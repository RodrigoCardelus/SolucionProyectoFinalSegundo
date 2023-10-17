using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Categorias
    {
        #region Atributos
        string codigoC;
        string nombre;
        #endregion

        #region Propiedades
        [DataMember]
        public string CodigoC
        {
            get { return codigoC; }
            set
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(value, "[A-Z]{4}"))
                    codigoC = value;
                else
                    throw new Exception("Formato de contraseña no valido");
            }
        }

        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if(value.Trim().Length == 0 || value.Trim().Length > 20)
                {

                    throw new Exception("El Nombre no puede ser vacio o mayor a 20 caracteres");
                }
             nombre = value;
            }
        }
        #endregion

        public Categorias(string pCodigoC, string pNombre)
        {
            CodigoC = pCodigoC;
            Nombre = pNombre; 
        }


        public Categorias() { }
      
        //falta hacer data contract y data member y el Constructor por Defecto
    }
}
