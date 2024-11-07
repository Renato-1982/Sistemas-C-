using MySql.Data.MySqlClient;
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
    public partial class Frm10BackupAdmRestaura : Form
    {
        public Frm10BackupAdmRestaura()
        {
            InitializeComponent();
        }

        private void Frm10BackupAdmRestaura_KeyDown(object sender, KeyEventArgs e)
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

        private void btn_acessar_Click(object sender, EventArgs e)
        {
            #region 'COMEÇA A VERIFICAÇÃO DE ACESSO'

            #region 'DECLARA A VARIAVEL'
            int i;
            i = 0;
            #endregion

            #region 'FAZ O SELECT NO BANCO'
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb06admbackup where Senha='" + txtSenha.Text + "'";
            cmd.ExecuteNonQuery();
            #endregion

            #region 'CARREGA OS DADOS NO DATATABLE E CONVERTE'
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            #endregion

            #region 'VERIFICA SE A SENHA É IGUAL'
            if (i == 0)
            {
                #region 'MENSAGEM'
                MessageBox.Show("Senha Incorreta!!!");
                #endregion

                #region 'LIMPA AS CAIXAS'
                this.txtSenha.Text = "";
                this.txtSenha.Focus();
                #endregion
            }
            else
            {
                #region ' MENSAGEM'
                MessageBox.Show("Agora Restaure a Base de Dados(BKP_SIGRASSYSTEMBD_Mysql)!!!");
                #endregion

                #region 'ABRE NOVA TELA'
                Frm11BackupRestaura frm = new Frm11BackupRestaura();
                this.Hide(); // use dessa maneira.             
                frm.ShowDialog();
                #endregion
            }
            #endregion

            #region 'FECHA A CONEXÃO'
            cmd.Connection.Close(); //Fecha a conexão 
            #endregion

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
