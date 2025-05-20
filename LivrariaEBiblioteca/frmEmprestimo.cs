using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LivrariaEBiblioteca;
using MySql.Data.MySqlClient;


namespace LivrariaEBiblioteca
{

    public partial class frmEmprestimo : Form
    {
        public int codUsu;
        public string nome;
        public string cargo;

        public int codLivro;
        public string fotoPath;

        Livros livros = new Livros();

        public frmEmprestimo()
        {
            InitializeComponent();
            DesabilitarCampos();
        }
        public frmEmprestimo(string nome, int codUsu, string cargo)
        {
            InitializeComponent();
            DesabilitarCampos();


            this.nome = nome;
            this.codUsu = codUsu;
            this.cargo = cargo;
        }

        public frmEmprestimo(string nome, int codUsu, string cargo, string livro)
        {
            InitializeComponent();
            DesabilitarCampos();

            this.nome = nome;
            this.codUsu = codUsu;
            this.cargo = cargo;

            //pesquisarPorNome(livro);

        }
        public void DesabilitarCampos()
        {
            txtIdLivro.Enabled = false;
            txtNEmprestimo.Enabled = false;
        }

        public void limparCampos()
        {
            txtAutor.Clear();
            txtEditora.Clear();
            txtIdLivro.Clear();
            txtIsbn.Clear();
            txtTitulo.Clear();
            txtLocatario.Clear();
            txtNEmprestimo.Clear();
            pctLivro.Image = null;

            ltbCarrinho.Items.Clear();
        }

        public bool checarComponentes()
        {
            if (txtTitulo.Text.Equals(""))
            {
                erroCadastro("Título");
                txtTitulo.Focus();
                return false;
            }
            else if (txtAutor.Text.Equals(""))
            {
                erroCadastro("Autor");
                txtAutor.Focus();
                return false;
            }
            else if (txtEditora.Text.Equals(""))
            {
                erroCadastro("Editora");
                txtEditora.Focus();
                return false;
            }
            else if (txtIsbn.Text.Equals(""))
            {
                erroCadastro("ISBN");
                txtIsbn.Focus();
                return false;
            }
            else if (txtLocatario.Text.Equals(""))
            {
                erroCadastro("Prontuário");
                txtLocatario.Focus();
                return false;
            }
            else if (txtNEmprestimo.Text.Equals(""))
            {
                erroCadastro("Nome");
                txtNEmprestimo.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public void erroCadastro(string nomeCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        private void erroCampo(string nomeCampo, string tipoCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo somente " + tipoCampo + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }


        public bool checarCaractere()
        {
            int tryParse;
            if (!int.TryParse(txtIsbn.Text, out tryParse))
            {
                erroCampo("ISBN", "numérico");
                txtIsbn.Clear();
                txtIsbn.Focus();
                return false;
            }
            else if (int.TryParse(txtTitulo.Text, out tryParse))
            {
                erroCampo("Título", "alfabético");
                txtTitulo.Clear();
                txtTitulo.Focus();
                return false;
            }
            else if (int.TryParse(txtAutor.Text, out tryParse))
            {
                erroCampo("Autor", "alfabético");
                txtAutor.Clear();
                txtAutor.Focus();
                return false;
            }
            else if (int.TryParse(txtEditora.Text, out tryParse))
            {
                erroCampo("Editora", "alfabético");
                txtEditora.Clear();
                txtEditora.Focus();
                return false;
            }
            else if (!int.TryParse(txtLocatario.Text, out tryParse))
            {
                erroCampo("Prontuário", "numérico");
                txtLocatario.Clear();
                txtLocatario.Focus();
                return false;
            }
            else if (int.TryParse(txtNEmprestimo.Text, out tryParse))
            {
                erroCampo("Nome", "alfabético");
                txtNEmprestimo.Clear();
                txtNEmprestimo.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (checarComponentes())
            {
                ltbCarrinho.Items.Add(txtTitulo.Text);
                separarLivros();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            txtIsbn.Focus();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal(this.cargo, this.nome, this.codUsu);
            abrir.Show();
            this.Hide();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            frmVender abrir = new frmVender(this.nome, this.codUsu, this.cargo);
            abrir.Show();
            this.Hide();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

        }
        public void separarLivros()
        {

        }

        public void escanearLivro(string isbn)
        {
            try
            {
                string empVen = "";

                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select codLivro, nome, autor, editora, foto, empVen from tbLivro where isbn = @isbn;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@isbn", MySqlDbType.VarChar, 13).Value = isbn;
                comm.Connection = Conexao.obterConexao();
                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                bool resp = DR.HasRows;

                empVen = DR.GetString(5);

                if (empVen == "Emp")
                {
                    if (resp)
                    {
                        txtIdLivro.Text = Convert.ToString(DR.GetInt32(0));
                        txtTitulo.Text = DR.GetString(1);
                        txtAutor.Text = DR.GetString(2);
                        txtEditora.Text = DR.GetString(3);
                        if (fotoPath != null)
                        {
                            fotoPath = DR.GetString(4);
                            pctLivro.ImageLocation = fotoPath;
                            pctLivro.Load();
                        }
                        else
                        {
                            pctLivro.Image = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ISBN inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                        txtIsbn.Clear();
                        txtIsbn.Focus();
                    }
                }
                else if (empVen == "Ven")
                {
                    MessageBox.Show("Livro selecionado não esta cadastrado para Empréstimo", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao escanear livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtIsbn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                escanearLivro(txtIsbn.Text);
                txtLocatario.Focus();
                codLivro = Convert.ToInt32(txtIdLivro.Text);
                if (livros.checarEstoque(codLivro, "Emp") <= 0)
                {
                    lblDisponibilidade.Text = "Indisponivel";
                    lblDisponibilidade.ForeColor = Color.Red;
                }
                else
                {
                    lblDisponibilidade.Text = "Disponivel";
                    lblDisponibilidade.ForeColor = Color.Green;
                }
            }
        }

        private void txtLocatario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void ltbCarrinho_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Livros.ListaLivros.RemoveAt(ltbCarrinho.SelectedIndex);
                    ltbCarrinho.Items.RemoveAt(ltbCarrinho.SelectedIndex);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao remover item do carrinho.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ltbCarrinho_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    Livros.ListaLivros.RemoveAt(ltbCarrinho.SelectedIndex);
                    ltbCarrinho.Items.RemoveAt(ltbCarrinho.SelectedIndex);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao remover item do carrinho.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ltbCarrinho_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pesquisarPorNome(ltbCarrinho.SelectedItem.ToString());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarLivro abrir = new frmBuscarLivro(this.nome, this.codUsu, this.cargo, "Empréstimo");

            if (ltbCarrinho.Items.Count != 0)
            {
                DialogResult resultado = MessageBox.Show("Essa ação irá limpar o carrinho. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (resultado == DialogResult.Yes)
                {
                    abrir = new frmBuscarLivro(this.nome, this.codUsu, this.cargo, "Empréstimo");
                    abrir.Show();
                    this.Hide();
                }
            }
            else
            {
                abrir = new frmBuscarLivro(this.nome, this.codUsu, this.cargo, "Empréstimo");
                abrir.Show();
                this.Hide();
            }
        }

        private void btnDevolucao_Click(object sender, EventArgs e)
        {
            frmDevolucao abrir = new frmDevolucao(this.nome, this.codUsu, this.cargo);
            abrir.Show();
            this.Hide();
        }
    }
}

