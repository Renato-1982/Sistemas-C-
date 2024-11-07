using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGRas
{
    public partial class FrmFinanceiro : Form
    {
        #region "PREENCHENDO COMBOBOX COM DADOS DO BANCO"
        //-----------------------------------------------------------------------
        //PREENCHENDO COMBOBOX
        public void FillComboDestinoLancamento(string strSql, string tstr)
        {
            #region 'CAIXA DESTINO LANÇAMENTO'
            //DECLARAÇÃO PARA PREENCHER A COMBOBOX
            cbo_destinolancamento.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    cbo_destinolancamento.Items.Add(datareader[0]);
                }
                cmd.Connection.Close(); //Fecha a conexão
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion
        }

        //-----------------------------------------------------------------------
        //PREENCHENDO COMBOBOX
        public void FillComboDepartamentoSetor(string strSql, string tstr)
        {
            #region 'CAIXA DEPARTAMENTO SETOR'
            //DECLARAÇÃO PARA PREENCHER A COMBOBOX
            cbo_departamentosetor.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    cbo_departamentosetor.Items.Add(datareader[0]);
                }
                cmd.Connection.Close(); //Fecha a conexão
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion
        }

        //-----------------------------------------------------------------------
        //PREENCHENDO COMBOBOX
        public void FillComboContaDestino(string strSql, string tstr)
        {
            #region 'CAIXA CONTA DESTINO'
            //DECLARAÇÃO PARA PREENCHER A COMBOBOX
            cbo_contadestino.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    cbo_contadestino.Items.Add(datareader[0]);
                }
                cmd.Connection.Close(); //Fecha a conexão
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion
        }
        #endregion

        #region "FORMATANDO TEXTBOX FORMATO MOEDA"
        //-----------------------------------------------------------------------
        //FORMATAÇÃO MOEDA
        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;
            double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");

                if (n.Equals(""))
                    n = "";

                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);

                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception)
            {

            }
        }
        //-----------------------------------------------------------------------
        #endregion

        public FrmFinanceiro()
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

        private void FrmFinanceiro_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmFinanceiro_Load(object sender, EventArgs e)
        {
            #region "PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO"               
            //PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO - EXEMPLO 1
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT max(ID) FROM tb_financeiro";

            try
            {
                if (cmd.ExecuteScalar() == DBNull.Value)
                {
                    //txt_ultid.Text = "1";
                    txt_ultid.TextAlign = HorizontalAlignment.Center;
                }
                else
                {
                    Int32 ra = Convert.ToInt32(cmd.ExecuteScalar());
                    txt_ultid.Text = ra.ToString();
                    txt_ultid.TextAlign = HorizontalAlignment.Center;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Connection.Close(); //Fecha a conexão
            }
            cmd.Connection.Close(); //Fecha a conexão
            #endregion

            #region "PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO"
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd1.CommandText = "SELECT * FROM tb_financeiro WHERE ID = '" + txt_ultid.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd1.ExecuteReader(); //Executa o comando selecionar                    
            
            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                txt_ultid.Text = dr["ID"].ToString();
                txt_ultid.TextAlign = HorizontalAlignment.Center;
                txt_ultdatasistema.Text = dr["DataSistema"].ToString();
                txt_ulthorasistema.Text = dr["HoraSistema"].ToString();
                txt_ultmes.Text = dr["Mes"].ToString();
                txt_ultano.Text = dr["Ano"].ToString();
                txt_ulttipolancamento.Text = dr["TipoLancamento"].ToString();
                txt_ultdestinolancamento.Text = dr["DestinoLancamento"].ToString();
                txt_ultdepartamentosetor.Text = dr["DepartamentoSetor"].ToString();
                txt_ultcontadestino.Text = dr["ContaDestino"].ToString();
                txt_ultdatalancamento.Text = dr["Data"].ToString();
                txt_ultespecie.Text = dr["Especie"].ToString();
                txt_ultdescricao.Text = dr["DescricaoLancamento"].ToString();
                txt_ultvlrentrada.Text = dr["ValorEntrada"].ToString();
                txt_ultvlrentrada.TextAlign = HorizontalAlignment.Center;
                txt_ultvlrsaida.Text = dr["ValorSaida"].ToString();
                txt_ultvlrsaida.TextAlign = HorizontalAlignment.Center;
                txt_ultobs.Text = dr["Observacao"].ToString();
            }
            //Fecha a conexão
            cmd1.Connection.Close();
            #endregion

            #region "CONTA QUANTIDADE DE REGISTROS"
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd2.CommandText = "SELECT count(ID) FROM tb_financeiro";

            try
            {
                int totalregistros = int.Parse(cmd2.ExecuteScalar().ToString());
                cmd2.Connection.Close(); //Fecha a conexão

                txt_totalregistros.Text = totalregistros.ToString();
                txt_totalregistros.TextAlign = HorizontalAlignment.Center;
            }
            catch (Exception)
            {
                throw;
            }
            cmd2.Connection.Close(); //Fecha a conexão
            #endregion

            #region "PREENCHENDO COMBOBOX FIXA
            //CARREGAR COMBOBOX MES   
            this.cbo_mes.Items.Clear();
            this.cbo_mes.Items.Add("Janeiro");
            this.cbo_mes.Items.Add("Fevereiro");
            this.cbo_mes.Items.Add("Março");
            this.cbo_mes.Items.Add("Abril");
            this.cbo_mes.Items.Add("Maio");
            this.cbo_mes.Items.Add("Junho");
            this.cbo_mes.Items.Add("Julho");
            this.cbo_mes.Items.Add("Agosto");
            this.cbo_mes.Items.Add("Setembro");
            this.cbo_mes.Items.Add("Outubro");
            this.cbo_mes.Items.Add("Novembro");
            this.cbo_mes.Items.Add("Dezembro");

            //CARREGAR COMBOBOX ANO    
            this.cbo_ano.Items.Clear();
            this.cbo_ano.Items.Add("2020");
            this.cbo_ano.Items.Add("2021");
            this.cbo_ano.Items.Add("2022");
            this.cbo_ano.Items.Add("2023");
            this.cbo_ano.Items.Add("2024");
            this.cbo_ano.Items.Add("2025");
            this.cbo_ano.Items.Add("2026");
            this.cbo_ano.Items.Add("2027");
            this.cbo_ano.Items.Add("2028");
            this.cbo_ano.Items.Add("2029");
            this.cbo_ano.Items.Add("2030");
            this.cbo_ano.Items.Add("2031");
            this.cbo_ano.Items.Add("2032");
            this.cbo_ano.Items.Add("2033");
            this.cbo_ano.Items.Add("2034");
            this.cbo_ano.Items.Add("2035");
            this.cbo_ano.Items.Add("2036");
            this.cbo_ano.Items.Add("2037");
            this.cbo_ano.Items.Add("2038");
            this.cbo_ano.Items.Add("2039");
            this.cbo_ano.Items.Add("2040");

            //CARREGAR COMBOBOX TIPO LANÇAMENTO
            this.cbo_tipolancamento.Items.Clear();
            this.cbo_tipolancamento.Items.Add("Despesa");
            this.cbo_tipolancamento.Items.Add("Receita");

            //CARREGAR COMBOBOX ESPÉCIE
            this.cbo_especie.Items.Clear();
            this.cbo_especie.Items.Add("Dinheiro");
            this.cbo_especie.Items.Add("Cartões Diversos");
            this.cbo_especie.Items.Add("Cartão Débito");
            this.cbo_especie.Items.Add("Cartão Crédito");
            this.cbo_especie.Items.Add("Cartão Alimentação");
            this.cbo_especie.Items.Add("Cartão Refeição");
            this.cbo_especie.Items.Add("Cartão Ticket");
            this.cbo_especie.Items.Add("Cheque");
            this.cbo_especie.Items.Add("Boleto");
            #endregion

            #region "CARREGAR COMBOBOX COM DADOS DO BANCO"    

            #region 'COMBOBOX DESTINO LANÇAMENTO'
            //CARREGAR COMBOBOX DESTINO LANÇAMENTO
            try
            {
                string strSQL = "Select DescricaoLancamentos from tb_financeirodestinolancamentos order by DescricaoLancamentos";
                string tstr = "tb_financeirodestinolancamentos";
                FillComboDestinoLancamento(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'COMBOBOX DEPARTAMENTO SETOR'
            //CARREGAR COMBOBOX DEPARTAMENTO SETOR
            try
            {
                string strSQL = "Select DescricaoDepartamentos from tb_financeirodepartamentosetores order by DescricaoDepartamentos";
                string tstr = "tb_financeirodepartamentosetores";
                FillComboDepartamentoSetor(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'COMBOBOX DESTINO OPERAÇÃO'
            //CARREGAR COMBOBOX CONTA DESTINO OPERAÇÃO
            try
            {
                string strSQL = "Select DescricaoDestinos from tb_financeirodestinooperacao order by DescricaoDestinos";
                string tstr = "tb_financeirodestinooperacao";
                FillComboContaDestino(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #endregion

            #region "DESATIVANDO/ATIVANDO CAIXAS"
            //DESATIVAR/ATIVAR CAIXAS LANÇAMENTO
            txt_id.Enabled = false;
            txt_datasistema.Enabled = false;
            txt_horasistema.Enabled = false;
            cbo_mes.Enabled = false;
            cbo_ano.Enabled = false;
            cbo_tipolancamento.Enabled = false;
            cbo_destinolancamento.Enabled = false;
            cbo_departamentosetor.Enabled = false;
            cbo_contadestino.Enabled = false;
            txtmsk_datalancamento.Enabled = false;
            cbo_especie.Enabled = false;
            txt_descricaolancamento.Enabled = false;
            txt_vlrentrada.Enabled = false;
            txt_vlrsaida.Enabled = false;
            txt_obs.Enabled = false;

            //DESATIVAR/ATIVAR CAIXAS ÚLTIMO LANÇAMENTO
            txt_ultid.Enabled = false;
            txt_ultdatasistema.Enabled = false;
            txt_ulthorasistema.Enabled = false;
            txt_ultmes.Enabled = false;
            txt_ultano.Enabled = false;
            txt_ulttipolancamento.Enabled = false;
            txt_ultdestinolancamento.Enabled = false;
            txt_ultdepartamentosetor.Enabled = false;
            txt_ultcontadestino.Enabled = false;
            txt_ultdatalancamento.Enabled = false;
            txt_ultespecie.Enabled = false;
            txt_ultdescricao.Enabled = false;
            txt_ultvlrentrada.Enabled = false;
            txt_ultvlrsaida.Enabled = false;
            txt_ultobs.Enabled = false;

            //DESATIVAR/ATIVAR CAIXAS DE SOMAS
            txt_totalregistros.Enabled = false;
            #endregion

            #region "DESATIVANDO/ATIVANDO BOTOES"
            if (txt_id.Text != "")
            {
                //DESATIVAR/ATIVAR BOTOES
                btn_novo.Enabled = false;
                btn_gravar.Enabled = false;
                btn_cancelar.Enabled = true;
                btn_editar.Enabled = true;
                btn_alterar.Enabled = false;
                btn_printtela.Enabled = true;
                btn_relatorio.Enabled = false;
                btn_consultar.Enabled = false;
                btn_backup.Enabled = false;
                btn_fechar.Enabled = false;
                btnCerrar.Enabled = false;
            }
            else
            {
                //DESATIVAR/ATIVAR BOTOES
                btn_novo.Enabled = true;
                btn_gravar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_editar.Enabled = false;
                btn_alterar.Enabled = false;
                btn_printtela.Enabled = true;
                btn_relatorio.Enabled = true;
                btn_consultar.Enabled = true;
                btn_backup.Enabled = true;
                btn_fechar.Enabled = true;
                btnCerrar.Enabled = true;

                //POSICIONANDO O FOCO
                btn_novo.Focus();
            }
            #endregion
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            #region "CAPTURAR DATA E HORA SISTEMA"
            //PREENCHENDO AS CAIXAS DATA E HORA COM DADOS ATUAIS
            //CAPTURAR HORA
            string hora = System.DateTime.Now.ToShortTimeString();
            //CAPTURAR DATA
            string DateTime = System.DateTime.Now.ToShortDateString();
            //PREENCHENDO AS CAIXAS
            txt_datasistema.Text = (DateTime);
            txt_horasistema.Text = (hora);
            #endregion

            #region "AUTO COMPLETE TEXTBOX DESCRIÇÃO"
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "Select DescricaoLancamento from tb_financeiro order by DescricaoLancamento";
            cmd.ExecuteNonQuery();
            MySqlDataReader datareader;
            datareader = cmd.ExecuteReader();

            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

            while (datareader.Read())
            {
                autotext.Add(datareader.GetString(0));
            }
            txt_descricaolancamento.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_descricaolancamento.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_descricaolancamento.AutoCompleteCustomSource = autotext;
            cmd.Connection.Close(); //Fecha a conexão  
            #endregion

            #region "AUTO COMPLETE TEXTBOX OBSERVAÇÃO"
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd1.CommandText = "Select Observacao from tb_financeiro order by Observacao";
            cmd1.ExecuteNonQuery();
            MySqlDataReader datareader1;
            datareader1 = cmd1.ExecuteReader();

            AutoCompleteStringCollection autotext1 = new AutoCompleteStringCollection();

            while (datareader1.Read())
            {
                autotext1.Add(datareader1.GetString(0));
            }
            txt_obs.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_obs.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_obs.AutoCompleteCustomSource = autotext1;
            cmd1.Connection.Close(); //Fecha a conexão  
            #endregion

            #region "DESATIVANDO/ATIVANDO CAIXAS"
            //DESATIVAR/ATIVAR CAIXAS LANÇAMENTO
            txt_id.Enabled = false;
            txt_datasistema.Enabled = false;
            txt_horasistema.Enabled = false;
            cbo_mes.Enabled = true;
            cbo_ano.Enabled = true;
            cbo_tipolancamento.Enabled = true;
            cbo_destinolancamento.Enabled = true;
            cbo_departamentosetor.Enabled = true;
            cbo_contadestino.Enabled = true;
            txtmsk_datalancamento.Enabled = true;
            cbo_especie.Enabled = true;
            txt_descricaolancamento.Enabled = true;
            txt_vlrentrada.Enabled = false;
            txt_vlrsaida.Enabled = false;
            txt_obs.Enabled = true;
            #endregion

            #region "DESATIVANDO/ATIVANDO BOTOES"
            //DESATIVAR/ATIVAR BOTOES
            btn_novo.Enabled = false;
            btn_gravar.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_editar.Enabled = false;
            btn_alterar.Enabled = false;
            btn_printtela.Enabled = false;
            btn_relatorio.Enabled = false;
            btn_consultar.Enabled = false;
            btn_backup.Enabled = false;
            btn_fechar.Enabled = false;
            btnCerrar.Enabled = false;
            #endregion

            #region 'COLOCA O FOCO'
            //POSICIONANDO O FOCO
            cbo_mes.Focus();
            #endregion
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            #region "COMEÇA A GRAVAÇÃO"
            try
            {
                #region "FAZ A VERIFICAÇÃO DE SELEÇÃO"
                if (txt_obs.Text == "")
                {
                    txt_obs.Text = "";
                    txt_obs.Text = "Nada";
                }
                #endregion

                #region 'VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR'
                if (cbo_mes.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_mes.Focus();
                    return;
                }
                if (cbo_ano.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_ano.Focus();
                    return;
                }
                if (cbo_tipolancamento.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_tipolancamento.Focus();
                    return;
                }
                if (cbo_destinolancamento.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_destinolancamento.Focus();
                    return;
                }
                if (cbo_departamentosetor.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_departamentosetor.Focus();
                    return;
                }
                if (cbo_contadestino.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_contadestino.Focus();
                    return;
                }
                if (!txtmsk_datalancamento.MaskCompleted)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmsk_datalancamento.Text = "";
                    this.txtmsk_datalancamento.Focus();
                    return;
                }
                if (cbo_especie.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_especie.Focus();
                    return;
                }
                if (txt_descricaolancamento.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_descricaolancamento.Focus();
                    return;
                }
                if (txt_vlrentrada.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_vlrentrada.Focus();
                    return;
                }
                if (txt_vlrsaida.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_vlrsaida.Focus();
                    return;
                }
                if (txt_obs.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_obs.Focus();
                    return;
                }
                #endregion

                #region 'FORMATAÇÃO DA DATA'
                //BUSCA A FORMATAÇÃO DA DATA
                string datasistemaUS = FormatadataUS(txt_datasistema.Text);
                string datalancamentoUS = FormatadataUS(txtmsk_datalancamento.Text);
                #endregion

                #region 'COMANDO PARA GRAVAR'
                //Começa o comando para gravar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "Insert Into tb_financeiro(DataSistema,HoraSistema,Mes,Ano,TipoLancamento," +
                    "DestinoLancamento,DepartamentoSetor,ContaDestino,Data,Especie,DescricaoLancamento," +
                    "ValorEntrada,ValorSaida,Observacao) Values";
                cmd.CommandText += "('" + datasistemaUS + "','" + txt_horasistema.Text + "','" + cbo_mes.Text + "'," +
                    "'" + cbo_ano.Text + "','" + cbo_tipolancamento.Text + "','" + cbo_destinolancamento.Text + "'," +
                    "'" + cbo_departamentosetor.Text + "','" + cbo_contadestino.Text + "','" + datalancamentoUS + "'," +
                    "'" + cbo_especie.Text + "','" + txt_descricaolancamento.Text + "','" + txt_vlrentrada.Text + "'," +
                    "'" + txt_vlrsaida.Text + "','" + txt_obs.Text + "')";
                cmd.ExecuteNonQuery();
                cmd.Connection.Close(); //Fecha a conexão 
                #endregion

                #region 'MENSAGEM'
                MessageBox.Show("Dados Cadastrados com Sucesso!!!");
                #endregion

                #region "PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO"               
                //PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO - EXEMPLO 1
                //Começa o comando para selecionar os dados do banco
                MySqlCommand cmd1 = new MySqlCommand();
                cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd1.CommandText = "SELECT max(ID) FROM tb_financeiro";

                try
                {
                    if (cmd1.ExecuteScalar() == DBNull.Value)
                    {
                        //txt_ultid.Text = "1";
                        txt_ultid.TextAlign = HorizontalAlignment.Center;
                    }
                    else
                    {
                        Int32 ra = Convert.ToInt32(cmd1.ExecuteScalar());
                        txt_ultid.Text = ra.ToString();
                        txt_ultid.TextAlign = HorizontalAlignment.Center;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Connection.Close(); //Fecha a conexão
                }
                cmd.Connection.Close(); //Fecha a conexão
                #endregion

                #region 'PREENCHE AS CAIXAS COM ULTIMO LANÇAMENTO'
                //PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO
                //txt_ultid.Text = txt_id.Text;
                txt_ultdatasistema.Text = txt_datasistema.Text;
                txt_ulthorasistema.Text = txt_horasistema.Text;
                txt_ultmes.Text = cbo_mes.Text;
                txt_ultano.Text = cbo_ano.Text;
                txt_ulttipolancamento.Text = cbo_tipolancamento.Text;
                txt_ultdestinolancamento.Text = cbo_destinolancamento.Text;
                txt_ultdepartamentosetor.Text = cbo_departamentosetor.Text;
                txt_ultcontadestino.Text = cbo_contadestino.Text;
                txt_ultdatalancamento.Text = txtmsk_datalancamento.Text;
                txt_ultespecie.Text = cbo_especie.Text;
                txt_ultdescricao.Text = txt_descricaolancamento.Text;
                txt_ultvlrentrada.Text = txt_vlrentrada.Text;
                txt_ultvlrentrada.TextAlign = HorizontalAlignment.Center;
                txt_ultvlrsaida.Text = txt_vlrsaida.Text;
                txt_ultvlrsaida.TextAlign = HorizontalAlignment.Center;
                txt_ultobs.Text = txt_obs.Text;
                #endregion
            }
            catch (Exception)
            {
                #region 'MENSAGEM'
                MessageBox.Show("Dados não Gravados!!! \n Não Use Caracteres Especiais na Descrição!");
                #endregion
            }
            #endregion

            #region "CONTA QUANTIDADE DE REGISTROS"
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd2.CommandText = "SELECT count(ID) FROM tb_financeiro";

            try
            {
                int totalregistros = int.Parse(cmd2.ExecuteScalar().ToString());
                cmd2.Connection.Close(); //Fecha a conexão

                txt_totalregistros.Text = totalregistros.ToString();
                txt_totalregistros.TextAlign = HorizontalAlignment.Center;
            }
            catch (Exception)
            {
                throw;
            }
            cmd2.Connection.Close(); //Fecha a conexão
            #endregion

            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btn_cancelar.PerformClick();

            //EXECUTA O BOTÃO LIMPAR
            btn_novo.PerformClick();
            #endregion
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            #region "COMEÇA A ALTERAÇÃO"
            try
            {
                #region "FAZ A VERIFICAÇÃO DE SELEÇÃO"
                if (txt_obs.Text == "")
                {
                    txt_obs.Text = "";
                    txt_obs.Text = "Nada";
                }
                #endregion

                #region 'VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR'
                if (cbo_mes.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_mes.Focus();
                    return;
                }
                if (cbo_ano.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_ano.Focus();
                    return;
                }
                if (cbo_tipolancamento.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_tipolancamento.Focus();
                    return;
                }
                if (cbo_destinolancamento.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_destinolancamento.Focus();
                    return;
                }
                if (cbo_departamentosetor.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_departamentosetor.Focus();
                    return;
                }
                if (cbo_contadestino.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_contadestino.Focus();
                    return;
                }
                if (!txtmsk_datalancamento.MaskCompleted)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmsk_datalancamento.Text = "";
                    this.txtmsk_datalancamento.Focus();
                    return;
                }
                if (cbo_especie.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_especie.Focus();
                    return;
                }
                if (txt_descricaolancamento.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_descricaolancamento.Focus();
                    return;
                }
                if (txt_vlrentrada.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_vlrentrada.Focus();
                    return;
                }
                if (txt_vlrsaida.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_vlrsaida.Focus();
                    return;
                }
                if (txt_obs.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_obs.Focus();
                    return;
                }
                #endregion

                #region 'FORMATAÇÃO DA DATA'
                //BUSCA A FORMATAÇÃO DA DATA
                string datasistemaUS = FormatadataUS(txt_datasistema.Text);
                string datalancamentoUS = FormatadataUS(txtmsk_datalancamento.Text);
                #endregion

                #region 'COMANDO PARA GRAVAR'
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "update tb_financeiro set " +
                    "DataSistema ='" + datasistemaUS + "' ,HoraSistema = '" + txt_horasistema.Text + "' ," +
                    "Mes = '" + cbo_mes.Text + "' ,Ano = '" + cbo_ano.Text + "' ,TipoLancamento = '" + cbo_tipolancamento.Text + "' ," +
                    "DestinoLancamento = '" + cbo_destinolancamento.Text + "' ,DepartamentoSetor = '" + cbo_departamentosetor.Text + "' ," +
                    "ContaDestino = '" + cbo_contadestino.Text + "' ,Data = '" + datalancamentoUS + "' ,Especie = '" + cbo_especie.Text + "' ," +
                    "DescricaoLancamento = '" + txt_descricaolancamento.Text + "' ,ValorEntrada = '" + txt_vlrentrada.Text + "' ," +
                    "ValorSaida = '" + txt_vlrsaida.Text + "' ,Observacao = '" + txt_obs.Text + "' Where ID = " + txt_id.Text + "";
                cmd.ExecuteNonQuery();
                cmd.Connection.Close(); //Fecha a conexão 
                #endregion

                #region 'MENSAGEM'
                MessageBox.Show("Dados Alterados com Sucesso!!!");
                #endregion

                #region 'PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO'
                //PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO
                txt_ultid.Text = txt_id.Text;
                txt_ultdatasistema.Text = txt_datasistema.Text;
                txt_ulthorasistema.Text = txt_horasistema.Text;
                txt_ultmes.Text = cbo_mes.Text;
                txt_ultano.Text = cbo_ano.Text;
                txt_ulttipolancamento.Text = cbo_tipolancamento.Text;
                txt_ultdestinolancamento.Text = cbo_destinolancamento.Text;
                txt_ultdepartamentosetor.Text = cbo_departamentosetor.Text;
                txt_ultcontadestino.Text = cbo_contadestino.Text;
                txt_ultdatalancamento.Text = txtmsk_datalancamento.Text;
                txt_ultespecie.Text = cbo_especie.Text;
                txt_ultdescricao.Text = txt_descricaolancamento.Text;
                txt_ultvlrentrada.Text = txt_vlrentrada.Text;
                txt_ultvlrentrada.TextAlign = HorizontalAlignment.Center;
                txt_ultvlrsaida.Text = txt_vlrsaida.Text;
                txt_ultvlrsaida.TextAlign = HorizontalAlignment.Center;
                txt_ultobs.Text = txt_obs.Text;
                #endregion
            }
            catch (Exception erro)
            {
                #region 'MENSAGEM'
                MessageBox.Show(erro.Message);
                #endregion
            }
            #endregion

            #region "CONTA QUANTIDADE DE REGISTROS"
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd1.CommandText = "SELECT count(ID) FROM tb_financeiro";

            try
            {
                int totalregistros = int.Parse(cmd1.ExecuteScalar().ToString());
                cmd1.Connection.Close(); //Fecha a conexão

                txt_totalregistros.Text = totalregistros.ToString();
                txt_totalregistros.TextAlign = HorizontalAlignment.Center;
            }
            catch (Exception)
            {
                throw;
            }
            cmd1.Connection.Close(); //Fecha a conexão
            #endregion

            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btn_cancelar.PerformClick();
            #endregion                        
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            #region "DESATIVANDO/ATIVANDO CAIXAS"
            //DESATIVAR/ATIVAR CAIXAS LANÇAMENTO
            txt_id.Enabled = false;
            txt_datasistema.Enabled = false;
            txt_horasistema.Enabled = false;
            cbo_mes.Enabled = true;
            cbo_ano.Enabled = true;
            cbo_tipolancamento.Enabled = true;
            cbo_destinolancamento.Enabled = true;
            cbo_departamentosetor.Enabled = true;
            cbo_contadestino.Enabled = true;
            txtmsk_datalancamento.Enabled = true;
            cbo_especie.Enabled = true;
            txt_descricaolancamento.Enabled = true;
            txt_vlrentrada.Enabled = false;
            txt_vlrsaida.Enabled = false;
            txt_obs.Enabled = true;
            #endregion

            #region "DESATIVANDO/ATIVANDO BOTOES"
            //DESATIVAR/ATIVAR BOTOES
            btn_novo.Enabled = false;
            btn_gravar.Enabled = false;
            btn_cancelar.Enabled = true;
            btn_editar.Enabled = false;
            btn_alterar.Enabled = true;
            btn_printtela.Enabled = false;
            btn_relatorio.Enabled = false;
            btn_consultar.Enabled = false;
            btn_backup.Enabled = false;
            btn_fechar.Enabled = false;
            btnCerrar.Enabled = false;
            #endregion

            #region "AUTO COMPLETE TEXTBOX"
            //AUTOCOMPLETE TEXTBOX 
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "Select DescricaoLancamento from tb_financeiro order by DescricaoLancamento";
            cmd.ExecuteNonQuery();
            MySqlDataReader datareader;
            datareader = cmd.ExecuteReader();

            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

            while (datareader.Read())
            {
                autotext.Add(datareader.GetString(0));
            }
            txt_descricaolancamento.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_descricaolancamento.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_descricaolancamento.AutoCompleteCustomSource = autotext;
            cmd.Connection.Close(); //Fecha a conexão  
            #endregion
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            #region "LIMPANDO CAIXAS"
            //LIMPAR CAIXAS LANÇAMENTO
            txt_id.Text = "";
            txt_datasistema.Text = "";
            txt_horasistema.Text = "";
            cbo_mes.Text = "";
            cbo_ano.Text = "";
            cbo_tipolancamento.Text = "";
            cbo_destinolancamento.Text = "";
            cbo_departamentosetor.Text = "";
            cbo_contadestino.Text = "";
            txtmsk_datalancamento.Text = "";
            cbo_especie.Text = "";
            txt_descricaolancamento.Text = "";
            txt_vlrentrada.Text = "";
            txt_vlrsaida.Text = "";
            txt_obs.Text = "";
            #endregion

            #region "DESATIVANDO/ATIVANDO CAIXAS"
            //DESATIVAR/ATIVAR CAIXAS LANÇAMENTO
            txt_id.Enabled = false;
            txt_datasistema.Enabled = false;
            txt_horasistema.Enabled = false;
            cbo_mes.Enabled = false;
            cbo_ano.Enabled = false;
            cbo_tipolancamento.Enabled = false;
            cbo_destinolancamento.Enabled = false;
            cbo_departamentosetor.Enabled = false;
            cbo_contadestino.Enabled = false;
            txtmsk_datalancamento.Enabled = false;
            cbo_especie.Enabled = false;
            txt_descricaolancamento.Enabled = false;
            txt_vlrentrada.Enabled = false;
            txt_vlrsaida.Enabled = false;
            txt_obs.Enabled = false;
            #endregion

            #region "DESATIVANDO/ATIVANDO BOTOES"
            //DESATIVAR/ATIVAR BOTOES
            btn_novo.Enabled = true;
            btn_gravar.Enabled = false;
            btn_cancelar.Enabled = false;
            btn_editar.Enabled = false;
            btn_alterar.Enabled = false;
            btn_printtela.Enabled = true;
            btn_relatorio.Enabled = true;
            btn_consultar.Enabled = true;
            btn_backup.Enabled = true;
            btn_fechar.Enabled = true;
            btnCerrar.Enabled = true;
            #endregion

            #region 'COLOCA O FOCO'
            //POSICIONANDO O FOCO
            btn_novo.Focus();
            #endregion
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            #region "ABRINDO NOVA TELA"
            this.Hide();
            FrmFinanceiroConsulta frm = new FrmFinanceiroConsulta();
            frm.ShowDialog();
            #endregion            
        }

        private void btn_relatorio_Click(object sender, EventArgs e)
        {
            #region "ABRINDO NOVA TELA"
            this.Hide();
            FrmFinanceiroRelatorio frm = new FrmFinanceiroRelatorio();
            frm.ShowDialog();
            #endregion 
        }

        private void btn_printtela_Click(object sender, EventArgs e)
        {
            #region "PRINTAR A TELA E SALVAR"
            //DEFINIMOS QUAL A DIMENSÃO DO BITMAP
            //A UTILIZAÇÃO DOU BOUNDS.WIDTH IRÁ PERMITIR QUE O PROGRAMA "SAIBA" ONDE COMEÇA A APLICAÇÃO            
            Bitmap printscreen = new Bitmap(this.Bounds.Width, this.Bounds.Height);

            //DEFINIMOS O BITMAP COMO IMAGEM
            Graphics graphics = Graphics.FromImage(printscreen);

            //O USO DO THIS.BOUND É FUNDAMENTAL PARA QUE O PRINTSCREEN APENAS INCIDA SOBRE A APLICAÇÃO
            //O THIS.BOUND.SIZE DETERMINA AUTOMATICAMENTE QUAL A DIMENSÃO DA JANELA DA APLICAÇÃO           
            graphics.CopyFromScreen(this.Bounds.X, this.Bounds.Y, 0, 0, this.Bounds.Size);

            //CHAMAMOS UM SAVE IMAG DIALOG PARA PODERMOS ESCOLHER ONDE GUARDAR A IMAGEM            
            SaveFileDialog saveImageDialog = new SaveFileDialog();

            //DEFINIMOS QUAL O TÍTULO DESSE DIALOGO            
            saveImageDialog.Title = "Seleccionar caminho do Ficheiro:";

            //DEFINIMOS OS FILTROS DA EXTENSÃO DA IMAGEM            
            saveImageDialog.Filter = "JPEG |*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png|All files (*.*)|*.*";

            //E POR FIM, VERIFICAMOS SE O UTILIZADOR CLICA NO BOTÃO GUARDAR            
            if (saveImageDialog.ShowDialog() == DialogResult.OK)
            {
                //E GRAVA COMO IMAGEM O PRINTSCREEN
                printscreen.Save(saveImageDialog.FileName, ImageFormat.Jpeg);
            }
            #endregion            
        }

        private void btn_backup_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVO FORMULARIO'
            Frm09Backup frm = new Frm09Backup();
            frm.ShowDialog();
            #endregion
        }

        private void btn_fechar_Click(object sender, EventArgs e)
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

        private void img_novodestinolancamento_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btn_cancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmFinanceiroDestinoLancamento frm = new FrmFinanceiroDestinoLancamento();
            frm.ShowDialog();
            #endregion            
        }

        private void img_novodepartamentosetor_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btn_cancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmFinanceiroDepartamentoSetor frm = new FrmFinanceiroDepartamentoSetor();
            frm.ShowDialog();
            #endregion            
        }

        private void img_novodestinooperacao_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btn_cancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmFinanceiroDestinoOperacao frm = new FrmFinanceiroDestinoOperacao();
            frm.ShowDialog();
            #endregion            
        }

        private string FormatadataUS(string dataBR)
        {
            #region 'FORMATAÇÃO DE DATA AMERICANA'
            String tempDia, tempMes, tempAno;
            tempDia = dataBR;
            tempMes = dataBR;
            tempAno = dataBR;
            tempDia = tempDia.Substring(0, 2);
            tempMes = tempMes.Substring(3, 2);
            tempAno = tempAno.Substring(6, 4);

            String dataUS = tempAno + "/" + tempMes + "/" + tempDia;
            return dataUS;
            #endregion
        }

        private string FormatadataBR(string dataUS)
        {
            #region 'FORMATAÇÃO DE DATA BRASIL'
            String tempDia, tempMes, tempAno;
            tempDia = dataUS;
            tempMes = dataUS;
            tempAno = dataUS;
            tempDia = tempDia.Substring(0, 2);
            tempMes = tempMes.Substring(3, 2);
            tempAno = tempAno.Substring(6, 4);

            String dataBR = tempDia + "/" + tempMes + "/" + tempAno;
            return dataBR;
            #endregion
        }

        private void cbo_tipolancamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region "IDENTIFICAÇÃO TIPO LANÇAMENTO"
            if (cbo_tipolancamento.Text == "Receita")
            {
                txt_vlrentrada.Text = "";
                txt_vlrentrada.Enabled = true;
                txt_vlrsaida.Text = "";
                txt_vlrsaida.Text = "0,00";
                txt_vlrsaida.Enabled = false;
                txt_vlrentrada.TextAlign = HorizontalAlignment.Center;
                txt_vlrsaida.TextAlign = HorizontalAlignment.Center;
            }
            else
            {
                if (cbo_tipolancamento.Text == "Despesa")
                    txt_vlrentrada.Text = "";
                txt_vlrentrada.Text = "0,00";
                txt_vlrentrada.Enabled = false;
                txt_vlrsaida.Text = "";
                txt_vlrsaida.Enabled = true;
                txt_vlrentrada.TextAlign = HorizontalAlignment.Center;
                txt_vlrsaida.TextAlign = HorizontalAlignment.Center;
            }
            #endregion            
        }

        private void txt_vlrentrada_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_vlrentrada);
            txt_vlrentrada.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txt_vlrsaida_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_vlrsaida);
            txt_vlrsaida.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txt_vlrentrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_vlrsaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void cbo_mes_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_ano_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_tipolancamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_destinolancamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_departamentosetor_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_contadestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_especie_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region "CONTAGEM DE TEMPO (RELÓGIO)"
            //DECLARANDO VARIÁVEIS
            DateTime Data_Hora;
            //PREENCHE A LABEL COM OS DADOS
            Data_Hora = DateTime.Now;
            lbl_datahora.Text = "Data: " + Data_Hora.ToLongDateString() + "  /  Hora: " + Data_Hora.ToLongTimeString();
            #endregion 
        }

        private void txtmsk_datalancamento_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            #region 'VALIDAR DATA'
            if (e.ReturnValue != null)
            {
                DateTime valor = (DateTime)e.ReturnValue;
                //MessageBox.Show("Validado: " + valor.ToLongDateString());
            }
            else
            {
                MessageBox.Show("Informe uma data válida!");
                txtmsk_datalancamento.Text = "";
                txtmsk_datalancamento.Focus();
            }
            #endregion
        }
    }
}
