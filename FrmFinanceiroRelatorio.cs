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
    public partial class FrmFinanceiroRelatorio : Form
    {
        public FrmFinanceiroRelatorio()
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

        private void FrmFinanceiroRelatorio_KeyDown(object sender, KeyEventArgs e)
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

        private void tc_financeiros_DrawItem(object sender, DrawItemEventArgs e)
        {
            #region 'MUDA A COR DA GUIA AO CLICAR'

            //FORMATAÇÃO DA TABCONTROL'
            TabPage CurrentTab = tc_financeiros.TabPages[e.Index];
            Rectangle ItemRect = tc_financeiros.GetTabRect(e.Index);
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
            if (tc_financeiros.Alignment == TabAlignment.Left || tc_financeiros.Alignment == TabAlignment.Right)
            {
                float RotateAngle = 90;
                if (tc_financeiros.Alignment == TabAlignment.Left)
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

        private void FrmFinanceiroRelatorio_Load(object sender, EventArgs e)
        {
            #region 'CARREGA TUDO'
            // TODO: esta linha de código carrega dados na tabela 'sigrassystembdDataSet.tb_vendasclientes'. 
            // Você pode movê-la ou removê-la conforme necessário.
            this.tb_financeiroTableAdapter.Fill(this.sigrassystembdDataSet.tb_financeiro);
            this.RVfinanceirobd.RefreshReport();
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "AUTO COMPLETA AS TEXTBOX"
            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX MES'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "Select Mes from tb_financeiro order by Mes";
            cmd.ExecuteNonQuery();
            MySqlDataReader datareader;
            datareader = cmd.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

            while (datareader.Read())
            {
                autotext.Add(datareader.GetString(0));
            }
            txt_mes.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_mes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_mes.AutoCompleteCustomSource = autotext;
            cmd.Connection.Close(); //Fecha a conexão 
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX MES ANO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd1.CommandText = "Select Mes from tb_financeiro order by Mes";
            cmd1.ExecuteNonQuery();
            MySqlDataReader datareader1;
            datareader1 = cmd1.ExecuteReader();
            AutoCompleteStringCollection autotext1 = new AutoCompleteStringCollection();

            while (datareader1.Read())
            {
                autotext1.Add(datareader1.GetString(0));
            }
            txt_mesano.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_mesano.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_mesano.AutoCompleteCustomSource = autotext1;
            cmd1.Connection.Close(); //Fecha a conexão 
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX ANO MES'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd2.CommandText = "Select Ano from tb_financeiro order by Ano";
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

            #region 'AUTOCOMPLETE TEXTBOX ANO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd3 = new MySqlCommand();
            cmd3.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd3.CommandText = "Select Ano from tb_financeiro order by Ano";
            cmd3.ExecuteNonQuery();
            MySqlDataReader datareader3;
            datareader3 = cmd3.ExecuteReader();
            AutoCompleteStringCollection autotext3 = new AutoCompleteStringCollection();

            while (datareader3.Read())
            {
                autotext3.Add(datareader3.GetString(0));
            }
            txt_ano.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_ano.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_ano.AutoCompleteCustomSource = autotext3;
            cmd3.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX TIPO LANÇAMENTO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd4 = new MySqlCommand();
            cmd4.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd4.CommandText = "Select TipoLancamento from tb_financeiro order by TipoLancamento";
            cmd4.ExecuteNonQuery();
            MySqlDataReader datareader4;
            datareader4 = cmd4.ExecuteReader();
            AutoCompleteStringCollection autotext4 = new AutoCompleteStringCollection();

            while (datareader4.Read())
            {
                autotext4.Add(datareader4.GetString(0));
            }
            txt_tipolancamento.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_tipolancamento.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_tipolancamento.AutoCompleteCustomSource = autotext4;
            cmd4.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX DESTINO LANÇAMENTO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd5 = new MySqlCommand();
            cmd5.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd5.CommandText = "Select DestinoLancamento from tb_financeiro order by DestinoLancamento";
            cmd5.ExecuteNonQuery();
            MySqlDataReader datareader5;
            datareader5 = cmd5.ExecuteReader();
            AutoCompleteStringCollection autotext5 = new AutoCompleteStringCollection();

            while (datareader5.Read())
            {
                autotext5.Add(datareader5.GetString(0));
            }
            txt_destino.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_destino.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_destino.AutoCompleteCustomSource = autotext5;
            cmd5.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX DESTINO MES'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd6 = new MySqlCommand();
            cmd6.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd6.CommandText = "Select DestinoLancamento from tb_financeiro order by DestinoLancamento";
            cmd6.ExecuteNonQuery();
            MySqlDataReader datareader6;
            datareader6 = cmd6.ExecuteReader();
            AutoCompleteStringCollection autotext6 = new AutoCompleteStringCollection();

            while (datareader6.Read())
            {
                autotext6.Add(datareader6.GetString(0));
            }
            txt_destinoanomes.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_destinoanomes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_destinoanomes.AutoCompleteCustomSource = autotext6;
            cmd6.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX MES DESTINO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd7 = new MySqlCommand();
            cmd7.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd7.CommandText = "Select Mes from tb_financeiro order by Mes";
            cmd7.ExecuteNonQuery();
            MySqlDataReader datareader7;
            datareader7 = cmd7.ExecuteReader();
            AutoCompleteStringCollection autotext7 = new AutoCompleteStringCollection();

            while (datareader7.Read())
            {
                autotext7.Add(datareader7.GetString(0));
            }
            txt_mesdestinoano.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_mesdestinoano.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_mesdestinoano.AutoCompleteCustomSource = autotext7;
            cmd7.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////



            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX DEPARTAMENTO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd8 = new MySqlCommand();
            cmd8.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd8.CommandText = "Select DepartamentoSetor from tb_financeiro order by DepartamentoSetor";
            cmd8.ExecuteNonQuery();
            MySqlDataReader datareader8;
            datareader8 = cmd8.ExecuteReader();
            AutoCompleteStringCollection autotext8 = new AutoCompleteStringCollection();

            while (datareader8.Read())
            {
                autotext8.Add(datareader8.GetString(0));
            }
            txt_departamento.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_departamento.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_departamento.AutoCompleteCustomSource = autotext8;
            cmd8.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX DEPARTAMENTO MES'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd9 = new MySqlCommand();
            cmd9.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd9.CommandText = "Select DepartamentoSetor from tb_financeiro order by DepartamentoSetor";
            cmd9.ExecuteNonQuery();
            MySqlDataReader datareader9;
            datareader9 = cmd9.ExecuteReader();
            AutoCompleteStringCollection autotext9 = new AutoCompleteStringCollection();

            while (datareader9.Read())
            {
                autotext9.Add(datareader9.GetString(0));
            }
            txt_departamentoanomes.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_departamentoanomes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_departamentoanomes.AutoCompleteCustomSource = autotext9;
            cmd9.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX MES DEPARTAMENTO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd10 = new MySqlCommand();
            cmd10.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd10.CommandText = "Select Mes from tb_financeiro order by Mes";
            cmd10.ExecuteNonQuery();
            MySqlDataReader datareader10;
            datareader10 = cmd10.ExecuteReader();
            AutoCompleteStringCollection autotext10 = new AutoCompleteStringCollection();

            while (datareader10.Read())
            {
                autotext10.Add(datareader10.GetString(0));
            }
            txt_mesdepartamentoano.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_mesdepartamentoano.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_mesdepartamentoano.AutoCompleteCustomSource = autotext10;
            cmd10.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////



            //////////////////////////////////////////////////////////////////////////////////////////////////
            
            #region 'AUTOCOMPLETE TEXTBOX CONTA DESTINO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd11 = new MySqlCommand();
            cmd11.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd11.CommandText = "Select ContaDestino from tb_financeiro order by ContaDestino";
            cmd11.ExecuteNonQuery();
            MySqlDataReader datareader11;
            datareader11 = cmd11.ExecuteReader();
            AutoCompleteStringCollection autotext11 = new AutoCompleteStringCollection();

            while (datareader11.Read())
            {
                autotext11.Add(datareader11.GetString(0));
            }
            txt_contadestino.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_contadestino.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_contadestino.AutoCompleteCustomSource = autotext11;
            cmd11.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX ESPECIE'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd12 = new MySqlCommand();
            cmd12.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd12.CommandText = "Select Especie from tb_financeiro order by Especie";
            cmd12.ExecuteNonQuery();
            MySqlDataReader datareader12;
            datareader12 = cmd12.ExecuteReader();
            AutoCompleteStringCollection autotext12 = new AutoCompleteStringCollection();

            while (datareader12.Read())
            {
                autotext12.Add(datareader12.GetString(0));
            }
            txt_especie.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_especie.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_especie.AutoCompleteCustomSource = autotext12;
            cmd12.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX ESPECIE MES'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd13 = new MySqlCommand();
            cmd13.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd13.CommandText = "Select Especie from tb_financeiro order by Especie";
            cmd13.ExecuteNonQuery();
            MySqlDataReader datareader13;
            datareader13 = cmd13.ExecuteReader();
            AutoCompleteStringCollection autotext13 = new AutoCompleteStringCollection();

            while (datareader13.Read())
            {
                autotext13.Add(datareader13.GetString(0));
            }
            txt_especieanomes.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_especieanomes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_especieanomes.AutoCompleteCustomSource = autotext13;
            cmd13.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX MES ESPECIE'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd14 = new MySqlCommand();
            cmd14.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd14.CommandText = "Select Mes from tb_financeiro order by Mes";
            cmd14.ExecuteNonQuery();
            MySqlDataReader datareader14;
            datareader14 = cmd14.ExecuteReader();
            AutoCompleteStringCollection autotext14 = new AutoCompleteStringCollection();

            while (datareader14.Read())
            {
                autotext14.Add(datareader14.GetString(0));
            }
            txt_mesespecieano.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_mesespecieano.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_mesespecieano.AutoCompleteCustomSource = autotext14;
            cmd14.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX DESCRIÇÃO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd15 = new MySqlCommand();
            cmd15.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd15.CommandText = "Select DescricaoLancamento from tb_financeiro order by DescricaoLancamento";
            cmd15.ExecuteNonQuery();
            MySqlDataReader datareader15;
            datareader15 = cmd15.ExecuteReader();
            AutoCompleteStringCollection autotext15 = new AutoCompleteStringCollection();

            while (datareader15.Read())
            {
                autotext15.Add(datareader15.GetString(0));
            }
            txt_descricao.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_descricao.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_descricao.AutoCompleteCustomSource = autotext15;
            cmd15.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX DESCRIÇÃO MES'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd16 = new MySqlCommand();
            cmd16.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd16.CommandText = "Select DescricaoLancamento from tb_financeiro order by DescricaoLancamento";
            cmd16.ExecuteNonQuery();
            MySqlDataReader datareader16;
            datareader16 = cmd16.ExecuteReader();
            AutoCompleteStringCollection autotext16 = new AutoCompleteStringCollection();

            while (datareader16.Read())
            {
                autotext16.Add(datareader16.GetString(0));
            }
            txt_descricaoanomes.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_descricaoanomes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_descricaoanomes.AutoCompleteCustomSource = autotext16;
            cmd16.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX MES DESCRIÇÃO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd17 = new MySqlCommand();
            cmd17.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd17.CommandText = "Select Mes from tb_financeiro order by Mes";
            cmd17.ExecuteNonQuery();
            MySqlDataReader datareader17;
            datareader17 = cmd17.ExecuteReader();
            AutoCompleteStringCollection autotext17 = new AutoCompleteStringCollection();

            while (datareader17.Read())
            {
                autotext17.Add(datareader17.GetString(0));
            }
            txt_mesdescricaoano.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_mesdescricaoano.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_mesdescricaoano.AutoCompleteCustomSource = autotext17;
            cmd17.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX MES DESCRIÇÃO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd18 = new MySqlCommand();
            cmd18.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd18.CommandText = "Select Ano from tb_financeiro order by Ano";
            cmd18.ExecuteNonQuery();
            MySqlDataReader datareader18;
            datareader18 = cmd18.ExecuteReader();
            AutoCompleteStringCollection autotext18 = new AutoCompleteStringCollection();

            while (datareader18.Read())
            {
                autotext18.Add(datareader18.GetString(0));
            }
            txt_anomesdescricao.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_anomesdescricao.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_anomesdescricao.AutoCompleteCustomSource = autotext18;
            cmd18.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX ANO, DESTINO E MES'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd19 = new MySqlCommand();
            cmd19.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd19.CommandText = "Select Ano from tb_financeiro order by Ano";
            cmd19.ExecuteNonQuery();
            MySqlDataReader datareader19;
            datareader19 = cmd19.ExecuteReader();
            AutoCompleteStringCollection autotext19 = new AutoCompleteStringCollection();

            while (datareader19.Read())
            {
                autotext19.Add(datareader19.GetString(0));
            }
            txt_anomesdestino.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_anomesdestino.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_anomesdestino.AutoCompleteCustomSource = autotext19;
            cmd19.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX ANO, DEPARTAMENTO E MES'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd20 = new MySqlCommand();
            cmd20.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd20.CommandText = "Select Ano from tb_financeiro order by Ano";
            cmd20.ExecuteNonQuery();
            MySqlDataReader datareader20;
            datareader20 = cmd20.ExecuteReader();
            AutoCompleteStringCollection autotext20 = new AutoCompleteStringCollection();

            while (datareader20.Read())
            {
                autotext20.Add(datareader20.GetString(0));
            }
            txt_anomesdepartamento.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_anomesdepartamento.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_anomesdepartamento.AutoCompleteCustomSource = autotext20;
            cmd20.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #endregion
        }

        private void btn_carregartudo_Click(object sender, EventArgs e)
        {
            #region 'CARREGA TUDO'
            // TODO: esta linha de código carrega dados na tabela 'sigrassystembdDataSet.tb_vendasclientes'. 
            // Você pode movê-la ou removê-la conforme necessário.
            this.tb_financeiroTableAdapter.Fill(this.sigrassystembdDataSet.tb_financeiro);
            this.RVfinanceirobd.RefreshReport();
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
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
                FrmFinanceiro frm = new FrmFinanceiro();
                frm.ShowDialog();
                //this.Close();
            }
            #endregion
        }

        private void btn_ano_Click(object sender, EventArgs e)
        {
            #region "CARREGA O ANO"
            if (txt_ano.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
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
                    this.tb_financeiroTableAdapter.FillBy01Ano(this.sigrassystembdDataSet.tb_financeiro, Convert.ToInt32(txt_ano.Text));
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_ano.Focus();
            #endregion
        }

        private void btn_mes_Click(object sender, EventArgs e)
        {
            #region "CARREGA O MÊS"
            if (txt_mes.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
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
                    this.tb_financeiroTableAdapter.FillBy02Mes(this.sigrassystembdDataSet.tb_financeiro, txt_mes.Text);
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_mes.Focus();
            #endregion
        }

        private void btn_anomes_Click(object sender, EventArgs e)
        {
            #region "CARREGA O ANO COM O MES"
            if (txt_anomes.Text == "" || txt_mesano.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
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
                #region "CARREGA O ANO COM O MES"
                try
                {
                    this.tb_financeiroTableAdapter.FillBy03AnoMes(this.sigrassystembdDataSet.tb_financeiro, Convert.ToInt32(txt_anomes.Text), txt_mesano.Text);
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_anomes.Focus();
            #endregion
        }

        private void btn_tipolancamento_Click(object sender, EventArgs e)
        {
            #region "CARREGA O TIPO LANÇAMENTO"
            if (txt_tipolancamento.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_tipolancamento.Focus();
                #endregion
            }
            else
            {
                #region "CARREGA O TIPO LANÇAMENTO"
                try
                {
                    this.tb_financeiroTableAdapter.FillBy04TipoLancamento(this.sigrassystembdDataSet.tb_financeiro, txt_tipolancamento.Text);
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_tipolancamento.Focus();
            #endregion
        }

        private void btn_destino_Click(object sender, EventArgs e)
        {
            #region "CARREGA O DESTINO LANÇAMENTO"
            if (txt_destino.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_destino.Focus();
                #endregion
            }
            else
            {
                #region "CARREGA O DESTINO LANÇAMENTO"
                try
                {
                    this.tb_financeiroTableAdapter.FillBy05DestinoLancamento(this.sigrassystembdDataSet.tb_financeiro, txt_destino.Text);
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_destino.Focus();
            #endregion
        }

        private void btn_destinoanomes_Click(object sender, EventArgs e)
        {
            #region "CARREGA O DESTINO, ANO E MÊS"
            if (txt_destinoanomes.Text == "" || txt_anomesdestino.Text == "" || txt_mesdestinoano.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_destinoanomes.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O DESTINO, ANO E MÊS"
                try
                {
                    this.tb_financeiroTableAdapter.FillBy06DestinoLancamentoAnoMes(this.sigrassystembdDataSet.tb_financeiro, txt_destinoanomes.Text, Convert.ToInt32(txt_anomesdestino.Text), txt_mesdestinoano.Text);
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_destinoanomes.Focus();
            #endregion
        }

        private void btn_departamento_Click(object sender, EventArgs e)
        {
            #region "CARREGA O DEPARTAMENTO SETOR"
            if (txt_departamento.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_departamento.Focus();
                #endregion
            }
            else
            {
                #region "CARREGA O DEPARTAMENTO SETOR"
                try
                {
                    this.tb_financeiroTableAdapter.FillBy07DepartamentoSetor(this.sigrassystembdDataSet.tb_financeiro, txt_departamento.Text);
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_departamento.Focus();
            #endregion
        }

        private void btn_departamentoanomes_Click(object sender, EventArgs e)
        {
            #region "CARREGA O DEPARTAMENTO SETOR, ANO E MÊS"
            if (txt_departamentoanomes.Text == "" || txt_anomesdepartamento.Text == "" || txt_mesdepartamentoano.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_departamentoanomes.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA O DEPARTAMENTO SETOR, ANO E MÊS"
                try
                {
                    this.tb_financeiroTableAdapter.FillBy08DepartamentoSetorAnoMes(this.sigrassystembdDataSet.tb_financeiro, txt_departamentoanomes.Text, Convert.ToInt32(txt_anomesdepartamento.Text), txt_mesdepartamentoano.Text);
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_departamentoanomes.Focus();
            #endregion
        }

        private void btn_contadestino_Click(object sender, EventArgs e)
        {
            #region "CARREGA O CONTA DESTINO"
            if (txt_contadestino.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_contadestino.Focus();
                #endregion
            }
            else
            {
                #region "CARREGA O CONTA DESTINO"
                try
                {
                    this.tb_financeiroTableAdapter.FillBy09ContaDestino(this.sigrassystembdDataSet.tb_financeiro, txt_contadestino.Text);
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_contadestino.Focus();
            #endregion
        }

        private void btn_data_Click(object sender, EventArgs e)
        {
            #region "CARREGA A DATA"
            if (!txtmsk_data.MaskCompleted)
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txtmsk_data.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA A DATA"
                try
                {
                    this.tb_financeiroTableAdapter.FillBy10Data(this.sigrassystembdDataSet.tb_financeiro, Convert.ToDateTime(txtmsk_data.Text));
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txtmsk_data.Focus();
            #endregion
        }

        private void btn_datainiciofim_Click(object sender, EventArgs e)
        {
            #region "CARREGA A DATAINICIOFIM E DATAFIMINICIO"
            if (!txtmsk_datainiciofim.MaskCompleted || !txtmsk_datafiminicio.MaskCompleted)
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
                txt_descricao.Text = "";
                txt_descricaoanomes.Text = "";
                txt_anomesdescricao.Text = "";
                txt_mesdescricaoano.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txtmsk_datainiciofim.Focus();
                #endregion                
            }
            else
            {
                #region "CARREGA A DATAINICIOFIM E DATAFIMINICIO"
                try
                {
                    this.tb_financeiroTableAdapter.FillBy11DataInicioDataFim(this.sigrassystembdDataSet.tb_financeiro, Convert.ToDateTime(txtmsk_datainiciofim.Text), Convert.ToDateTime(txtmsk_datafiminicio.Text));
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txtmsk_datainiciofim.Focus();
            #endregion
        }

        private void btn_especie_Click(object sender, EventArgs e)
        {
            #region "CARREGA A ESPÉCIE"
            if (txt_especie.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
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
                    this.tb_financeiroTableAdapter.FillBy12Especie(this.sigrassystembdDataSet.tb_financeiro, txt_especie.Text);
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_especie.Focus();
            #endregion
        }

        private void btn_especieanomes_Click(object sender, EventArgs e)
        {
            #region "CARREGA A ESPÉCIE, ANO E MÊS"
            if (txt_especieanomes.Text == "" || txt_anomesespecie.Text == "" || txt_mesespecieano.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
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
                    this.tb_financeiroTableAdapter.FillBy13EspecieAnoMes(this.sigrassystembdDataSet.tb_financeiro, txt_especieanomes.Text, Convert.ToInt32(txt_anomesespecie.Text), txt_mesespecieano.Text);
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_especieanomes.Focus();
            #endregion
        }

        private void btn_descricao_Click(object sender, EventArgs e)
        {
            #region "CARREGA A DESCRIÇÃO"
            if (txt_descricao.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
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
                    this.tb_financeiroTableAdapter.FillBy14DescricaoLancamento(this.sigrassystembdDataSet.tb_financeiro, txt_descricao.Text);
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_descricao.Focus();
            #endregion
        }

        private void btn_descricaoanomes_Click(object sender, EventArgs e)
        {
            #region "CARREGA A DESCRIÇÃO LANÇAMENTO, ANO E MÊS"
            if (txt_descricaoanomes.Text == "" || txt_anomesdescricao.Text == "" || txt_mesdescricaoano.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                //GUIA PERÍODO
                txt_ano.Text = "";
                txt_mes.Text = "";
                txt_mesano.Text = "";
                txt_anomes.Text = "";
                //GUIA TIPO LANÇAMENTO
                txt_tipolancamento.Text = "";
                //GUIA DESTINO LANÇAMENTO
                txt_destino.Text = "";
                txt_destinoanomes.Text = "";
                txt_anomesdestino.Text = "";
                txt_mesdestinoano.Text = "";
                //GUIA DEPARTAMENTO LANÇAMENTO
                txt_departamento.Text = "";
                txt_departamentoanomes.Text = "";
                txt_anomesdepartamento.Text = "";
                txt_mesdepartamentoano.Text = "";
                //GUIA CONTA DESTINO
                txt_contadestino.Text = "";
                //GUIA DATA
                txtmsk_data.Text = "";
                txtmsk_datainiciofim.Text = "";
                txtmsk_datafiminicio.Text = "";
                //GUIA ESPÉCIE
                txt_especie.Text = "";
                txt_especieanomes.Text = "";
                txt_anomesespecie.Text = "";
                txt_mesespecieano.Text = "";
                //GUIA DESCRIÇÃO LANÇAMENTO
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
                #region "CARREGA A DESCRIÇÃO LANÇAMENTO, ANO E MÊS"
                try
                {
                    this.tb_financeiroTableAdapter.FillBy15DescricaoLancamentoAnoMes(this.sigrassystembdDataSet.tb_financeiro, txt_descricaoanomes.Text, Convert.ToInt32(txt_anomesdescricao.Text), txt_mesdescricaoano.Text);
                    this.RVfinanceirobd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //GUIA PERÍODO
            txt_ano.Text = "";
            txt_mes.Text = "";
            txt_mesano.Text = "";
            txt_anomes.Text = "";
            //GUIA TIPO LANÇAMENTO
            txt_tipolancamento.Text = "";
            //GUIA DESTINO LANÇAMENTO
            txt_destino.Text = "";
            txt_destinoanomes.Text = "";
            txt_anomesdestino.Text = "";
            txt_mesdestinoano.Text = "";
            //GUIA DEPARTAMENTO LANÇAMENTO
            txt_departamento.Text = "";
            txt_departamentoanomes.Text = "";
            txt_anomesdepartamento.Text = "";
            txt_mesdepartamentoano.Text = "";
            //GUIA CONTA DESTINO
            txt_contadestino.Text = "";
            //GUIA DATA
            txtmsk_data.Text = "";
            txtmsk_datainiciofim.Text = "";
            txtmsk_datafiminicio.Text = "";
            //GUIA ESPÉCIE
            txt_especie.Text = "";
            txt_especieanomes.Text = "";
            txt_anomesespecie.Text = "";
            txt_mesespecieano.Text = "";
            //GUIA DESCRIÇÃO LANÇAMENTO
            txt_descricao.Text = "";
            txt_descricaoanomes.Text = "";
            txt_anomesdescricao.Text = "";
            txt_mesdescricaoano.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_descricaoanomes.Focus();
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

        private void txt_anomesdestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_mesdestinoano_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_anomesdepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_mesdepartamentoano_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
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
