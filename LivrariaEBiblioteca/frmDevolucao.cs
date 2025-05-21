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
    public partial class frmDevolucao : Form
    {
        public string nome;
        public string cargo;
        public int codUsu;

        public frmDevolucao()
        {
            InitializeComponent();
        }
        public frmDevolucao(string nome, int codUsu, string cargo)
        {
            InitializeComponent();
            this.nome = nome;
            this.cargo = cargo;
            this.codUsu = codUsu;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal(cargo, nome, codUsu);
            abrir.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarLivro abrir = new frmBuscarLivro(nome, codUsu, cargo, "Devolução");
            abrir.Show();
            this.Hide();
        }

        public void limparCampos()
        {
            txtIdLivro.Clear();
            txtIsbn.Clear();
            txtTitulo.Clear();
            txtEditora.Clear();
            txtAutor.Clear();
            txtNEmprestimo.Clear();
            txtLocatario.Clear();

            ltbCarrinho.Items.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
    }
}
