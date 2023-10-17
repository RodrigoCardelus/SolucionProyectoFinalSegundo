using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public interface ILogicaUsuario
    {
        void AgregarUsuario(Usuario unUsu, EntidadesCompartidas.Usuario pLogueo);

        Usuario BuscarUsuario(string UsuarioLog, EntidadesCompartidas.Usuario pLogueo);

        void EliminarUsuario(Usuario unUsu, EntidadesCompartidas.Usuario pLogueo);

        void ModificarUsuario(Usuario unUsu, EntidadesCompartidas.Usuario pLogueo);

        Usuario LogueoUsuario(string UsuarioLog, string Contraseña);
    }
}
