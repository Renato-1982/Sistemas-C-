namespace SIGRas
{
    partial class Frm02ProgressBar
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sigRasProgressBar1 = new SIGRas.SIGRasProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.sigRasProgressBar2 = new SIGRas.SIGRasProgressBar();
            this.sigRasProgressBar3 = new SIGRas.SIGRasProgressBar();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sigRasProgressBar1
            // 
            this.sigRasProgressBar1.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.sigRasProgressBar1.ChannelHeight = 10;
            this.sigRasProgressBar1.ForeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.sigRasProgressBar1.ForeColor = System.Drawing.Color.White;
            this.sigRasProgressBar1.Location = new System.Drawing.Point(12, 57);
            this.sigRasProgressBar1.Name = "sigRasProgressBar1";
            this.sigRasProgressBar1.ShowMaximun = true;
            this.sigRasProgressBar1.ShowValue = SIGRas.TextPosition.Right;
            this.sigRasProgressBar1.Size = new System.Drawing.Size(326, 33);
            this.sigRasProgressBar1.SliderColor = System.Drawing.Color.RoyalBlue;
            this.sigRasProgressBar1.SliderHeight = 15;
            this.sigRasProgressBar1.SymbolAfter = "";
            this.sigRasProgressBar1.SymbolBefore = "";
            this.sigRasProgressBar1.TabIndex = 1;
            this.sigRasProgressBar1.Value = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(38, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Instalando / Atualizando Tabelas";
            // 
            // sigRasProgressBar2
            // 
            this.sigRasProgressBar2.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.sigRasProgressBar2.ChannelHeight = 10;
            this.sigRasProgressBar2.ForeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.sigRasProgressBar2.ForeColor = System.Drawing.Color.White;
            this.sigRasProgressBar2.Location = new System.Drawing.Point(12, 96);
            this.sigRasProgressBar2.Name = "sigRasProgressBar2";
            this.sigRasProgressBar2.ShowMaximun = false;
            this.sigRasProgressBar2.ShowValue = SIGRas.TextPosition.Center;
            this.sigRasProgressBar2.Size = new System.Drawing.Size(326, 33);
            this.sigRasProgressBar2.SliderColor = System.Drawing.Color.Orange;
            this.sigRasProgressBar2.SliderHeight = 15;
            this.sigRasProgressBar2.SymbolAfter = "%";
            this.sigRasProgressBar2.SymbolBefore = "";
            this.sigRasProgressBar2.TabIndex = 2;
            this.sigRasProgressBar2.Value = 20;
            // 
            // sigRasProgressBar3
            // 
            this.sigRasProgressBar3.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.sigRasProgressBar3.ChannelHeight = 10;
            this.sigRasProgressBar3.ForeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.sigRasProgressBar3.ForeColor = System.Drawing.Color.White;
            this.sigRasProgressBar3.Location = new System.Drawing.Point(12, 135);
            this.sigRasProgressBar3.Name = "sigRasProgressBar3";
            this.sigRasProgressBar3.ShowMaximun = false;
            this.sigRasProgressBar3.ShowValue = SIGRas.TextPosition.Sliding;
            this.sigRasProgressBar3.Size = new System.Drawing.Size(326, 33);
            this.sigRasProgressBar3.SliderColor = System.Drawing.Color.Green;
            this.sigRasProgressBar3.SliderHeight = 15;
            this.sigRasProgressBar3.SymbolAfter = "%";
            this.sigRasProgressBar3.SymbolBefore = "";
            this.sigRasProgressBar3.TabIndex = 3;
            this.sigRasProgressBar3.Value = 20;
            // 
            // timer2
            // 
            this.timer2.Interval = 40;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 60;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Frm02ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(350, 190);
            this.Controls.Add(this.sigRasProgressBar3);
            this.Controls.Add(this.sigRasProgressBar2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sigRasProgressBar1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm02ProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm02ProgressBar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Timer timer1;
        private SIGRasProgressBar sigRasProgressBar1;
        private System.Windows.Forms.Label label3;
        private SIGRasProgressBar sigRasProgressBar2;
        private SIGRasProgressBar sigRasProgressBar3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
    }
}