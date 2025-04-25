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
            this.btnEmprestimos = new System.Windows.Forms.Button();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnLocatarios = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnListaLivros = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnEstoque = new System.Windows.Forms.Button();
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
            this.dgvRelatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatorio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRelatorio.Location = new System.Drawing.Point(12, 12);
            this.dgvRelatorio.Name = "dgvRelatorio";
            this.dgvRelatorio.Size = new System.Drawing.Size(583, 463);
            this.dgvRelatorio.TabIndex = 0;
            // 
            // tlpRelatorios
            // 
            this.tlpRelatorios.AutoSize = true;
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
            this.tlpRelatorios.Location = new System.Drawing.Point(628, 0);
            this.tlpRelatorios.Name = "tlpRelatorios";
            this.tlpRelatorios.RowCount = 7;
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpRelatorios.Size = new System.Drawing.Size(156, 561);
            this.tlpRelatorios.TabIndex = 1;
            // 
            this.btnVendas.AutoSize = true;
            this.btnVendas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnVendas.ColumnCount = 1;
            this.btnVendas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.btnVendas.Controls.Add(this.btnEmprestimos, 0, 4);
            this.btnVendas.Controls.Add(this.btnUsuarios, 0, 1);
            this.btnVendas.Controls.Add(this.btnListaLivros, 0, 0);
            this.btnVendas.Controls.Add(this.btnLocatarios, 0, 3);
            this.btnVendas.Controls.Add(this.button1, 0, 2);
            this.btnVendas.Controls.Add(this.btnVoltar, 0, 6);
            this.btnVendas.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendas.Location = new System.Drawing.Point(598, 0);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.RowCount = 7;
            this.btnVendas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.btnVendas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.btnVendas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.btnVendas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.btnVendas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.btnVendas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.btnVendas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.btnVendas.Size = new System.Drawing.Size(186, 561);
            this.btnVendas.TabIndex = 1;
            // 
            // btnEmprestimos
            // 
            this.btnEmprestimos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEmprestimos.Location = new System.Drawing.Point(3, 323);
            this.btnEmprestimos.Name = "btnEmprestimos";
            this.btnEmprestimos.Size = new System.Drawing.Size(150, 74);
            this.btnEmprestimos.Image = ((System.Drawing.Image)(resources.GetObject("btnEmprestimos.Image")));
            this.btnEmprestimos.TabIndex = 6;
            this.btnEmprestimos.Text = "Relatorio de &empréstimos";
            this.btnEmprestimos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmprestimos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmprestimos.UseVisualStyleBackColor = true;
            this.btnEmprestimos.Click += new System.EventHandler(this.btnEmprestimos_Click);
            // 
            // btnVendas
            // 
            this.btnVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVendas.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.btnVendas.Location = new System.Drawing.Point(3, 243);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(150, 74);
            this.btnVendas.TabIndex = 5;
            this.btnVendas.Text = "&Relatório de vendas";
            this.btnVendas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVendas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVendas.UseVisualStyleBackColor = true;
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);
            // 
            // btnLocatarios
            // 
            this.btnLocatarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLocatarios.Location = new System.Drawing.Point(3, 163);
            this.btnLocatarios.Name = "btnLocatarios";
            this.btnLocatarios.Size = new System.Drawing.Size(150, 74);
            this.btnLocatarios.Image = ((System.Drawing.Image)(resources.GetObject("btnLocatarios.Image")));
            this.btnLocatarios.TabIndex = 4;
            this.btnLocatarios.Text = "Lista de &locatários";
            this.btnLocatarios.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLocatarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLocatarios.UseVisualStyleBackColor = true;
            this.btnLocatarios.Click += new System.EventHandler(this.btnLocatarios_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUsuarios.Location = new System.Drawing.Point(3, 83);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(150, 74);
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "Lista de &usuários";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnListaLivros
            // 
            this.btnListaLivros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnListaLivros.Location = new System.Drawing.Point(3, 3);
            this.btnListaLivros.Name = "btnListaLivros";
            this.btnListaLivros.Size = new System.Drawing.Size(150, 74);
            this.btnListaLivros.TabIndex = 2;
            this.btnListaLivros.Text = "&Lista de livros";
            this.btnListaLivros.Image = ((System.Drawing.Image)(resources.GetObject("btnListaLivros.Image")));
            this.btnListaLivros.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnListaLivros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListaLivros.UseVisualStyleBackColor = true;
            this.btnListaLivros.Click += new System.EventHandler(this.btnListaLivros_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.Location = new System.Drawing.Point(3, 483);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(150, 75);
            this.btnVoltar.TabIndex = 10;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(3, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(209, 74);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel1.Controls.Add(this.btnLimpar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImprimir, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExportar, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 481);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 80);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpar.Location = new System.Drawing.Point(433, 3);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(192, 74);
            this.btnLimpar.TabIndex = 10;
            this.btnLimpar.Text = "Li&mpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportar.Location = new System.Drawing.Point(218, 3);
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(209, 74);
            this.btnExportar.TabIndex = 9;
            this.btnExportar.Text = "&Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // btnEstoque
            // 
            this.btnEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEstoque.Location = new System.Drawing.Point(3, 403);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(150, 74);
            this.btnEstoque.TabIndex = 11;
            this.btnEstoque.Text = "&Dados do estoque";
            this.btnEstoque.UseVisualStyleBackColor = true;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            // 
            // frmRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tlpRelatorios);
            this.Controls.Add(this.dgvRelatorio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O Semeador - Relatório";
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
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnEstoque;
    }
}