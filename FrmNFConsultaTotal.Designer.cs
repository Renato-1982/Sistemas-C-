namespace SIGRas
{
    partial class FrmNFConsultaTotal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNFConsultaTotal));
            this.pan_titulo = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pan_barrainferior = new System.Windows.Forms.Panel();
            this.lvw_nftotal = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IdOperacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescricaoOperacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Modelo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Especie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Serie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Documentonr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Emissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Referencia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IDFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescricaoFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EstadoFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FormaPagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PrazoPagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescontoTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AcrescimoTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QntProdutosTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VlrTotalDocumento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_consultar = new System.Windows.Forms.Button();
            this.btn_limpar = new System.Windows.Forms.Button();
            this.btn_carregar = new System.Windows.Forms.Button();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_procurar = new System.Windows.Forms.TextBox();
            this.cbo_procurar = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_saldofinal = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_totalregistros = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pan_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.pan_titulo.Size = new System.Drawing.Size(815, 25);
            this.pan_titulo.TabIndex = 2;
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
            this.label14.Size = new System.Drawing.Size(155, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "NF Resumida Consulta";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(782, 4);
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
            this.panel1.Size = new System.Drawing.Size(15, 575);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(800, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 575);
            this.panel2.TabIndex = 4;
            // 
            // pan_barrainferior
            // 
            this.pan_barrainferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_barrainferior.Cursor = System.Windows.Forms.Cursors.Default;
            this.pan_barrainferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_barrainferior.Location = new System.Drawing.Point(15, 585);
            this.pan_barrainferior.Name = "pan_barrainferior";
            this.pan_barrainferior.Size = new System.Drawing.Size(785, 15);
            this.pan_barrainferior.TabIndex = 5;
            // 
            // lvw_nftotal
            // 
            this.lvw_nftotal.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvw_nftotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvw_nftotal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.IdOperacao,
            this.DescricaoOperacao,
            this.Modelo,
            this.Especie,
            this.Serie,
            this.Documentonr,
            this.Emissao,
            this.Referencia,
            this.IDFornecedor,
            this.DescricaoFornecedor,
            this.EstadoFornecedor,
            this.FormaPagamento,
            this.PrazoPagamento,
            this.DescontoTotal,
            this.AcrescimoTotal,
            this.QntProdutosTotal,
            this.VlrTotalDocumento});
            this.lvw_nftotal.FullRowSelect = true;
            this.lvw_nftotal.GridLines = true;
            this.lvw_nftotal.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvw_nftotal.HideSelection = false;
            this.lvw_nftotal.HoverSelection = true;
            this.lvw_nftotal.Location = new System.Drawing.Point(21, 28);
            this.lvw_nftotal.Name = "lvw_nftotal";
            this.lvw_nftotal.ShowItemToolTips = true;
            this.lvw_nftotal.Size = new System.Drawing.Size(773, 393);
            this.lvw_nftotal.TabIndex = 12;
            this.lvw_nftotal.UseCompatibleStateImageBehavior = false;
            this.lvw_nftotal.View = System.Windows.Forms.View.Details;
            this.lvw_nftotal.SelectedIndexChanged += new System.EventHandler(this.lvw_nftotal_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "Cód.";
            this.ID.Width = 40;
            // 
            // IdOperacao
            // 
            this.IdOperacao.Text = "Operação";
            this.IdOperacao.Width = 70;
            // 
            // DescricaoOperacao
            // 
            this.DescricaoOperacao.Text = "Descrição Operação";
            this.DescricaoOperacao.Width = 200;
            // 
            // Modelo
            // 
            this.Modelo.Text = "Modelo";
            // 
            // Especie
            // 
            this.Especie.Text = "Espécie";
            // 
            // Serie
            // 
            this.Serie.Text = "Série";
            // 
            // Documentonr
            // 
            this.Documentonr.Text = "Nº Documento";
            this.Documentonr.Width = 120;
            // 
            // Emissao
            // 
            this.Emissao.Text = "Emissão";
            this.Emissao.Width = 90;
            // 
            // Referencia
            // 
            this.Referencia.Text = "Referência";
            this.Referencia.Width = 90;
            // 
            // IDFornecedor
            // 
            this.IDFornecedor.Text = "Cód. Fornecedor";
            this.IDFornecedor.Width = 110;
            // 
            // DescricaoFornecedor
            // 
            this.DescricaoFornecedor.Text = "Descrição Fornecedor";
            this.DescricaoFornecedor.Width = 200;
            // 
            // EstadoFornecedor
            // 
            this.EstadoFornecedor.Text = "Estado";
            // 
            // FormaPagamento
            // 
            this.FormaPagamento.Text = "Forma Pagamento";
            this.FormaPagamento.Width = 150;
            // 
            // PrazoPagamento
            // 
            this.PrazoPagamento.Text = "Prazo Pagamento";
            this.PrazoPagamento.Width = 150;
            // 
            // DescontoTotal
            // 
            this.DescontoTotal.Text = "Desc. Total NF";
            this.DescontoTotal.Width = 120;
            // 
            // AcrescimoTotal
            // 
            this.AcrescimoTotal.Text = "Acresc. Total NF";
            this.AcrescimoTotal.Width = 120;
            // 
            // QntProdutosTotal
            // 
            this.QntProdutosTotal.Text = "Qtde Produto NF";
            this.QntProdutosTotal.Width = 120;
            // 
            // VlrTotalDocumento
            // 
            this.VlrTotalDocumento.Text = "Vlr. Total NF";
            this.VlrTotalDocumento.Width = 120;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_consultar);
            this.groupBox2.Controls.Add(this.btn_limpar);
            this.groupBox2.Controls.Add(this.btn_carregar);
            this.groupBox2.Controls.Add(this.btn_fechar);
            this.groupBox2.Location = new System.Drawing.Point(614, 427);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 152);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // btn_consultar
            // 
            this.btn_consultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_consultar.FlatAppearance.BorderSize = 0;
            this.btn_consultar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_consultar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_consultar.ForeColor = System.Drawing.Color.White;
            this.btn_consultar.Image = ((System.Drawing.Image)(resources.GetObject("btn_consultar.Image")));
            this.btn_consultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_consultar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_consultar.Location = new System.Drawing.Point(8, 86);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(78, 60);
            this.btn_consultar.TabIndex = 6;
            this.btn_consultar.Text = "Buscar";
            this.btn_consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_consultar.UseVisualStyleBackColor = false;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // btn_limpar
            // 
            this.btn_limpar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_limpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_limpar.FlatAppearance.BorderSize = 0;
            this.btn_limpar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_limpar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_limpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_limpar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_limpar.ForeColor = System.Drawing.Color.White;
            this.btn_limpar.Image = ((System.Drawing.Image)(resources.GetObject("btn_limpar.Image")));
            this.btn_limpar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_limpar.Location = new System.Drawing.Point(6, 14);
            this.btn_limpar.Name = "btn_limpar";
            this.btn_limpar.Size = new System.Drawing.Size(80, 60);
            this.btn_limpar.TabIndex = 0;
            this.btn_limpar.Text = "Limpar";
            this.btn_limpar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_limpar.UseVisualStyleBackColor = false;
            this.btn_limpar.Click += new System.EventHandler(this.btn_limpar_Click);
            // 
            // btn_carregar
            // 
            this.btn_carregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_carregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_carregar.FlatAppearance.BorderSize = 0;
            this.btn_carregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_carregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_carregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_carregar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_carregar.ForeColor = System.Drawing.Color.White;
            this.btn_carregar.Image = ((System.Drawing.Image)(resources.GetObject("btn_carregar.Image")));
            this.btn_carregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_carregar.Location = new System.Drawing.Point(92, 14);
            this.btn_carregar.Name = "btn_carregar";
            this.btn_carregar.Size = new System.Drawing.Size(80, 60);
            this.btn_carregar.TabIndex = 1;
            this.btn_carregar.Text = "Carregar";
            this.btn_carregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_carregar.UseVisualStyleBackColor = false;
            this.btn_carregar.Click += new System.EventHandler(this.btn_carregar_Click);
            // 
            // btn_fechar
            // 
            this.btn_fechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_fechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_fechar.FlatAppearance.BorderSize = 0;
            this.btn_fechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_fechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fechar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fechar.ForeColor = System.Drawing.Color.White;
            this.btn_fechar.Image = ((System.Drawing.Image)(resources.GetObject("btn_fechar.Image")));
            this.btn_fechar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_fechar.Location = new System.Drawing.Point(92, 86);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(80, 60);
            this.btn_fechar.TabIndex = 2;
            this.btn_fechar.Text = "Sair";
            this.btn_fechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_fechar.UseVisualStyleBackColor = false;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_procurar);
            this.groupBox1.Controls.Add(this.cbo_procurar);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Location = new System.Drawing.Point(21, 499);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 80);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // txt_procurar
            // 
            this.txt_procurar.BackColor = System.Drawing.SystemColors.Window;
            this.txt_procurar.Location = new System.Drawing.Point(165, 37);
            this.txt_procurar.Name = "txt_procurar";
            this.txt_procurar.Size = new System.Drawing.Size(416, 23);
            this.txt_procurar.TabIndex = 3;
            this.txt_procurar.TextChanged += new System.EventHandler(this.txt_procurar_TextChanged);
            // 
            // cbo_procurar
            // 
            this.cbo_procurar.BackColor = System.Drawing.SystemColors.Window;
            this.cbo_procurar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbo_procurar.FormattingEnabled = true;
            this.cbo_procurar.Location = new System.Drawing.Point(9, 37);
            this.cbo_procurar.Name = "cbo_procurar";
            this.cbo_procurar.Size = new System.Drawing.Size(150, 23);
            this.cbo_procurar.TabIndex = 1;
            this.cbo_procurar.SelectedIndexChanged += new System.EventHandler(this.cbo_procurar_SelectedIndexChanged);
            this.cbo_procurar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_procurar_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(6, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 15);
            this.label19.TabIndex = 0;
            this.label19.Text = "Procurar";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9F);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(162, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(307, 14);
            this.label20.TabIndex = 2;
            this.label20.Text = "Selecione o valor da caixa Procurar e informe o critério.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_saldofinal);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txt_totalregistros);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(21, 427);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(587, 65);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // txt_saldofinal
            // 
            this.txt_saldofinal.BackColor = System.Drawing.Color.Lavender;
            this.txt_saldofinal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_saldofinal.Location = new System.Drawing.Point(9, 29);
            this.txt_saldofinal.Name = "txt_saldofinal";
            this.txt_saldofinal.Size = new System.Drawing.Size(366, 23);
            this.txt_saldofinal.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(5, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(117, 15);
            this.label18.TabIndex = 4;
            this.label18.Text = "Valor Total de Notas";
            // 
            // txt_totalregistros
            // 
            this.txt_totalregistros.BackColor = System.Drawing.SystemColors.Window;
            this.txt_totalregistros.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalregistros.Location = new System.Drawing.Point(381, 29);
            this.txt_totalregistros.Name = "txt_totalregistros";
            this.txt_totalregistros.Size = new System.Drawing.Size(200, 23);
            this.txt_totalregistros.TabIndex = 7;
            this.txt_totalregistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(378, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 15);
            this.label17.TabIndex = 6;
            this.label17.Text = "Total Registros";
            // 
            // FrmNFConsultaTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(815, 600);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvw_nftotal);
            this.Controls.Add(this.pan_barrainferior);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pan_titulo);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmNFConsultaTotal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmNFConsultaTotal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmNFConsultaTotal_KeyDown);
            this.pan_titulo.ResumeLayout(false);
            this.pan_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_titulo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pan_barrainferior;
        private System.Windows.Forms.ListView lvw_nftotal;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader IdOperacao;
        private System.Windows.Forms.ColumnHeader DescricaoOperacao;
        private System.Windows.Forms.ColumnHeader Modelo;
        private System.Windows.Forms.ColumnHeader Especie;
        private System.Windows.Forms.ColumnHeader Serie;
        private System.Windows.Forms.ColumnHeader Documentonr;
        private System.Windows.Forms.ColumnHeader Emissao;
        private System.Windows.Forms.ColumnHeader Referencia;
        private System.Windows.Forms.ColumnHeader IDFornecedor;
        private System.Windows.Forms.ColumnHeader DescricaoFornecedor;
        private System.Windows.Forms.ColumnHeader EstadoFornecedor;
        private System.Windows.Forms.ColumnHeader FormaPagamento;
        private System.Windows.Forms.ColumnHeader PrazoPagamento;
        private System.Windows.Forms.ColumnHeader DescontoTotal;
        private System.Windows.Forms.ColumnHeader AcrescimoTotal;
        private System.Windows.Forms.ColumnHeader QntProdutosTotal;
        private System.Windows.Forms.ColumnHeader VlrTotalDocumento;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_limpar;
        private System.Windows.Forms.Button btn_carregar;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_procurar;
        private System.Windows.Forms.ComboBox cbo_procurar;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_saldofinal;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_totalregistros;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.Button btn_consultar;
    }
}