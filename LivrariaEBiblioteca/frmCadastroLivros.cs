﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivrariaEBiblioteca
{
    public partial class frmCadastroLivros : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;
        public string livro;
        public string fotoPath;

        public int quantAtual = 0;
        public frmCadastroLivros()
        {
            InitializeComponent();
            desabilitarCampos();
        }

        public void limparComponentes()
        {
            txtAno.Clear();
            txtAutor.Clear();
            txtEditora.Clear();
            txtIdLivro.Clear();
            txtIsbn.Clear();
            txtQuantidade.Clear();
            txtTitulo.Clear();
            txtValor.Clear();
            rdbEmprestimo.Checked = false;
            rdbVenda.Checked = false;
            pctLivro.Image = null;
        }

        public frmCadastroLivros(string livro, string tipo, string nome, int codusu, string cargo)
        {
            InitializeComponent();
            desabilitarCamposBusca();
            habilitarCampos();
            this.nome = nome;
            this.codUsu = codusu;
            this.cargo = cargo;

            if (this.cargo == "Voluntário")
            {
                btnRemover.Enabled = false;
                btnAlterar.Enabled = false;
            }

            if (tipo == "venda")
            {
                pesquisarPorNomeL(livro);
                rdbEmprestimo.Enabled = false;
            }
            else if (tipo == "emprestimo")
            {
                pesquisarPorNomeB(livro);
                rdbVenda.Enabled = false;
            }
        }

        public frmCadastroLivros(string nome, int codusu, string cargo)
        {
            InitializeComponent();
            desabilitarCampos();
            this.nome = nome;
            this.codUsu = codusu;
            this.cargo = cargo;

            if (this.cargo == "Voluntário")
            {
                btnRemover.Enabled = false;
                btnAlterar.Enabled = false;
            }
        }

        public void limparCampos()
        {
            txtIsbn.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtEditora.Clear();
            txtAno.Clear();
            txtQuantidade.Clear();
            txtValor.Clear();
            pctLivro.Image = null;
            rdbEmprestimo.Checked = false;
            rdbVenda.Checked = false;
            txtIsbn.Focus();
            txtIdLivro.Clear();
        }

        public void desabilitarCampos()
        {
            btnRemover.Enabled = false;
            btnAlterar.Enabled = false;
        }
        public void desabilitarCamposBusca()
        {
            btnRemover.Enabled = false;
            btnAlterar.Enabled = false;
            btnAdicionar.Enabled = false;
        }

        public void habilitarCampos()
        {
            btnRemover.Enabled = true;
            btnAlterar.Enabled = true;
        }

        private void erroCadastro(string nomeCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        private void erroCampo(string nomeCampo, string tipoCampo)
        {
            MessageBox.Show(nomeCampo + " é um campo somente " + tipoCampo + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            frmBuscarLivro abrir = new frmBuscarLivro(nome, codUsu, cargo, "Cadastro");
            abrir.Show();
            this.Hide();
        }

        public void pesquisarPorNomeL(string nome)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbLivroL where nome = @nome;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                txtIdLivro.Text = DR.GetInt32(0).ToString();
                rdbVenda.Checked = true;
                txtIsbn.Text = DR.GetString(1).ToString();
                txtTitulo.Text = DR.GetString(2).ToString();
                txtAutor.Text = DR.GetString(3).ToString();
                txtQuantidade.Text = DR.GetInt32(4).ToString();
                txtValor.Text = DR.GetDecimal(5).ToString();
                txtEditora.Text = DR.GetString(6).ToString();
                txtAno.Text = DR.GetInt32(7).ToString();
                fotoPath = DR.GetString(8).ToString();
                if (fotoPath != "")
                {
                    pctLivro.ImageLocation = fotoPath;
                    pctLivro.Load();
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao buscar informações do livro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pesquisarPorNomeB(string nome)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbLivroB where nome = @nome;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                txtIdLivro.Text = DR.GetInt32(0).ToString();
                rdbEmprestimo.Checked = true;
                txtIsbn.Text = DR.GetString(1).ToString();
                txtTitulo.Text = DR.GetString(2).ToString();
                txtAutor.Text = DR.GetString(3).ToString();
                txtQuantidade.Text = DR.GetInt32(4).ToString();
                txtValor.Text = "--,--";
                txtEditora.Text = DR.GetString(5).ToString();
                txtAno.Text = DR.GetInt32(6).ToString();
                fotoPath = DR.GetString(7).ToString();
                if (fotoPath != "")
                {
                    pctLivro.ImageLocation = fotoPath;
                    pctLivro.Load();
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao buscar informações do livro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool checarCharactere()
        {
            int tryParse;
            decimal tryParseDecimal;
            if (int.TryParse(txtTitulo.Text, out tryParse))
            {
                erroCampo("Titulo", "alfabético");
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
            else if (!int.TryParse(txtAno.Text, out tryParse))
            {
                erroCampo("Ano", "númerico");
                txtAno.Clear();
                txtAno.Focus();
                return false;
            }
            else if (!int.TryParse(txtQuantidade.Text, out tryParse))
            {
                erroCampo("Quantidade", "númerico");
                txtQuantidade.Clear();
                txtQuantidade.Focus();
                return false;
            }
            else if (!decimal.TryParse(txtValor.Text, out tryParseDecimal) && rdbVenda.Checked)
            {
                erroCampo("Valor", "númerico");
                txtValor.Clear();
                txtValor.Focus();
                return false;
            }
            else
            {

                return true;
            }
        }

        public bool checarCampos()
        {
            if (txtIsbn.Text.Equals(""))
            {
                erroCadastro("ISBN");
                txtIsbn.Focus();
                return false;
            }
            else if (txtTitulo.Text.Equals(""))
            {
                erroCadastro("Titulo");
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
            else if (txtAno.Text.Equals(""))
            {
                erroCadastro("Ano");
                txtAno.Focus();
                return false;
            }
            else if (txtQuantidade.Text.Equals(""))
            {
                erroCadastro("Quantidade");
                txtQuantidade.Focus();
                return false;
            }
            else if (txtValor.Text.Equals("") && rdbVenda.Checked)
            {
                erroCadastro("Valor");
                txtValor.Focus();
                return false;
            }
            else if (rdbEmprestimo.Checked == false && rdbVenda.Checked == false)
            {
                erroCadastro("Emprestimo ou Venda");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (checarCampos() && checarCharactere())
            {
                    if (cadastrarLivro() == 1 && adicionarEstoque() == 1)
                    {
                        MessageBox.Show("Cadastro realizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        limparCampos();

                        txtIsbn.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar livro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
            }
        }

        public bool checarLivro()
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select livraria.nome, biblioteca.nome from tbLivroL as livraria, tbLivroB as biblioteca where livraria.isbn = @isbn or biblioteca.isbn = @isbn;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@isbn", MySqlDbType.VarChar, 20).Value = txtIsbn.Text;

                comm.Connection = Conexao.obterConexao();
                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();
                if (DR.HasRows)
                {
                    MessageBox.Show("Livro já cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIsbn.Focus();

                    Conexao.fecharConexao();
                    return false;
                }

                Conexao.fecharConexao();
                return true;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao verificar existencia do livro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public int pegarIDLivro(string tipo)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                if (tipo == "venda")
                {
                    comm.CommandText = "select codLivro from tbLivroL where isbn = @isbn;";
                    comm.CommandType = CommandType.Text;
                }
                if (tipo == "emprestimo")
                {
                    comm.CommandText = "select codLivro from tbLivroB where isbn = @isbn;";
                    comm.CommandType = CommandType.Text;
                }
                comm.Parameters.Clear();
                comm.Parameters.Add("@isbn", MySqlDbType.VarChar, 20).Value = txtIsbn.Text;

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                int idLivro = DR.GetInt32(0);

                Conexao.fecharConexao();
                return idLivro;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao pegar ID do livro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int pegarQuantLivro()
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                if (rdbEmprestimo.Checked)
                {
                    comm.CommandText = "select entradaEmp, saidaEmp from tbEstoqueB where codLivro = @codLivro;";
                    comm.CommandType = CommandType.Text;
                }

                if (rdbVenda.Checked)
                {
                    comm.CommandText = "select entradaVen, saidaVen from tbEstoqueL where codLivro = @codLivro;";
                    comm.CommandType = CommandType.Text;
                }

                comm.Parameters.Clear();
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32, 20).Value = Convert.ToInt32(txtIdLivro.Text);

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                int quant = DR.GetInt32(0);
                quantAtual = DR.GetInt32(0) - DR.GetInt32(1);

                Conexao.fecharConexao();
                return quant;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao pegar quantidade do livro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int cadastrarLivro()
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();

                if (rdbVenda.Checked)
                {
                    comm.CommandText = "insert into tbLivroL (isbn, nome, autor, quant, valor, editora, anoPublicacao, foto, dataCadastro) values (@isbn, @nome, @autor, @quant, @valor, @editora, @anoPublicacao, @foto, @dataCadastro);";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    try
                    {
                        comm.Parameters.Add("@valor", MySqlDbType.Decimal).Value = Convert.ToDecimal(txtValor.Text);
                        comm.Parameters.Add("@isbn", MySqlDbType.VarChar, 20).Value = txtIsbn.Text;
                        comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtTitulo.Text;
                        comm.Parameters.Add("@autor", MySqlDbType.VarChar, 100).Value = txtAutor.Text;
                        comm.Parameters.Add("@quant", MySqlDbType.Int32).Value = Convert.ToInt32(txtQuantidade.Text);
                        comm.Parameters.Add("@editora", MySqlDbType.VarChar, 50).Value = txtEditora.Text;
                        comm.Parameters.Add("@anoPublicacao", MySqlDbType.Int32).Value = Convert.ToInt32(txtAno.Text);
                        if (pctLivro.Image == null)
                        {
                            fotoPath = "";
                        }
                        else
                        {
                            fotoPath = pctLivro.ImageLocation;
                        }
                        comm.Parameters.Add("@foto", MySqlDbType.VarChar, 200).Value = fotoPath;
                        comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Valor inválido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }
                }

                if (rdbEmprestimo.Checked)
                {
                    comm.CommandText = "insert into tbLivroB (isbn, nome, autor, quant, editora, anoPublicacao, foto, dataCadastro) values (@isbn, @nome, @autor, @quant, @editora, @anoPublicacao, @foto, @dataCadastro);";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();

                    comm.Parameters.Add("@isbn", MySqlDbType.VarChar, 20).Value = txtIsbn.Text;
                    comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtTitulo.Text;
                    comm.Parameters.Add("@autor", MySqlDbType.VarChar, 100).Value = txtAutor.Text;
                    comm.Parameters.Add("@quant", MySqlDbType.Int32).Value = Convert.ToInt32(txtQuantidade.Text);
                    comm.Parameters.Add("@editora", MySqlDbType.VarChar, 50).Value = txtEditora.Text;
                    comm.Parameters.Add("@anoPublicacao", MySqlDbType.Int32).Value = Convert.ToInt32(txtAno.Text);
                    if (pctLivro.Image == null)
                    {
                        fotoPath = "";
                    }
                    else
                    {
                        fotoPath = pctLivro.ImageLocation;
                    }
                    comm.Parameters.Add("@foto", MySqlDbType.VarChar, 200).Value = fotoPath;
                    comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;
                }

                comm.Connection = Conexao.obterConexao();
                int resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao cadastrar livro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal(cargo, nome, codUsu);
            abrir.Show();
            this.Hide();
        }

        private void btnAdicionarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto = new OpenFileDialog();
            foto.Title = "Selecione uma imagem";
            foto.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp|Todos os arquivos|*.*";

            if (foto.ShowDialog() == DialogResult.OK)
            {
                pctLivro.ImageLocation = foto.FileName;
                pctLivro.Load();
                fotoPath = foto.FileName;
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja excluir o livro?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resultado == DialogResult.Yes)
            {
                excluirLivro(Convert.ToInt32(txtIdLivro.Text));
                limparCampos();
                desabilitarCampos();
                btnAdicionar.Enabled = true;
            }
        }

        public int excluirLivro(int codLivro)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                if (rdbEmprestimo.Checked)
                {
                    comm.CommandText = "delete from tbLivroB where codLivro = @codLivro;";
                    comm.CommandType = CommandType.Text;
                }
                if (rdbVenda.Checked)
                {
                    comm.CommandText = "delete from tbLivroL where codLivro = @codLivro;";
                    comm.CommandType = CommandType.Text;
                }

                comm.Connection = Conexao.obterConexao();

                comm.Parameters.Clear();
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = codLivro;

                int resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao excluir livro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int alterarLivro(int codLivro)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                if (rdbEmprestimo.Checked)
                {
                    comm.CommandText = "update tbLivroB set codLivro = @codLivro, isbn = @isbn, nome = @nome, autor = @autor, quant = @quant, editora = @editora, anoPublicacao = @anoPublicacao, foto = @foto, dataCadastro = @dataCadastro where codLivro = @codLivro;";
                    comm.CommandType = CommandType.Text;
                }
                if (rdbVenda.Checked)
                {
                    comm.CommandText = "update tbLivroL set codLivro = @codLivro, isbn = @isbn, nome = @nome, autor = @autor, quant = @quant, valor = @valor, editora = @editora, anoPublicacao = @anoPublicacao, foto = @foto, dataCadastro = @dataCadastro where codLivro = @codLivro;";
                    comm.CommandType = CommandType.Text;
                }
                comm.Parameters.Clear();

                comm.Parameters.Add("@isbn", MySqlDbType.VarChar, 20).Value = txtIsbn.Text;
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtTitulo.Text;
                comm.Parameters.Add("@autor", MySqlDbType.VarChar, 100).Value = txtAutor.Text;
                comm.Parameters.Add("@quant", MySqlDbType.Int32).Value = Convert.ToInt32(txtQuantidade.Text);
                if (rdbVenda.Checked)
                {
                    comm.Parameters.Add("@valor", MySqlDbType.Decimal).Value = Convert.ToDecimal(txtValor.Text);
                }
                comm.Parameters.Add("@editora", MySqlDbType.VarChar, 50).Value = txtEditora.Text;
                comm.Parameters.Add("@anoPublicacao", MySqlDbType.Int32).Value = Convert.ToInt32(txtAno.Text);
                if (pctLivro.Image == null)
                {
                    fotoPath = "";
                }
                else
                {
                    fotoPath = pctLivro.ImageLocation;
                }
                comm.Parameters.Add("@foto", MySqlDbType.VarChar, 200).Value = fotoPath;
                comm.Parameters.Add("@dataCadastro", MySqlDbType.DateTime).Value = DateTime.Now;
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = codLivro;

                comm.Connection = Conexao.obterConexao();
                int resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao alterar livro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (checarCampos() && checarCharactere())
            {
                if (alterarLivro(Convert.ToInt32(txtIdLivro.Text)) == 1 && atualizarEstoque(Convert.ToInt32(txtIdLivro.Text)) == 1)
                {
                    MessageBox.Show("Alteração realizada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limparCampos();

                    txtIsbn.Focus();
                }
                else
                {
                    MessageBox.Show("Erro ao alterar cadastro", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public int adicionarEstoque()
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                if (rdbVenda.Checked)
                {
                    comm.CommandText = "insert into tbEstoqueL(entradaVen, nomeLivro, disponibilidade, codLivro) values (@entradaVen, @nomeLivro, @disponibilidade, @codLivro);";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@entradaVen", MySqlDbType.Int32).Value = Convert.ToInt32(txtQuantidade.Text);
                    comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = txtTitulo.Text;
                    comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = pegarIDLivro("venda");
                }
                if (rdbEmprestimo.Checked)
                {
                    comm.CommandText = "insert into tbEstoqueB(entradaEmp, nomeLivro,  disponibilidade, codLivro) values (@entradaEmp, @nomeLivro, @disponibilidade, @codLivro);";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@entradaEmp", MySqlDbType.Int32).Value = Convert.ToInt32(txtQuantidade.Text);
                    comm.Parameters.Add("@nomeLivro", MySqlDbType.VarChar, 100).Value = txtTitulo.Text;
                    comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = pegarIDLivro("emprestimo");
                }

                if (Convert.ToInt32(txtQuantidade.Text) == 0)
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

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao adicionar livro ao estoque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int atualizarEstoque(int codLivro)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                if (rdbVenda.Checked)
                {
                    comm.CommandText = "update tbEstoqueL set entradaVen = @entradaVen, disponibilidade = @disponibilidade where codLivro = @codLivro;";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@entradaVen", MySqlDbType.Int32).Value = pegarQuantLivro() + Convert.ToInt32(txtQuantidade.Text);
                    comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = codLivro;
                    if (Convert.ToInt32(txtQuantidade.Text) != 0)
                    {
                        comm.Parameters.Add("@disponibilidade", MySqlDbType.VarChar, 1).Value = "S";
                    }
                    else
                    {
                        comm.Parameters.Add("@disponibilidade", MySqlDbType.VarChar, 1).Value = "N";
                    }
                }
                if (rdbEmprestimo.Checked)
                {
                    comm.CommandText = "update tbEstoqueB set entradaEmp = @entradaEmp, disponibilidade = @disponibilidade where codLivro = @codLivro;";
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.Clear();
                    comm.Parameters.Add("@entradaEmp", MySqlDbType.Int32).Value = pegarQuantLivro() + Convert.ToInt32(txtQuantidade.Text);
                    comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = codLivro;
                    if (Convert.ToInt32(txtQuantidade.Text) != 0)
                    {
                        comm.Parameters.Add("@disponibilidade", MySqlDbType.VarChar, 1).Value = "S";
                    }
                    else
                    {
                        comm.Parameters.Add("@disponibilidade", MySqlDbType.VarChar, 1).Value = "N";
                    }
                }

                comm.Connection = Conexao.obterConexao();

                int resp = comm.ExecuteNonQuery();

                Conexao.fecharConexao();

                return resp;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao adicionar livro ao estoque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void rdbEmprestimo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEmprestimo.Checked)
            {
                txtValor.Enabled = false;
            }
            else
            {
                txtValor.Enabled = true;
            }
        }

        private void txtIsbn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checarLivro())
                {
                    txtTitulo.Focus();
                }
                else
                {
                    txtIsbn.Clear();
                    txtIsbn.Focus();
                }
            }
        }

        private void txtTitulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAutor.Focus();
            }
        }

        private void txtIsbn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
