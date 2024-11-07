namespace SIGRas
{
    partial class FrmProdutos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProdutos));
            this.pan_titulo = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pan_barrainferior = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_unvenda = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_vlrvenda = new System.Windows.Forms.TextBox();
            this.cbo_tipoitem = new System.Windows.Forms.ComboBox();
            this.txt_vlrcompra = new System.Windows.Forms.TextBox();
            this.img_novafamilia = new System.Windows.Forms.PictureBox();
            this.img_novogrupo = new System.Windows.Forms.PictureBox();
            this.btn_estoqueajuste = new System.Windows.Forms.Button();
            this.img_novaunidadeestocagem = new System.Windows.Forms.PictureBox();
            this.txt_estoque = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_obs = new System.Windows.Forms.TextBox();
            this.cbo_uncompra = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.img_novaunidadecompra = new System.Windows.Forms.PictureBox();
            this.txt_dataalteracao = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_datacadastro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_unestocagem = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_familia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_grupo = new System.Windows.Forms.ComboBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ean = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_status = new System.Windows.Forms.ComboBox();
            this.txt_descricaoproduto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gb_botoes = new System.Windows.Forms.GroupBox();
            this.btConsultar = new System.Windows.Forms.Button();
            this.btRelatorio = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.btGravar = new System.Windows.Forms.Button();
            this.btAlterar = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pan_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_novafamilia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_novogrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_novaunidadeestocagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_novaunidadecompra)).BeginInit();
            this.gb_botoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_titulo
            // 
            this.pan_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_titulo.Controls.Add(this.label14);
            this.pan_titulo.Controls.Add(this.btnCerrar);
            this.pan_titulo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pan_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_titulo.Location = new System.Drawing.Point(0, 0);
            this.pan_titulo.Name = "pan_titulo";
            this.pan_titulo.Size = new System.Drawing.Size(720, 25);
            this.pan_titulo.TabIndex = 0;
            this.pan_titulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pan_titulo_MouseDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(12, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "Cadastro Produtos";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(687, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(18, 18);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 23;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.btnCerrar_MouseLeave);
            this.btnCerrar.MouseHover += new System.EventHandler(this.btnCerrar_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 335);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(705, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 335);
            this.panel2.TabIndex = 2;
            // 
            // pan_barrainferior
            // 
            this.pan_barrainferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_barrainferior.Cursor = System.Windows.Forms.Cursors.Default;
            this.pan_barrainferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_barrainferior.Location = new System.Drawing.Point(15, 345);
            this.pan_barrainferior.Name = "pan_barrainferior";
            this.pan_barrainferior.Size = new System.Drawing.Size(690, 15);
            this.pan_barrainferior.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_unvenda);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txt_vlrvenda);
            this.groupBox1.Controls.Add(this.cbo_tipoitem);
            this.groupBox1.Controls.Add(this.txt_vlrcompra);
            this.groupBox1.Controls.Add(this.img_novafamilia);
            this.groupBox1.Controls.Add(this.img_novogrupo);
            this.groupBox1.Controls.Add(this.btn_estoqueajuste);
            this.groupBox1.Controls.Add(this.img_novaunidadeestocagem);
            this.groupBox1.Controls.Add(this.txt_estoque);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txt_obs);
            this.groupBox1.Controls.Add(this.cbo_uncompra);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.img_novaunidadecompra);
            this.groupBox1.Controls.Add(this.txt_dataalteracao);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txt_datacadastro);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbo_unestocagem);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbo_familia);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbo_grupo);
            this.groupBox1.Controls.Add(this.txt_id);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_ean);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbo_status);
            this.groupBox1.Controls.Add(this.txt_descricaoproduto);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(21, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 205);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Principal";
            // 
            // cbo_unvenda
            // 
            this.cbo_unvenda.FormattingEnabled = true;
            this.cbo_unvenda.Location = new System.Drawing.Point(218, 169);
            this.cbo_unvenda.Name = "cbo_unvenda";
            this.cbo_unvenda.Size = new System.Drawing.Size(55, 23);
            this.cbo_unvenda.TabIndex = 32;
            this.cbo_unvenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_unvenda_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(215, 151);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 15);
            this.label17.TabIndex = 31;
            this.label17.Text = "UN Venda";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(3, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 15);
            this.label13.TabIndex = 8;
            this.label13.Text = "Tipo do Ítem";
            // 
            // txt_vlrvenda
            // 
            this.txt_vlrvenda.Location = new System.Drawing.Point(112, 169);
            this.txt_vlrvenda.MaxLength = 30;
            this.txt_vlrvenda.Name = "txt_vlrvenda";
            this.txt_vlrvenda.Size = new System.Drawing.Size(100, 23);
            this.txt_vlrvenda.TabIndex = 28;
            this.txt_vlrvenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_vlrvenda.TextChanged += new System.EventHandler(this.txt_vlrvenda_TextChanged);
            this.txt_vlrvenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_vlrvenda_KeyPress);
            // 
            // cbo_tipoitem
            // 
            this.cbo_tipoitem.FormattingEnabled = true;
            this.cbo_tipoitem.Location = new System.Drawing.Point(6, 81);
            this.cbo_tipoitem.Name = "cbo_tipoitem";
            this.cbo_tipoitem.Size = new System.Drawing.Size(282, 23);
            this.cbo_tipoitem.TabIndex = 9;
            this.cbo_tipoitem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_tipoitem_KeyPress);
            // 
            // txt_vlrcompra
            // 
            this.txt_vlrcompra.Location = new System.Drawing.Point(6, 169);
            this.txt_vlrcompra.MaxLength = 30;
            this.txt_vlrcompra.Name = "txt_vlrcompra";
            this.txt_vlrcompra.Size = new System.Drawing.Size(100, 23);
            this.txt_vlrcompra.TabIndex = 26;
            this.txt_vlrcompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_vlrcompra.TextChanged += new System.EventHandler(this.txt_vlrcompra_TextChanged);
            this.txt_vlrcompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_vlrcompra_KeyPress);
            // 
            // img_novafamilia
            // 
            this.img_novafamilia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_novafamilia.Image = ((System.Drawing.Image)(resources.GetObject("img_novafamilia.Image")));
            this.img_novafamilia.Location = new System.Drawing.Point(534, 64);
            this.img_novafamilia.Name = "img_novafamilia";
            this.img_novafamilia.Size = new System.Drawing.Size(15, 15);
            this.img_novafamilia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_novafamilia.TabIndex = 7;
            this.img_novafamilia.TabStop = false;
            this.img_novafamilia.Click += new System.EventHandler(this.img_novafamilia_Click);
            // 
            // img_novogrupo
            // 
            this.img_novogrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_novogrupo.Image = ((System.Drawing.Image)(resources.GetObject("img_novogrupo.Image")));
            this.img_novogrupo.Location = new System.Drawing.Point(334, 64);
            this.img_novogrupo.Name = "img_novogrupo";
            this.img_novogrupo.Size = new System.Drawing.Size(15, 15);
            this.img_novogrupo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_novogrupo.TabIndex = 7;
            this.img_novogrupo.TabStop = false;
            this.img_novogrupo.Click += new System.EventHandler(this.img_novogrupo_Click);
            // 
            // btn_estoqueajuste
            // 
            this.btn_estoqueajuste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_estoqueajuste.FlatAppearance.BorderSize = 0;
            this.btn_estoqueajuste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_estoqueajuste.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_estoqueajuste.ForeColor = System.Drawing.Color.White;
            this.btn_estoqueajuste.Location = new System.Drawing.Point(558, 126);
            this.btn_estoqueajuste.Name = "btn_estoqueajuste";
            this.btn_estoqueajuste.Size = new System.Drawing.Size(20, 22);
            this.btn_estoqueajuste.TabIndex = 22;
            this.btn_estoqueajuste.Text = "?";
            this.btn_estoqueajuste.UseVisualStyleBackColor = false;
            this.btn_estoqueajuste.Click += new System.EventHandler(this.btn_estoqueajuste_Click);
            // 
            // img_novaunidadeestocagem
            // 
            this.img_novaunidadeestocagem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_novaunidadeestocagem.Image = ((System.Drawing.Image)(resources.GetObject("img_novaunidadeestocagem.Image")));
            this.img_novaunidadeestocagem.Location = new System.Drawing.Point(392, 108);
            this.img_novaunidadeestocagem.Name = "img_novaunidadeestocagem";
            this.img_novaunidadeestocagem.Size = new System.Drawing.Size(15, 15);
            this.img_novaunidadeestocagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_novaunidadeestocagem.TabIndex = 6;
            this.img_novaunidadeestocagem.TabStop = false;
            this.img_novaunidadeestocagem.Click += new System.EventHandler(this.img_novaunidadeestocagem_Click);
            // 
            // txt_estoque
            // 
            this.txt_estoque.Location = new System.Drawing.Point(450, 125);
            this.txt_estoque.MaxLength = 10;
            this.txt_estoque.Name = "txt_estoque";
            this.txt_estoque.Size = new System.Drawing.Size(102, 23);
            this.txt_estoque.TabIndex = 21;
            this.txt_estoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_estoque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_estoque_KeyPress);
            this.txt_estoque.Leave += new System.EventHandler(this.txt_estoque_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(447, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 15);
            this.label16.TabIndex = 20;
            this.label16.Text = "Estoque";
            // 
            // txt_obs
            // 
            this.txt_obs.Location = new System.Drawing.Point(279, 169);
            this.txt_obs.MaxLength = 100;
            this.txt_obs.Name = "txt_obs";
            this.txt_obs.Size = new System.Drawing.Size(395, 23);
            this.txt_obs.TabIndex = 30;
            // 
            // cbo_uncompra
            // 
            this.cbo_uncompra.FormattingEnabled = true;
            this.cbo_uncompra.Location = new System.Drawing.Point(168, 125);
            this.cbo_uncompra.Name = "cbo_uncompra";
            this.cbo_uncompra.Size = new System.Drawing.Size(135, 23);
            this.cbo_uncompra.TabIndex = 17;
            this.cbo_uncompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_uncompra_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(276, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 15);
            this.label12.TabIndex = 29;
            this.label12.Text = "Observação";
            // 
            // img_novaunidadecompra
            // 
            this.img_novaunidadecompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.img_novaunidadecompra.Image = ((System.Drawing.Image)(resources.GetObject("img_novaunidadecompra.Image")));
            this.img_novaunidadecompra.Location = new System.Drawing.Point(235, 108);
            this.img_novaunidadecompra.Name = "img_novaunidadecompra";
            this.img_novaunidadecompra.Size = new System.Drawing.Size(15, 15);
            this.img_novaunidadecompra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_novaunidadecompra.TabIndex = 5;
            this.img_novaunidadecompra.TabStop = false;
            this.img_novaunidadecompra.Click += new System.EventHandler(this.img_novaunidadecompra_Click);
            // 
            // txt_dataalteracao
            // 
            this.txt_dataalteracao.Location = new System.Drawing.Point(584, 125);
            this.txt_dataalteracao.MaxLength = 20;
            this.txt_dataalteracao.Name = "txt_dataalteracao";
            this.txt_dataalteracao.Size = new System.Drawing.Size(90, 23);
            this.txt_dataalteracao.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(581, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 15);
            this.label15.TabIndex = 23;
            this.label15.Text = "Data Alteração";
            // 
            // txt_datacadastro
            // 
            this.txt_datacadastro.Location = new System.Drawing.Point(72, 37);
            this.txt_datacadastro.MaxLength = 20;
            this.txt_datacadastro.Name = "txt_datacadastro";
            this.txt_datacadastro.Size = new System.Drawing.Size(90, 23);
            this.txt_datacadastro.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(165, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "UN.Compra";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(69, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data Cadastro";
            // 
            // cbo_unestocagem
            // 
            this.cbo_unestocagem.FormattingEnabled = true;
            this.cbo_unestocagem.Location = new System.Drawing.Point(309, 125);
            this.cbo_unestocagem.Name = "cbo_unestocagem";
            this.cbo_unestocagem.Size = new System.Drawing.Size(135, 23);
            this.cbo_unestocagem.TabIndex = 19;
            this.cbo_unestocagem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_unestocagem_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(109, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "Valor Venda";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(306, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "UN.Estocagem";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "Valor Compra";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(484, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Família";
            // 
            // cbo_familia
            // 
            this.cbo_familia.FormattingEnabled = true;
            this.cbo_familia.Location = new System.Drawing.Point(487, 81);
            this.cbo_familia.Name = "cbo_familia";
            this.cbo_familia.Size = new System.Drawing.Size(187, 23);
            this.cbo_familia.TabIndex = 13;
            this.cbo_familia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_familia_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(291, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Grupo";
            // 
            // cbo_grupo
            // 
            this.cbo_grupo.FormattingEnabled = true;
            this.cbo_grupo.Location = new System.Drawing.Point(294, 81);
            this.cbo_grupo.Name = "cbo_grupo";
            this.cbo_grupo.Size = new System.Drawing.Size(187, 23);
            this.cbo_grupo.TabIndex = 11;
            this.cbo_grupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_grupo_KeyPress);
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(6, 37);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(60, 23);
            this.txt_id.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(165, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status";
            // 
            // txt_ean
            // 
            this.txt_ean.Location = new System.Drawing.Point(6, 125);
            this.txt_ean.MaxLength = 20;
            this.txt_ean.Name = "txt_ean";
            this.txt_ean.Size = new System.Drawing.Size(156, 23);
            this.txt_ean.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Código EAN";
            // 
            // cbo_status
            // 
            this.cbo_status.FormattingEnabled = true;
            this.cbo_status.Location = new System.Drawing.Point(168, 37);
            this.cbo_status.Name = "cbo_status";
            this.cbo_status.Size = new System.Drawing.Size(120, 23);
            this.cbo_status.TabIndex = 5;
            this.cbo_status.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_status_KeyPress);
            // 
            // txt_descricaoproduto
            // 
            this.txt_descricaoproduto.Location = new System.Drawing.Point(294, 37);
            this.txt_descricaoproduto.MaxLength = 100;
            this.txt_descricaoproduto.Name = "txt_descricaoproduto";
            this.txt_descricaoproduto.Size = new System.Drawing.Size(380, 23);
            this.txt_descricaoproduto.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(291, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "Descrição Produto";
            // 
            // gb_botoes
            // 
            this.gb_botoes.Controls.Add(this.btConsultar);
            this.gb_botoes.Controls.Add(this.btRelatorio);
            this.gb_botoes.Controls.Add(this.btNovo);
            this.gb_botoes.Controls.Add(this.btCancelar);
            this.gb_botoes.Controls.Add(this.btFechar);
            this.gb_botoes.Controls.Add(this.btGravar);
            this.gb_botoes.Controls.Add(this.btAlterar);
            this.gb_botoes.Controls.Add(this.btEditar);
            this.gb_botoes.Location = new System.Drawing.Point(21, 242);
            this.gb_botoes.Name = "gb_botoes";
            this.gb_botoes.Size = new System.Drawing.Size(680, 95);
            this.gb_botoes.TabIndex = 5;
            this.gb_botoes.TabStop = false;
            // 
            // btConsultar
            // 
            this.btConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btConsultar.FlatAppearance.BorderSize = 0;
            this.btConsultar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btConsultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConsultar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsultar.ForeColor = System.Drawing.Color.White;
            this.btConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btConsultar.Image")));
            this.btConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btConsultar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btConsultar.Location = new System.Drawing.Point(426, 22);
            this.btConsultar.Name = "btConsultar";
            this.btConsultar.Size = new System.Drawing.Size(78, 60);
            this.btConsultar.TabIndex = 5;
            this.btConsultar.Text = "Buscar";
            this.btConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btConsultar.UseVisualStyleBackColor = false;
            this.btConsultar.Click += new System.EventHandler(this.btConsultar_Click);
            // 
            // btRelatorio
            // 
            this.btRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btRelatorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRelatorio.FlatAppearance.BorderSize = 0;
            this.btRelatorio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btRelatorio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRelatorio.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRelatorio.ForeColor = System.Drawing.Color.White;
            this.btRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("btRelatorio.Image")));
            this.btRelatorio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btRelatorio.Location = new System.Drawing.Point(510, 22);
            this.btRelatorio.Name = "btRelatorio";
            this.btRelatorio.Size = new System.Drawing.Size(78, 60);
            this.btRelatorio.TabIndex = 6;
            this.btRelatorio.Text = "Relatório";
            this.btRelatorio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btRelatorio.UseVisualStyleBackColor = false;
            this.btRelatorio.Click += new System.EventHandler(this.btRelatorio_Click);
            // 
            // btNovo
            // 
            this.btNovo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNovo.FlatAppearance.BorderSize = 0;
            this.btNovo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btNovo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNovo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNovo.ForeColor = System.Drawing.Color.White;
            this.btNovo.Image = ((System.Drawing.Image)(resources.GetObject("btNovo.Image")));
            this.btNovo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btNovo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btNovo.Location = new System.Drawing.Point(6, 22);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(78, 60);
            this.btNovo.TabIndex = 0;
            this.btNovo.Text = "Novo";
            this.btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btNovo.UseVisualStyleBackColor = false;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.FlatAppearance.BorderSize = 0;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.ForeColor = System.Drawing.Color.White;
            this.btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btCancelar.Image")));
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btCancelar.Location = new System.Drawing.Point(342, 22);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(78, 60);
            this.btCancelar.TabIndex = 4;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btFechar
            // 
            this.btFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btFechar.FlatAppearance.BorderSize = 0;
            this.btFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFechar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFechar.ForeColor = System.Drawing.Color.White;
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btFechar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btFechar.Location = new System.Drawing.Point(594, 22);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(78, 60);
            this.btFechar.TabIndex = 7;
            this.btFechar.Text = "Fechar";
            this.btFechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btFechar.UseVisualStyleBackColor = false;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btGravar
            // 
            this.btGravar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btGravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btGravar.FlatAppearance.BorderSize = 0;
            this.btGravar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btGravar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGravar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGravar.ForeColor = System.Drawing.Color.White;
            this.btGravar.Image = ((System.Drawing.Image)(resources.GetObject("btGravar.Image")));
            this.btGravar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btGravar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btGravar.Location = new System.Drawing.Point(90, 22);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(78, 60);
            this.btGravar.TabIndex = 1;
            this.btGravar.Text = "Gravar";
            this.btGravar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btGravar.UseVisualStyleBackColor = false;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAlterar.FlatAppearance.BorderSize = 0;
            this.btAlterar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btAlterar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAlterar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAlterar.ForeColor = System.Drawing.Color.White;
            this.btAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btAlterar.Image")));
            this.btAlterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAlterar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btAlterar.Location = new System.Drawing.Point(174, 22);
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.Size = new System.Drawing.Size(78, 60);
            this.btAlterar.TabIndex = 2;
            this.btAlterar.Text = "Alterar";
            this.btAlterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAlterar.UseVisualStyleBackColor = false;
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btEditar
            // 
            this.btEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditar.FlatAppearance.BorderSize = 0;
            this.btEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEditar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEditar.ForeColor = System.Drawing.Color.White;
            this.btEditar.Image = ((System.Drawing.Image)(resources.GetObject("btEditar.Image")));
            this.btEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btEditar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btEditar.Location = new System.Drawing.Point(258, 22);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(78, 60);
            this.btEditar.TabIndex = 3;
            this.btEditar.Text = "Editar";
            this.btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btEditar.UseVisualStyleBackColor = false;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // FrmProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(720, 360);
            this.Controls.Add(this.gb_botoes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pan_barrainferior);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pan_titulo);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmProdutos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProdutos_KeyDown);
            this.pan_titulo.ResumeLayout(false);
            this.pan_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_novafamilia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_novogrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_novaunidadeestocagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_novaunidadecompra)).EndInit();
            this.gb_botoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_titulo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pan_barrainferior;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txt_vlrvenda;
        public System.Windows.Forms.TextBox txt_vlrcompra;
        private System.Windows.Forms.PictureBox img_novafamilia;
        private System.Windows.Forms.PictureBox img_novogrupo;
        private System.Windows.Forms.PictureBox img_novaunidadeestocagem;
        private System.Windows.Forms.PictureBox img_novaunidadecompra;
        public System.Windows.Forms.TextBox txt_obs;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Button btn_estoqueajuste;
        public System.Windows.Forms.TextBox txt_estoque;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txt_dataalteracao;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txt_datacadastro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox cbo_unestocagem;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cbo_uncompra;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbo_familia;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cbo_grupo;
        public System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_ean;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbo_status;
        public System.Windows.Forms.TextBox txt_descricaoproduto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gb_botoes;
        public System.Windows.Forms.Button btConsultar;
        public System.Windows.Forms.Button btRelatorio;
        public System.Windows.Forms.Button btNovo;
        public System.Windows.Forms.Button btCancelar;
        public System.Windows.Forms.Button btFechar;
        public System.Windows.Forms.Button btGravar;
        public System.Windows.Forms.Button btAlterar;
        public System.Windows.Forms.Button btEditar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox cbo_tipoitem;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox cbo_unvenda;
    }
}