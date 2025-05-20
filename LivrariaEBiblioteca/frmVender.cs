using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
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
        public string fotoPath;

        public int estoqueInicial = 0;
        public decimal custo = 0;
        Livros livros = new Livros();

        public frmVender(string nomeUsu, int codUsuario, string cargo)
        {
            InitializeComponent();

            txtVendedor.Text = nomeUsu;
            nome = nomeUsu;
            codUsu = codUsuario;
            this.cargo = cargo;
        }

        public frmVender(string nomeUsu, int codUsuario, string cargo, string livro, int estoquePesquisa)
        {
            InitializeComponent();

            txtVendedor.Text = nomeUsu;
            nome = nomeUsu;
            codUsu = codUsuario;
            this.cargo = cargo;

            pesquisarPorNome(livro);

            estoqueInicial = estoquePesquisa;
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
            estoqueInicial = 0;
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
            int tryParse;
            decimal tryParseDecimal;
            if (txtIsbn.Text.Equals(""))
            {
                if (!int.TryParse(txtIsbn.Text, out tryParse))
                {
                    erroCampo("ISBN", "numérico");
                    txtIsbn.Clear();
                    txtIsbn.Focus();
                    return;
                }
                erroCadastro("ISBN");
                txtIsbn.Focus();
            }
            else if (txtTitulo.Text.Equals(""))
            {
                if (int.TryParse(txtTitulo.Text, out tryParse))
                {
                    erroCampo("Título", "alfabético");
                    txtTitulo.Clear();
                    txtTitulo.Focus();
                    return;
                }
                erroCadastro("Titulo");
                txtTitulo.Focus();
            }
            else if (txtAutor.Text.Equals(""))
            {
                if (int.TryParse(txtAutor.Text, out tryParse))
                {
                    erroCampo("Autor", "alfabético");
                    txtAutor.Clear();
                    txtAutor.Focus();
                    return;
                }
                erroCadastro("Autor");
                txtAutor.Focus();
            }
            else if (txtEditora.Text.Equals(""))
            {
                if (int.TryParse(txtEditora.Text, out tryParse))
                {
                    erroCampo("Editora", "alfabético");
                    txtEditora.Clear();
                    txtEditora.Focus();
                    return;
                }
                erroCadastro("Editora");
                txtEditora.Focus();
            }
            else if (txtValor.Text.Equals(""))
            {
                if (!decimal.TryParse(txtValor.Text, out tryParseDecimal))
                {
                    erroCampo("Valor", "numérico");
                    txtEditora.Clear();
                    txtEditora.Focus();
                    return;
                }
                erroCadastro("Valor");
                txtValor.Focus();
            }
            else
            {
                //Tem que separar por livro

                separarLivros();
                if (estoqueInicial <= 5 && estoqueInicial > 0)
                {
                    if (estoqueInicial == 1)
                    {
                        MessageBox.Show("Essa é a última unidade no estoque.", "Aviso do estoque", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Resta " + estoqueInicial + " unidades em estoque.", "Aviso do estoque", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (estoqueInicial <= 0)
                {
                    MessageBox.Show("Não há mais esse livro em estoque.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return;
                }
                ltbCarrinho.Items.Add(txtTitulo.Text + " - " + txtAutor.Text + " - R$ " + txtValor.Text);

                estoqueInicial--;
                valor = custo;

                valorTotal = valorTotal + valor;
                txtValorTotal.Text = "R$" + valorTotal.ToString();
            }
        }
        public void separarLivros()
        {
            Livros livros = new Livros();

            livros.idLivro = Convert.ToInt32(txtIdLivro.Text);
            livros.nomeLivro = txtTitulo.Text;
            livros.valorLivro = custo;

            Livros.ListaLivros.Add(livros);
        }

        public void erroCadastro(string nomeCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }
        private void erroCampo(string nomeCampo, string tipoCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo somente " + tipoCampo + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarLivro abrir = new frmBuscarLivro(this.nome, this.codUsu, this.cargo, "Venda");

            if (ltbCarrinho.Items.Count != 0)
            {
                DialogResult resultado = MessageBox.Show("Essa ação irá limpar o carrinho. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (resultado == DialogResult.Yes)
                {
                    abrir = new frmBuscarLivro(this.nome, this.codUsu, this.cargo, "Venda");
                    abrir.Show();
                    this.Hide();
                }
            }
            else
            {
                abrir = new frmBuscarLivro(this.nome, this.codUsu, this.cargo, "Venda");
                abrir.Show();
                this.Hide();
            }
        }
        public void escanearLivro(string isbn)
        {
            try
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
                        custo = DR.GetDecimal(5);
                        txtValor.Text = "R$ " + custo.ToString("0.00");
                        if (fotoPath != null)
                        {
                            fotoPath = DR.GetString(6);
                            pctLivro.ImageLocation = fotoPath;
                            pctLivro.Load();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ISBN inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    txtIsbn.Focus();
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao escanear livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }

        }

        private void txtIsbn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                escanearLivro(txtIsbn.Text);
                codLivro = Convert.ToInt32(txtIdLivro.Text);
                estoqueInicial = livros.checarEstoque(codLivro, "Ven");

                if (estoqueInicial <= 5 && estoqueInicial == 0)
                {
                    MessageBox.Show("Resta " + estoqueInicial + " unidades em estoque.", "Aviso do estoque", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            int tryParse;
            if (cbbFormaPagamento.Text.Equals(""))
            {
                if (int.TryParse(cbbFormaPagamento.Text, out tryParse))
                {
                    erroCampo("Forma de Pagamento", "alfabético");
                    return;
                }
                erroCadastro("Forma de Pagamento");
                cbbFormaPagamento.Focus();
                return;
            }
            if (ltbCarrinho.Items.Count != 0)
            {
                if (registrarVenda() == 1 && saidaEstoque() == 1)
                {
                    MessageBox.Show("Venda registrada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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

        public int registrarVenda()
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                int resp = 0;

                comm.CommandText = "insert into tbVendas(dataVenda, nomeLivro, valorTotal, pagamento, nomeVendedor, dataCadastro, codUsu, codLivro) values (@dataVenda, @nomeLivro, @valorTotal, @pagamento, @nomeVendedor, @dataCadastro, @codUsu, @codLivro);";
                comm.CommandType = CommandType.Text;


                for (int i = 0; i < Livros.ListaLivros.Count; i++)
                {
                    comm.Parameters.Clear();

                    comm.Parameters.Add("@dataVenda", MySqlDbType.DateTime).Value = DateTime.Now;
                    comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = livros.nomeRetorno(i);
                    comm.Parameters.Add("@valorTotal", MySqlDbType.Decimal).Value = livros.valorRetorno(i);
                    comm.Parameters.Add("@pagamento", MySqlDbType.VarChar, 50).Value = cbbFormaPagamento.Text;
                    comm.Parameters.Add("@nomeVendedor", MySqlDbType.VarChar, 100).Value = this.nome;
                    comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;
                    comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.codRetorno(i);
                    comm.Parameters.Add("@codUsu", MySqlDbType.Int32).Value = codUsu;

                    comm.Connection = Conexao.obterConexao();

                    resp = comm.ExecuteNonQuery();

                    Conexao.fecharConexao();
                }

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao registrar a venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return 0;
            }
        }

        public int saidaEstoque()
        {
            MySqlCommand comm = new MySqlCommand();
            int resp = 0;
            try
            {
                for (int i = 0; i < livros.quantidadeLista(); i++)
                {
                    comm.CommandText = "update tbEstoque set saidaVen = @saidaVen, empVen = @empVen where codLivro = @codLivro";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@saidaVen", MySqlDbType.Int32).Value = pegarQuantSaida(livros.proximoLivro(i)) + quantidadeRetorno(i);
                    comm.Parameters.Add("@empVen", MySqlDbType.VarChar, 3).Value = "Ven";
                    comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.proximoLivro(i);

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
                comm.CommandText = "select entradaVen from tbEstoque where codLivro = @codLivro;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32, 20).Value = livros.proximoLivro(index);

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

        public int pegarQuantSaida(int index)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select saidaVen from tbEstoque where codLivro = @codLivro;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32, 20).Value = livros.proximoLivro(index);

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

        private void ltbCarrinho_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    valorTotal -= livros.valorRetorno(ltbCarrinho.SelectedIndex);
                    txtValorTotal.Text = "R$ " + valorTotal.ToString();
                    Livros.ListaLivros.RemoveAt(ltbCarrinho.SelectedIndex);
                    ltbCarrinho.Items.RemoveAt(ltbCarrinho.SelectedIndex);
                    estoqueInicial++;
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
                    valorTotal -= livros.valorRetorno(ltbCarrinho.SelectedIndex);
                    txtValorTotal.Text = "R$ " + valorTotal.ToString();
                    Livros.ListaLivros.RemoveAt(ltbCarrinho.SelectedIndex);
                    ltbCarrinho.Items.RemoveAt(ltbCarrinho.SelectedIndex);
                    estoqueInicial++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao remover item do carrinho.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pesquisarPorNome(string nome)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select codLivro, isbn, nome, autor, editora, valor, foto from tbLivro where nome = @nome;";
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
                custo = DR.GetDecimal(5);
                txtValor.Text = "R$ " + custo.ToString("0.00");
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

        private void txtIsbn_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTitulo.Focus();
            }
        }

        private void txtTitulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAutor.Focus();
            }

        }

        private void txtAutor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEditora.Focus();
            }
        }

        private void txtEditora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtValor.Focus();
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbbFormaPagamento.Focus();
            }
        }
    }
}

