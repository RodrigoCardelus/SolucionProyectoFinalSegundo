using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario:ILogicaUsuario
    {

        //Singleton 
        //1)atributo privado de clase que me permite almacenar mis objetos
        //en este caso sera un solo objeto (singleton puro)
        //inicializo en null, porque asi optimizo: hasta que alguien necesite un objeto mio,
        //no lo creo - optimizo memoria 
        private static LogicaUsuario _instancia = null;


        //2)Constructor privado, no permite que nadie pueda crear objetos de la clase, solo yo
        //como no necesito nada... genero constructor vacio

        private LogicaUsuario() { }


        //3)mecanismo para obtener un objeto de la Clase
        public static LogicaUsuario GetInstancia()
        {

            if (_instancia == null) // no hay objeto.....
                _instancia = new LogicaUsuario(); // creo uno, yo puedo por ser la clase

            return _instancia;

        }
        //fin Singleton

        public void AgregarUsuario(Usuario unUsu, EntidadesCompartidas.Usuario pLogueo)
        {
            FabricaPersistencia.getPersistenciaUsuario().AgregarUsuario(unUsu, pLogueo);
        }

        public Usuario BuscarUsuario(string UsuarioLog, EntidadesCompartidas.Usuario pLogueo)
        {
            return (FabricaPersistencia.getPersistenciaUsuario().BuscarUsuario(UsuarioLog, pLogueo));
        }

        public void EliminarUsuario(Usuario unUsu, EntidadesCompartidas.Usuario pLogueo)
        {
            FabricaPersistencia.getPersistenciaUsuario().EliminarUsuario(unUsu, pLogueo);
        }

        public void ModificarUsuario(Usuario unUsu, EntidadesCompartidas.Usuario pLogueo)
        {
            FabricaPersistencia.getPersistenciaUsuario().ModificarUsuario(unUsu, pLogueo);
        }

        public Usuario LogueoUsuario(string UsuarioLog, string Contraseña)
        {
            return (FabricaPersistencia.getPersistenciaUsuario().LogueoUsuario(UsuarioLog, Contraseña));
        }
    }
}
