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
    public partial class FrmFinanceiroConsulta : Form
    {       
        public FrmFinanceiroConsulta()
        {
            InitializeComponent();
        }
        
        #region "PREENCHE DATAGRID"
        //preecnher dados no listview
        public void preencheListView(string strSql, string tstr)
        {
            #region 'PREENCHE LISTVIEW'
            lvw_financeiro.Items.Clear();
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
                    lvw_financeiro.Items.Add(lvitem);
                }
                txt_totalregistros.Text = lvw_financeiro.Items.Count.ToString();
                txt_totalregistros.TextAlign = HorizontalAlignment.Center;

                cmd.Connection.Close(); //Fecha a conexão
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
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

        private void FrmFinanceiroConsulta_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmFinanceiroConsulta_Load(object sender, EventArgs e)
        {
            #region 'CARREGAR AS COMBOBOX'
            //CARREGAR COMBOBOX PROCURAR
            this.cbo_procurar.Items.Clear();
            this.cbo_procurar.Items.Add("ID");
            this.cbo_procurar.Items.Add("Mes");
            this.cbo_procurar.Items.Add("Ano");
            this.cbo_procurar.Items.Add("TipoLancamento");
            this.cbo_procurar.Items.Add("DestinoLancamento");
            this.cbo_procurar.Items.Add("DepartamentoSetor");
            this.cbo_procurar.Items.Add("ContaDestino");
            this.cbo_procurar.Items.Add("Data");
            this.cbo_procurar.Items.Add("Especie");
            this.cbo_procurar.Items.Add("DescricaoLancamento");
            #endregion

            #region 'PREENCHE O LISTVIEW'
            //preenche o ListView com os dados no evento Load
            //chamando a função preencheListView e PreencheTexto que definimos anteriormente
            //desabilita(false);
            try
            {
                string strSQL = "Select * from tb_financeiro order by ID";
                string tstr = "tb_financeiro";
                preencheListView(strSQL, tstr);
                //preencheTexto(strSQL, tstr);
                cbo_procurar.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'ATIVA/DESATIVA AS CAIXAS'
            //DESATIVAR/ATIVAR CAIXAS
            this.txt_totalregistros.Enabled = false;
            #endregion

            #region 'ATIVA/DESATIVA OS BOTÕES'
            this.btn_carregar.Enabled = false;
            #endregion

            #region 'LIMPA AS CAIXAS'
            //LIMPAR CAIXAS
            cbo_procurar.Text = "";
            txt_procurar.Text = "";
            #endregion

            #region 'ATIVA/DESATIVA AS CAIXAS'
            txt_totalentradas.Enabled = false;
            txt_totalsaidas.Enabled = false;
            txt_saldofinal.Enabled = false;
            txt_totalregistros.Enabled = false;
            #endregion

            #region 'REALIZA A SOMA TOTAL DE ENTRADAS DENTRO DA LISTVIEW'
            var totalentrada = 0m;
            for (int i = 0; i < lvw_financeiro.Items.Count; i++)
            {
                totalentrada += decimal.Parse(lvw_financeiro.Items[i].SubItems[12].Text); ;
            }
            txt_totalentradas.Text = totalentrada.ToString("N");
            #endregion

            #region 'REALIZA A SOMA TOTAL DE SAÍDAS DENTRO DA LISTVIEW'
            var totalsaida = 0m;
            for (int i = 0; i < lvw_financeiro.Items.Count; i++)
            {
                totalsaida += decimal.Parse(lvw_financeiro.Items[i].SubItems[13].Text); ;
            }
            txt_totalsaidas.Text = totalsaida.ToString("N");
            #endregion

            #region 'REALIZA A SOMA DA DIFERENÇA ENTRE ENTRADAS E SAÍDAS'  
            Decimal valor1 = Convert.ToDecimal(txt_totalentradas.Text);
            Decimal valor2 = Convert.ToDecimal(txt_totalsaidas.Text);
            Decimal saldo = valor1 - valor2;
            #endregion

            #region 'COLOCA A FORMATAÇÃO DE MOEDA NAS CAIXAS E MOSTRA O RESULTADO DA SOMA'
            txt_saldofinal.Text = saldo.ToString("C");
            txt_saldofinal.TextAlign = HorizontalAlignment.Center;
            txt_totalentradas.Text = totalentrada.ToString("C");
            txt_totalentradas.TextAlign = HorizontalAlignment.Center;
            txt_totalsaidas.Text = totalsaida.ToString("C");
            txt_totalsaidas.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void cbo_procurar_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 'ATIVA/DESATIVA OS BOTÕES'
            //DESATIVAR/ATIVAR
            btn_carregar.Enabled = false;
            #endregion
        }

        private void txt_procurar_TextChanged(object sender, EventArgs e)
        {
            #region 'ATIVA/DESATIVA OS BOTÕES'
            //DESATIVAR/ATIVAR
            btn_carregar.Enabled = false;
            #endregion

            #region 'VERIFICA SE A COMBOBOX NÃO ESTÁ VAZIA'
            if (cbo_procurar.Text == string.Empty)
            {
                MessageBox.Show("Selecione um Registro na Caixa para Buscar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbo_procurar.Focus();
                return;
            }
            #endregion

            #region 'PREENCHE O LISTVIEW'
            //procura os dados que você preencheu no text box e selecionou no criterio da combo
            try
            {
                //string cbtexto = cbo_procurar.Text;
                string strSQL = "Select * from tb_financeiro " + "where " + cbo_procurar.Text + " like'%" + txt_procurar.Text + "%'";
                string tstr = "tb_financeiro";
                preencheListView(strSQL, tstr);
                //preencheTexto(strSQL, tstr, cbtext);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion

            #region 'FAZ A SOMA DE VALORES E MOSTRA OS RESULTADOS'
            txt_totalentradas.Enabled = false;
            txt_totalsaidas.Enabled = false;
            txt_saldofinal.Enabled = false;
            txt_totalregistros.Enabled = false;
            #endregion

            #region 'REALIZA A SOMA TOTAL DE ENTRADAS DENTRO DA LISTVIEW'
            var totalentrada = 0m;
            for (int i = 0; i < lvw_financeiro.Items.Count; i++)
            {
                totalentrada += decimal.Parse(lvw_financeiro.Items[i].SubItems[12].Text); ;
            }
            txt_totalentradas.Text = totalentrada.ToString("N");
            #endregion

            #region 'REALIZA A SOMA TOTAL DE SAÍDAS DENTRO DA LISTVIEW'
            var totalsaida = 0m;
            for (int i = 0; i < lvw_financeiro.Items.Count; i++)
            {
                totalsaida += decimal.Parse(lvw_financeiro.Items[i].SubItems[13].Text); ;
            }
            txt_totalsaidas.Text = totalsaida.ToString("N");
            #endregion

            #region 'REALIZA A SOMA DA DIFERENÇA ENTRE ENTRADAS E SAÍDAS'
            Decimal valor1 = Convert.ToDecimal(txt_totalentradas.Text);
            Decimal valor2 = Convert.ToDecimal(txt_totalsaidas.Text);
            Decimal saldo = valor1 - valor2;
            #endregion

            #region 'COLOCA A FORMATAÇÃO DE MOEDA NAS CAIXAS E MOSTRA O RESULTADO DA SOMA'
            txt_saldofinal.Text = saldo.ToString("C");
            txt_saldofinal.TextAlign = HorizontalAlignment.Center;
            txt_totalentradas.Text = totalentrada.ToString("C");
            txt_totalentradas.TextAlign = HorizontalAlignment.Center;
            txt_totalsaidas.Text = totalsaida.ToString("C");
            txt_totalsaidas.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void lvw_financeiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 'ATIVA/DESATIVA OS BOTÕES'
            btn_carregar.Enabled = true;
            #endregion
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            #region 'LIMPA AS CAIXAS'
            //LIMPAR CAIXAS
            cbo_procurar.Text = "";
            txt_procurar.Text = "";
            #endregion

            #region 'ATUALIZA INICIALIZANDO A TELA'
            FrmFinanceiroConsulta_Load(sender, e);
            #endregion

            #region 'ATIVA/DESATIVA OS BOTÕES'
            //DESATIVAR/ATIVAR
            btn_carregar.Enabled = false;
            #endregion
        }

        private void btn_carregar_Click(object sender, EventArgs e)
        {            
            #region "ESTANCIA O NOVO FORMULÁRIO"
            //CÓDIGO PARA PREENCHER AS CAIXAS COM DADOS DO BANCO
            //PARA ISSO TEM QUE TORNAR AS CAIXAS DO FORMÚLARIO PÚBLICAS
            FrmFinanceiro frm = new FrmFinanceiro();
            #endregion

            #region 'CARREGA OS DADOS EM OUTRO FORMULÁRIO'
            //CONTINUAÇÃO DO CÓDIGO PARA PREENCHER AS CAIXAS
            frm.txt_id.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[0].Text);
            frm.txt_id.TextAlign = HorizontalAlignment.Center;
            frm.txt_datasistema.Text = DateTime.Parse(lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[1].Text).ToString("dd/MM/yyy");//convertendo a data
            //frm.txt_datasistema.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[1].Text);
            frm.txt_horasistema.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[2].Text);
            frm.cbo_mes.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[3].Text);
            frm.cbo_ano.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[4].Text);
            frm.cbo_tipolancamento.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[5].Text);
            frm.cbo_destinolancamento.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[6].Text);
            frm.cbo_departamentosetor.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[7].Text);
            frm.cbo_contadestino.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[8].Text);
            frm.txtmsk_datalancamento.Text = DateTime.Parse(lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[9].Text).ToString("dd/MM/yyy");//convertendo a data
            //frm.txtmsk_datalancamento.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[9].Text);
            frm.cbo_especie.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[10].Text);
            frm.txt_descricaolancamento.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[11].Text);
            frm.txt_vlrentrada.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[12].Text);
            frm.txt_vlrentrada.TextAlign = HorizontalAlignment.Center;
            frm.txt_vlrsaida.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[13].Text);
            frm.txt_vlrsaida.TextAlign = HorizontalAlignment.Center;
            frm.txt_obs.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[14].Text);
            #endregion

            #region "ATIVA/DESATIVA OS BOTÕES"
            frm.btn_novo.Enabled = false;
            frm.btn_gravar.Enabled = false;
            frm.btn_alterar.Enabled = false;
            frm.btn_editar.Enabled = true;
            frm.btn_cancelar.Enabled = true;
            frm.btn_consultar.Enabled = false;
            frm.btn_relatorio.Enabled = false;
            frm.btn_printtela.Enabled = false;
            frm.btn_backup.Enabled = false;
            frm.btn_fechar.Enabled = false;
            #endregion

            #region "FECHA ESSE FORMULÁRIO E ABRE O NOVO"
            //FECHA O FORMULARIO
            this.Hide();
            //ABRE O FORMULÁRIO PARA EDITAR
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
                this.Hide();
                FrmFinanceiro frm = new FrmFinanceiro();
                frm.ShowDialog();
                //this.Close();
            }
            #endregion
        }

        private void cbo_procurar_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }
    }
}
