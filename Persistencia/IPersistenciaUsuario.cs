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
    public interface IPersistenciaUsuario
    {
        void AgregarUsuario(EntidadesCompartidas.Usuario pUsu, EntidadesCompartidas.Usuario pLogueo);
        
        void EliminarUsuario(EntidadesCompartidas.Usuario pUsu, EntidadesCompartidas.Usuario pLogueo);

        void ModificarUsuario(EntidadesCompartidas.Usuario pUsu, EntidadesCompartidas.Usuario pLogueo);

        Usuario BuscarUsuario(string UsuarioLogueo, EntidadesCompartidas.Usuario pLogueo);

        Usuario LogueoUsuario(string UsuarioLog, string Contraseña);

    }
}
