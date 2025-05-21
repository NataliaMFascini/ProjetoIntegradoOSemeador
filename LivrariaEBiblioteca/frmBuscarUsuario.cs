<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace LivrariaEBiblioteca
{
    public partial class frmBuscarUsuario : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;
        public string ultimaTela;
        public frmBuscarUsuario()
        {
            InitializeComponent();
            desabilitarComponentes();
        }
        public frmBuscarUsuario(string nome, int codUsu, string cargo, string ultimaTela)
        {
            InitializeComponent();
            desabilitarComponentes();

            this.codUsu = codUsu;
            this.nome = nome;
            this.cargo = cargo;
            this.ultimaTela = ultimaTela;
        }
        public void limparComponetes()
        {
            txtDescricao.Clear();
            ltbPesquisar.Items.Clear();
            rdbID.Checked = false;
            rdbNome.Checked = false;
        }
        public void desabilitarComponentes()
        {
            txtDescricao.Enabled = false;
            btnPesquisar.Enabled = false;
            btnLimpar.Enabled = false;
        }

        public void habilitarComponentes()
        {
            txtDescricao.Enabled = true;
            btnPesquisar.Enabled = true;
            btnLimpar.Enabled = true;

            txtDescricao.Focus();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario abrir = new frmCadastroUsuario(this.nome, this.codUsu, this.cargo);
            abrir.Show();
            this.Hide();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparComponetes();
            desabilitarComponentes();
        }

        private void rdbID_CheckedChanged(object sender, EventArgs e)
        {
            habilitarComponentes();
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            habilitarComponentes();
        }

        public void pesquisarPorCodigo(int codigo)
        {
            try
            {

                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbUsuario where codUsu = @codUsu;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@codUsu", MySqlDbType.Int32).Value = codigo;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                if (!DR.HasRows)
                {
                    MessageBox.Show("Não há usuários com esse ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ltbPesquisar.Items.Add(DR.GetString(1));

                Conexao.fecharConexao();
            }
            catch(MySqlException)
            {
                MessageBox.Show("Código não encontrado/não existe.", "Erro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pesquisarPorNome(string descricao)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbUsuario where nome like '%" + descricao + "%'";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = descricao;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();

                if (!DR.HasRows)
                {
                    MessageBox.Show("Não há usuários com esse nome.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                while (DR.Read())
                {
                    ltbPesquisar.Items.Add(DR.GetString(1));
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Nome não encontrado/não existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            int tryParse;
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                MessageBox.Show("Favor prencher a descrição.");
                txtDescricao.Focus();
            }
            else
            {
                if (rdbID.Checked)
                {
                    if (!int.TryParse(txtDescricao.Text, out tryParse))
                    {
                        MessageBox.Show("Favor preencher o campo com números inteiros.");
                        txtDescricao.Clear();
                        txtDescricao.Focus();
                        return;
                    }
                    pesquisarPorCodigo(Convert.ToInt32(txtDescricao.Text));
                }
                if (rdbNome.Checked)
                {
                    if(int.TryParse(txtDescricao.Text, out tryParse))
                    {
                        MessageBox.Show("Favor preencher o campo com letras.");
                        txtDescricao.Clear();
                        txtDescricao.Focus();
                        return;
                    }
                    pesquisarPorNome(txtDescricao.Text);
                }
            }
        }

        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbID.Checked)
            {
                string descricao = ltbPesquisar.SelectedItem.ToString();
                frmCadastroUsuario abrir = new frmCadastroUsuario(nome, codUsu, cargo, descricao);
                abrir.Show();
                this.Hide();
            }
            if(rdbNome.Checked)
            {
                string descricao = ltbPesquisar.SelectedItem.ToString();
                frmCadastroUsuario abrir = new frmCadastroUsuario(nome, codUsu, cargo, descricao);
                abrir.Show();
                this.Hide();
            }
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnPesquisar_Click(sender, e);
            }
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace LivrariaEBiblioteca
{
    public partial class frmBuscarUsuario : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;
        public string ultimaTela;
        public frmBuscarUsuario()
        {
            InitializeComponent();
            desabilitarComponentes();
        }
        public frmBuscarUsuario(string nome, int codUsu, string cargo, string ultimaTela)
        {
            InitializeComponent();
            desabilitarComponentes();

            this.codUsu = codUsu;
            this.nome = nome;
            this.cargo = cargo;
            this.ultimaTela = ultimaTela;
        }
        public void limparComponetes()
        {
            txtDescricao.Clear();
            ltbPesquisar.Items.Clear();
            rdbID.Checked = false;
            rdbNome.Checked = false;
        }
        public void desabilitarComponentes()
        {
            txtDescricao.Enabled = false;
            btnPesquisar.Enabled = false;
            btnLimpar.Enabled = false;
        }

        public void habilitarComponentes()
        {
            txtDescricao.Enabled = true;
            btnPesquisar.Enabled = true;
            btnLimpar.Enabled = true;

            txtDescricao.Focus();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario abrir = new frmCadastroUsuario(this.nome, this.codUsu, this.cargo);
            abrir.Show();
            this.Hide();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparComponetes();
            desabilitarComponentes();
        }

        private void rdbID_CheckedChanged(object sender, EventArgs e)
        {
            habilitarComponentes();
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            habilitarComponentes();
        }

        public void pesquisarPorCodigo(int codigo)
        {
            try
            {

                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbUsuario where codUsu = @codUsu;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@codUsu", MySqlDbType.Int32).Value = codigo;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                if (!DR.HasRows)
                {
                    MessageBox.Show("Não há usuários com esse ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ltbPesquisar.Items.Add(DR.GetString(1));

                Conexao.fecharConexao();
            }
            catch(MySqlException)
            {
                MessageBox.Show("Código não encontrado/não existe.", "Erro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pesquisarPorNome(string descricao)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbUsuario where nome like '%" + descricao + "%'";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = descricao;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();

                if (!DR.HasRows)
                {
                    MessageBox.Show("Não há usuários com esse nome.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                while (DR.Read())
                {
                    ltbPesquisar.Items.Add(DR.GetString(1));
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Nome não encontrado/não existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            int tryParse;
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                MessageBox.Show("Favor prencher a descrição.");
                txtDescricao.Focus();
            }
            else
            {
                if (rdbID.Checked)
                {
                    if (!int.TryParse(txtDescricao.Text, out tryParse))
                    {
                        MessageBox.Show("Favor preencher o campo com números inteiros.");
                        txtDescricao.Clear();
                        txtDescricao.Focus();
                        return;
                    }
                    pesquisarPorCodigo(Convert.ToInt32(txtDescricao.Text));
                }
                if (rdbNome.Checked)
                {
                    if(int.TryParse(txtDescricao.Text, out tryParse))
                    {
                        MessageBox.Show("Favor preencher o campo com letras.");
                        txtDescricao.Clear();
                        txtDescricao.Focus();
                        return;
                    }
                    pesquisarPorNome(txtDescricao.Text);
                }
            }
        }

        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbID.Checked)
            {
                string descricao = ltbPesquisar.SelectedItem.ToString();
                frmCadastroUsuario abrir = new frmCadastroUsuario(nome, codUsu, cargo, descricao);
                abrir.Show();
                this.Hide();
            }
            if(rdbNome.Checked)
            {
                string descricao = ltbPesquisar.SelectedItem.ToString();
                frmCadastroUsuario abrir = new frmCadastroUsuario(nome, codUsu, cargo, descricao);
                abrir.Show();
                this.Hide();
            }
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnPesquisar_Click(sender, e);
            }
        }
    }
}
>>>>>>> 6f662a3d24e061c06d58d613c86cdd2d3d0087dc
