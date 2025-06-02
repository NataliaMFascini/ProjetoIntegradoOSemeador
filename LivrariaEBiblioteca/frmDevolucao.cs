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

        Livros livrosDev = new Livros();

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
                comm.CommandText = "select codLivro, isbn, nome, autor, editora, foto from tbLivroB where nome = @nome;";
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

        public void listaDoLocatario(long prontuario)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select nomeLivro from tbEmprestimo where prontuario = @prontuario and dataDev is null;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@prontuario", MySqlDbType.Int64).Value = prontuario;

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
                livrosDev.idLivro = livrosDev.pegarID(livrosDev.nomeLivro, "emprestimo");

                Livros.ListaLivros.Add(livrosDev);
            }
        }

        public void pegarNomeLoc(long prontuario)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select nomeLocatario from tbEmprestimo where prontuario = @prontuario;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@prontuario", MySqlDbType.Int64).Value = prontuario;

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

        public void pegarDataEmp(long prontuario)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select dataEmp from tbEmprestimo where prontuario = @prontuario and nomeLivro = @nomeLivro;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();

                comm.Parameters.Add("@prontuario", MySqlDbType.Int64).Value = prontuario;
                comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = ltbCarrinho.SelectedItem.ToString();

                comm.Connection = Conexao.obterConexao();
                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                if (DR.HasRows)
                {
                    dtpDataEmprestimo.Value = DR.GetDateTime(0);
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao encontrar a data em que o empréstimo foi realizado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                pegarDataEmp(Convert.ToInt64(txtProntuario.Text));
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (ltbCarrinho.SelectedItem != null)
            {
                Livros.ListaLivros.RemoveAt(ltbCarrinho.SelectedIndex);
                ltbCarrinho.Items.RemoveAt(ltbCarrinho.SelectedIndex);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (ltbCarrinho.Items.Count != 0)
            {
                if (registarDevolucao() == 1 && atualizarEstoque() == 1)
                {
                    MessageBox.Show("Devolução realizada com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    confirmarEstoque();
                    limparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao registrar devolução.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Não há livros para devolver.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public int registarDevolucao()
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "update tbEmprestimo set dataDev = @dataDev where prontuario = @prontuario and codLivro = @codLivro;";
                comm.CommandType = CommandType.Text;

                for (int i = 0; i < Livros.ListaLivros.Count; i++)
                {
                    comm.Parameters.Clear();
                    comm.Parameters.Add("@dataDev", MySqlDbType.DateTime).Value = DateTime.Now;
                    comm.Parameters.Add("@prontuario", MySqlDbType.Int64).Value = Convert.ToInt64(txtProntuario.Text);
                    comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livrosDev.proximoLivro(i);
                }
                comm.Connection = Conexao.obterConexao();

                int resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao registrar devolução.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int atualizarEstoque()
        {
            MySqlCommand comm = new MySqlCommand();
            int resp = 0;
            try
            {
                for (int i = 0; i < livrosDev.quantidadeLista(); i++)
                {
                    comm.CommandText = "update tbEstoqueB set entradaEmp = @entradaEmp where codLivro = @codLivro";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@entradaEmp", MySqlDbType.Int32).Value = pegarQuantLivro(livrosDev.proximoLivro(i)) + quantidadeRetorno(i);
                    comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livrosDev.proximoLivro(i);

                    comm.Connection = Conexao.obterConexao();

                    resp = comm.ExecuteNonQuery();

                    Conexao.fecharConexao();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Livro não registrado no estoque.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resp;
        }

        public int quantidadeRetorno(int index)
        {
            int quantTotal = 1;

            for (int i = 0; i < Livros.ListaLivros.Count - 1; i++)
            {
                if (Livros.ListaLivros[i].idLivro == Livros.ListaLivros[i + 1].idLivro)
                {
                    quantTotal++;
                }
            }
            return quantTotal;
        }

        public int pegarQuantLivro(int index)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select entradaEmp from tbEstoqueB where codLivro = @codLivro;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32, 20).Value = livrosDev.proximoLivro(index);

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                int quant = DR.GetInt32(0);

                Conexao.fecharConexao();
                return quant;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao pegar a quantidade do livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return 0;
            }
        }
        public void confirmarEstoque()
        {
            MySqlCommand comm = new MySqlCommand();
            try
            {
                for (int i = 0; i < livrosDev.quantidadeLista(); i++)
                {
                    comm.CommandText = "update tbEstoqueB set disponibilidade = @disponibilidade where codLivro = @codLivro";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livrosDev.proximoLivro(i);

                    if (livrosDev.checarEstoque(livrosDev.proximoLivro(i), "Emp") <= 0)
                    {
                        comm.Parameters.Add("@disponibilidade", MySqlDbType.VarChar, 1).Value = "N";
                    }
                    else
                    {
                        comm.Parameters.Add("@disponibilidade", MySqlDbType.VarChar, 1).Value = "S";
                    }

                    comm.Connection = Conexao.obterConexao();

                    int resp = comm.ExecuteNonQuery();

                    Conexao.fecharConexao();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao checar disponibilidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmprestimo_Click(object sender, EventArgs e)
        {
            frmEmprestimo abrir = new frmEmprestimo(nome, codUsu, cargo);
            abrir.Show();
            this.Hide();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            frmVender abrir = new frmVender(nome, codUsu, cargo);
            abrir.Show();
            this.Hide();
        }
    }
}
