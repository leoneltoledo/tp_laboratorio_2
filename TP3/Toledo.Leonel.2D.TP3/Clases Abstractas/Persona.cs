using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region Fields
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Properties
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Methods
        public Persona()
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");

            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException("DNI fuera de rango.");
            }

            if(nacionalidad == ENacionalidad.Argentino && dato > 89999999)
            {
                throw new NacionalidadInvalidaException("La Nacionalidad no coincide con el número de DNI.");
            }
            else if(nacionalidad == ENacionalidad.Extranjero && dato <= 89999999)
            {
                throw new NacionalidadInvalidaException("La Nacionalidad no coincide con el número de DNI.");
            }

            return dato;
        }
        //REVISAR!
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;
            bool aux = true;

            if (!(dato is null))
            {
                for (int i = 0; i < dato.Length; i++)
                {
                    if (dato[i] < '0' || dato[i] > '9')
                    {
                        aux = false;
                        break;
                    }
                }
                if (aux)
                    Int32.TryParse(dato, out retorno);
                else
                    throw new DniInvalidoException("El dni contiene caracteres invalidos.");
            }

            return this.ValidarDni(nacionalidad, retorno);
        }
        private string ValidarNombreApellido(string dato)
        {
            string retorno = null;
            bool aux = true;
            
            foreach(char item in dato)
            {
                if (!char.IsLetter(item))
                {
                    aux = false;
                    break;
                }
            }
            if (aux)
            {
                retorno = dato;
            }
            return retorno;
        }
        #endregion

        #region Nested types
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion
    }
}
