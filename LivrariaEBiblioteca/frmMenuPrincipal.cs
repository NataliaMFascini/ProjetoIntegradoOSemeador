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
    public partial class frmMenuPrincipal : Form
    {
        public string nome;
        public int codUsu;
        public string cargo;

        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        public frmMenuPrincipal(string cargo, string nome, int codUsu)
        {
            InitializeComponent();
            this.nome = nome;
            this.codUsu = codUsu;
            this.cargo = cargo;
            if (cargo == "Voluntário")
            {
                btnCadastrarlivros.Enabled = false;
                btnCadastrausuario.Enabled = false;
                btnRelatorio.Enabled = false;
            }else if(cargo == "Dirigente")
            {
                btnRelatorio.Enabled = false;
                btnCadastrausuario.Enabled = false;
            }
        }

        private void btnEmprestimo_Click(object sender, EventArgs e)
        {
            frmEmprestimo abrir = new frmEmprestimo(nome, codUsu, cargo);
            abrir.Show();
            this.Hide();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            frmVender abrir = new frmVender(nome, codUsu, cargo); 
            abrir.Show();
            this.Hide();
        }

        private void btnCadastroLocatario_Click(object sender, EventArgs e)
        {
            frmCadastroLocatario abrir = new frmCadastroLocatario(nome, codUsu, cargo);
            abrir.Show();
            this.Hide();
        }

        private void btnCadastrarlivros_Click(object sender, EventArgs e)
        {
            frmCadastroLivrosAlugar abrir = new frmCadastroLivrosAlugar (nome, codUsu, cargo); 
            abrir.Show();
            this.Hide();
        }

        private void btnCadastrausuario_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario abrir = new frmCadastroUsuario(nome, codUsu, cargo);
            abrir.Show();
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            frmLogin abrir = new frmLogin();
            abrir.Show();
            this.Hide();

        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            frmRelatorio abrir = new frmRelatorio(nome, codUsu, cargo);
            abrir.Show();
            this.Hide();
        }

        private void btnBuscarlivros_Click(object sender, EventArgs e)
        {
            frmBuscarLivro abrir = new frmBuscarLivro(this.nome, this.codUsu, this.cargo, "Menu");
            abrir.Show();
            this.Hide();
        }
    }
}
