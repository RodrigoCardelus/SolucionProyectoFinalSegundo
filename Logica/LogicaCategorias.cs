using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;


namespace Logica
{
    public class LogicaCategorias: ILogicaCategorias
    {
        // Singleton
        //1)atributo privado de clase que me permite almacenar mis objetos
        //en este caso sera un solo objeto (singleton puro)
        //inicializo en null, porque asi optimizo: hasta que alguien necesite un objeto mio,
        //no lo creo - optimizo memoria 
        private static LogicaCategorias _instancia = null;


        //2)Constructor privado, no permite que nadie pueda crear objetos de la clase, solo yo
        //como no necesito nada... genero constructor vacio

        private LogicaCategorias() { }


        //3)mecanismo para obtener un objeto de la Clase
        public static LogicaCategorias GetInstancia()
        {

            if (_instancia == null) // no hay objeto.....
                _instancia = new LogicaCategorias(); // creo uno, yo puedo por ser la clase

            return _instancia;

        }
        //fin Singleton


        public void AgregarCategorias(Categorias unaC, EntidadesCompartidas.Usuario pLogueo)
        {
            FabricaPersistencia.getPersistenciaCategorias().AgregarCategorias(unaC, pLogueo);
        }

        public void EliminarCategorias(Categorias unaC, EntidadesCompartidas.Usuario pLogueo)
        {
            FabricaPersistencia.getPersistenciaCategorias().EliminarCategorias(unaC, pLogueo);
        }

        public void ModificarCategorias(Categorias unaC, EntidadesCompartidas.Usuario pLogueo)
        {
            FabricaPersistencia.getPersistenciaCategorias().ModificarCategorias(unaC, pLogueo);
        }

        public Categorias BuscarCategoriasActivo(string CodigoC, EntidadesCompartidas.Usuario pLogueo)
        {
            return (FabricaPersistencia.getPersistenciaCategorias().BuscarCategoriasActivo(CodigoC, pLogueo));
        }

    }
}
