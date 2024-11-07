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
    public partial class FrmCadastroMultiplosConsulta : Form
    {
        public FrmCadastroMultiplosConsulta()
        {
            InitializeComponent();
        }

        #region "PREENCHE DATAGRID"
        //preecnher dados no listview
        public void preencheListView(string strSql, string tstr)
        {
            #region 'PREENCHE LISTVIEW'
            lvw_cadastromultiplos.Items.Clear();
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
                    lvw_cadastromultiplos.Items.Add(lvitem);
                }
                lb_totalregistros.Text = lvw_cadastromultiplos.Items.Count.ToString();
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

        private void FrmCadastroMultiplosConsulta_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmCadastroMultiplosConsulta_Load(object sender, EventArgs e)
        {
            #region 'CARREGAR AS COMBOBOX'
            //CARREGAR COMBOBOX PROCURAR
            this.cbo_procurar.Items.Clear();
            this.cbo_procurar.Items.Add("ID");
            this.cbo_procurar.Items.Add("Status");
            this.cbo_procurar.Items.Add("TipoCadastro");
            this.cbo_procurar.Items.Add("TipoPessoa");
            this.cbo_procurar.Items.Add("NomeRazaoSocial");
            this.cbo_procurar.Items.Add("NomeFantasiaApelido");
            this.cbo_procurar.Items.Add("Cnpj");
            this.cbo_procurar.Items.Add("InscricaoEstadual");
            this.cbo_procurar.Items.Add("InscricaoMunicipal");
            this.cbo_procurar.Items.Add("Cpf");
            this.cbo_procurar.Items.Add("Rg");
            this.cbo_procurar.Items.Add("Naturalidade");
            this.cbo_procurar.Items.Add("EstadoCivil");
            this.cbo_procurar.Items.Add("CtpsNumero");
            this.cbo_procurar.Items.Add("PisPasep");
            this.cbo_procurar.Items.Add("TituloNumero");
            this.cbo_procurar.Items.Add("ValeTransporte");
            this.cbo_procurar.Items.Add("Funcao");
            this.cbo_procurar.Items.Add("NomeMae");
            this.cbo_procurar.Items.Add("NomePai");
            #endregion

            #region 'PREENCHE O LISTVIEW'
            //preenche o ListView com os dados no evento Load
            //chamando a função preencheListView e PreencheTexto que definimos anteriormente
            //desabilita(false);
            try
            {
                string strSQL = "Select * from tb_cadastromultiplo order by ID";
                string tstr = "tb_cadastromultiplo";
                preencheListView(strSQL, tstr);
                //preencheTexto(strSQL, tstr);
                cbo_procurar.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'ATIVA/DESATIVA OS BOTÕES'
            this.btn_carregar.Enabled = false;
            #endregion

            #region 'LIMPA AS CAIXAS'
            //LIMPAR CAIXAS
            cbo_procurar.Text = "";
            txt_procurar.Text = "";
            #endregion
        }

        private void cbo_procurar_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 'ATIVA/DESATIVA OS BOTÕES'
            btn_carregar.Enabled = false;
            #endregion
        }

        private void txt_procurar_TextChanged(object sender, EventArgs e)
        {
            #region 'ATIVA/DESATIVA OS BOTÕES'
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
                string strSQL = "Select * from tb_cadastromultiplo " + "where " + cbo_procurar.Text + " like'%" + txt_procurar.Text + "%'";
                string tstr = "tb_cadastromultiplo";
                preencheListView(strSQL, tstr);
                //preencheTexto(strSQL, tstr, cbtext);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion
        }

        private void lvw_cadastromultiplos_SelectedIndexChanged(object sender, EventArgs e)
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
            FrmCadastroMultiplosConsulta_Load(sender, e);
            #endregion

            #region 'ATIVA/DESATIVA OS BOTÕES'
            btn_carregar.Enabled = false;
            #endregion
        }

        private void btn_carregar_Click(object sender, EventArgs e)
        {
            #region "ESTANCIA O NOVO FORMULÁRIO"
            //CÓDIGO PARA PREENCHER AS CAIXAS COM DADOS DO BANCO
            //PARA ISSO TEM QUE TORNAR AS CAIXAS DO FORMÚLARIO PÚBLICAS
            FrmCadastroMultiplos frm = new FrmCadastroMultiplos();
            #endregion

            #region 'CARREGA OS DADOS EM OUTRO FORMULÁRIO'
            //CONTINUAÇÃO DO CÓDIGO PARA PREENCHER AS CAIXAS
            frm.txt_id.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[0].Text);
            frm.txt_id.TextAlign = HorizontalAlignment.Center;
            frm.txt_datacadastro.Text = DateTime.Parse(lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[1].Text).ToString("dd/MM/yyyy");//convertendo a data
            //frm.txt_datasistema.Text = (lvw_financeiro.Items[lvw_financeiro.FocusedItem.Index].SubItems[1].Text);
            frm.cbo_status.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[2].Text);
            frm.cbo_tipocadastro.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[3].Text);
            frm.cbo_tipopessoa.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[4].Text);
            frm.txt_nomerazao.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[5].Text);
            frm.txt_nomefantasia.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[6].Text);
            frm.txt_mskdataabertura.Text = DateTime.Parse(lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[7].Text).ToString("dd/MM/yyyy");//convertendo a data
            //frm.txt_mskdataabertura.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[7].Text);
            frm.txt_mskcnpj.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[8].Text);
            frm.txt_inscricaoestadual.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[9].Text);
            frm.txt_inscricaomunicipal.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[10].Text);
            frm.txt_mskdatanascimento.Text = DateTime.Parse(lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[11].Text).ToString("dd/MM/yyyy");//convertendo a data
            //frm.txt_mskdatanascimento.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[11].Text);
            frm.txt_mskcpf.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[12].Text);
            frm.txt_rg.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[13].Text);
            frm.txt_mskdataexprg.Text = DateTime.Parse(lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[14].Text).ToString("dd/MM/yyy");//convertendo a data
            //frm.txt_mskdataexprg.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[14].Text);
            frm.txt_nacionalidade.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[15].Text);
            frm.txt_naturalidade.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[16].Text);
            frm.cbo_estadocivil.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[17].Text);
            frm.cbo_grauinstrucao.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[18].Text);
            frm.txt_ctps.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[19].Text);
            frm.txt_seriectps.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[20].Text);
            frm.txt_mskdataexpctps.Text = DateTime.Parse(lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[21].Text).ToString("dd/MM/yyy");//convertendo a data
            //frm.txt_mskdataexpctps.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[21].Text);
            frm.txt_pispasep.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[22].Text);
            frm.txt_tituloeleitor.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[23].Text);
            frm.txt_titulozona.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[24].Text);
            frm.txt_titulosecao.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[25].Text);
            frm.cbo_valetransporte.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[26].Text);
            frm.cbo_tipoadmissao.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[27].Text);
            frm.txt_funcao.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[28].Text);
            frm.txt_salarioregistrado.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[29].Text);
            frm.txt_salarioregistrado.TextAlign = HorizontalAlignment.Center;
            frm.txt_salariototal.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[30].Text);
            frm.txt_salariototal.TextAlign = HorizontalAlignment.Center;
            frm.txt_nomemae.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[31].Text);
            frm.txt_nomepai.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[32].Text);
            frm.txt_narmario.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[33].Text);
            frm.txt_mskdatacomecou.Text = DateTime.Parse(lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[34].Text).ToString("dd/MM/yyy");//convertendo a data
            //frm.txt_mskdatacomecou.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[34].Text);
            frm.txt_mskdataadmissao.Text = DateTime.Parse(lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[35].Text).ToString("dd/MM/yyy");//convertendo a data
            //frm.txt_mskdataadmissao.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[35].Text);
            frm.txt_mskdatademissao.Text = DateTime.Parse(lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[36].Text).ToString("dd/MM/yyy");//convertendo a data
            //frm.txt_mskdatademissao.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[36].Text);
            frm.txt_mskcep.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[37].Text);
            frm.cbo_tipologradouro.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[38].Text);
            frm.txt_endereco.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[39].Text);
            frm.txt_numero.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[40].Text);
            frm.txt_complemento.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[41].Text);
            frm.txt_bairro.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[42].Text);
            frm.txt_cidade.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[43].Text);
            frm.cbo_estado.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[44].Text);
            frm.txt_msktelfixo.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[45].Text);
            frm.txt_msktelfixocomercial.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[46].Text);
            frm.txt_msktelcelular1.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[47].Text);
            frm.txt_msktelcelular2.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[48].Text);
            frm.txt_email.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[49].Text);
            frm.txt_contato.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[50].Text);
            frm.txt_obs.Text = (lvw_cadastromultiplos.Items[lvw_cadastromultiplos.FocusedItem.Index].SubItems[51].Text);
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
                FrmCadastroMultiplos frm = new FrmCadastroMultiplos();
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
