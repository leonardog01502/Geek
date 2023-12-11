using Geet.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            FrmSplash splash = new FrmSplash();
            splash.Show();
            Application.DoEvents();
            Thread.Sleep(3000);
            splash.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmCliente cliente = new FrmCliente();
            cliente.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmProduto produto = new FrmProduto();
            produto.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmVenda vendas = new FrmVenda(); 
            vendas.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmTipoProdutos tipoProdutos = new FrmTipoProdutos();
            tipoProdutos.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            FrmCliente cliente = new FrmCliente();
            cliente.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            FrmProduto produto = new FrmProduto();
            produto.Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            FrmVenda vendas = new FrmVenda();
            vendas.Show();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            FrmTipoProdutos tipoProdutos = new FrmTipoProdutos();
            tipoProdutos.Show();
        }
    }
}