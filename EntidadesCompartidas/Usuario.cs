using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Usuario
    {
        #region Atributos
        string usuarioLog;
        string contraseña;
        string nombreC;

        #endregion

        #region Propiedades
        [DataMember]
        public string UsuarioLog
        {
            get { return usuarioLog; }
            set
            {
                if(value.Trim().Length == 0 || value.Trim().Length > 20)
                {

                    throw new Exception("El Usuario Logueo no puede estar vacio o mayor a 20 caracteres");
                }
                usuarioLog = value;
            }
        }

        [DataMember]
        public string Contraseña
        {
            get { return contraseña; }
            set
            { 
                if(value.Trim().Length == 0 || value.Trim().Length > 10)
                {

                    throw new Exception("La Contraseña no puede estar vacia o mayor a 10 caracteres");
                }
                contraseña = value;
            }
        }

        [DataMember]
        public string NombreC
        {
            get { return nombreC; }
            set
            {
                if(value.Trim().Length == 0 || value.Trim().Length > 20)
                {

                    throw new Exception("El Nombre Completo no puede estar vacio o mayor a 20 caracteres");
                }
                nombreC = value;
            }
        }
        #endregion

        public Usuario(string pUsuarioLog, string pContraseña, string pNombreC)
        {
            UsuarioLog = pUsuarioLog;
            Contraseña = pContraseña;
            NombreC = pNombreC;
        }

        public Usuario() { }

        //falta hacer data contract y data member y el Constructor por Defecto
    }
}
