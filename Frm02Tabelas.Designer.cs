namespace SIGRas
{
    partial class Frm02Tabelas
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
            this.lbl_Status1 = new System.Windows.Forms.Label();
            this.progressBarbkp1 = new System.Windows.Forms.ProgressBar();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.progressBarbkp = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SuspendLayout();
            // 
            // lbl_Status1
            // 
            this.lbl_Status1.AutoSize = true;
            this.lbl_Status1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Status1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status1.ForeColor = System.Drawing.Color.White;
            this.lbl_Status1.Location = new System.Drawing.Point(9, 87);
            this.lbl_Status1.Name = "lbl_Status1";
            this.lbl_Status1.Size = new System.Drawing.Size(149, 15);
            this.lbl_Status1.TabIndex = 3;
            this.lbl_Status1.Text = "Processando Sistema...0%";
            // 
            // progressBarbkp1
            // 
            this.progressBarbkp1.BackColor = System.Drawing.Color.White;
            this.progressBarbkp1.Location = new System.Drawing.Point(12, 105);
            this.progressBarbkp1.Name = "progressBarbkp1";
            this.progressBarbkp1.Size = new System.Drawing.Size(300, 17);
            this.progressBarbkp1.TabIndex = 4;
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Status.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status.ForeColor = System.Drawing.Color.White;
            this.lbl_Status.Location = new System.Drawing.Point(9, 42);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(148, 15);
            this.lbl_Status.TabIndex = 1;
            this.lbl_Status.Text = "Processando Tabelas...0%";
            // 
            // progressBarbkp
            // 
            this.progressBarbkp.BackColor = System.Drawing.Color.White;
            this.progressBarbkp.Location = new System.Drawing.Point(12, 60);
            this.progressBarbkp.Name = "progressBarbkp";
            this.progressBarbkp.Size = new System.Drawing.Size(300, 17);
            this.progressBarbkp.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(35, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Instalando / Atualizando Tabelas";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // Frm02Tabelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(325, 140);
            this.Controls.Add(this.lbl_Status1);
            this.Controls.Add(this.progressBarbkp1);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.progressBarbkp);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm02Tabelas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm02Tabelas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Status1;
        private System.Windows.Forms.ProgressBar progressBarbkp1;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.ProgressBar progressBarbkp;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}