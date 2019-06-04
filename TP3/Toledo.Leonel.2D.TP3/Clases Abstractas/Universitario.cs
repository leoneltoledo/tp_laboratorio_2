using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region Fields
        private int legajo;
        #endregion

        #region Methods
        public Universitario() : base()
        {

        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if((pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo) && pg1.GetType() == pg2.GetType())
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (this == (Universitario)obj)
                retorno = true;

            return retorno;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NÚMERO: {this.legajo}");
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();
        #endregion
    }
}
