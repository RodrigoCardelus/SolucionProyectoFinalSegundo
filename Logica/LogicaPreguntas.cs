using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPreguntas : ILogicaPreguntas
    {

        //Singleton 
        //1)atributo privado de clase que me permite almacenar mis objetos
        //en este caso sera un solo objeto (singleton puro)
        //inicializo en null, porque asi optimizo: hasta que alguien necesite un objeto mio,
        //no lo creo - optimizo memoria 
        private static LogicaPreguntas _instancia = null;


        //2)Constructor privado, no permite que nadie pueda crear objetos de la clase, solo yo
        //como no necesito nada... genero constructor vacio

        private LogicaPreguntas() { }


        //3)mecanismo para obtener un objeto de la Clase
        public static LogicaPreguntas GetInstancia()
        {

            if (_instancia == null) // no hay objeto.....
                _instancia = new LogicaPreguntas(); // creo uno, yo puedo por ser la clase

            return _instancia;

        }


        public void AgregarPreguntas(Preguntas unaP, EntidadesCompartidas.Usuario pLogueo)
        {
            FabricaPersistencia.getPersistenciaPreguntas().AgregarPreguntas(unaP, pLogueo);
        }

        public Preguntas BuscarPreguntas(string CodigoP, EntidadesCompartidas.Usuario pLogueo)
        {
            return (FabricaPersistencia.getPersistenciaPreguntas().BuscarPreguntas(CodigoP, pLogueo));
        }

        public List<Preguntas> ListaPreguntasNuncaUsadas(EntidadesCompartidas.Usuario pLogueo)
        {
            return (FabricaPersistencia.getPersistenciaPreguntas().ListaPreguntasNuncaUsadas(pLogueo));
        }

        public void AgregarPreguntasdeUnJuego(Preguntas unaP, Juegos unJ, Usuario pLogueo)
        {
            FabricaPersistencia.getPersistenciaPreguntadeUnJuego().AgregarPreguntasdeUnJuego(unaP, unJ, pLogueo);
        }

        public void EliminarPreguntasdeUnJuego(Preguntas unaP, Juegos unJ, EntidadesCompartidas.Usuario pLogueo)
        {
            FabricaPersistencia.getPersistenciaPreguntadeUnJuego().EliminarPreguntasdeUnJuego(unaP, unJ, pLogueo);
        }
    }
}