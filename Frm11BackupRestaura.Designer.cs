namespace SIGRas
{
    partial class Frm11BackupRestaura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm11BackupRestaura));
            this.btn_sair = new System.Windows.Forms.Button();
            this.btn_backuprestaura = new System.Windows.Forms.Button();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.progressBarbkp = new System.Windows.Forms.ProgressBar();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.pan_titulo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pan_barrainferior = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.pan_titulo.SuspendLayout();
            this.SuspendLayout();
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
            this.btn_sair.Location = new System.Drawing.Point(241, 209);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(80, 60);
            this.btn_sair.TabIndex = 7;
            this.btn_sair.Text = "Fechar";
            this.btn_sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_sair.UseVisualStyleBackColor = false;
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // btn_backuprestaura
            // 
            this.btn_backuprestaura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_backuprestaura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_backuprestaura.FlatAppearance.BorderSize = 0;
            this.btn_backuprestaura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btn_backuprestaura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btn_backuprestaura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_backuprestaura.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_backuprestaura.ForeColor = System.Drawing.Color.White;
            this.btn_backuprestaura.Image = ((System.Drawing.Image)(resources.GetObject("btn_backuprestaura.Image")));
            this.btn_backuprestaura.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_backuprestaura.Location = new System.Drawing.Point(21, 209);
            this.btn_backuprestaura.Name = "btn_backuprestaura";
            this.btn_backuprestaura.Size = new System.Drawing.Size(80, 60);
            this.btn_backuprestaura.TabIndex = 6;
            this.btn_backuprestaura.Text = "Restaurar";
            this.btn_backuprestaura.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_backuprestaura.UseVisualStyleBackColor = false;
            this.btn_backuprestaura.Click += new System.EventHandler(this.btn_backuprestaura_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Status.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status.ForeColor = System.Drawing.Color.White;
            this.lbl_Status.Location = new System.Drawing.Point(18, 168);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(100, 15);
            this.lbl_Status.TabIndex = 4;
            this.lbl_Status.Text = "Processando...0%";
            // 
            // progressBarbkp
            // 
            this.progressBarbkp.BackColor = System.Drawing.Color.AliceBlue;
            this.progressBarbkp.Location = new System.Drawing.Point(21, 186);
            this.progressBarbkp.Name = "progressBarbkp";
            this.progressBarbkp.Size = new System.Drawing.Size(300, 17);
            this.progressBarbkp.TabIndex = 5;
            // 
            // pb_logo
            // 
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.Location = new System.Drawing.Point(123, 56);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(100, 100);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_logo.TabIndex = 30;
            this.pb_logo.TabStop = false;
            // 
            // pan_titulo
            // 
            this.pan_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_titulo.Controls.Add(this.label3);
            this.pan_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_titulo.Location = new System.Drawing.Point(0, 0);
            this.pan_titulo.Name = "pan_titulo";
            this.pan_titulo.Size = new System.Drawing.Size(345, 35);
            this.pan_titulo.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(45, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Restaurar Base de Dados";
            // 
            // pan_barrainferior
            // 
            this.pan_barrainferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.pan_barrainferior.Cursor = System.Windows.Forms.Cursors.Default;
            this.pan_barrainferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_barrainferior.Location = new System.Drawing.Point(0, 275);
            this.pan_barrainferior.Name = "pan_barrainferior";
            this.pan_barrainferior.Size = new System.Drawing.Size(345, 15);
            this.pan_barrainferior.TabIndex = 3;
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
            this.panel2.Location = new System.Drawing.Point(330, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 240);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 240);
            this.panel1.TabIndex = 1;
            // 
            // Frm11BackupRestaura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(345, 290);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pan_barrainferior);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_backuprestaura);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.progressBarbkp);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.pan_titulo);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm11BackupRestaura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm11BackupRestaura_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm11BackupRestaura_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.pan_titulo.ResumeLayout(false);
            this.pan_titulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_sair;
        private System.Windows.Forms.Button btn_backuprestaura;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.ProgressBar progressBarbkp;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Panel pan_titulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pan_barrainferior;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}