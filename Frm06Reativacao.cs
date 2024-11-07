using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGRas
{
    public partial class Frm06Reativacao : Form
    {
        public Frm06Reativacao()
        {
            InitializeComponent();
        }

        private void Frm06Reativacao_KeyDown(object sender, KeyEventArgs e)
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

        private void btn_reativar_Click(object sender, EventArgs e)
        {
            #region 'COMANDO PARA LIMPAR A TABELA INTEIRA USANDO O TRUNCATE'
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            //cmd.CommandText = "Delete from tbl_dadosfichacras Where ID = " + txtIDficha.Text + "";
            cmd.CommandText = "truncate table tb07acessovalidade";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close(); //Fecha a conexão
            #endregion

            #region 'MENSAGEM'
            MessageBox.Show("Software não ativado!" + "\n" + "Ative com uma nova licença!");
            MessageBox.Show("Execute o sistema novamente!" + "\n" + " Em seguida ative com uma nova licença!");
            #endregion

            #region 'VERIFICA E LIMPA O ARQUIVO DE TEXTO'
            if (new FileInfo(@"C:\SIGRASSYSTEMBD\Atvdr\Reg.txt").Length == 0)
            {
                // empty
            }
            else
            {
                List<string> mensagemLinha = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(@"C:\SIGRASSYSTEMBD\Atvdr\Reg.txt");
                System.IO.File.WriteAllLines(@"C:\SIGRASSYSTEMBD\Atvdr\Reg.txt", lines.Take<string>(lines.Length - 1000));
            }
            #endregion

            #region 'ENCERRA O SISTEMA
            Application.Exit();
            this.Close();
            #endregion
        }
    }
}
