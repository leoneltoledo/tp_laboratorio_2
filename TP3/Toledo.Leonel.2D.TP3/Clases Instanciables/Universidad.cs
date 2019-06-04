using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Fields
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Properties
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Methods
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> aux = new Xml<Universidad>();

            try
            {
                aux.Guardar("Universidad.xml", uni);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return true;
        }
        public static Universidad Leer(Universidad uni)
        {
            Universidad retorno = null;
            Xml<Universidad> aux = new Xml<Universidad>();

            try
            {
                aux.Leer("Universidad.xml", out retorno);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            if (!(g is null) && !(i is null))
            {
                foreach (Profesor item in g.Instructores)
                {
                    if (item == i)
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            if (!(u is null))
            {
                foreach (Profesor item in u.Instructores)
                {
                    if (item == clase)
                    {
                        return item;
                    }
                }
            }
            throw new SinProfesorException();
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            if (!(u is null))
            {
                foreach (Profesor item in u.Instructores)
                {
                    if (item != clase)
                    {
                        return item;
                    }
                }
            }
            throw new SinProfesorException();
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada auxJornada = null;
            Profesor auxProfesor = null;

            if (!(g is null))
            {
                auxProfesor = (g == clase);
                auxJornada = new Jornada(clase, auxProfesor);
                foreach (Alumno item in g.alumnos)
                {
                    if (item == clase)
                    {
                        auxJornada += item;
                    }
                }
                g.Jornadas.Add(auxJornada);
            }

            return g;
        }
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (!(g is null) && !(a is null))
            {
                if (g != a)
                {
                    g.Alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            return g;
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (!(g is null) && !(i is null))
            {
                if (g != i)
                {
                    g.Instructores.Add(i);
                }
            }
            return g;
        }
        #endregion

        #region Nested Types
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        #endregion
    }
}
