using Microsoft.Office.Interop.Excel;
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
using TextBox = System.Windows.Forms.TextBox;

namespace SIGRas
{
    public partial class FrmVendasClientes : Form
    {
        public FrmVendasClientes()
        {
            InitializeComponent();
        }

        #region 'DECLARAÇÃO'
        Boolean estado = false;
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

        #region 'PREENCHE DATAGRID'
        //preecnher dados no listview
        public void preencheListView(string strSql, string tstr)
        {
            #region 'PREENCHE LISTVIEW'
            lvVendasClientes.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    ListViewItem lvitem = new ListViewItem(datareader[0].ToString());

                    for (int i = 1; i <= datareader.FieldCount - 1; i++)
                    {
                        lvitem.SubItems.Add(datareader[i].ToString());
                    }
                    lvVendasClientes.Items.Add(lvitem);
                }
                cmd.Connection.Close(); //Fecha a conexão
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion
        }
        private void preencheTexto(string strSql, string tstr)
        {
            #region "PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO"               
            //PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO - EXEMPLO 1
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT max(ID) FROM tb_vendasclientes";

            try
            {
                if (cmd.ExecuteScalar() == DBNull.Value)
                {
                    //txt_ultid.Text = "1";
                    txtId.TextAlign = HorizontalAlignment.Center;
                }
                else
                {
                    Int32 ra = Convert.ToInt32(cmd.ExecuteScalar());
                    txtId.Text = ra.ToString();
                    txtId.TextAlign = HorizontalAlignment.Center;
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
            cmd1.CommandText = "SELECT * FROM tb_vendasclientes WHERE ID = '" + txtId.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr1 = cmd1.ExecuteReader(); //Executa o comando selecionar                    

            while (dr1.Read())
            {
                //Repassa os dados da tabela para a textbox
                txtId.Text = dr1["ID"].ToString();
                txtDataSistema.Text = dr1["DataSistema"].ToString();
                txtNomeCliente.Text = dr1["NomeCliente"].ToString();
                txtNomeFantasiaApelido.Text = dr1["NomeFantasiaApelido"].ToString();
                txtTipoPessoa.Text = dr1["TipoPessoa"].ToString();
                txtCpfCnpj.Text = dr1["CpfCnpj"].ToString();
                txtTelFixo.Text = dr1["TelFixo"].ToString();
                txtTelCelular.Text = dr1["TelCelular"].ToString();
                cbTipoAtividade.Text = dr1["TipoAtividade"].ToString();
                txtmskDataCredito.Text = dr1["DataCredito"].ToString();
                txtmskDataDebito.Text = dr1["DataDebito"].ToString();
                cbMes.Text = dr1["Mes"].ToString();
                cbAno.Text = dr1["Ano"].ToString();
                cbSituacao.Text = dr1["Situacao"].ToString();
                txtNotaN.Text = dr1["NumeroNota"].ToString();
                cbEspecie.Text = dr1["Especie"].ToString();
                txtVlrEntrada.Text = dr1["ValorCredito"].ToString();
                txtVlrSaida.Text = dr1["ValorDebito"].ToString();
                txtObs.Text = dr1["Observacao"].ToString();
            }
            dr1.Close(); //Fecha o datareader            
            cmd1.Connection.Close(); //Fecha a conexão
            #endregion

            #region 'PREENCHE TEXTO'
            ////Começa o comando para selecionar e preencher
            //MySqlCommand cmd = new MySqlCommand(strSql);
            //cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            //MySqlDataReader datareader;
            //datareader = cmd.ExecuteReader();

            //datareader.Read();
            //{
            //    txtId.Text = datareader["ID"].ToString();
            //    txtDataSistema.Text = datareader["DataSistema"].ToString();
            //    txtNomeCliente.Text = datareader["NomeCliente"].ToString();
            //    txtNomeFantasiaApelido.Text = datareader["NomeFantasiaApelido"].ToString();
            //    txtTipoPessoa.Text = datareader["TipoPessoa"].ToString();
            //    txtCpfCnpj.Text = datareader["CpfCnpj"].ToString();
            //    txtTelFixo.Text = datareader["TelFixo"].ToString();
            //    txtTelCelular.Text = datareader["TelCelular"].ToString();
            //    cbTipoAtividade.Text = datareader["TipoAtividade"].ToString();
            //    txtmskDataCredito.Text = datareader["DataCredito"].ToString();
            //    txtmskDataDebito.Text = datareader["DataDebito"].ToString();
            //    cbMes.Text = datareader["Mes"].ToString();
            //    cbAno.Text = datareader["Ano"].ToString();
            //    cbSituacao.Text = datareader["Situacao"].ToString();
            //    txtNotaN.Text = datareader["NumeroNota"].ToString();
            //    cbEspecie.Text = datareader["Especie"].ToString();
            //    txtVlrEntrada.Text = datareader["ValorCredito"].ToString();
            //    txtVlrSaida.Text = datareader["ValorDebito"].ToString();
            //    txtObs.Text = datareader["Observacao"].ToString();
            //}
            //datareader.Close(); //Fecha o datareader
            //cmd.Connection.Close(); //Fecha a conexão
            #endregion
        }
        private void desabilita(bool a)
        {
            #region 'DESABILITA'
            txtId.Enabled = a;
            txtDataSistema.Enabled = a;
            txtNomeCliente.Enabled = a;
            txtNomeFantasiaApelido.Enabled = a;
            txtTipoPessoa.Enabled = a;
            txtCpfCnpj.Enabled = a;
            txtTelFixo.Enabled = a;
            txtTelCelular.Enabled = a;
            cbTipoAtividade.Enabled = a;
            txtmskDataCredito.Enabled = a;
            txtmskDataDebito.Enabled = a;
            cbMes.Enabled = a;
            cbAno.Enabled = a;
            cbSituacao.Enabled = a;
            txtNotaN.Enabled = a;
            cbEspecie.Enabled = a;
            txtVlrEntrada.Enabled = a;
            txtVlrSaida.Enabled = a;
            txtObs.Enabled = a;
            #endregion
        }
        #endregion

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

        private void FrmVendasClientes_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmVendasClientes_Load(object sender, EventArgs e)
        {
            #region 'LIMPA AS CAIXAS'
            txtId.Text = "";
            txtDataSistema.Text = "";
            txtNomeCliente.Text = "";
            txtNomeFantasiaApelido.Text = "";
            txtTipoPessoa.Text = "";
            txtCpfCnpj.Text = "";
            txtTelFixo.Text = "";
            txtTelCelular.Text = "";
            cbTipoAtividade.Text = "";
            txtmskDataCredito.Text = "";
            txtmskDataDebito.Text = "";
            cbMes.Text = "";
            cbAno.Text = "";
            cbSituacao.Text = "";
            txtNotaN.Text = "";
            cbEspecie.Text = "";
            txtVlrEntrada.Text = "";
            txtVlrSaida.Text = "";
            txtObs.Text = "";
            cbProcurar.Text = "";
            txtProcurar.Text = "";
            #endregion

            #region 'PREENCHE AS COMBOBOX FIXAS'

            #region 'CARREGAR COMBOBOX PROCURAR'
            this.cbProcurar.Items.Clear();
            this.cbProcurar.Items.Add("ID");
            this.cbProcurar.Items.Add("DataSistema");
            this.cbProcurar.Items.Add("NomeCliente");
            this.cbProcurar.Items.Add("NomeFantasiaApelido");
            this.cbProcurar.Items.Add("TipoPessoa");
            this.cbProcurar.Items.Add("CpfCnpj");
            this.cbProcurar.Items.Add("TelFixo");
            this.cbProcurar.Items.Add("TelCelular");
            this.cbProcurar.Items.Add("TipoAtividade");
            this.cbProcurar.Items.Add("DataCredito");
            this.cbProcurar.Items.Add("DataDebito");
            this.cbProcurar.Items.Add("Mes");
            this.cbProcurar.Items.Add("Ano");
            this.cbProcurar.Items.Add("Situacao");
            this.cbProcurar.Items.Add("NumeroNota");
            this.cbProcurar.Items.Add("Especie");
            this.cbProcurar.Items.Add("ValorCredito");
            this.cbProcurar.Items.Add("ValorDebito");
            this.cbProcurar.Items.Add("Observacao");
            #endregion

            #region 'CARREGAR COMBOBOX TIPO ATIVIDADE'
            this.cbTipoAtividade.Items.Clear();
            this.cbTipoAtividade.Items.Add("Crédito");
            this.cbTipoAtividade.Items.Add("Débito");
            #endregion

            #region 'CARREGAR COMBOBOX MES'
            this.cbMes.Items.Clear();
            this.cbMes.Items.Add("Janeiro");
            this.cbMes.Items.Add("Fevereiro");
            this.cbMes.Items.Add("Março");
            this.cbMes.Items.Add("Abril");
            this.cbMes.Items.Add("Maio");
            this.cbMes.Items.Add("Junho");
            this.cbMes.Items.Add("Julho");
            this.cbMes.Items.Add("Agosto");
            this.cbMes.Items.Add("Setembro");
            this.cbMes.Items.Add("Outubro");
            this.cbMes.Items.Add("Novembro");
            this.cbMes.Items.Add("Dezembro");
            #endregion

            #region 'CARREGAR COMBOBOX ANO'
            this.cbAno.Items.Clear();
            this.cbAno.Items.Add("2022");
            this.cbAno.Items.Add("2023");
            this.cbAno.Items.Add("2024");
            this.cbAno.Items.Add("2025");
            this.cbAno.Items.Add("2026");
            this.cbAno.Items.Add("2027");
            this.cbAno.Items.Add("2028");
            this.cbAno.Items.Add("2029");
            this.cbAno.Items.Add("2030");
            this.cbAno.Items.Add("2031");
            this.cbAno.Items.Add("2032");
            this.cbAno.Items.Add("2033");
            this.cbAno.Items.Add("2034");
            this.cbAno.Items.Add("2035");
            this.cbAno.Items.Add("2036");
            this.cbAno.Items.Add("2037");
            this.cbAno.Items.Add("2038");
            this.cbAno.Items.Add("2039");
            this.cbAno.Items.Add("2040");
            this.cbAno.Items.Add("2041");
            this.cbAno.Items.Add("2042");
            this.cbAno.Items.Add("2043");
            this.cbAno.Items.Add("2044");
            this.cbAno.Items.Add("2045");
            this.cbAno.Items.Add("2046");
            this.cbAno.Items.Add("2047");
            this.cbAno.Items.Add("2048");
            this.cbAno.Items.Add("2049");
            this.cbAno.Items.Add("2050");
            #endregion

            #region 'CARREGAR COMBOBOX SITUAÇÃO'
            this.cbSituacao.Items.Clear();
            this.cbSituacao.Items.Add("Atrasada");
            this.cbSituacao.Items.Add("Não Atrasada");
            #endregion

            #region 'CARREGAR COMBOBOX ESPÉCIE'
            this.cbEspecie.Items.Clear();
            this.cbEspecie.Items.Add("Dinheiro");
            this.cbEspecie.Items.Add("Cartões Diversos");
            this.cbEspecie.Items.Add("Cartão Débito");
            this.cbEspecie.Items.Add("Cartão Crédito");
            this.cbEspecie.Items.Add("Cartão Alimentação");
            this.cbEspecie.Items.Add("Cartão Refeição");
            this.cbEspecie.Items.Add("Cartão Ticket");
            this.cbEspecie.Items.Add("Cheque");
            this.cbEspecie.Items.Add("Boleto");
            #endregion

            #endregion

            #region 'ATIVA|DESATIVA AS CAIXAS'
            txtId.Enabled = false;
            txtDataSistema.Enabled = false;
            txtNomeCliente.Enabled = false;
            txtNomeFantasiaApelido.Enabled = false;
            txtTipoPessoa.Enabled = false;
            txtCpfCnpj.Enabled = false;
            txtTelFixo.Enabled = false;
            txtTelCelular.Enabled = false;
            cbTipoAtividade.Enabled = false;
            txtmskDataCredito.Enabled = false;
            txtmskDataDebito.Enabled = false;
            cbMes.Enabled = false;
            cbAno.Enabled = false;
            cbSituacao.Enabled = false;
            txtNotaN.Enabled = false;
            cbEspecie.Enabled = false;
            txtVlrEntrada.Enabled = false;
            txtVlrSaida.Enabled = false;
            txtObs.Enabled = false;
            cbProcurar.Enabled = true;
            txtProcurar.Enabled = true;
            lvVendasClientes.Enabled = true;
            txtVlrTotalCredito.Enabled = false;
            txtVlrTotalDebito.Enabled = false;
            txtVlrTotalFinal.Enabled = false;
            #endregion

            #region 'PREENCHE O LISTVIEW COM DADOS PROCURADOS'
            //preenche o ListView com os dados no evento Load
            //chamando a função preencheListView e PreencheTexto que definimos anteriormente
            desabilita(false);
            try
            {
                string strSQL = "Select * from tb_vendasclientes order by ID";
                string tstr = "tb_vendasclientes";
                preencheListView(strSQL, tstr);
                preencheTexto(strSQL, tstr);
                cbProcurar.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'REALIZA AS SOMAS DENTRO DA LISTVIEW'

            #region 'REALIZA A SOMA TOTAL DE CRÉDITOS DENTRO DA LISTVIEW'
            var totalentrada = 0m;
            for (int i = 0; i < lvVendasClientes.Items.Count; i++)
            {
                totalentrada += decimal.Parse(lvVendasClientes.Items[i].SubItems[16].Text); ;
            }
            txtVlrTotalCredito.Text = totalentrada.ToString("N");
            #endregion

            #region 'REALIZA A SOMA TOTAL DE DÉBITOS DENTRO DA LISTVIEW'
            var totalsaida = 0m;
            for (int i = 0; i < lvVendasClientes.Items.Count; i++)
            {
                totalsaida += decimal.Parse(lvVendasClientes.Items[i].SubItems[17].Text); ;
            }
            txtVlrTotalDebito.Text = totalsaida.ToString("N");
            #endregion

            #region 'REALIZA A SOMA DA DIFERENÇA ENTRE CRÉDITO E DÉBITO'  
            Decimal valor1 = Convert.ToDecimal(txtVlrTotalCredito.Text);
            Decimal valor2 = Convert.ToDecimal(txtVlrTotalDebito.Text);
            Decimal saldo = valor1 - valor2;
            #endregion

            #region 'COLOCA A COR NAS CAIXAS'         
            txtVlrTotalCredito.BackColor = Color.Azure;
            txtVlrTotalDebito.BackColor = Color.LavenderBlush;
            if (saldo >= 0)
            {
                txtVlrTotalFinal.BackColor = Color.Lavender;
            }
            if (saldo < 0)
            {
                txtVlrTotalFinal.BackColor = Color.LavenderBlush;
            }
            #endregion

            #region 'COLOCA A FORMATAÇÃO DE MOEDA''
            //COLOCA A FORMATAÇÃO DE MOEDA NAS CAIXA TOTAL CRÉDITO           
            txtVlrTotalCredito.Text = totalentrada.ToString("C");
            txtVlrTotalCredito.TextAlign = HorizontalAlignment.Center;
            //COLOCA A FORMATAÇÃO DE MOEDA NAS CAIXA TOTAL DÉBITO  
            txtVlrTotalDebito.Text = totalsaida.ToString("C");
            txtVlrTotalDebito.TextAlign = HorizontalAlignment.Center;
            //COLOCA A FORMATAÇÃO DE MOEDA NAS CAIXA TOTAL FINAL  
            txtVlrTotalFinal.Text = saldo.ToString("C");
            txtVlrTotalFinal.TextAlign = HorizontalAlignment.Center;
            #endregion

            #endregion

            #region 'ATIVA|DESATIVA BOTOES'
            this.btNovo.Enabled = true;
            this.btGravar.Enabled = false;
            this.btAlterar.Enabled = false;
            this.btEditar.Enabled = true;
            this.btCancelar.Enabled = false;
            this.btPrintTela.Enabled = true;
            this.btExportar.Enabled = true;
            this.btRelatorio.Enabled = true;
            this.btFechar.Enabled = true;
            btnCerrar.Enabled = true;
            #endregion

            #region 'COLOCA O FOCO'
            btNovo.Focus();
            #endregion
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            #region 'VERIFICA SE A COMBOBOX NÃO ESTÁ VAZIA'
            if (cbProcurar.Text == string.Empty)
            {
                MessageBox.Show("Selecione um Registro na Caixa para Buscar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbProcurar.Focus();
                return;
            }
            #endregion

            #region 'PREENCHE O LISTVIEW'
            //procura os dados que você preencheu no text box e selecionou no criterio da combo
            try
            {
                //string cbtexto = cbo_procurar.Text;
                string strSQL = "Select * from tb_vendasclientes " + "where " + cbProcurar.Text + " like'%" + txtProcurar.Text + "%'";
                string tstr = "tb_vendasclientes";
                preencheListView(strSQL, tstr);
                //preencheTexto(strSQL, tstr, cbtext);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion

            #region 'REALIZA AS SOMAS DENTRO DA LISTVIEW'

            #region 'REALIZA A SOMA TOTAL DE CRÉDITOS DENTRO DA LISTVIEW'
            var totalentrada = 0m;
            for (int i = 0; i < lvVendasClientes.Items.Count; i++)
            {
                totalentrada += decimal.Parse(lvVendasClientes.Items[i].SubItems[16].Text); ;
            }
            txtVlrTotalCredito.Text = totalentrada.ToString("N");
            #endregion

            #region 'REALIZA A SOMA TOTAL DE DÉBITOS DENTRO DA LISTVIEW'
            var totalsaida = 0m;
            for (int i = 0; i < lvVendasClientes.Items.Count; i++)
            {
                totalsaida += decimal.Parse(lvVendasClientes.Items[i].SubItems[17].Text); ;
            }
            txtVlrTotalDebito.Text = totalsaida.ToString("N");
            #endregion

            #region 'REALIZA A SOMA DA DIFERENÇA ENTRE CRÉDITO E DÉBITO'  
            Decimal valor1 = Convert.ToDecimal(txtVlrTotalCredito.Text);
            Decimal valor2 = Convert.ToDecimal(txtVlrTotalDebito.Text);
            Decimal saldo = valor1 - valor2;
            #endregion

            #region 'COLOCA A COR NAS CAIXAS'         
            txtVlrTotalCredito.BackColor = Color.Azure;
            txtVlrTotalDebito.BackColor = Color.LavenderBlush;
            if (saldo >= 0)
            {
                txtVlrTotalFinal.BackColor = Color.Lavender;
            }
            if (saldo < 0)
            {
                txtVlrTotalFinal.BackColor = Color.LavenderBlush;
            }
            #endregion

            #region 'COLOCA A FORMATAÇÃO DE MOEDA''
            //COLOCA A FORMATAÇÃO DE MOEDA NAS CAIXA TOTAL CRÉDITO           
            txtVlrTotalCredito.Text = totalentrada.ToString("C");
            txtVlrTotalCredito.TextAlign = HorizontalAlignment.Center;
            //COLOCA A FORMATAÇÃO DE MOEDA NAS CAIXA TOTAL DÉBITO  
            txtVlrTotalDebito.Text = totalsaida.ToString("C");
            txtVlrTotalDebito.TextAlign = HorizontalAlignment.Center;
            //COLOCA A FORMATAÇÃO DE MOEDA NAS CAIXA TOTAL FINAL  
            txtVlrTotalFinal.Text = saldo.ToString("C");
            txtVlrTotalFinal.TextAlign = HorizontalAlignment.Center;
            #endregion

            #endregion
        }

        private void lvVendasClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 'PREENCHE AS CAIXAS COM DADOS DO LISTVIEW'
            //CARREGA AS CAIXAS
            txtId.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[0].Text);
            txtDataSistema.Text = DateTime.Parse(lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[1].Text).ToString("dd/MM/yyyy");
            txtNomeCliente.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[2].Text);
            txtNomeFantasiaApelido.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[3].Text);
            txtTipoPessoa.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[4].Text);
            txtCpfCnpj.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[5].Text);
            txtTelFixo.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[6].Text);
            txtTelCelular.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[7].Text);
            cbTipoAtividade.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[8].Text);
            txtmskDataCredito.Text = DateTime.Parse(lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[9].Text).ToString("dd/MM/yyyy");
            txtmskDataDebito.Text = DateTime.Parse(lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[10].Text).ToString("dd/MM/yyyy");
            cbMes.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[11].Text);
            cbAno.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[12].Text);
            cbSituacao.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[13].Text);
            txtNotaN.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[14].Text);
            cbEspecie.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[15].Text);
            txtVlrEntrada.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[16].Text);
            txtVlrSaida.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[17].Text);
            txtObs.Text = (lvVendasClientes.Items[lvVendasClientes.FocusedItem.Index].SubItems[18].Text);
            #endregion

            #region 'LIMPA AS CAIXAS'
            this.cbProcurar.Text = "";
            this.txtProcurar.Text = "";
            #endregion
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            #region 'LIMPA AS CAIXAS'
            txtId.Text = "";
            txtDataSistema.Text = "";
            txtNomeCliente.Text = "";
            txtNomeFantasiaApelido.Text = "";
            txtTipoPessoa.Text = "";
            txtCpfCnpj.Text = "";
            txtTelFixo.Text = "";
            txtTelCelular.Text = "";
            cbTipoAtividade.Text = "";
            txtmskDataCredito.Text = "";
            txtmskDataDebito.Text = "";
            cbMes.Text = "";
            cbAno.Text = "";
            cbSituacao.Text = "";
            txtNotaN.Text = "";
            cbEspecie.Text = "";
            txtVlrEntrada.Text = "";
            txtVlrSaida.Text = "";
            txtObs.Text = "";
            cbProcurar.Text = "";
            txtProcurar.Text = "";
            #endregion

            #region "CAPTURAR DATA E HORA SISTEMA"
            //PREENCHENDO AS CAIXAS DATA E HORA COM DADOS ATUAIS
            //CAPTURAR HORA
            //string hora = System.DateTime.Now.ToShortTimeString();
            //CAPTURAR DATA
            string DateTime = System.DateTime.Now.ToShortDateString();
            //PREENCHENDO AS CAIXAS
            txtDataSistema.Text = (DateTime);
            //txt_horasistema.Text = (hora);
            #endregion

            #region "AUTO COMPLETE TEXTBOX"

            #region 'AUTOCOMPLETE TEXTBOX NOME|RAZÃO SOCIAL'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "Select NomeRazaoSocial from tb_cadastromultiplo order by NomeRazaoSocial";
            cmd.ExecuteNonQuery();
            MySqlDataReader datareader;
            datareader = cmd.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

            while (datareader.Read())
            {
                autotext.Add(datareader.GetString(0));
            }
            txtNomeCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtNomeCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNomeCliente.AutoCompleteCustomSource = autotext;
            cmd.Connection.Close(); //Fecha a conexão
            #endregion

            #region 'AUTOCOMPLETE TEXTBOX NOME|RAZÃO SOCIAL'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd1.CommandText = "Select NomeFantasiaApelido from tb_cadastromultiplo order by NomeFantasiaApelido";
            cmd1.ExecuteNonQuery();
            MySqlDataReader datareader1;
            datareader1 = cmd1.ExecuteReader();
            AutoCompleteStringCollection autotext1 = new AutoCompleteStringCollection();

            while (datareader1.Read())
            {
                autotext1.Add(datareader1.GetString(0));
            }
            txtNomeFantasiaApelido.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtNomeFantasiaApelido.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNomeFantasiaApelido.AutoCompleteCustomSource = autotext1;
            cmd1.Connection.Close(); //Fecha a conexão
            #endregion

            #region 'AUTOCOMPLETE TEXTBOX NOME|RAZÃO SOCIAL'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd2.CommandText = "Select Observacao from tb_vendasclientes order by Observacao";
            cmd2.ExecuteNonQuery();
            MySqlDataReader datareader2;
            datareader2 = cmd2.ExecuteReader();
            AutoCompleteStringCollection autotext2 = new AutoCompleteStringCollection();

            while (datareader2.Read())
            {
                autotext2.Add(datareader2.GetString(0));
            }
            txtObs.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtObs.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtObs.AutoCompleteCustomSource = autotext2;
            cmd2.Connection.Close(); //Fecha a conexão
            #endregion

            #endregion

            #region 'ATIVA|DESATIVA AS CAIXAS'
            txtId.Enabled = false;
            txtDataSistema.Enabled = false;
            txtNomeCliente.Enabled = true;
            txtNomeFantasiaApelido.Enabled = true;
            txtTipoPessoa.Enabled = false;
            txtCpfCnpj.Enabled = false;
            txtTelFixo.Enabled = false;
            txtTelCelular.Enabled = false;
            cbTipoAtividade.Enabled = true;
            txtmskDataCredito.Enabled = false;
            txtmskDataDebito.Enabled = false;
            cbMes.Enabled = true;
            cbAno.Enabled = true;
            cbSituacao.Enabled = true;
            txtNotaN.Enabled = true;
            cbEspecie.Enabled = true;
            txtVlrEntrada.Enabled = false;
            txtVlrSaida.Enabled = false;
            txtObs.Enabled = true;
            cbProcurar.Enabled = false;
            txtProcurar.Enabled = false;
            lvVendasClientes.Enabled = false;
            #endregion
            
            #region 'ATIVA|DESATIVA BOTOES'
            this.btNovo.Enabled = false;
            this.btGravar.Enabled = true;
            this.btAlterar.Enabled = false;
            this.btEditar.Enabled = false;
            this.btCancelar.Enabled = true;
            this.btPrintTela.Enabled = false;
            this.btExportar.Enabled = false;
            this.btRelatorio.Enabled = false;
            this.btFechar.Enabled = false;
            btnCerrar.Enabled = false;
            #endregion

            #region 'POSICIONA O FOCO'
            txtNomeCliente.Focus();
            #endregion
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            #region "COMEÇA A GRAVAÇÃO"                
            try
            {
                #region "FAZ AS VERIFICAÇÕES PARA GRAVAR" 

                #region 'DADOS DO CADASTRO'
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtNomeCliente.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nome cliente para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNomeCliente.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtNomeFantasiaApelido.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nome fantasia|apelido para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNomeFantasiaApelido.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtTipoPessoa.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tipo pessoa para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTipoPessoa.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtCpfCnpj.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo CPF|CNPJ para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtCpfCnpj.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtTelFixo.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tel.fixo para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTelFixo.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtTelCelular.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tel.celular para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTelCelular.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbTipoAtividade.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tipo atividade para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbTipoAtividade.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txtmskDataCredito.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data crédito para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmskDataCredito.Text = "";
                    this.txtmskDataCredito.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txtmskDataDebito.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data débito para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmskDataDebito.Text = "";
                    this.txtmskDataDebito.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbMes.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo mês para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbMes.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbAno.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo ano para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbAno.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbSituacao.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo situação para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbSituacao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtNotaN.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Nº Nota para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNotaN.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbEspecie.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo espécie para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbEspecie.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtVlrEntrada.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo valor crédito para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtVlrEntrada.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtVlrSaida.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo valor débito para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtVlrSaida.Focus();
                    return;
                }
                #endregion

                #endregion

                #region 'FORMATAÇÃO DA DATA'
                string DataSistemaUS = FormatadataUS(txtDataSistema.Text);
                string DataCreditoUS = FormatadataUS(txtmskDataCredito.Text);
                string DataDebitoUS = FormatadataUS(txtmskDataDebito.Text);
                #endregion

                #region "COMEÇA A GRAVAÇÃO"
                //Começa o comando para gravar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "Insert Into tb_vendasclientes(DataSistema,NomeCliente,NomeFantasiaApelido,TipoPessoa," +
                    "CpfCnpj,TelFixo,TelCelular,TipoAtividade,DataCredito,DataDebito," +
                    "Mes,Ano,Situacao,NumeroNota,Especie,ValorCredito,ValorDebito,Observacao) Values";
                cmd.CommandText += "('" + DataSistemaUS + "','" + txtNomeCliente.Text + "','" + txtNomeFantasiaApelido.Text + "','" + txtTipoPessoa.Text + "'," +
                    "'" + txtCpfCnpj.Text + "','" + txtTelFixo.Text + "','" + txtTelCelular.Text + "'," +
                    "'" + cbTipoAtividade.Text + "','" + DataCreditoUS + "','" + DataDebitoUS + "'," +
                    "'" + cbMes.Text + "','" + cbAno.Text + "','" + cbSituacao.Text + "'," +
                    "'" + txtNotaN.Text + "','" + cbEspecie.Text + "','" + txtVlrEntrada.Text + "'," +
                    "'" + txtVlrSaida.Text + "','" + txtObs.Text + "')";
                cmd.ExecuteNonQuery();
                cmd.Connection.Close(); //Fecha a conexão
                #endregion

                #region "MENSAGEM"
                //MENSAGEM DE EXECUÇÃO
                MessageBox.Show("Dados Cadastrados com Sucesso!"); //Mensagem                       
                #endregion

                #region "EXECUTA O BOTÃO"
                //EXECUTA O BOTÃO LIMPAR
                btCancelar.PerformClick();
                #endregion

                #region "COLOCA O FOCO"
                btNovo.Focus();
                #endregion
            }
            catch (Exception erro)
            {
                #region 'MENSAGEM DE ERRO'
                MessageBox.Show(erro.Message);
                #endregion
            }
            #endregion

            #region 'ATUALIZAR TELA COM INICIALIZAÇÃO
            FrmVendasClientes_Load(sender, e);
            #endregion

            #region "COLOCA O FOCO"
            btNovo.Focus();
            #endregion
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            #region "COMEÇA A ALTERAÇÃO"                    
            try
            {
                #region "FAZ AS VERIFICAÇÕES PARA GRAVAR" 

                #region 'DADOS DO CADASTRO'
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtNomeCliente.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nome cliente para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNomeCliente.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtNomeFantasiaApelido.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nome fantasia|apelido para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNomeFantasiaApelido.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtTipoPessoa.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tipo pessoa para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTipoPessoa.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtCpfCnpj.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo CPF|CNPJ para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtCpfCnpj.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtTelFixo.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tel.fixo para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTelFixo.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtTelCelular.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tel.celular para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTelCelular.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbTipoAtividade.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tipo atividade para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbTipoAtividade.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txtmskDataCredito.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data crédito para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmskDataCredito.Text = "";
                    this.txtmskDataCredito.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txtmskDataDebito.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data débito para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmskDataDebito.Text = "";
                    this.txtmskDataDebito.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbMes.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo mês para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbMes.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbAno.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo ano para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbAno.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbSituacao.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo situação para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbSituacao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtNotaN.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Nº Nota para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNotaN.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbEspecie.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo espécie para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbEspecie.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtVlrEntrada.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo valor crédito para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtVlrEntrada.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txtVlrSaida.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo valor débito para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtVlrSaida.Focus();
                    return;
                }
                #endregion

                #endregion

                #region 'FORMATAÇÃO DA DATA'
                string DataSistemaUS = FormatadataUS(txtDataSistema.Text);
                string DataCreditoUS = FormatadataUS(txtmskDataCredito.Text);
                string DataDebitoUS = FormatadataUS(txtmskDataDebito.Text);
                #endregion

                #region "COMEÇA A ALTERAÇÃO"
                //Começa o comando para alterar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "update tb_vendasclientes set " +
                    "DataSistema = '" + DataSistemaUS + "',NomeCliente = '" + txtNomeCliente.Text + "',NomeFantasiaApelido = '" + txtNomeFantasiaApelido.Text + "'," +
                    "TipoPessoa = '" + txtTipoPessoa.Text + "',CpfCnpj = '" + txtCpfCnpj.Text + "',TelFixo = '" + txtTelFixo.Text + "'," +
                    "TelCelular = '" + txtTelCelular.Text + "',TipoAtividade = '" + cbTipoAtividade.Text + "',DataCredito = '" + DataCreditoUS + "'," +
                    "DataDebito = '" + DataDebitoUS + "',Mes = '" + cbMes.Text + "',Ano = '" + cbAno.Text + "'," +
                    "Situacao = '" + cbSituacao.Text + "',NumeroNota = '" + txtNotaN.Text + "',Especie = '" + cbEspecie.Text + "'," +
                    "ValorCredito = '" + txtVlrEntrada.Text + "',ValorDebito = '" + txtVlrSaida.Text + "',Observacao = '" + txtObs.Text + "' Where ID = " + txtId.Text + "";
                cmd.ExecuteNonQuery();
                cmd.Connection.Close(); //Fecha a conexão
                #endregion

                #region "MENSAGEM"
                MessageBox.Show("Dados Alterados com Sucesso!!!");
                #endregion

                #region "EXECUTA O BOTÃO"
                btCancelar.PerformClick();
                #endregion

                #region "COLOCA O FOCO"
                btNovo.Focus();
                #endregion
            }
            catch (Exception erro)
            {
                #region 'MENSAGEM DE ERRO'
                MessageBox.Show(erro.Message);
                #endregion
            }
            #endregion

            #region 'ATUALIZAR TELA COM INICIALIZAÇÃO
            FrmVendasClientes_Load(sender, e);
            #endregion

            #region "COLOCA O FOCO"
            btNovo.Focus();
            #endregion
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            #region 'LIMPA AS CAIXAS'
            //LIMPAR CAIXAS                    
            this.cbProcurar.Text = "";
            this.txtProcurar.Text = "";
            #endregion

            #region 'ATIVA|DESATIVA AS CAIXAS'
            txtId.Enabled = false;
            txtDataSistema.Enabled = false;
            txtNomeCliente.Enabled = true;
            txtNomeFantasiaApelido.Enabled = true;
            txtTipoPessoa.Enabled = false;
            txtCpfCnpj.Enabled = false;
            txtTelFixo.Enabled = false;
            txtTelCelular.Enabled = false;
            cbTipoAtividade.Enabled = true;
            txtmskDataCredito.Enabled = false;
            txtmskDataDebito.Enabled = false;
            cbMes.Enabled = true;
            cbAno.Enabled = true;
            cbSituacao.Enabled = true;
            txtNotaN.Enabled = true;
            cbEspecie.Enabled = true;
            txtVlrEntrada.Enabled = false;
            txtVlrSaida.Enabled = false;
            txtObs.Enabled = true;
            cbProcurar.Enabled = false;
            txtProcurar.Enabled = false;
            lvVendasClientes.Enabled = false;
            #endregion
            
            #region 'ATIVA/DESATIVA BOTOES'
            this.btNovo.Enabled = false;
            this.btGravar.Enabled = false;
            this.btAlterar.Enabled = true;
            this.btEditar.Enabled = false;
            this.btCancelar.Enabled = true;
            this.btPrintTela.Enabled = false;
            this.btExportar.Enabled = false;
            this.btRelatorio.Enabled = false;
            this.btFechar.Enabled = false;
            btnCerrar.Enabled = false;

            estado = true;
            #endregion
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            #region 'LIMPA AS CAIXAS'
            txtId.Text = "";
            txtDataSistema.Text = "";
            txtNomeCliente.Text = "";
            txtNomeFantasiaApelido.Text = "";
            txtTipoPessoa.Text = "";
            txtCpfCnpj.Text = "";
            txtTelFixo.Text = "";
            txtTelCelular.Text = "";
            cbTipoAtividade.Text = "";
            txtmskDataCredito.Text = "";
            txtmskDataDebito.Text = "";
            cbMes.Text = "";
            cbAno.Text = "";
            cbSituacao.Text = "";
            txtNotaN.Text = "";
            cbEspecie.Text = "";
            txtVlrEntrada.Text = "";
            txtVlrSaida.Text = "";
            txtObs.Text = "";
            cbProcurar.Text = "";
            txtProcurar.Text = "";
            #endregion

            #region 'ATIVA|DESATIVA AS CAIXAS'
            txtId.Enabled = false;
            txtDataSistema.Enabled = false;
            txtNomeCliente.Enabled = false;
            txtNomeFantasiaApelido.Enabled = false;
            txtTipoPessoa.Enabled = false;
            txtCpfCnpj.Enabled = false;
            txtTelFixo.Enabled = false;
            txtTelCelular.Enabled = false;
            cbTipoAtividade.Enabled = false;
            txtmskDataCredito.Enabled = false;
            txtmskDataDebito.Enabled = false;
            cbMes.Enabled = false;
            cbAno.Enabled = false;
            cbSituacao.Enabled = false;
            txtNotaN.Enabled = false;
            cbEspecie.Enabled = false;
            txtVlrEntrada.Enabled = false;
            txtVlrSaida.Enabled = false;
            txtObs.Enabled = false;
            cbProcurar.Enabled = true;
            txtProcurar.Enabled = true;
            lvVendasClientes.Enabled = true;
            #endregion

            #region 'ATIVA|DESATIVA BOTOES'
            this.btNovo.Enabled = true;
            this.btGravar.Enabled = false;
            this.btAlterar.Enabled = false;
            this.btEditar.Enabled = true;
            this.btCancelar.Enabled = false;
            this.btPrintTela.Enabled = true;
            this.btExportar.Enabled = true;
            this.btRelatorio.Enabled = true;
            this.btFechar.Enabled = true;
            btnCerrar.Enabled = true;
            #endregion

            #region 'PREENCHE O LISTVIEW COM DADOS PROCURADOS'
            //preenche o ListView com os dados no evento Load
            //chamando a função preencheListView e PreencheTexto que definimos anteriormente
            desabilita(false);
            try
            {
                string strSQL = "Select * from tb_vendasclientes order by ID";
                string tstr = "tb_vendasclientes";
                preencheListView(strSQL, tstr);
                preencheTexto(strSQL, tstr);
                cbProcurar.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'ATUALIZAR TELA COM INICIALIZAÇÃO
            FrmVendasClientes_Load(sender, e);
            #endregion

            #region 'COLOCA O FOCO'
            btNovo.Focus();
            #endregion                        
        }

        private void btPrintTela_Click(object sender, EventArgs e)
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

        private void btExportar_Click(object sender, EventArgs e)
        {
            #region 'EXPORTAR DADOS DO LISTVIEW PARA EXCEL'
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    ws.Cells[1, 1] = "ID";
                    ws.Cells[1, 2] = "Data Sistema";
                    ws.Cells[1, 3] = "Nome Cliente";
                    ws.Cells[1, 4] = "Nome Fantasia|Apelido";
                    ws.Cells[1, 5] = "Tipo Pessoa";
                    ws.Cells[1, 6] = "CPF|CNPJ";
                    ws.Cells[1, 7] = "Tel.Fixo";
                    ws.Cells[1, 8] = "Tel.Celular";
                    ws.Cells[1, 9] = "Tipo Atividade";
                    ws.Cells[1, 10] = "Data Crédito";
                    ws.Cells[1, 11] = "Data Débito";
                    ws.Cells[1, 12] = "Mês";
                    ws.Cells[1, 13] = "Ano";
                    ws.Cells[1, 14] = "Situação";
                    ws.Cells[1, 15] = "Nº Nota";
                    ws.Cells[1, 16] = "Espécie";
                    ws.Cells[1, 17] = "Valor Crédito";
                    ws.Cells[1, 18] = "Valor Débito";
                    ws.Cells[1, 19] = "Observação";
                    int i = 2;
                    foreach (ListViewItem item in lvVendasClientes.Items)
                    {
                        ws.Cells[i, 1] = item.SubItems[0].Text;
                        ws.Cells[i, 2] = item.SubItems[1].Text;
                        ws.Cells[i, 3] = item.SubItems[2].Text;
                        ws.Cells[i, 4] = item.SubItems[3].Text;
                        ws.Cells[i, 5] = item.SubItems[4].Text;
                        ws.Cells[i, 6] = item.SubItems[5].Text;
                        ws.Cells[i, 7] = item.SubItems[6].Text;
                        ws.Cells[i, 8] = item.SubItems[7].Text;
                        ws.Cells[i, 9] = item.SubItems[8].Text;
                        ws.Cells[i, 10] = item.SubItems[9].Text;
                        ws.Cells[i, 11] = item.SubItems[10].Text;
                        ws.Cells[i, 12] = item.SubItems[11].Text;
                        ws.Cells[i, 13] = item.SubItems[12].Text;
                        ws.Cells[i, 14] = item.SubItems[13].Text;
                        ws.Cells[i, 15] = item.SubItems[14].Text;
                        ws.Cells[i, 16] = item.SubItems[15].Text;
                        ws.Cells[i, 17] = item.SubItems[16].Text;
                        ws.Cells[i, 18] = item.SubItems[17].Text;
                        ws.Cells[i, 19] = item.SubItems[18].Text;
                        i++;
                    }
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    app.Quit();
                    MessageBox.Show("Dados exportados com sucesso!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            #endregion
        }

        private void btRelatorio_Click(object sender, EventArgs e)
        {
            #region "ABRINDO NOVA TELA"
            this.Hide();
            FrmVendasClientesRelatorios frm = new FrmVendasClientesRelatorios();
            frm.ShowDialog();
            #endregion            
        }

        private void btFechar_Click(object sender, EventArgs e)
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
            #region 'FORMATAÇÃO DE DATA BRASILEIRA'
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

        private void img_novocliente_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btCancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmCadastroMultiplos frm = new FrmCadastroMultiplos();
            frm.ShowDialog();
            #endregion            
        }

        private void txtNomeCliente_Leave(object sender, EventArgs e)
        {
            #region 'PREENCHE AS CAIXAS AO SAIR DA CAIXA COM O FOCO'
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_cadastromultiplo WHERE NomeRazaoSocial = '" + txtNomeCliente.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                //txt_Id.Text = dr["ID"].ToString();
                txtNomeCliente.Text = dr["NomeRazaoSocial"].ToString();
                txtNomeFantasiaApelido.Text = dr["NomeFantasiaApelido"].ToString();
                txtTipoPessoa.Text = dr["TipoPessoa"].ToString();
                if (txtTipoPessoa.Text == "Pessoa Física")
                {
                    txtCpfCnpj.Text = dr["Cpf"].ToString();
                }
                if (txtTipoPessoa.Text == "Pessoa Jurídica")
                {
                    txtCpfCnpj.Text = dr["Cnpj"].ToString();
                }
                txtTelFixo.Text = dr["TelFixo"].ToString();
                txtTelCelular.Text = dr["TelCelular1"].ToString();
            }
            cmd.Connection.Close();//Fecha a conexão
            #endregion

            #region 'COLOCA O FOCO'
            cbTipoAtividade.Focus();
            #endregion
        }

        private void txtNomeFantasiaApelido_Leave(object sender, EventArgs e)
        {
            #region 'PREENCHE AS CAIXAS AO SAIR DA CAIXA COM O FOCO'
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_cadastromultiplo WHERE NomeFantasiaApelido = '" + txtNomeFantasiaApelido.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                //txt_Id.Text = dr["ID"].ToString();
                txtNomeCliente.Text = dr["NomeRazaoSocial"].ToString();
                txtNomeFantasiaApelido.Text = dr["NomeFantasiaApelido"].ToString();
                txtTipoPessoa.Text = dr["TipoPessoa"].ToString();
                if (txtTipoPessoa.Text == "Pessoa Física")
                {
                    txtCpfCnpj.Text = dr["Cpf"].ToString();
                }
                if (txtTipoPessoa.Text == "Pessoa Jurídica")
                {
                    txtCpfCnpj.Text = dr["Cnpj"].ToString();
                }
                txtTelFixo.Text = dr["TelFixo"].ToString();
                txtTelCelular.Text = dr["TelCelular1"].ToString();
            }
            cmd.Connection.Close();//Fecha a conexão
            #endregion

            #region 'COLOCA O FOCO'
            cbTipoAtividade.Focus();
            #endregion
        }

        private void cbTipoAtividade_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 'VERIFICA SE A CAIXA ESTÁ ATIVA PARA ALTERAR'
            if (txtNomeCliente.Enabled == true)
            {
                #region "IDENTIFICAÇÃO TIPO LANÇAMENTO (ATIVIDADE)"
                if (cbTipoAtividade.Text == "Crédito")
                {
                    //CAIXA DATA CRÉDITO
                    txtmskDataCredito.Text = "";
                    txtmskDataCredito.Enabled = true;
                    //CAIXA DATA DÉBITO
                    txtmskDataDebito.Text = "";
                    txtmskDataDebito.Text = "01/01/2023";
                    txtmskDataDebito.Enabled = false;
                    //CAIXA CRÉDITO
                    txtVlrEntrada.Text = "";
                    txtVlrEntrada.Enabled = true;
                    //CAIXA DÉBITO
                    txtVlrSaida.Text = "";
                    txtVlrSaida.Text = "0,00";
                    txtVlrSaida.Enabled = false;
                    //FORMATA O ALINHAMENTO
                    txtVlrEntrada.TextAlign = HorizontalAlignment.Center;
                    txtVlrSaida.TextAlign = HorizontalAlignment.Center;
                }
                else
                {
                    if (cbTipoAtividade.Text == "Débito")
                    {
                        //CAIXA DATA CRÉDITO
                        txtmskDataCredito.Text = "";
                        txtmskDataCredito.Text = "01/01/2023";
                        txtmskDataCredito.Enabled = false;
                        //CAIXA DATA DÉBITO
                        txtmskDataDebito.Enabled = true;
                        txtmskDataDebito.Text = "";
                        //CAIXA CRÉDITO
                        txtVlrEntrada.Text = "";
                        txtVlrEntrada.Text = "0,00";
                        txtVlrEntrada.Enabled = false;
                        //CAIXA DÉBITO
                        txtVlrSaida.Text = "";
                        txtVlrSaida.Enabled = true;
                        //FORMATA O ALINHAMENTO
                        txtVlrEntrada.TextAlign = HorizontalAlignment.Center;
                        txtVlrSaida.TextAlign = HorizontalAlignment.Center;
                    }                    
                }
                #endregion
            }
            #endregion
        }

        private void txtVlrEntrada_TextChanged(object sender, EventArgs e)
        {
            #region 'BUSCANDO A REFERÊNCIA DE FORMATAÇÃO'            
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txtVlrEntrada);
            txtVlrEntrada.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txtVlrSaida_TextChanged(object sender, EventArgs e)
        {
            #region 'BUSCANDO A REFERÊNCIA DE FORMATAÇÃO'            
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txtVlrSaida);
            txtVlrSaida.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txtVlrEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txtVlrSaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void cbTipoAtividade_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbEspecie_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbProcurar_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void txtmskDataCredito_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
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
                txtmskDataCredito.Text = "";
                txtmskDataCredito.Focus();
            }
            #endregion
        }

        private void txtmskDataDebito_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
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
                txtmskDataDebito.Text = "";
                txtmskDataDebito.Focus();
            }
            #endregion
        }
    }
}
