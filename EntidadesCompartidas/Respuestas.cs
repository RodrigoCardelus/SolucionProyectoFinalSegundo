using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Respuestas
    {
        #region Atributos
        int codigoInterno;
        string textoR;
        bool resultado;

        #endregion

        #region Propiedades
        [DataMember]
        public int CodigoInterno
        {
            get { return codigoInterno; }
            set { codigoInterno = value; }
        }

        [DataMember]
        public string TextoR
        {
            get { return textoR; }
            set
            {

                if (value.Trim().Length == 0 || value.Length > 50)
                {
                    throw new Exception("El Texto de la Respuesta no puede ser mayor a 50 caracteres");
                }
                textoR = value;
            }
        }
        //no puede estar nulo el TextoR

        [DataMember]
        public bool Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        #endregion

        #region Constructor
        public Respuestas(int pCodigoInterno, string pTextoR, bool pResultado)
        {
            CodigoInterno = pCodigoInterno;
            TextoR = pTextoR;
            Resultado = pResultado;
        }


        public Respuestas() { }

        //falta hacer data contract y data member y el Constructor por Defecto
        #endregion





    }
}
