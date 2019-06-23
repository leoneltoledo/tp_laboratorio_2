using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        #region Methods
        public TrackingIdRepetidoException(string msj, Exception innerException) : base(msj, innerException)
        {

        }

        public TrackingIdRepetidoException(string msj) : this(msj, null)
        {

        }
        #endregion
    }
}
