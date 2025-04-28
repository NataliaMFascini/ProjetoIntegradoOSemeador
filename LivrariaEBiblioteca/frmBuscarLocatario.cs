using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmCadastroLocatario abrir = new frmCadastroLocatario();
            abrir.Show();
            this.Hide();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparComponentes();
            desabilitarCampos ();   
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
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select from tbLocatario where codLoc = @codLoc;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codLoc", MySqlDbType.Int32).Value = prontuario;

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
            comm.CommandText = "select from tbLocatario where nome like '%" + descricao + "%'";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codLoc", MySqlDbType.Int32).Value = nome;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            ltbPesquisar.Items.Add(DR.GetString(0));

            Conexao.fecharConexao();
        }

        private void frmBuscarLocatario_Load(object sender, EventArgs e)
        {

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
                if (rdbPront.Checked)
                {
                    pesquisarPorProntuario(Convert.ToInt32(txtDescricao.Text));
                }
                if (rdbNome.Checked)
                {
                    pesquisarPorNome(txtDescricao.Text);
                }
            }
        }
    }
}
