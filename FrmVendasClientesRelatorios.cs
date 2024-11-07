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
    public partial class FrmVendasClientesRelatorios : Form
    {
        public FrmVendasClientesRelatorios()
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

        private void FrmVendasClientesRelatorios_KeyDown(object sender, KeyEventArgs e)
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

        private void tc_vendasclientes_DrawItem(object sender, DrawItemEventArgs e)
        {
            #region 'MUDA A COR DA GUIA AO CLICAR'

            //FORMATAÇÃO DA TABCONTROL'
            TabPage CurrentTab = tc_vendasclientes.TabPages[e.Index];
            Rectangle ItemRect = tc_vendasclientes.GetTabRect(e.Index);
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
            if (tc_vendasclientes.Alignment == TabAlignment.Left || tc_vendasclientes.Alignment == TabAlignment.Right)
            {
                float RotateAngle = 90;
                if (tc_vendasclientes.Alignment == TabAlignment.Left)
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

        private void FrmVendasClientesRelatorios_Load(object sender, EventArgs e)
        {
            #region 'CARREGA TUDO'
            // TODO: esta linha de código carrega dados na tabela 'sigrassystembdDataSet.tb_vendasclientes'. 
            // Você pode movê-la ou removê-la conforme necessário.
            this.tb_vendasclientesTableAdapter.Fill(this.sigrassystembdDataSet.tb_vendasclientes);
            this.RVvendasclientesbd.RefreshReport();
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "AUTO COMPLETA AS TEXTBOX"
            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX ANO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "Select Ano from tb_vendasclientes order by Ano";
            cmd.ExecuteNonQuery();
            MySqlDataReader datareader;
            datareader = cmd.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

            while (datareader.Read())
            {
                autotext.Add(datareader.GetString(0));
            }
            txt_ano.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_ano.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_ano.AutoCompleteCustomSource = autotext;
            cmd.Connection.Close(); //Fecha a conexão 
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX MES'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd1.CommandText = "Select Mes from tb_vendasclientes order by Mes";
            cmd1.ExecuteNonQuery();
            MySqlDataReader datareader1;
            datareader1 = cmd1.ExecuteReader();
            AutoCompleteStringCollection autotext1 = new AutoCompleteStringCollection();

            while (datareader1.Read())
            {
                autotext1.Add(datareader1.GetString(0));
            }
            txt_mes.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_mes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_mes.AutoCompleteCustomSource = autotext1;
            cmd1.Connection.Close(); //Fecha a conexão 
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX ANO MES'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd2.CommandText = "Select Ano from tb_vendasclientes order by Ano";
            cmd2.ExecuteNonQuery();
            MySqlDataReader datareader2;
            datareader2 = cmd2.ExecuteReader();
            AutoCompleteStringCollection autotext2 = new AutoCompleteStringCollection();

            while (datareader2.Read())
            {
                autotext2.Add(datareader2.GetString(0));
            }
            txt_anomes.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_anomes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_anomes.AutoCompleteCustomSource = autotext2;
            cmd2.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX MES ANO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd3 = new MySqlCommand();
            cmd3.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd3.CommandText = "Select Mes from tb_vendasclientes order by Mes";
            cmd3.ExecuteNonQuery();
            MySqlDataReader datareader3;
            datareader3 = cmd3.ExecuteReader();
            AutoCompleteStringCollection autotext3 = new AutoCompleteStringCollection();

            while (datareader3.Read())
            {
                autotext3.Add(datareader3.GetString(0));
            }
            txt_mesano.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_mesano.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_mesano.AutoCompleteCustomSource = autotext3;
            cmd3.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX SITUAÇÃO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd4 = new MySqlCommand();
            cmd4.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd4.CommandText = "Select Situacao from tb_vendasclientes order by Situacao";
            cmd4.ExecuteNonQuery();
            MySqlDataReader datareader4;
            datareader4 = cmd4.ExecuteReader();
            AutoCompleteStringCollection autotext4 = new AutoCompleteStringCollection();

            while (datareader4.Read())
            {
                autotext4.Add(datareader4.GetString(0));
            }
            txt_situacao.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_situacao.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_situacao.AutoCompleteCustomSource = autotext4;
            cmd4.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX TIPO ATIVIDADE'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd5 = new MySqlCommand();
            cmd5.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd5.CommandText = "Select TipoAtividade from tb_vendasclientes order by TipoAtividade";
            cmd5.ExecuteNonQuery();
            MySqlDataReader datareader5;
            datareader5 = cmd5.ExecuteReader();
            AutoCompleteStringCollection autotext5 = new AutoCompleteStringCollection();

            while (datareader5.Read())
            {
                autotext5.Add(datareader5.GetString(0));
            }
            txt_tipoatividade.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_tipoatividade.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_tipoatividade.AutoCompleteCustomSource = autotext5;
            cmd5.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX ESPECIE'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd6 = new MySqlCommand();
            cmd6.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd6.CommandText = "Select Especie from tb_vendasclientes order by Especie";
            cmd6.ExecuteNonQuery();
            MySqlDataReader datareader6;
            datareader6 = cmd6.ExecuteReader();
            AutoCompleteStringCollection autotext6 = new AutoCompleteStringCollection();

            while (datareader6.Read())
            {
                autotext6.Add(datareader6.GetString(0));
            }
            txt_especie.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_especie.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_especie.AutoCompleteCustomSource = autotext6;
            cmd6.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX ESPECIE, ANO E MES'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd7 = new MySqlCommand();
            cmd7.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd7.CommandText = "Select Especie from tb_vendasclientes order by Especie";
            cmd7.ExecuteNonQuery();
            MySqlDataReader datareader7;
            datareader7 = cmd7.ExecuteReader();
            AutoCompleteStringCollection autotext7 = new AutoCompleteStringCollection();

            while (datareader7.Read())
            {
                autotext7.Add(datareader7.GetString(0));
            }
            txt_especieanomes.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_especieanomes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_especieanomes.AutoCompleteCustomSource = autotext7;
            cmd7.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////
                        
            #region 'AUTOCOMPLETE TEXTBOX ANO, MES E ESPECIE'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd8 = new MySqlCommand();
            cmd8.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd8.CommandText = "Select Ano from tb_vendasclientes order by Ano";
            cmd8.ExecuteNonQuery();
            MySqlDataReader datareader8;
            datareader8 = cmd8.ExecuteReader();
            AutoCompleteStringCollection autotext8 = new AutoCompleteStringCollection();

            while (datareader8.Read())
            {
                autotext8.Add(datareader8.GetString(0));
            }
            txt_anomesespecie.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_anomesespecie.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_anomesespecie.AutoCompleteCustomSource = autotext8;
            cmd8.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX MES, ESPECIE E ANO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd9 = new MySqlCommand();
            cmd9.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd9.CommandText = "Select Mes from tb_vendasclientes order by Mes";
            cmd9.ExecuteNonQuery();
            MySqlDataReader datareader9;
            datareader9 = cmd9.ExecuteReader();
            AutoCompleteStringCollection autotext9 = new AutoCompleteStringCollection();

            while (datareader9.Read())
            {
                autotext9.Add(datareader9.GetString(0));
            }
            txt_mesespecieano.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_mesespecieano.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_mesespecieano.AutoCompleteCustomSource = autotext9;
            cmd9.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX CPF/CNPJ'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd10 = new MySqlCommand();
            cmd10.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd10.CommandText = "Select CpfCnpj from tb_vendasclientes order by CpfCnpj";
            cmd10.ExecuteNonQuery();
            MySqlDataReader datareader10;
            datareader10 = cmd10.ExecuteReader();
            AutoCompleteStringCollection autotext10 = new AutoCompleteStringCollection();

            while (datareader10.Read())
            {
                autotext10.Add(datareader10.GetString(0));
            }
            txt_cpfcnpj.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_cpfcnpj.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_cpfcnpj.AutoCompleteCustomSource = autotext10;
            cmd10.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX NOME CLIENTE'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd11 = new MySqlCommand();
            cmd11.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd11.CommandText = "Select NomeCliente from tb_vendasclientes order by NomeCliente";
            cmd11.ExecuteNonQuery();
            MySqlDataReader datareader11;
            datareader11 = cmd11.ExecuteReader();
            AutoCompleteStringCollection autotext11 = new AutoCompleteStringCollection();

            while (datareader11.Read())
            {
                autotext11.Add(datareader11.GetString(0));
            }
            txt_descricao.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_descricao.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_descricao.AutoCompleteCustomSource = autotext11;
            cmd11.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX NOME CLIENTE, ANO E MES'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd12 = new MySqlCommand();
            cmd12.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd12.CommandText = "Select NomeCliente from tb_vendasclientes order by NomeCliente";
            cmd12.ExecuteNonQuery();
            MySqlDataReader datareader12;
            datareader12 = cmd12.ExecuteReader();
            AutoCompleteStringCollection autotext12 = new AutoCompleteStringCollection();

            while (datareader12.Read())
            {
                autotext12.Add(datareader12.GetString(0));
            }
            txt_descricaoanomes.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_descricaoanomes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_descricaoanomes.AutoCompleteCustomSource = autotext12;
            cmd12.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX ANO, MES E NOME CLIENTE'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd13 = new MySqlCommand();
            cmd13.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd13.CommandText = "Select Ano from tb_vendasclientes order by Ano";
            cmd13.ExecuteNonQuery();
            MySqlDataReader datareader13;
            datareader13 = cmd13.ExecuteReader();
            AutoCompleteStringCollection autotext13 = new AutoCompleteStringCollection();

            while (datareader13.Read())
            {
                autotext13.Add(datareader13.GetString(0));
            }
            txt_anomesdescricao.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_anomesdescricao.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_anomesdescricao.AutoCompleteCustomSource = autotext13;
            cmd13.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX MES, NOME CLIENTE E ANO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd14 = new MySqlCommand();
            cmd14.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd14.CommandText = "Select Mes from tb_vendasclientes order by Mes";
            cmd14.ExecuteNonQuery();
            MySqlDataReader datareader14;
            datareader14 = cmd14.ExecuteReader();
            AutoCompleteStringCollection autotext14 = new AutoCompleteStringCollection();

            while (datareader14.Read())
            {
                autotext14.Add(datareader14.GetString(0));
            }
            txt_mesdescricaoano.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_mesdescricaoano.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_mesdescricaoano.AutoCompleteCustomSource = autotext14;
            cmd14.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #endregion
        }

        private void btAno_Click(object sender, EventArgs e)
        {
            #region "CARREGA O ANO"
            if (txt_ano.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_ano.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O ANO"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy01Ano(this.sigrassystembdDataSet.tb_vendasclientes, Convert.ToInt32(txt_ano.Text));
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_ano.Focus();
            #endregion
        }

        private void btMes_Click(object sender, EventArgs e)
        {
            #region "CARREGA O MÊS"
            if (txt_mes.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_mes.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O MES"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy02Mes(this.sigrassystembdDataSet.tb_vendasclientes, txt_mes.Text);
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_mes.Focus();
            #endregion
        }

        private void btAnoMes_Click(object sender, EventArgs e)
        {
            #region "CARREGA O MÊS COM O ANO"
            if (txt_anomes.Text == "" || txt_mesano.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_anomes.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O MES COM O ANO"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy03AnoMes(this.sigrassystembdDataSet.tb_vendasclientes, Convert.ToInt32(txt_anomes.Text), txt_mesano.Text);
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_anomes.Focus();
            #endregion
        }

        private void btSituacao_Click(object sender, EventArgs e)
        {
            #region "CARREGA A SITUAÇÃO"
            if (txt_situacao.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_situacao.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA A SITUAÇÃO"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy04Situacao(this.sigrassystembdDataSet.tb_vendasclientes, txt_situacao.Text);
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_situacao.Focus();
            #endregion
        }

        private void btn_tipoatividade_Click(object sender, EventArgs e)
        {
            #region "CARREGA O TIPO ATIVIDADE"
            if (txt_tipoatividade.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_tipoatividade.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O TIPO ATIVIDADE"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy05TipoAtividade(this.sigrassystembdDataSet.tb_vendasclientes, txt_tipoatividade.Text);
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_tipoatividade.Focus();
            #endregion
        }

        private void btDataCredito_Click(object sender, EventArgs e)
        {
            #region "CARREGA A DATA CRÉDITO"
            if (!txtmsk_datacredito.MaskCompleted)
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txtmsk_datacredito.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA A DATA CRÉDITO"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy06DataCredito(this.sigrassystembdDataSet.tb_vendasclientes, Convert.ToDateTime(txtmsk_datacredito.Text));
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txtmsk_datacredito.Focus();
            #endregion
        }

        private void btDataInicioFimCredito_Click(object sender, EventArgs e)
        {
            #region "CARREGA A DATAINICIOFIM CRÉDITO E DATAFIMINICIO CRÉDITO"
            if (!txtmsk_datainiciofimcredito.MaskCompleted || !txtmsk_datafiminiciocredito.MaskCompleted)
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txtmsk_datainiciofimcredito.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA A DATAINICIOFIM CRÉDITO E DATAFIMINICIO CRÉDITO"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy07DataCreditoInicioFim(this.sigrassystembdDataSet.tb_vendasclientes, Convert.ToDateTime(txtmsk_datainiciofimcredito.Text), Convert.ToDateTime(txtmsk_datafiminiciocredito.Text));
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txtmsk_datainiciofimcredito.Focus();
            #endregion
        }

        private void btDataDebito_Click(object sender, EventArgs e)
        {
            #region "CARREGA A DATA DÉBITO"
            if (!txtmsk_datadebito.MaskCompleted)
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txtmsk_datadebito.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA A DATA DÉBITO"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy08DataDebito(this.sigrassystembdDataSet.tb_vendasclientes, Convert.ToDateTime(txtmsk_datadebito.Text));
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txtmsk_datadebito.Focus();
            #endregion
        }

        private void btDataInicioFimDebito_Click(object sender, EventArgs e)
        {
            #region "CARREGA A DATAINICIOFIM DÉBITO E DATAFIMINICIO DÉBITO"
            if (!txtmsk_datainiciofimdebito.MaskCompleted || !txtmsk_datafiminiciodebito.MaskCompleted)
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txtmsk_datainiciofimdebito.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA A DATAINICIOFIM DÉBITO E DATAFIMINICIO DÉBITO"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy09DataDebitoInicioFim(this.sigrassystembdDataSet.tb_vendasclientes, Convert.ToDateTime(txtmsk_datainiciofimdebito.Text), Convert.ToDateTime(txtmsk_datafiminiciodebito.Text));
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txtmsk_datainiciofimdebito.Focus();
            #endregion
        }

        private void btEspecie_Click(object sender, EventArgs e)
        {
            #region "CARREGA A ESPÉCIE"
            if (txt_especie.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_especie.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA A ESPÉCIE"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy10Especie(this.sigrassystembdDataSet.tb_vendasclientes, txt_especie.Text);
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_especie.Focus();
            #endregion
        }

        private void btEspecieAnoMes_Click(object sender, EventArgs e)
        {
            #region "CARREGA A ESPÉCIE, ANO E MÊS"
            if (txt_especieanomes.Text == "" || txt_anomesespecie.Text == "" || txt_mesespecieano.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_especieanomes.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA A ESPÉCIE, ANO E MÊS"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy11EspecieAnoMes(this.sigrassystembdDataSet.tb_vendasclientes, txt_especieanomes.Text, Convert.ToInt32(txt_anomesespecie.Text), txt_mesespecieano.Text);
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_especieanomes.Focus();
            #endregion
        }

        private void btCpfCnpj_Click(object sender, EventArgs e)
        {
            #region "CARREGA O CPF E CNPJ"
            if (txt_cpfcnpj.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_cpfcnpj.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O CPF E CNPJ"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy12CpfCnpj(this.sigrassystembdDataSet.tb_vendasclientes, txt_cpfcnpj.Text);
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_cpfcnpj.Focus();
            #endregion
        }

        private void btDescricao_Click(object sender, EventArgs e)
        {
            #region "CARREGA A DESCRIÇÃO"
            if (txt_descricao.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_descricao.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA A DESCRIÇÃO"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy13NomeCliente(this.sigrassystembdDataSet.tb_vendasclientes, txt_descricao.Text);
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_descricao.Focus();
            #endregion
        }

        private void btDescricaoAnoMes_Click(object sender, EventArgs e)
        {
            #region "CARREGA A DESCRIÇÃO, ANO E MÊS"
            if (txt_descricaoanomes.Text == "" || txt_anomesdescricao.Text == "" || txt_mesdescricaoano.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_anomes.Text = "";
                txt_mesano.Text = "";
                txt_situacao.Text = "";
                txt_tipoatividade.Text = "";
                txtmsk_datacredito.Text = "";
                txtmsk_datainiciofimcredito.Text = "";
                txtmsk_datafiminiciocredito.Text = "";
                txtmsk_datadebito.Text = "";
                txtmsk_datainiciofimdebito.Text = "";
                txtmsk_datafiminiciodebito.Text = "";
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                txt_cpfcnpj.Text = "";
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_descricaoanomes.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA A DESCRIÇÃO, ANO E MÊS"
                try
                {
                    this.tb_vendasclientesTableAdapter.FillBy14NomeClienteAnoMes(this.sigrassystembdDataSet.tb_vendasclientes, txt_descricaoanomes.Text, Convert.ToInt32(txt_anomesdescricao.Text), txt_mesdescricaoano.Text);
                    this.RVvendasclientesbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_descricaoanomes.Focus();
            #endregion
        }

        private void btn_carregartudo_Click(object sender, EventArgs e)
        {
            #region 'CARREGA TUDO'
            // TODO: esta linha de código carrega dados na tabela 'sigrassystembdDataSet.tb_vendasclientes'. 
            // Você pode movê-la ou removê-la conforme necessário.
            this.tb_vendasclientesTableAdapter.Fill(this.sigrassystembdDataSet.tb_vendasclientes);
            this.RVvendasclientesbd.RefreshReport();
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_anomes.Text = "";
            txt_mesano.Text = "";
            txt_situacao.Text = "";
            txt_tipoatividade.Text = "";
            txtmsk_datacredito.Text = "";
            txtmsk_datainiciofimcredito.Text = "";
            txtmsk_datafiminiciocredito.Text = "";
            txtmsk_datadebito.Text = "";
            txtmsk_datainiciofimdebito.Text = "";
            txtmsk_datafiminiciodebito.Text = "";
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            txt_cpfcnpj.Text = "";
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
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
                FrmVendasClientes frm = new FrmVendasClientes();
                frm.ShowDialog();
                //this.Close();
            }
            #endregion
        }

        private void txt_ano_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_anomes_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_anomesespecie_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_cpfcnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_anomesdescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_mes_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_mesano_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_mesespecieano_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_mesdescricaoano_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }
    }
}
