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
    internal class PersistenciaPreguntasdeUnJuego : IPersistenciaPreguntasdeUnJuego
    {
        //Singleton
        private static PersistenciaPreguntasdeUnJuego _instancia = null;

        private PersistenciaPreguntasdeUnJuego() { }

        public static PersistenciaPreguntasdeUnJuego GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPreguntasdeUnJuego();

            return _instancia;
        }

        //Operaciones

        public void AgregarPreguntasdeUnJuego(Preguntas unaP, Juegos unJ, Usuario pLogueo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("AltaPreguntasdeUnJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            SqlParameter _codigoP = new SqlParameter("@CodigoP", unaP.CodigoP);
            SqlParameter _codigo = new SqlParameter("@Codigo", unJ.Codigo);


            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigoP);
            oComando.Parameters.Add(_codigo);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La Pregunta no existe");
                if (oAfectados == -2)
                    throw new Exception("El Juego no existe");
                if (oAfectados == -3)
                    throw new Exception("Ya Existen Preguntas de Un Juego");
                if (oAfectados == -4)
                    throw new Exception("Error al Insertar Preguntas de Un Juego");
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

        public void EliminarPreguntasdeUnJuego(Preguntas unaP, Juegos unJ, EntidadesCompartidas.Usuario pLogueo)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("EliminarPreguntasdeUnJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            SqlParameter _codigoP = new SqlParameter("@CodigoP", unaP.CodigoP);
            SqlParameter _codigo = new SqlParameter("@Codigo", unJ.Codigo);


            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigoP);
            oComando.Parameters.Add(_codigo);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("No Existe las Preguntas de UnJuego");
                if (oAfectados == -2)
                    throw new Exception("Error al Eliminar PreguntasdeUnJuego");
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

    }
}
