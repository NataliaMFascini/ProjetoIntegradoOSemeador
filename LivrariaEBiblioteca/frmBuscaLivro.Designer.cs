namespace LivrariaEBiblioteca
{
    partial class frmBuscarLivro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarLivro));
            this.pctLivro = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblIdLivro = new System.Windows.Forms.Label();
            this.lblIsbn = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblPequisar = new System.Windows.Forms.Label();
            this.ltbPesquisar = new System.Windows.Forms.ListBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.rdbTitulo = new System.Windows.Forms.RadioButton();
            this.rdbIdLivro = new System.Windows.Forms.RadioButton();
            this.txtIsbn = new System.Windows.Forms.TextBox();
            this.txtIdLivro = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnEmprestar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuscarLivro = new System.Windows.Forms.Label();
            this.rdbIsbn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pctLivro)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctLivro
            // 
            this.pctLivro.Location = new System.Drawing.Point(31, 124);
            this.pctLivro.Name = "pctLivro";
            this.pctLivro.Size = new System.Drawing.Size(136, 160);
            this.pctLivro.TabIndex = 0;
            this.pctLivro.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.btnBuscar.Location = new System.Drawing.Point(3, 311);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(150, 74);
            this.btnBuscar.TabIndex = 8;
=======
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(632, 333);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(95, 35);
            this.btnBuscar.TabIndex = 10;
>>>>>>> cd5debe9b4e1946e8ce9b17949d22d62b0ed21f6
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblIdLivro
            // 
            this.lblIdLivro.AutoSize = true;
            this.lblIdLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdLivro.Location = new System.Drawing.Point(173, 164);
            this.lblIdLivro.Name = "lblIdLivro";
            this.lblIdLivro.Size = new System.Drawing.Size(115, 25);
            this.lblIdLivro.TabIndex = 1;
            this.lblIdLivro.Text = "ID do Livro";
            // 
            // lblIsbn
            // 
            this.lblIsbn.AutoSize = true;
            this.lblIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsbn.Location = new System.Drawing.Point(333, 164);
            this.lblIsbn.Name = "lblIsbn";
            this.lblIsbn.Size = new System.Drawing.Size(60, 25);
            this.lblIsbn.TabIndex = 1;
            this.lblIsbn.Text = "ISBN";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(173, 225);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(65, 25);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Título";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.txtTitulo.Location = new System.Drawing.Point(173, 253);
=======
            this.txtTitulo.Location = new System.Drawing.Point(184, 154);
            this.txtTitulo.MaxLength = 100;
>>>>>>> cd5debe9b4e1946e8ce9b17949d22d62b0ed21f6
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(434, 31);
            this.txtTitulo.TabIndex = 3;
            // 
<<<<<<< HEAD
=======
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutor.Location = new System.Drawing.Point(184, 192);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(63, 25);
            this.lblAutor.TabIndex = 1;
            this.lblAutor.Text = "Autor";
            // 
            // txtAutor
            // 
            this.txtAutor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutor.Location = new System.Drawing.Point(184, 215);
            this.txtAutor.MaxLength = 100;
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(583, 31);
            this.txtAutor.TabIndex = 4;
            // 
>>>>>>> cd5debe9b4e1946e8ce9b17949d22d62b0ed21f6
            // lblPequisar
            // 
            this.lblPequisar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPequisar.AutoSize = true;
            this.lblPequisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPequisar.Location = new System.Drawing.Point(26, 76);
            this.lblPequisar.Name = "lblPequisar";
            this.lblPequisar.Size = new System.Drawing.Size(151, 25);
            this.lblPequisar.TabIndex = 1;
            this.lblPequisar.Text = "Pesquisar por:";
            // 
            // ltbPesquisar
            // 
            this.ltbPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltbPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbPesquisar.FormattingEnabled = true;
            this.ltbPesquisar.ItemHeight = 25;
<<<<<<< HEAD
            this.ltbPesquisar.Location = new System.Drawing.Point(31, 315);
            this.ltbPesquisar.Name = "ltbPesquisar";
            this.ltbPesquisar.Size = new System.Drawing.Size(587, 154);
            this.ltbPesquisar.TabIndex = 8;
=======
            this.ltbPesquisar.Location = new System.Drawing.Point(12, 333);
            this.ltbPesquisar.Name = "ltbPesquisar";
            this.ltbPesquisar.Size = new System.Drawing.Size(636, 154);
            this.ltbPesquisar.TabIndex = 9;
>>>>>>> cd5debe9b4e1946e8ce9b17949d22d62b0ed21f6
            this.ltbPesquisar.SelectedIndexChanged += new System.EventHandler(this.ltbPesquisar_SelectedIndexChanged);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(26, 287);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(109, 25);
            this.lblResultado.TabIndex = 1;
            this.lblResultado.Text = "Resultado";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.btnLimpar.Location = new System.Drawing.Point(3, 391);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(150, 74);
            this.btnLimpar.TabIndex = 9;
=======
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.Location = new System.Drawing.Point(632, 385);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(94, 35);
            this.btnLimpar.TabIndex = 11;
>>>>>>> cd5debe9b4e1946e8ce9b17949d22d62b0ed21f6
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // rdbTitulo
            // 
            this.rdbTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTitulo.Location = new System.Drawing.Point(478, 74);
            this.rdbTitulo.Name = "rdbTitulo";
            this.rdbTitulo.Size = new System.Drawing.Size(83, 29);
            this.rdbTitulo.TabIndex = 2;
            this.rdbTitulo.Text = "Título";
            this.rdbTitulo.UseVisualStyleBackColor = true;
            this.rdbTitulo.CheckedChanged += new System.EventHandler(this.rdbTitulo_CheckedChanged);
            // 
            // rdbIdLivro
            // 
            this.rdbIdLivro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbIdLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbIdLivro.Location = new System.Drawing.Point(207, 74);
            this.rdbIdLivro.Name = "rdbIdLivro";
            this.rdbIdLivro.Size = new System.Drawing.Size(133, 29);
            this.rdbIdLivro.TabIndex = 0;
            this.rdbIdLivro.Text = "ID do Livro";
            this.rdbIdLivro.UseVisualStyleBackColor = true;
            this.rdbIdLivro.CheckedChanged += new System.EventHandler(this.rdbIdLivro_CheckedChanged);
            // 
<<<<<<< HEAD
=======
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAno.Location = new System.Drawing.Point(184, 249);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(50, 25);
            this.lblAno.TabIndex = 1;
            this.lblAno.Text = "Ano";
            // 
            // txtAno
            // 
            this.txtAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAno.Location = new System.Drawing.Point(184, 274);
            this.txtAno.MaxLength = 10;
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(130, 31);
            this.txtAno.TabIndex = 5;
            // 
            // lblEditora
            // 
            this.lblEditora.AutoSize = true;
            this.lblEditora.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditora.Location = new System.Drawing.Point(328, 249);
            this.lblEditora.Name = "lblEditora";
            this.lblEditora.Size = new System.Drawing.Size(80, 25);
            this.lblEditora.TabIndex = 1;
            this.lblEditora.Text = "Editora";
            // 
            // txtEditora
            // 
            this.txtEditora.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditora.Location = new System.Drawing.Point(328, 274);
            this.txtEditora.MaxLength = 50;
            this.txtEditora.Name = "txtEditora";
            this.txtEditora.Size = new System.Drawing.Size(130, 31);
            this.txtEditora.TabIndex = 6;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.Location = new System.Drawing.Point(495, 249);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(123, 25);
            this.lblQuantidade.TabIndex = 1;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(495, 274);
            this.txtQuantidade.MaxLength = 10;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(130, 31);
            this.txtQuantidade.TabIndex = 7;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(638, 249);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(62, 25);
            this.lblValor.TabIndex = 1;
            this.lblValor.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.Enabled = false;
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(638, 274);
            this.txtValor.MaxLength = 12;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(129, 31);
            this.txtValor.TabIndex = 8;
            // 
>>>>>>> cd5debe9b4e1946e8ce9b17949d22d62b0ed21f6
            // txtIsbn
            // 
            this.txtIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.txtIsbn.Location = new System.Drawing.Point(333, 192);
=======
            this.txtIsbn.Location = new System.Drawing.Point(344, 93);
            this.txtIsbn.MaxLength = 20;
>>>>>>> cd5debe9b4e1946e8ce9b17949d22d62b0ed21f6
            this.txtIsbn.Name = "txtIsbn";
            this.txtIsbn.Size = new System.Drawing.Size(136, 31);
            this.txtIsbn.TabIndex = 2;
            // 
            // txtIdLivro
            // 
            this.txtIdLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.txtIdLivro.Location = new System.Drawing.Point(173, 192);
=======
            this.txtIdLivro.Location = new System.Drawing.Point(184, 93);
            this.txtIdLivro.MaxLength = 10;
>>>>>>> cd5debe9b4e1946e8ce9b17949d22d62b0ed21f6
            this.txtIdLivro.Name = "txtIdLivro";
            this.txtIdLivro.Size = new System.Drawing.Size(136, 31);
            this.txtIdLivro.TabIndex = 1;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.btnVoltar.Location = new System.Drawing.Point(3, 3);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(150, 75);
            this.btnVoltar.TabIndex = 12;
=======
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.Location = new System.Drawing.Point(638, 496);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(130, 49);
            this.btnVoltar.TabIndex = 14;
>>>>>>> cd5debe9b4e1946e8ce9b17949d22d62b0ed21f6
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnVender
            // 
            this.btnVender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.btnVender.Location = new System.Drawing.Point(3, 3);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(210, 74);
            this.btnVender.TabIndex = 10;
=======
            this.btnVender.Image = ((System.Drawing.Image)(resources.GetObject("btnVender.Image")));
            this.btnVender.Location = new System.Drawing.Point(12, 496);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(113, 35);
            this.btnVender.TabIndex = 12;
>>>>>>> cd5debe9b4e1946e8ce9b17949d22d62b0ed21f6
            this.btnVender.Text = "Vender";
            this.btnVender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVender.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnEmprestar
            // 
            this.btnEmprestar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEmprestar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD
            this.btnEmprestar.Location = new System.Drawing.Point(219, 3);
            this.btnEmprestar.Name = "btnEmprestar";
            this.btnEmprestar.Size = new System.Drawing.Size(209, 74);
            this.btnEmprestar.TabIndex = 11;
=======
            this.btnEmprestar.Image = ((System.Drawing.Image)(resources.GetObject("btnEmprestar.Image")));
            this.btnEmprestar.Location = new System.Drawing.Point(184, 496);
            this.btnEmprestar.Name = "btnEmprestar";
            this.btnEmprestar.Size = new System.Drawing.Size(113, 35);
            this.btnEmprestar.TabIndex = 13;
>>>>>>> cd5debe9b4e1946e8ce9b17949d22d62b0ed21f6
            this.btnEmprestar.Text = "Emprestar";
            this.btnEmprestar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmprestar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmprestar.UseVisualStyleBackColor = true;
            this.btnEmprestar.Click += new System.EventHandler(this.btnEmprestar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnBuscar, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnLimpar, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnVoltar, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(624, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(156, 557);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.77564F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.61538F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.tableLayoutPanel2.Controls.Add(this.btnVender, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEmprestar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 477);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(624, 80);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // lblBuscarLivro
            // 
            this.lblBuscarLivro.AutoSize = true;
            this.lblBuscarLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarLivro.Location = new System.Drawing.Point(24, 19);
            this.lblBuscarLivro.Name = "lblBuscarLivro";
            this.lblBuscarLivro.Size = new System.Drawing.Size(196, 37);
            this.lblBuscarLivro.TabIndex = 15;
            this.lblBuscarLivro.Text = "Buscar livro";
            // 
            // rdbIsbn
            // 
            this.rdbIsbn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbIsbn.Location = new System.Drawing.Point(370, 74);
            this.rdbIsbn.Name = "rdbIsbn";
            this.rdbIsbn.Size = new System.Drawing.Size(78, 29);
            this.rdbIsbn.TabIndex = 16;
            this.rdbIsbn.Text = "ISBN";
            this.rdbIsbn.UseVisualStyleBackColor = true;
            // 
            // frmBuscarLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(780, 557);
            this.Controls.Add(this.rdbIsbn);
            this.Controls.Add(this.lblBuscarLivro);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.rdbIdLivro);
            this.Controls.Add(this.rdbTitulo);
            this.Controls.Add(this.ltbPesquisar);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtIdLivro);
            this.Controls.Add(this.txtIsbn);
            this.Controls.Add(this.lblIsbn);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblPequisar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblIdLivro);
            this.Controls.Add(this.pctLivro);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmBuscarLivro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O Semeador - Buscar Livro";
            ((System.ComponentModel.ISupportInitialize)(this.pctLivro)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctLivro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblIdLivro;
        private System.Windows.Forms.Label lblIsbn;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblPequisar;
        private System.Windows.Forms.ListBox ltbPesquisar;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.RadioButton rdbTitulo;
        private System.Windows.Forms.RadioButton rdbIdLivro;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.TextBox txtIdLivro;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Button btnEmprestar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblBuscarLivro;
        private System.Windows.Forms.RadioButton rdbIsbn;
    }
}