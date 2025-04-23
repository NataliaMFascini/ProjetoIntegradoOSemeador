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
