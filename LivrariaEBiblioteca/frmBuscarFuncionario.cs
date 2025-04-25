using System;
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
    public partial class frmBuscarFuncionario : Form
    {
        public frmBuscarFuncionario()
        {
            InitializeComponent();
            desabilitarComponentes();
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
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario abrir = new frmCadastroUsuario();
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
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select from tbUsuario where codUsu = @codUsu;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codUsu", MySqlDbType.Int32).Value = codigo;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            ltbPesquisar.Items.Add(DR.GetString(0));

            Conexao.fecharConexao();
        }

        public void pesquisarPorNome(string descricao)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select from tbUsuario where nome like '%" + descricao + "%'";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar,100).Value = descricao;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            
            while (DR.Read())
            {
                ltbPesquisar.Items.Add(DR.GetString(0));
            }

            Conexao.fecharConexao();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                MessageBox.Show("Favor prencher a descrição!");
                txtDescricao.Focus();
            }
            else
            {
                if (rdbID.Checked)
                {
                    pesquisarPorCodigo(Convert.ToInt32(txtDescricao.Text));
                }
                if (rdbID.Checked)
                {
                    pesquisarPorNome(txtDescricao.Text);
                }
            }
        }

        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string descricao = ltbPesquisar.SelectedItem.ToString();
            frmCadastroUsuario abrir = new frmCadastroUsuario();
            abrir.Show();
            this.Hide();
        }
    }
}
