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

        Livros livros = new Livros();

        public frmEmprestimo()
        {
            InitializeComponent();
            DesavilitarCampos();
        }

        public void DesavilitarCampos() 
        {
            txtIdLivro.Enabled = false;
            txtNEmprestimo.Enabled = false;
        }

        public void limparComponentes()
        {
            txtAutor.Text = string.Empty;
            txtEditora.Text = string.Empty;
            txtIdLivro.Text = string.Empty;
            txtIsbn.Text = string.Empty;
            txtTitulo.Text = string.Empty;
            txtLocatario.Text = string.Empty;
            txtNEmprestimo.Text = string.Empty;
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
            if (txtLocatario.Equals(""))
            {
                MessageBox.Show("Favor, Preencha todos os componentes", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocatario.Focus();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            ltbCarrinho.Items.Add(txtTitulo.Text);
            txtNEmprestimo.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparComponentes();
            txtIsbn.Focus();
           
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            frmVender abrir = new frmVender();
            abrir.Show();
            this.Hide();
        }

        public int registrarEmprestimo(int codigoUsuario)
        {

            MySqlCommand comm = new MySqlCommand();
            int resp = 0;

            comm.CommandText = "insert into tbEmprestimo(dataVenda, nomeLivro, valorTotal, pagamento, codUsu, codLivro) values (@dataVenda, @nomeLivro, @valorTotal, @pagamento, @codUsu, @codLivro);";
            comm.CommandType = CommandType.Text;


            for (int i = 0; i < Livros.ListaLivros.Count; i++)
            {
                comm.Parameters.Clear();

                comm.Parameters.Add("@dataEmprestimo", MySqlDbType.DateTime).Value = DateTime.Now;
                comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = livros.nomeRetorno(i);
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.codRetorno(i);
                comm.Parameters.Add("@codLoc", MySqlDbType.Int32).Value = codLoc;

                comm.Connection = Conexao.obterConexao();

                resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();
            }

            return resp;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            checarComponentes();

            if (ltbCarrinho.Items.Count == 0)
            {
                if (registrarEmprestimo(codLoc) == 1)
                {
                    MessageBox.Show("Empréstimo registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    limparComponentes();
                }
                else
                {
                    MessageBox.Show("Erro ao registrar empréstimo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
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
            }
        }
    }
}
