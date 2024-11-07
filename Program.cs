using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGRas
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]

        static void Main(string[] args)
        {
            //Verifica se o programa já está em execução
            string Processo = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcessesByName(Processo).Length > 1)
            {
                MessageBox.Show("Programa já executando!");
                return;
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmTelaPrincipal());
            }
        }
    }
}
