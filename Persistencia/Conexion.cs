using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Conexion
    {
        internal static string Cnn(EntidadesCompartidas.Usuario pUsu = null)
        {
            if (pUsu == null)
                return "Data Source =.; Initial Catalog = ProyectoFinalSegundo; Integrated Security = true";
            else
                return "Data Source =.; Initial Catalog = ProyectoFinalSegundo; User=" + pUsu.UsuarioLog + "; Password='" + pUsu.Contraseña + "'";
        }
    }
}
