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
    public partial class Frm05AdmReativacao : Form
    {
        public Frm05AdmReativacao()
        {
            InitializeComponent();
        }

        private void Frm05AdmReativacao_KeyDown(object sender, KeyEventArgs e)
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
            #region 'VERIFICA SE É ATIVAÇÃO OU REATIVAÇÃO'
            var IDlicenca = "";
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "Select ID from tb07acessovalidade order by ID";
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar   

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                IDlicenca = dr["ID"].ToString();
            }
            //Fecha a conexão
            cmd.Connection.Close();

            if (IDlicenca != "")
            {
                #region 'COMEÇA A VERIFICAÇÃO DE ACESSO'
                int i;
                i = 0;

                //Começa o comando para selecionar os dados do banco
                MySqlCommand cmd1 = new MySqlCommand();
                cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd1.CommandText = "SELECT * FROM tb04admreativacao where Senha='" + txtPass.Text + "'";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                da1.Fill(dt1);
                i = Convert.ToInt32(dt1.Rows.Count.ToString());

                if (i == 0)
                {
                    MessageBox.Show("Senha Incorreta!!!");
                    this.txtPass.Text = "";
                    this.txtPass.Focus();
                }
                else
                {
                    MessageBox.Show("Agora prepare o sistema para um novo serial!!!");
                    Frm06Reativacao frm = new Frm06Reativacao();
                    this.Hide(); // use dessa maneira.             
                    frm.ShowDialog();
                }
                cmd1.Connection.Close(); //Fecha a conexão  
                #endregion
            }
            else
            {
                #region 'MENSAGEM'
                MessageBox.Show("Primeira ativação." + "\n" + "Ative pela tela login!", "Ativação do sistema:");
                #endregion

                #region 'ENCERRA A APLICAÇÃO'
                Application.Exit();
                this.Close();
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
