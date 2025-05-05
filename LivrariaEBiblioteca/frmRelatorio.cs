using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        public string nomeRelatorio;
        public string data1;
        public string data2;

        DataGridViewPrinter dgvPrinter;
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
            data1 = DateTime.MinValue.ToString("dd/MM/yyyy");
            data2 = DateTime.Now.ToString("dd/MM/yyyy");

            mskDataEntre.Text = data1;
            mskDataAte.Text = data2;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal(this.cargo, this.nome, this.codUsu);
            abrir.Show();
            this.Hide();
        }

        private void btnListaLivros_Click(object sender, EventArgs e)
        {
            nomeRelatorio = "Lista de Livros";
            MySqlCommand comm = new MySqlCommand();

            data1 = mskDataEntre.Text;
            data2 = mskDataAte.Text;

            comm.CommandText = "select codLivro as 'ID do livro', empVen as 'Tipo', isbn as 'ISBN', nome as 'Titulo', autor as 'Autor', quant as 'Quantidade', valor as 'Valor', editora as 'Editora', anoPublicacao as 'Ano de publicacao', dataCadastro as 'Data de registro' from tbLivro where dataCadastro between @dataCadastro1 and @dataCadastro2;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@dataCadastro1", DateTime.Parse(data1));
            comm.Parameters.AddWithValue("@dataCadastro2", DateTime.Parse(data2));

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvRelatorio.RowCount; i++)
            {
                dgvRelatorio.Rows[i].DataGridView.Columns.Clear();
                mskDataEntre.Clear();
                mskDataAte.Clear();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            nomeRelatorio = "Lista de Usuários";
            MySqlCommand comm = new MySqlCommand();

            data1 = mskDataEntre.Text;
            data2 = mskDataAte.Text;

            comm.CommandText = "select codUsu as 'ID do usuario', nome as 'Nome', cargo as 'Cargo', cpf as 'CPF', diaTrabalho as 'Dia de trabalho', telCel as 'Telefone', login as 'Login', email as 'E-mail', cep as 'CEP', logradouro as 'Endereco', numero as 'Numero', complemento as 'Complemento', bairro as 'Bairro', cidade as 'Cidade', estado as 'Estado', dataCadastro as 'Data de registro' from tbUsuario where dataCadastro between @dataCadastro1 and @dataCadastro2;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@dataCadastro1", DateTime.Parse(data1));
            comm.Parameters.AddWithValue("@dataCadastro2", DateTime.Parse(data2));

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnLocatarios_Click(object sender, EventArgs e)
        {
            nomeRelatorio = "Lista de Locatários";
            MySqlCommand comm = new MySqlCommand();
            data1 = mskDataEntre.Text;
            data2 = mskDataAte.Text;

            comm.CommandText = "select codLoc as 'ID do Locatario', pront as 'Prontuario', nome as 'Nome', cpf as 'CPF', telCel as 'Telefone', email as 'E-mail', dataCadastro as 'Data de registro' from tbLocatario;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@dataCadastro1", DateTime.Parse(data1));
            comm.Parameters.AddWithValue("@dataCadastro2", DateTime.Parse(data2));

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            nomeRelatorio = "Relatório de Vendas";
            MySqlCommand comm = new MySqlCommand();
            data1 = mskDataEntre.Text;
            data2 = mskDataAte.Text;

            comm.CommandText = "select codVenda as 'Numero de venda', dataVenda as 'Data da venda', nomeLivro as 'Titulo', valorTotal as 'Valor da venda', pagamento as 'Forma de pagamento', nomeVendedor as 'Nome do vendedor' from tbVendas where dataCadastro between @dataCadastro1 and @dataCadastro2;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@dataCadastro1", DateTime.Parse(data1));
            comm.Parameters.AddWithValue("@dataCadastro2", DateTime.Parse(data2));
            
            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnEmprestimos_Click(object sender, EventArgs e)
        {
            nomeRelatorio = "Relatório de Empréstimos";
            MySqlCommand comm = new MySqlCommand();
            data1 = mskDataEntre.Text;
            data2 = mskDataAte.Text;
            
            comm.CommandText = "select codEmp as 'Numero de emprestimo', dataEmp as 'Data de emprestimo', dataDev as 'Data de devolucao', nomeVendedor as 'Nome do caixa', nomeLivro as 'Titulo', prontuario as 'Prontuario' from tbEmprestimo where dataCadastro between @dataCadastro1 and @dataCadastro2;";
            comm.CommandType = CommandType.Text;
            

            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@dataCadastro1", DateTime.Parse(data1));
            comm.Parameters.AddWithValue("@dataCadastro2", DateTime.Parse(data2));

            comm.Connection = Conexao.obterConexao();

            MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvRelatorio.DataSource = dataTable;

            Conexao.fecharConexao();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            nomeRelatorio = "Dados do Estoque";
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
            if (SetupThePrinting())
            {
                pdcRelatorio.Print();
            }
        }

        private void prdRelatorio_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = dgvPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
            {
                e.HasMorePages = true;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();

            if (dgvRelatorio.Rows.Count > 0)
            {
                try
                {
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < dgvRelatorio.Columns.Count + 1; i++)
                    {
                        xcelApp.Cells[1, i] = dgvRelatorio.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvRelatorio.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dgvRelatorio.Columns.Count; j++)
                        {
                            xcelApp.Cells[i + 2, j + 1] = dgvRelatorio.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    xcelApp.Columns.AutoFit();

                    xcelApp.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao exportar arquivo para Excel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    xcelApp.Quit();
                }
            }
        }
        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            pdcRelatorio.DocumentName = nomeRelatorio;
            pdcRelatorio.PrinterSettings = MyPrintDialog.PrinterSettings;
            pdcRelatorio.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            pdcRelatorio.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Deseja que o relatório esteja centralizado?", "Pergunta - Centralizar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgvPrinter = new DataGridViewPrinter(dgvRelatorio, pdcRelatorio, true, true, nomeRelatorio, new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgvPrinter = new DataGridViewPrinter(dgvRelatorio, pdcRelatorio, false, true, nomeRelatorio, new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }
    }
}
