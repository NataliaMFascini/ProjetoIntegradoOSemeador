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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void tmrSplash_Tick(object sender, EventArgs e)
        {
            int contagem = 0;

            if (pgbSplash.Value < 100 && contagem < 100)
            {
                pgbSplash.Value = pgbSplash.Value + 1;
                contagem = pgbSplash.Value;
                lblPorcentagem.Text = contagem + "%";
            }
            else
            {
                frmLogin abrir = new frmLogin();
                abrir.Show();
                this.Hide();
                tmrSplash.Enabled = false;
            }
        }
    }
}
