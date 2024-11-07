namespace SIGRas
{
    partial class FrmProdutosRelatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProdutosRelatorio));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.pan_titulo = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pan_barrainferior = new System.Windows.Forms.Panel();
            this.tc_cadastroprodutos = new System.Windows.Forms.TabControl();
            this.tp_statustipos = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btStatus = new System.Windows.Forms.Button();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.btStatusTipoItem = new System.Windows.Forms.Button();
            this.txt_tipoitemstatus = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txt_statustipoitem = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tp_gruposfamilia = new System.Windows.Forms.TabPage();
            this.btFamilia = new System.Windows.Forms.Button();
            this.txt_familia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btGrupo = new System.Windows.Forms.Button();
            this.txt_grupo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tp_descricao = new System.Windows.Forms.TabPage();
            this.btEanProduto = new System.Windows.Forms.Button();
            this.txt_eanproduto = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btDescricaoProduto = new System.Windows.Forms.Button();
            this.txt_descricaoproduto = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_carregartudo = new System.Windows.Forms.Button();
            this.btn_sair = new System.Windows.Forms.Button();
            this.RVprodutosbd = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_produtosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sigrassystembdDataSet = new SIGRas.sigrassystembdDataSet();
            this.tb_produtosTableAdapter = new SIGRas.sigrassystembdDataSetTableAdapters.tb_produtosTableAdapter();
            this.pan_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.tc_cadastroprodutos.SuspendLayout();
            this.tp_statustipos.SuspendLayout();
            this.tp_gruposfamilia.SuspendLayout();
            this.tp_descricao.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sigrassystembdDataSet)).BeginInit();
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
            this.pan_titulo.Size = new System.Drawing.Size(995, 25);
            this.pan_titulo.TabIndex = 1;
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
            this.label14.Size = new System.Drawing.Size(136, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "Produtos Relatórios";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(956, 3);
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
            this.panel2.Location = new System.Drawing.Point(980, 25);
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
            this.pan_barrainferior.Size = new System.Drawing.Size(965, 15);
            this.pan_barrainferior.TabIndex = 4;
            // 
            // tc_cadastroprodutos
            // 
            this.tc_cadastroprodutos.Controls.Add(this.tp_statustipos);
            this.tc_cadastroprodutos.Controls.Add(this.tp_gruposfamilia);
            this.tc_cadastroprodutos.Controls.Add(this.tp_descricao);
            this.tc_cadastroprodutos.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tc_cadastroprodutos.Location = new System.Drawing.Point(21, 31);
            this.tc_cadastroprodutos.Name = "tc_cadastroprodutos";
            this.tc_cadastroprodutos.SelectedIndex = 0;
            this.tc_cadastroprodutos.Size = new System.Drawing.Size(777, 85);
            this.tc_cadastroprodutos.TabIndex = 5;
            this.tc_cadastroprodutos.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tc_cadastroprodutos_DrawItem);
            // 
            // tp_statustipos
            // 
            this.tp_statustipos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.tp_statustipos.Controls.Add(this.label4);
            this.tp_statustipos.Controls.Add(this.btStatus);
            this.tp_statustipos.Controls.Add(this.txt_status);
            this.tp_statustipos.Controls.Add(this.label3);
            this.tp_statustipos.Controls.Add(this.label35);
            this.tp_statustipos.Controls.Add(this.btStatusTipoItem);
            this.tp_statustipos.Controls.Add(this.txt_tipoitemstatus);
            this.tp_statustipos.Controls.Add(this.label38);
            this.tp_statustipos.Controls.Add(this.txt_statustipoitem);
            this.tp_statustipos.Controls.Add(this.label42);
            this.tp_statustipos.ForeColor = System.Drawing.Color.White;
            this.tp_statustipos.Location = new System.Drawing.Point(4, 24);
            this.tp_statustipos.Name = "tp_statustipos";
            this.tp_statustipos.Padding = new System.Windows.Forms.Padding(3);
            this.tp_statustipos.Size = new System.Drawing.Size(769, 57);
            this.tp_statustipos.TabIndex = 1;
            this.tp_statustipos.Text = "Status|Tipos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(164, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 49);
            this.label4.TabIndex = 3;
            this.label4.Text = "|";
            // 
            // btStatus
            // 
            this.btStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btStatus.FlatAppearance.BorderSize = 0;
            this.btStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStatus.ForeColor = System.Drawing.Color.White;
            this.btStatus.Image = ((System.Drawing.Image)(resources.GetObject("btStatus.Image")));
            this.btStatus.Location = new System.Drawing.Point(132, 19);
            this.btStatus.Name = "btStatus";
            this.btStatus.Size = new System.Drawing.Size(28, 28);
            this.btStatus.TabIndex = 2;
            this.btStatus.UseVisualStyleBackColor = false;
            this.btStatus.Click += new System.EventHandler(this.btStatus_Click);
            // 
            // txt_status
            // 
            this.txt_status.Location = new System.Drawing.Point(6, 22);
            this.txt_status.Name = "txt_status";
            this.txt_status.Size = new System.Drawing.Size(120, 23);
            this.txt_status.TabIndex = 1;
            this.txt_status.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_status_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Status";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(332, 27);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(13, 15);
            this.label35.TabIndex = 6;
            this.label35.Text = "e";
            // 
            // btStatusTipoItem
            // 
            this.btStatusTipoItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btStatusTipoItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btStatusTipoItem.FlatAppearance.BorderSize = 0;
            this.btStatusTipoItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btStatusTipoItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btStatusTipoItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStatusTipoItem.ForeColor = System.Drawing.Color.White;
            this.btStatusTipoItem.Image = ((System.Drawing.Image)(resources.GetObject("btStatusTipoItem.Image")));
            this.btStatusTipoItem.Location = new System.Drawing.Point(555, 19);
            this.btStatusTipoItem.Name = "btStatusTipoItem";
            this.btStatusTipoItem.Size = new System.Drawing.Size(28, 28);
            this.btStatusTipoItem.TabIndex = 12;
            this.btStatusTipoItem.UseVisualStyleBackColor = false;
            this.btStatusTipoItem.Click += new System.EventHandler(this.btStatusTipoItem_Click);
            // 
            // txt_tipoitemstatus
            // 
            this.txt_tipoitemstatus.Location = new System.Drawing.Point(349, 22);
            this.txt_tipoitemstatus.Name = "txt_tipoitemstatus";
            this.txt_tipoitemstatus.Size = new System.Drawing.Size(200, 23);
            this.txt_tipoitemstatus.TabIndex = 11;
            this.txt_tipoitemstatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_tipoitemstatus_KeyPress);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(346, 4);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(58, 15);
            this.label38.TabIndex = 10;
            this.label38.Text = "Tipo Ítem";
            // 
            // txt_statustipoitem
            // 
            this.txt_statustipoitem.Location = new System.Drawing.Point(208, 22);
            this.txt_statustipoitem.Name = "txt_statustipoitem";
            this.txt_statustipoitem.Size = new System.Drawing.Size(120, 23);
            this.txt_statustipoitem.TabIndex = 5;
            this.txt_statustipoitem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_statustipoitem_KeyPress);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(205, 4);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 15);
            this.label42.TabIndex = 4;
            this.label42.Text = "Status";
            // 
            // tp_gruposfamilia
            // 
            this.tp_gruposfamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.tp_gruposfamilia.Controls.Add(this.btFamilia);
            this.tp_gruposfamilia.Controls.Add(this.txt_familia);
            this.tp_gruposfamilia.Controls.Add(this.label1);
            this.tp_gruposfamilia.Controls.Add(this.label2);
            this.tp_gruposfamilia.Controls.Add(this.btGrupo);
            this.tp_gruposfamilia.Controls.Add(this.txt_grupo);
            this.tp_gruposfamilia.Controls.Add(this.label10);
            this.tp_gruposfamilia.ForeColor = System.Drawing.Color.White;
            this.tp_gruposfamilia.Location = new System.Drawing.Point(4, 24);
            this.tp_gruposfamilia.Name = "tp_gruposfamilia";
            this.tp_gruposfamilia.Padding = new System.Windows.Forms.Padding(3);
            this.tp_gruposfamilia.Size = new System.Drawing.Size(769, 57);
            this.tp_gruposfamilia.TabIndex = 8;
            this.tp_gruposfamilia.Text = "Grupos|Famílias";
            // 
            // btFamilia
            // 
            this.btFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btFamilia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btFamilia.FlatAppearance.BorderSize = 0;
            this.btFamilia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btFamilia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFamilia.ForeColor = System.Drawing.Color.White;
            this.btFamilia.Image = ((System.Drawing.Image)(resources.GetObject("btFamilia.Image")));
            this.btFamilia.Location = new System.Drawing.Point(333, 19);
            this.btFamilia.Name = "btFamilia";
            this.btFamilia.Size = new System.Drawing.Size(28, 28);
            this.btFamilia.TabIndex = 6;
            this.btFamilia.UseVisualStyleBackColor = false;
            this.btFamilia.Click += new System.EventHandler(this.btFamilia_Click);
            // 
            // txt_familia
            // 
            this.txt_familia.Location = new System.Drawing.Point(207, 22);
            this.txt_familia.Name = "txt_familia";
            this.txt_familia.Size = new System.Drawing.Size(120, 23);
            this.txt_familia.TabIndex = 5;
            this.txt_familia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_familia_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(204, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Família";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(164, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 49);
            this.label2.TabIndex = 3;
            this.label2.Text = "|";
            // 
            // btGrupo
            // 
            this.btGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btGrupo.FlatAppearance.BorderSize = 0;
            this.btGrupo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btGrupo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGrupo.ForeColor = System.Drawing.Color.White;
            this.btGrupo.Image = ((System.Drawing.Image)(resources.GetObject("btGrupo.Image")));
            this.btGrupo.Location = new System.Drawing.Point(132, 19);
            this.btGrupo.Name = "btGrupo";
            this.btGrupo.Size = new System.Drawing.Size(28, 28);
            this.btGrupo.TabIndex = 2;
            this.btGrupo.UseVisualStyleBackColor = false;
            this.btGrupo.Click += new System.EventHandler(this.btGrupo_Click);
            // 
            // txt_grupo
            // 
            this.txt_grupo.Location = new System.Drawing.Point(6, 22);
            this.txt_grupo.Name = "txt_grupo";
            this.txt_grupo.Size = new System.Drawing.Size(120, 23);
            this.txt_grupo.TabIndex = 1;
            this.txt_grupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_grupo_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Grupo";
            // 
            // tp_descricao
            // 
            this.tp_descricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.tp_descricao.Controls.Add(this.btEanProduto);
            this.tp_descricao.Controls.Add(this.txt_eanproduto);
            this.tp_descricao.Controls.Add(this.label16);
            this.tp_descricao.Controls.Add(this.label17);
            this.tp_descricao.Controls.Add(this.btDescricaoProduto);
            this.tp_descricao.Controls.Add(this.txt_descricaoproduto);
            this.tp_descricao.Controls.Add(this.label18);
            this.tp_descricao.Location = new System.Drawing.Point(4, 24);
            this.tp_descricao.Name = "tp_descricao";
            this.tp_descricao.Padding = new System.Windows.Forms.Padding(3);
            this.tp_descricao.Size = new System.Drawing.Size(769, 57);
            this.tp_descricao.TabIndex = 9;
            this.tp_descricao.Text = "Descrição";
            // 
            // btEanProduto
            // 
            this.btEanProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btEanProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEanProduto.FlatAppearance.BorderSize = 0;
            this.btEanProduto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btEanProduto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btEanProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEanProduto.ForeColor = System.Drawing.Color.White;
            this.btEanProduto.Image = ((System.Drawing.Image)(resources.GetObject("btEanProduto.Image")));
            this.btEanProduto.Location = new System.Drawing.Point(442, 19);
            this.btEanProduto.Name = "btEanProduto";
            this.btEanProduto.Size = new System.Drawing.Size(28, 28);
            this.btEanProduto.TabIndex = 6;
            this.btEanProduto.UseVisualStyleBackColor = false;
            this.btEanProduto.Click += new System.EventHandler(this.btEanProduto_Click);
            // 
            // txt_eanproduto
            // 
            this.txt_eanproduto.Location = new System.Drawing.Point(306, 22);
            this.txt_eanproduto.Name = "txt_eanproduto";
            this.txt_eanproduto.Size = new System.Drawing.Size(130, 23);
            this.txt_eanproduto.TabIndex = 5;
            this.txt_eanproduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_eanproduto_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(303, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 15);
            this.label16.TabIndex = 4;
            this.label16.Text = "EAN Produto";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(263, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 49);
            this.label17.TabIndex = 3;
            this.label17.Text = "|";
            // 
            // btDescricaoProduto
            // 
            this.btDescricaoProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btDescricaoProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDescricaoProduto.FlatAppearance.BorderSize = 0;
            this.btDescricaoProduto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btDescricaoProduto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btDescricaoProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDescricaoProduto.ForeColor = System.Drawing.Color.White;
            this.btDescricaoProduto.Image = ((System.Drawing.Image)(resources.GetObject("btDescricaoProduto.Image")));
            this.btDescricaoProduto.Location = new System.Drawing.Point(232, 19);
            this.btDescricaoProduto.Name = "btDescricaoProduto";
            this.btDescricaoProduto.Size = new System.Drawing.Size(28, 28);
            this.btDescricaoProduto.TabIndex = 2;
            this.btDescricaoProduto.UseVisualStyleBackColor = false;
            this.btDescricaoProduto.Click += new System.EventHandler(this.btDescricaoProduto_Click);
            // 
            // txt_descricaoproduto
            // 
            this.txt_descricaoproduto.Location = new System.Drawing.Point(6, 22);
            this.txt_descricaoproduto.Name = "txt_descricaoproduto";
            this.txt_descricaoproduto.Size = new System.Drawing.Size(220, 23);
            this.txt_descricaoproduto.TabIndex = 1;
            this.txt_descricaoproduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_descricaoproduto_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(3, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 15);
            this.label18.TabIndex = 0;
            this.label18.Text = "Descrição Produto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_carregartudo);
            this.groupBox1.Controls.Add(this.btn_sair);
            this.groupBox1.Location = new System.Drawing.Point(804, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 90);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btn_carregartudo
            // 
            this.btn_carregartudo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_carregartudo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_carregartudo.FlatAppearance.BorderSize = 0;
            this.btn_carregartudo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_carregartudo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_carregartudo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_carregartudo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_carregartudo.ForeColor = System.Drawing.Color.White;
            this.btn_carregartudo.Image = ((System.Drawing.Image)(resources.GetObject("btn_carregartudo.Image")));
            this.btn_carregartudo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_carregartudo.Location = new System.Drawing.Point(6, 19);
            this.btn_carregartudo.Name = "btn_carregartudo";
            this.btn_carregartudo.Size = new System.Drawing.Size(75, 60);
            this.btn_carregartudo.TabIndex = 0;
            this.btn_carregartudo.Text = "Carregar";
            this.btn_carregartudo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_carregartudo.UseVisualStyleBackColor = false;
            this.btn_carregartudo.Click += new System.EventHandler(this.btn_carregartudo_Click);
            // 
            // btn_sair
            // 
            this.btn_sair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_sair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sair.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sair.ForeColor = System.Drawing.Color.White;
            this.btn_sair.Image = ((System.Drawing.Image)(resources.GetObject("btn_sair.Image")));
            this.btn_sair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_sair.Location = new System.Drawing.Point(87, 19);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(75, 60);
            this.btn_sair.TabIndex = 1;
            this.btn_sair.Text = "Fechar";
            this.btn_sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_sair.UseVisualStyleBackColor = false;
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // RVprodutosbd
            // 
            reportDataSource1.Name = "DataSetProdutos";
            reportDataSource1.Value = this.tb_produtosBindingSource;
            this.RVprodutosbd.LocalReport.DataSources.Add(reportDataSource1);
            this.RVprodutosbd.LocalReport.ReportEmbeddedResource = "SIGRas.ReportProdutosbd.rdlc";
            this.RVprodutosbd.Location = new System.Drawing.Point(21, 122);
            this.RVprodutosbd.Name = "RVprodutosbd";
            this.RVprodutosbd.ServerReport.BearerToken = null;
            this.RVprodutosbd.Size = new System.Drawing.Size(953, 457);
            this.RVprodutosbd.TabIndex = 7;
            // 
            // tb_produtosBindingSource
            // 
            this.tb_produtosBindingSource.DataMember = "tb_produtos";
            this.tb_produtosBindingSource.DataSource = this.sigrassystembdDataSet;
            // 
            // sigrassystembdDataSet
            // 
            this.sigrassystembdDataSet.DataSetName = "sigrassystembdDataSet";
            this.sigrassystembdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_produtosTableAdapter
            // 
            this.tb_produtosTableAdapter.ClearBeforeFill = true;
            // 
            // FrmProdutosRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(995, 600);
            this.Controls.Add(this.RVprodutosbd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tc_cadastroprodutos);
            this.Controls.Add(this.pan_barrainferior);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pan_titulo);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmProdutosRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmProdutosRelatorio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProdutosRelatorio_KeyDown);
            this.pan_titulo.ResumeLayout(false);
            this.pan_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.tc_cadastroprodutos.ResumeLayout(false);
            this.tp_statustipos.ResumeLayout(false);
            this.tp_statustipos.PerformLayout();
            this.tp_gruposfamilia.ResumeLayout(false);
            this.tp_gruposfamilia.PerformLayout();
            this.tp_descricao.ResumeLayout(false);
            this.tp_descricao.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sigrassystembdDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_titulo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pan_barrainferior;
        private System.Windows.Forms.TabControl tc_cadastroprodutos;
        private System.Windows.Forms.TabPage tp_statustipos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btStatus;
        private System.Windows.Forms.TextBox txt_status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btStatusTipoItem;
        private System.Windows.Forms.TextBox txt_tipoitemstatus;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txt_statustipoitem;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TabPage tp_gruposfamilia;
        private System.Windows.Forms.Button btFamilia;
        private System.Windows.Forms.TextBox txt_familia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btGrupo;
        private System.Windows.Forms.TextBox txt_grupo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tp_descricao;
        private System.Windows.Forms.Button btEanProduto;
        private System.Windows.Forms.TextBox txt_eanproduto;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btDescricaoProduto;
        private System.Windows.Forms.TextBox txt_descricaoproduto;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_carregartudo;
        private System.Windows.Forms.Button btn_sair;
        private Microsoft.Reporting.WinForms.ReportViewer RVprodutosbd;
        private System.Windows.Forms.BindingSource tb_produtosBindingSource;
        private sigrassystembdDataSet sigrassystembdDataSet;
        private sigrassystembdDataSetTableAdapters.tb_produtosTableAdapter tb_produtosTableAdapter;
    }
}