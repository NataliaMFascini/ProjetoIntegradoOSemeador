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
using MosaicoSolutions.ViaCep;
using System.Windows.Forms.VisualStyles;

namespace LivrariaEBiblioteca
{
    public partial class frmCadastroUsuario : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;
        public int codPesquisa;

        public frmCadastroUsuario()
        {
            InitializeComponent();
            desabilitarCampos();
        }
        public frmCadastroUsuario(string nome, int codUsu, string cargo)
        {
            InitializeComponent();
            desabilitarCampos();
            this.nome = nome;
            this.cargo = cargo;
            this.codUsu = codUsu;
        }
        //retorno da pesquisa
        public frmCadastroUsuario(string nome, int codUsu, string cargo, int codPesquisa)
        {
            InitializeComponent();
            desabilitarCampos();
            this.nome = nome;
            this.cargo = cargo;
            this.codUsu = codUsu;
            this.codPesquisa = codPesquisa;
        }
        public void desabilitarCampos()
        {
            txtNomeCompleto.Enabled = false;
            txtEmail.Enabled = false;
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
            txtRepetirSenha.Enabled = false;
            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;
            txtComplemento.Enabled = false;
            txtCidade.Enabled = false;
            txtBairro.Enabled = false;
            mskCpf.Enabled = false;
            mskTelefone.Enabled = false;
            mskCep.Enabled = false;
            cbbCargo.Enabled = false;
            cbbDiaDeTrabalho.Enabled = false;
            cbbEstado.Enabled = false;

            btnLimpar.Enabled = false;
            btnCadastra.Enabled = false;
            btnAlterar.Enabled = false;
            btnRemover.Enabled = false;
            btnAdicionarFoto.Enabled = false;
        }
        public void habilitarCampos()
        {
            txtNomeCompleto.Enabled = true;
            txtEmail.Enabled = true;
            txtLogin.Enabled = true;
            txtSenha.Enabled = true;
            txtRepetirSenha.Enabled = true;
            txtLogradouro.Enabled = true;
            txtNumero.Enabled = true;
            txtComplemento.Enabled = true;
            txtCidade.Enabled = true;
            txtBairro.Enabled = true;
            mskCpf.Enabled = true;
            mskTelefone.Enabled = true;
            mskCep.Enabled = true;
            cbbCargo.Enabled = true;
            cbbDiaDeTrabalho.Enabled = true;
            cbbEstado.Enabled = true;

            btnLimpar.Enabled = true;
            btnCadastra.Enabled = true;
            btnAlterar.Enabled = false;
            btnRemover.Enabled = false;
            btnAdicionarFoto.Enabled = true;
        }
        public void limparCampos()
        {
            txtNomeCompleto.Clear();
            txtEmail.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            txtRepetirSenha.Clear();
            txtLogradouro.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
            mskCpf.Clear();
            mskTelefone.Clear();
            mskCep.Clear();
            cbbCargo.Text = "";
            cbbDiaDeTrabalho.Text = "";
            cbbEstado.Text = "";

            btnCadastra.Enabled = true;
            btnAlterar.Enabled = false;
            btnRemover.Enabled = false;
            btnAdicionarFoto.Enabled = true;
            ptbUsuario.Image = null;
        }

        private void erroCadastro(string nomeCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal(this.cargo, this.nome, this.codUsu);
            abrir.Show();
            this.Hide();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            if (txtNomeCompleto.Text.Equals(""))
            {
                erroCadastro("Nome Completo");
                txtNomeCompleto.Focus();
            }
            else if (mskCpf.Text.Equals("    .   .   -"))
            {
                erroCadastro("CPF");
                mskCpf.Focus();
            }
            else if (mskTelefone.Text.Equals("(  )      -"))
            {
                erroCadastro("Telefone");
                mskTelefone.Focus();
            }
            else if (cbbCargo.Text.Equals(""))
            {
                erroCadastro("Cargo");
                cbbCargo.Focus();
            }
            else if (txtEmail.Text.Equals(""))
            {
                erroCadastro("Email");
                txtEmail.Focus();
            }
            else if (cbbDiaDeTrabalho.Text.Equals(""))
            {
                erroCadastro("Dia de trabalho");
                cbbDiaDeTrabalho.Focus();
            }
            else if (txtLogin.Text.Equals(""))
            {
                erroCadastro("Login");
                txtLogin.Focus();
            }
            else if (txtSenha.Text.Equals(""))
            {
                erroCadastro("Senha");
                txtSenha.Focus();
            }
            else if (txtRepetirSenha.Text.Equals(""))
            {
                erroCadastro("Repetir senha");
                txtRepetirSenha.Focus();
            }
            else if (mskCep.Text.Equals("     -"))
            {
                erroCadastro("Cep");
                mskCep.Focus();
            }
            else if (txtLogradouro.Text.Equals(""))
            {
                erroCadastro("Lougradouro");
                txtLogradouro.Focus();
            }
            else if (txtNumero.Text.Equals(""))
            {
                erroCadastro("Numero");
                txtNumero.Focus();
            }
            else if (txtComplemento.Text.Equals(""))
            {
                erroCadastro("Complemento");
                txtComplemento.Focus();
            }
            else if (txtBairro.Text.Equals(""))
            {
                erroCadastro("Bairro");
                txtBairro.Focus();
            }
            else if (txtCidade.Text.Equals(""))
            {
                erroCadastro("Cidade");
                txtCidade.Focus();
            }
            else if (cbbEstado.Text.Equals(""))
            {
                erroCadastro("Estado");
                cbbEstado.Focus();
            }
            else
            {

                if (cadastrarUsuario() == 1)
                {
                    MessageBox.Show("Cadastro realizado com sucesso.");
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar livro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int cadastrarUsuario()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbUsuario(nome, cargo, cpf, diaTrabalho, telCel, login, senha, email, cep, logradouro, numero, complemento, bairro, cidade, estado, foto, dataCadastro) values (@nome, @cargo, @cpf, @diaTrabalho, @telCel, @login, @senha, @email, @cep, @logradouro, @numero, @complemento, @bairro, @cidade, @estado, @foto, @dataCadastro);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNomeCompleto.Text;
            comm.Parameters.Add("@cargo", MySqlDbType.VarChar, 50).Value = cbbCargo.SelectedItem;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCpf.Text;
            comm.Parameters.Add("@diaTrabalho", MySqlDbType.VarChar, 15).Value = cbbDiaDeTrabalho.SelectedItem;
            comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 14).Value = mskTelefone.Text;
            comm.Parameters.Add("@login", MySqlDbType.VarChar, 50).Value = txtLogin.Text;
            comm.Parameters.Add("@senha", MySqlDbType.VarChar, 20).Value = txtSenha.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = mskCep.Text;
            comm.Parameters.Add("@logradouro", MySqlDbType.VarChar, 100).Value = txtLogradouro.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 10).Value = txtNumero.Text;
            comm.Parameters.Add("@complemento", MySqlDbType.VarChar, 100).Value = txtComplemento.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = txtBairro.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = txtCidade.Text;
            comm.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = cbbEstado;
            comm.Parameters.Add("@foto", MySqlDbType.Blob).Value = ptbUsuario.Image;
            comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        public void buscaCEP(string cep)
        {
            var viaCEPService = ViaCepService.Default();

            try
            {
                var endereco = viaCEPService.ObterEndereco(cep);

                txtLogradouro.Text = endereco.Logradouro;
                txtComplemento.Text = endereco.Complemento;
                txtBairro.Text = endereco.Bairro;
                txtCidade.Text = endereco.Localidade;
                cbbEstado.Text = endereco.UF;
            }
            catch (Exception)
            {
                MessageBox.Show("CEP invalido. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskCep.Clear();
                mskCep.Focus();
            }
        }

        private void mskCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscaCEP(mskCep.Text);
                txtNumero.Focus();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            txtNomeCompleto.Focus();

        }

        private void btnAdicionarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto = new OpenFileDialog();
            foto.Title = "Selecione uma imagem";
            foto.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp|Todos os arquivos|*.*";
           
            if (foto.ShowDialog() == DialogResult.OK)
            {
                ptbUsuario.ImageLocation = foto.FileName;
                ptbUsuario.Load();

            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja remover esse usuário?", "Mensagem do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resultado == DialogResult.Yes)
            {
                excluirUsuario(Convert.ToInt32(codPesquisa));
                limparCampos();
            }
        }

        public int excluirUsuario(int codUsu)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            comm.Parameters.Clear();
            comm.Parameters.Add("@codUsu", MySqlDbType.Int32).Value = codUsu;

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }
        public int alterarUsuario(int codUsu)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update tbUsuario set nome = @nome, cargo = @cargo,cpf = @cpf, diaTrabalho = @diaTrabalho, telCel = @telCel, login = @login, senha = @senha email = @email, cep = @cep, logradouro = @logradouro, numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, estado = @estado, foto = @foto, dataCadastro = @dataCadastro";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNomeCompleto.Text;
            comm.Parameters.Add("@cargo", MySqlDbType.VarChar, 50).Value = cbbCargo.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCpf.Text;
            comm.Parameters.Add("@diaTrabalho", MySqlDbType.VarChar, 15).Value = cbbDiaDeTrabalho.Text;
            comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 10).Value = mskTelefone.Text;
            comm.Parameters.Add("@login", MySqlDbType.VarChar, 50).Value = txtLogin.Text;
            comm.Parameters.Add("@senha", MySqlDbType.VarChar, 20).Value = txtSenha.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = mskCep.Text;
            comm.Parameters.Add("@logradouro", MySqlDbType.VarChar, 100).Value = txtLogradouro.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 10).Value = txtNumero.Text;
            comm.Parameters.Add("@complemento", MySqlDbType.VarChar, 100).Value = txtComplemento.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = txtBairro.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = txtCidade.Text;
            comm.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = cbbEstado.Text;
            comm.Parameters.Add("@foto", MySqlDbType.Blob, 255).Value = ptbUsuario.Image;
            comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            btnNovo.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarFuncionario abrir = new frmBuscarFuncionario(this.nome, this.codUsu, this.cargo, "Usuario");
            abrir.Show();
            this.Hide();
        }

        private void txtRepetirSenha_TextChanged(object sender, EventArgs e)
        {
            if(txtSenha.Text != txtRepetirSenha.Text)
            {
                pnlBordaRepetir.BackColor = Color.Red;
            }
            else
            {
                pnlBordaRepetir.BackColor = Color.WhiteSmoke;
            }
        }
    }
}
