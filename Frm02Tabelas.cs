using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGRas
{
    public partial class Frm02Tabelas : Form
    {
        public Frm02Tabelas()
        {
            InitializeComponent();
        }

        private Task ProcessData(List<string> list, IProgress<ProgressReport> progress)
        {
            #region 'DECLARA E CRIA A BARRA PROGRESSO'
            //Declaração para Barra Progresso
            int index = 1;
            int totalProcess = list.Count;
            var progressReport = new ProgressReport();
            return Task.Run(() =>
            {
                for (int i = 0; i < totalProcess; i++)
                {
                    progressReport.PercentComplete = index++ * 100 / totalProcess;
                    progress.Report(progressReport);
                    Thread.Sleep(10); //used to simulate length of operation
                }
            });
            #endregion
        }

        private Task ProcessData1(List<string> list1, IProgress<ProgressReport> progress1)
        {
            #region 'DECLARA E CRIA A BARRA PROGRESSO'
            //Declaração para Barra Progresso
            int index1 = 1;
            int totalProcess1 = list1.Count;
            var progressReport1 = new ProgressReport();
            return Task.Run(() =>
            {
                for (int i = 0; i < totalProcess1; i++)
                {
                    progressReport1.PercentComplete = index1++ * 100 / totalProcess1;
                    progress1.Report(progressReport1);
                    Thread.Sleep(10); //used to simulate length of operation
                }
            });
            #endregion           
        }

        private async void processatabelas()
        {
            #region 'EXECUTA A BARRA PROGRESSO'
            //Início da Barra Progresso
            List<string> list = new List<string>();
            for (int i = 0; i < 200; i++)
                list.Add(i.ToString());
            lbl_Status.Text = "Working...";
            var progress = new Progress<ProgressReport>();
            progress.ProgressChanged += (o, report) => {
                lbl_Status.Text = string.Format("Processando Tabelas...{0}%", report.PercentComplete);
                progressBarbkp.Value = report.PercentComplete;
                progressBarbkp.Update();
            };
            await ProcessData(list, progress);
            lbl_Status.Text = "Tabelas Processadas!!!";
            this.Close();
            //Fim da Barra Progresso
            #endregion
        }

        private async void processatabelas1()
        {
            #region 'EXECUTA A BARRA PROGRESSO'
            //Início da Barra Progresso
            List<string> list1 = new List<string>();
            for (int i = 0; i < 300; i++)
                list1.Add(i.ToString());
            lbl_Status1.Text = "Working...";
            var progress1 = new Progress<ProgressReport>();
            progress1.ProgressChanged += (o, report) => {
                lbl_Status1.Text = string.Format("Processando Sistema...{0}%", report.PercentComplete);
                progressBarbkp1.Value = report.PercentComplete;
                progressBarbkp1.Update();
            };
            await ProcessData(list1, progress1);
            lbl_Status1.Text = "Sistema Processado!!!";
            this.Close();
            //Fim da Barra Progresso
            #endregion                        
        }

        private void Frm02Tabelas_Load(object sender, EventArgs e)
        {
            #region 'CLASSE DE CRIAÇÃO DO BANCO E TABELAS'
            //Busca a classe de criação do banco e tabelas no MySQL
            ClasseCriarBDTable.conectar();
            //Inicia a página para download do banco MySQL
            //System.Diagnostics.Process.Start("https://dev.mysql.com/downloads/windows/installer/");
            #endregion

            #region 'CHAMA OS PROCESSOS'
            processatabelas();
            processatabelas1();
            #endregion
        }
    }
}
