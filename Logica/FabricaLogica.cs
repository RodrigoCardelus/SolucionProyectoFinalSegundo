using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class FabricaLogica
    {

        public static ILogicaUsuario getLogicaUsuario()
        {
            return (LogicaUsuario.GetInstancia());

        }

        public static ILogicaJuegos getLogicaJuegos()
        {
            return (LogicaJuegos.GetInstancia());

        }

        public static ILogicaJugar getLogicaJugar()
        {
            return (LogicaJugar.GetInstancia());
        }

        public static ILogicaPreguntas getLogicaPreguntas()
        {
            return (LogicaPreguntas.GetInstancia());
        }

        public static ILogicaCategorias getLogicaCategorias()
        {
            return (LogicaCategorias.GetInstancia());
        }
    }
}
