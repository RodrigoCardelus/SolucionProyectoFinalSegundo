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
    public interface IPersistenciaPreguntasdeUnJuego
    {
        void AgregarPreguntasdeUnJuego(Preguntas unaP, Juegos unJ, EntidadesCompartidas.Usuario pLogueo);

        void EliminarPreguntasdeUnJuego(Preguntas unaP, Juegos unJ, EntidadesCompartidas.Usuario pLogueo);
    }
}
