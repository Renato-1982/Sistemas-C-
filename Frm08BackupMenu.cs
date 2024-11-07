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
    public partial class Frm08BackupMenu : Form
    {
        public Frm08BackupMenu()
        {
            InitializeComponent();
        }

        private void Frm08BackupMenu_KeyDown(object sender, KeyEventArgs e)
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

        private void btn_backup_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVO FORMULARIO'
            Frm09Backup frm = new Frm09Backup();
            this.Hide();
            frm.ShowDialog();
            #endregion
        }

        private void btn_backuprestaura_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVO FORMULARIO'
            Frm10BackupAdmRestaura frm = new Frm10BackupAdmRestaura();
            this.Hide();
            frm.ShowDialog();
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
