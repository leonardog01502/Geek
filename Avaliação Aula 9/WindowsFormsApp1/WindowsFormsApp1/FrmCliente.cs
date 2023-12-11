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
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            List<Clientes> clientes = cliente.listacliente();
            dgvClientes.DataSource = clientes;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            this.ActiveControl = txtNome;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || mtdCPF.Text == "" || mtdTelefone.Text == "")
            {
                MessageBox.Show("Por favor, preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Clientes cliente = new Clientes();
                if (cliente.RegistroRepetido(mtdCPF.Text) == true)
                {
                    MessageBox.Show("Cliente já existe em nossa base de dados!", "Cliente Repetido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNome.Text = "";
                    mtdCPF.Text = "";
                    mtdTelefone.Text = "";
                    return;
                }
                else
                {
                    cliente.Inserir(txtNome.Text, mtdCPF.Text, mtdTelefone.Text);
                    MessageBox.Show("Cliente inserido com sucesso!", "Inserção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    List<Clientes> clientes = cliente.listacliente();
                    dgvClientes.DataSource = clientes;
                    txtNome.Text = "";
                    mtdCPF.Text = "";
                    mtdTelefone.Text = "";
                    this.txtNome.Focus();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro - Inserção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Por favor, digite um ID para localizar!", "Sem ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int Id = Convert.ToInt32(txtID.Text.Trim());
                Clientes cliente = new Clientes();
                cliente.Localizar(Id);
                txtNome.Text = cliente.nome;
                mtdCPF.Text = cliente.cpf;
                mtdTelefone.Text = cliente.telefone;
                if (txtNome.Text != null)
                {
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
                Clientes cliente = new Clientes();
                cliente.Atualizar(Id, txtNome.Text, mtdCPF.Text, mtdTelefone.Text);
                MessageBox.Show("Cliente atualizado com sucesso!", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Clientes> clientes = cliente.listacliente();
                dgvClientes.DataSource = clientes;
                txtID.Text = "";
                txtNome.Text = "";
                mtdCPF.Text = "";
                mtdTelefone.Text = "";
                this.ActiveControl = txtNome;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro - Edição", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(txtID.Text.Trim());
                Clientes cliente = new Clientes();
                cliente.Excluir(Id);
                MessageBox.Show("Cliente excluído com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Clientes> clientes = cliente.listacliente();
                dgvClientes.DataSource = clientes;
                txtID.Text = "";
                txtNome.Text = "";
                mtdCPF.Text = "";
                mtdTelefone.Text = "";
                this.ActiveControl = txtNome;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro - Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvClientes.Rows[e.RowIndex];
                this.dgvClientes.Rows[e.RowIndex].Selected = true;
                txtID.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                mtdCPF.Text = row.Cells[2].Value.ToString();
                mtdTelefone.Text = row.Cells[3].Value.ToString();
            }
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }
    }
}