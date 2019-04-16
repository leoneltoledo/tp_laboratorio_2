using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero resultado = new Numero(lblResultado.Text);
            lblResultado.Text = resultado.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero resultado = new Numero(lblResultado.Text);
            lblResultado.Text = resultado.BinarioDecimal(lblResultado.Text);
        }

        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.ResetText();
            lblResultado.ResetText();
        }
           
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            Calculadora calculadora = new Calculadora();
            return calculadora.Operar(num1, num2, operador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = LaCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
