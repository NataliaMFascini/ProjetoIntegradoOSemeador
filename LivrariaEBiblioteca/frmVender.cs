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
    public partial class frmVender : Form
    {
        public decimal valorTotal = 0;
        public decimal valor = 0;
        public int codLivro = 0;
        public int codUsu = 0;
        public string nome;
        public string cargo;
        public int quantTotal = 0;

        Livros livros = new Livros();

        public frmVender()
        {
            InitializeComponent();
        }

        public frmVender(string nomeUsu, int codUsuario, string cargo)
        {
            InitializeComponent();

            txtVendedor.Text = nomeUsu;
            nome = nomeUsu;
            codUsu = codUsuario;
            this.cargo = cargo;
        }

        public void ReceberDadosLivro(string titulo,string isbn, string idLivro)
        {
            txtTitulo.Text = titulo;
            txtIsbn.Text = isbn;
            txtIdLivro.Text = idLivro;
        }

        public void limparComponentes()
        {
            txtAutor.Clear();
            txtEditora.Clear();
            txtIdLivro.Clear();
            txtIsbn.Clear();
            txtTitulo.Clear();
            txtValor.Clear();
            txtValorTotal.Clear();
            ltbCarrinho.Items.Clear();
            cbbFormaPagamento.Text = "";

            Livros.ListaLivros.Clear();
        }

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            frmEmprestimo abrir = new frmEmprestimo(this.nome, this.codUsu, this.cargo);
            abrir.Show();
            this.Hide();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal(this.cargo, this.nome, this.codUsu);
            abrir.Show();
            this.Hide();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparComponentes();
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
            else if (txtValor.Text.Equals(""))
            {
                erroCadastro("Valor");
                txtValor.Focus();
            }
            else if (cbbFormaPagamento.Items.Equals(""))
            {
                erroCadastro("Forma de Pagamento");
                cbbFormaPagamento.Focus();
            }


            else
            {
                ltbCarrinho.Items.Add(txtTitulo.Text + " - R$ " + txtValor.Text);

                //Tem que separar por livro
                separarLivros();

                valor = Convert.ToDecimal(txtValor.Text);

                valorTotal = valorTotal + valor;
                txtValorTotal.Text = "R$" + valorTotal.ToString();
            }
        }
        public void separarLivros()
        {
            Livros livros = new Livros();

            livros.idLivro = Convert.ToInt32(txtIdLivro.Text);
            livros.nomeLivro = txtTitulo.Text;
            livros.valorLivro = Convert.ToDecimal(txtValor.Text);

            Livros.ListaLivros.Add(livros);
        }
        public void erroCadastro(string nomeCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarLivro abrir = new frmBuscarLivro();
            abrir.Show();
            this.Hide();
        }
        public void escanearLivro(string isbn)
        {
            string tipo;

            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select codLivro, empVen, nome, autor, editora, valor, foto from tbLivro where isbn = @isbn;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@isbn", MySqlDbType.VarChar, 13).Value = isbn;

            comm.Connection = Conexao.obterConexao();
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            bool resp = DR.HasRows;

            if (resp)
            {
                tipo = DR.GetString(1);

                if (tipo.Equals("Emp"))
                {
                    MessageBox.Show("Esse livro não está disponível para venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    txtIsbn.Clear();
                    txtIsbn.Focus();
                }
                else
                {
                    txtIdLivro.Text = Convert.ToString(DR.GetInt32(0));
                    txtTitulo.Text = DR.GetString(2);
                    txtAutor.Text = DR.GetString(3);
                    txtEditora.Text = DR.GetString(4);
                    txtValor.Text = Convert.ToString(DR.GetDecimal(5));
                    //pctLivro.ImageLocation = DR.GetString(6);
                }
            }
            else
            {
                MessageBox.Show("ISBN inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                txtIsbn.Focus();
            }

            Conexao.fecharConexao();

        }

        private void txtIsbn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                escanearLivro(txtIsbn.Text);
                codLivro = Convert.ToInt32(txtIdLivro.Text);
                if(livros.checarEstoque(codLivro, "Ven") <= 5)
                {
                    MessageBox.Show("Resta " + livros.checarEstoque(codLivro, "Ven") + " em estoque.", "Aviso do estoque", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (ltbCarrinho.Items.Count != 0)
            {
                if (registrarVenda(codUsu) == 1 && saidaEstoque() == 1)
                {
                    MessageBox.Show("Venda registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    limparComponentes();
                }
                else
                {
                    MessageBox.Show("Erro ao registrar a venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
            }
            else
            {
                MessageBox.Show("Carrinho vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }

        public int registrarVenda(int codigoUsuario)
        {
            MySqlCommand comm = new MySqlCommand();
            int resp = 0;

            comm.CommandText = "insert into tbVendas(dataVenda, nomeLivro, valorTotal, pagamento, nomeVendedor, codUsu, codLivro) values (@dataVenda, @nomeLivro, @valorTotal, @pagamento, @nomeVendedor, @codUsu, @codLivro);";
            comm.CommandType = CommandType.Text;


            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                comm.Parameters.Clear();

                comm.Parameters.Add("@dataVenda", MySqlDbType.DateTime).Value = DateTime.Now;
                comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = livros.nomeRetorno(i);
                comm.Parameters.Add("@valorTotal", MySqlDbType.Decimal).Value = livros.valorRetorno(i);
                comm.Parameters.Add("@pagamento", MySqlDbType.VarChar, 50).Value = cbbFormaPagamento.Text;
                comm.Parameters.Add("@nomeVendedor", MySqlDbType.VarChar, 100).Value = this.nome;
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.codRetorno(i);
                comm.Parameters.Add("@codUsu", MySqlDbType.Int32).Value = codigoUsuario;

                comm.Connection = Conexao.obterConexao();

                resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();
            }

            return resp;
        }

        public int saidaEstoque()
        {
            MySqlCommand comm = new MySqlCommand();
            int resp = 0;

            comm.CommandText = "update tbEstoque set saidaVen = @saidaVen, empVen = @empVen where codLivro = @codLivro";
            comm.CommandType = CommandType.Text;
            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                comm.Parameters.Clear();
                comm.Parameters.Add("@saidaVen", MySqlDbType.Int32).Value = quantidadeRetorno(i);
                comm.Parameters.Add("@empVen", MySqlDbType.Int32).Value = "Ven";
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.codRetorno(i);

                comm.Connection = Conexao.obterConexao();

                resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();
            }
            return resp;
        }
        public int quantidadeRetorno(int index)
        {
            int quantTotal = 0;

            for (int i = 0; i < Livros.ListaLivros.Count - 1; i++)
            {
                if (Livros.ListaLivros[index].idLivro == Livros.ListaLivros[i + 1].idLivro)
                {
                    quantTotal++;
                }
            }
            return quantTotal;
        }

        private void ltbCarrinho_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                valorTotal -= livros.valorRetorno(ltbCarrinho.SelectedIndex);
                txtValorTotal.Text = "R$ " + valorTotal.ToString();
                ltbCarrinho.Items.RemoveAt(ltbCarrinho.SelectedIndex);
            }
        }

        private void ltbCarrinho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                valorTotal -= livros.valorRetorno(ltbCarrinho.SelectedIndex);
                txtValorTotal.Text = "R$ " + valorTotal.ToString();
                ltbCarrinho.Items.RemoveAt(ltbCarrinho.SelectedIndex);
            }
        }

        private void frmVender_Load(object sender, EventArgs e)
        {

        }
    }
}

