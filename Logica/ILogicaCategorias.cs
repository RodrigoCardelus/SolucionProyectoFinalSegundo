using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;


namespace Logica
{
    public interface ILogicaCategorias
    {
        void AgregarCategorias(Categorias unaC, EntidadesCompartidas.Usuario pLogueo);

        void EliminarCategorias(Categorias unaC, EntidadesCompartidas.Usuario pLogueo);

        void ModificarCategorias(Categorias unaC, EntidadesCompartidas.Usuario pLogueo);

        Categorias BuscarCategoriasActivo(string CodigoC, EntidadesCompartidas.Usuario pLogueo);


    }
}
