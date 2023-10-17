using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;


namespace Persistencia
{
    internal class PersistenciaPreguntas: IPersistenciaPreguntas
    {
        //Singleton
        private static PersistenciaPreguntas _instancia = null;

        private PersistenciaPreguntas() { }

        public static PersistenciaPreguntas GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPreguntas();

            return _instancia;
        }


        //Operaciones
        public void AgregarPreguntas(Preguntas unaP, EntidadesCompartidas.Usuario pLogueo)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("AltaPreguntas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            SqlParameter _codigoP = new SqlParameter("@CodigoP", unaP.CodigoP);
            SqlParameter _codigoC = new SqlParameter("@CodigoC", unaP.UnaCategoria.CodigoC);
            SqlParameter _texto = new SqlParameter("@Texto ", unaP.Texto);
            SqlParameter _puntaje = new SqlParameter("@Puntaje", unaP.Puntaje);


            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigoP);
            oComando.Parameters.Add(_codigoC);
            oComando.Parameters.Add(_texto);
            oComando.Parameters.Add(_puntaje);
            oComando.Parameters.Add(_Retorno);

            SqlTransaction _miTransaccion = null;

            try
            {
                //conecto a la bd
                oConexion.Open();

                //determino que voy a trabar con esa unica transaccion
                _miTransaccion = oConexion.BeginTransaction();

                //ejecuto comando de alta del Cliente en la transaccion
                oComando.Transaction = _miTransaccion;
                oComando.ExecuteNonQuery(); //se ejecuta dentro de la TRN Logica

                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La Pregunta ya existe");
                if (oAfectados == -2)
                    throw new Exception("No existe la Categoria asociada a la Pregunta");
                if (oAfectados == -3)
                    throw new Exception("Error al Insertar las Preguntas");

                //si llego aca es porque pude dar de alta la Pregunta
                foreach (EntidadesCompartidas.Respuestas unaR in unaP.ListadoRespuestas)
                { 
                    PersistenciaRespuestas.GetInstancia().AgregarRespuestas(unaR, unaP.CodigoP, _miTransaccion);

                }

                //si llegue aca es porque no hubo problemas con los telefonos
                _miTransaccion.Commit();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }


        public Preguntas BuscarPreguntas(string CodigoP, EntidadesCompartidas.Usuario pLogueo)
        {

            Categorias unaC;
            string _codigoC;
            string _codigoP;
            Preguntas unaP = null;
            string _texto;
            int _puntaje;

            List<Respuestas> ListadoRespuestas = new List<Respuestas>();

            SqlConnection cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand cmd = new SqlCommand("BuscoPreguntas", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoP", CodigoP);


            SqlDataReader oReader;

            try
            {
                cnn.Open();
                oReader = cmd.ExecuteReader();
                if (oReader.Read())
                {
                    _codigoP = (string)oReader["CodigoP"];
                    _codigoC = (string)oReader["CodigoC"];
                    unaC = PersistenciaCategorias.GetInstancia().BuscarCategorias(_codigoC);
                    _texto = (string)oReader["Texto"];
                    _puntaje = (int)oReader["Puntaje"];
                    ListadoRespuestas = PersistenciaRespuestas.GetInstancia().ListadoRespuestasdeUnaPregunta(CodigoP);
                
                    unaP = new Preguntas(CodigoP, unaC, _texto, _puntaje, ListadoRespuestas);
               
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return unaP;
        }


        public List<Preguntas> ListaPreguntasNuncaUsadas(EntidadesCompartidas.Usuario pLogueo)
        {
            
            string _codigoP;
            Preguntas unaP;
            Categorias unaCategoria;
            string _codigoC;
            string _texto;
            int _puntaje;

            List<Respuestas> ListadoRespuestas = new List<Respuestas>();
            List<Preguntas> _Lista = new List<Preguntas>();
         

            /*Create Procedure ListadoPreguntasNuncaUsadas AS*/

            SqlConnection cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand cmd = new SqlCommand("ListadoPreguntasNuncaUsadas", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader _Reader;
     
            try
            {
                // conecto a la bd
                cnn.Open();
                _Reader = cmd.ExecuteReader();
                while (_Reader.Read())
                {
                    _codigoP = (string)_Reader["CodigoP"];
                    _codigoC = (string)_Reader["CodigoC"];
                    unaCategoria = PersistenciaCategorias.GetInstancia().BuscarCategorias(_codigoC);
                    _texto = (string)_Reader["Texto"];
                    _puntaje = (int)_Reader["Puntaje"];
                    ListadoRespuestas = PersistenciaRespuestas.GetInstancia().ListadoRespuestasdeUnaPregunta(_codigoP);
                    unaP = new Preguntas(_codigoP, unaCategoria, _texto,_puntaje,ListadoRespuestas);
                    _Lista.Add(unaP);


                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return _Lista;
        }

        internal List<Preguntas> ListadoPreguntasdeUnJuego(int Codigo)
        {

            string _codigoP;
            Preguntas unaP = null;
            string _codigoC;
            Categorias unaC = null;
            string _texto;
            int _puntaje;


            List<Preguntas> _Lista = new List<Preguntas>();
            List<Respuestas> _ListaRespuestas = new List<Respuestas>();

            /*Create Procedure ListadoPreguntasdeUnJuego @Codigo int AS*/

            SqlConnection cnn = new SqlConnection(Conexion.Cnn());
            SqlCommand cmd = new SqlCommand("ListadoPreguntasdeUnJuego", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Codigo", Codigo);
       
      

            SqlDataReader _Reader;

            try
            {
                // conecto a la bd
                cnn.Open();
                _Reader = cmd.ExecuteReader();
                while (_Reader.Read())
                {
                    _codigoP = (string)_Reader["CodigoP"];
                    _codigoC = (string)_Reader["CodigoC"];
                    unaC = PersistenciaCategorias.GetInstancia().BuscarCategorias(_codigoC);
                    _texto = (string)_Reader["Texto"];
                    _puntaje = (int)_Reader["Puntaje"];
                    _ListaRespuestas = PersistenciaRespuestas.GetInstancia().ListadoRespuestasdeUnaPregunta(_codigoP);


                    unaP = new Preguntas(_codigoP,unaC,_texto, _puntaje, _ListaRespuestas);
                    _Lista.Add(unaP);


                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return _Lista;
        }

    }
}

