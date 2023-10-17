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
    internal class PersistenciaUsuario:IPersistenciaUsuario
    {
        //Singleton
        private static PersistenciaUsuario _instancia = null;

        private PersistenciaUsuario() { }

        public static PersistenciaUsuario GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaUsuario();

            return _instancia;

        }

        //Operaciones
        public void AgregarUsuario(Usuario unUsu, EntidadesCompartidas.Usuario pLogueo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("AltaUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            SqlParameter _usuarioLog = new SqlParameter("@UsuarioLog", unUsu.UsuarioLog);
            SqlParameter _contraseña = new SqlParameter("@Contraseña", unUsu.Contraseña);
            SqlParameter _nombreCompleto = new SqlParameter("@NombreC", unUsu.NombreC);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_usuarioLog);
            oComando.Parameters.Add(_contraseña);
            oComando.Parameters.Add(_nombreCompleto);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El Usuario de Logueo no se pudo crear");
                if (oAfectados == -2)
                    throw new Exception("El Usuario de Sql no se pudo crear");
                if (oAfectados == -3)
                    throw new Exception("El Usuario ya existe");
                if (oAfectados == -4)
                    throw new Exception("No se puedo ejecutar el Insert del Usuario");
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

        public Usuario BuscarUsuario(string UsuarioLog, EntidadesCompartidas.Usuario pLogueo)
        {
            string _usuarioLog;
            string _contraseña;
            string _nombreC;


            Usuario unUsu = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand cmd = new SqlCommand("BuscoUsuarioActivo", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsuarioLog", UsuarioLog);


            SqlDataReader oReader;

            try
            {
                //conecto a la base de datos
                cnn.Open();
                oReader = cmd.ExecuteReader();

                /*Select*
                From Usuario
                where UsuarioLog = @UsuarioLog AND Activo = 1*/

                if (oReader.Read())
                {
                    _usuarioLog = (string)oReader["UsuarioLog"];
                    _contraseña = (string)oReader["Contraseña"];
                    _nombreC = (string)oReader["NombreC"];
                    unUsu = new Usuario(_usuarioLog, _contraseña, _nombreC);
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
            return unUsu;
        }

        internal Usuario BuscarTodos(string pUsuarioLog)
        {
            string _usuarioLog;
            string _contraseña;
            string _nombreC;
            Usuario unUsu = null;
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn());
            SqlCommand oComando = new SqlCommand("Exec BuscoUsuario " + pUsuarioLog, oConexion);


            SqlDataReader oReader;

            try
            {
                //conecto a la base de datos
                oConexion.Open();

                oReader = oComando.ExecuteReader();
                /*Select*
                From Usuario
                where UsuarioLog = @UsuarioLog*/

                if (oReader.Read())
                {
                    _usuarioLog = (string)oReader["UsuarioLog"];
                    _contraseña = (string)oReader["Contraseña"];
                    _nombreC = (string)oReader["NombreC"];
                    unUsu = new Usuario(_usuarioLog, _contraseña, _nombreC);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return unUsu;
        }

        public void EliminarUsuario(Usuario unUsu, EntidadesCompartidas.Usuario pLogueo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("BajaUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _usuarioLog = new SqlParameter("@UsuarioLog", unUsu.UsuarioLog);

            SqlParameter _Retorno = new SqlParameter("@retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_usuarioLog);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El usuario no existe");
                if (oAfectados == -2)
                    throw new Exception("Si el Usuario esta mal eliminado devuelve -2");
                if (oAfectados == -3)
                    throw new Exception("El Usuario de Logueo esta mal eliminado devuelve -3");
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

        public void ModificarUsuario(Usuario unUsu, EntidadesCompartidas.Usuario pLogueo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("ModificarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            SqlParameter _usuarioLog = new SqlParameter("@UsuarioLog", unUsu.UsuarioLog);
            SqlParameter _contraseña = new SqlParameter("@Contraseña", unUsu.Contraseña);
            SqlParameter _nombreCompleto = new SqlParameter("@NombreC ", unUsu.NombreC);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_usuarioLog);
            oComando.Parameters.Add(_contraseña);
            oComando.Parameters.Add(_nombreCompleto);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El Usuario no existe");
                if (oAfectados == -2)
                    throw new Exception("Error al Modificar el Usuario");
                if (oAfectados == -3)
                    throw new Exception("Error al Modificar el Logueo de Usuario");
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

        public Usuario LogueoUsuario(string UsuarioLog, string Contraseña)
        {

            Usuario unUsu = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn());
            SqlCommand cmd = new SqlCommand("LogueoUsuario", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsuarioLog", UsuarioLog);
            cmd.Parameters.AddWithValue("@Contraseña", Contraseña);


            try
            {

                //conecto a la base de datos
                cnn.Open();

                SqlDataReader lector = cmd.ExecuteReader();
               /*select*
               from Usuario
               where UsuarioLog = @UsuarioLog AND Contraseña = @Contraseña AND Activo = 1*/

                if (lector.HasRows)
                {

                    lector.Read();

                    string nombreC = (string)lector[2];

                    unUsu = new Usuario(UsuarioLog, Contraseña, nombreC);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }

            return unUsu;
        }
    }
}
 