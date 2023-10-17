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
    public interface IPersistenciaJuegos
    {
        void AgregarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo);

        void EliminarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo);

        void ModificarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo);

        Juegos BuscarJuegos(int Codigo, EntidadesCompartidas.Usuario pLogueo);

        List<Juegos> ListaJuegosNuncaUsados(EntidadesCompartidas.Usuario pLogueo);

        List<Juegos> ListaJuegosVacios(EntidadesCompartidas.Usuario pLogueo);

        List<Juegos> ListadoJuegosConPreguntas();

    }
}
