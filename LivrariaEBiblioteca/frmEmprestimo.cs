using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                },

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
                comm.Parameters.Add("@saidaEmp", MySqlDbType.Int32).Value = quantidadeRetorno(i);
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

            comm.CommandText = "UPDATE tbEstoque SET quantidadeAtual = quantidadeAtual + @quantidade WHERE codLivro = @codLivro";
            comm.CommandType = CommandType.Text;

            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                comm.Parameters.Clear();
                comm.Parameters.Add("@quantidade", MySqlDbType.Int32).Value = quantidadeRetorno(i);
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


        private void btnFinalizar_Click(object sender, EventArgs e)
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
             
            public void escanearLivro(string isbn)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select codLivro, nome, autor, editora, foto from tbLivro where isbn = @isbn;";
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

            Conexao.fecharConexao();

        }

        private void txtIsbn_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                escanearLivro(txtIsbn.Text);
                //codLivro = Convert.ToInt32(txtIdLivro.Text);
                mskDataDevolucao.Focus();
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

        private void btnDevolver_Click(object sender, EventArgs e)
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

        private void mskDataDevolucao_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            DateTime dataEmprestimo = mskDataDevolucao.Value;
            DateTime dataDevolucao = dataEmprestimo.AddDays(20);

            mskDataDevolucao.Value = dataDevolucao;
        }
    }
}

