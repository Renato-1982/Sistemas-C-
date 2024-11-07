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
    public partial class FrmNFConsultaTotal : Form
    {
        public FrmNFConsultaTotal()
        {
            InitializeComponent();
        }

        #region "PREENCHE DATAGRID"
        //preecnher dados no listview
        public void preencheListView(string strSql, string tstr)
        {
            #region 'PREENCHE LISTVIEW'
            lvw_nftotal.Items.Clear();
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
                    lvw_nftotal.Items.Add(lvitem);
                }
                txt_totalregistros.Text = lvw_nftotal.Items.Count.ToString();
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

        private void FrmNFConsultaTotal_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmNFConsultaTotal_Load(object sender, EventArgs e)
        {
            #region "CARREGA A COMBOBOX"
            //CARREGAR COMBOBOX PROCURAR
            this.cbo_procurar.Items.Add("IDOperacao");
            this.cbo_procurar.Items.Add("Modelo");
            this.cbo_procurar.Items.Add("Documentonr");
            this.cbo_procurar.Items.Add("Emissao");
            this.cbo_procurar.Items.Add("Referencia");
            this.cbo_procurar.Items.Add("DescricaoFornecedor");
            this.cbo_procurar.Items.Add("Estado");
            this.cbo_procurar.Items.Add("FormaPagamento");
            #endregion

            #region "PREENCHE O LISTVIEW"
            //preenche o ListView com os dados no evento Load
            //chamando a função preencheListView e PreencheTexto que definimos anteriormente
            //desabilita(false);
            try
            {
                string strSQL = "Select * from tb_nfetotal order by ID";
                string tstr = "tb_nfetotal";
                preencheListView(strSQL, tstr);
                //preencheTexto(strSQL, tstr);
                cbo_procurar.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }

            #region 'LIMPAR CAIXAS'
            cbo_procurar.Text = "";
            txt_procurar.Text = "";
            #endregion

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
            txt_saldofinal.Enabled = false;
            txt_totalregistros.Enabled = false;
            #endregion

            #region 'REALIZA A SOMA TOTAL DE ENTRADAS DENTRO DA LISTVIEW'
            var totalentrada = 0m;
            for (int i = 0; i < lvw_nftotal.Items.Count; i++)
            {
                totalentrada += decimal.Parse(lvw_nftotal.Items[i].SubItems[17].Text); ;
            }
            txt_saldofinal.Text = totalentrada.ToString("N");
            #endregion

            #region 'COLOCA A FORMATAÇÃO DE MOEDA NAS CAIXAS E MOSTRA O RESULTADO DA SOMA'
            decimal saldo = Convert.ToDecimal(txt_saldofinal.Text);
            txt_saldofinal.Text = saldo.ToString("C");
            txt_saldofinal.TextAlign = HorizontalAlignment.Center;
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
                string strSQL = "Select * from tb_nfetotal " + "where " + cbo_procurar.Text + " like'%" + txt_procurar.Text + "%'";
                string tstr = "tb_nfetotal";
                preencheListView(strSQL, tstr);
                //preencheTexto(strSQL, tstr, cbtext);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion

            #region 'REALIZA A SOMA TOTAL DE ENTRADAS DENTRO DA LISTVIEW'
            var totalentrada = 0m;
            for (int i = 0; i < lvw_nftotal.Items.Count; i++)
            {
                totalentrada += decimal.Parse(lvw_nftotal.Items[i].SubItems[17].Text); ;
            }
            txt_saldofinal.Text = totalentrada.ToString("N");
            #endregion

            #region 'COLOCA A FORMATAÇÃO DE MOEDA NAS CAIXAS E MOSTRA O RESULTADO DA SOMA'
            decimal saldo = Convert.ToDecimal(txt_saldofinal.Text);
            txt_saldofinal.Text = saldo.ToString("C");
            txt_saldofinal.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void lvw_nftotal_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 'ATIVA/DESATIVA OS BOTÕES'
            btn_carregar.Enabled = false;
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
            FrmNFConsultaTotal_Load(sender, e);
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
            FrmNF frm = new FrmNF();
            #endregion

            #region 'CARREGA OS DADOS EM OUTRO FORMULÁRIO'
            //CONTINUAÇÃO DO CÓDIGO PARA PREENCHER AS CAIXAS
            frm.txt_idoperacao.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[1].Text);
            frm.txt_descricaooperacao.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[2].Text);
            frm.txt_modelodoc.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[3].Text);
            frm.txt_especiedoc.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[4].Text);
            frm.txt_seriedoc.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[5].Text);
            frm.txt_numerodoc.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[6].Text);
            frm.txtmsk_dtemissaodoc.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[7].Text);
            frm.txtmsk_dtreferenciadoc.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[8].Text);
            //frm.txtmsk_dtemissaodoc.Text = DateTime.Parse(lvw_nfentradas.Items[lvw_nfentradas.FocusedItem.Index].SubItems[6].Text).ToString("dd/MM/yyy");//convertendo a data
            //frm.txtmsk_dtreferenciadoc.Text = DateTime.Parse(lvw_nfentradas.Items[lvw_nfentradas.FocusedItem.Index].SubItems[7].Text).ToString("dd/MM/yyy");//convertendo a data
            frm.txt_idfornecedor.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[9].Text);
            frm.txt_descricaofornecedor.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[10].Text);
            frm.cbo_estadofornecedor.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[11].Text);
            frm.cbo_formapgdoc.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[12].Text);
            frm.cbo_prazopgdoc.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[13].Text);            
            frm.txt_descontototaldoc.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[14].Text);
            frm.txt_acrescimototaldoc.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[15].Text);
            frm.txt_qnttotalprodutosdoc.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[16].Text);
            frm.txt_vlrtotaldoc.Text = (lvw_nftotal.Items[lvw_nftotal.FocusedItem.Index].SubItems[17].Text);
            #endregion

            #region "ATIVA/DESATIVA OS BOTÕES"
            frm.btNovo.Enabled = false;
            frm.btGravar.Enabled = false;
            frm.btAlterar.Enabled = false;
            frm.btEditar.Enabled = true;
            frm.btCancelar.Enabled = true;
            frm.btConsultar.Enabled = false;
            frm.btRelatorio.Enabled = false;
            frm.btFechar.Enabled = false;
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
                FrmNF frm = new FrmNF();
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

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            #region "ABRINDO NOVA TELA"
            this.Hide();
            FrmNFConsulta frm = new FrmNFConsulta();
            frm.ShowDialog();
            #endregion  
        }
    }
}
