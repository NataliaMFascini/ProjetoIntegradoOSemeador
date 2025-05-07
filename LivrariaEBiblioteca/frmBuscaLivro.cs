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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace LivrariaEBiblioteca
{
    public partial class frmBuscarLivro : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;
        public string ultimaTela;

        public string fotoPath;
        public string nomeLivro;
        public string tipo;
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

        private void btnVender_Click(object sender, EventArgs e)
        {
            if(tipo == "Emp")
            {
                MessageBox.Show("Esse livro está reservado para empréstimo, não pode ser vendido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                frmVender abrirVender = new frmVender(this.nome, this.codUsu, this.cargo, nomeLivro);

                abrirVender.Show();
                this.Hide();
            }
        }

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            if (tipo == "Ven")
            {
                MessageBox.Show("Esse livro está reservado para venda, não pode ser emprestado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                frmEmprestimo abrirEmprestimo = new frmEmprestimo(this.nome, this.codUsu, this.cargo, nomeLivro);

                abrirEmprestimo.Show();
                this.Hide();
            }
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
            if (ultimaTela == "Cadastro")
            {
                frmCadastroLivrosAlugar abrir = new frmCadastroLivrosAlugar(this.nome, this.codUsu, this.cargo);
                abrir.Show();
                this.Hide();
            }
            if (ultimaTela == "Venda")
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
            txtIsbn.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int tryParse;
            try
            {
                MySqlCommand comm = new MySqlCommand();

                if (rdbIdLivro.Checked)
                {
                    if(!int.TryParse(txtIdLivro.Text, out tryParse))
                    {
                        MessageBox.Show("Use apenas números.", "MENSAGEM DO SISTEMA", MessageBoxButtons.OK);
                        return;
                    }
                    comm.CommandText = "SELECT codLivro, nome, isbn, foto, empVen FROM tbLivro WHERE codLivro = @codLivro;";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = Convert.ToInt32(txtIdLivro.Text);
                }
                if (rdbTitulo.Checked)
                {
                    if(int.TryParse(txtTitulo.Text, out tryParse))
                    {
                        MessageBox.Show("Use apenas letras.", "MENSAGEM DO SISTEMA", MessageBoxButtons.OK);
                        return;
                    }
                    comm.CommandText = "SELECT codLivro, nome, isbn, foto, empVen FROM tbLivro WHERE nome LIKE @nome;";
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.Clear();
                    comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtTitulo.Text;
                }
                if (rdbIsbn.Checked)
                {
                    if (!int.TryParse(txtIsbn.Text, out tryParse))
                    {
                        MessageBox.Show("Use apenas números.", "MENSAGEM DO SISTEMA", MessageBoxButtons.OK);
                        return;
                    }
                    comm.CommandText = "SELECT codLivro, nome, isbn, foto, empVen FROM tbLivro WHERE isbn = @isbn;";
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.Clear();
                    comm.Parameters.Add("@isbn", MySqlDbType.VarChar, 20).Value = txtIsbn.Text;
                }

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR = comm.ExecuteReader();

                // Limpa o ListBox antes
                ltbPesquisar.Items.Clear();

                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        // Preenche os campos
                        txtIdLivro.Text = DR.GetInt32(0).ToString();
                        txtTitulo.Text = DR.GetString(1);
                        txtIsbn.Text = DR.GetString(2);
                        tipo = DR.GetString(4);

                        // Preenche a imagem
                        if (fotoPath != null)
                        {
                            fotoPath = DR.GetString(3);
                            pctLivro.ImageLocation = fotoPath;
                            pctLivro.Load();
                        }

                        // Adiciona no ListBox
                        ltbPesquisar.Items.Add(DR.GetString(1));
                    }
                }
                else
                {
                    MessageBox.Show("Livro não encontrado.");
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao buscar livro.", "MENSAGEM DO SISTEMA", MessageBoxButtons.OK);
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
        private void txtIdLivro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click( sender, e);
            }
        }

        private void txtIsbn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void txtTitulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }
        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            nomeLivro = ltbPesquisar.SelectedItem.ToString();
        }
    }
}
