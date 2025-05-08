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
        public int codLivro = 0;
        public int codLoc = 0;
        public int codUsu = 0;
        public int codEmp = 0;
        public string nome;
        public string cargo;
        public string fotoPath;

        string nomeCheck;
        string codLivroCheck;

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

            string codLoc = txtLocatario.Text;

        }

        public frmEmprestimo(string nome, int codUsu, string cargo, string livro)
        {
            InitializeComponent();
            DesabilitarCampos();

            this.nome = nome;
            this.codUsu = codUsu;
            this.cargo = cargo;

            string codLoc = txtLocatario.Text;

            pesquisarPorNome(livro);

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
            mskDataDevolucao.Clear();
            pctLivro.Image = null;

            ltbCarrinho.Items.Clear();

        }
        public void ReceberDadosLivro(string titulo, string isbn, string idLivro)
        {
            txtTitulo.Text = titulo;
            txtIsbn.Text = isbn;
            txtIdLivro.Text = idLivro;

        }

        public Boolean checarComponentes()
        {
            Boolean result = true;
            if (txtTitulo.Text.Equals(""))
            {
                MessageBox.Show("Favor, informe o título do livro", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitulo.Focus();
                result = false;
            }
            else if (txtAutor.Text.Equals(""))
            {
                MessageBox.Show("Favor, informe o autor do livro", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutor.Focus();
                result = false;
            }
            else if (txtEditora.Text.Equals(""))
            {
                MessageBox.Show("Favor, informe a editora", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEditora.Focus();
                result = false;
            }
            else if (txtIsbn.Text.Equals(""))
            {
                MessageBox.Show("Favor, informe o ISBN do livro", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIsbn.Focus();
                result = false;
            }


            return result;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (checarComponentes())
            {

                if (!mskDataDevolucao.Equals("  /  /    ") && mskDataDevolucao.MaskFull)
                {
                    ltbCarrinho.Items.Add(txtTitulo.Text = " Devolução:" + mskDataDevolucao.Text);
                    separarLivros();
                }
                else
                {
                    ltbCarrinho.Items.Add(txtTitulo.Text);
                    separarLivros();
                }

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

        public int registrarEmprestimo()
        {

            MySqlCommand comm = new MySqlCommand();
            int resp = 0;

            comm.CommandText = "insert into tbEmprestimo( dataEmp, nomeVendedor, nomeLivro, prontuario, codLivro) values (@dataEmp, @nomeVendedor, @nomeLivro, @prontuario, @codLivro);";
            comm.CommandType = CommandType.Text;

            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                comm.Parameters.Clear();

                comm.Parameters.Add("@dataEmp", MySqlDbType.DateTime).Value = DateTime.Now;

                //if (!mskDataDevolucao.Equals("  /  /    ") && mskDataDevolucao.MaskFull)
                //{
                //    // Converte o texto para DateTime
                //    DateTime dataConvertida = DateTime.ParseExact(mskDataDevolucao.Text, "dd/MM/yyyy", null);

                //    // Cria e configura o comando
                //    comm.Parameters.Add("@dataDev", MySqlDbType.DateTime).Value = dataConvertida;
                //}

                comm.Parameters.Add("@nomeVendedor", MySqlDbType.VarChar, 100).Value = this.nome;
                comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = livros.nomeRetorno(i);
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.codRetorno(i);
                //comm.Parameters.Add("@codLoc", MySqlDbType.Int32).Value = codLoc;
                comm.Parameters.Add("@prontuario", MySqlDbType.Int32).Value = Convert.ToInt32(txtLocatario.Text);
                comm.Connection = Conexao.obterConexao();

                try
                {
                    resp = comm.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erro no banco: " + ex.Message);
                }


                Conexao.fecharConexao();
            }

            return resp;
        }

        public int saidaEstoque()
        {
            MySqlCommand comm = new MySqlCommand();
            int resp = 0;

            comm.CommandText = "update tbEstoque set saidaEmp = @saidaEmp where codLivro = @codLivro";
            comm.CommandType = CommandType.Text;
            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                comm.Parameters.Clear();
                comm.Parameters.Add("@saidaEmp", MySqlDbType.Int32).Value = pegarQuantLivro(i, "Saida") + quantidadeRetorno(i);
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.codRetorno(i);

                comm.Connection = Conexao.obterConexao();
                try
                {
                    resp = comm.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erro no banco: " + ex.Message);
                }

                Conexao.fecharConexao();
            }

            return resp;
        }

        public int retornoEstoque()
        {
            MySqlCommand comm = new MySqlCommand();
            int resp = 0;

            comm.CommandText = "UPDATE tbEstoque SET entradaEmp = @entradaEmp WHERE codLivro = @codLivro";
            comm.CommandType = CommandType.Text;

            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                comm.Parameters.Clear();
                comm.Parameters.Add("@saidaEmp", MySqlDbType.Int32).Value = pegarQuantLivro(i, "Entrada") + quantidadeRetorno(i);
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = Livros.ListaLivros[i].idLivro;

                comm.Connection = Conexao.obterConexao();
                try
                {
                    resp = comm.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erro ao retornar livro ao estoque: " + ex.Message);
                }
                Conexao.fecharConexao();
            }

            return resp;
        }

        public int pegarQuantLivro(int index, string entSai)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();

                if (entSai == "Entrada")
                {
                    comm.CommandText = "select entradaEmp from tbEstoque where codLivro = @codLivro;";
                }
                else
                {
                    comm.CommandText = "select saidaEmp from tbEstoque where codLivro = @codLivro;";
                }

                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32, 20).Value = livros.codRetorno(index);


                comm.Connection = Conexao.obterConexao();


                MySqlDataReader DR = comm.ExecuteReader();


                if (DR.Read())
                {
                    int quant = DR.GetInt32(0); // Pega a quantidade do banco
                    Conexao.fecharConexao(); // Fecha a conexão
                    return quant;
                }
                else
                {

                    Conexao.fecharConexao();
                    return 0;
                }
            }
            catch (MySqlException)
            {

                MessageBox.Show("Erro ao pegar a quantidade do livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return 0;
            }
        }
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (rdbDevolução.Checked)
            {
                if (retornoEstoque() > 0)
                {
                    MessageBox.Show("Livro devolvido e estoque atualizado!", "Sucesso");
                    limparCampos();
                    Livros.ListaLivros.Clear(); // limpar a lista
                }
                else
                {
                    MessageBox.Show("Erro ao devolver livro.", "Erro");
                }
            }
            else if (rdbEmprestimo.Checked)
            {
                if (ltbCarrinho.Items.Count != 0)

                {
                    if (registrarEmprestimo() == 1 && saidaEstoque() == 1)
                    {
                        MessageBox.Show("Empréstimo registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        limparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao registrar o empréstimo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }
                }
                else
                {
                    MessageBox.Show("Carrinho vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
            }
        }
        public void separarLivros()


        {
            try
            {
                Livros livros = new Livros();

                livros.idLivro = Convert.ToInt32(txtIdLivro.Text);
                livros.nomeLivro = txtTitulo.Text;

                Livros.ListaLivros.Add(livros);
            }
            catch (Exception)
            {
                MessageBox.Show("Livro não encontrado", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public string checargemDevolucao(string codEmp)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select codLivro, nomeLivro from tbEmprestimo where codEmp = @codEmp;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codEmp", MySqlDbType.VarChar, 1000).Value = codEmp;
            comm.Connection = Conexao.obterConexao();
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            ltbCarrinho.Items.Clear();

            bool resp = DR.HasRows;

            if (resp)
            {
                //while (DR.Read())
                //{
                //    //ltbCarrinho.Items.Add(DR.GetString(0) + ":" + DR.GetString(1));

                //}
                codLivroCheck = DR.GetInt32(0).ToString();
                nomeCheck = DR.GetString(1);
            }
            else
            {
                MessageBox.Show("Nº de empréstimo inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                txtNEmprestimo.Clear();
                txtNEmprestimo.Focus();
            }
            return codLivroCheck + " - " + nomeCheck;
        }

        public void escanearLivro(string isbn)
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

        private void txtIsbn_KeyDown_1(object sender, KeyEventArgs e)
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
        public int quantidadeRetorno(int index)
        {
            int quantTotal = 1;

            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                if (i != index && Livros.ListaLivros[i].idLivro == Livros.ListaLivros[index].idLivro)
                {
                    quantTotal++;
                }
            }
            return quantTotal;
        }

        private void rdbDevolução_CheckedChanged(object sender, EventArgs e)
        {
            txtNEmprestimo.Enabled = true;
        }

        private void rdbEmprestimo_CheckedChanged(object sender, EventArgs e)
        {
            txtNEmprestimo.Enabled = false;
        }

        private void txtNEmprestimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ltbCarrinho.Items.Add(checargemDevolucao(txtNEmprestimo.Text));
                //checargemDevolucao(Convert.ToString(ltbCarrinho.Items));
            }
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
    }
}

