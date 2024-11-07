namespace SIGRas
{
    partial class FrmFinanceiroConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFinanceiroConsulta));
            this.pan_titulo = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pan_barrainferior = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lvw_financeiro = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_procurar = new System.Windows.Forms.TextBox();
            this.cbo_procurar = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_limpar = new System.Windows.Forms.Button();
            this.btn_carregar = new System.Windows.Forms.Button();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_saldofinal = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_totalentradas = new System.Windows.Forms.TextBox();
            this.txt_totalsaidas = new System.Windows.Forms.TextBox();
            this.txt_totalregistros = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pan_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.label14.Size = new System.Drawing.Size(183, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "Movimento Caixa Consulta";
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
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(800, 25);
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
            this.pan_barrainferior.Size = new System.Drawing.Size(785, 15);
            this.pan_barrainferior.TabIndex = 3;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // lvw_financeiro
            // 
            this.lvw_financeiro.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvw_financeiro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvw_financeiro.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.lvw_financeiro.FullRowSelect = true;
            this.lvw_financeiro.GridLines = true;
            this.lvw_financeiro.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvw_financeiro.HideSelection = false;
            this.lvw_financeiro.HoverSelection = true;
            this.lvw_financeiro.Location = new System.Drawing.Point(21, 31);
            this.lvw_financeiro.Name = "lvw_financeiro";
            this.lvw_financeiro.ShowItemToolTips = true;
            this.lvw_financeiro.Size = new System.Drawing.Size(771, 400);
            this.lvw_financeiro.TabIndex = 4;
            this.lvw_financeiro.UseCompatibleStateImageBehavior = false;
            this.lvw_financeiro.View = System.Windows.Forms.View.Details;
            this.lvw_financeiro.SelectedIndexChanged += new System.EventHandler(this.lvw_financeiro_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data Sistema";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Hora Sistema";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mês";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ano";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tipo Lançamento";
            this.columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Destino Lançamento";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Departamento | Setor";
            this.columnHeader8.Width = 99;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Conta Destino";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Data";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Espécie";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Descrição Lançamento";
            this.columnHeader12.Width = 190;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Valor Entrada";
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Valor Saída";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Observação";
            this.columnHeader15.Width = 300;
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
            this.groupBox1.TabIndex = 6;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_limpar);
            this.groupBox2.Controls.Add(this.btn_carregar);
            this.groupBox2.Controls.Add(this.btn_fechar);
            this.groupBox2.Location = new System.Drawing.Point(528, 499);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 80);
            this.groupBox2.TabIndex = 7;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_saldofinal);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txt_totalentradas);
            this.groupBox3.Controls.Add(this.txt_totalsaidas);
            this.groupBox3.Controls.Add(this.txt_totalregistros);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(21, 437);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(773, 65);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // txt_saldofinal
            // 
            this.txt_saldofinal.BackColor = System.Drawing.Color.Lavender;
            this.txt_saldofinal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_saldofinal.Location = new System.Drawing.Point(438, 29);
            this.txt_saldofinal.Name = "txt_saldofinal";
            this.txt_saldofinal.Size = new System.Drawing.Size(210, 23);
            this.txt_saldofinal.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(2, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Total Entradas";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(434, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 15);
            this.label18.TabIndex = 4;
            this.label18.Text = "Saldo Final";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(218, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 15);
            this.label16.TabIndex = 2;
            this.label16.Text = "Total Saídas";
            // 
            // txt_totalentradas
            // 
            this.txt_totalentradas.BackColor = System.Drawing.Color.Azure;
            this.txt_totalentradas.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalentradas.Location = new System.Drawing.Point(6, 29);
            this.txt_totalentradas.Name = "txt_totalentradas";
            this.txt_totalentradas.Size = new System.Drawing.Size(210, 23);
            this.txt_totalentradas.TabIndex = 1;
            // 
            // txt_totalsaidas
            // 
            this.txt_totalsaidas.BackColor = System.Drawing.Color.LavenderBlush;
            this.txt_totalsaidas.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalsaidas.Location = new System.Drawing.Point(222, 29);
            this.txt_totalsaidas.Name = "txt_totalsaidas";
            this.txt_totalsaidas.Size = new System.Drawing.Size(210, 23);
            this.txt_totalsaidas.TabIndex = 3;
            // 
            // txt_totalregistros
            // 
            this.txt_totalregistros.BackColor = System.Drawing.SystemColors.Window;
            this.txt_totalregistros.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalregistros.Location = new System.Drawing.Point(654, 29);
            this.txt_totalregistros.Name = "txt_totalregistros";
            this.txt_totalregistros.Size = new System.Drawing.Size(111, 23);
            this.txt_totalregistros.TabIndex = 7;
            this.txt_totalregistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(651, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 15);
            this.label17.TabIndex = 6;
            this.label17.Text = "Total Registros";
            // 
            // FrmFinanceiroConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(815, 600);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvw_financeiro);
            this.Controls.Add(this.pan_barrainferior);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pan_titulo);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmFinanceiroConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmFinanceiroConsulta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFinanceiroConsulta_KeyDown);
            this.pan_titulo.ResumeLayout(false);
            this.pan_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_saldofinal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_totalentradas;
        private System.Windows.Forms.TextBox txt_totalsaidas;
        private System.Windows.Forms.TextBox txt_totalregistros;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_limpar;
        private System.Windows.Forms.Button btn_carregar;
        private System.Windows.Forms.Button btn_fechar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_procurar;
        private System.Windows.Forms.ComboBox cbo_procurar;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListView lvw_financeiro;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
    }
}