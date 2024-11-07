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
    public partial class Frm04Usuario : Form
    {
        public Frm04Usuario()
        {
            InitializeComponent();
        }

        private void Frm04Usuario_KeyDown(object sender, KeyEventArgs e)
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

        private void Frm04Usuario_Load(object sender, EventArgs e)
        {
            #region 'PREENCHE AS COMBOBOX'
            //CARREGAR COMBOBOX STATUS            
            this.cbNivelAcesso.Items.Add("Administrador");
            this.cbNivelAcesso.Items.Add("Gerente");
            this.cbNivelAcesso.Items.Add("Supervisor");
            this.cbNivelAcesso.Items.Add("Usuário");
            #endregion
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            #region 'VERIFICA SE AS SENHAS SÃO IGUAIS'
            if (txtPass.Text != txtPassConf.Text || txtPass.Text == "" || txtPassConf.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Senhas não coincidem!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txtPass.Text = "";
                txtPassConf.Text = "";
                txtPass.Focus();
                #endregion                                
            }
            else
            {
                #region 'COMEÇA A VERIFICAÇÃO PARA CADASTRAR'
                //Declarando a variavel
                int i;
                i = 0;

                //Começa o comando para selecionar os dados do banco
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão            
                cmd.CommandText = "SELECT * FROM tb02usuario where user='" + txtUser.Text + "' or email='" + txtEmail.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                if (i == 0)
                {
                    #region 'COMEÇA A GRAVAÇÃO'
                    try
                    {
                        #region 'FAZ AS VERIFICAÇÕES PARA GRAVAR'
                        // VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                        if (txtUser.Text == string.Empty)
                        {
                            MessageBox.Show("Preencha o campo Usuário para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.txtUser.Focus();
                            return;
                        }
                        if (txtEmail.Text == string.Empty)
                        {
                            MessageBox.Show("Preencha o campo Email para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.txtEmail.Focus();
                            return;
                        }
                        if (txtPass.Text == string.Empty)
                        {
                            MessageBox.Show("Preencha o campo Senha para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.txtPass.Focus();
                            return;
                        }
                        if (txtPassConf.Text == string.Empty)
                        {
                            MessageBox.Show("Preencha o campo Confirmação Senha para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.txtPassConf.Focus();
                            return;
                        }
                        if (cbNivelAcesso.Text == string.Empty)
                        {
                            MessageBox.Show("Preencha o campo Nível Acesso para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.cbNivelAcesso.Focus();
                            return;
                        }
                        if (cbNivelAcesso.Text == "Administrador" || cbNivelAcesso.Text == "Gerente" || cbNivelAcesso.Text == "Supervisor" || cbNivelAcesso.Text == "Usuário")
                        {

                        }
                        else
                        {
                            MessageBox.Show("Selecione o Nível Válido para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cbNivelAcesso.Text = "";
                            this.cbNivelAcesso.Focus();
                            return;
                        }
                        #endregion

                        #region 'FAZ A GRAVAÇÃO'
                        //Começa o comando para gravar
                        MySqlCommand cmd1 = new MySqlCommand();
                        cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                        cmd1.CommandText = "Insert Into tb02usuario(user,email,pass,passconf,nivelacesso) Values";
                        cmd1.CommandText += "('" + txtUser.Text + "','" + txtEmail.Text + "','" + txtPass.Text + "','" + txtPassConf.Text + "','" + cbNivelAcesso.Text + "')";
                        cmd1.ExecuteNonQuery();
                        cmd1.Connection.Close(); //Fecha a conexão
                        #endregion

                        #region 'MENSAGEM DE EXECUÇÃO'
                        MessageBox.Show("Usuário Cadastrado com Sucesso!!!");
                        #endregion

                        #region 'ENCERRA A TELA'
                        this.Close();
                        #endregion
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                    #endregion

                    #region 'LIMPA AS CAIXAS'
                    txtUser.Text = "";
                    txtEmail.Text = "";
                    txtPass.Text = "";
                    txtPassConf.Text = "";
                    cbNivelAcesso.Text = "";
                    txtUser.Focus();
                    #endregion
                }
                else
                {
                    #region 'MENSAGEM DE EXECUÇÃO'
                    MessageBox.Show("Usuário ou Email já cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    #endregion

                    #region 'LIMPA AS CAIXAS'
                    txtUser.Text = "";
                    txtEmail.Text = "";
                    txtPass.Text = "";
                    txtPassConf.Text = "";
                    cbNivelAcesso.Text = "";
                    txtUser.Focus();
                    #endregion
                }
                cmd.Connection.Close(); //Fecha a conexão            
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

        private void cbNivelAcesso_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }
    }
}
