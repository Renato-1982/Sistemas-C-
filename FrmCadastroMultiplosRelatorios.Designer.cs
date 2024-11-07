namespace SIGRas
{
    partial class FrmCadastroMultiplosRelatorios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroMultiplosRelatorios));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tb_cadastromultiploBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sigrassystembdDataSet = new SIGRas.sigrassystembdDataSet();
            this.pan_titulo = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pan_barrainferior = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.tc_cadastromultiplos = new System.Windows.Forms.TabControl();
            this.tp_statustipos = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btStatus = new System.Windows.Forms.Button();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.btStatusTipocadastropessoa = new System.Windows.Forms.Button();
            this.txt_tipopessoastatustipocadastro = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txt_tipocadastrotipopessoastatus = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txt_statustipocadastrotipopessoa = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tp_cpfcnpj = new System.Windows.Forms.TabPage();
            this.btCnpj = new System.Windows.Forms.Button();
            this.txt_cnpj = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btCpf = new System.Windows.Forms.Button();
            this.txt_cpf = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tp_descricao = new System.Windows.Forms.TabPage();
            this.btNomeFantasiaApelido = new System.Windows.Forms.Button();
            this.txt_nomefantasiaapelido = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btNomeRazao = new System.Windows.Forms.Button();
            this.txt_nomerazaosocial = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_carregartudo = new System.Windows.Forms.Button();
            this.btn_sair = new System.Windows.Forms.Button();
            this.RVcadastromultiplosbd = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_cadastromultiploTableAdapter = new SIGRas.sigrassystembdDataSetTableAdapters.tb_cadastromultiploTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cadastromultiploBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sigrassystembdDataSet)).BeginInit();
            this.pan_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.tc_cadastromultiplos.SuspendLayout();
            this.tp_statustipos.SuspendLayout();
            this.tp_cpfcnpj.SuspendLayout();
            this.tp_descricao.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_cadastromultiploBindingSource
            // 
            this.tb_cadastromultiploBindingSource.DataMember = "tb_cadastromultiplo";
            this.tb_cadastromultiploBindingSource.DataSource = this.sigrassystembdDataSet;
            // 
            // sigrassystembdDataSet
            // 
            this.sigrassystembdDataSet.DataSetName = "sigrassystembdDataSet";
            this.sigrassystembdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.label14.Size = new System.Drawing.Size(202, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "Cadastro Múltiplos Relatórios";
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
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(980, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 575);
            this.panel2.TabIndex = 2;
            // 
            // pan_barrainferior
            // 
            this.pan_barrainferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_barrainferior.Cursor = System.Windows.Forms.Cursors.Default;
            this.pan_barrainferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_barrainferior.Location = new System.Drawing.Point(15, 585);
            this.pan_barrainferior.Name = "pan_barrainferior";
            this.pan_barrainferior.Size = new System.Drawing.Size(965, 15);
            this.pan_barrainferior.TabIndex = 3;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // tc_cadastromultiplos
            // 
            this.tc_cadastromultiplos.Controls.Add(this.tp_statustipos);
            this.tc_cadastromultiplos.Controls.Add(this.tp_cpfcnpj);
            this.tc_cadastromultiplos.Controls.Add(this.tp_descricao);
            this.tc_cadastromultiplos.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tc_cadastromultiplos.Location = new System.Drawing.Point(21, 31);
            this.tc_cadastromultiplos.Name = "tc_cadastromultiplos";
            this.tc_cadastromultiplos.SelectedIndex = 0;
            this.tc_cadastromultiplos.Size = new System.Drawing.Size(777, 85);
            this.tc_cadastromultiplos.TabIndex = 4;
            this.tc_cadastromultiplos.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tc_cadastromultiplos_DrawItem);
            // 
            // tp_statustipos
            // 
            this.tp_statustipos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.tp_statustipos.Controls.Add(this.label4);
            this.tp_statustipos.Controls.Add(this.btStatus);
            this.tp_statustipos.Controls.Add(this.txt_status);
            this.tp_statustipos.Controls.Add(this.label3);
            this.tp_statustipos.Controls.Add(this.label36);
            this.tp_statustipos.Controls.Add(this.label35);
            this.tp_statustipos.Controls.Add(this.btStatusTipocadastropessoa);
            this.tp_statustipos.Controls.Add(this.txt_tipopessoastatustipocadastro);
            this.tp_statustipos.Controls.Add(this.label38);
            this.tp_statustipos.Controls.Add(this.txt_tipocadastrotipopessoastatus);
            this.tp_statustipos.Controls.Add(this.label37);
            this.tp_statustipos.Controls.Add(this.txt_statustipocadastrotipopessoa);
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
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(453, 27);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(13, 15);
            this.label36.TabIndex = 9;
            this.label36.Text = "e";
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
            // btStatusTipocadastropessoa
            // 
            this.btStatusTipocadastropessoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btStatusTipocadastropessoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btStatusTipocadastropessoa.FlatAppearance.BorderSize = 0;
            this.btStatusTipocadastropessoa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btStatusTipocadastropessoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btStatusTipocadastropessoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStatusTipocadastropessoa.ForeColor = System.Drawing.Color.White;
            this.btStatusTipocadastropessoa.Image = ((System.Drawing.Image)(resources.GetObject("btStatusTipocadastropessoa.Image")));
            this.btStatusTipocadastropessoa.Location = new System.Drawing.Point(576, 19);
            this.btStatusTipocadastropessoa.Name = "btStatusTipocadastropessoa";
            this.btStatusTipocadastropessoa.Size = new System.Drawing.Size(28, 28);
            this.btStatusTipocadastropessoa.TabIndex = 12;
            this.btStatusTipocadastropessoa.UseVisualStyleBackColor = false;
            this.btStatusTipocadastropessoa.Click += new System.EventHandler(this.btStatusTipocadastropessoa_Click);
            // 
            // txt_tipopessoastatustipocadastro
            // 
            this.txt_tipopessoastatustipocadastro.Location = new System.Drawing.Point(470, 22);
            this.txt_tipopessoastatustipocadastro.Name = "txt_tipopessoastatustipocadastro";
            this.txt_tipopessoastatustipocadastro.Size = new System.Drawing.Size(100, 23);
            this.txt_tipopessoastatustipocadastro.TabIndex = 11;
            this.txt_tipopessoastatustipocadastro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_tipopessoastatustipocadastro_KeyPress);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(467, 4);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(73, 15);
            this.label38.TabIndex = 10;
            this.label38.Text = "Tipo Pessoa";
            // 
            // txt_tipocadastrotipopessoastatus
            // 
            this.txt_tipocadastrotipopessoastatus.Location = new System.Drawing.Point(349, 22);
            this.txt_tipocadastrotipopessoastatus.Name = "txt_tipocadastrotipopessoastatus";
            this.txt_tipocadastrotipopessoastatus.Size = new System.Drawing.Size(100, 23);
            this.txt_tipocadastrotipopessoastatus.TabIndex = 8;
            this.txt_tipocadastrotipopessoastatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_tipocadastrotipopessoastatus_KeyPress);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(346, 4);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(84, 15);
            this.label37.TabIndex = 7;
            this.label37.Text = "Tipo Cadastro";
            // 
            // txt_statustipocadastrotipopessoa
            // 
            this.txt_statustipocadastrotipopessoa.Location = new System.Drawing.Point(208, 22);
            this.txt_statustipocadastrotipopessoa.Name = "txt_statustipocadastrotipopessoa";
            this.txt_statustipocadastrotipopessoa.Size = new System.Drawing.Size(120, 23);
            this.txt_statustipocadastrotipopessoa.TabIndex = 5;
            this.txt_statustipocadastrotipopessoa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_statustipocadastrotipopessoa_KeyPress);
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
            // tp_cpfcnpj
            // 
            this.tp_cpfcnpj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.tp_cpfcnpj.Controls.Add(this.btCnpj);
            this.tp_cpfcnpj.Controls.Add(this.txt_cnpj);
            this.tp_cpfcnpj.Controls.Add(this.label1);
            this.tp_cpfcnpj.Controls.Add(this.label2);
            this.tp_cpfcnpj.Controls.Add(this.btCpf);
            this.tp_cpfcnpj.Controls.Add(this.txt_cpf);
            this.tp_cpfcnpj.Controls.Add(this.label10);
            this.tp_cpfcnpj.ForeColor = System.Drawing.Color.White;
            this.tp_cpfcnpj.Location = new System.Drawing.Point(4, 24);
            this.tp_cpfcnpj.Name = "tp_cpfcnpj";
            this.tp_cpfcnpj.Padding = new System.Windows.Forms.Padding(3);
            this.tp_cpfcnpj.Size = new System.Drawing.Size(769, 57);
            this.tp_cpfcnpj.TabIndex = 8;
            this.tp_cpfcnpj.Text = "CPF|CNPJ";
            // 
            // btCnpj
            // 
            this.btCnpj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btCnpj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCnpj.FlatAppearance.BorderSize = 0;
            this.btCnpj.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btCnpj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btCnpj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCnpj.ForeColor = System.Drawing.Color.White;
            this.btCnpj.Image = ((System.Drawing.Image)(resources.GetObject("btCnpj.Image")));
            this.btCnpj.Location = new System.Drawing.Point(333, 19);
            this.btCnpj.Name = "btCnpj";
            this.btCnpj.Size = new System.Drawing.Size(28, 28);
            this.btCnpj.TabIndex = 6;
            this.btCnpj.UseVisualStyleBackColor = false;
            this.btCnpj.Click += new System.EventHandler(this.btCnpj_Click);
            // 
            // txt_cnpj
            // 
            this.txt_cnpj.Location = new System.Drawing.Point(207, 22);
            this.txt_cnpj.Name = "txt_cnpj";
            this.txt_cnpj.Size = new System.Drawing.Size(120, 23);
            this.txt_cnpj.TabIndex = 5;
            this.txt_cnpj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cnpj_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(204, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "CNPJ";
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
            // btCpf
            // 
            this.btCpf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btCpf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCpf.FlatAppearance.BorderSize = 0;
            this.btCpf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btCpf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btCpf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCpf.ForeColor = System.Drawing.Color.White;
            this.btCpf.Image = ((System.Drawing.Image)(resources.GetObject("btCpf.Image")));
            this.btCpf.Location = new System.Drawing.Point(132, 19);
            this.btCpf.Name = "btCpf";
            this.btCpf.Size = new System.Drawing.Size(28, 28);
            this.btCpf.TabIndex = 2;
            this.btCpf.UseVisualStyleBackColor = false;
            this.btCpf.Click += new System.EventHandler(this.btCpf_Click);
            // 
            // txt_cpf
            // 
            this.txt_cpf.Location = new System.Drawing.Point(6, 22);
            this.txt_cpf.Name = "txt_cpf";
            this.txt_cpf.Size = new System.Drawing.Size(120, 23);
            this.txt_cpf.TabIndex = 1;
            this.txt_cpf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cpf_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "CPF";
            // 
            // tp_descricao
            // 
            this.tp_descricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.tp_descricao.Controls.Add(this.btNomeFantasiaApelido);
            this.tp_descricao.Controls.Add(this.txt_nomefantasiaapelido);
            this.tp_descricao.Controls.Add(this.label16);
            this.tp_descricao.Controls.Add(this.label17);
            this.tp_descricao.Controls.Add(this.btNomeRazao);
            this.tp_descricao.Controls.Add(this.txt_nomerazaosocial);
            this.tp_descricao.Controls.Add(this.label18);
            this.tp_descricao.Location = new System.Drawing.Point(4, 24);
            this.tp_descricao.Name = "tp_descricao";
            this.tp_descricao.Padding = new System.Windows.Forms.Padding(3);
            this.tp_descricao.Size = new System.Drawing.Size(769, 57);
            this.tp_descricao.TabIndex = 9;
            this.tp_descricao.Text = "Descrição";
            // 
            // btNomeFantasiaApelido
            // 
            this.btNomeFantasiaApelido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btNomeFantasiaApelido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNomeFantasiaApelido.FlatAppearance.BorderSize = 0;
            this.btNomeFantasiaApelido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btNomeFantasiaApelido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btNomeFantasiaApelido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNomeFantasiaApelido.ForeColor = System.Drawing.Color.White;
            this.btNomeFantasiaApelido.Image = ((System.Drawing.Image)(resources.GetObject("btNomeFantasiaApelido.Image")));
            this.btNomeFantasiaApelido.Location = new System.Drawing.Point(532, 19);
            this.btNomeFantasiaApelido.Name = "btNomeFantasiaApelido";
            this.btNomeFantasiaApelido.Size = new System.Drawing.Size(28, 28);
            this.btNomeFantasiaApelido.TabIndex = 6;
            this.btNomeFantasiaApelido.UseVisualStyleBackColor = false;
            this.btNomeFantasiaApelido.Click += new System.EventHandler(this.btNomeFantasiaApelido_Click);
            // 
            // txt_nomefantasiaapelido
            // 
            this.txt_nomefantasiaapelido.Location = new System.Drawing.Point(306, 22);
            this.txt_nomefantasiaapelido.Name = "txt_nomefantasiaapelido";
            this.txt_nomefantasiaapelido.Size = new System.Drawing.Size(220, 23);
            this.txt_nomefantasiaapelido.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(303, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 15);
            this.label16.TabIndex = 4;
            this.label16.Text = "Nome Fantasia/Apelido";
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
            // btNomeRazao
            // 
            this.btNomeRazao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btNomeRazao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNomeRazao.FlatAppearance.BorderSize = 0;
            this.btNomeRazao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btNomeRazao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btNomeRazao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNomeRazao.ForeColor = System.Drawing.Color.White;
            this.btNomeRazao.Image = ((System.Drawing.Image)(resources.GetObject("btNomeRazao.Image")));
            this.btNomeRazao.Location = new System.Drawing.Point(232, 19);
            this.btNomeRazao.Name = "btNomeRazao";
            this.btNomeRazao.Size = new System.Drawing.Size(28, 28);
            this.btNomeRazao.TabIndex = 2;
            this.btNomeRazao.UseVisualStyleBackColor = false;
            this.btNomeRazao.Click += new System.EventHandler(this.btNomeRazao_Click);
            // 
            // txt_nomerazaosocial
            // 
            this.txt_nomerazaosocial.Location = new System.Drawing.Point(6, 22);
            this.txt_nomerazaosocial.Name = "txt_nomerazaosocial";
            this.txt_nomerazaosocial.Size = new System.Drawing.Size(220, 23);
            this.txt_nomerazaosocial.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(3, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(113, 15);
            this.label18.TabIndex = 0;
            this.label18.Text = "Nome/Razão Social";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_carregartudo);
            this.groupBox1.Controls.Add(this.btn_sair);
            this.groupBox1.Location = new System.Drawing.Point(804, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 90);
            this.groupBox1.TabIndex = 5;
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
            // RVcadastromultiplosbd
            // 
            reportDataSource1.Name = "DataSetCadastroMultiplos";
            reportDataSource1.Value = this.tb_cadastromultiploBindingSource;
            this.RVcadastromultiplosbd.LocalReport.DataSources.Add(reportDataSource1);
            this.RVcadastromultiplosbd.LocalReport.ReportEmbeddedResource = "SIGRas.ReportCadastroMultiplosbd.rdlc";
            this.RVcadastromultiplosbd.Location = new System.Drawing.Point(21, 122);
            this.RVcadastromultiplosbd.Name = "RVcadastromultiplosbd";
            this.RVcadastromultiplosbd.ServerReport.BearerToken = null;
            this.RVcadastromultiplosbd.Size = new System.Drawing.Size(953, 457);
            this.RVcadastromultiplosbd.TabIndex = 6;
            // 
            // tb_cadastromultiploTableAdapter
            // 
            this.tb_cadastromultiploTableAdapter.ClearBeforeFill = true;
            // 
            // FrmCadastroMultiplosRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(995, 600);
            this.Controls.Add(this.RVcadastromultiplosbd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tc_cadastromultiplos);
            this.Controls.Add(this.pan_barrainferior);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pan_titulo);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmCadastroMultiplosRelatorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCadastroMultiplosRelatorios_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCadastroMultiplosRelatorios_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_cadastromultiploBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sigrassystembdDataSet)).EndInit();
            this.pan_titulo.ResumeLayout(false);
            this.pan_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.tc_cadastromultiplos.ResumeLayout(false);
            this.tp_statustipos.ResumeLayout(false);
            this.tp_statustipos.PerformLayout();
            this.tp_cpfcnpj.ResumeLayout(false);
            this.tp_cpfcnpj.PerformLayout();
            this.tp_descricao.ResumeLayout(false);
            this.tp_descricao.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tc_cadastromultiplos;
        private System.Windows.Forms.TabPage tp_statustipos;
        private System.Windows.Forms.TextBox txt_statustipocadastrotipopessoa;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TabPage tp_cpfcnpj;
        private System.Windows.Forms.Button btCpf;
        private System.Windows.Forms.TextBox txt_cpf;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tp_descricao;
        private System.Windows.Forms.Button btNomeFantasiaApelido;
        private System.Windows.Forms.TextBox txt_nomefantasiaapelido;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btNomeRazao;
        private System.Windows.Forms.TextBox txt_nomerazaosocial;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_carregartudo;
        private System.Windows.Forms.Button btn_sair;
        private Microsoft.Reporting.WinForms.ReportViewer RVcadastromultiplosbd;
        private System.Windows.Forms.BindingSource tb_cadastromultiploBindingSource;
        private sigrassystembdDataSet sigrassystembdDataSet;
        private sigrassystembdDataSetTableAdapters.tb_cadastromultiploTableAdapter tb_cadastromultiploTableAdapter;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btStatusTipocadastropessoa;
        private System.Windows.Forms.TextBox txt_tipopessoastatustipocadastro;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txt_tipocadastrotipopessoastatus;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btCnpj;
        private System.Windows.Forms.TextBox txt_cnpj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btStatus;
        private System.Windows.Forms.TextBox txt_status;
        private System.Windows.Forms.Label label3;
    }
}