namespace SIGRas
{
    partial class FrmNFConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNFConsulta));
            this.pan_titulo = new System.Windows.Forms.Panel();
            this.lb_totalregistros = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pan_barrainferior = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lvw_nfentradas = new System.Windows.Forms.ListView();
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
            this.IDProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescricaoProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UnVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PrecoProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QntProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescontoProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AcrescimoProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VlrTotalProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescontoTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AcrescimoTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QntProdutosTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VlrTotalDocumento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_limpar = new System.Windows.Forms.Button();
            this.btn_carregar = new System.Windows.Forms.Button();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_procurar = new System.Windows.Forms.TextBox();
            this.cbo_procurar = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pan_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_titulo
            // 
            this.pan_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_titulo.Controls.Add(this.lb_totalregistros);
            this.pan_titulo.Controls.Add(this.label1);
            this.pan_titulo.Controls.Add(this.label14);
            this.pan_titulo.Controls.Add(this.btnCerrar);
            this.pan_titulo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pan_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_titulo.Location = new System.Drawing.Point(0, 0);
            this.pan_titulo.Name = "pan_titulo";
            this.pan_titulo.Size = new System.Drawing.Size(815, 25);
            this.pan_titulo.TabIndex = 1;
            this.pan_titulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pan_titulo_MouseDown);
            // 
            // lb_totalregistros
            // 
            this.lb_totalregistros.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalregistros.ForeColor = System.Drawing.Color.White;
            this.lb_totalregistros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lb_totalregistros.Location = new System.Drawing.Point(666, 2);
            this.lb_totalregistros.Name = "lb_totalregistros";
            this.lb_totalregistros.Size = new System.Drawing.Size(110, 20);
            this.lb_totalregistros.TabIndex = 25;
            this.lb_totalregistros.Text = "Total Registros";
            this.lb_totalregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(572, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Total Registros:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(12, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(153, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "NF Completa Consulta";
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
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(800, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 575);
            this.panel2.TabIndex = 3;
            // 
            // pan_barrainferior
            // 
            this.pan_barrainferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_barrainferior.Cursor = System.Windows.Forms.Cursors.Default;
            this.pan_barrainferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_barrainferior.Location = new System.Drawing.Point(15, 585);
            this.pan_barrainferior.Name = "pan_barrainferior";
            this.pan_barrainferior.Size = new System.Drawing.Size(785, 15);
            this.pan_barrainferior.TabIndex = 4;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // lvw_nfentradas
            // 
            this.lvw_nfentradas.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvw_nfentradas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvw_nfentradas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.IDProduto,
            this.DescricaoProduto,
            this.UnVenda,
            this.PrecoProduto,
            this.QntProduto,
            this.DescontoProduto,
            this.AcrescimoProduto,
            this.VlrTotalProduto,
            this.DescontoTotal,
            this.AcrescimoTotal,
            this.QntProdutosTotal,
            this.VlrTotalDocumento});
            this.lvw_nfentradas.FullRowSelect = true;
            this.lvw_nfentradas.GridLines = true;
            this.lvw_nfentradas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvw_nfentradas.HideSelection = false;
            this.lvw_nfentradas.HoverSelection = true;
            this.lvw_nfentradas.Location = new System.Drawing.Point(21, 31);
            this.lvw_nfentradas.Name = "lvw_nfentradas";
            this.lvw_nfentradas.ShowItemToolTips = true;
            this.lvw_nfentradas.Size = new System.Drawing.Size(773, 462);
            this.lvw_nfentradas.TabIndex = 11;
            this.lvw_nfentradas.UseCompatibleStateImageBehavior = false;
            this.lvw_nfentradas.View = System.Windows.Forms.View.Details;
            this.lvw_nfentradas.SelectedIndexChanged += new System.EventHandler(this.lvw_nfentradas_SelectedIndexChanged);
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
            // IDProduto
            // 
            this.IDProduto.Text = "Cód. Produto";
            this.IDProduto.Width = 110;
            // 
            // DescricaoProduto
            // 
            this.DescricaoProduto.Text = "Descrição Produto";
            this.DescricaoProduto.Width = 200;
            // 
            // UnVenda
            // 
            this.UnVenda.Text = "Un. Venda";
            this.UnVenda.Width = 70;
            // 
            // PrecoProduto
            // 
            this.PrecoProduto.Text = "Preço UN. Produto";
            this.PrecoProduto.Width = 120;
            // 
            // QntProduto
            // 
            this.QntProduto.Text = "Qtde";
            this.QntProduto.Width = 70;
            // 
            // DescontoProduto
            // 
            this.DescontoProduto.Text = "Desc. Produto";
            this.DescontoProduto.Width = 120;
            // 
            // AcrescimoProduto
            // 
            this.AcrescimoProduto.Text = "Acresc. Produto";
            this.AcrescimoProduto.Width = 120;
            // 
            // VlrTotalProduto
            // 
            this.VlrTotalProduto.Text = "Vlr. Total Produto";
            this.VlrTotalProduto.Width = 120;
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
            this.groupBox2.Controls.Add(this.btn_limpar);
            this.groupBox2.Controls.Add(this.btn_carregar);
            this.groupBox2.Controls.Add(this.btn_fechar);
            this.groupBox2.Location = new System.Drawing.Point(528, 499);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 80);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
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
            this.btn_fechar.Location = new System.Drawing.Point(178, 14);
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
            this.groupBox1.Size = new System.Drawing.Size(501, 80);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // txt_procurar
            // 
            this.txt_procurar.BackColor = System.Drawing.SystemColors.Window;
            this.txt_procurar.Location = new System.Drawing.Point(165, 37);
            this.txt_procurar.Name = "txt_procurar";
            this.txt_procurar.Size = new System.Drawing.Size(330, 23);
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
            // FrmNFConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(815, 600);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvw_nfentradas);
            this.Controls.Add(this.pan_barrainferior);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pan_titulo);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmNFConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmNFConsulta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmNFConsulta_KeyDown);
            this.pan_titulo.ResumeLayout(false);
            this.pan_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_titulo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pan_barrainferior;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.ListView lvw_nfentradas;
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
        private System.Windows.Forms.ColumnHeader IDProduto;
        private System.Windows.Forms.ColumnHeader DescricaoProduto;
        private System.Windows.Forms.ColumnHeader UnVenda;
        private System.Windows.Forms.ColumnHeader PrecoProduto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_limpar;
        private System.Windows.Forms.Button btn_carregar;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_procurar;
        private System.Windows.Forms.ComboBox cbo_procurar;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ColumnHeader QntProduto;
        private System.Windows.Forms.ColumnHeader DescontoProduto;
        private System.Windows.Forms.ColumnHeader AcrescimoProduto;
        private System.Windows.Forms.ColumnHeader VlrTotalProduto;
        private System.Windows.Forms.ColumnHeader DescontoTotal;
        private System.Windows.Forms.ColumnHeader AcrescimoTotal;
        private System.Windows.Forms.ColumnHeader QntProdutosTotal;
        private System.Windows.Forms.ColumnHeader VlrTotalDocumento;
        private System.Windows.Forms.Label lb_totalregistros;
        private System.Windows.Forms.Label label1;
    }
}