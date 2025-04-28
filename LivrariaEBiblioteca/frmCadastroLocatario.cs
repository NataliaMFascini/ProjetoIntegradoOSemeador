using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LivrariaEBiblioteca
{
    public partial class frmCadastroLocatario : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;
        public string locatario;
        public int prontuario;
        public frmCadastroLocatario()
        {
            InitializeComponent();
            desabilitarCampos();
        }
        public frmCadastroLocatario(string nome, int codUsu, string cargo)
        {
            InitializeComponent();
            desabilitarCampos();
            this.cargo = cargo;
            this.nome = nome;
            this.codUsu = codUsu;
        }
        public frmCadastroLocatario(string nome, int codUsu, string cargo, string locatario)
        {
            InitializeComponent();
            desabilitarCampos();
            this.cargo = cargo;
            this.nome = nome;
            this.codUsu = codUsu;
            this.locatario = locatario;
            pesquisarPorNome(locatario);
        }
        public frmCadastroLocatario(string nome, int codUsu, string cargo, int prontuario)
        {
            InitializeComponent();
            desabilitarCampos();
            this.cargo = cargo;
            this.nome = nome;
            this.codUsu= codUsu;
            this.prontuario = prontuario;
            pesquisarPorProntuario(prontuario); 
        }

        public void pesquisarPorNome(string locatario)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbLocatario where  nome = @nome;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar,100).Value = nome;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            txtProntuario.Text = DR.GetString(0).ToString();
            txtLocatario.Text = DR.GetString(1);
            mskCpf.Text = DR.GetString(2);
            txtEmail.Text = DR.GetString(3);
            mskTelefone.Text = DR.GetString(4);

            Conexao.fecharConexao();

        }

        public void pesquisarPorProntuario(int prontuario)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbLocatario where pront = @pront;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@pront", MySqlDbType.Int32).Value = prontuario;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            txtProntuario.Text= DR.GetString(0).ToString();
            txtLocatario.Text= DR.GetString(1);
            mskCpf.Text= DR.GetString(2);
            txtEmail.Text= DR.GetString(3);
            mskTelefone.Text= DR.GetString(4);

            Conexao.fecharConexao();
            
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal(this.cargo, this.nome, this.codUsu);
            abrir.Show();
            this.Hide();
        }

        public void limparCampos()
        {
            txtLocatario.Clear();
            txtEmail.Clear();
            mskCpf.Clear();
            mskTelefone.Clear();
            txtProntuario.Clear();
            ltbListadelivros.Items.Clear();

        }

        public void desabilitarCampos()
        {
            btnAlterar.Enabled = false;
            btnRemover.Enabled = false;
            btnCadastrar.Enabled = false;
            btnLimpar.Enabled = false;
            txtEmail.Enabled = false;
            txtLocatario.Enabled = false;
            mskCpf.Enabled = false;
            mskTelefone.Enabled = false;
            ltbListadelivros.Enabled = false;

        }

        private void erroCadastro(string nomeCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        public bool checarPront()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbLocatario where pront = @pront;";
            comm.CommandType = CommandType.Text;

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            if (DR.HasRows)
            {
                MessageBox.Show("Prontuário já cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProntuario.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtLocatario.Text.Equals(""))
            {
                erroCadastro("Locatario");
                txtLocatario.Focus();
            }
            else if (mskCpf.Text.Equals("    .   .   -"))
            {
                erroCadastro("CPF");
                mskCpf.Focus();
            }
            else if (txtEmail.Text.Equals(""))
            {
                erroCadastro("Email");
                txtEmail.Focus();
            }
            else if (mskTelefone.Text.Equals("(  )     -"))
            {
                erroCadastro("Telefone");
                mskTelefone.Focus();
            }
            else
            {

                if (cadastrarLocatario() == 1)
                {
                    MessageBox.Show("Cadastro realizado com sucesso.");
                    limparCampos();
                    txtLocatario.Focus();
                }

                else
                {
                    MessageBox.Show("Erro ao cadastrar locatário.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private int cadastrarLocatario()
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "insert into tbLocatario(pront, nome, cpf, telCel, email, dataCadastro) values (@pront, @nome, @cpf, @telCel, @email, @dataCadastro);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@pront", MySqlDbType.Int64).Value = Convert.ToInt64(txtProntuario.Text);
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtLocatario.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCpf.Text;
            comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 14).Value = mskTelefone.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = txtEmail.Text;
            comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;

            comm.Connection = Conexao.obterConexao();
            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        public int excluirLocatario(int codLoc)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "delete from tbLocatario where codLoc = @codLoc;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            comm.Parameters.Clear();
            comm.Parameters.Add("@codLoc", MySqlDbType.Int32).Value = codLoc;

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;

        }

        private void btnGerarPront_Click(object sender, EventArgs e)
        {
            if (!checarPront())
            {
                Random numAleatorio = new Random();

                long prontuario = numAleatorio.Next(100000000, 999999999);

                txtProntuario.Text = prontuario.ToString();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnCadastrar.Enabled = true;
            btnLimpar.Enabled = true;
            txtEmail.Enabled = true;
            txtLocatario.Enabled = true;
            mskCpf.Enabled = true;
            mskTelefone.Enabled = true;
            ltbListadelivros.Enabled = true;
            btnNovo.Enabled = false;
            if (!checarPront())
            {
                Random numAleatorio = new Random();

                long prontuario = numAleatorio.Next(100000000, 999999999);

                txtProntuario.Text = prontuario.ToString();
            }

            txtLocatario.Focus();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja remover esse locatário?", "Mensagem do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resultado == DialogResult.Yes)
            {
                excluirLocatario(Convert.ToInt32(txtProntuario.Text));
                limparCampos();
            }
        }

        public int alterarLocatario(int codLoc)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update tbLocatario set nome = @nome, cpf = @cpf, telCel = @telCel, email = @email;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@pront", MySqlDbType.Int64).Value = Convert.ToInt64(txtProntuario.Text);
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtLocatario.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCpf.Text;
            comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 14).Value = mskTelefone.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = txtEmail.Text;
            

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtLocatario.Text.Equals(""))
            {
                erroCadastro("Locatario");
                txtLocatario.Focus();
            }
            else if (mskCpf.Text.Equals("    .   .   -"))
            {
                erroCadastro("CPF");
                mskCpf.Focus();
            }
            else if (txtEmail.Text.Equals(""))
            {
                erroCadastro("Email");
                txtEmail.Focus();
            }
            else if (mskTelefone.Text.Equals("(  )     -"))
            {
                erroCadastro("Telefone");
                mskTelefone.Focus();
            }
            else
            {

                if (alterarLocatario(Convert.ToInt32(txtLocatario.Text)) == 1)
                {
                    MessageBox.Show("Alteração realizado com sucesso.");
                    limparCampos();
                    desabilitarCampos();
                    btnNovo.Enabled = true;
                    btnNovo.Focus();
                }

                else
                {
                    MessageBox.Show("Erro ao alterar locatário.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarLocatario abrir = new frmBuscarLocatario;
            abrir.Show();
            This.Hide();
        }
    }
}
