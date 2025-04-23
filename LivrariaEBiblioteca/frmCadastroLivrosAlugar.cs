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
    public partial class frmCadastroLivrosAlugar : Form
    {
        public frmCadastroLivrosAlugar()
        {
            InitializeComponent();
            desabilitarCampos();
        }

        public void limparComponentes()
        {
            txtAno.Clear();
            txtAutor.Clear();
            txtEditora.Clear();
            txtIdLivro.Clear();
            txtIsbn.Clear();
            txtQuantidade.Clear();
            txtTitulo.Clear();
            txtValor.Clear();
            rdbEmprestimo.Checked = false;
            rdbVenda.Checked = false;
            pctLivro.Image = null;
        }

        public frmCadastroLivrosAlugar(string livro)
        {
            InitializeComponent();
            habilitarCampos();
        }

        public void limparCampos()
        {
            txtIsbn.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtEditora.Clear();
            txtAno.Clear();
            txtQuantidade.Clear();
            txtValor.Clear();
            pctLivro.Image = null;
            rdbEmprestimo.Checked = false;
            rdbVenda.Checked = false;
            txtIsbn.Focus();
        }

        public void desabilitarCampos()
        {
            btnRemover.Enabled = false;
            btnAlterar.Enabled = false;
        }

        public void habilitarCampos()
        {
            btnRemover.Enabled = true;
            btnAlterar.Enabled = true;
        }
        private void erroCadastro(string nomeCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            frmBuscarLivro abrir = new frmBuscarLivro();
            abrir.Show();
            this.Hide();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            if (txtIsbn.Text.Equals(""))
            {
                erroCadastro("ISBN");
                txtIsbn.Focus();
            }
            else if (txtTitulo.Text.Equals(""))
            {
                erroCadastro("Titulo");
                txtTitulo.Focus();
            }
            else if (txtAutor.Text.Equals(""))
            {
                erroCadastro("Autor");
                txtAutor.Focus();
            }
            else if (txtEditora.Text.Equals(""))
            {
                erroCadastro("Editora");
                txtEditora.Focus();
            }
            else if (txtAno.Text.Equals(""))
            {
                erroCadastro("Ano");
                txtAno.Focus();
            }
            else if (txtQuantidade.Text.Equals(""))
            {
                erroCadastro("Quantidade");
                txtQuantidade.Focus();
            }
            else if (txtValor.Text.Equals(""))
            {
                erroCadastro("Valor");
                txtValor.Focus();
            }
            else if (rdbEmprestimo.Checked == false && rdbVenda.Checked == false)
            {
                erroCadastro("Emprestimo ou Venda");

            }
            else
            {
                if (cadastrarLivro() == 1 && adicionarEstoque() == 1)
                {
                    MessageBox.Show("Cadastro realizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limparCampos();

                    txtIsbn.Focus();

                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar livro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public int cadastrarLivro()
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "insert into tbLivro (empVen, isbn, nome, autor, quant, valor, editora, anoPublicacao, foto, dataCadastro) values (@empVen, @isbn, @nome, @autor, @quant, @valor, @editora, @anoPublicacao, @foto, @dataCadastro);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            if (rdbEmprestimo.Checked)
            {
                comm.Parameters.Add("@empVen", MySqlDbType.VarChar, 3).Value = "Emp";
            }
            if (rdbVenda.Checked)
            {
                comm.Parameters.Add("@empVen", MySqlDbType.VarChar, 3).Value = "Ven";
            }
            comm.Parameters.Add("@isbn", MySqlDbType.VarChar, 20).Value = txtIsbn.Text;
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtTitulo.Text;
            comm.Parameters.Add("@autor", MySqlDbType.VarChar, 100).Value = txtAutor.Text;
            comm.Parameters.Add("@quant", MySqlDbType.Int32).Value = Convert.ToInt32(txtQuantidade.Text);
            comm.Parameters.Add("@valor", MySqlDbType.Decimal).Value = Convert.ToDecimal(txtValor.Text);
            comm.Parameters.Add("@editora", MySqlDbType.VarChar, 50).Value = txtEditora.Text;
            comm.Parameters.Add("@anoPublicacao", MySqlDbType.Int32).Value = Convert.ToInt32(txtAno.Text);
            comm.Parameters.Add("@foto", MySqlDbType.Blob).Value = pctLivro.Image;
            comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;

            comm.Connection = Conexao.obterConexao();
            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparComponentes();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void btnAdicionarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto = new OpenFileDialog();
            foto.Title = "Selecione uma imagem";
            foto.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp|Todos os arquivos|*.*";

            if (foto.ShowDialog() == DialogResult.OK)
            {
                pctLivro.ImageLocation = foto.FileName;
                pctLivro.Load();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja excluir o livro?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resultado == DialogResult.Yes)
            {
                excluirLivro(Convert.ToInt32(txtIdLivro.Text));
                limparCampos();
            }
        }

        public int excluirLivro(int codLivro)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "delete from tbLivro where codLivro = @codLivro;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            comm.Parameters.Clear();
            comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = codLivro;

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        public int alterarLivro(int codLivro)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update tbLivro set empVen = @empVen, isbn = @isbn, nome = @nome, autor = @autor, quant = @quant, valor = @valor, editora = @editora, anoPublicacao = @anoPublicacao, foto = @foto, dataCadastro = @dataCadastro where codLivro = @codLivro;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            if (rdbEmprestimo.Checked)
            {
                comm.Parameters.Add("@empVen", MySqlDbType.VarChar, 3).Value = "Emp";
            }
            if (rdbVenda.Checked)
            {
                comm.Parameters.Add("@empVen", MySqlDbType.VarChar, 3).Value = "Ven";
            }
            comm.Parameters.Add("@isbn", MySqlDbType.VarChar, 20).Value = txtIsbn.Text;
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtTitulo.Text;
            comm.Parameters.Add("@autor", MySqlDbType.VarChar, 100).Value = txtAutor.Text;
            comm.Parameters.Add("@quant", MySqlDbType.Int32).Value = Convert.ToInt32(txtQuantidade.Text);
            comm.Parameters.Add("@valor", MySqlDbType.Decimal).Value = Convert.ToDecimal(txtValor.Text);
            comm.Parameters.Add("@editora", MySqlDbType.VarChar, 50).Value = txtEditora.Text;
            comm.Parameters.Add("@anoPublicacao", MySqlDbType.Int32).Value = Convert.ToInt32(txtAno.Text);
            comm.Parameters.Add("@foto", MySqlDbType.Blob).Value = pctLivro.Image;
            comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;

            comm.Connection = Conexao.obterConexao();
            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtIsbn.Text.Equals(""))
            {
                erroCadastro("ISBN");
                txtIsbn.Focus();
            }
            else if (txtTitulo.Text.Equals(""))
            {
                erroCadastro("Titulo");
                txtTitulo.Focus();
            }
            else if (txtAutor.Text.Equals(""))
            {
                erroCadastro("Autor");
                txtAutor.Focus();
            }
            else if (txtEditora.Text.Equals(""))
            {
                erroCadastro("Editora");
                txtEditora.Focus();
            }
            else if (txtAno.Text.Equals(""))
            {
                erroCadastro("Ano");
                txtAno.Focus();
            }
            else if (txtQuantidade.Text.Equals(""))
            {
                erroCadastro("Quantidade");
                txtQuantidade.Focus();
            }
            else if (txtValor.Text.Equals(""))
            {
                erroCadastro("Valor");
                txtValor.Focus();
            }
            else if (rdbEmprestimo.Checked == false && rdbVenda.Checked == false)
            {
                erroCadastro("Emprestimo ou Venda");

            }
            else
            {
                if (cadastrarLivro() == 1 && adicionarEstoque() == 1)
                {
                    MessageBox.Show("Cadastro realizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limparCampos();

                    txtIsbn.Focus();

                }
                else
                {
                    MessageBox.Show("Erro ao alterar cadastro", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public int adicionarEstoque()
        {
            MySqlCommand comm = new MySqlCommand();
            if (rdbVenda.Checked)
            {
                comm.CommandText = "insert into tbEstoque(entradaVen, empVen, codLivro, nomeLivro, dataCadastro) values (@entradaVen, @empVen, @codLivro, @nomeLivro, @dataCadastro);";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@entradaVen", MySqlDbType.Int32).Value = Convert.ToInt32(txtQuantidade.Text);
                comm.Parameters.Add("@empVen", MySqlDbType.VarChar, 3).Value = "Ven";
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = 1;
                comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = (txtTitulo.Text);
                comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;
            }
            if (rdbEmprestimo.Checked)
            {
                comm.CommandText = "insert into tbEstoque(entradaEmp, empVen, codLivro, nomeLivro, dataCadastro) values (@entradaEmp, @empVen, @codLivro, @nomeLivro, @dataCadastro);";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@entradaEmp", MySqlDbType.Int32).Value = Convert.ToInt32(txtQuantidade.Text);
                comm.Parameters.Add("@empVen", MySqlDbType.VarChar, 3).Value = "Emp";
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = 1;
                comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = (txtTitulo.Text);
                comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;
            }

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        private void rdbEmprestimo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEmprestimo.Checked)
            {
                txtValor.Enabled = false;
            }
            else
            {
                txtValor.Enabled = true;
            }
        }
    }
}
