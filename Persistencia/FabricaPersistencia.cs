using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EntidadesCompartidas;


namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPersistenciaUsuario getPersistenciaUsuario()
        {
            return (PersistenciaUsuario.GetInstancia());
        }

        public static IPersistenciaJuegos getPersistenciaJuegos()
        {
            return (PersistenciaJuegos.GetInstancia());
        }

        public static IPersistenciaCategorias getPersistenciaCategorias()
        {
            return (PersistenciaCategorias.GetInstancia());
        }

        public static IPersistenciaPreguntas getPersistenciaPreguntas()
        {
            return (PersistenciaPreguntas.GetInstancia());
        }

        public static IPersistenciaJugar getPersistenciaJugar()
        {
            return (PersistenciaJugar.GetInstancia());
        }

        public static IPersistenciaPreguntasdeUnJuego getPersistenciaPreguntadeUnJuego()
        {
            return (PersistenciaPreguntasdeUnJuego.GetInstancia());
        }

    }
}
