namespace LivrariaEBiblioteca
{
    partial class frmDevolucao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevolucao));
            this.lblBuscarLivro = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEmprestimo = new System.Windows.Forms.Button();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.gpbDadosLivro = new System.Windows.Forms.GroupBox();
            this.lblIdLivro = new System.Windows.Forms.Label();
            this.lblEditora = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblIsbn = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.txtIdLivro = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtEditora = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtIsbn = new System.Windows.Forms.TextBox();
            this.ltbCarrinho = new System.Windows.Forms.ListBox();
            this.pctLivro = new System.Windows.Forms.PictureBox();
            this.dtpDataEmprestimo = new System.Windows.Forms.DateTimePicker();
            this.txtProntuario = new System.Windows.Forms.TextBox();
            this.lblNEmprestimo = new System.Windows.Forms.Label();
            this.lblDataDevolucao = new System.Windows.Forms.Label();
            this.lblDataEmprestimo = new System.Windows.Forms.Label();
            this.txtNomeLoc = new System.Windows.Forms.TextBox();
            this.lblLocatario = new System.Windows.Forms.Label();
            this.dtpDevolucao = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gpbDadosLivro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLivro)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBuscarLivro
            // 
            this.lblBuscarLivro.AutoSize = true;
            this.lblBuscarLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarLivro.Location = new System.Drawing.Point(24, 19);
            this.lblBuscarLivro.Name = "lblBuscarLivro";
            this.lblBuscarLivro.Size = new System.Drawing.Size(176, 37);
            this.lblBuscarLivro.TabIndex = 55;
            this.lblBuscarLivro.Text = "Devolução";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btnEmprestimo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnVender, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnVoltar, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(257, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(543, 67);
            this.tableLayoutPanel2.TabIndex = 56;
            // 
            // btnEmprestimo
            // 
            this.btnEmprestimo.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEmprestimo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEmprestimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmprestimo.Image = ((System.Drawing.Image)(resources.GetObject("btnEmprestimo.Image")));
            this.btnEmprestimo.Location = new System.Drawing.Point(184, 3);
            this.btnEmprestimo.Name = "btnEmprestimo";
            this.btnEmprestimo.Size = new System.Drawing.Size(175, 61);
            this.btnEmprestimo.TabIndex = 13;
            this.btnEmprestimo.Text = "&Empréstimo";
            this.btnEmprestimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmprestimo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmprestimo.UseVisualStyleBackColor = false;
            // 
            // btnVender
            // 
            this.btnVender.BackColor = System.Drawing.Color.PowderBlue;
            this.btnVender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVender.Image = ((System.Drawing.Image)(resources.GetObject("btnVender.Image")));
            this.btnVender.Location = new System.Drawing.Point(3, 3);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(175, 61);
            this.btnVender.TabIndex = 0;
            this.btnVender.Text = "V&ender";
            this.btnVender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVender.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVender.UseVisualStyleBackColor = false;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnVoltar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.Location = new System.Drawing.Point(365, 3);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(175, 61);
            this.btnVoltar.TabIndex = 12;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnBuscar, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRemover, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLimpar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFinalizar, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 520);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 80);
            this.tableLayoutPanel1.TabIndex = 57;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(603, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(194, 74);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.Color.PowderBlue;
            this.btnRemover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.Image = ((System.Drawing.Image)(resources.GetObject("btnRemover.Image")));
            this.btnRemover.Location = new System.Drawing.Point(3, 3);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(194, 74);
            this.btnRemover.TabIndex = 9;
            this.btnRemover.Text = "&Remover";
            this.btnRemover.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemover.UseVisualStyleBackColor = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnLimpar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.Location = new System.Drawing.Point(203, 3);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(194, 74);
            this.btnLimpar.TabIndex = 10;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnFinalizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnFinalizar.Image")));
            this.btnFinalizar.Location = new System.Drawing.Point(403, 3);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(194, 74);
            this.btnFinalizar.TabIndex = 11;
            this.btnFinalizar.Text = "&Finalizar";
            this.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // gpbDadosLivro
            // 
            this.gpbDadosLivro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbDadosLivro.Controls.Add(this.lblIdLivro);
            this.gpbDadosLivro.Controls.Add(this.lblEditora);
            this.gpbDadosLivro.Controls.Add(this.lblTitulo);
            this.gpbDadosLivro.Controls.Add(this.lblIsbn);
            this.gpbDadosLivro.Controls.Add(this.lblAutor);
            this.gpbDadosLivro.Controls.Add(this.txtIdLivro);
            this.gpbDadosLivro.Controls.Add(this.txtAutor);
            this.gpbDadosLivro.Controls.Add(this.txtEditora);
            this.gpbDadosLivro.Controls.Add(this.txtTitulo);
            this.gpbDadosLivro.Controls.Add(this.txtIsbn);
            this.gpbDadosLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbDadosLivro.Location = new System.Drawing.Point(167, 74);
            this.gpbDadosLivro.Name = "gpbDadosLivro";
            this.gpbDadosLivro.Size = new System.Drawing.Size(324, 272);
            this.gpbDadosLivro.TabIndex = 60;
            this.gpbDadosLivro.TabStop = false;
            this.gpbDadosLivro.Text = "Dados do livro";
            // 
            // lblIdLivro
            // 
            this.lblIdLivro.AutoSize = true;
            this.lblIdLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdLivro.Location = new System.Drawing.Point(6, 31);
            this.lblIdLivro.Name = "lblIdLivro";
            this.lblIdLivro.Size = new System.Drawing.Size(112, 25);
            this.lblIdLivro.TabIndex = 0;
            this.lblIdLivro.Text = "Id do Livro";
            // 
            // lblEditora
            // 
            this.lblEditora.AutoSize = true;
            this.lblEditora.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditora.Location = new System.Drawing.Point(6, 205);
            this.lblEditora.Name = "lblEditora";
            this.lblEditora.Size = new System.Drawing.Size(80, 25);
            this.lblEditora.TabIndex = 0;
            this.lblEditora.Text = "Editora";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(6, 89);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(65, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título";
            // 
            // lblIsbn
            // 
            this.lblIsbn.AutoSize = true;
            this.lblIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsbn.Location = new System.Drawing.Point(176, 31);
            this.lblIsbn.Name = "lblIsbn";
            this.lblIsbn.Size = new System.Drawing.Size(60, 25);
            this.lblIsbn.TabIndex = 0;
            this.lblIsbn.Text = "ISBN";
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutor.Location = new System.Drawing.Point(6, 147);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(63, 25);
            this.lblAutor.TabIndex = 0;
            this.lblAutor.Text = "Autor";
            // 
            // txtIdLivro
            // 
            this.txtIdLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdLivro.Location = new System.Drawing.Point(6, 57);
            this.txtIdLivro.MaxLength = 20;
            this.txtIdLivro.Name = "txtIdLivro";
            this.txtIdLivro.Size = new System.Drawing.Size(135, 31);
            this.txtIdLivro.TabIndex = 2;
            // 
            // txtAutor
            // 
            this.txtAutor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAutor.Enabled = false;
            this.txtAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutor.Location = new System.Drawing.Point(6, 173);
            this.txtAutor.MaxLength = 100;
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(305, 31);
            this.txtAutor.TabIndex = 4;
            // 
            // txtEditora
            // 
            this.txtEditora.Enabled = false;
            this.txtEditora.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditora.Location = new System.Drawing.Point(6, 231);
            this.txtEditora.MaxLength = 50;
            this.txtEditora.Name = "txtEditora";
            this.txtEditora.Size = new System.Drawing.Size(305, 31);
            this.txtEditora.TabIndex = 5;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitulo.Enabled = false;
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(6, 115);
            this.txtTitulo.MaxLength = 100;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(305, 31);
            this.txtTitulo.TabIndex = 3;
            // 
            // txtIsbn
            // 
            this.txtIsbn.Enabled = false;
            this.txtIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIsbn.Location = new System.Drawing.Point(176, 59);
            this.txtIsbn.MaxLength = 20;
            this.txtIsbn.Name = "txtIsbn";
            this.txtIsbn.Size = new System.Drawing.Size(135, 31);
            this.txtIsbn.TabIndex = 1;
            // 
            // ltbCarrinho
            // 
            this.ltbCarrinho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltbCarrinho.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbCarrinho.FormattingEnabled = true;
            this.ltbCarrinho.ItemHeight = 25;
            this.ltbCarrinho.Location = new System.Drawing.Point(31, 351);
            this.ltbCarrinho.Name = "ltbCarrinho";
            this.ltbCarrinho.Size = new System.Drawing.Size(733, 154);
            this.ltbCarrinho.TabIndex = 59;
            this.ltbCarrinho.SelectedIndexChanged += new System.EventHandler(this.ltbCarrinho_SelectedIndexChanged);
            // 
            // pctLivro
            // 
            this.pctLivro.Location = new System.Drawing.Point(31, 105);
            this.pctLivro.Name = "pctLivro";
            this.pctLivro.Size = new System.Drawing.Size(130, 182);
            this.pctLivro.TabIndex = 58;
            this.pctLivro.TabStop = false;
            // 
            // dtpDataEmprestimo
            // 
            this.dtpDataEmprestimo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataEmprestimo.Enabled = false;
            this.dtpDataEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataEmprestimo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEmprestimo.Location = new System.Drawing.Point(497, 247);
            this.dtpDataEmprestimo.Name = "dtpDataEmprestimo";
            this.dtpDataEmprestimo.Size = new System.Drawing.Size(155, 31);
            this.dtpDataEmprestimo.TabIndex = 68;
            // 
            // txtProntuario
            // 
            this.txtProntuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProntuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProntuario.Location = new System.Drawing.Point(497, 131);
            this.txtProntuario.MaxLength = 100;
            this.txtProntuario.Name = "txtProntuario";
            this.txtProntuario.Size = new System.Drawing.Size(267, 31);
            this.txtProntuario.TabIndex = 66;
            this.txtProntuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocatario_KeyDown);
            // 
            // lblNEmprestimo
            // 
            this.lblNEmprestimo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNEmprestimo.AutoSize = true;
            this.lblNEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNEmprestimo.Location = new System.Drawing.Point(497, 163);
            this.lblNEmprestimo.Name = "lblNEmprestimo";
            this.lblNEmprestimo.Size = new System.Drawing.Size(68, 25);
            this.lblNEmprestimo.TabIndex = 61;
            this.lblNEmprestimo.Text = "Nome";
            // 
            // lblDataDevolucao
            // 
            this.lblDataDevolucao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataDevolucao.AutoSize = true;
            this.lblDataDevolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataDevolucao.Location = new System.Drawing.Point(497, 279);
            this.lblDataDevolucao.Name = "lblDataDevolucao";
            this.lblDataDevolucao.Size = new System.Drawing.Size(195, 25);
            this.lblDataDevolucao.TabIndex = 62;
            this.lblDataDevolucao.Text = "Data de Devolução";
            // 
            // lblDataEmprestimo
            // 
            this.lblDataEmprestimo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataEmprestimo.AutoSize = true;
            this.lblDataEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataEmprestimo.Location = new System.Drawing.Point(497, 221);
            this.lblDataEmprestimo.Name = "lblDataEmprestimo";
            this.lblDataEmprestimo.Size = new System.Drawing.Size(206, 25);
            this.lblDataEmprestimo.TabIndex = 63;
            this.lblDataEmprestimo.Text = "Data de Empréstimo";
            // 
            // txtNomeLoc
            // 
            this.txtNomeLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeLoc.Enabled = false;
            this.txtNomeLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeLoc.Location = new System.Drawing.Point(497, 189);
            this.txtNomeLoc.Name = "txtNomeLoc";
            this.txtNomeLoc.Size = new System.Drawing.Size(267, 31);
            this.txtNomeLoc.TabIndex = 65;
            // 
            // lblLocatario
            // 
            this.lblLocatario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocatario.AutoSize = true;
            this.lblLocatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocatario.Location = new System.Drawing.Point(497, 105);
            this.lblLocatario.Name = "lblLocatario";
            this.lblLocatario.Size = new System.Drawing.Size(111, 25);
            this.lblLocatario.TabIndex = 64;
            this.lblLocatario.Text = "Prontuário";
            // 
            // dtpDevolucao
            // 
            this.dtpDevolucao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDevolucao.Enabled = false;
            this.dtpDevolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDevolucao.Location = new System.Drawing.Point(497, 305);
            this.dtpDevolucao.Name = "dtpDevolucao";
            this.dtpDevolucao.Size = new System.Drawing.Size(155, 31);
            this.dtpDevolucao.TabIndex = 69;
            // 
            // frmDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dtpDevolucao);
            this.Controls.Add(this.dtpDataEmprestimo);
            this.Controls.Add(this.txtProntuario);
            this.Controls.Add(this.lblNEmprestimo);
            this.Controls.Add(this.lblDataDevolucao);
            this.Controls.Add(this.lblDataEmprestimo);
            this.Controls.Add(this.txtNomeLoc);
            this.Controls.Add(this.lblLocatario);
            this.Controls.Add(this.gpbDadosLivro);
            this.Controls.Add(this.ltbCarrinho);
            this.Controls.Add(this.pctLivro);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.lblBuscarLivro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmDevolucao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O Semeador - Devolução";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gpbDadosLivro.ResumeLayout(false);
            this.gpbDadosLivro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLivro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBuscarLivro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnEmprestimo;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.GroupBox gpbDadosLivro;
        private System.Windows.Forms.Label lblIdLivro;
        private System.Windows.Forms.Label lblEditora;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIsbn;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.TextBox txtIdLivro;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtEditora;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.ListBox ltbCarrinho;
        private System.Windows.Forms.PictureBox pctLivro;
        private System.Windows.Forms.DateTimePicker dtpDataEmprestimo;
        private System.Windows.Forms.TextBox txtProntuario;
        private System.Windows.Forms.Label lblNEmprestimo;
        private System.Windows.Forms.Label lblDataDevolucao;
        private System.Windows.Forms.Label lblDataEmprestimo;
        private System.Windows.Forms.TextBox txtNomeLoc;
        private System.Windows.Forms.Label lblLocatario;
        private System.Windows.Forms.DateTimePicker dtpDevolucao;
        private System.Windows.Forms.Button btnRemover;
    }
}