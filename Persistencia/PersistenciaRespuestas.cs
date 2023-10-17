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
    internal class PersistenciaRespuestas
    {
        //Singleton
        private static PersistenciaRespuestas _instancia = null;

        private PersistenciaRespuestas() { }

        public static PersistenciaRespuestas GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaRespuestas();

            return _instancia;
        }

        //Operaciones
      
        internal void AgregarRespuestas(Respuestas unaR, string CodigoP, SqlTransaction _pTransaccion)
        {

            SqlCommand oComando = new SqlCommand("AltaRespuestas", _pTransaccion.Connection);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigoInterno = new SqlParameter("@CodigoP ", CodigoP);
            SqlParameter _textoR = new SqlParameter("@TextoR ", unaR.TextoR);
            SqlParameter _resultado = new SqlParameter("@Resultado", unaR.Resultado);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(_ParmRetorno);



            oComando.Parameters.Add(_textoR);
            oComando.Parameters.Add(_resultado);

            try
            {
              
                //determino que debo trabajar con la misma transaccion
                oComando.Transaction = _pTransaccion;

                //ejecuto comando
                oComando.ExecuteNonQuery(); //se ejecuta dentro de la TRN Logica

                //verifico si hay errores
                int oAfectados = Convert.ToInt32(_ParmRetorno.Value);
                if (oAfectados == -1)
                    throw new Exception("No existe la Pregunta");
                if (oAfectados == -2)
                    throw new Exception("Error al Insertar las Respuestas");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Respuestas> ListadoRespuestasdeUnaPregunta(string CodigoP)
        {

            /*Create Procedure ListadoRespuestasdeUnaPregunta @CodigoP varchar(5) AS*/

            
            int _codigoInterno;
            string _textoR;
            bool _resultado;
            Respuestas unaR = null;

            List<Respuestas> ListadoRespuestas = new List<Respuestas>();
            List<Preguntas> _Lista = new List<Preguntas>();
 
            SqlConnection cnn = new SqlConnection(Conexion.Cnn());
            SqlCommand oComando = new SqlCommand("ListadoRespuestasdeUnaPregunta", cnn);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@CodigoP", CodigoP);



            SqlDataReader _Reader;
            try
            {
                // conecto a la bd
                 cnn.Open();
                _Reader = oComando.ExecuteReader();
                while (_Reader.Read())
                {
                    
                    _codigoInterno = (int)_Reader["CodigoInterno"];
                    _textoR = (string)_Reader["TextoR"];
                    _resultado = (bool)_Reader["Resultado"];


                    unaR = new Respuestas(_codigoInterno, _textoR, _resultado);
                    ListadoRespuestas.Add(unaR);

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
            return ListadoRespuestas;
        }
    }
}
