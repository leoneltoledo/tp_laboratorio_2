using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Fields
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Methods
        public Alumno() : base()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma != clase)
            {
                retorno = true;
            }
            return retorno;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
      
        protected override string ParticiparEnClase()
        {
            return String.Format($"TOMA CLASE DE {this.claseQueToma}\n");
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Nested Types
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        #endregion
    }
}
