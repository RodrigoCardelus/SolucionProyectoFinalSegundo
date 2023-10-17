using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public interface ILogicaJugar
    {
        void JugarJuegos(Jugar J);

        List<Jugar> ListadoJugadas();
    }
}