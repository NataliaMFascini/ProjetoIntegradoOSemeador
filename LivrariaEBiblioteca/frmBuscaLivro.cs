using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace LivrariaEBiblioteca
{
    public partial class frmBuscarLivro : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;
        public string ultimaTela;
        public frmBuscarLivro()
        {
            InitializeComponent();
            desabilitarCampos();
        }
        public frmBuscarLivro(string nome, int codUsu, string cargo, string ultimaTela)
        {
            InitializeComponent();
            desabilitarCampos();

            this.nome = nome;
            this.cargo = cargo;
            this.codUsu = codUsu;
            this.ultimaTela = ultimaTela; 
        }

        public void habilitarCampos()
        {
            txtIdLivro.Enabled = true;
            txtIsbn.Enabled = true;
            txtTitulo.Enabled = true;
            btnBuscar.Enabled = true;
            btnLimpar.Enabled = true;
        }

        public void desabilitarCampos()
        {
            txtIdLivro.Enabled = false;
            txtIsbn.Enabled = false;
            txtTitulo.Enabled = false;
            btnBuscar.Enabled = false;
            btnLimpar.Enabled = false;
        }

        public void limparComponentes()
        {
            txtIdLivro.Text = string.Empty;
            txtIsbn.Text = string.Empty;
            txtTitulo.Text = string.Empty;
            rdbIdLivro.Checked = false;
            rdbTitulo.Checked = false;
            ltbPesquisar.Text = string.Empty;
            
        }

        public void pesquisarPorCodigo(int codigo)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select nome from tbLivro where codLivro = @codLivro;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = codigo;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();
            try
            {
                ltbPesquisar.Items.Add(DR.GetString(0));
            }
            catch (Exception)
            {
                MessageBox.Show("Registro não encontrado");
                txtIdLivro.Focus();
                txtIdLivro.Clear();
            }
        }

        public void pesquisarPorNome(string titulo)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select nome from tbLivro where nome like '%" + titulo + "%';";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = titulo;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();

            while (DR.Read())
            {
                ltbPesquisar.Items.Add((DR.GetString(0)));
            }

            Conexao.fecharConexao();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            frmVender abrirVender = new frmVender(this.nome, this.codUsu, this.cargo);
            abrirVender.ShowDialog();
        }

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            frmEmprestimo abrirEmpre = new frmEmprestimo(this.nome, this.codUsu, this.cargo);
            abrirEmpre.ShowDialog();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparComponentes();
            desabilitarCampos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (ultimaTela == "Menu")
            {
                frmMenuPrincipal abrir = new frmMenuPrincipal(this.cargo, this.nome, this.codUsu);
                abrir.Show();
                this.Hide();
            }
            if(ultimaTela == "Cadastro")
            {
                frmCadastroLivrosAlugar abrir = new frmCadastroLivrosAlugar(this.nome, this.codUsu, this.cargo);
                abrir.Show();
                this.Hide();
            }
            if(ultimaTela == "Venda")
            {
                frmVender abrir = new frmVender(this.nome, this.codUsu, this.cargo);
                abrir.Show();
                this.Hide();
            }
            if (ultimaTela == "Emprestimo")
            {
                frmEmprestimo abrir = new frmEmprestimo(this.nome, this.codUsu, this.cargo);
                abrir.Show();
                this.Hide();
            }
        }

        private void rdbIdLivro_CheckedChanged(object sender, EventArgs e)
        {
            habilitarCampos();
            txtIdLivro.Focus();
        }

        private void rdbTitulo_CheckedChanged(object sender, EventArgs e)
        {
            habilitarCampos();
            txtTitulo.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rdbIdLivro.Checked)
            {
                pesquisarPorCodigo(Convert.ToInt32(txtIdLivro.Text));
            }
            if (rdbTitulo.Checked)
            {
                pesquisarPorNome(txtTitulo.Text);
            }
        }

        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
