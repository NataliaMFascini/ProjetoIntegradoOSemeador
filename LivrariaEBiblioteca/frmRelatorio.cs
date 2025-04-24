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
    public partial class frmRelatorio : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;
        public frmRelatorio()
        {
            InitializeComponent();
        }
        public frmRelatorio(string nome, int codUsu, string cargo)
        {
            InitializeComponent();
            this.nome = nome;
            this.codUsu = codUsu;
            this.cargo = cargo;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal(this.cargo, this.nome, this.codUsu);
            abrir.Show();
            this.Hide();
        }

        private void btnListaLivros_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbLivro;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            for(int i =0; i < dgvRelatorio.RowCount; i++)
            {
                dgvRelatorio.Rows[i].DataGridView.Columns.Clear();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbUsuario;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnLocatarios_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbLocatario;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbVendas;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnEmprestimos_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbEmprestimo;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }
    }
}
