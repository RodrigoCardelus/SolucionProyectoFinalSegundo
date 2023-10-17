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
    internal class PersistenciaCategorias:IPersistenciaCategorias
    {
        //Singleton
        private static PersistenciaCategorias _instancia = null;

        private PersistenciaCategorias() { }

        public static PersistenciaCategorias GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaCategorias();

            return _instancia;
        }


        //Operaciones
        public void AgregarCategorias(Categorias unaC, EntidadesCompartidas.Usuario pLogueo)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("AltaCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            SqlParameter _codigoC = new SqlParameter("@CodigoC", unaC.CodigoC);
            SqlParameter _nombre = new SqlParameter("@Nombre", unaC.Nombre);
         

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigoC);
            oComando.Parameters.Add(_nombre);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La Categoria ya existe");
                if (oAfectados == -2)
                    throw new Exception("Error al Insertar la Categoria");
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

        public void EliminarCategorias(Categorias unaC, EntidadesCompartidas.Usuario pLogueo)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("BajaCategorias", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter CodigoC = new SqlParameter("@CodigoC", unaC.CodigoC);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(CodigoC);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La Categoria no existe");
                if (oAfectados == -2)
                    throw new Exception("Error al Eliminar la Categoria");
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

        public void ModificarCategorias(Categorias unaC, EntidadesCompartidas.Usuario pLogueo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("ModificarCategorias", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            /*Create Procedure ModificarCategorias @CodigoC varchar(4), @Nombre varchar(20) AS */

            SqlParameter _codigoC = new SqlParameter("@CodigoC", unaC.CodigoC);
            SqlParameter _nombre = new SqlParameter("@Nombre", unaC.Nombre);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_codigoC);
            oComando.Parameters.Add(_nombre);
            oComando.Parameters.Add(_Retorno);
            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La Categoria no existe");
                if (oAfectados == -2)
                    throw new Exception("Error al Modificar la Categoria");

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

        internal Categorias BuscarCategorias(string CodigoC)
        {
            string _codigoC;
            string _nombre;
            Categorias unaC = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn());
            SqlCommand cmd = new SqlCommand("BuscoCategorias", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoC", CodigoC);

            SqlDataReader oReader;

            try
            {
                 cnn.Open();
                 oReader = cmd.ExecuteReader();
                 if (oReader.Read())
                 {
                      _codigoC = (string)oReader["CodigoC"];
                      _nombre = (string)oReader["Nombre"];
                      unaC = new Categorias(_codigoC, _nombre);
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
          return unaC;
        }

        public Categorias BuscarCategoriasActivo(string CodigoC, Usuario pLogueo)
        {
            string _codigoC;
            string _nombre;
            Categorias unaC = null;
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand oComando = new SqlCommand("BuscoCategoriasActivo", oConexion);
            oComando.CommandType = System.Data.CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@CodigoC", CodigoC);

            SqlDataReader oReader;


            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    _codigoC = (string)oReader["CodigoC"];
                    _nombre = (string)oReader["Nombre"];
                    unaC = new Categorias(CodigoC, _nombre);
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
            return unaC;
        }
    }
}
