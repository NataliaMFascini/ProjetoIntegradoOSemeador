namespace LivrariaEBiblioteca
{
    partial class frmCadastroLocatario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroLocatario));
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtLocatario = new System.Windows.Forms.TextBox();
            this.txtProntuario = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblProntuario = new System.Windows.Forms.Label();
            this.lblLocatario = new System.Windows.Forms.Label();
            this.lblCpf = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lbllistadelivros = new System.Windows.Forms.Label();
            this.gpbDadosLocatario = new System.Windows.Forms.GroupBox();
            this.btnGerarPront = new System.Windows.Forms.Button();
            this.mskCpf = new System.Windows.Forms.MaskedTextBox();
            this.mskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.ltbListadelivros = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuscarLivro = new System.Windows.Forms.Label();
            this.gpbDadosLocatario.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNovo
            // 
            this.btnNovo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.Location = new System.Drawing.Point(3, 3);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(150, 74);
            this.btnNovo.TabIndex = 10;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.Image")));
            this.btnCadastrar.Location = new System.Drawing.Point(159, 3);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(150, 74);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "&Cadastrar";
            this.btnCadastrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCadastrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.Location = new System.Drawing.Point(315, 3);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(150, 74);
            this.btnAlterar.TabIndex = 13;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.Image = ((System.Drawing.Image)(resources.GetObject("btnRemover.Image")));
            this.btnRemover.Location = new System.Drawing.Point(471, 3);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(150, 74);
            this.btnRemover.TabIndex = 14;
            this.btnRemover.Text = "&Remover";
            this.btnRemover.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(3, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(208, 74);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtLocatario
            // 
            this.txtLocatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocatario.Location = new System.Drawing.Point(24, 115);
            this.txtLocatario.MaxLength = 100;
            this.txtLocatario.Name = "txtLocatario";
            this.txtLocatario.Size = new System.Drawing.Size(470, 31);
            this.txtLocatario.TabIndex = 4;
            // 
            // txtProntuario
            // 
            this.txtProntuario.Enabled = false;
            this.txtProntuario.Location = new System.Drawing.Point(24, 59);
            this.txtProntuario.MaxLength = 100;
            this.txtProntuario.Name = "txtProntuario";
            this.txtProntuario.Size = new System.Drawing.Size(208, 31);
            this.txtProntuario.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(24, 174);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(469, 31);
            this.txtEmail.TabIndex = 6;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.Location = new System.Drawing.Point(217, 3);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(208, 74);
            this.btnVoltar.TabIndex = 15;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblProntuario
            // 
            this.lblProntuario.AutoSize = true;
            this.lblProntuario.Location = new System.Drawing.Point(24, 34);
            this.lblProntuario.Name = "lblProntuario";
            this.lblProntuario.Size = new System.Drawing.Size(111, 25);
            this.lblProntuario.TabIndex = 12;
            this.lblProntuario.Text = "Prontuário";
            // 
            // lblLocatario
            // 
            this.lblLocatario.AutoSize = true;
            this.lblLocatario.Location = new System.Drawing.Point(24, 90);
            this.lblLocatario.Name = "lblLocatario";
            this.lblLocatario.Size = new System.Drawing.Size(101, 25);
            this.lblLocatario.TabIndex = 13;
            this.lblLocatario.Text = "Locatário";
            // 
            // lblCpf
            // 
            this.lblCpf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCpf.AutoSize = true;
            this.lblCpf.Location = new System.Drawing.Point(499, 90);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(54, 25);
            this.lblCpf.TabIndex = 14;
            this.lblCpf.Text = "CPF";
            // 
            // lblTelefone
            // 
            this.lblTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(499, 149);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(96, 25);
            this.lblTelefone.TabIndex = 15;
            this.lblTelefone.Text = "Telefone";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(24, 149);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(72, 25);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "E-mail";
            // 
            // lbllistadelivros
            // 
            this.lbllistadelivros.AutoSize = true;
            this.lbllistadelivros.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistadelivros.Location = new System.Drawing.Point(12, 296);
            this.lbllistadelivros.Name = "lbllistadelivros";
            this.lbllistadelivros.Size = new System.Drawing.Size(145, 25);
            this.lbllistadelivros.TabIndex = 17;
            this.lbllistadelivros.Text = "Lista de livros";
            // 
            // gpbDadosLocatario
            // 
            this.gpbDadosLocatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbDadosLocatario.Controls.Add(this.btnGerarPront);
            this.gpbDadosLocatario.Controls.Add(this.mskCpf);
            this.gpbDadosLocatario.Controls.Add(this.mskTelefone);
            this.gpbDadosLocatario.Controls.Add(this.lblEmail);
            this.gpbDadosLocatario.Controls.Add(this.lblTelefone);
            this.gpbDadosLocatario.Controls.Add(this.lblCpf);
            this.gpbDadosLocatario.Controls.Add(this.lblLocatario);
            this.gpbDadosLocatario.Controls.Add(this.lblProntuario);
            this.gpbDadosLocatario.Controls.Add(this.txtEmail);
            this.gpbDadosLocatario.Controls.Add(this.txtProntuario);
            this.gpbDadosLocatario.Controls.Add(this.txtLocatario);
            this.gpbDadosLocatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbDadosLocatario.Location = new System.Drawing.Point(12, 70);
            this.gpbDadosLocatario.Name = "gpbDadosLocatario";
            this.gpbDadosLocatario.Size = new System.Drawing.Size(760, 223);
            this.gpbDadosLocatario.TabIndex = 1;
            this.gpbDadosLocatario.TabStop = false;
            this.gpbDadosLocatario.Text = "Dados locatario";
            // 
            // btnGerarPront
            // 
            this.btnGerarPront.Location = new System.Drawing.Point(238, 58);
            this.btnGerarPront.Name = "btnGerarPront";
            this.btnGerarPront.Size = new System.Drawing.Size(182, 32);
            this.btnGerarPront.TabIndex = 3;
            this.btnGerarPront.Text = "Gerar número";
            this.btnGerarPront.UseVisualStyleBackColor = true;
            this.btnGerarPront.Click += new System.EventHandler(this.btnGerarPront_Click);
            // 
            // mskCpf
            // 
            this.mskCpf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mskCpf.Location = new System.Drawing.Point(499, 115);
            this.mskCpf.Mask = " 999,999,999-99";
            this.mskCpf.Name = "mskCpf";
            this.mskCpf.Size = new System.Drawing.Size(187, 31);
            this.mskCpf.TabIndex = 5;
            // 
            // mskTelefone
            // 
            this.mskTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mskTelefone.Location = new System.Drawing.Point(499, 174);
            this.mskTelefone.Mask = "(99) 9999-9999";
            this.mskTelefone.Name = "mskTelefone";
            this.mskTelefone.Size = new System.Drawing.Size(187, 31);
            this.mskTelefone.TabIndex = 7;
            // 
            // ltbListadelivros
            // 
            this.ltbListadelivros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltbListadelivros.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbListadelivros.FormattingEnabled = true;
            this.ltbListadelivros.ItemHeight = 25;
            this.ltbListadelivros.Location = new System.Drawing.Point(12, 324);
            this.ltbListadelivros.Name = "ltbListadelivros";
            this.ltbListadelivros.Size = new System.Drawing.Size(760, 154);
            this.ltbListadelivros.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnLimpar, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNovo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRemover, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCadastrar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAlterar, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 481);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 80);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.Location = new System.Drawing.Point(627, 3);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(154, 74);
            this.btnLimpar.TabIndex = 15;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnVoltar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBuscar, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(356, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(428, 80);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // lblBuscarLivro
            // 
            this.lblBuscarLivro.AutoSize = true;
            this.lblBuscarLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarLivro.Location = new System.Drawing.Point(24, 19);
            this.lblBuscarLivro.Name = "lblBuscarLivro";
            this.lblBuscarLivro.Size = new System.Drawing.Size(307, 37);
            this.lblBuscarLivro.TabIndex = 20;
            this.lblBuscarLivro.Text = "Gerenciar locatário";
            // 
            // frmCadastroLocatario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblBuscarLivro);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ltbListadelivros);
            this.Controls.Add(this.gpbDadosLocatario);
            this.Controls.Add(this.lbllistadelivros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastroLocatario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O Semeador - Cadastro de locatário";
            this.Load += new System.EventHandler(this.frmCadastroLocatario_Load);
            this.gpbDadosLocatario.ResumeLayout(false);
            this.gpbDadosLocatario.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtLocatario;
        private System.Windows.Forms.TextBox txtProntuario;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblProntuario;
        private System.Windows.Forms.Label lblLocatario;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lbllistadelivros;
        private System.Windows.Forms.GroupBox gpbDadosLocatario;
        private System.Windows.Forms.MaskedTextBox mskCpf;
        private System.Windows.Forms.MaskedTextBox mskTelefone;
        private System.Windows.Forms.ListBox ltbListadelivros;
        private System.Windows.Forms.Button btnGerarPront;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblBuscarLivro;
        private System.Windows.Forms.Button btnLimpar;
    }
}