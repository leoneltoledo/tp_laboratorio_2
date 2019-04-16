using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Fields

        private double numero;

        #endregion

        #region Properties

        private void SetNumero(string strNumero)
        {
            this.numero = Numero.ValidarNumero(strNumero);
        }

        #endregion

        #region Methods

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            SetNumero(strNumero);
        }

        private static double ValidarNumero(string strNumero)
        {
            double dblNumero;
            Double.TryParse(strNumero,out dblNumero);

            return dblNumero;
        }

        public string BinarioDecimal(string binario)
        {
            SetNumero(binario);
            if (this.numero != 0)
            {
                char[] array = binario.ToCharArray();
                Array.Reverse(array);
                double sum = 0;
                for (int x = 0; x < array.Length; x++)
                {
                    if (array[x] == '1')
                        sum += Math.Pow(2, x);
                }
                return sum.ToString();
            }
            return "Valor inválido";
        }

        public string DecimalBinario(double numero)
        {
            string respuesta = "";
            while (numero > 1)
            {
                double resto = numero % 2;
                respuesta = Convert.ToString(resto) + respuesta;
                numero /= 2;
            }
            respuesta = Convert.ToString(numero) + respuesta;
            return respuesta;
        }

        public string DecimalBinario(string numero)
        {
            SetNumero(numero);
            if(this.numero == 0)
            {
                return "Valor inválido";
            }
            else
            {
                return DecimalBinario(this.numero);
            }
        }
        
        public static double operator +(Numero n1,Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        #endregion
    }
}
