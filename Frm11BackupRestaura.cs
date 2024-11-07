using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGRas
{
    public partial class Frm11BackupRestaura : Form
    {
        public Frm11BackupRestaura()
        {
            InitializeComponent();
        }

        private void Frm11BackupRestaura_KeyDown(object sender, KeyEventArgs e)
        {
            #region 'AVANÇAR OU VOLTAR A SELEÇÃO DE CAIXA COM O ENTER'
            //Obs.1: O código ” !e.Shift” indica que é para mudar para o próximo campo se pressionado ENTER, 
            //e ir para o campo anterior se pressionados SHIFT e ENTER simultaneamente (o mesmo funcionamento do SHIFT + TAB).
            // 1- Alterar a propriedade KeyPreview do Formulário para ” true”
            // 2- Preencha o evento KeyDown do Formulário com o seguinte código:
            //MUDA DE TEXTBOX COM O ENTER
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
            #endregion
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

        private void Frm11BackupRestaura_Load(object sender, EventArgs e)
        {
            #region 'ATIVA/DESATIVA OS BOTÕES'           
            this.btn_backuprestaura.Enabled = true;
            #endregion
        }

        private async void btn_backuprestaura_Click(object sender, EventArgs e)
        {
            #region ' VERIFICA SE AS PASTAS EXISTEM'
            //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
            string pastabkp = @"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp";
            if (!Directory.Exists(pastabkp))
            {
                Directory.CreateDirectory(pastabkp);
            }
            //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
            string pastabkpBKPRestaura = @"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp\BKP_Restaura";
            if (!Directory.Exists(pastabkpBKPRestaura))
            {
                Directory.CreateDirectory(pastabkpBKPRestaura);
            }
            #endregion

            #region 'VERIFICA SE O TEM O ARQUIVO PARA RESTAURAR O BACKUP'
            //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
            string arquivorestaura = @"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp\BKP_Restaura\BKP_SIGRASSYSTEMBD_Mysql" + ".sql";
            if (!File.Exists(arquivorestaura))
            {
                MessageBox.Show("Arquivo não encontrado!");
            }
            else
            {
                #region 'ATIVA/DESATIVA OS BOTÕES'          
                this.btn_backuprestaura.Enabled = false;
                this.btn_sair.Enabled = false;
                #endregion

                #region "RESTAURA BANCO"
                //RESTAURAÇÃO BACKUP BD MYSQL
                string constring1 = "SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;";

                //Opções de conexão adicionais importantes
                constring1 += "charset=utf8;convertzerodatetime=true;";

                string file1 = "C:/SIGRASSYSTEMBD/SIGRASSYSTEMBD_bkp/BKP_Restaura/BKP_SIGRASSYSTEMBD_Mysql.sql";

                using (MySqlConnection conn = new MySqlConnection(constring1))
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(command))
                        {
                            command.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(file1);
                            conn.Close();
                        }
                    }
                }
                #endregion

                #region 'EXECUTA A BARRA PROGRESSO'
                //Início da Barra Progresso
                List<string> list = new List<string>();
                for (int i = 0; i < 1000; i++)
                    list.Add(i.ToString());
                lbl_Status.Text = "Working...";
                var progress = new Progress<ProgressReport>();
                progress.ProgressChanged += (o, report) => {
                    lbl_Status.Text = string.Format("Processando...{0}%", report.PercentComplete);
                    progressBarbkp.Value = report.PercentComplete;
                    progressBarbkp.Update();
                };
                await ProcessData(list, progress);
                lbl_Status.Text = "Backup Restaurado!!!";
                //Fim da Barra Progresso
                #endregion

                #region 'MOVE O ARQUIVO PARA PASTA ULTIMO RESTAURADO'
                //MOVE O ÚLTIMO ARQUIVO RESTAURADO PARA A PASTA BKP_UltimoRestaurado
                //DEFINE O NOME DO ARQUIVO DE ACORDO COM DATA E HORA.
                string dia = DateTime.Now.Day.ToString();
                string mes = DateTime.Now.Month.ToString();
                string ano = DateTime.Now.Year.ToString();
                string hora = DateTime.Now.ToLongTimeString().Replace(":", "");
                string nomedoarquivo = "_" + dia + "-" + mes + "-" + ano + "_" + hora;
                //MOVENDO O ARQUIVO DA PASTA BKP_Restaura PARA A PASTA BKP_UltimoRestaurado
                File.Move(@"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp\BKP_Restaura\BKP_SIGRASSYSTEMBD_Mysql" + ".sql", @"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp\BKP_UltimoRestaurado\BKP_SIGRASSYSTEMBD_Mysql" + nomedoarquivo + ".sql");
                //Fim
                #endregion

                #region 'MENSAGEM'
                MessageBox.Show("Backup restaurado com sucesso!!!");
                #endregion

                #region 'ATIVA/DESATIVA OS BOTÕES'         
                this.btn_backuprestaura.Enabled = true;
                this.btn_sair.Enabled = true;
                #endregion
            }
            #endregion
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            #region 'ENCERRA A APLICAÇÃO'
            this.Close();
            #endregion
        }
    }
}
