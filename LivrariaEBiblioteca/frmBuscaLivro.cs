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

        public int codLivroEstoque;
        public int estoque;

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

            if (this.cargo == "Voluntário")
            {
                btnGerenciador.Enabled = false;
            }
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
            ltbPesquisar.Items.Clear();
            txtIdLivro.Clear();
            txtIsbn.Clear();
            txtTitulo.Clear();
            rdbIdLivro.Checked = false;
            rdbTitulo.Checked = false;
            rdbIsbn.Checked = false;
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (ltbPesquisar.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um livro para vender.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (tipo == "Emp")
            {
                MessageBox.Show("Esse livro está reservado para empréstimo, não pode ser vendido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                frmVender abrirVender = new frmVender(this.nome, this.codUsu, this.cargo, nomeLivro, estoque);

                abrirVender.Show();
                this.Hide();
            }
        }

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            if (ltbPesquisar.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um livro para emprestar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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
                frmCadastroLivros abrir = new frmCadastroLivros(this.nome, this.codUsu, this.cargo);
                abrir.Show();
                this.Hide();
            }
            if (ultimaTela == "Venda")
            {
                frmVender abrir = new frmVender(this.nome, this.codUsu, this.cargo);
                abrir.Show();
                this.Hide();
            }
            if (ultimaTela == "Empréstimo")
            {
                frmEmprestimo abrir = new frmEmprestimo(this.nome, this.codUsu, this.cargo);
                abrir.Show();
                this.Hide();
            }
            if(ultimaTela == "Devolução")
            {
                frmDevolucao abrir = new frmDevolucao(this.nome, this.codUsu, this.cargo);
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

        public bool checarCampos()
        {
            if (rdbIdLivro.Checked && txtIdLivro.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher o ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdLivro.Focus();
                return false;
            }
            else if (rdbIsbn.Checked && txtIsbn.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher o ISBN.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIsbn.Focus();
                return false;
            }
            else if (rdbTitulo.Checked && txtTitulo.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher o Título.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitulo.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checarCharactere()
        {
            int tryParse;
                        
            if (int.TryParse(txtTitulo.Text, out tryParse))
            {
                MessageBox.Show("Use apenas letras.", "Mensagem do sistema", MessageBoxButtons.OK);
                txtTitulo.Clear();
                txtTitulo.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (checarCharactere() && checarCampos())
            {
                if (rdbIdLivro.Checked)
                {
                    pesquisarPorId(Convert.ToInt32(txtIdLivro.Text));
                }
                if (rdbTitulo.Checked)
                {
                    pesquisarPorNome(txtTitulo.Text);
                }
                if (rdbIsbn.Checked)
                {
                    pesquisarPorIsbn(Convert.ToInt32(txtIsbn.Text));
                }
            }
        }

        public void pesquisarPorId(int descricao)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbLivro where codLivro = @codLivro;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = descricao;

                ltbPesquisar.Items.Clear();

                comm.Connection = Conexao.obterConexao();
                MySqlDataReader DR = comm.ExecuteReader();
                DR.Read();

                if (!DR.HasRows)
                {
                    MessageBox.Show("Não há livros com esse ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                codLivroEstoque = DR.GetInt32(0);
                ltbPesquisar.Items.Add(DR.GetString(3));
                fotoPath = DR.GetString(9);
                mostrarFoto(fotoPath);

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("ID não encontrado/inexistente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pesquisarPorNome(string descricao)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbLivro where nome like '%" + descricao + "%';";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = descricao;

                ltbPesquisar.Items.Clear();

                comm.Connection = Conexao.obterConexao();
                MySqlDataReader DR = comm.ExecuteReader();

                while (DR.Read())
                {
                    if (DR.HasRows)
                    {
                        ltbPesquisar.Items.Add(DR.GetString(3));
                    }
                    else
                    {
                        MessageBox.Show("Não há livros com esse nome.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Livro não encontrado/inexistente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void pesquisarPorIsbn(int descricao)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbLivro where isbn = @isbn;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@isbn", MySqlDbType.Int32).Value = descricao;

                ltbPesquisar.Items.Clear();

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR = comm.ExecuteReader();
                DR.Read();
                if (!DR.HasRows)
                {
                    MessageBox.Show("Não há livros com esse ISBN.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                codLivroEstoque = DR.GetInt32(0);
                ltbPesquisar.Items.Add(DR.GetString(3));
                fotoPath = DR.GetString(9);
                mostrarFoto(fotoPath);

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("ISBN não encontrado/inexistente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int pegarEstoque(string livroSelecionado)
        {
            string tipo;
            int estoqueEnt = 0;
            int estoqueSai = 0;
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbEstoque where nomeLivro = @nomeLivro";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = livroSelecionado;

                comm.Connection = Conexao.obterConexao();
                MySqlDataReader DR = comm.ExecuteReader();
                DR.Read();

                codLivroEstoque = DR.GetInt32(6);
                tipo = DR.GetString(1);
                if (tipo == "Ven")
                {
                    estoqueEnt = DR.GetInt32(2);
                    estoqueSai = DR.GetInt32(3);
                }
                if (tipo == "Emp")
                {
                    estoqueEnt = DR.GetInt32(4);
                    estoqueSai = DR.GetInt32(5);
                }

                estoque = estoqueEnt - estoqueSai;

                Conexao.fecharConexao();

                return estoque;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao checar estoque do livro selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public void mostrarFoto(string path)
        {
            if (path.Equals(""))
            {
                pctLivro.Image = null;
            }
            else
            {
                pctLivro.ImageLocation = path;
                pctLivro.Load();
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
            if (this.cargo == "Voluntario")
            {
                MessageBox.Show("Você não tem permissão para acessar essa funcionalidade.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (ltbPesquisar.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um livro para gerenciar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmCadastroLivros abrir = new frmCadastroLivros(nomeLivro, this.nome, this.codUsu, this.cargo);
            abrir.Show();
            this.Hide();
        }
        private void txtIdLivro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
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
            if (ltbPesquisar.SelectedItem != null)
            {
                nomeLivro = ltbPesquisar.SelectedItem.ToString();
                if (pegarEstoque(nomeLivro) <= 5 && pegarEstoque(nomeLivro) > 0)
                {
                    MessageBox.Show("Resta " + pegarEstoque(nomeLivro) + " unidades no estoque.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estoque = pegarEstoque(nomeLivro);
                    btnVender.Enabled = true;
                    btnEmprestar.Enabled = true;
                }
                if (pegarEstoque(nomeLivro) <= 0)
                {
                    MessageBox.Show("Não há unidades em estoque.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnVender.Enabled = false;
                    btnEmprestar.Enabled = false;
                    return;
                }
            }
        }

        private void txtIsbn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtIdLivro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
