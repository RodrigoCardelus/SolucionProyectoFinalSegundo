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
    internal class PersistenciaJuegos:IPersistenciaJuegos
    {
        //Singleton
        private static PersistenciaJuegos _instancia = null;

        private PersistenciaJuegos() { }

        public static PersistenciaJuegos GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaJuegos();

            return _instancia;
        }

        //Operaciones
        public void AgregarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("AltaJuegos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            SqlParameter _usuarioLog = new SqlParameter("@UsuarioLog", unJ.UnUsuario.UsuarioLog);
            SqlParameter _dificultad = new SqlParameter("@Dificultad", unJ.Dificultad);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;


            oComando.Parameters.Add(_usuarioLog);
            oComando.Parameters.Add(_dificultad);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El Usuario no Existe");
                if (oAfectados == -2)
                    throw new Exception("Error al Insertar los Juegos");

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

        public Juegos BuscarJuegos(int Codigo, EntidadesCompartidas.Usuario pLogueo = null)
        {
            
            Usuario unUsuario;
            string _usuarioLogueo;
            string _dificultad;
            DateTime _fechac;

            List<Preguntas> _ListadoPreguntas = new List<Preguntas>();


            Juegos unJ = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand cmd = new SqlCommand("BuscoJuegos", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Codigo", Codigo);


            SqlDataReader oReader;

            try
            {
                cnn.Open();
                oReader = cmd.ExecuteReader();
                if (oReader.Read())
                {
                    _usuarioLogueo = (string)oReader["UsuarioLog"];
                    unUsuario = Persistencia.PersistenciaUsuario.GetInstancia().BuscarUsuario(_usuarioLogueo, pLogueo);
                    _dificultad = (string)oReader["Dificultad"];
                    _fechac = (DateTime)oReader["FechaC"];
                    _ListadoPreguntas = PersistenciaPreguntas.GetInstancia().ListadoPreguntasdeUnJuego(Codigo);

                    unJ = new Juegos(Codigo, unUsuario, _dificultad, _fechac, _ListadoPreguntas);
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
            return unJ;
        }


        public void EliminarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("BajaJuegos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigo = new SqlParameter("@Codigo", unJ.Codigo);

            SqlParameter _Retorno = new SqlParameter("@retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigo);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El Juego no existe");
                if (oAfectados == -2)
                    throw new Exception("Hay Jugadas asociadas y no se puede eliminar");
                if (oAfectados == -3)
                    throw new Exception("Error al Eliminar los Juegos");
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


        public void ModificarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("ModificarJuegos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigo = new SqlParameter("@Codigo", unJ.Codigo);
            SqlParameter _usuarioLog = new SqlParameter("@UsuarioLog", unJ.UnUsuario.UsuarioLog);
            SqlParameter _dificultad = new SqlParameter("@Dificultad", unJ.Dificultad);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigo);
            oComando.Parameters.Add(_usuarioLog);
            oComando.Parameters.Add(_dificultad);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El Juego no existe");
                if (oAfectados == -2)
                    throw new Exception("El Usuario no existe");
                if (oAfectados == -3)
                    throw new Exception("Error al Modificar los Juegos");
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

        public List<Juegos> ListaJuegosNuncaUsados(EntidadesCompartidas.Usuario pLogueo)
        {

            int _codigo;
            Usuario unUsu;
            string _usuarioLog;
            string _dificultad;
            DateTime _fechaC;


            List<Juegos> ListadoJuegos = new List<Juegos>();

            List<Preguntas> ListadoPreguntas = new List<Preguntas>();

            /*Create Procedure ListadoJuegosNuncaUsados AS*/

            SqlConnection cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand cmd = new SqlCommand("ListadoJuegosNuncaUsados", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader _Reader;
            try
            {
                // conecto a la bd
                cnn.Open();
                _Reader = cmd.ExecuteReader();
                while (_Reader.Read())
                {
                    _codigo = (int)_Reader["Codigo"];
                    _usuarioLog = (string)_Reader["UsuarioLog"];
                    unUsu = PersistenciaUsuario.GetInstancia().BuscarUsuario(_usuarioLog, pLogueo);
                    _dificultad = (string)_Reader["Dificultad"];
                    _fechaC = (DateTime)_Reader["FechaC"];
                    ListadoPreguntas = PersistenciaPreguntas.GetInstancia().ListadoPreguntasdeUnJuego(_codigo);

                    Juegos unJ = new Juegos(_codigo, unUsu, _dificultad, _fechaC, ListadoPreguntas);
                    ListadoJuegos.Add(unJ);

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
            return ListadoJuegos;
        }

        public List<Juegos> ListaJuegosVacios(EntidadesCompartidas.Usuario pLogueo)
        {

            int _codigo;
            string _usuarioLog;
            Usuario unUsu;
            string _dificultad;
            DateTime _fechaC;

            List<Juegos> ListadoJuegos = new List<Juegos>();
            List<Preguntas> _ListadoPreguntas = new List<Preguntas>();


            /*Create Procedure ListadoJuegosVacios AS*/

            SqlConnection cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand cmd = new SqlCommand("ListadoJuegosVacios", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader _Reader;
            try
            {
                // conecto a la bd
                cnn.Open();
                _Reader = cmd.ExecuteReader();
                while (_Reader.Read())
                {
                    _codigo = (int)_Reader["Codigo"];
                    _usuarioLog = (string)_Reader["UsuarioLog"];
                    unUsu = PersistenciaUsuario.GetInstancia().BuscarUsuario(_usuarioLog, pLogueo);
                    _dificultad = (string)_Reader["Dificultad"];
                    _fechaC = (DateTime)_Reader["FechaC"];
                    _ListadoPreguntas = PersistenciaPreguntas.GetInstancia().ListadoPreguntasdeUnJuego(_codigo);
                    

                    Juegos unJ = new Juegos(_codigo, unUsu, _dificultad, _fechaC, _ListadoPreguntas);
                    ListadoJuegos.Add(unJ);
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
            return ListadoJuegos;
         }
       
        public List<Juegos> ListadoJuegosConPreguntas()
        {

            int _codigo;
            string _usuarioLog;
            Usuario unUsu;
            string _dificultad;
            DateTime _fechaC;
        
         
            List<Preguntas> _ListadoPreguntas = new List<Preguntas>();
            List<Juegos> _ListadoJuegos = new List<Juegos>();
            
          

            /*Create Procedure ListadoJuegosConPreguntas AS*/

            SqlConnection cnn = new SqlConnection(Conexion.Cnn());
            SqlCommand cmd = new SqlCommand("ListadoJuegosConPreguntas", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader _Reader;
            try
            {
                // conecto a la bd
                cnn.Open();
                _Reader = cmd.ExecuteReader();
                while (_Reader.Read())
                {
                    _codigo = (int)_Reader["Codigo"];
                    _usuarioLog = (string)_Reader["UsuarioLog"];
                    unUsu = PersistenciaUsuario.GetInstancia().BuscarTodos(_usuarioLog);
                    _dificultad = (string)_Reader["Dificultad"];
                    _fechaC = (DateTime)_Reader["FechaC"];
                    _ListadoPreguntas = PersistenciaPreguntas.GetInstancia().ListadoPreguntasdeUnJuego(_codigo);
              

                    Juegos unJ = new Juegos(_codigo, unUsu, _dificultad, _fechaC, _ListadoPreguntas);
                    _ListadoJuegos.Add(unJ);

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
            return _ListadoJuegos;
        }
    }
 }



