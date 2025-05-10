namespace LivrariaEBiblioteca
{
    partial class frmRelatorio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatorio));
            this.dgvRelatorio = new System.Windows.Forms.DataGridView();
            this.tlpRelatorios = new System.Windows.Forms.TableLayoutPanel();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.btnEmprestimos = new System.Windows.Forms.Button();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnLocatarios = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnListaLivros = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.pdcRelatorio = new System.Drawing.Printing.PrintDocument();
            this.pdiaRelatorio = new System.Windows.Forms.PrintDialog();
            this.lblRelatorio = new System.Windows.Forms.Label();
            this.lblEntre = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.mskDataEntre = new System.Windows.Forms.MaskedTextBox();
            this.mskDataAte = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).BeginInit();
            this.tlpRelatorios.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRelatorio
            // 
            this.dgvRelatorio.AllowUserToAddRows = false;
            this.dgvRelatorio.AllowUserToDeleteRows = false;
            this.dgvRelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRelatorio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelatorio.BackgroundColor = System.Drawing.Color.Teal;
            this.dgvRelatorio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRelatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatorio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRelatorio.Location = new System.Drawing.Point(12, 105);
            this.dgvRelatorio.Name = "dgvRelatorio";
            this.dgvRelatorio.Size = new System.Drawing.Size(602, 409);
            this.dgvRelatorio.TabIndex = 0;
            // 
            // tlpRelatorios
            // 
            this.tlpRelatorios.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpRelatorios.ColumnCount = 1;
            this.tlpRelatorios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRelatorios.Controls.Add(this.btnEstoque, 0, 5);
            this.tlpRelatorios.Controls.Add(this.btnEmprestimos, 0, 4);
            this.tlpRelatorios.Controls.Add(this.btnVendas, 0, 3);
            this.tlpRelatorios.Controls.Add(this.btnLocatarios, 0, 2);
            this.tlpRelatorios.Controls.Add(this.btnUsuarios, 0, 1);
            this.tlpRelatorios.Controls.Add(this.btnListaLivros, 0, 0);
            this.tlpRelatorios.Controls.Add(this.btnVoltar, 0, 6);
            this.tlpRelatorios.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlpRelatorios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpRelatorios.Location = new System.Drawing.Point(620, 0);
            this.tlpRelatorios.Name = "tlpRelatorios";
            this.tlpRelatorios.RowCount = 7;
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.Size = new System.Drawing.Size(180, 600);
            this.tlpRelatorios.TabIndex = 4;
            // 
            // btnEstoque
            // 
            this.btnEstoque.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstoque.Image = ((System.Drawing.Image)(resources.GetObject("btnEstoque.Image")));
            this.btnEstoque.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEstoque.Location = new System.Drawing.Point(3, 428);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(174, 79);
            this.btnEstoque.TabIndex = 10;
            this.btnEstoque.Text = "&Dados do estoque";
            this.btnEstoque.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEstoque.UseVisualStyleBackColor = false;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            // 
            // btnEmprestimos
            // 
            this.btnEmprestimos.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEmprestimos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEmprestimos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmprestimos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmprestimos.Image = ((System.Drawing.Image)(resources.GetObject("btnEmprestimos.Image")));
            this.btnEmprestimos.Location = new System.Drawing.Point(3, 343);
            this.btnEmprestimos.Name = "btnEmprestimos";
            this.btnEmprestimos.Size = new System.Drawing.Size(174, 79);
            this.btnEmprestimos.TabIndex = 9;
            this.btnEmprestimos.Text = "Relatorio de &empréstimos";
            this.btnEmprestimos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmprestimos.UseVisualStyleBackColor = false;
            this.btnEmprestimos.Click += new System.EventHandler(this.btnEmprestimos_Click);
            // 
            // btnVendas
            // 
            this.btnVendas.BackColor = System.Drawing.Color.PowderBlue;
            this.btnVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendas.Image = ((System.Drawing.Image)(resources.GetObject("btnVendas.Image")));
            this.btnVendas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVendas.Location = new System.Drawing.Point(3, 258);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(174, 79);
            this.btnVendas.TabIndex = 8;
            this.btnVendas.Text = "&Relatório de vendas";
            this.btnVendas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVendas.UseVisualStyleBackColor = false;
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);
            // 
            // btnLocatarios
            // 
            this.btnLocatarios.BackColor = System.Drawing.Color.PowderBlue;
            this.btnLocatarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLocatarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocatarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocatarios.Image = ((System.Drawing.Image)(resources.GetObject("btnLocatarios.Image")));
            this.btnLocatarios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocatarios.Location = new System.Drawing.Point(3, 173);
            this.btnLocatarios.Name = "btnLocatarios";
            this.btnLocatarios.Size = new System.Drawing.Size(174, 79);
            this.btnLocatarios.TabIndex = 7;
            this.btnLocatarios.Text = "Lista de l&ocatários";
            this.btnLocatarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLocatarios.UseVisualStyleBackColor = false;
            this.btnLocatarios.Click += new System.EventHandler(this.btnLocatarios_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.PowderBlue;
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsuarios.Location = new System.Drawing.Point(3, 88);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(174, 79);
            this.btnUsuarios.TabIndex = 6;
            this.btnUsuarios.Text = "Lista de &usuários";
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnListaLivros
            // 
            this.btnListaLivros.BackColor = System.Drawing.Color.PowderBlue;
            this.btnListaLivros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnListaLivros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListaLivros.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaLivros.Image = ((System.Drawing.Image)(resources.GetObject("btnListaLivros.Image")));
            this.btnListaLivros.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListaLivros.Location = new System.Drawing.Point(3, 3);
            this.btnListaLivros.Name = "btnListaLivros";
            this.btnListaLivros.Size = new System.Drawing.Size(174, 79);
            this.btnListaLivros.TabIndex = 5;
            this.btnListaLivros.Text = "&Lista de livros";
            this.btnListaLivros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListaLivros.UseVisualStyleBackColor = false;
            this.btnListaLivros.Click += new System.EventHandler(this.btnListaLivros_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnVoltar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.Location = new System.Drawing.Point(3, 513);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(174, 84);
            this.btnVoltar.TabIndex = 11;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.PowderBlue;
            this.btnImprimir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.Location = new System.Drawing.Point(3, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(200, 74);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnExportar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLimpar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImprimir, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 520);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 80);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnExportar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(209, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(200, 74);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "E&xportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnLimpar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.Location = new System.Drawing.Point(415, 3);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(202, 74);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "Li&mpar";
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // pdcRelatorio
            // 
            this.pdcRelatorio.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prdRelatorio_PrintPage);
            // 
            // pdiaRelatorio
            // 
            this.pdiaRelatorio.UseEXDialog = true;
            // 
            // lblRelatorio
            // 
            this.lblRelatorio.AutoSize = true;
            this.lblRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelatorio.Location = new System.Drawing.Point(24, 19);
            this.lblRelatorio.Name = "lblRelatorio";
            this.lblRelatorio.Size = new System.Drawing.Size(153, 37);
            this.lblRelatorio.TabIndex = 5;
            this.lblRelatorio.Text = "Relatório";
            // 
            // lblEntre
            // 
            this.lblEntre.AutoSize = true;
            this.lblEntre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntre.Location = new System.Drawing.Point(12, 71);
            this.lblEntre.Name = "lblEntre";
            this.lblEntre.Size = new System.Drawing.Size(75, 25);
            this.lblEntre.TabIndex = 6;
            this.lblEntre.Text = "Entre: ";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.Location = new System.Drawing.Point(239, 71);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(32, 25);
            this.lblAte.TabIndex = 7;
            this.lblAte.Text = "E:";
            // 
            // mskDataEntre
            // 
            this.mskDataEntre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataEntre.Location = new System.Drawing.Point(93, 68);
            this.mskDataEntre.Mask = "00/00/0000";
            this.mskDataEntre.Name = "mskDataEntre";
            this.mskDataEntre.Size = new System.Drawing.Size(130, 31);
            this.mskDataEntre.TabIndex = 8;
            this.mskDataEntre.ValidatingType = typeof(System.DateTime);
            // 
            // mskDataAte
            // 
            this.mskDataAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataAte.Location = new System.Drawing.Point(277, 68);
            this.mskDataAte.Mask = "00/00/0000";
            this.mskDataAte.Name = "mskDataAte";
            this.mskDataAte.Size = new System.Drawing.Size(130, 31);
            this.mskDataAte.TabIndex = 9;
            this.mskDataAte.ValidatingType = typeof(System.DateTime);
            // 
            // frmRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.mskDataAte);
            this.Controls.Add(this.mskDataEntre);
            this.Controls.Add(this.lblAte);
            this.Controls.Add(this.lblEntre);
            this.Controls.Add(this.lblRelatorio);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tlpRelatorios);
            this.Controls.Add(this.dgvRelatorio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O Semeador - Relatório";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).EndInit();
            this.tlpRelatorios.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRelatorio;
        private System.Windows.Forms.TableLayoutPanel tlpRelatorios;
        private System.Windows.Forms.Button btnLocatarios;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnListaLivros;
        private System.Windows.Forms.Button btnVendas;
        private System.Windows.Forms.Button btnEmprestimos;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnEstoque;
        private System.Drawing.Printing.PrintDocument pdcRelatorio;
        private System.Windows.Forms.PrintDialog pdiaRelatorio;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblRelatorio;
        private System.Windows.Forms.Label lblEntre;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mskDataEntre;
        private System.Windows.Forms.MaskedTextBox mskDataAte;
    }
}