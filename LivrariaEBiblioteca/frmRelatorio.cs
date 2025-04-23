using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivrariaEBiblioteca
{
    public partial class frmRelatorio : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;
        public frmRelatorio()
        {
            InitializeComponent();
        }
        public frmRelatorio(string nome, int codUsu, string cargo)
        {
            InitializeComponent();
            this.nome = nome;
            this.codUsu = codUsu;
            this.cargo = cargo;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal(this.nome, this.cargo, this.codUsu);
            abrir.Show();
            this.Hide();
        }
    }
}
