using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Fields
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
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
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Methods
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach(Alumno item in j.alumnos)
            {
                if(item == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        public static string Leer()
        {
            Texto aux = new Texto();
            string datos = null;

            try
            {
                aux.Leer("Jornada.txt", out datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return datos;
        }
        public static bool Guardar(Jornada jornada)
        {
            if(!(jornada is null))
            {
                Texto texto = new Texto();

                try
                {
                    texto.Guardar("Jornada.txt", jornada.ToString());
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"CLASE DE {this.Clase} POR {this.Instructor.ToString()}");
            sb.AppendLine("ALUMNOS: ");
            foreach(Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<---------------------------------->");
            return sb.ToString();
        }
        #endregion
    }
}
