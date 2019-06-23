using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Fields
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Properties
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Methods
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }

        public void MockCicloDeVida()
        {
            while (Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                //Estado = (Estado == EEstado.Ingresado) ? EEstado.EnViaje : EEstado.Entregado;
                if(Estado == EEstado.Ingresado)
                {
                    Estado = EEstado.EnViaje;
                }
                else
                {
                    Estado = EEstado.Entregado;
                }
                InformaEstado(this, new EventArgs());

            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (p1.trackingID == p2.trackingID)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Events
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Nested Types
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion
    }
}
