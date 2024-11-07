namespace SIGRas
{
    partial class FrmVendasPDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVendasPDV));
            this.pan_titulo = new System.Windows.Forms.Panel();
            this.lbl_marcasistema = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pan_barrainferior = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_vendas = new System.Windows.Forms.TextBox();
            this.txt_totalvenda = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gb_cliente = new System.Windows.Forms.GroupBox();
            this.btn_liberacliente = new System.Windows.Forms.Button();
            this.txt_cliente = new System.Windows.Forms.TextBox();
            this.lbl_cliente = new System.Windows.Forms.Label();
            this.gb_produtos = new System.Windows.Forms.GroupBox();
            this.txt_precounitproduto = new System.Windows.Forms.TextBox();
            this.txt_qntproduto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_descontoproduto = new System.Windows.Forms.TextBox();
            this.txt_totalproduto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_nomeproduto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_idproduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_logo = new System.Windows.Forms.GroupBox();
            this.lbl_estadoemp = new System.Windows.Forms.Label();
            this.lbl_telefoneemp = new System.Windows.Forms.Label();
            this.lbl_horaemp = new System.Windows.Forms.Label();
            this.lbl_cidadeemp = new System.Windows.Forms.Label();
            this.lbl_bairroemp = new System.Windows.Forms.Label();
            this.lbl_numeroemp = new System.Windows.Forms.Label();
            this.lbl_ruaemp = new System.Windows.Forms.Label();
            this.lbl_cepemp = new System.Windows.Forms.Label();
            this.lbl_cnpjemp = new System.Windows.Forms.Label();
            this.lbl_dataemp = new System.Windows.Forms.Label();
            this.lbl_nomeemp = new System.Windows.Forms.Label();
            this.gb_caixalivrefechado = new System.Windows.Forms.GroupBox();
            this.lbl_codvenda = new System.Windows.Forms.Label();
            this.lbl_cxlivre = new System.Windows.Forms.Label();
            this.gb_totalvendas = new System.Windows.Forms.GroupBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_novavenda = new System.Windows.Forms.Button();
            this.btn_addproduto = new System.Windows.Forms.Button();
            this.btn_finalizarvenda = new System.Windows.Forms.Button();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.lvw_vendas = new System.Windows.Forms.ListView();
            this.txt_unidadevenda = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.timer_pdv = new System.Windows.Forms.Timer(this.components);
            this.pan_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.gb_cliente.SuspendLayout();
            this.gb_produtos.SuspendLayout();
            this.gb_logo.SuspendLayout();
            this.gb_caixalivrefechado.SuspendLayout();
            this.gb_totalvendas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_titulo
            // 
            this.pan_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_titulo.Controls.Add(this.lbl_marcasistema);
            this.pan_titulo.Controls.Add(this.label14);
            this.pan_titulo.Controls.Add(this.btnCerrar);
            this.pan_titulo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pan_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_titulo.Location = new System.Drawing.Point(0, 0);
            this.pan_titulo.Name = "pan_titulo";
            this.pan_titulo.Size = new System.Drawing.Size(840, 25);
            this.pan_titulo.TabIndex = 3;
            this.pan_titulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pan_titulo_MouseDown);
            // 
            // lbl_marcasistema
            // 
            this.lbl_marcasistema.AutoSize = true;
            this.lbl_marcasistema.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_marcasistema.ForeColor = System.Drawing.Color.White;
            this.lbl_marcasistema.Location = new System.Drawing.Point(54, 5);
            this.lbl_marcasistema.Name = "lbl_marcasistema";
            this.lbl_marcasistema.Size = new System.Drawing.Size(149, 15);
            this.lbl_marcasistema.TabIndex = 24;
            this.lbl_marcasistema.Text = "MultSeg - RAS Consultoria";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(12, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "PDV";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(799, 3);
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
            this.panel1.Size = new System.Drawing.Size(15, 545);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(825, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 545);
            this.panel2.TabIndex = 5;
            // 
            // pan_barrainferior
            // 
            this.pan_barrainferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_barrainferior.Cursor = System.Windows.Forms.Cursors.Default;
            this.pan_barrainferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_barrainferior.Location = new System.Drawing.Point(15, 555);
            this.pan_barrainferior.Name = "pan_barrainferior";
            this.pan_barrainferior.Size = new System.Drawing.Size(810, 15);
            this.pan_barrainferior.TabIndex = 6;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(706, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 33;
            this.label6.Text = "Vlr. Total";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(654, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 15);
            this.label13.TabIndex = 32;
            this.label13.Text = "Desc.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(608, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 15);
            this.label12.TabIndex = 31;
            this.label12.Text = "Qtd.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(546, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 15);
            this.label11.TabIndex = 30;
            this.label11.Text = "Vlr. Un.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(351, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 29;
            this.label10.Text = "Descrição";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(304, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "Cod.";
            // 
            // txt_vendas
            // 
            this.txt_vendas.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_vendas.Location = new System.Drawing.Point(302, 108);
            this.txt_vendas.Multiline = true;
            this.txt_vendas.Name = "txt_vendas";
            this.txt_vendas.Size = new System.Drawing.Size(515, 280);
            this.txt_vendas.TabIndex = 34;
            // 
            // txt_totalvenda
            // 
            this.txt_totalvenda.BackColor = System.Drawing.SystemColors.Control;
            this.txt_totalvenda.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalvenda.Location = new System.Drawing.Point(567, 403);
            this.txt_totalvenda.Name = "txt_totalvenda";
            this.txt_totalvenda.Size = new System.Drawing.Size(250, 37);
            this.txt_totalvenda.TabIndex = 36;
            this.txt_totalvenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_totalvenda.TextChanged += new System.EventHandler(this.txt_totalvenda_TextChanged);
            this.txt_totalvenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_totalvenda_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(434, 405);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 33);
            this.label7.TabIndex = 35;
            this.label7.Text = "Valor Total";
            // 
            // gb_cliente
            // 
            this.gb_cliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.gb_cliente.Controls.Add(this.btn_liberacliente);
            this.gb_cliente.Controls.Add(this.txt_cliente);
            this.gb_cliente.Controls.Add(this.lbl_cliente);
            this.gb_cliente.ForeColor = System.Drawing.Color.White;
            this.gb_cliente.Location = new System.Drawing.Point(21, 182);
            this.gb_cliente.Name = "gb_cliente";
            this.gb_cliente.Size = new System.Drawing.Size(275, 65);
            this.gb_cliente.TabIndex = 26;
            this.gb_cliente.TabStop = false;
            // 
            // btn_liberacliente
            // 
            this.btn_liberacliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_liberacliente.FlatAppearance.BorderSize = 0;
            this.btn_liberacliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_liberacliente.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_liberacliente.ForeColor = System.Drawing.Color.White;
            this.btn_liberacliente.Location = new System.Drawing.Point(244, 29);
            this.btn_liberacliente.Name = "btn_liberacliente";
            this.btn_liberacliente.Size = new System.Drawing.Size(25, 25);
            this.btn_liberacliente.TabIndex = 23;
            this.btn_liberacliente.Text = "?";
            this.btn_liberacliente.UseVisualStyleBackColor = false;
            this.btn_liberacliente.Click += new System.EventHandler(this.btn_liberacliente_Click);
            // 
            // txt_cliente
            // 
            this.txt_cliente.BackColor = System.Drawing.SystemColors.Control;
            this.txt_cliente.Location = new System.Drawing.Point(7, 30);
            this.txt_cliente.Name = "txt_cliente";
            this.txt_cliente.Size = new System.Drawing.Size(231, 23);
            this.txt_cliente.TabIndex = 1;
            this.txt_cliente.Leave += new System.EventHandler(this.txt_cliente_Leave);
            // 
            // lbl_cliente
            // 
            this.lbl_cliente.AutoSize = true;
            this.lbl_cliente.ForeColor = System.Drawing.Color.White;
            this.lbl_cliente.Location = new System.Drawing.Point(4, 12);
            this.lbl_cliente.Name = "lbl_cliente";
            this.lbl_cliente.Size = new System.Drawing.Size(45, 15);
            this.lbl_cliente.TabIndex = 0;
            this.lbl_cliente.Text = "Cliente";
            // 
            // gb_produtos
            // 
            this.gb_produtos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.gb_produtos.Controls.Add(this.txt_unidadevenda);
            this.gb_produtos.Controls.Add(this.label15);
            this.gb_produtos.Controls.Add(this.txt_precounitproduto);
            this.gb_produtos.Controls.Add(this.txt_qntproduto);
            this.gb_produtos.Controls.Add(this.label3);
            this.gb_produtos.Controls.Add(this.label8);
            this.gb_produtos.Controls.Add(this.txt_descontoproduto);
            this.gb_produtos.Controls.Add(this.txt_totalproduto);
            this.gb_produtos.Controls.Add(this.label4);
            this.gb_produtos.Controls.Add(this.label5);
            this.gb_produtos.Controls.Add(this.txt_nomeproduto);
            this.gb_produtos.Controls.Add(this.label2);
            this.gb_produtos.Controls.Add(this.txt_idproduto);
            this.gb_produtos.Controls.Add(this.label1);
            this.gb_produtos.ForeColor = System.Drawing.Color.White;
            this.gb_produtos.Location = new System.Drawing.Point(21, 253);
            this.gb_produtos.Name = "gb_produtos";
            this.gb_produtos.Size = new System.Drawing.Size(275, 195);
            this.gb_produtos.TabIndex = 27;
            this.gb_produtos.TabStop = false;
            // 
            // txt_precounitproduto
            // 
            this.txt_precounitproduto.BackColor = System.Drawing.SystemColors.Control;
            this.txt_precounitproduto.Location = new System.Drawing.Point(77, 118);
            this.txt_precounitproduto.Name = "txt_precounitproduto";
            this.txt_precounitproduto.Size = new System.Drawing.Size(90, 23);
            this.txt_precounitproduto.TabIndex = 7;
            this.txt_precounitproduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_precounitproduto.TextChanged += new System.EventHandler(this.txt_precounitproduto_TextChanged);
            this.txt_precounitproduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_precounitproduto_KeyPress);
            // 
            // txt_qntproduto
            // 
            this.txt_qntproduto.BackColor = System.Drawing.SystemColors.Control;
            this.txt_qntproduto.Location = new System.Drawing.Point(173, 118);
            this.txt_qntproduto.Name = "txt_qntproduto";
            this.txt_qntproduto.Size = new System.Drawing.Size(96, 23);
            this.txt_qntproduto.TabIndex = 5;
            this.txt_qntproduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_qntproduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_qntproduto_KeyPress);
            this.txt_qntproduto.Leave += new System.EventHandler(this.txt_qntproduto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(170, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantidade";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(74, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Preço Unit.";
            // 
            // txt_descontoproduto
            // 
            this.txt_descontoproduto.BackColor = System.Drawing.SystemColors.Control;
            this.txt_descontoproduto.Location = new System.Drawing.Point(6, 162);
            this.txt_descontoproduto.Name = "txt_descontoproduto";
            this.txt_descontoproduto.Size = new System.Drawing.Size(120, 23);
            this.txt_descontoproduto.TabIndex = 9;
            this.txt_descontoproduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_descontoproduto.TextChanged += new System.EventHandler(this.txt_descontoproduto_TextChanged);
            this.txt_descontoproduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_descontoproduto_KeyPress);
            this.txt_descontoproduto.Leave += new System.EventHandler(this.txt_descontoproduto_Leave);
            // 
            // txt_totalproduto
            // 
            this.txt_totalproduto.BackColor = System.Drawing.SystemColors.Control;
            this.txt_totalproduto.Location = new System.Drawing.Point(132, 162);
            this.txt_totalproduto.Name = "txt_totalproduto";
            this.txt_totalproduto.Size = new System.Drawing.Size(137, 23);
            this.txt_totalproduto.TabIndex = 11;
            this.txt_totalproduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_totalproduto.TextChanged += new System.EventHandler(this.txt_totalproduto_TextChanged);
            this.txt_totalproduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_totalproduto_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Desconto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(129, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total Produto";
            // 
            // txt_nomeproduto
            // 
            this.txt_nomeproduto.BackColor = System.Drawing.SystemColors.Control;
            this.txt_nomeproduto.Location = new System.Drawing.Point(6, 74);
            this.txt_nomeproduto.Name = "txt_nomeproduto";
            this.txt_nomeproduto.Size = new System.Drawing.Size(263, 23);
            this.txt_nomeproduto.TabIndex = 3;
            this.txt_nomeproduto.Leave += new System.EventHandler(this.txt_nomeproduto_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome Produto";
            // 
            // txt_idproduto
            // 
            this.txt_idproduto.BackColor = System.Drawing.SystemColors.Control;
            this.txt_idproduto.Location = new System.Drawing.Point(6, 30);
            this.txt_idproduto.Name = "txt_idproduto";
            this.txt_idproduto.Size = new System.Drawing.Size(263, 23);
            this.txt_idproduto.TabIndex = 1;
            this.txt_idproduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_idproduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_idproduto_KeyPress);
            this.txt_idproduto.Leave += new System.EventHandler(this.txt_idproduto_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código Produto ou Código de Barras";
            // 
            // gb_logo
            // 
            this.gb_logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.gb_logo.Controls.Add(this.lbl_estadoemp);
            this.gb_logo.Controls.Add(this.lbl_telefoneemp);
            this.gb_logo.Controls.Add(this.lbl_horaemp);
            this.gb_logo.Controls.Add(this.lbl_cidadeemp);
            this.gb_logo.Controls.Add(this.lbl_bairroemp);
            this.gb_logo.Controls.Add(this.lbl_numeroemp);
            this.gb_logo.Controls.Add(this.lbl_ruaemp);
            this.gb_logo.Controls.Add(this.lbl_cepemp);
            this.gb_logo.Controls.Add(this.lbl_cnpjemp);
            this.gb_logo.Controls.Add(this.lbl_dataemp);
            this.gb_logo.Controls.Add(this.lbl_nomeemp);
            this.gb_logo.ForeColor = System.Drawing.Color.White;
            this.gb_logo.Location = new System.Drawing.Point(21, 31);
            this.gb_logo.Name = "gb_logo";
            this.gb_logo.Size = new System.Drawing.Size(275, 145);
            this.gb_logo.TabIndex = 25;
            this.gb_logo.TabStop = false;
            // 
            // lbl_estadoemp
            // 
            this.lbl_estadoemp.AutoSize = true;
            this.lbl_estadoemp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estadoemp.ForeColor = System.Drawing.Color.White;
            this.lbl_estadoemp.Location = new System.Drawing.Point(168, 75);
            this.lbl_estadoemp.Name = "lbl_estadoemp";
            this.lbl_estadoemp.Size = new System.Drawing.Size(44, 15);
            this.lbl_estadoemp.TabIndex = 9;
            this.lbl_estadoemp.Text = "Estado";
            // 
            // lbl_telefoneemp
            // 
            this.lbl_telefoneemp.AutoSize = true;
            this.lbl_telefoneemp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_telefoneemp.ForeColor = System.Drawing.Color.White;
            this.lbl_telefoneemp.Location = new System.Drawing.Point(168, 96);
            this.lbl_telefoneemp.Name = "lbl_telefoneemp";
            this.lbl_telefoneemp.Size = new System.Drawing.Size(102, 15);
            this.lbl_telefoneemp.TabIndex = 4;
            this.lbl_telefoneemp.Text = "Telefone Empresa";
            // 
            // lbl_horaemp
            // 
            this.lbl_horaemp.AutoSize = true;
            this.lbl_horaemp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_horaemp.ForeColor = System.Drawing.Color.White;
            this.lbl_horaemp.Location = new System.Drawing.Point(168, 117);
            this.lbl_horaemp.Name = "lbl_horaemp";
            this.lbl_horaemp.Size = new System.Drawing.Size(70, 15);
            this.lbl_horaemp.TabIndex = 10;
            this.lbl_horaemp.Text = "Hora Venda";
            // 
            // lbl_cidadeemp
            // 
            this.lbl_cidadeemp.AutoSize = true;
            this.lbl_cidadeemp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cidadeemp.ForeColor = System.Drawing.Color.White;
            this.lbl_cidadeemp.Location = new System.Drawing.Point(4, 75);
            this.lbl_cidadeemp.Name = "lbl_cidadeemp";
            this.lbl_cidadeemp.Size = new System.Drawing.Size(95, 15);
            this.lbl_cidadeemp.TabIndex = 6;
            this.lbl_cidadeemp.Text = "Cidade Empresa";
            // 
            // lbl_bairroemp
            // 
            this.lbl_bairroemp.AutoSize = true;
            this.lbl_bairroemp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bairroemp.ForeColor = System.Drawing.Color.White;
            this.lbl_bairroemp.Location = new System.Drawing.Point(84, 54);
            this.lbl_bairroemp.Name = "lbl_bairroemp";
            this.lbl_bairroemp.Size = new System.Drawing.Size(92, 15);
            this.lbl_bairroemp.TabIndex = 2;
            this.lbl_bairroemp.Text = "Bairro Empresa";
            // 
            // lbl_numeroemp
            // 
            this.lbl_numeroemp.AutoSize = true;
            this.lbl_numeroemp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_numeroemp.ForeColor = System.Drawing.Color.White;
            this.lbl_numeroemp.Location = new System.Drawing.Point(4, 54);
            this.lbl_numeroemp.Name = "lbl_numeroemp";
            this.lbl_numeroemp.Size = new System.Drawing.Size(50, 15);
            this.lbl_numeroemp.TabIndex = 8;
            this.lbl_numeroemp.Text = "Número";
            // 
            // lbl_ruaemp
            // 
            this.lbl_ruaemp.AutoSize = true;
            this.lbl_ruaemp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ruaemp.ForeColor = System.Drawing.Color.White;
            this.lbl_ruaemp.Location = new System.Drawing.Point(84, 33);
            this.lbl_ruaemp.Name = "lbl_ruaemp";
            this.lbl_ruaemp.Size = new System.Drawing.Size(107, 15);
            this.lbl_ruaemp.TabIndex = 1;
            this.lbl_ruaemp.Text = "Endereço Empresa";
            // 
            // lbl_cepemp
            // 
            this.lbl_cepemp.AutoSize = true;
            this.lbl_cepemp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cepemp.ForeColor = System.Drawing.Color.White;
            this.lbl_cepemp.Location = new System.Drawing.Point(4, 33);
            this.lbl_cepemp.Name = "lbl_cepemp";
            this.lbl_cepemp.Size = new System.Drawing.Size(27, 15);
            this.lbl_cepemp.TabIndex = 7;
            this.lbl_cepemp.Text = "Cep";
            // 
            // lbl_cnpjemp
            // 
            this.lbl_cnpjemp.AutoSize = true;
            this.lbl_cnpjemp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cnpjemp.ForeColor = System.Drawing.Color.White;
            this.lbl_cnpjemp.Location = new System.Drawing.Point(4, 96);
            this.lbl_cnpjemp.Name = "lbl_cnpjemp";
            this.lbl_cnpjemp.Size = new System.Drawing.Size(82, 15);
            this.lbl_cnpjemp.TabIndex = 3;
            this.lbl_cnpjemp.Text = "Cnpj Empresa";
            // 
            // lbl_dataemp
            // 
            this.lbl_dataemp.AutoSize = true;
            this.lbl_dataemp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dataemp.ForeColor = System.Drawing.Color.White;
            this.lbl_dataemp.Location = new System.Drawing.Point(4, 117);
            this.lbl_dataemp.Name = "lbl_dataemp";
            this.lbl_dataemp.Size = new System.Drawing.Size(69, 15);
            this.lbl_dataemp.TabIndex = 5;
            this.lbl_dataemp.Text = "Data Venda";
            // 
            // lbl_nomeemp
            // 
            this.lbl_nomeemp.AutoSize = true;
            this.lbl_nomeemp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nomeemp.ForeColor = System.Drawing.Color.White;
            this.lbl_nomeemp.Location = new System.Drawing.Point(4, 12);
            this.lbl_nomeemp.Name = "lbl_nomeemp";
            this.lbl_nomeemp.Size = new System.Drawing.Size(88, 15);
            this.lbl_nomeemp.TabIndex = 0;
            this.lbl_nomeemp.Text = "Nome Empresa";
            // 
            // gb_caixalivrefechado
            // 
            this.gb_caixalivrefechado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.gb_caixalivrefechado.Controls.Add(this.lbl_codvenda);
            this.gb_caixalivrefechado.Controls.Add(this.lbl_cxlivre);
            this.gb_caixalivrefechado.ForeColor = System.Drawing.Color.White;
            this.gb_caixalivrefechado.Location = new System.Drawing.Point(302, 31);
            this.gb_caixalivrefechado.Name = "gb_caixalivrefechado";
            this.gb_caixalivrefechado.Size = new System.Drawing.Size(515, 60);
            this.gb_caixalivrefechado.TabIndex = 24;
            this.gb_caixalivrefechado.TabStop = false;
            // 
            // lbl_codvenda
            // 
            this.lbl_codvenda.AutoSize = true;
            this.lbl_codvenda.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_codvenda.ForeColor = System.Drawing.Color.White;
            this.lbl_codvenda.Location = new System.Drawing.Point(6, 19);
            this.lbl_codvenda.Name = "lbl_codvenda";
            this.lbl_codvenda.Size = new System.Drawing.Size(25, 29);
            this.lbl_codvenda.TabIndex = 0;
            this.lbl_codvenda.Text = "0";
            // 
            // lbl_cxlivre
            // 
            this.lbl_cxlivre.AutoSize = true;
            this.lbl_cxlivre.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cxlivre.ForeColor = System.Drawing.Color.White;
            this.lbl_cxlivre.Location = new System.Drawing.Point(150, 12);
            this.lbl_cxlivre.Name = "lbl_cxlivre";
            this.lbl_cxlivre.Size = new System.Drawing.Size(192, 42);
            this.lbl_cxlivre.TabIndex = 1;
            this.lbl_cxlivre.Text = "CAIXA LIVRE";
            // 
            // gb_totalvendas
            // 
            this.gb_totalvendas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.gb_totalvendas.Controls.Add(this.btn_cancelar);
            this.gb_totalvendas.Controls.Add(this.btn_novavenda);
            this.gb_totalvendas.Controls.Add(this.btn_addproduto);
            this.gb_totalvendas.Controls.Add(this.btn_finalizarvenda);
            this.gb_totalvendas.Controls.Add(this.btn_fechar);
            this.gb_totalvendas.Location = new System.Drawing.Point(21, 458);
            this.gb_totalvendas.Name = "gb_totalvendas";
            this.gb_totalvendas.Size = new System.Drawing.Size(796, 90);
            this.gb_totalvendas.TabIndex = 37;
            this.gb_totalvendas.TabStop = false;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_cancelar.FlatAppearance.BorderSize = 0;
            this.btn_cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_cancelar.Location = new System.Drawing.Point(472, 16);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(140, 65);
            this.btn_cancelar.TabIndex = 3;
            this.btn_cancelar.Text = "Cancelar Venda";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_novavenda
            // 
            this.btn_novavenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_novavenda.FlatAppearance.BorderSize = 0;
            this.btn_novavenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_novavenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_novavenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_novavenda.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_novavenda.ForeColor = System.Drawing.Color.White;
            this.btn_novavenda.Image = ((System.Drawing.Image)(resources.GetObject("btn_novavenda.Image")));
            this.btn_novavenda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_novavenda.Location = new System.Drawing.Point(34, 16);
            this.btn_novavenda.Name = "btn_novavenda";
            this.btn_novavenda.Size = new System.Drawing.Size(140, 65);
            this.btn_novavenda.TabIndex = 0;
            this.btn_novavenda.Text = "Nova Venda";
            this.btn_novavenda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_novavenda.UseVisualStyleBackColor = false;
            this.btn_novavenda.Click += new System.EventHandler(this.btn_novavenda_Click);
            // 
            // btn_addproduto
            // 
            this.btn_addproduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_addproduto.FlatAppearance.BorderSize = 0;
            this.btn_addproduto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_addproduto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_addproduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addproduto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addproduto.ForeColor = System.Drawing.Color.White;
            this.btn_addproduto.Image = ((System.Drawing.Image)(resources.GetObject("btn_addproduto.Image")));
            this.btn_addproduto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_addproduto.Location = new System.Drawing.Point(180, 16);
            this.btn_addproduto.Name = "btn_addproduto";
            this.btn_addproduto.Size = new System.Drawing.Size(140, 65);
            this.btn_addproduto.TabIndex = 1;
            this.btn_addproduto.Text = "Adicionar Produto";
            this.btn_addproduto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_addproduto.UseVisualStyleBackColor = false;
            this.btn_addproduto.Click += new System.EventHandler(this.btn_addproduto_Click);
            // 
            // btn_finalizarvenda
            // 
            this.btn_finalizarvenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_finalizarvenda.FlatAppearance.BorderSize = 0;
            this.btn_finalizarvenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_finalizarvenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_finalizarvenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_finalizarvenda.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_finalizarvenda.ForeColor = System.Drawing.Color.White;
            this.btn_finalizarvenda.Image = ((System.Drawing.Image)(resources.GetObject("btn_finalizarvenda.Image")));
            this.btn_finalizarvenda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_finalizarvenda.Location = new System.Drawing.Point(326, 16);
            this.btn_finalizarvenda.Name = "btn_finalizarvenda";
            this.btn_finalizarvenda.Size = new System.Drawing.Size(140, 65);
            this.btn_finalizarvenda.TabIndex = 2;
            this.btn_finalizarvenda.Text = "Finalizar Venda";
            this.btn_finalizarvenda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_finalizarvenda.UseVisualStyleBackColor = false;
            this.btn_finalizarvenda.Click += new System.EventHandler(this.btn_finalizarvenda_Click);
            // 
            // btn_fechar
            // 
            this.btn_fechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_fechar.FlatAppearance.BorderSize = 0;
            this.btn_fechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_fechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fechar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fechar.ForeColor = System.Drawing.Color.White;
            this.btn_fechar.Image = ((System.Drawing.Image)(resources.GetObject("btn_fechar.Image")));
            this.btn_fechar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_fechar.Location = new System.Drawing.Point(618, 16);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(140, 65);
            this.btn_fechar.TabIndex = 4;
            this.btn_fechar.Text = "Fechar PDV";
            this.btn_fechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_fechar.UseVisualStyleBackColor = false;
            this.btn_fechar.Click += new System.EventHandler(this.btn_encerrar_Click);
            // 
            // lvw_vendas
            // 
            this.lvw_vendas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvw_vendas.FullRowSelect = true;
            this.lvw_vendas.HideSelection = false;
            this.lvw_vendas.Location = new System.Drawing.Point(21, 454);
            this.lvw_vendas.Name = "lvw_vendas";
            this.lvw_vendas.Size = new System.Drawing.Size(796, 5);
            this.lvw_vendas.TabIndex = 38;
            this.lvw_vendas.UseCompatibleStateImageBehavior = false;
            this.lvw_vendas.View = System.Windows.Forms.View.Details;
            // 
            // txt_unidadevenda
            // 
            this.txt_unidadevenda.BackColor = System.Drawing.SystemColors.Control;
            this.txt_unidadevenda.Location = new System.Drawing.Point(6, 118);
            this.txt_unidadevenda.Name = "txt_unidadevenda";
            this.txt_unidadevenda.Size = new System.Drawing.Size(65, 23);
            this.txt_unidadevenda.TabIndex = 13;
            this.txt_unidadevenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 15);
            this.label15.TabIndex = 12;
            this.label15.Text = "UN. Venda";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(508, 93);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 15);
            this.label16.TabIndex = 39;
            this.label16.Text = "Un";
            // 
            // timer_pdv
            // 
            this.timer_pdv.Enabled = true;
            this.timer_pdv.Interval = 1000;
            this.timer_pdv.Tick += new System.EventHandler(this.timer_pdv_Tick);
            // 
            // FrmVendasPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(840, 570);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lvw_vendas);
            this.Controls.Add(this.gb_totalvendas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_vendas);
            this.Controls.Add(this.txt_totalvenda);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gb_cliente);
            this.Controls.Add(this.gb_produtos);
            this.Controls.Add(this.gb_logo);
            this.Controls.Add(this.gb_caixalivrefechado);
            this.Controls.Add(this.pan_barrainferior);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pan_titulo);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmVendasPDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmVendasPDV_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVendasPDV_KeyDown);
            this.pan_titulo.ResumeLayout(false);
            this.pan_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.gb_cliente.ResumeLayout(false);
            this.gb_cliente.PerformLayout();
            this.gb_produtos.ResumeLayout(false);
            this.gb_produtos.PerformLayout();
            this.gb_logo.ResumeLayout(false);
            this.gb_logo.PerformLayout();
            this.gb_caixalivrefechado.ResumeLayout(false);
            this.gb_caixalivrefechado.PerformLayout();
            this.gb_totalvendas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pan_titulo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pan_barrainferior;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lbl_marcasistema;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_vendas;
        private System.Windows.Forms.TextBox txt_totalvenda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gb_cliente;
        private System.Windows.Forms.TextBox txt_cliente;
        private System.Windows.Forms.Label lbl_cliente;
        private System.Windows.Forms.GroupBox gb_produtos;
        private System.Windows.Forms.TextBox txt_precounitproduto;
        private System.Windows.Forms.TextBox txt_qntproduto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_descontoproduto;
        private System.Windows.Forms.TextBox txt_totalproduto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_nomeproduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_idproduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_logo;
        private System.Windows.Forms.Label lbl_estadoemp;
        private System.Windows.Forms.Label lbl_telefoneemp;
        private System.Windows.Forms.Label lbl_horaemp;
        private System.Windows.Forms.Label lbl_cidadeemp;
        private System.Windows.Forms.Label lbl_bairroemp;
        private System.Windows.Forms.Label lbl_numeroemp;
        private System.Windows.Forms.Label lbl_ruaemp;
        private System.Windows.Forms.Label lbl_cepemp;
        private System.Windows.Forms.Label lbl_cnpjemp;
        private System.Windows.Forms.Label lbl_dataemp;
        private System.Windows.Forms.Label lbl_nomeemp;
        private System.Windows.Forms.GroupBox gb_caixalivrefechado;
        private System.Windows.Forms.Label lbl_codvenda;
        private System.Windows.Forms.Label lbl_cxlivre;
        public System.Windows.Forms.Button btn_liberacliente;
        private System.Windows.Forms.GroupBox gb_totalvendas;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_novavenda;
        private System.Windows.Forms.Button btn_addproduto;
        private System.Windows.Forms.Button btn_finalizarvenda;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.ListView lvw_vendas;
        private System.Windows.Forms.TextBox txt_unidadevenda;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Timer timer_pdv;
    }
}