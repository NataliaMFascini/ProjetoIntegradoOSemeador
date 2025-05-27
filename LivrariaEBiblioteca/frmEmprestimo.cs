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
        public int codUsu;
        public string nome;
        public string cargo;

        public int codLivro;
        public string fotoPath;

        Livros livros = new Livros();

        public int estoqueInicial = 0;

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
        }

        public frmEmprestimo(string nome, int codUsu, string cargo, string livro, int estoquePesquisa)
        {
            InitializeComponent();
            DesabilitarCampos();

            this.nome = nome;
            this.codUsu = codUsu;
            this.cargo = cargo;

            pesquisarPorNome(livro);

            estoqueInicial = estoquePesquisa;
        }

        public void DesabilitarCampos()
        {
            txtIsbn.Enabled = false;
            txtNomeLoc.Enabled = false;
        }

        public void limparCampos()
        {
            txtAutor.Clear();
            txtEditora.Clear();
            txtIdLivro.Clear();
            txtIsbn.Clear();
            txtTitulo.Clear();
            txtProntuario.Clear();
            txtNomeLoc.Clear();
            pctLivro.Image = null;

            Livros.ListaLivros.Clear();
            ltbCarrinho.Items.Clear();

            estoqueInicial = 0;
        }

        public bool checarComponentesLoc()
        {
            if (txtProntuario.Text.Equals(""))
            {
                erroCadastro("Prontuário");
                txtProntuario.Focus();
                return false;
            }
            else if (txtNomeLoc.Text.Equals(""))
            {
                erroCadastro("Nome");
                txtNomeLoc.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checarComponentesLivro()
        {
            if (txtTitulo.Text.Equals(""))
            {
                erroCadastro("Título");
                txtTitulo.Focus();
                return false;
            }
            else if (txtAutor.Text.Equals(""))
            {
                erroCadastro("Autor");
                txtAutor.Focus();
                return false;
            }
            else if (txtEditora.Text.Equals(""))
            {
                erroCadastro("Editora");
                txtEditora.Focus();
                return false;
            }
            else if (txtIsbn.Text.Equals(""))
            {
                erroCadastro("ISBN");
                txtIsbn.Focus();
                return false;
            }
            else
            {
                return true;
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

        public bool checarCaractereLivro()
        {
            int tryParse;
            if (int.TryParse(txtTitulo.Text, out tryParse))
            {
                erroCampo("Título", "alfabético");
                txtTitulo.Clear();
                txtTitulo.Focus();
                return false;
            }
            else if (int.TryParse(txtAutor.Text, out tryParse))
            {
                erroCampo("Autor", "alfabético");
                txtAutor.Clear();
                txtAutor.Focus();
                return false;
            }
            else if (int.TryParse(txtEditora.Text, out tryParse))
            {
                erroCampo("Editora", "alfabético");
                txtEditora.Clear();
                txtEditora.Focus();
                return false;
            }
            else if (!int.TryParse(txtProntuario.Text, out tryParse))
            {
                erroCampo("Prontuário", "numérico");
                txtProntuario.Clear();
                txtProntuario.Focus();
                return false;
            }
            else if (int.TryParse(txtNomeLoc.Text, out tryParse))
            {
                erroCampo("Nome", "alfabético");
                txtNomeLoc.Clear();
                txtNomeLoc.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool checarCaractereLoc()
        {
            int tryParse;
            if (!int.TryParse(txtProntuario.Text, out tryParse))
            {
                erroCampo("Prontuário", "numérico");
                txtProntuario.Clear();
                txtProntuario.Focus();
                return false;
            }
            else if (int.TryParse(txtNomeLoc.Text, out tryParse))
            {
                erroCampo("Nome", "alfabético");
                txtNomeLoc.Clear();
                txtNomeLoc.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (checarComponentesLivro() && checarCaractereLivro())
            {
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
                ltbCarrinho.Items.Add(txtTitulo.Text + " - " + txtAutor.Text);
                estoqueInicial--;
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

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (checarCaractereLoc() && checarComponentesLoc())
            {
                if (ltbCarrinho.Items.Count != 0)
                {
                    if (registrarEmprestimo() == 1 && saidaEstoque() == 1)
                    {
                        MessageBox.Show("Empréstimo registrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        confirmarEstoque();
                        limparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao registrar o Empréstimo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }
                }
                else
                {
                    MessageBox.Show("Carrinho vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public int registrarEmprestimo()
        {
            try
            {
                int resp = 0;
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "insert into tbEmprestimo(dataEmp, nomeLivro, prontuario, nomeLocatario, nomeVendedor, dataCadastro, codLivro) values (@dataEmp, @nomeLivro, @prontuario, @nomeLocatario, @nomeVendedor, @dataCadastro, @codLivro);";
                comm.CommandType = CommandType.Text;

                for (int i = 0; i < Livros.ListaLivros.Count; i++)
                {
                    comm.Parameters.Clear();
                    comm.Parameters.Add("@dataEmp", MySqlDbType.DateTime).Value = DateTime.Now;
                    comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = livros.nomeRetorno(i);
                    comm.Parameters.Add("@prontuario", MySqlDbType.Int32).Value = Convert.ToInt32(txtProntuario.Text);
                    comm.Parameters.Add("@nomeLocatario", MySqlDbType.VarChar, 100).Value = txtNomeLoc.Text;
                    comm.Parameters.Add("@nomeVendedor", MySqlDbType.VarChar, 100).Value = this.nome;
                    comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;
                    comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.codRetorno(i);
                }

                comm.Connection = Conexao.obterConexao();
                resp = comm.ExecuteNonQuery();
                Conexao.fecharConexao();

                return resp;
            }
            catch (MySqlException)
            {
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
                    comm.CommandText = "update tbEstoque set saidaEmp = @saidaEmp, empVen = @empVen where codLivro = @codLivro";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@saidaEmp", MySqlDbType.Int32).Value = pegarQuantSaida(livros.proximoLivro(i)) + quantidadeRetorno(i);
                    comm.Parameters.Add("@empVen", MySqlDbType.VarChar, 3).Value = "Emp";
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

        public void confirmarEstoque()
        {
            MySqlCommand comm = new MySqlCommand();
            try
            {
                for (int i = 0; i < livros.quantidadeLista(); i++)
                {
                    comm.CommandText = "update tbEstoque set disponibilidade = @disponibilidade where codLivro = @codLivro";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = livros.proximoLivro(i);

                    if (livros.checarEstoque(i, "Emp") <= 0)
                    {
                        comm.Parameters.Add("@disponibilidade", MySqlDbType.VarChar, 1).Value = "N";
                    }
                    else
                    {
                        comm.Parameters.Add("@disponibilidade", MySqlDbType.VarChar, 1).Value = "S";
                    }

                    comm.Connection = Conexao.obterConexao();

                    int resp = comm.ExecuteNonQuery();

                    Conexao.fecharConexao();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao checar disponibilidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public int pegarQuantLivro(int index)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select entradaEmp from tbEstoque where codLivro = @codLivro;";
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
                comm.CommandText = "select saidaEmp from tbEstoque where codLivro = @codLivro;";
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

        public void separarLivros()
        {
            Livros livros = new Livros();

            livros.idLivro = Convert.ToInt32(txtIdLivro.Text);
            livros.nomeLivro = txtTitulo.Text;

            Livros.ListaLivros.Add(livros);
        }

        public void escanearLivro(int id)
        {
            try
            {
                string tipo;

                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select empVen, isbn, nome, autor, editora, foto from tbLivro where codLivro = @codLivro;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = id;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                bool resp = DR.HasRows;

                tipo = DR.GetString(0);

                if (resp)
                {
                    if (tipo.Equals("Emp"))
                    {
                        txtIsbn.Text = DR.GetString(1);
                        txtTitulo.Text = DR.GetString(2);
                        txtAutor.Text = DR.GetString(3);
                        txtEditora.Text = DR.GetString(4);
                        if (fotoPath != null)
                        {
                            fotoPath = DR.GetString(5);
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
                        MessageBox.Show("Livro selecionado não esta cadastrado para Empréstimo", "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("ID inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    txtIdLivro.Focus();
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao escanear livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public bool checarDisp(int codLivro)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select disponibilidade from tbEstoque where codLivro = @codLivro";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = codLivro;

            comm.Connection = Conexao.obterConexao();
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            if (DR.GetString(0).Equals("N"))
            {
                Conexao.fecharConexao();
                return false;
            }
            else
            {
                Conexao.fecharConexao();
                return true;
            }
        }

        private void txtProntuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNomeLoc.Text = pesquisarLocatario(Convert.ToInt32(txtProntuario.Text));
            }
        }

        public string pesquisarLocatario(int pront)
        {
            string locatario = "";

            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select nome from tbLocatario where pront = @pront;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@pront", pront);

            comm.Connection = Conexao.obterConexao();
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            if (!DR.HasRows)
            {
                MessageBox.Show("Prontuário inexistente/não encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                locatario = DR.GetString(0);
            }

            Conexao.fecharConexao();

            return locatario;
        }

        private void ltbCarrinho_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
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
                    Livros.ListaLivros.RemoveAt(ltbCarrinho.SelectedIndex);
                    ltbCarrinho.Items.RemoveAt(ltbCarrinho.SelectedIndex);
                    estoqueInicial++;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao remover item do carrinho.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarLivro abrir = new frmBuscarLivro(this.nome, this.codUsu, this.cargo, "Empréstimo");

            if (ltbCarrinho.Items.Count != 0)
            {
                DialogResult resultado = MessageBox.Show("Essa ação irá limpar o carrinho. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (resultado == DialogResult.Yes)
                {
                    abrir = new frmBuscarLivro(this.nome, this.codUsu, this.cargo, "Empréstimo");
                    abrir.Show();
                    this.Hide();
                }
            }
            else
            {
                abrir = new frmBuscarLivro(this.nome, this.codUsu, this.cargo, "Empréstimo");
                abrir.Show();
                this.Hide();
            }
        }

        private void btnDevolucao_Click(object sender, EventArgs e)
        {
            frmDevolucao abrir = new frmDevolucao(this.nome, this.codUsu, this.cargo);
            abrir.Show();
            this.Hide();
        }

        private void txtIdLivro_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    codLivro = Convert.ToInt32(txtIdLivro.Text);
                    escanearLivro(codLivro);
                    estoqueInicial = livros.checarEstoque(codLivro, "Emp");
                    txtProntuario.Focus();
                    if (!checarDisp(codLivro))
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
            catch (Exception)
            {
                MessageBox.Show("ID não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    fotoPath = DR.GetString(5);
                    pctLivro.ImageLocation = fotoPath;
                    pctLivro.Load();
                }
                else
                {
                    pctLivro.Image = null;
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao buscar informações do livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }

        private void txtIdLivro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
