namespace SIGRas
{
    partial class FrmProdutosConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProdutosConsulta));
            this.pan_titulo = new System.Windows.Forms.Panel();
            this.lb_totalregistros = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pan_barrainferior = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_limpar = new System.Windows.Forms.Button();
            this.btn_carregar = new System.Windows.Forms.Button();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_procurar = new System.Windows.Forms.TextBox();
            this.cbo_procurar = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lvw_produtos = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataCadastro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescricaoProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TipoItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Grupo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Familia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EAN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UNCompra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UNEstocagem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Estoque = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataAlteracao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VlrCompra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VlrVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UnVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Observacoes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.pan_titulo.Controls.Add(this.label17);
            this.pan_titulo.Controls.Add(this.label14);
            this.pan_titulo.Controls.Add(this.btnCerrar);
            this.pan_titulo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pan_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_titulo.Location = new System.Drawing.Point(0, 0);
            this.pan_titulo.Name = "pan_titulo";
            this.pan_titulo.Size = new System.Drawing.Size(815, 25);
            this.pan_titulo.TabIndex = 5;
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
            this.lb_totalregistros.TabIndex = 2;
            this.lb_totalregistros.Text = "Total Registros";
            this.lb_totalregistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(572, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 15);
            this.label17.TabIndex = 1;
            this.label17.Text = "Total Registros:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(12, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(189, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "Cadastro Produtos Consulta";
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
            this.panel1.Size = new System.Drawing.Size(15, 440);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(800, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 440);
            this.panel2.TabIndex = 7;
            // 
            // pan_barrainferior
            // 
            this.pan_barrainferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_barrainferior.Cursor = System.Windows.Forms.Cursors.Default;
            this.pan_barrainferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_barrainferior.Location = new System.Drawing.Point(15, 450);
            this.pan_barrainferior.Name = "pan_barrainferior";
            this.pan_barrainferior.Size = new System.Drawing.Size(785, 15);
            this.pan_barrainferior.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_limpar);
            this.groupBox2.Controls.Add(this.btn_carregar);
            this.groupBox2.Controls.Add(this.btn_fechar);
            this.groupBox2.Location = new System.Drawing.Point(523, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 80);
            this.groupBox2.TabIndex = 10;
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
            this.groupBox1.Location = new System.Drawing.Point(16, 364);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 80);
            this.groupBox1.TabIndex = 9;
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
            // lvw_produtos
            // 
            this.lvw_produtos.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvw_produtos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvw_produtos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.DataCadastro,
            this.Status,
            this.DescricaoProduto,
            this.TipoItem,
            this.Grupo,
            this.Familia,
            this.EAN,
            this.UNCompra,
            this.UNEstocagem,
            this.Estoque,
            this.DataAlteracao,
            this.VlrCompra,
            this.VlrVenda,
            this.UnVenda,
            this.Observacoes});
            this.lvw_produtos.FullRowSelect = true;
            this.lvw_produtos.GridLines = true;
            this.lvw_produtos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvw_produtos.HideSelection = false;
            this.lvw_produtos.HoverSelection = true;
            this.lvw_produtos.Location = new System.Drawing.Point(21, 31);
            this.lvw_produtos.Name = "lvw_produtos";
            this.lvw_produtos.ShowItemToolTips = true;
            this.lvw_produtos.Size = new System.Drawing.Size(773, 327);
            this.lvw_produtos.TabIndex = 11;
            this.lvw_produtos.UseCompatibleStateImageBehavior = false;
            this.lvw_produtos.View = System.Windows.Forms.View.Details;
            this.lvw_produtos.SelectedIndexChanged += new System.EventHandler(this.lvw_produtos_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 40;
            // 
            // DataCadastro
            // 
            this.DataCadastro.Text = "Data Cadastro";
            this.DataCadastro.Width = 110;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 80;
            // 
            // DescricaoProduto
            // 
            this.DescricaoProduto.Text = "Descrição Produto";
            this.DescricaoProduto.Width = 300;
            // 
            // TipoItem
            // 
            this.TipoItem.Text = "Tipo Ítem";
            this.TipoItem.Width = 200;
            // 
            // Grupo
            // 
            this.Grupo.Text = "Grupo";
            this.Grupo.Width = 100;
            // 
            // Familia
            // 
            this.Familia.Text = "Família";
            this.Familia.Width = 100;
            // 
            // EAN
            // 
            this.EAN.Text = "Código EAN";
            this.EAN.Width = 120;
            // 
            // UNCompra
            // 
            this.UNCompra.Text = "Un.Compra";
            this.UNCompra.Width = 100;
            // 
            // UNEstocagem
            // 
            this.UNEstocagem.Text = "Un.Estocagem";
            this.UNEstocagem.Width = 100;
            // 
            // Estoque
            // 
            this.Estoque.Text = "Estoque";
            this.Estoque.Width = 80;
            // 
            // DataAlteracao
            // 
            this.DataAlteracao.Text = "Data Alteração";
            this.DataAlteracao.Width = 110;
            // 
            // VlrCompra
            // 
            this.VlrCompra.Text = "Valor Compra";
            this.VlrCompra.Width = 100;
            // 
            // VlrVenda
            // 
            this.VlrVenda.Text = "Valor Venda";
            this.VlrVenda.Width = 100;
            // 
            // UnVenda
            // 
            this.UnVenda.Text = "UN Venda";
            this.UnVenda.Width = 80;
            // 
            // Observacoes
            // 
            this.Observacoes.Text = "Observações";
            this.Observacoes.Width = 100;
            // 
            // FrmProdutosConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(815, 465);
            this.Controls.Add(this.lvw_produtos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pan_barrainferior);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pan_titulo);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmProdutosConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmProdutosConsulta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProdutosConsulta_KeyDown);
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
        private System.Windows.Forms.Label lb_totalregistros;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pan_barrainferior;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_limpar;
        private System.Windows.Forms.Button btn_carregar;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_procurar;
        private System.Windows.Forms.ComboBox cbo_procurar;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListView lvw_produtos;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader DataCadastro;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader DescricaoProduto;
        private System.Windows.Forms.ColumnHeader TipoItem;
        private System.Windows.Forms.ColumnHeader Grupo;
        private System.Windows.Forms.ColumnHeader Familia;
        private System.Windows.Forms.ColumnHeader EAN;
        private System.Windows.Forms.ColumnHeader UNCompra;
        private System.Windows.Forms.ColumnHeader UNEstocagem;
        private System.Windows.Forms.ColumnHeader Estoque;
        private System.Windows.Forms.ColumnHeader DataAlteracao;
        private System.Windows.Forms.ColumnHeader VlrCompra;
        private System.Windows.Forms.ColumnHeader VlrVenda;
        private System.Windows.Forms.ColumnHeader UnVenda;
        private System.Windows.Forms.ColumnHeader Observacoes;
    }
}