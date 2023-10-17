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
    public interface IPersistenciaPreguntas
    {
        void AgregarPreguntas(Preguntas unaP, EntidadesCompartidas.Usuario pLogueo);

        Preguntas BuscarPreguntas(string CodigoP, EntidadesCompartidas.Usuario pLogueo);

        List<Preguntas> ListaPreguntasNuncaUsadas(EntidadesCompartidas.Usuario pLogueo);

      
    }
}
