﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public double Operar(Numero num1, Numero num2, string operador)
        {
            operador = Calculadora.ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    if (num2.GetNumero == 0)
                        return double.MinValue;
                    return num1 / num2;
                default:
                    return 0;
            }
        }
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }
    }
}
