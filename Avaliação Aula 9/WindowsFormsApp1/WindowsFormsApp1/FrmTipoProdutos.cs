using Geet.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmTipoProdutos : Form
    {
        public FrmTipoProdutos()
        {
            InitializeComponent();
        }

        private void FrmTipoProdutos_Load(object sender, EventArgs e)
        {
            TipoProduto tipoProduto = new TipoProduto();
            List<TipoProduto> tipoProdutos = tipoProduto.listatipoproduto();
            dgvTipo.DataSource = tipoProdutos;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTipo.Text == "")
                {
                    MessageBox.Show("Por favor, preencha o campo Tipo do Produto!", "Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = txtTipo;
                    return;
                }
                else
                {
                    TipoProduto tipoProduto = new TipoProduto();
                    if (tipoProduto.RegistroRepetido(txtTipo.Text) == true)
                    {
                        MessageBox.Show("Tipo do produto já existe em nossa base de dados!", "Repetido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTipo.Text = "";
                        this.ActiveControl = txtTipo;
                    }
                    else
                    {
                        tipoProduto.Inserir(txtTipo.Text);
                        MessageBox.Show("Tipo do produto inserido com sucesso!", "Inserção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTipo.Text = "";
                        this.ActiveControl = txtTipo;
                        List<TipoProduto> tipoProdutos = tipoProduto.listatipoproduto();
                        dgvTipo.DataSource = tipoProdutos;
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro - Inserção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text.Trim() == "")
                {
                    MessageBox.Show("Por favor digite um ID para realizar a busca!", "Localizar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = txtID;
                    return;
                }
                else
                {
                    int Id = Convert.ToInt32(txtID.Text.Trim());
                    TipoProduto tipoProduto = new TipoProduto();
                    tipoProduto.Localizar(Id);
                    txtTipo.Text = tipoProduto.tipo;
                    btnEditar.Enabled = true;
                    btnExcluir.Enabled = true;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro - Localização", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtID.Text.Trim());
                TipoProduto tipoProduto = new TipoProduto();
                tipoProduto.Atualizar(Id, txtTipo.Text);
                MessageBox.Show("Tipo do Produto atualizado com sucesso!", "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Text = "";
                txtTipo.Text = "";
                this.ActiveControl = txtTipo;
                List<TipoProduto> tipoProdutos = tipoProduto.listatipoproduto();
                dgvTipo.DataSource = tipoProdutos;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro - Atualização", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtID.Text.Trim());
                TipoProduto tipoProduto = new TipoProduto();
                tipoProduto.Excluir(Id);
                MessageBox.Show("Tipo do produto excluído com sucesso!", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Text = "";
                txtTipo.Text = "";
                this.ActiveControl = txtTipo;
                List<TipoProduto> tipoProdutos = tipoProduto.listatipoproduto();
                dgvTipo.DataSource = tipoProdutos;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro - Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTipoProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvTipo.Rows[e.RowIndex];
                row.Selected = true;
                txtID.Text = row.Cells[0].Value.ToString();
                txtTipo.Text = row.Cells[1].Value.ToString();
            }
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }
    }
}