using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public interface ILogicaJuegos
    {
        void AgregarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo);

        Juegos BuscarJuegos(int Codigo, EntidadesCompartidas.Usuario pLogueo);

        void EliminarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo);

        void ModificarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo);

        List<Juegos> ListaJuegosNuncaUsados(EntidadesCompartidas.Usuario pLogueo);

        List<Juegos> ListaJuegosVacios(EntidadesCompartidas.Usuario pLogueo);

        List<Juegos> ListaJuegosConPreguntas();
    }
}