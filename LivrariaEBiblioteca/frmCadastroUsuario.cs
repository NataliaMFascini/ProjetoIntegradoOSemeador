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
using System.IO;

namespace LivrariaEBiblioteca
{
    public partial class frmCadastroUsuario : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;
        public string descricao;
        public string fotoPath;
        public int codUsuBusca;

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

            if (this.cargo == "Voluntário")
            {
                cbbCargo.Items.Clear();
                cbbCargo.Items.AddRange(new object[]
                {
                    "Voluntário"
                });
            }
            else if (this.cargo == "Dirigente")
            {
                cbbCargo.Items.Clear();
                cbbCargo.Items.AddRange(new object[]
                {
                    "Voluntário",
                    "Dirigente"
                });
            }
        }
        //retorno da pesquisa
        public frmCadastroUsuario(string nome, int codUsu, string cargo, string descricao)
        {
            InitializeComponent();
            desabilitarCampos();
            habilitarCamposBusca();
            this.nome = nome;
            this.cargo = cargo;
            this.codUsu = codUsu;

            txtLogin.Enabled = false;

            pesquisarPorNome(descricao);
            if (this.cargo == "Voluntário")
            {
                cbbCargo.Items.Clear();
                cbbCargo.Items.AddRange(new object[]
                {
                    "Voluntário"
                });
                btnAlterar.Enabled = false;
                btnRemover.Enabled = false;
            }
            else if (this.cargo == "Dirigente")
            {
                cbbCargo.Items.Clear();
                cbbCargo.Items.AddRange(new object[]
                {
                    "Voluntário",
                    "Dirigente"
                });
            }
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

        public void habilitarCamposBusca()
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
            btnCadastra.Enabled = false;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = true;
            btnRemover.Enabled = true;
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
        private void erroCampo(string nomeCampo, string tipoCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo somente de " + tipoCampo + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal(this.cargo, this.nome, this.codUsu);
            abrir.Show();
            this.Hide();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            int tryParse;
            if (txtNomeCompleto.Text.Equals(""))
            {
                if (int.TryParse(txtNomeCompleto.Text, out tryParse))
                {
                    erroCampo("Nome Completo", "Texto");
                    txtNomeCompleto.Clear();
                    txtNomeCompleto.Focus();
                    return;
                }
                erroCadastro("Nome Completo");
                txtNomeCompleto.Focus();
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
            else if (mskTelefone.Text.Equals("(  )      -") || !mskTelefone.MaskFull)
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
            else if (cbbCargo.Text.Equals(""))
            {
                if (int.TryParse(cbbCargo.Text, out tryParse))
                {
                    erroCampo("Cargo", "Texto");
                    cbbCargo.Text = "";
                    cbbCargo.Focus();
                    return;
                }
                erroCadastro("Cargo");
                cbbCargo.Focus();
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
            else if (cbbDiaDeTrabalho.Text.Equals(""))
            {
                if (int.TryParse(cbbDiaDeTrabalho.Text, out tryParse))
                {
                    erroCampo("Dia de trabalho", "Texto");
                    cbbCargo.Text = "";
                    cbbCargo.Focus();
                    return;
                }
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
            else if (mskCep.Text.Equals("     -") || !mskCep.MaskFull)
            {
                if (!int.TryParse(mskCep.Text, out tryParse))
                {
                    erroCampo("Cep", "Número");
                    mskCep.Clear();
                    mskCep.Focus();
                    return;
                }
                erroCadastro("Cep");
                mskCep.Focus();
            }
            else if (txtLogradouro.Text.Equals(""))
            {
                if (int.TryParse(txtLogradouro.Text, out tryParse))
                {
                    erroCampo("Logradouro", "Texto");
                    txtLogradouro.Clear();
                    txtLogradouro.Focus();
                    return;
                }
                erroCadastro("Lougradouro");
                txtLogradouro.Focus();
            }
            else if (txtNumero.Text.Equals(""))
            {
                if (!int.TryParse(txtNumero.Text, out tryParse))
                {
                    erroCampo("Numero", "Número");
                    txtNumero.Clear();
                    txtNumero.Focus();
                    return;
                }
                erroCadastro("Numero");
                txtNumero.Focus();
            }
            else if (txtComplemento.Text.Equals(""))
            {
                if (int.TryParse(txtComplemento.Text, out tryParse))
                {
                    erroCampo("Complemento", "Texto");
                    txtComplemento.Clear();
                    txtComplemento.Focus();
                    return;
                }
                erroCadastro("Complemento");
                txtComplemento.Focus();
            }
            else if (txtBairro.Text.Equals(""))
            {
                if (int.TryParse(txtBairro.Text, out tryParse))
                {
                    erroCampo("Bairro", "Texto");
                    txtBairro.Clear();
                    txtBairro.Focus();
                    return;
                }
                erroCadastro("Bairro");
                txtBairro.Focus();
            }
            else if (txtCidade.Text.Equals(""))
            {
                if (int.TryParse(txtCidade.Text, out tryParse))
                {
                    erroCampo("Cidade", "Texto");
                    txtCidade.Clear();
                    txtCidade.Focus();
                    return;
                }
                erroCadastro("Cidade");
                txtCidade.Focus();
            }
            else if (cbbEstado.Text.Equals(""))
            {
                if (int.TryParse(cbbEstado.Text, out tryParse))
                {
                    erroCampo("Estado", "Texto");
                    cbbEstado.Text = "";
                    cbbEstado.Focus();
                    return;
                }
                erroCadastro("Estado");
                cbbEstado.Focus();
            }
            else
            {
                if (this.cargo == "Voluntário" && cbbCargo.Text == "Dirigente" || cbbCargo.Text == "Diretor")
                {
                    MessageBox.Show("Você não tem permissão para realizar esse cadastro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.cargo == "Dirigente" && cbbCargo.Text == "Diretor")
                {
                    MessageBox.Show("Você não tem permissão para realizar esse cadastro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cadastrarUsuario() == 1)
                {
                    MessageBox.Show("Cadastro realizado com sucesso.");
                    limparCampos();
                    btnNovo.Enabled = true;
                    btnCadastra.Enabled = false;
                    btnLimpar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar usuário.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int cadastrarUsuario()
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "insert into tbUsuario(nome, cargo, cpf, diaTrabalho, telCel, login, senha, email, cep, logradouro, numero, complemento, bairro, cidade, estado, foto, dataCadastro) values (@nome, @cargo, @cpf, @diaTrabalho, @telCel, @login, @senha, @email, @cep, @logradouro, @numero, @complemento, @bairro, @cidade, @estado, @foto, @dataCadastro);";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNomeCompleto.Text;
                comm.Parameters.Add("@cargo", MySqlDbType.VarChar, 50).Value = cbbCargo.SelectedItem;
                comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 15).Value = mskCpf.Text;
                comm.Parameters.Add("@diaTrabalho", MySqlDbType.VarChar, 15).Value = cbbDiaDeTrabalho.SelectedItem;
                comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 15).Value = mskTelefone.Text;
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
                if (ptbUsuario.Image == null)
                {
                    fotoPath = "";
                }
                else
                {
                    fotoPath = ptbUsuario.ImageLocation;
                }
                comm.Parameters.Add("@foto", MySqlDbType.VarChar, 200).Value = fotoPath;
                comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;

                comm.Connection = Conexao.obterConexao();

                int resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao cadastrar usuário. Tente novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public bool checarMudancaCpf(string nomeSelecionado)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select cpf from tbUsuario where nome = @nome;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nomeSelecionado;

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR = comm.ExecuteReader();
                DR.Read();

                Conexao.fecharConexao();
                if (mskCpf.Text == DR.GetString(0))
                {
                    return false;
                }

                return true;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao confirmar CPF.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
                txtNumero.Focus();
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

            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnNovo.Enabled = false;
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
                fotoPath = foto.FileName;
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (this.cargo == "Voluntário")
            {
                MessageBox.Show("Você não tem permissão para deletar esse usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Deseja remover esse usuário?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (resultado == DialogResult.Yes)
                {
                    excluirUsuario(codUsuBusca);
                    MessageBox.Show("Usuário removido com sucesso.", "Mensagem do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limparCampos();
                }
            }
        }

        public int excluirUsuario(int codUsuSelecionado)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "delete from tbLivro where codUsu = @codUsu;";
                comm.CommandType = CommandType.Text;

                comm.Connection = Conexao.obterConexao();

                comm.Parameters.Clear();
                comm.Parameters.Add("@codUsu", MySqlDbType.Int32).Value = codUsuSelecionado;

                int resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao excluir usuário. Tente novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int alterarUsuario(int codUsuSelecionado)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();

                if (checarMudancaCpf(txtNomeCompleto.Text))
                {
                    comm.CommandText = "update tbUsuario set nome = @nome, cargo = @cargo, cpf = @cpf, diaTrabalho = @diaTrabalho, telCel = @telCel, senha = @senha, email = @email, cep = @cep, logradouro = @logradouro, numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, estado = @estado, foto = @foto, dataCadastro = @dataCadastro where codUsu = @codUsu";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNomeCompleto.Text;
                    comm.Parameters.Add("@cargo", MySqlDbType.VarChar, 50).Value = cbbCargo.Text;
                    comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 15).Value = mskCpf.Text;
                    comm.Parameters.Add("@diaTrabalho", MySqlDbType.VarChar, 15).Value = cbbDiaDeTrabalho.Text;
                    comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 15).Value = mskTelefone.Text;
                    comm.Parameters.Add("@senha", MySqlDbType.VarChar, 20).Value = txtSenha.Text;
                    comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
                    comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = mskCep.Text;
                    comm.Parameters.Add("@logradouro", MySqlDbType.VarChar, 100).Value = txtLogradouro.Text;
                    comm.Parameters.Add("@numero", MySqlDbType.VarChar, 10).Value = txtNumero.Text;
                    comm.Parameters.Add("@complemento", MySqlDbType.VarChar, 100).Value = txtComplemento.Text;
                    comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = txtBairro.Text;
                    comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = txtCidade.Text;
                    comm.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = cbbEstado.Text;
                    if (ptbUsuario.Image == null)
                    {
                        fotoPath = "";
                    }
                    else
                    {
                        fotoPath = ptbUsuario.ImageLocation;
                    }
                    comm.Parameters.Add("@foto", MySqlDbType.VarChar, 200).Value = fotoPath;
                    comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;
                    comm.Parameters.Add("@codUsu", MySqlDbType.Int32).Value = codUsuSelecionado;
                }
                else
                {
                    comm.CommandText = "update tbUsuario set nome = @nome, cargo = @cargo, diaTrabalho = @diaTrabalho, telCel = @telCel, senha = @senha, email = @email, cep = @cep, logradouro = @logradouro, numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, estado = @estado, foto = @foto, dataCadastro = @dataCadastro where codUsu = @codUsu";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNomeCompleto.Text;
                    comm.Parameters.Add("@cargo", MySqlDbType.VarChar, 50).Value = cbbCargo.Text;
                    comm.Parameters.Add("@diaTrabalho", MySqlDbType.VarChar, 15).Value = cbbDiaDeTrabalho.Text;
                    comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 15).Value = mskTelefone.Text;
                    comm.Parameters.Add("@senha", MySqlDbType.VarChar, 20).Value = txtSenha.Text;
                    comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
                    comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = mskCep.Text;
                    comm.Parameters.Add("@logradouro", MySqlDbType.VarChar, 100).Value = txtLogradouro.Text;
                    comm.Parameters.Add("@numero", MySqlDbType.VarChar, 10).Value = txtNumero.Text;
                    comm.Parameters.Add("@complemento", MySqlDbType.VarChar, 100).Value = txtComplemento.Text;
                    comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = txtBairro.Text;
                    comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = txtCidade.Text;
                    comm.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = cbbEstado.Text;
                    if (ptbUsuario.Image == null)
                    {
                        fotoPath = "";
                    }
                    comm.Parameters.Add("@foto", MySqlDbType.VarChar, 200).Value = fotoPath;
                    comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;
                    comm.Parameters.Add("@codUsu", MySqlDbType.Int32).Value = codUsuSelecionado;
                }

                comm.Connection = Conexao.obterConexao();

                int resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao alterar usuário. Tente novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            desabilitarCampos();

            btnNovo.Enabled = true;
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
            if (txtSenha.Text != txtRepetirSenha.Text)
            {
                pnlBordaRepetir.BackColor = Color.Red;
            }
            else
            {
                pnlBordaRepetir.BackColor = Color.CadetBlue;
            }
        }

        public void pesquisarPorNome(string nome)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbUsuario where nome = @nome;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                codUsuBusca = DR.GetInt32(0);
                txtNomeCompleto.Text = DR.GetString(1);
                cbbCargo.Text = DR.GetString(2);
                mskCpf.Text = DR.GetString(3);
                cbbDiaDeTrabalho.Text = DR.GetString(4);
                mskTelefone.Text = DR.GetString(5);
                txtLogin.Text = DR.GetString(6);
                txtSenha.Text = DR.GetString(7);
                txtEmail.Text = DR.GetString(8);
                mskCep.Text = DR.GetString(9);
                txtLogradouro.Text = DR.GetString(10);
                txtNumero.Text = DR.GetString(11);
                txtComplemento.Text = DR.GetString(12);
                txtBairro.Text = DR.GetString(13);
                txtCidade.Text = DR.GetString(14);
                cbbEstado.Text = DR.GetString(15);
                if (fotoPath != null)
                {
                    fotoPath = DR.GetString(16);
                    ptbUsuario.ImageLocation = fotoPath;
                    ptbUsuario.Load();
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao buscar usuário. Tente novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int tryParse;
            if (txtNomeCompleto.Text.Equals(""))
            {
                if (int.TryParse(txtNomeCompleto.Text, out tryParse))
                {
                    erroCampo("Nome Completo", "Texto");
                    txtNomeCompleto.Clear();
                    txtNomeCompleto.Focus();
                    return;
                }
                erroCadastro("Nome Completo");
                txtNomeCompleto.Focus();
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
            else if (mskTelefone.Text.Equals("(  )      -") || !mskTelefone.MaskFull)
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
            else if (cbbCargo.Text.Equals(""))
            {
                if (int.TryParse(cbbCargo.Text, out tryParse))
                {
                    erroCampo("Cargo", "Texto");
                    cbbCargo.Text = "";
                    cbbCargo.Focus();
                    return;
                }
                erroCadastro("Cargo");
                cbbCargo.Focus();
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
            else if (cbbDiaDeTrabalho.Text.Equals(""))
            {
                if (int.TryParse(cbbDiaDeTrabalho.Text, out tryParse))
                {
                    erroCampo("Dia de trabalho", "Texto");
                    cbbCargo.Text = "";
                    cbbCargo.Focus();
                    return;
                }
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
            else if (mskCep.Text.Equals("     -") || !mskCep.MaskFull)
            {
                if (!int.TryParse(mskCep.Text, out tryParse))
                {
                    erroCampo("Cep", "Número");
                    mskCep.Clear();
                    mskCep.Focus();
                    return;
                }
                erroCadastro("Cep");
                mskCep.Focus();
            }
            else if (txtLogradouro.Text.Equals(""))
            {
                if (int.TryParse(txtLogradouro.Text, out tryParse))
                {
                    erroCampo("Logradouro", "Texto");
                    txtLogradouro.Clear();
                    txtLogradouro.Focus();
                    return;
                }
                erroCadastro("Lougradouro");
                txtLogradouro.Focus();
            }
            else if (txtNumero.Text.Equals(""))
            {
                if (!int.TryParse(txtNumero.Text, out tryParse))
                {
                    erroCampo("Numero", "Número");
                    txtNumero.Clear();
                    txtNumero.Focus();
                    return;
                }
                erroCadastro("Numero");
                txtNumero.Focus();
            }
            else if (txtComplemento.Text.Equals(""))
            {
                if (int.TryParse(txtComplemento.Text, out tryParse))
                {
                    erroCampo("Complemento", "Texto");
                    txtComplemento.Clear();
                    txtComplemento.Focus();
                    return;
                }
                erroCadastro("Complemento");
                txtComplemento.Focus();
            }
            else if (txtBairro.Text.Equals(""))
            {
                if (int.TryParse(txtBairro.Text, out tryParse))
                {
                    erroCampo("Bairro", "Texto");
                    txtBairro.Clear();
                    txtBairro.Focus();
                    return;
                }
                erroCadastro("Bairro");
                txtBairro.Focus();
            }
            else if (txtCidade.Text.Equals(""))
            {
                if (int.TryParse(txtCidade.Text, out tryParse))
                {
                    erroCampo("Cidade", "Texto");
                    txtCidade.Clear();
                    txtCidade.Focus();
                    return;
                }
                erroCadastro("Cidade");
                txtCidade.Focus();
            }
            else if (cbbEstado.Text.Equals(""))
            {
                if (int.TryParse(cbbEstado.Text, out tryParse))
                {
                    erroCampo("Estado", "Texto");
                    cbbEstado.Text = "";
                    cbbEstado.Focus();
                    return;
                }
                erroCadastro("Estado");
                cbbEstado.Focus();
            }
            else
            {
                if (this.cargo == "Voluntário" && cbbCargo.Text == "Dirigente" || cbbCargo.Text == "Diretor")
                {
                    MessageBox.Show("Você não tem permissão para realizar essa alteração.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.cargo == "Dirigente" && cbbCargo.Text == "Diretor")
                {
                    MessageBox.Show("Você não tem permissão para realizar essa alteração.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (alterarUsuario(codUsuBusca) == 1)
                {
                    MessageBox.Show("Cadastro alterado com sucesso.");
                }
                else
                {
                    MessageBox.Show("Erro ao alterar usuário.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtNomeCompleto_KeyDown(object sender, KeyEventArgs e)
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
                mskTelefone.Focus();
            }
        }

        private void mskTelefone_KeyDown(object sender, KeyEventArgs e)
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
                cbbCargo.Focus();
            }
        }

        private void cbbCargo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLogin.Focus();
            }
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRepetirSenha.Focus();
            }
        }

        private void txtRepetirSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbbDiaDeTrabalho.Focus();
            }
        }

        private void cbbDiaDeTrabalho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mskCep.Focus();
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtComplemento.Focus();
            }
        }

        private void txtComplemento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdicionarFoto.Focus();
            }
        }
    }
}
