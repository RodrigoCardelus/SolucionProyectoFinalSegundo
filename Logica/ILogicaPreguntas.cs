using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntidadesCompartidas;
using Persistencia;


namespace Logica
{
    public interface ILogicaPreguntas
    {
        void AgregarPreguntas(Preguntas unaP, EntidadesCompartidas.Usuario pLogueo);

        Preguntas BuscarPreguntas(string CodigoP, EntidadesCompartidas.Usuario pLogueo);

        List<Preguntas> ListaPreguntasNuncaUsadas(EntidadesCompartidas.Usuario pLogueo);

        void AgregarPreguntasdeUnJuego(Preguntas unaP, Juegos unJ, Usuario pLogueo);

        void EliminarPreguntasdeUnJuego(Preguntas unaP, Juegos unJ, EntidadesCompartidas.Usuario pLogueo);

    }
}