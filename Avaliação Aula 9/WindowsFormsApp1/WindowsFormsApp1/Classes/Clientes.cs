using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Geet.Classes
{
    class Clientes
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\Programação\\2° Trimestre\\Emerson\\Avaliação Aula 9\\WindowsFormsApp1\\WindowsFormsApp1\\Geet.mdf\";Integrated Security=True");

        public List<Clientes> listacliente()
        {
            List<Clientes> li = new List<Clientes>();
            string sql = "SELECT * FROM Cliente";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Clientes c = new Clientes();
                c.Id = (int)dr["Id"];
                c.nome = dr["nome"].ToString();
                c.cpf = dr["cpf"].ToString();
                c.telefone = dr["telefone"].ToString();
                li.Add(c);
            }
            dr.Close();
            con.Close();
            return li;
        }

        public void Inserir(string nome, string cpf, string telefone)
        {
            string sql = "INSERT INTO Cliente(nome,cpf,telefone) VALUES ('" + nome + "','" + cpf + "','" + telefone + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Atualizar(int Id, string nome, string cpf, string telefone)
        {
            string sql = "UPDATE Cliente SET nome='" + nome + "',cpf='" + cpf + "',telefone='" + telefone + "' WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int Id)
        {
            string sql = "DELETE FROM Cliente WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localizar(int Id)
        {
            string sql = "SELECT * FROM Cliente WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                cpf = dr["cpf"].ToString();
                telefone = dr["telefone"].ToString();
            }
            dr.Close();
            con.Close();
        }

        public bool RegistroRepetido(string cpf)
        {
            string sql = "SELECT * FROM Cliente WHERE cpf='" + cpf + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                return (int)result > 0;
            }
            con.Close();
            return false;
        }
    }
}