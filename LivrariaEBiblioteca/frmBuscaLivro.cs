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

        public string fotoPath;
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
            btnGerenciador.Enabled = true;
            btnVender.Enabled = true;
            btnEmprestar.Enabled = true;
        }

        public void desabilitarCampos()
        {
            txtIdLivro.Enabled = false;
            txtIsbn.Enabled = false;
            txtTitulo.Enabled = false;
            btnBuscar.Enabled = false;
            btnLimpar.Enabled = false;
            btnVender.Enabled = false;
            btnEmprestar.Enabled = false;
            btnGerenciador.Enabled = false;
        }

        public void limparComponentes()
        {
            txtIdLivro.Text = string.Empty;
            txtIsbn.Text = string.Empty;
            txtTitulo.Text = string.Empty;
            rdbIdLivro.Checked = false;
            rdbTitulo.Checked = false;
            rdbIsbn.Checked = false;
            ltbPesquisar.Text = string.Empty;
            
        }

        public void pesquisarPorCodigo(int codigo)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "SELECT codLivro, nome, isbn, foto FROM tbLivro WHERE codLivro = @codLivro;";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = codigo;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR = comm.ExecuteReader();

            // Limpa o ListBox antes
            ltbPesquisar.Items.Clear();

            try
            {
                if (DR.Read())
                {
                    // Preenche os campos
                    txtIdLivro.Text = DR["codLivro"].ToString();
                    txtTitulo.Text = DR["nome"].ToString();
                    txtIsbn.Text = DR["isbn"].ToString();
                    fotoPath = DR["foto"].ToString();

                    // Preenche a imagem
                    pctLivro.ImageLocation = fotoPath;
                    pctLivro.Load();

                    // Adiciona no ListBox
                    ltbPesquisar.Items.Add(DR["nome"].ToString());
                }
                else
                {
                    MessageBox.Show("Registro não encontrado!");
                    txtIdLivro.Focus();
                    txtIdLivro.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao buscar registro.");
            }
            finally
            {
                Conexao.fecharConexao();
            }
        }

        public void pesquisarPorNome(string titulo)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "SELECT codLivro, nome, isbn, foto FROM tbLivro WHERE nome LIKE @nome;";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = "%" + titulo + "%";
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR = comm.ExecuteReader();

            // Limpa o ListBox antes
            ltbPesquisar.Items.Clear();

            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    // Preenche os campos
                    txtIdLivro.Text = DR["codLivro"].ToString();
                    txtTitulo.Text = DR["nome"].ToString();
                    txtIsbn.Text = DR["isbn"].ToString(); 
                    fotoPath = DR["foto"].ToString();

                    // Preenche a imagem
                    pctLivro.ImageLocation = fotoPath;
                    pctLivro.Load();

                    // Adiciona no ListBox
                    ltbPesquisar.Items.Add(DR["nome"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Livro não encontrado.");
            }

            Conexao.fecharConexao();
        
    }

        public void pesquisarPorIsbn(string isbn)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "SELECT codLivro, nome, isbn, foto FROM tbLivro WHERE codLivro = @isbn;";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.Add("@isbn", MySqlDbType.VarChar, 20).Value = isbn;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR = comm.ExecuteReader();

            ltbPesquisar.Items.Clear();

            try
            {
                if (DR.Read())
                {
                    // Preenche todos os campos do formulário
                    txtIdLivro.Text = DR["codLivro"].ToString();
                    txtIsbn.Text = DR["isbn"].ToString();
                    txtTitulo.Text = DR["nome"].ToString();
                    fotoPath = DR["foto"].ToString();

                    // Preenche a imagem
                    pctLivro.ImageLocation = fotoPath;
                    pctLivro.Load();

                    ltbPesquisar.Items.Add(DR["nome"].ToString());
                }
                else
                {
                    MessageBox.Show("Livro com ISBN informado não encontrado.");
                    txtIsbn.Focus();
                    txtIsbn.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao buscar livro por ISBN.");
            }
            finally
            {
                Conexao.fecharConexao();
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            frmVender abrirVender = new frmVender(this.nome, this.codUsu, this.cargo);

            // Envia os dados dos campos preenchidos
            abrirVender.ReceberDadosLivro(
                txtTitulo.Text,
                txtIsbn.Text,
                txtIdLivro.Text
            );

            abrirVender.Show();
        }

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            frmEmprestimo abrirEmprestimo = new frmEmprestimo (this.nome, this.codUsu, this.cargo);

            // Envia os dados dos campos preenchidos
            abrirEmprestimo.ReceberDadosLivro(
                txtTitulo.Text,
                txtIsbn.Text,
                txtIdLivro.Text
            );

            abrirEmprestimo.Show();
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
            txtTitulo.Enabled = false;
            txtIsbn.Enabled = false;
        }

        private void rdbTitulo_CheckedChanged(object sender, EventArgs e)
        {
            habilitarCampos();
            txtTitulo.Focus();
            txtIdLivro.Enabled = false;
            txtIsbn.Enabled=false;
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
            if (rdbIsbn.Checked)
            { 
                pesquisarPorIsbn(txtTitulo.Text);
            }
        }

        private void rdbIsbn_CheckedChanged_1(object sender, EventArgs e)
        {
            habilitarCampos();
            txtIsbn.Focus();
            txtTitulo.Enabled = false;
            txtIdLivro.Enabled = false;
        }
        
        private void btnGerenciador_Click(object sender, EventArgs e)
        {
            string descricao = txtTitulo.Text;
            frmCadastroLivrosAlugar abrir = new frmCadastroLivrosAlugar(descricao, this.nome, this.codUsu, this.cargo);
            abrir.Show();
            this.Hide();
        }
    }
}
