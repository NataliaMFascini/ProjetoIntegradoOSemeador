namespace LivrariaEBiblioteca
{
    partial class frmEmprestimo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmprestimo));
            this.lblIdLivro = new System.Windows.Forms.Label();
            this.btnVender = new System.Windows.Forms.Button();
            this.txtIdLivro = new System.Windows.Forms.TextBox();
            this.pctLivro = new System.Windows.Forms.PictureBox();
            this.ltbCarrinho = new System.Windows.Forms.ListBox();
            this.lblIsbn = new System.Windows.Forms.Label();
            this.txtIsbn = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblAutor = new System.Windows.Forms.Label();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.lblEditora = new System.Windows.Forms.Label();
            this.lblLocatario = new System.Windows.Forms.Label();
            this.txtEditora = new System.Windows.Forms.TextBox();
            this.txtLocatario = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblDataEmprestimo = new System.Windows.Forms.Label();
            this.lblDataDevolucao = new System.Windows.Forms.Label();
            this.dtpDataEmprestimo = new System.Windows.Forms.DateTimePicker();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.mskDataDevolucao = new System.Windows.Forms.MaskedTextBox();
            this.lblDisponibilidade = new System.Windows.Forms.Label();
            this.lblNEmprestimo = new System.Windows.Forms.Label();
            this.txtNEmprestimo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gpbDadosLivro = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuscarLivro = new System.Windows.Forms.Label();
            this.rdbDevolução = new System.Windows.Forms.RadioButton();
            this.rdbEmprestimo = new System.Windows.Forms.RadioButton();
            this.gpbAcao = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctLivro)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.gpbDadosLivro.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gpbAcao.SuspendLayout();
            this.SuspendLayout();
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
            // btnVender
            // 
            this.btnVender.BackColor = System.Drawing.Color.PowderBlue;
            this.btnVender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVender.Image = ((System.Drawing.Image)(resources.GetObject("btnVender.Image")));
            this.btnVender.Location = new System.Drawing.Point(3, 3);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(208, 61);
            this.btnVender.TabIndex = 0;
            this.btnVender.Text = "V&ender";
            this.btnVender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVender.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVender.UseVisualStyleBackColor = false;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
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
            // pctLivro
            // 
            this.pctLivro.Location = new System.Drawing.Point(31, 105);
            this.pctLivro.Name = "pctLivro";
            this.pctLivro.Size = new System.Drawing.Size(130, 182);
            this.pctLivro.TabIndex = 3;
            this.pctLivro.TabStop = false;
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
            this.ltbCarrinho.Size = new System.Drawing.Size(577, 129);
            this.ltbCarrinho.TabIndex = 7;
            this.ltbCarrinho.SelectedIndexChanged += new System.EventHandler(this.ltbCarrinho_SelectedIndexChanged);
            this.ltbCarrinho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ltbCarrinho_KeyDown);
            this.ltbCarrinho.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ltbCarrinho_MouseDoubleClick);
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
            // txtIsbn
            // 
            this.txtIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIsbn.Location = new System.Drawing.Point(176, 59);
            this.txtIsbn.MaxLength = 20;
            this.txtIsbn.Name = "txtIsbn";
            this.txtIsbn.Size = new System.Drawing.Size(135, 31);
            this.txtIsbn.TabIndex = 1;
            this.txtIsbn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIsbn_KeyDown_1);
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
            // txtTitulo
            // 
            this.txtTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(6, 115);
            this.txtTitulo.MaxLength = 100;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(305, 31);
            this.txtTitulo.TabIndex = 3;
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
            // txtAutor
            // 
            this.txtAutor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutor.Location = new System.Drawing.Point(6, 173);
            this.txtAutor.MaxLength = 100;
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(305, 31);
            this.txtAutor.TabIndex = 4;
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
            // lblLocatario
            // 
            this.lblLocatario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocatario.AutoSize = true;
            this.lblLocatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocatario.Location = new System.Drawing.Point(507, 162);
            this.lblLocatario.Name = "lblLocatario";
            this.lblLocatario.Size = new System.Drawing.Size(101, 25);
            this.lblLocatario.TabIndex = 0;
            this.lblLocatario.Text = "Locatário";
            // 
            // txtEditora
            // 
            this.txtEditora.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditora.Location = new System.Drawing.Point(6, 231);
            this.txtEditora.MaxLength = 50;
            this.txtEditora.Name = "txtEditora";
            this.txtEditora.Size = new System.Drawing.Size(305, 31);
            this.txtEditora.TabIndex = 5;
            // 
            // txtLocatario
            // 
            this.txtLocatario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocatario.Location = new System.Drawing.Point(507, 185);
            this.txtLocatario.MaxLength = 100;
            this.txtLocatario.Name = "txtLocatario";
            this.txtLocatario.Size = new System.Drawing.Size(267, 31);
            this.txtLocatario.TabIndex = 2;
            this.txtLocatario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocatario_KeyDown);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnVoltar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.Location = new System.Drawing.Point(217, 3);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(208, 61);
            this.btnVoltar.TabIndex = 12;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
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
            // lblDataEmprestimo
            // 
            this.lblDataEmprestimo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataEmprestimo.AutoSize = true;
            this.lblDataEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataEmprestimo.Location = new System.Drawing.Point(507, 219);
            this.lblDataEmprestimo.Name = "lblDataEmprestimo";
            this.lblDataEmprestimo.Size = new System.Drawing.Size(206, 25);
            this.lblDataEmprestimo.TabIndex = 0;
            this.lblDataEmprestimo.Text = "Data de Empréstimo";
            // 
            // lblDataDevolucao
            // 
            this.lblDataDevolucao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataDevolucao.AutoSize = true;
            this.lblDataDevolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataDevolucao.Location = new System.Drawing.Point(507, 276);
            this.lblDataDevolucao.Name = "lblDataDevolucao";
            this.lblDataDevolucao.Size = new System.Drawing.Size(195, 25);
            this.lblDataDevolucao.TabIndex = 0;
            this.lblDataDevolucao.Text = "Data de Devolução";
            // 
            // dtpDataEmprestimo
            // 
            this.dtpDataEmprestimo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataEmprestimo.Enabled = false;
            this.dtpDataEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataEmprestimo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEmprestimo.Location = new System.Drawing.Point(507, 242);
            this.dtpDataEmprestimo.Name = "dtpDataEmprestimo";
            this.dtpDataEmprestimo.Size = new System.Drawing.Size(155, 31);
            this.dtpDataEmprestimo.TabIndex = 30;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAdicionar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.Image")));
            this.btnAdicionar.Location = new System.Drawing.Point(3, 3);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(194, 74);
            this.btnAdicionar.TabIndex = 9;
            this.btnAdicionar.Text = "&Adicionar";
            this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
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
            // mskDataDevolucao
            // 
            this.mskDataDevolucao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mskDataDevolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataDevolucao.Location = new System.Drawing.Point(507, 299);
            this.mskDataDevolucao.Mask = "00/00/0000";
            this.mskDataDevolucao.Name = "mskDataDevolucao";
            this.mskDataDevolucao.Size = new System.Drawing.Size(155, 31);
            this.mskDataDevolucao.TabIndex = 6;
            this.mskDataDevolucao.ValidatingType = typeof(System.DateTime);
            // 
            // lblDisponibilidade
            // 
            this.lblDisponibilidade.AutoSize = true;
            this.lblDisponibilidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponibilidade.Location = new System.Drawing.Point(35, 290);
            this.lblDisponibilidade.Name = "lblDisponibilidade";
            this.lblDisponibilidade.Size = new System.Drawing.Size(0, 25);
            this.lblDisponibilidade.TabIndex = 0;
            // 
            // lblNEmprestimo
            // 
            this.lblNEmprestimo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNEmprestimo.AutoSize = true;
            this.lblNEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNEmprestimo.Location = new System.Drawing.Point(507, 97);
            this.lblNEmprestimo.Name = "lblNEmprestimo";
            this.lblNEmprestimo.Size = new System.Drawing.Size(184, 25);
            this.lblNEmprestimo.TabIndex = 0;
            this.lblNEmprestimo.Text = "Nº do Empréstimo";
            // 
            // txtNEmprestimo
            // 
            this.txtNEmprestimo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNEmprestimo.Enabled = false;
            this.txtNEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNEmprestimo.Location = new System.Drawing.Point(507, 128);
            this.txtNEmprestimo.Name = "txtNEmprestimo";
            this.txtNEmprestimo.Size = new System.Drawing.Size(267, 31);
            this.txtNEmprestimo.TabIndex = 1;
            this.txtNEmprestimo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNEmprestimo_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAdicionar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLimpar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFinalizar, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 520);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 80);
            this.tableLayoutPanel1.TabIndex = 31;
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
            this.gpbDadosLivro.TabIndex = 32;
            this.gpbDadosLivro.TabStop = false;
            this.gpbDadosLivro.Text = "Dados do livro";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnVoltar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnVender, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(372, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(428, 67);
            this.tableLayoutPanel2.TabIndex = 33;
            // 
            // lblBuscarLivro
            // 
            this.lblBuscarLivro.AutoSize = true;
            this.lblBuscarLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarLivro.Location = new System.Drawing.Point(24, 19);
            this.lblBuscarLivro.Name = "lblBuscarLivro";
            this.lblBuscarLivro.Size = new System.Drawing.Size(198, 37);
            this.lblBuscarLivro.TabIndex = 54;
            this.lblBuscarLivro.Text = "Empréstimo";
            // 
            // rdbDevolução
            // 
            this.rdbDevolução.AutoSize = true;
            this.rdbDevolução.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDevolução.Location = new System.Drawing.Point(6, 58);
            this.rdbDevolução.Name = "rdbDevolução";
            this.rdbDevolução.Size = new System.Drawing.Size(132, 29);
            this.rdbDevolução.TabIndex = 55;
            this.rdbDevolução.TabStop = true;
            this.rdbDevolução.Text = "Devolução";
            this.rdbDevolução.UseVisualStyleBackColor = true;
            this.rdbDevolução.CheckedChanged += new System.EventHandler(this.rdbDevolução_CheckedChanged);
            // 
            // rdbEmprestimo
            // 
            this.rdbEmprestimo.AutoSize = true;
            this.rdbEmprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbEmprestimo.Location = new System.Drawing.Point(6, 28);
            this.rdbEmprestimo.Name = "rdbEmprestimo";
            this.rdbEmprestimo.Size = new System.Drawing.Size(143, 29);
            this.rdbEmprestimo.TabIndex = 56;
            this.rdbEmprestimo.TabStop = true;
            this.rdbEmprestimo.Text = "Empréstimo";
            this.rdbEmprestimo.UseVisualStyleBackColor = true;
            this.rdbEmprestimo.CheckedChanged += new System.EventHandler(this.rdbEmprestimo_CheckedChanged);
            // 
            // gpbAcao
            // 
            this.gpbAcao.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.gpbAcao.Controls.Add(this.rdbEmprestimo);
            this.gpbAcao.Controls.Add(this.rdbDevolução);
            this.gpbAcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbAcao.Location = new System.Drawing.Point(614, 351);
            this.gpbAcao.Name = "gpbAcao";
            this.gpbAcao.Size = new System.Drawing.Size(160, 100);
            this.gpbAcao.TabIndex = 6;
            this.gpbAcao.TabStop = false;
            this.gpbAcao.Text = "Ações";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(603, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 74);
            this.button1.TabIndex = 12;
            this.button1.Text = "&Buscar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblBuscarLivro);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.gpbDadosLivro);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mskDataDevolucao);
            this.Controls.Add(this.dtpDataEmprestimo);
            this.Controls.Add(this.ltbCarrinho);
            this.Controls.Add(this.pctLivro);
            this.Controls.Add(this.txtLocatario);
            this.Controls.Add(this.lblNEmprestimo);
            this.Controls.Add(this.lblDataDevolucao);
            this.Controls.Add(this.lblDataEmprestimo);
            this.Controls.Add(this.txtNEmprestimo);
            this.Controls.Add(this.lblDisponibilidade);
            this.Controls.Add(this.lblLocatario);
            this.Controls.Add(this.gpbAcao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmEmprestimo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O Semeador - Empréstimo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pctLivro)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gpbDadosLivro.ResumeLayout(false);
            this.gpbDadosLivro.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gpbAcao.ResumeLayout(false);
            this.gpbAcao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdLivro;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.TextBox txtIdLivro;
        private System.Windows.Forms.PictureBox pctLivro;
        private System.Windows.Forms.ListBox ltbCarrinho;
        private System.Windows.Forms.Label lblIsbn;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.Label lblEditora;
        private System.Windows.Forms.Label lblLocatario;
        private System.Windows.Forms.TextBox txtEditora;
        private System.Windows.Forms.TextBox txtLocatario;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblDataEmprestimo;
        private System.Windows.Forms.Label lblDataDevolucao;
        private System.Windows.Forms.DateTimePicker dtpDataEmprestimo;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.MaskedTextBox mskDataDevolucao;
        private System.Windows.Forms.Label lblDisponibilidade;
        private System.Windows.Forms.Label lblNEmprestimo;
        private System.Windows.Forms.TextBox txtNEmprestimo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gpbDadosLivro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblBuscarLivro;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.RadioButton rdbDevolução;
        private System.Windows.Forms.RadioButton rdbEmprestimo;
        private System.Windows.Forms.GroupBox gpbAcao;
        private System.Windows.Forms.Button button1;
    }
}