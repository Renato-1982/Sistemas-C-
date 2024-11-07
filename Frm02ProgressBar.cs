using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGRas
{
    public partial class Frm02ProgressBar : Form
    {
        public Frm02ProgressBar()
        {
            InitializeComponent();
        }

        private void Frm02ProgressBar_Load(object sender, EventArgs e)
        {
            #region 'CLASSE DE CRIAÇÃO DO BANCO E TABELAS'
            //Busca a classe de criação do banco e tabelas no MySQL
            ClasseCriarBDTable.conectar();
            //Inicia a página para download do banco MySQL
            //System.Diagnostics.Process.Start("https://dev.mysql.com/downloads/windows/installer/");
            #endregion

            #region 'INICIA E CHAMA OS PROCESSOS'
            sigRasProgressBar1.Value = 0;
            sigRasProgressBar2.Value = 0;
            sigRasProgressBar3.Value = 0;
            timer1.Start();
            timer2.Start();
            timer3.Start();
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region 'BARRA PROGRESSO 1'
            if (sigRasProgressBar1.Value < sigRasProgressBar1.Maximum)
            {
                sigRasProgressBar1.Value++;
            }
            #endregion
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            #region 'BARRA PROGRESSO 2'
            if (sigRasProgressBar2.Value < sigRasProgressBar2.Maximum)
            {
                sigRasProgressBar2.Value++;
            }
            #endregion
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            #region 'BARRA PROGRESSO 3'
            if (sigRasProgressBar3.Value < sigRasProgressBar3.Maximum)
            {
                sigRasProgressBar3.Value++;
            }
            else
            {
                this.Close();
            }
            #endregion
        }
    }
}
