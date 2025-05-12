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
        public string nomeLivro;
        public DateTime dataEmprestimo;


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

        public bool checarComponentes()
        {
            bool result = true;
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
            try
                MySqlCommand comm = new MySqlCommand();
            int resp = 0;

            comm.CommandText = "insert into tbEmprestimo(dataEmp, nomeVendedor, nomeLivro, prontuario, dataCadastro, codLivro) values (@dataEmp, @nomeVendedor, @nomeLivro, @prontuario, @dataCadastro, @codLivro);";
            comm.CommandType = CommandType.Text;

            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                comm.Parameters.Clear();

                comm.Parameters.Add("@dataEmp", MySqlDbType.DateTime).Value = DateTime.Now;
                comm.Parameters.Add("@nomeVendedor", MySqlDbType.VarChar, 100).Value = this.nome;
                comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = livros.nomeRetorno(i);
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.codRetorno(i);
                comm.Parameters.Add("@prontuario", MySqlDbType.Int32).Value = Convert.ToInt32(txtLocatario.Text);
                comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;
                comm.Connection = Conexao.obterConexao();

                try
                {
                    resp = comm.ExecuteNonQuery();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Erro ao registrar empréstimo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                Conexao.fecharConexao();
            }

            return resp;
            }
        }

        public int registrarRetorno()
        {
            int resp = 0;

            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbEmprestimo(dataDev, nomeVendedor, nomeLivro, prontuario, dataCadastro, codLivro) values (@dataDev, @nomeVendedor, @nomeLivro, @prontuario, @dataCadastro, @codLivro);";
            comm.CommandType = CommandType.Text;

            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                comm.Parameters.Clear();

                comm.Parameters.Add("@dataDev", MySqlDbType.DateTime).Value = DateTime.Now;
                comm.Parameters.Add("@nomeVendedor", MySqlDbType.VarChar, 100).Value = this.nome;
                comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = livros.nomeRetorno(i);
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.codRetorno(i);
                comm.Parameters.Add("@prontuario", MySqlDbType.Int32).Value = Convert.ToInt32(txtLocatario.Text);
                comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;
                comm.Connection = Conexao.obterConexao();

                try
                {
                    resp = comm.ExecuteNonQuery();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Erro ao registrar empréstimo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                Conexao.fecharConexao();
            }

            return resp;
        }

        public int saidaEstoque()
        {
            MySqlCommand comm = new MySqlCommand();
            int resp = 0;

            comm.CommandText = "update tbEstoque set saidaEmp = @saidaEmp, disponibilidade = @disponibilidade where codLivro = @codLivro";
            comm.CommandType = CommandType.Text;
            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                comm.Parameters.Clear();
                comm.Parameters.Add("@saidaEmp", MySqlDbType.Int32).Value = pegarQuantLivro(livros.proximoLivro(i), "Saida") + quantidadeRetorno(i);
                comm.Parameters.Add("@disponibilidade", MySqlDbType.VarChar).Value = "N";
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.proximoLivro(i);

                comm.Connection = Conexao.obterConexao();
                try
                {
                    resp = comm.ExecuteNonQuery();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Erro ao registrar empréstimo no estoque.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Conexao.fecharConexao();
            }

            return resp;
        }

        public int retornoEstoque()
        {
            MySqlCommand comm = new MySqlCommand();
            int resp = 0;

            comm.CommandText = "UPDATE tbEstoque SET entradaEmp = @entradaEmp, disponibilidade = @disponibilidade WHERE codLivro = @codLivro";
            comm.CommandType = CommandType.Text;

            for (int i = 0; i < livros.quantidadeLista(); i++)
            {
                comm.Parameters.Clear();
                comm.Parameters.Add("@entradaEmp", MySqlDbType.Int32).Value = pegarQuantLivro(livros.proximoLivro(i), "Entrada") + quantidadeRetorno(i);
                comm.Parameters.Add("@disponibilidade", MySqlDbType.VarChar).Value = "S";
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.proximoLivro(i);

                comm.Connection = Conexao.obterConexao();
                try
                {
                    resp = comm.ExecuteNonQuery();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Erro ao retornar livro ao estoque.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            Conexao.fecharConexao();

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
                if (entSai == "Saida")
                {
                    comm.CommandText = "select saidaEmp from tbEstoque where codLivro = @codLivro;";
                }

                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.proximoLivro(index);

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

        public void erroCadastro(string nomeCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }
        private void erroCampo(string nomeCampo, string tipoCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo somente " + tipoCampo + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            int tryParse;

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
            else if (txtLocatario.Text.Equals(""))
            {
                if (int.TryParse(txtEditora.Text, out tryParse))
                {
                    erroCampo("Locatário", "alfabético");
                    txtLocatario.Clear();
                    txtLocatario.Focus();
                    return;
                }
                erroCadastro("Locatário");
                txtLocatario.Focus();
            }
            if (rdbDevolução.Checked)
            {
                if (retornoEstoque() == 1 && registrarRetorno() == 1)
                {
                    MessageBox.Show("Livro devolvido e estoque atualizado.", "Sucesso");
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
                        MessageBox.Show("Empréstimo registrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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

        public void checagemDevolucao(int prontuario, string campo)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                if (campo == "Numero")
                {
                    comm.CommandText = "select codLivro, nomeLivro from tbEmprestimo where codEmp = @codEmp;";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@codEmp", MySqlDbType.Int32).Value = prontuario;
                }
                if (campo == "Locatario")
                {
                    comm.CommandText = "select codLivro, nomeLivro from tbEmprestimo where prontuario = @prontuario;";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@prontuario", MySqlDbType.Int32).Value = prontuario;
                }

                ltbCarrinho.Items.Clear();
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();

                while (DR.Read())
                {
                    ltbCarrinho.Items.Add(DR.GetString(1));
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao checar empréstimos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                MessageBox.Show("Erro ao escanear livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

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

            for (int i = 0; i < Livros.ListaLivros.Count - 1; i++)
            {
                if (Livros.ListaLivros[i].idLivro == Livros.ListaLivros[i + 1].idLivro)
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
                checagemDevolucao(Convert.ToInt32(txtNEmprestimo.Text), "Numero");
                ltbCarrinho.SetSelected(0, true);
                listaDeDevolucao();
            }
        }

        private void txtLocatario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checagemDevolucao(Convert.ToInt32(txtLocatario.Text), "Locatario");
                ltbCarrinho.SetSelected(0, true);
                listaDeDevolucao();
            }
        }

        public void listaDeDevolucao()
        {
            Livros livrosDev = new Livros();
            for (int i = 0; i < ltbCarrinho.Items.Count; i++)
            {
                livrosDev.nomeLivro = ltbCarrinho.Items[i].ToString();
                livrosDev.idLivro = livrosDev.pegarID(livrosDev.nomeLivro);

                Livros.ListaLivros.Add(livrosDev);
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
            pesquisarPorNome(ltbCarrinho.SelectedItem.ToString());
        }
    }
}

