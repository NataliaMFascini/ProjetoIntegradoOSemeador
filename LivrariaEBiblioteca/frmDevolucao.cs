using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivrariaEBiblioteca
{
    public partial class frmDevolucao : Form
    {
        public string nome;
        public string cargo;
        public int codUsu;

        public string nomeLoc;

        public string fotoPath; 

        public frmDevolucao()
        {
            InitializeComponent();
        }
        public frmDevolucao(string nome, int codUsu, string cargo)
        {
            InitializeComponent();
            this.nome = nome;
            this.cargo = cargo;
            this.codUsu = codUsu;
        }

        public void pesquisarPorNome(string nome)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select codLivro, isbn, nome, autor, editora, foto from tbLivro where nome = @nome;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                txtIdLivro.Text = Convert.ToString(DR.GetInt32(0));
                txtIsbn.Text = DR.GetString(1);
                txtTitulo.Text = DR.GetString(2);
                txtAutor.Text = DR.GetString(3);
                txtEditora.Text = DR.GetString(4);
                if (fotoPath != null)
                {
                    fotoPath = DR.GetString(6);
                    pctLivro.ImageLocation = fotoPath;
                    pctLivro.Load();
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao buscar informações do livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal(cargo, nome, codUsu);
            abrir.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarLivro abrir = new frmBuscarLivro(nome, codUsu, cargo, "Devolução");
            abrir.Show();
            this.Hide();
        }

        public void limparCampos()
        {
            txtIdLivro.Clear();
            txtIsbn.Clear();
            txtTitulo.Clear();
            txtEditora.Clear();
            txtAutor.Clear();
            txtNomeLoc.Clear();
            txtProntuario.Clear();

            ltbCarrinho.Items.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        public void listaDoLocatario(int prontuario)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select nomeLivro from tbEmprestimo where prontuario = @prontuario;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@prontuario", MySqlDbType.Int32).Value = prontuario;

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();

                while (DR.Read())
                {
                    ltbCarrinho.Items.Add(DR.GetString(0));
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao pegar o histórico de empréstimo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void listaDevolucao()
        {
            Livros livrosDev = new Livros();

            for (int i = 0; i < ltbCarrinho.Items.Count; i++)
            {
                livrosDev.nomeLivro = ltbCarrinho.Items[i].ToString();
                livrosDev.idLivro = livrosDev.pegarID(livrosDev.nomeLivro);

                Livros.ListaLivros.Add(livrosDev);
            }
        }

        public void pegarNomeLoc(int prontuario)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select nomeLocatario from tbEmprestimo where prontuario = @prontuario;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@prontuario", MySqlDbType.Int32).Value = prontuario;

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                txtNomeLoc.Text = DR.GetString(0);

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao pegar o nome do locatário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLocatario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listaDoLocatario(Convert.ToInt32(txtProntuario.Text));
                pegarNomeLoc(Convert.ToInt32(txtProntuario.Text));
                listaDevolucao();
            }
        }

        private void ltbCarrinho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ltbCarrinho.SelectedItem != null)
            {
                pesquisarPorNome(ltbCarrinho.SelectedItem.ToString());
            }
        }
    }
}
