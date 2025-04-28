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
    //teste
    public partial class frmEmprestimo : Form
    {
        public int codLivro = 0;
        public int codLoc = 0;
        public int codUsu = 0;
        public int codEmp = 0;
        public string nome;
        public string cargo;

        Livros livros = new Livros();

        public frmEmprestimo()
        {
            InitializeComponent();
            DesavilitarCampos();
        }
        //public frmEmprestimo(string codEmp, int codEmprestimo) problema de amanha
        //{
        //    InitializeComponent();
        //    txtNEmprestimo.Text = codEmp;
        //    codEmp = codEmprestimo;
        //}
        public frmEmprestimo(string nome, int codUsu, string cargo)
        {
            InitializeComponent();
            DesavilitarCampos();

            this.nome = nome;
            this.codUsu = codUsu;
            this.cargo = cargo;
        }

        public void DesavilitarCampos()
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

        public void checarComponentes()
        {
            if (txtTitulo.Equals(""))
            {
                MessageBox.Show("Favor, Preencha todos os componentes", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitulo.Focus();                
            }
            if (txtAutor.Equals(""))
            {
                MessageBox.Show("Favor, Preencha todos os componentes", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutor.Focus();
            }
            if (txtEditora.Equals(""))
            {
                MessageBox.Show("Favor, Preencha todos os componentes", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEditora.Focus();
            }
            if (txtIsbn.Equals(""))
            {
                MessageBox.Show("Favor, Preencha todos os componentes", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIsbn.Focus();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            checarComponentes();
            ltbCarrinho.Items.Add(txtTitulo.Text);
            separarLivros();
            txtNEmprestimo.Focus();
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

        public int registrarEmprestimo(int codigoUsuario)
        {

            MySqlCommand comm = new MySqlCommand();
            int resp = 0;

            comm.CommandText = "insert into tbEmprestimo(codEmp, dataEmp, dataDev, codLivro, codLoc) values (@codEmp, @dataEmp, @dataDev, @codLivro, @codLoc );";
            comm.CommandType = CommandType.Text;


            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                comm.Parameters.Clear();

                comm.Parameters.Add("@codEmp", MySqlDbType.Int32).Value = codEmp;
                comm.Parameters.Add("@dataEmp", MySqlDbType.DateTime).Value = DateTime.Now;
                //comm.Parameters.Add("@dataDev", MySqlDbType.DateTime).Value = DateTime.; problema de amanha
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.codRetorno(i);
                comm.Parameters.Add("@codLoc", MySqlDbType.Int32).Value = codLoc;

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

            comm.CommandText = "update tbEstoque set saidaEmp = @saidaEmp where codLivro = @codLivro";
            comm.CommandType = CommandType.Text;
            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                comm.Parameters.Clear();
                comm.Parameters.Add("@saidaEmp", MySqlDbType.Int32).Value = (i);
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.codRetorno(i);

                comm.Connection = Conexao.obterConexao();

                resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();
            }

            return resp;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (ltbCarrinho.Items.Count != 0)

            {
                if (registrarEmprestimo(codUsu) == 1 && saidaEstoque() == 1)
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
            Livros livros = new Livros();

            livros.idLivro = Convert.ToInt32(txtIdLivro.Text);
            livros.nomeLivro = txtTitulo.Text;

            Livros.ListaLivros.Add(livros);
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
                //pctLivro.ImageLocation = DR.GetString(5);
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
                codLivro = Convert.ToInt32(txtIdLivro.Text);
            }
        }
    }
}
