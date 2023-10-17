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
    internal class PersistenciaJugar:IPersistenciaJugar
    {

        //Singleton
        private static PersistenciaJugar _instancia = null;

        private PersistenciaJugar() { }

        public static PersistenciaJugar GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaJugar();

            return _instancia;
        }

        //Operaciones
        public void JugarJuegos(Jugar J)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn());
            SqlCommand oComando = new SqlCommand("JugarJuegos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            SqlParameter _codigo = new SqlParameter("@Codigo", J.UnJuego.Codigo);
            SqlParameter _nombre = new SqlParameter("@Nombre", J.Nombre);
            SqlParameter _puntaje = new SqlParameter("@Puntaje", J.Puntaje);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigo);
            oComando.Parameters.Add(_nombre);
            oComando.Parameters.Add(_puntaje);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == 1)
                    throw new Exception("El Juego no existe");
                if (oAfectados == -2)
                    throw new Exception("Error en Agregar la Jugada");
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

        public List<Jugar> ListadoJugadas()
        {
            Jugar J = null;
            DateTime _fechaHora;
            int _codigo;
            Juegos unJ;
            string _nombre;
            int _puntaje;
          

            List<Jugar> _Lista = new List<Jugar>();


            /*Create Procedure ListadoJugadas AS*/

            SqlConnection cnn = new SqlConnection(Conexion.Cnn());
            SqlCommand cmd = new SqlCommand("ListadoJugadas", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader oReader;

            try
            {
                cnn.Open();
                oReader = cmd.ExecuteReader();
                if (oReader.Read())
                {

                    _fechaHora = (DateTime)oReader["FechaHora"];
                    _codigo = (int)oReader["Codigo"];
                    unJ = PersistenciaJuegos.GetInstancia().BuscarJuegos(_codigo);
                    _nombre = (string)oReader["Nombre"];
                    _puntaje = (int)oReader["Puntaje"];


                    J = new Jugar(_fechaHora, unJ, _nombre, _puntaje);
                    _Lista.Add(J);
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
            return _Lista;
         }
    }
}
