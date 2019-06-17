using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Fields
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Properties
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Methods
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> lista = ((Correo)elementos).paquetes;
            StringBuilder sb = new StringBuilder();
            foreach(Paquete item in lista)
            {
                sb.AppendLine($"{item.ToString()} ({item.Estado.ToString()})");
            }
            return sb.ToString();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException($"El paquete {p.TrackingID} ya esta en la lista.");
                }
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }
        #endregion
    }
}
