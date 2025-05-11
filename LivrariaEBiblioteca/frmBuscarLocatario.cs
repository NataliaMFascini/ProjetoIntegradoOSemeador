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
    public partial class frmBuscarLocatario : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;
        public frmBuscarLocatario()
        {
            InitializeComponent();
            desabilitarCampos();
        }
        public frmBuscarLocatario(string nome, int codUsu, string cargo)
        {
            InitializeComponent();
            desabilitarCampos();

            this.nome = nome;
            this.codUsu = codUsu;
            this.cargo = cargo;
        }

        public void limparComponentes()
        {
            txtDescricao.Clear();
            ltbPesquisar.Items.Clear();
            rdbPront.Checked = false;
            rdbNome.Checked = false;
        }

        public void desabilitarCampos()
        {
            txtDescricao.Enabled = false;
            btnLimpar.Enabled = false;
            btnPesquisar.Enabled = false;

            rdbNome.Checked = false;
            rdbPront.Checked = false;
        }

        public void habilitarCampos()
        {
            txtDescricao.Enabled = true;
            btnLimpar.Enabled = true;
            btnPesquisar.Enabled = true;
            txtDescricao.Focus();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmCadastroLocatario abrir = new frmCadastroLocatario(this.nome, this.codUsu, this.cargo);
            abrir.Show();
            this.Hide();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparComponentes();
            desabilitarCampos();
        }

        private void rdbPront_CheckedChanged(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            habilitarCampos();
        }
        public void pesquisarPorProntuario(int prontuario)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select nome from tbLocatario where pront = @pront;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@pront", MySqlDbType.Int32).Value = prontuario;

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();

                if (!DR.HasRows)
                {
                    MessageBox.Show("Não há locatários com esse prontuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                while (DR.Read())
                {
                    ltbPesquisar.Items.Add(DR.GetString(0));
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao pesquisar por prontuario.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pesquisarPorNome(string descricao)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select nome from tbLocatario where nome like '%" + descricao + "%'";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = descricao;

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();

                if (!DR.HasRows)
                {
                    MessageBox.Show("Não há locatários com esse nome.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                while (DR.Read())
                {
                    ltbPesquisar.Items.Add(DR.GetString(0));
                }

                Conexao.fecharConexao();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Erro ao pesquisar por nome.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            int tryParse;
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                MessageBox.Show("Favor prencher a descrição.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescricao.Focus();
            }
            else
            {
                try
                {
                    if (rdbPront.Checked)
                    {
                        if(!int.TryParse(txtDescricao.Text, out tryParse))
                        {
                            MessageBox.Show("Usar apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDescricao.Clear();
                            txtDescricao.Focus();
                            return;
                        }
                        pesquisarPorProntuario(Convert.ToInt32(txtDescricao.Text));
                    }
                    if (rdbNome.Checked)
                    {
                        if(int.TryParse(txtDescricao.Text, out tryParse))
                        {
                            MessageBox.Show("Utilizar apenas letras.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDescricao.Clear();
                            txtDescricao.Focus();
                            return;
                        }
                        pesquisarPorNome(txtDescricao.Text);
                    }
                }catch (Exception)
                {
                    MessageBox.Show("Caractere invalido.", "Erro", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnPesquisar_Click(sender, e);
            }
        }
        
        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string locatario = ltbPesquisar.SelectedItem.ToString();
            frmCadastroLocatario abrir = new frmCadastroLocatario(this.nome, this.codUsu, this.cargo, locatario);
            abrir.Show();
            this.Hide();
        }
    }
}
