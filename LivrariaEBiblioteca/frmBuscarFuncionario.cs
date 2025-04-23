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
        public string nome;
        public int codUsu;
        public string cargo;
        public string ultimaTela;
        public frmBuscarFuncionario()
        {
            InitializeComponent();
            desabilitarComponentes();
        }
        public frmBuscarFuncionario(string nome, int codUsu, string cargo, string ultimaTela)
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
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if(ultimaTela == "Usuario")
            {
                frmCadastroUsuario abrir = new frmCadastroUsuario(this.nome, this.codUsu, this.cargo);
            }
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

        private void frmBuscarFuncionario_Load(object sender, EventArgs e)
        {

        }
    }
}
