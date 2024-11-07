namespace SIGRas
{
    partial class Frm01Login
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm01Login));
            this.pan_titulo = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.pan_barrainferior = new System.Windows.Forms.Panel();
            this.link_reativar = new System.Windows.Forms.LinkLabel();
            this.lblAviso = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.btnAtivar = new System.Windows.Forms.Button();
            this.link_novousuario = new System.Windows.Forms.LinkLabel();
            this.link_contato = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbx_logo = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pan_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pan_titulo
            // 
            this.pan_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_titulo.Controls.Add(this.btnMinimizar);
            this.pan_titulo.Controls.Add(this.btnCerrar);
            this.pan_titulo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pan_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_titulo.Location = new System.Drawing.Point(0, 0);
            this.pan_titulo.Name = "pan_titulo";
            this.pan_titulo.Size = new System.Drawing.Size(290, 30);
            this.pan_titulo.TabIndex = 0;
            this.pan_titulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pan_titulo_MouseDown);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(228, 6);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(18, 18);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 24;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            this.btnMinimizar.MouseLeave += new System.EventHandler(this.btnMinimizar_MouseLeave);
            this.btnMinimizar.MouseHover += new System.EventHandler(this.btnMinimizar_MouseHover);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(252, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(18, 18);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 23;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.btnCerrar_MouseLeave);
            this.btnCerrar.MouseHover += new System.EventHandler(this.btnCerrar_MouseHover);
            // 
            // pan_barrainferior
            // 
            this.pan_barrainferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_barrainferior.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pan_barrainferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_barrainferior.Location = new System.Drawing.Point(0, 415);
            this.pan_barrainferior.Name = "pan_barrainferior";
            this.pan_barrainferior.Size = new System.Drawing.Size(290, 15);
            this.pan_barrainferior.TabIndex = 3;
            this.pan_barrainferior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pan_barrainferior_MouseDown);
            // 
            // link_reativar
            // 
            this.link_reativar.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.link_reativar.AutoSize = true;
            this.link_reativar.DisabledLinkColor = System.Drawing.Color.White;
            this.link_reativar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_reativar.LinkColor = System.Drawing.Color.White;
            this.link_reativar.Location = new System.Drawing.Point(98, 287);
            this.link_reativar.Name = "link_reativar";
            this.link_reativar.Size = new System.Drawing.Size(98, 15);
            this.link_reativar.TabIndex = 12;
            this.link_reativar.TabStop = true;
            this.link_reativar.Text = "Reativar Sistema";
            this.link_reativar.VisitedLinkColor = System.Drawing.Color.White;
            this.link_reativar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_reativar_LinkClicked);
            this.link_reativar.MouseLeave += new System.EventHandler(this.link_reativar_MouseLeave);
            this.link_reativar.MouseHover += new System.EventHandler(this.link_reativar_MouseHover);
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.Red;
            this.lblAviso.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAviso.Location = new System.Drawing.Point(21, 332);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(10, 15);
            this.lblAviso.TabIndex = 14;
            this.lblAviso.Text = ".";
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(204, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "MSRC0001";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSerial
            // 
            this.txtSerial.BackColor = System.Drawing.SystemColors.Window;
            this.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSerial.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.ForeColor = System.Drawing.Color.Black;
            this.txtSerial.Location = new System.Drawing.Point(21, 350);
            this.txtSerial.MaxLength = 24;
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(250, 20);
            this.txtSerial.TabIndex = 16;
            this.txtSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAtivar
            // 
            this.btnAtivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnAtivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtivar.FlatAppearance.BorderSize = 0;
            this.btnAtivar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnAtivar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnAtivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtivar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtivar.ForeColor = System.Drawing.Color.White;
            this.btnAtivar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtivar.Image")));
            this.btnAtivar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtivar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAtivar.Location = new System.Drawing.Point(21, 379);
            this.btnAtivar.Name = "btnAtivar";
            this.btnAtivar.Size = new System.Drawing.Size(250, 30);
            this.btnAtivar.TabIndex = 17;
            this.btnAtivar.Text = "Ativar";
            this.btnAtivar.UseVisualStyleBackColor = false;
            this.btnAtivar.Click += new System.EventHandler(this.btnAtivar_Click);
            // 
            // link_novousuario
            // 
            this.link_novousuario.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.link_novousuario.AutoSize = true;
            this.link_novousuario.DisabledLinkColor = System.Drawing.Color.White;
            this.link_novousuario.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_novousuario.LinkColor = System.Drawing.Color.White;
            this.link_novousuario.Location = new System.Drawing.Point(17, 266);
            this.link_novousuario.Name = "link_novousuario";
            this.link_novousuario.Size = new System.Drawing.Size(135, 15);
            this.link_novousuario.TabIndex = 10;
            this.link_novousuario.TabStop = true;
            this.link_novousuario.Text = "Cadastrar Novo Usuário";
            this.link_novousuario.VisitedLinkColor = System.Drawing.Color.White;
            this.link_novousuario.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_novousuario_LinkClicked);
            this.link_novousuario.MouseLeave += new System.EventHandler(this.link_novousuario_MouseLeave);
            this.link_novousuario.MouseHover += new System.EventHandler(this.link_novousuario_MouseHover);
            // 
            // link_contato
            // 
            this.link_contato.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.link_contato.AutoSize = true;
            this.link_contato.DisabledLinkColor = System.Drawing.Color.White;
            this.link_contato.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_contato.LinkColor = System.Drawing.Color.White;
            this.link_contato.Location = new System.Drawing.Point(171, 266);
            this.link_contato.Name = "link_contato";
            this.link_contato.Size = new System.Drawing.Size(105, 15);
            this.link_contato.TabIndex = 11;
            this.link_contato.TabStop = true;
            this.link_contato.Text = "Entre em Contato";
            this.link_contato.VisitedLinkColor = System.Drawing.Color.White;
            this.link_contato.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_contato_LinkClicked);
            this.link_contato.MouseLeave += new System.EventHandler(this.link_contato_MouseLeave);
            this.link_contato.MouseHover += new System.EventHandler(this.link_contato_MouseHover);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(39, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "RASystens - Tecnologia para inovação";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.Window;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.Black;
            this.txtUser.Location = new System.Drawing.Point(20, 160);
            this.txtUser.MaxLength = 50;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(250, 20);
            this.txtUser.TabIndex = 5;
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.SystemColors.Window;
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Location = new System.Drawing.Point(20, 201);
            this.txtPass.MaxLength = 20;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(250, 20);
            this.txtPass.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(17, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(17, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Senha";
            // 
            // pbx_logo
            // 
            this.pbx_logo.Image = ((System.Drawing.Image)(resources.GetObject("pbx_logo.Image")));
            this.pbx_logo.Location = new System.Drawing.Point(20, 40);
            this.pbx_logo.Margin = new System.Windows.Forms.Padding(2);
            this.pbx_logo.Name = "pbx_logo";
            this.pbx_logo.Size = new System.Drawing.Size(250, 93);
            this.pbx_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_logo.TabIndex = 35;
            this.pbx_logo.TabStop = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(275, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 385);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 385);
            this.panel1.TabIndex = 1;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(151, 227);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(120, 30);
            this.btnSair.TabIndex = 9;
            this.btnSair.Text = "Fechar";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Calibri", 12F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLogin.Location = new System.Drawing.Point(20, 227);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 30);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Frm01Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(290, 430);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.link_reativar);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.btnAtivar);
            this.Controls.Add(this.link_novousuario);
            this.Controls.Add(this.link_contato);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbx_logo);
            this.Controls.Add(this.pan_barrainferior);
            this.Controls.Add(this.pan_titulo);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm01Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.Frm01Login_Activated);
            this.Load += new System.EventHandler(this.Frm01Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm01Login_KeyDown);
            this.pan_titulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pan_titulo;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel pan_barrainferior;
        private System.Windows.Forms.LinkLabel link_reativar;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Button btnAtivar;
        private System.Windows.Forms.LinkLabel link_novousuario;
        private System.Windows.Forms.LinkLabel link_contato;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbx_logo;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnLogin;
    }
}

