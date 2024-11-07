using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGRas
{
    public partial class FrmCadastroMultiplosRelatorios : Form
    {
        public FrmCadastroMultiplosRelatorios()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            #region 'ENCERRA A APLICAÇÃO'
            //FECHA O FORMULÁRIO COM MENSAGEM
            DialogResult dlgResult = MessageBox.Show("Deseja sair da tela ?", "Encerrar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                this.Close();
            }
            #endregion
        }

        private void pan_titulo_MouseDown(object sender, MouseEventArgs e)
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

        private void FrmCadastroMultiplosRelatorios_KeyDown(object sender, KeyEventArgs e)
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

        private void tc_cadastromultiplos_DrawItem(object sender, DrawItemEventArgs e)
        {
            #region 'MUDA A COR DA GUIA AO CLICAR'

            //FORMATAÇÃO DA TABCONTROL'
            TabPage CurrentTab = tc_cadastromultiplos.TabPages[e.Index];
            Rectangle ItemRect = tc_cadastromultiplos.GetTabRect(e.Index);
            SolidBrush FillBrush = new SolidBrush(Color.White);
            SolidBrush TextBrush = new SolidBrush(Color.Black);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //Se estivermos pintando o TabItem selecionado, vamos
            //altera as cores do pincel e infla o retângulo.
            if (System.Convert.ToBoolean(e.State & DrawItemState.Selected))
            {
                FillBrush.Color = Color.DodgerBlue;
                TextBrush.Color = Color.White;
                ItemRect.Inflate(2, 2);
            }

            //Configura a rotação para as guias alinhadas à esquerda e à direita
            if (tc_cadastromultiplos.Alignment == TabAlignment.Left || tc_cadastromultiplos.Alignment == TabAlignment.Right)
            {
                float RotateAngle = 90;
                if (tc_cadastromultiplos.Alignment == TabAlignment.Left)
                    RotateAngle = 270;
                PointF cp = new PointF(ItemRect.Left + (ItemRect.Width / 2), ItemRect.Top + (ItemRect.Height / 2));
                e.Graphics.TranslateTransform(cp.X, cp.Y);
                e.Graphics.RotateTransform(RotateAngle);
                ItemRect = new Rectangle(-(ItemRect.Height / 2), -(ItemRect.Width / 2), ItemRect.Height, ItemRect.Width);
            }

            // Em seguida vamos pintar o TabItem com nosso pincel de preenchimento
            e.Graphics.FillRectangle(FillBrush, ItemRect);

            //Agora desenhe o texto.
            e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, (RectangleF)ItemRect, sf);

            //Reinicia qualquer rotação de gráficos
            e.Graphics.ResetTransform();

            //Finalmente, devemos descartar nossos pincéis.
            FillBrush.Dispose();
            TextBrush.Dispose();

            #endregion
        }

        private void FrmCadastroMultiplosRelatorios_Load(object sender, EventArgs e)
        {
            #region 'CARREGA TUDO'
            // TODO: esta linha de código carrega dados na tabela 'sigrassystembdDataSet.tb_cadastromultiplo'. 
            // Você pode movê-la ou removê-la conforme necessário.
            this.tb_cadastromultiploTableAdapter.Fill(this.sigrassystembdDataSet.tb_cadastromultiplo);
            this.RVcadastromultiplosbd.RefreshReport();
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipocadastrotipopessoa.Text = "";
            txt_tipocadastrotipopessoastatus.Text = "";
            txt_tipopessoastatustipocadastro.Text = "";
            txt_cpf.Text = "";
            txt_cnpj.Text = "";
            txt_nomerazaosocial.Text = "";
            txt_nomefantasiaapelido.Text = "";
            #endregion

            #region "AUTO COMPLETA AS TEXTBOX"
            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX STATUS'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "Select Status from tb_cadastromultiplo order by Status";
            cmd.ExecuteNonQuery();
            MySqlDataReader datareader;
            datareader = cmd.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

            while (datareader.Read())
            {
                autotext.Add(datareader.GetString(0));
            }
            txt_statustipocadastrotipopessoa.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_statustipocadastrotipopessoa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_statustipocadastrotipopessoa.AutoCompleteCustomSource = autotext;
            cmd.Connection.Close(); //Fecha a conexão 
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX TIPO CADASTRO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd1.CommandText = "Select TipoCadastro from tb_cadastromultiplo order by TipoCadastro";
            cmd1.ExecuteNonQuery();
            MySqlDataReader datareader1;
            datareader1 = cmd1.ExecuteReader();
            AutoCompleteStringCollection autotext1 = new AutoCompleteStringCollection();

            while (datareader1.Read())
            {
                autotext1.Add(datareader1.GetString(0));
            }
            txt_tipocadastrotipopessoastatus.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_tipocadastrotipopessoastatus.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_tipocadastrotipopessoastatus.AutoCompleteCustomSource = autotext1;
            cmd1.Connection.Close(); //Fecha a conexão 
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX TIPO PESSOA'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd2.CommandText = "Select TipoPessoa from tb_cadastromultiplo order by TipoPessoa";
            cmd2.ExecuteNonQuery();
            MySqlDataReader datareader2;
            datareader2 = cmd2.ExecuteReader();
            AutoCompleteStringCollection autotext2 = new AutoCompleteStringCollection();

            while (datareader2.Read())
            {
                autotext2.Add(datareader2.GetString(0));
            }
            txt_tipopessoastatustipocadastro.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_tipopessoastatustipocadastro.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_tipopessoastatustipocadastro.AutoCompleteCustomSource = autotext2;
            cmd2.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX CPF'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd3 = new MySqlCommand();
            cmd3.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd3.CommandText = "Select Cpf from tb_cadastromultiplo order by Cpf";
            cmd3.ExecuteNonQuery();
            MySqlDataReader datareader3;
            datareader3 = cmd3.ExecuteReader();
            AutoCompleteStringCollection autotext3 = new AutoCompleteStringCollection();

            while (datareader3.Read())
            {
                autotext3.Add(datareader3.GetString(0));
            }
            txt_cpf.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_cpf.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_cpf.AutoCompleteCustomSource = autotext3;
            cmd3.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX CNPJ'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd4 = new MySqlCommand();
            cmd4.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd4.CommandText = "Select Cnpj from tb_cadastromultiplo order by Cnpj";
            cmd4.ExecuteNonQuery();
            MySqlDataReader datareader4;
            datareader4 = cmd4.ExecuteReader();
            AutoCompleteStringCollection autotext4 = new AutoCompleteStringCollection();

            while (datareader4.Read())
            {
                autotext4.Add(datareader4.GetString(0));
            }
            txt_cnpj.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_cnpj.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_cnpj.AutoCompleteCustomSource = autotext4;
            cmd4.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX NOME/RAZÃO SOCIAL'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd5 = new MySqlCommand();
            cmd5.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd5.CommandText = "Select NomeRazaoSocial from tb_cadastromultiplo order by NomeRazaoSocial";
            cmd5.ExecuteNonQuery();
            MySqlDataReader datareader5;
            datareader5 = cmd5.ExecuteReader();
            AutoCompleteStringCollection autotext5 = new AutoCompleteStringCollection();

            while (datareader5.Read())
            {
                autotext5.Add(datareader5.GetString(0));
            }
            txt_nomerazaosocial.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_nomerazaosocial.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_nomerazaosocial.AutoCompleteCustomSource = autotext5;
            cmd5.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX NOME FANTASIA/APELIDO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd6 = new MySqlCommand();
            cmd6.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd6.CommandText = "Select NomeFantasiaApelido from tb_cadastromultiplo order by NomeFantasiaApelido";
            cmd6.ExecuteNonQuery();
            MySqlDataReader datareader6;
            datareader6 = cmd6.ExecuteReader();
            AutoCompleteStringCollection autotext6 = new AutoCompleteStringCollection();

            while (datareader6.Read())
            {
                autotext6.Add(datareader6.GetString(0));
            }
            txt_nomefantasiaapelido.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_nomefantasiaapelido.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_nomefantasiaapelido.AutoCompleteCustomSource = autotext6;
            cmd6.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX STATUS'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd7 = new MySqlCommand();
            cmd7.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd7.CommandText = "Select Status from tb_cadastromultiplo order by Status";
            cmd7.ExecuteNonQuery();
            MySqlDataReader datareader7;
            datareader7 = cmd7.ExecuteReader();
            AutoCompleteStringCollection autotext7 = new AutoCompleteStringCollection();

            while (datareader7.Read())
            {
                autotext7.Add(datareader7.GetString(0));
            }
            txt_status.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_status.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_status.AutoCompleteCustomSource = autotext7;
            cmd7.Connection.Close(); //Fecha a conexão 
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////
            
            #endregion
        }

        private void btStatus_Click(object sender, EventArgs e)
        {
            #region "CARREGA O STATUS"
            if (txt_status.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_status.Text = "";
                txt_statustipocadastrotipopessoa.Text = "";
                txt_tipocadastrotipopessoastatus.Text = "";
                txt_tipopessoastatustipocadastro.Text = "";
                txt_cpf.Text = "";
                txt_cnpj.Text = "";
                txt_nomerazaosocial.Text = "";
                txt_nomefantasiaapelido.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_status.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O STATUS"
                try
                {
                    this.tb_cadastromultiploTableAdapter.FillBy01Status(this.sigrassystembdDataSet.tb_cadastromultiplo, txt_status.Text);
                    this.RVcadastromultiplosbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipocadastrotipopessoa.Text = "";
            txt_tipocadastrotipopessoastatus.Text = "";
            txt_tipopessoastatustipocadastro.Text = "";
            txt_cpf.Text = "";
            txt_cnpj.Text = "";
            txt_nomerazaosocial.Text = "";
            txt_nomefantasiaapelido.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_status.Focus();
            #endregion
        }

        private void btStatusTipocadastropessoa_Click(object sender, EventArgs e)
        {
            #region "CARREGA O STATUS, TIPO CADASTRO E TIPO PESSOA"
            if (txt_statustipocadastrotipopessoa.Text == "" || txt_tipocadastrotipopessoastatus.Text == "" || txt_tipopessoastatustipocadastro.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_status.Text = "";
                txt_statustipocadastrotipopessoa.Text = "";
                txt_tipocadastrotipopessoastatus.Text = "";
                txt_tipopessoastatustipocadastro.Text = "";
                txt_cpf.Text = "";
                txt_cnpj.Text = "";
                txt_nomerazaosocial.Text = "";
                txt_nomefantasiaapelido.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_statustipocadastrotipopessoa.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O STATUS, TIPO CADASTRO E TIPO PESSOA"
                try
                {
                    this.tb_cadastromultiploTableAdapter.FillBy02StatusTipoCadastroTipoPessoa(this.sigrassystembdDataSet.tb_cadastromultiplo, txt_statustipocadastrotipopessoa.Text, txt_tipocadastrotipopessoastatus.Text, txt_tipopessoastatustipocadastro.Text);
                    this.RVcadastromultiplosbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipocadastrotipopessoa.Text = "";
            txt_tipocadastrotipopessoastatus.Text = "";
            txt_tipopessoastatustipocadastro.Text = "";
            txt_cpf.Text = "";
            txt_cnpj.Text = "";
            txt_nomerazaosocial.Text = "";
            txt_nomefantasiaapelido.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_statustipocadastrotipopessoa.Focus();
            #endregion
        }

        private void btCpf_Click(object sender, EventArgs e)
        {
            #region "CARREGA O CPF"
            if (txt_cpf.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_status.Text = "";
                txt_statustipocadastrotipopessoa.Text = "";
                txt_tipocadastrotipopessoastatus.Text = "";
                txt_tipopessoastatustipocadastro.Text = "";
                txt_cpf.Text = "";
                txt_cnpj.Text = "";
                txt_nomerazaosocial.Text = "";
                txt_nomefantasiaapelido.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_cpf.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O CPF"
                try
                {
                    this.tb_cadastromultiploTableAdapter.FillBy03Cpf(this.sigrassystembdDataSet.tb_cadastromultiplo, txt_cpf.Text);
                    this.RVcadastromultiplosbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipocadastrotipopessoa.Text = "";
            txt_tipocadastrotipopessoastatus.Text = "";
            txt_tipopessoastatustipocadastro.Text = "";
            txt_cpf.Text = "";
            txt_cnpj.Text = "";
            txt_nomerazaosocial.Text = "";
            txt_nomefantasiaapelido.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_cpf.Focus();
            #endregion
        }

        private void btCnpj_Click(object sender, EventArgs e)
        {
            #region "CARREGA O CNPJ"
            if (txt_cnpj.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_status.Text = "";
                txt_statustipocadastrotipopessoa.Text = "";
                txt_tipocadastrotipopessoastatus.Text = "";
                txt_tipopessoastatustipocadastro.Text = "";
                txt_cpf.Text = "";
                txt_cnpj.Text = "";
                txt_nomerazaosocial.Text = "";
                txt_nomefantasiaapelido.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_cnpj.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O CNPJ"
                try
                {
                    this.tb_cadastromultiploTableAdapter.FillBy04Cnpj(this.sigrassystembdDataSet.tb_cadastromultiplo, txt_cnpj.Text);
                    this.RVcadastromultiplosbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipocadastrotipopessoa.Text = "";
            txt_tipocadastrotipopessoastatus.Text = "";
            txt_tipopessoastatustipocadastro.Text = "";
            txt_cpf.Text = "";
            txt_cnpj.Text = "";
            txt_nomerazaosocial.Text = "";
            txt_nomefantasiaapelido.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_cnpj.Focus();
            #endregion
        }

        private void btNomeRazao_Click(object sender, EventArgs e)
        {
            #region "CARREGA O NOME/RAZAO SOCIAL"
            if (txt_nomerazaosocial.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_status.Text = "";
                txt_statustipocadastrotipopessoa.Text = "";
                txt_tipocadastrotipopessoastatus.Text = "";
                txt_tipopessoastatustipocadastro.Text = "";
                txt_cpf.Text = "";
                txt_cnpj.Text = "";
                txt_nomerazaosocial.Text = "";
                txt_nomefantasiaapelido.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_nomerazaosocial.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O NOME/RAZÃO SOCIAL"
                try
                {
                    this.tb_cadastromultiploTableAdapter.FillBy05NomeRazaoSocial(this.sigrassystembdDataSet.tb_cadastromultiplo, txt_nomerazaosocial.Text);
                    this.RVcadastromultiplosbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipocadastrotipopessoa.Text = "";
            txt_tipocadastrotipopessoastatus.Text = "";
            txt_tipopessoastatustipocadastro.Text = "";
            txt_cpf.Text = "";
            txt_cnpj.Text = "";
            txt_nomerazaosocial.Text = "";
            txt_nomefantasiaapelido.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_nomerazaosocial.Focus();
            #endregion
        }

        private void btNomeFantasiaApelido_Click(object sender, EventArgs e)
        {
            #region "CARREGA O NOME FANTASIA/APELIDO"
            if (txt_nomefantasiaapelido.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_status.Text = "";
                txt_statustipocadastrotipopessoa.Text = "";
                txt_tipocadastrotipopessoastatus.Text = "";
                txt_tipopessoastatustipocadastro.Text = "";
                txt_cpf.Text = "";
                txt_cnpj.Text = "";
                txt_nomerazaosocial.Text = "";
                txt_nomefantasiaapelido.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_nomefantasiaapelido.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O NOME FANTASIA/APELIDO"
                try
                {
                    this.tb_cadastromultiploTableAdapter.FillBy06NomeFantasiaApelido(this.sigrassystembdDataSet.tb_cadastromultiplo, txt_nomefantasiaapelido.Text);
                    this.RVcadastromultiplosbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipocadastrotipopessoa.Text = "";
            txt_tipocadastrotipopessoastatus.Text = "";
            txt_tipopessoastatustipocadastro.Text = "";
            txt_cpf.Text = "";
            txt_cnpj.Text = "";
            txt_nomerazaosocial.Text = "";
            txt_nomefantasiaapelido.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_nomefantasiaapelido.Focus();
            #endregion
        }

        private void btn_carregartudo_Click(object sender, EventArgs e)
        {
            #region 'CARREGA TUDO'
            // TODO: esta linha de código carrega dados na tabela 'sigrassystembdDataSet.tb_cadastromultiplo'. 
            // Você pode movê-la ou removê-la conforme necessário.
            this.tb_cadastromultiploTableAdapter.Fill(this.sigrassystembdDataSet.tb_cadastromultiplo);
            this.RVcadastromultiplosbd.RefreshReport();
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipocadastrotipopessoa.Text = "";
            txt_tipocadastrotipopessoastatus.Text = "";
            txt_tipopessoastatustipocadastro.Text = "";
            txt_cpf.Text = "";
            txt_cnpj.Text = "";
            txt_nomerazaosocial.Text = "";
            txt_nomefantasiaapelido.Text = "";
            #endregion
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            #region 'ENCERRA A APLICAÇÃO'
            //FECHA O FORMULÁRIO COM MENSAGEM
            DialogResult dlgResult = MessageBox.Show("Deseja sair da tela ?", "Encerrar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                this.Hide();
                FrmCadastroMultiplos frm = new FrmCadastroMultiplos();
                frm.ShowDialog();
                //this.Close();
            }
            #endregion
        }

        private void txt_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_statustipocadastrotipopessoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_tipocadastrotipopessoastatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_tipopessoastatustipocadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_cpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_cnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }
    }
}
