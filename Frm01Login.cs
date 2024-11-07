using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SIGRas
{
    public partial class Frm01Login : Form
    {
        public Frm01Login()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            #region 'ENCERRA A APLICAÇÃO'
            //FECHA O FORMULÁRIO COM MENSAGEM
            DialogResult dlgResult = MessageBox.Show("Deseja sair da aplicação ?", "Encerrar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                Application.Exit();
                this.Close();
            }
            #endregion
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            #region 'MINIMIZA O FORMULARIO'
            this.WindowState = FormWindowState.Minimized;
            #endregion
        }

        private void pan_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            #region 'MOVIMENTAR O FORMULARIO'
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            #endregion
        }

        private void pan_barrainferior_MouseDown(object sender, MouseEventArgs e)
        {
            #region 'MOVIMENTAR O FORMULARIO'
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            #endregion
        }

        #region 'DECLARAÇÃO PARA MOVIMENTAR O FORMULÁRIO'
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        private void Frm01Login_KeyDown(object sender, KeyEventArgs e)
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

        private void btnCerrar_MouseHover(object sender, EventArgs e)
        {
            #region 'MUDA COR DO BOTÃO'
            btnCerrar.BackColor = Color.DimGray;
            #endregion
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            #region 'MUDA COR DO BOTÃO'
            btnCerrar.BackColor = Color.FromArgb(38, 45, 53);
            #endregion
        }

        private void btnMinimizar_MouseHover(object sender, EventArgs e)
        {
            #region 'MUDA COR DO BOTÃO'
            //btnMinimizar.BackColor = Color.FromArgb(64, 69, 76);
            btnMinimizar.BackColor = Color.DimGray;
            #endregion
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            #region 'MUDA COR DO BOTÃO'
            btnMinimizar.BackColor = Color.FromArgb(38, 45, 53);
            #endregion
        }

        private void link_novousuario_MouseHover(object sender, EventArgs e)
        {
            #region 'MUDA COR DO BOTÃO'
            link_novousuario.BackColor = Color.DodgerBlue;
            #endregion
        }

        private void link_novousuario_MouseLeave(object sender, EventArgs e)
        {
            #region 'MUDA COR DO BOTÃO'
            link_novousuario.BackColor = Color.FromArgb(64, 69, 76);
            #endregion
        }

        private void link_contato_MouseHover(object sender, EventArgs e)
        {
            #region 'MUDA COR DO BOTÃO'
            link_contato.BackColor = Color.DodgerBlue;
            #endregion
        }

        private void link_contato_MouseLeave(object sender, EventArgs e)
        {
            #region 'MUDA COR DO BOTÃO'
            link_contato.BackColor = Color.FromArgb(64, 69, 76);
            #endregion
        }

        private void link_reativar_MouseHover(object sender, EventArgs e)
        {
            #region 'MUDA COR DO BOTÃO'
            link_reativar.BackColor = Color.DodgerBlue;
            #endregion
        }

        private void link_reativar_MouseLeave(object sender, EventArgs e)
        {
            #region 'MUDA COR DO BOTÃO'
            link_reativar.BackColor = Color.FromArgb(64, 69, 76);
            #endregion
        }

        private void Frm01Login_Activated(object sender, EventArgs e)
        {
            #region 'COLOCA O FOCO'
            txtUser.Focus();
            #endregion
        }

        private void Frm01Login_Load(object sender, EventArgs e)
        {
            #region 'COLOCA O FOCO'
            txtUser.Focus();
            #endregion

            #region "ABRE NOVA TELA"
            this.Hide();
            Frm02ProgressBar frm = new Frm02ProgressBar();
            frm.ShowDialog();
            #endregion
                                                
            #region 'VERIFICA SE PASTAS EXISTEM'
            string sigrassystembd = @"C:\SIGRASSYSTEMBD";
            if (!Directory.Exists(sigrassystembd))
            {
                #region "CRIAR PASTAS SE NÃO EXISTIR NO DIRETÓRIO C:"            
                //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO
                string pastabancogeral = @"C:\SIGRASSYSTEMBD";
                if (!Directory.Exists(pastabancogeral))
                {
                    Directory.CreateDirectory(pastabancogeral);
                }

                //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO
                string pastaatvdr = @"C:\SIGRASSYSTEMBD\Atvdr";
                if (!Directory.Exists(pastaatvdr))
                {
                    Directory.CreateDirectory(pastaatvdr);
                }

                //DECLARA A VARIÁVEL E CRIA O ARQUIVO SE NÃO EXISTIR NO DIRETÓRIO
                string arquivoatvdr = @"C:\SIGRASSYSTEMBD\Atvdr\Reg" + ".txt";
                if (!File.Exists(arquivoatvdr))
                {
                    File.Create(arquivoatvdr).Close();
                }

                //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
                string pastabkp = @"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp";
                if (!Directory.Exists(pastabkp))
                {
                    Directory.CreateDirectory(pastabkp);
                }

                //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
                string pastabkpBKPSilencioso = @"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp\BKP_Silencioso";
                if (!Directory.Exists(pastabkpBKPSilencioso))
                {
                    Directory.CreateDirectory(pastabkpBKPSilencioso);
                }

                //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
                string pastabkpBKPRestaura = @"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp\BKP_Restaura";
                if (!Directory.Exists(pastabkpBKPRestaura))
                {
                    Directory.CreateDirectory(pastabkpBKPRestaura);
                }

                //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
                string pastabkpBKPRestauraUltimo = @"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp\BKP_UltimoRestaurado";
                if (!Directory.Exists(pastabkpBKPRestauraUltimo))
                {
                    Directory.CreateDirectory(pastabkpBKPRestauraUltimo);
                }

                //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
                string pastabkpBKPInicializacaoVazio = @"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp\BKP_InicializacaoVazio";
                if (!Directory.Exists(pastabkpBKPInicializacaoVazio))
                {
                    Directory.CreateDirectory(pastabkpBKPInicializacaoVazio);
                }

                //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
                string pastabBACKUP = @"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp\BACKUP";
                if (!Directory.Exists(pastabBACKUP))
                {
                    Directory.CreateDirectory(pastabBACKUP);
                }

                //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
                string pastaorcamentos = @"C:\SIGRASSYSTEMBD\ORCAMENTOS";
                if (!Directory.Exists(pastaorcamentos))
                {
                    Directory.CreateDirectory(pastaorcamentos);
                }

                //DECLARA A VARIÁVEL E CRIA O ARQUIVO SE NÃO EXISTIR NO DIRETÓRIO
                string arquivoorcamento = @"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento" + ".txt";
                if (!File.Exists(arquivoorcamento))
                {
                    File.Create(arquivoorcamento).Close();
                }

                //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
                string pastavendas = @"C:\SIGRASSYSTEMBD\VENDAS";
                if (!Directory.Exists(pastavendas))
                {
                    Directory.CreateDirectory(pastavendas);
                }

                //DECLARA A VARIÁVEL E CRIA O ARQUIVO SE NÃO EXISTIR NO DIRETÓRIO
                string arquivovenda = @"C:\SIGRASSYSTEMBD\VENDAS\Venda" + ".txt";
                if (!File.Exists(arquivovenda))
                {
                    File.Create(arquivovenda).Close();
                }
                #endregion

                #region "BACKUP BANCO"            
                // BACKUP BD MYSQL
                string constring = "SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;";
                //Opções de conexão adicionais importantes
                constring += "charset=utf8;convertzerodatetime=true;";

                string file = "C:/SIGRASSYSTEMBD/SIGRASSYSTEMBD_bkp/BKP_InicializacaoVazio/BKP_SIGRASSYSTEMBD_Mysql_Inicializacao.sql";

                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(command))
                        {
                            command.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
                #endregion

                #region "RESTAURA BANCO"
                //RESTAURAÇÃO BACKUP BD MYSQL
                string constring1 = "SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;";

                //Opções de conexão adicionais importantes
                constring1 += "charset=utf8;convertzerodatetime=true;";

                string file1 = "C:/SIGRASSYSTEMBD/SIGRASSYSTEMBD_bkp/BKP_InicializacaoVazio/BKP_SIGRASSYSTEMBD_Mysql_Inicializacao.sql";

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
            }
            else
            {

            }
            #endregion

            #region "VERIFICAR ATIVAÇÃO DO SISTEMA"
            //LENDO O ARQUIVO TXT DE ATIVAÇÃO NO DIRETÓRIO C:\SIGRASCRASBD\Atvdr
            //DECLARA A VARIÁVEL                
            string serial;
            StreamReader leitor = new StreamReader(@"C:\SIGRASSYSTEMBD\Atvdr\Reg.txt");
            serial = leitor.ReadLine();
            //serial = CriptografiaHelper.Decriptar(leitor.ReadLine());                

            if (serial != "H02J-2RR1-WS55-A6A6-0101")
            {
                this.Text = "Software Não Registrado";
                btnLogin.Enabled = false;
                txtUser.Enabled = false;
                txtPass.Enabled = false;
                link_novousuario.Enabled = false;
                link_reativar.Enabled = false;
                lblAviso.Text = "Digite o Serial para Ativar!";
                MessageBox.Show("Software Não Ativado!" + "\n" + "Digite o Serial para Ativar!");
                txtSerial.Text = "";
                txtSerial.Focus();
            }
            else
            {
                ativado();
                licenca();
            }
            leitor.Close();
            #endregion

            #region 'COLOCA O FOCO'
            txtUser.Focus();
            #endregion
        }

        private void licenca()
        {
            #region 'COMEÇA A VERIFICAÇÃO DA LICENÇA'
            //Declarando a variavel e deixando limpa
            string DRest = string.Empty;
            string DExp = string.Empty;

            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb07acessovalidade where ID = " + 1 + ""; //Seleciona a tabela e procura os dados            
            MySqlDataReader reader = cmd.ExecuteReader(); //Executa o comando selecionar

            //Faz a leitura e repassa os dados para variavel
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    DRest = reader.GetString("Diasrestante");
                    DExp = reader.GetString("Dataexpiracao");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }

            //Declarando a variavel e deixando limpa
            string diasrestante1 = string.Empty;
            string dataexpiracao = string.Empty;
                        
            //Repassando dados selecionados no banco de uma variável para uma nova variável
            diasrestante1 = DRest;//diasrestante1 é uma string 
            dataexpiracao = DExp;//dataexpiracao é uma string 

            //Convertendo string para inteiro
            int diasrestante;
            diasrestante = Convert.ToInt32(diasrestante1);//diasrestante agora é um inteiro

            //Se a variável for menor ou igual a que está gravada no banco, o sistema não será liberado. 
            //Pois os dias de acesso já terminaram e não atualiza a validação no banco.
            //Com isso mesmo se o usuário voltar a data do sistema ele não irá liberar o acesso.                   
            if (diasrestante <= 0 || dataexpiracao == "")
            {              
                MessageBox.Show("Entre em contato com o desenvolvedor para renovar sua licença! Telefones: (31) 9.9757-2559 / (31) 9.8804-8781", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Text = "Licença Expirada";
                btnLogin.Enabled = false;
                txtUser.Enabled = false;
                txtPass.Enabled = false;
                lblAviso.Text = "Licença Expirada!";
                lblAviso.ForeColor = Color.Red;
                this.Width = 290;
                this.Height = 430;
                txtSerial.Enabled = true;
                btnAtivar.Enabled = true;
                txtSerial.Visible = true;
                btnAtivar.Visible = true;
                link_reativar.Enabled = true;
                link_novousuario.Enabled = false;
            }
            else
            {
                //Começa a validação de dados para acesso
                //A validação é feita em cima da variável inteiro.
                //Se a variável for maior a que está gravada no banco o sistema é liberado e sempre atualiza a validação no banco.     
                DateTime dataatual = DateTime.Today; //Pega a data atual
                DateTime datahoje = DateTime.Now; //Pega a data hoje
                TimeSpan date = Convert.ToDateTime(dataexpiracao) - Convert.ToDateTime(dataatual); //Subtrai a data final menos a data atual do sistema
                int Dias = date.Days; //Repassa a quantidade de dias restante para variável inteiro

                //Começa os comandos para gravar e atualizar a quantidade de dias restantes no banco
                MySqlCommand com = new MySqlCommand();
                com.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                com.CommandText = "update tb07acessovalidade set Dataatual = '" + dataatual + "' ,Datahoje = '" + datahoje + "' ,Diasrestante = '" + Dias + "' Where ID = " + 1 + ""; //Atualiza os dados da tabela                                   
                com.ExecuteNonQuery(); //Atualiza os registros na tabela                       
                com.Connection.Close(); //Fecha a conexão    

                //Mensagem de informação de validade da ativação
                if (diasrestante <= 15)
                {
                    MessageBox.Show(Dias.ToString() + "  Dias " + "\r\n" + " " + "\r\n" + "Sua licença está expirando!!!" + "\r\n" + "Entre em contato para renovar sua licença.", "Licença Restante:"); //Mensagem                                      
                }
            }
            #endregion
        }

        private void ativado()
        {
            #region 'LIBERAR ACESSO CASO ESTEJA ATIVADO'
            this.Text = "Softaware Ativado! Entre com seu Usuário e Senha!";
            lblAviso.Text = "Software Ativado!";
            lblAviso.ForeColor = Color.Green;
            btnLogin.Enabled = true;
            txtUser.Enabled = true;
            txtPass.Enabled = true;
            btnAtivar.Enabled = false;
            txtSerial.Enabled = false;
            this.Width = 290;
            this.Height = 365;
            txtSerial.Visible = false;
            btnAtivar.Visible = false;
            link_reativar.Enabled = false;
            link_novousuario.Enabled = true;
            #endregion
        }

        private void link_novousuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region 'ABRE NOVO FORMULARIO'
            Frm03AdmUsuario frm = new Frm03AdmUsuario();
            frm.ShowDialog();
            #endregion
        }

        private void link_contato_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region 'ABRE NOVO FORMULARIO'
            Frm12Contatos frm = new Frm12Contatos();
            frm.ShowDialog();
            #endregion
        }

        private void link_reativar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region 'ABRE NOVO FORMULARIO'
            this.Hide();
            Frm05AdmReativacao frm = new Frm05AdmReativacao();
            frm.ShowDialog();
            #endregion
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            #region 'COMEÇA A VERIFICAÇÃO DE LOGIN'
            int i;
            i = 0;

            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb02usuario where user='" + txtUser.Text + "' AND pass='" + txtPass.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                //INICIA A GRAVAÇÃO DE TENTATIVA DE ACESSO DO USUARIO NÃO CADASTRADO
                //DECLARANDO VARIÁVEIS
                DateTime DataAgora = DateTime.Now;
                string TpnUsuario = "Usuário Não Cadastrado";

                //Começa o comando para gravar
                MySqlCommand cmd1 = new MySqlCommand();
                cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd1.CommandText = "Insert Into tb03usuariocontrole(Usuario,Senha,DataHora,TipoUsuario) Values";
                cmd1.CommandText += "('" + txtUser.Text + "','" + txtPass.Text + "','" + DataAgora + "','" + TpnUsuario + "')";
                cmd1.ExecuteNonQuery();
                cmd1.Connection.Close(); //Fecha a conexão

                MessageBox.Show("Usuário ou Senha Incorreto!!!" + "\n" + "Digite Novamente ou" + "\n" + "Cadastre um Novo Usuário");
                this.txtUser.Text = "";
                this.txtPass.Text = "";
                this.txtUser.Focus();
            }
            else
            {
                //INICIA A GRAVAÇÃO DE TENTATIVA DE ACESSO DO USUARIO CADASTRADO
                //DECLARANDO VARIÁVEIS
                DateTime DataAgora = DateTime.Now;
                string TpUsuario = "Usuário Cadastrado";

                //Começa o comando para gravar
                MySqlCommand cmd1 = new MySqlCommand();
                cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd1.CommandText = "Insert Into tb03usuariocontrole(Usuario,Senha,DataHora,TipoUsuario) Values";
                cmd1.CommandText += "('" + txtUser.Text + "','" + txtPass.Text + "','" + DataAgora + "','" + TpUsuario + "')";
                cmd1.ExecuteNonQuery();
                cmd1.Connection.Close(); //Fecha a conexão              

                //MENSAGEM
                MessageBox.Show(txtUser.Text + "! Seja Bem Vindo!!!");
                //FECHA A TELA
                this.Hide();
                //ABRE NOVA TELA
                FrmTelaPrincipal frm = new FrmTelaPrincipal();
                frm.Show();
            }
            cmd.Connection.Close(); //Fecha a conexão            
            #endregion
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            #region 'ENCERRA A APLICAÇÃO'
            //FECHA O FORMULÁRIO COM MENSAGEM
            DialogResult dlgResult = MessageBox.Show("Deseja sair da aplicação ?", "Encerrar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                Application.Exit();
                this.Close();
            }
            #endregion
        }

        private void btnAtivar_Click(object sender, EventArgs e)
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
                #region 'MENSAGEM'
                MessageBox.Show("Reativação somente pelo link Reativar Sistema!" + "\n" + "Entre em contato com o desenvolvedor.", "Reativação do sistema:");
                txtSerial.Text = "";
                #endregion
            }
            else
            {
                #region 'ATIVAR COM SERIAL'
                if (txtSerial.Text != "H02J-2RR1-WS55-A6A6-0101")
                {
                    lblAviso.Text = "";
                    lblAviso.Text = "Serial Inválido!";
                    MessageBox.Show("Software Não Ativado!" + "\n" + "Serial Inválido!");
                    txtSerial.Text = "";
                    txtSerial.Focus();
                }
                else
                {
                    string gravar;
                    gravar = txtSerial.Text;
                    StreamWriter escreve = new StreamWriter(@"C:\SIGRASSYSTEMBD\Atvdr\Reg.txt");
                    escreve.WriteLine(gravar);
                    //escreve.WriteLine(CriptografiaHelper.Encriptar(gravar));
                    escreve.Close();
                    lblAviso.Text = "Software Ativado!";
                    lblAviso.ForeColor = Color.Green;
                    MessageBox.Show("Software Ativado!");

                    //Começa a gravação de validação
                    DateTime datainicial = DateTime.Today; //Pega a data inicial
                    DateTime dataatual = DateTime.Today; //Pega a data atual
                    DateTime datahoje = DateTime.Now; //Pega a data hoje
                    DateTime dataexpiracao = datainicial.AddDays(365); //Adiciona uma quantidade de dias a data inicial                
                    TimeSpan date = Convert.ToDateTime(dataexpiracao) - Convert.ToDateTime(datainicial);
                    int Dias = date.Days;

                    //Começa o comando para gravar
                    MySqlCommand cmd1 = new MySqlCommand();
                    cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                    cmd1.CommandText = "Insert Into tb07acessovalidade(Datainicial,Dataatual,Datahoje,Dataexpiracao,Diasrestante) Values"; //Seleciona a tabela para gravar
                    cmd1.CommandText += "('" + datainicial + "','" + dataatual + "','" + datahoje + "','" + dataexpiracao + "','" + Dias + "')"; //Insere os dados dos campos
                    cmd1.ExecuteNonQuery(); //Grava registros na tabela                       
                    cmd1.Connection.Close(); //Fecha a conexão

                    MessageBox.Show("Execute o sistema novamente!");

                    Application.Exit();
                    this.Close();

                    //Reinicia o formulario para ativar as alteraçoes
                    //FrmAcessoLogin_Load(sender, e);
                }
                #endregion
            }
            #endregion                                                                  
        }
    }
}
