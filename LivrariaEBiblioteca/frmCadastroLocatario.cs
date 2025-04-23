using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LivrariaEBiblioteca
{
    public partial class frmCadastroLocatario : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;
        public frmCadastroLocatario()
        {
            InitializeComponent();
        }
        public frmCadastroLocatario(string nome, int codUsu, string cargo)
        {
            InitializeComponent();
            this.cargo = cargo;
            this.nome = nome;
            this.codUsu = codUsu;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal(this.cargo, this.nome, this.codUsu);
            abrir.Show();
            this.Hide();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (cadastrarLocatario() == 1)
            {
                MessageBox.Show("Cadastro realizado com sucesso.");
            }
        }

        private int cadastrarLocatario()
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "insert into tbLocatario(pront, nome, cpf, telCel, email, dataCadastro) values (@pront, @nome, @cpf, @telCel, @email, @dataCadastro);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@pront", MySqlDbType.Int64).Value = Convert.ToInt64(txtProntuario.Text);
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtLocatario.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCpf.Text;
            comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 14).Value = mskTelefone.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = txtEmail.Text;
            comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;

            comm.Connection = Conexao.obterConexao();
            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        private void btnGerarPront_Click(object sender, EventArgs e)
        {
            Random numAleatorio = new Random();

            long prontuario = numAleatorio.Next(100000000, 999999999);

            txtProntuario.Text = prontuario.ToString();

        }

        private void frmCadastroLocatario_Load(object sender, EventArgs e)
        {

        }
    }
}
