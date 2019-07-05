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

        private string SetNumero
        {
            set
            {
                this.numero = Numero.ValidarNumero(value);
            }
        }

        public double GetNumero
        {
            get
            {
                return this.numero;
            }
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
            this.SetNumero = strNumero;
        }

        private static double ValidarNumero(string strNumero)
        {
            double dblNumero;
            Double.TryParse(strNumero, out dblNumero);

            return dblNumero;
        }

        public string BinarioDecimal(string binario)
        {
            int x, y;
            double num = 0;
            string retorno = "";
            bool verif = true;
            y = 0;

            for (x = binario.Length - 1; x >= 0; x--)
            {
                y++;
                if (binario[x] == '0' || binario[x] == '1')
                {
                    num += (double)(double.Parse(binario[x].ToString()) * Math.Pow(2, y));
                }
                else
                {
                    retorno = "No es binario";
                    verif = false;
                }

            }
            if (verif)
            {
                retorno = Convert.ToString(num / 2);

            }
            return retorno;
        }

        public string DecimalBinario(double numero)
        {
            return DecimalBinario(Convert.ToString(numero));
        }

        public string DecimalBinario(string numero)
        {
            bool verif;
            string binario = "";
            int n;
            verif = int.TryParse(numero, out n);
            if (verif && n > -1)
            {
                while (true)
                {
                    if ((n % 2) != 0)
                    {
                        binario = "1" + binario;
                    }
                    else
                    {
                        binario = "0" + binario;
                    }
                    n /= 2;
                    if (n <= 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                binario = "Valor invalido";
            }
            return binario;
        }

        public static double operator +(Numero n1, Numero n2)
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
