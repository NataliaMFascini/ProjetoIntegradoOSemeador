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

            if (this.cargo == "Voluntário")
            {
                btnRemover.Enabled = false;
                btnAlterar.Enabled = false;
            }
        }
        public frmCadastroLocatario(string nome, int codUsu, string cargo, string locatario)
        {
            InitializeComponent();
            desabilitarCampos();
            habilitarCamposBusca();
            this.cargo = cargo;
            this.nome = nome;
            this.codUsu = codUsu;
            this.locatario = locatario;
            pesquisarPorNome(locatario);

            if (this.cargo == "Voluntário")
            {
                btnRemover.Enabled = false;
                btnAlterar.Enabled = false;
            }
        }
        public frmCadastroLocatario(string nome, int codUsu, string cargo, int prontuario)
        {
            InitializeComponent();
            desabilitarCampos();
            habilitarCamposBusca();
            this.cargo = cargo;
            this.nome = nome;
            this.codUsu = codUsu;
            this.prontuario = prontuario;
            pesquisarPorProntuario(prontuario);

            if (this.cargo == "Voluntário")
            {
                btnRemover.Enabled = false;
                btnAlterar.Enabled = false;
            }
        }

        public void pesquisarPorNome(string locatario)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbLocatario where  nome = @nome;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = locatario;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                txtProntuario.Text = DR.GetInt32(1).ToString();
                txtLocatario.Text = DR.GetString(2);
                mskCpf.Text = DR.GetString(3);
                mskTelefone.Text = DR.GetString(4);
                txtEmail.Text = DR.GetString(5);


                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Locatário não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pesquisarPorProntuario(int prontuario)
        {
            try
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

                txtProntuario.Text = DR.GetString(0).ToString();
                txtLocatario.Text = DR.GetString(1);
                mskCpf.Text = DR.GetString(2);
                txtEmail.Text = DR.GetString(3);
                mskTelefone.Text = DR.GetString(4);

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Locatário não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public void habilitarCamposBusca()
        {
            btnAlterar.Enabled = true;
            btnRemover.Enabled = true;
            btnNovo.Enabled = false;
            txtLocatario.Enabled = true;
            mskCpf.Enabled = true;
            txtEmail.Enabled = true;
            mskTelefone.Enabled = true;
            btnLimpar.Enabled = true;
            btnGerarPront.Enabled = false;
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
            btnGerarPront.Enabled = false;
        }

        private void erroCadastro(string nomeCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        private void erroCampo(string nomeCampo, string tipoCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo somente de " + tipoCampo + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        public bool checarPront()
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbLocatario where pront = @pront;";
                comm.CommandType = CommandType.Text;

                comm.Connection = Conexao.obterConexao();

                comm.Parameters.Clear();
                comm.Parameters.Add("@pront", MySqlDbType.LongBlob).Value = txtProntuario.Text;


                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();


                if (DR.HasRows)
                {
                    MessageBox.Show("Prontuário já cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProntuario.Focus();
                    Conexao.fecharConexao();
                    return false;
                }

                Conexao.fecharConexao();
                return true;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao verificar prontuário.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int tryParse;
            if (txtLocatario.Text.Equals(""))
            {
                if (int.TryParse(txtLocatario.Text, out tryParse))
                {
                    erroCampo("Locatário", "Texto");
                    txtLocatario.Clear();
                    txtLocatario.Focus();
                    return;
                }
                erroCadastro("Locatario");
                txtLocatario.Focus();
            }
            else if (mskCpf.Text.Equals("    .   .   -") || !mskCpf.MaskFull)
            {
                if (!int.TryParse(mskCpf.Text, out tryParse))
                {
                    erroCampo("CPF", "Número");
                    mskCpf.Clear();
                    mskCpf.Focus();
                    return;
                }
                erroCadastro("CPF");
                mskCpf.Focus();
            }
            else if (txtEmail.Text.Equals(""))
            {
                if (int.TryParse(txtEmail.Text, out tryParse))
                {
                    erroCampo("Email", "Texto");
                    txtEmail.Clear();
                    txtEmail.Focus();
                    return;
                }
                erroCadastro("Email");
                txtEmail.Focus();
            }
            else if (mskTelefone.Text.Equals("(  )     -") || !mskTelefone.MaskFull)
            {
                if (!int.TryParse(mskTelefone.Text, out tryParse))
                {
                    erroCampo("Telefone", "Número");
                    mskTelefone.Clear();
                    mskTelefone.Focus();
                    return;
                }
                erroCadastro("Telefone");
                mskTelefone.Focus();
            }
            else if (txtProntuario.Text.Equals(""))
            {
                erroCadastro("Prontuario");
                btnGerarPront.Focus();
            }
            else
            {
                if (cadastrarLocatario() == 1)
                {
                    MessageBox.Show("Cadastro realizado com sucesso.");
                    limparCampos();
                    desabilitarCampos();
                    txtLocatario.Focus();
                    btnNovo.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar locatário.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int cadastrarLocatario()
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();

                comm.CommandText = "insert into tbLocatario(pront, nome, cpf, telCel, email, dataCadastro) values (@pront, @nome, @cpf, @telCel, @email, @dataCadastro);";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@pront", MySqlDbType.Int64).Value = Convert.ToInt64(txtProntuario.Text);
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtLocatario.Text;
                comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 15).Value = mskCpf.Text;
                comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 15).Value = mskTelefone.Text;
                comm.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = txtEmail.Text;
                comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;

                comm.Connection = Conexao.obterConexao();
                int resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao cadastrar no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return 0;
            }
        }

        public int excluirLocatario(int pront)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "delete from tbLocatario where pront = @pront;";
                comm.CommandType = CommandType.Text;

                comm.Connection = Conexao.obterConexao();

                comm.Parameters.Clear();
                comm.Parameters.Add("@pront", MySqlDbType.Int32).Value = pront;

                int resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao excluir locatário.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return 0;
            }
        }

        private void btnGerarPront_Click(object sender, EventArgs e)
        {
            Random numAleatorio = new Random();

            long prontuario = numAleatorio.Next(100000000, 999999999);

            txtProntuario.Text = prontuario.ToString();

            if (!checarPront())
            {
                numAleatorio = new Random();

                prontuario = numAleatorio.Next(100000000, 999999999);

                txtProntuario.Text = prontuario.ToString();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            desabilitarCampos();
            btnNovo.Enabled = true;

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

            Random numAleatorio = new Random();

            long prontuario = numAleatorio.Next(100000000, 999999999);

            txtProntuario.Text = prontuario.ToString();
            if (!checarPront())
            {
                numAleatorio = new Random();

                prontuario = numAleatorio.Next(100000000, 999999999);

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
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "update tbLocatario set nome = @nome, cpf = @cpf, telCel = @telCel, email = @email where pront = @pront;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@pront", MySqlDbType.Int32).Value = Convert.ToInt32(txtProntuario.Text);
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtLocatario.Text;
                comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 15).Value = mskCpf.Text;
                comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 15).Value = mskTelefone.Text;
                comm.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = txtEmail.Text;


                comm.Connection = Conexao.obterConexao();

                int resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao alterar locatário.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return 0;
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int tryParse;
            if (txtLocatario.Text.Equals(""))
            {
                if (int.TryParse(txtLocatario.Text, out tryParse))
                {
                    erroCampo("Locatário", "Texto");
                    txtLocatario.Clear();
                    txtLocatario.Focus();
                    return;
                }
                erroCadastro("Locatario");
                txtLocatario.Focus();
            }
            else if (mskCpf.Text.Equals("    .   .   -") || !mskCpf.MaskFull)
            {
                if (!int.TryParse(mskCpf.Text, out tryParse))
                {
                    erroCampo("CPF", "Número");
                    mskCpf.Clear();
                    mskCpf.Focus();
                    return;
                }
                erroCadastro("CPF");
                mskCpf.Focus();
            }
            else if (txtEmail.Text.Equals(""))
            {
                if (int.TryParse(txtEmail.Text, out tryParse))
                {
                    erroCampo("Email", "Texto");
                    txtEmail.Clear();
                    txtEmail.Focus();
                    return;
                }
                erroCadastro("Email");
                txtEmail.Focus();
            }
            else if (mskTelefone.Text.Equals("(  )     -") || !mskTelefone.MaskFull)
            {
                if (!int.TryParse(mskTelefone.Text, out tryParse))
                {
                    erroCampo("Telefone", "Número");
                    mskTelefone.Clear();
                    mskTelefone.Focus();
                    return;
                }
                erroCadastro("Telefone");
                mskTelefone.Focus();
            }
            else
            {
                if (alterarLocatario(Convert.ToInt32(txtProntuario.Text)) == 1)
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
            frmBuscarLocatario abrir = new frmBuscarLocatario(this.nome, this.codUsu, this.cargo);
            abrir.Show();
            this.Hide();
        }

        private void txtLocatario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mskCpf.Focus();
            }
        }

        private void mskCpf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mskTelefone.Focus();
            }
        }

        private void mskTelefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCadastrar.Focus();
            }
        }


    }
}
