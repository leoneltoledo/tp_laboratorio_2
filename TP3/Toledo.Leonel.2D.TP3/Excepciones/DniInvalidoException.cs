using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Fields
        private static string mensajeBase = "DNI inválido.";
        #endregion

        #region Methods
        public DniInvalidoException() : this(mensajeBase)
        {

        }
        public DniInvalidoException(Exception e) : this(mensajeBase, e)
        {

        }
        public DniInvalidoException(string message) : base(message)
        {

        }
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }
        #endregion
    }
}
