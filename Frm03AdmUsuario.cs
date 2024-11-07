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
    public partial class Frm03AdmUsuario : Form
    {
        public Frm03AdmUsuario()
        {
            InitializeComponent();
        }

        private void Frm03AdmUsuario_KeyDown(object sender, KeyEventArgs e)
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
            int i;
            i = 0;

            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb01admusuario where Senha='" + txtPass.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("Senha Incorreta!!!");
                this.txtPass.Text = "";
                this.txtPass.Focus();
            }
            else
            {
                MessageBox.Show("Agora Cadastre um Novo Usuário!!!");
                Frm04Usuario frm = new Frm04Usuario();
                this.Hide(); // use dessa maneira.             
                frm.ShowDialog();
            }
            cmd.Connection.Close(); //Fecha a conexão  
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
