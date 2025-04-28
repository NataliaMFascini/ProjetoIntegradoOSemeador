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
            frmMenuPrincipal abrir = new frmMenuPrincipal(this.cargo, this.nome, this.codUsu);
            abrir.Show();
            this.Hide();
        }

        private void btnListaLivros_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select empVen as 'Tipo', isbn as 'ISBN', nome as 'Titulo', autor as 'Autor', quant as 'Quantidade', valor as 'Valor', editora as 'Editora', anoPublicacao as 'Ano de publicacao', dataCadastro as 'Data de registro' from tbLivro;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            for(int i =0; i < dgvRelatorio.RowCount; i++)
            {
                dgvRelatorio.Rows[i].DataGridView.Columns.Clear();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select nome as 'Nome', cargo as 'Cargo', cpf as 'CPF', diaTrabalho as 'Dia de trabalho', telCel as 'Telefone', login as 'Login', email as 'E-mail', cep as 'CEP', logradouro as 'Endereco', numero as 'Numero', complemento as 'Complemento', bairro as 'Bairro', cidade as 'Cidade', estado as 'Estado', dataCadastro as 'Data de registro' from tbUsuario;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnLocatarios_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select pront as 'Prontuario', nome as 'Nome', cpf as 'CPF', telCel as 'Telefone', email as 'E-mail', dataCadastro as 'Data de registro' from tbLocatario;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select codVenda as 'Numero de venda', dataVenda as 'Data da venda', nomeLivro as 'Titulo', valorTotal as 'Valor da venda', pagamento as 'Forma de pagamento', nomeVendedor as 'Nome do vendedor' from tbVendas;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnEmprestimos_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select dataEmp as 'Data de emprestimo', dataDev as 'Data de devolucao', nomeVendedor as 'Nome do caixa', nomeLivro as 'Titulo', prontuario as 'Prontuario' from tbEmprestimo;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select empVen as 'Tipo', nomeLivro as 'Titulo', entradaVen as 'Entrada de vendas', saidaVen as 'Saida de vendas', entradaEmp as 'Entrada de emprestimos', saidaEmp as 'Saida de emprestimos' from tbEstoque;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pdcRelatorio;
            printDialog.UseEXDialog = true;

            if(DialogResult.OK == printDialog.ShowDialog())
            {
                pdcRelatorio.Print();
            }

        }

        private void prdRelatorio_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.dgvRelatorio.Width, this.dgvRelatorio.Height);
            dgvRelatorio.DrawToBitmap(bmp, new Rectangle(0, 0, this.dgvRelatorio.Width, this.dgvRelatorio.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
