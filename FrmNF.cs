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
    public partial class FrmNF : Form
    {
        #region "1-CAMINHO BANCO"
        //CONEXÃO COM O BANCO MSQL
        MySqlConnection cn = new MySqlConnection(@"SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;");
        //private string StrMySql;
        int i;
        #endregion

        public FrmNF()
        {
            InitializeComponent();
        }

        #region "PREENCHENDO COMBOBOX COM DADOS DO BANCO"
        //-----------------------------------------------------------------------
        //PREENCHENDO COMBOBOX
        public void FillComboPagamentoFormas(string strSql, string tstr)
        {
            #region 'CAIXA PAGAMENTO FORMAS'
            //DECLARAÇÃO PARA PREENCHER A COMBOBOX
            cbo_formapgdoc.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    cbo_formapgdoc.Items.Add(datareader[0]);
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
        public void FillComboPagamentoPrazos(string strSql, string tstr)
        {
            #region 'CAIXA PAGAMENTO PRAZOS'
            //DECLARAÇÃO PARA PREENCHER A COMBOBOX
            cbo_prazopgdoc.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    cbo_prazopgdoc.Items.Add(datareader[0]);
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
        #endregion

        #region 'FORMATAÇÃO MOEDA'
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

        private void FrmNF_KeyDown(object sender, KeyEventArgs e)
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

        private void tc_nf_DrawItem(object sender, DrawItemEventArgs e)
        {
            #region 'MUDA A COR DA GUIA AO CLICAR'

            //FORMATAÇÃO DA TABCONTROL'
            TabPage CurrentTab = tc_nf.TabPages[e.Index];
            Rectangle ItemRect = tc_nf.GetTabRect(e.Index);
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
            if (tc_nf.Alignment == TabAlignment.Left || tc_nf.Alignment == TabAlignment.Right)
            {
                float RotateAngle = 90;
                if (tc_nf.Alignment == TabAlignment.Left)
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

        private void FrmNF_Load(object sender, EventArgs e)
        {
            #region "PREENCHE COMBOBOX"
            //CARREGAR COMBOBOX ESTADO            
            this.cbo_estadofornecedor.Items.Add("AC");
            this.cbo_estadofornecedor.Items.Add("AL");
            this.cbo_estadofornecedor.Items.Add("AP");
            this.cbo_estadofornecedor.Items.Add("AM");
            this.cbo_estadofornecedor.Items.Add("BA");
            this.cbo_estadofornecedor.Items.Add("CE");
            this.cbo_estadofornecedor.Items.Add("DF");
            this.cbo_estadofornecedor.Items.Add("ES");
            this.cbo_estadofornecedor.Items.Add("GO");
            this.cbo_estadofornecedor.Items.Add("MA");
            this.cbo_estadofornecedor.Items.Add("MT");
            this.cbo_estadofornecedor.Items.Add("MS");
            this.cbo_estadofornecedor.Items.Add("MG");
            this.cbo_estadofornecedor.Items.Add("PA");
            this.cbo_estadofornecedor.Items.Add("PB");
            this.cbo_estadofornecedor.Items.Add("PR");
            this.cbo_estadofornecedor.Items.Add("PE");
            this.cbo_estadofornecedor.Items.Add("PI");
            this.cbo_estadofornecedor.Items.Add("RJ");
            this.cbo_estadofornecedor.Items.Add("RN");
            this.cbo_estadofornecedor.Items.Add("RS");
            this.cbo_estadofornecedor.Items.Add("RO");
            this.cbo_estadofornecedor.Items.Add("RR");
            this.cbo_estadofornecedor.Items.Add("SC");
            this.cbo_estadofornecedor.Items.Add("SP");
            this.cbo_estadofornecedor.Items.Add("SE");
            this.cbo_estadofornecedor.Items.Add("TO");
            #endregion

            #region "AUTOCOMPLETA TEXTBOX"

            #region 'AUTOCOMPLETE TEXTBOX DESCRIÇÃO OPERAÇÃO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "Select DescricaoOperacoes from tb_nfeoperacoes order by DescricaoOperacoes";
            cmd.ExecuteNonQuery();
            MySqlDataReader datareader;
            datareader = cmd.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

            while (datareader.Read())
            {
                autotext.Add(datareader.GetString(0));
            }
            txt_descricaooperacao.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_descricaooperacao.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_descricaooperacao.AutoCompleteCustomSource = autotext;
            cmd.Connection.Close(); //Fecha a conexão 
            #endregion

            #region 'AUTOCOMPLETE TEXTBOX FORNECEDOR'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd1.CommandText = "Select NomeRazaoSocial from tb_cadastromultiplo order by NomeRazaoSocial";
            cmd1.ExecuteNonQuery();
            MySqlDataReader datareader1;
            datareader1 = cmd1.ExecuteReader();
            AutoCompleteStringCollection autotext1 = new AutoCompleteStringCollection();

            while (datareader1.Read())
            {
                autotext1.Add(datareader1.GetString(0));
            }
            txt_descricaofornecedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_descricaofornecedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_descricaofornecedor.AutoCompleteCustomSource = autotext1;
            cmd1.Connection.Close(); //Fecha a conexão 
            #endregion

            #region 'AUTOCOMPLETE TEXTBOX PRODUTO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd2.CommandText = "Select DescricaoProduto from tb_produtos order by DescricaoProduto";
            cmd2.ExecuteNonQuery();
            MySqlDataReader datareader2;
            datareader2 = cmd2.ExecuteReader();
            AutoCompleteStringCollection autotext2 = new AutoCompleteStringCollection();

            while (datareader2.Read())
            {
                autotext2.Add(datareader2.GetString(0));
            }
            txt_descricaoproduto.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_descricaoproduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_descricaoproduto.AutoCompleteCustomSource = autotext2;
            cmd2.Connection.Close(); //Fecha a conexão 
            #endregion

            #endregion
                        
            #region "CARREGAR COMBOBOX COM DADOS DO BANCO"            
            //CARREGAR COMBOBOX PAGAMENTO FORMAS
            try
            {
                string strSQL = "Select DescricaoFormasPagamento  from tb_formaspagamento order by DescricaoFormasPagamento ";
                string tstr = "tb_formaspagamento";
                FillComboPagamentoFormas(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }

            //CARREGAR COMBOBOX PAGAMENTO PRAZOS
            try
            {
                string strSQL = "Select DescricaoPrazosPagamento from tb_prazospagamento order by DescricaoPrazosPagamento";
                string tstr = "tbl_dadospagamentoprazos";
                FillComboPagamentoPrazos(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region "LIMPA AS CAIXAS"
            /*
            //DOCUMENTO
            txt_idoperacao.Text = "";
            txt_descricaooperacao.Text = "";
            txt_modelodoc.Text = "";
            txt_especiedoc.Text = "";
            txt_seriedoc.Text = "";
            txt_numerodoc.Text = "";
            txtmsk_dtemissaodoc.Text = "";
            txtmsk_dtreferenciadoc.Text = "";
            txt_idfornecedor.Text = "";
            txt_descricaofornecedor.Text = "";
            cbo_estadofornecedor.Text = "";
            cbo_formapgdoc.Text = "";
            cbo_prazopgdoc.Text = "";
            //ITENS
            lbIdProduto.Text = "";
            txt_idproduto.Text = "";
            txt_descricaoproduto.Text = "";
            txt_unidadevenda.Text = "";
            txt_precounitproduto.Text = "";
            txt_quantidadeproduto.Text = "";
            txt_descontoproduto.Text = "";
            txt_acrescimoproduto.Text = "";
            txt_vlrtotalproduto.Text = "";
            lvw_produtosdoc.Text = "";
            lvw_produtosdoc.Clear();
            //TOTAIS
            txt_descontototaldoc.Text = "";
            txt_acrescimototaldoc.Text = "";
            txt_qnttotalprodutosdoc.Text = "";
            txt_vlrtotaldoc.Text = "";
            */
            #endregion

            #region "ADICIONA A LISTVIEW"
            //Adicionar colunas
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[0].Text = "Cód.";
            this.lvw_produtosdoc.Columns[0].Width = 50;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[1].Text = "Descrição Produto";
            this.lvw_produtosdoc.Columns[1].Width = 300;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[2].Text = "Un. Venda";
            this.lvw_produtosdoc.Columns[2].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[3].Text = "Preço";
            this.lvw_produtosdoc.Columns[3].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[4].Text = "Qnt.";
            this.lvw_produtosdoc.Columns[4].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[5].Text = "Desconto";
            this.lvw_produtosdoc.Columns[5].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[6].Text = "Acréscimo";
            this.lvw_produtosdoc.Columns[6].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[7].Text = "Valor Total";
            this.lvw_produtosdoc.Columns[7].Width = 120;
            #endregion
                       
            #region 'PREENCHE AS CAIXAS'
            txt_quantidadeproduto.Text = "0,000";
            txt_precounitproduto.Text = "0,00";
            txt_descontoproduto.Text = "0,00";
            txt_acrescimoproduto.Text = "0,00";
            txt_vlrtotalproduto.Text = "0,00";
            txt_descontototaldoc.Text = "0,00";
            txt_acrescimototaldoc.Text = "0,00";
            txt_qnttotalprodutosdoc.Text = "00";
            txt_vlrtotaldoc.Text = "0,00";
            #endregion

            #region "DESATIVA AS CAIXAS"
            //DOCUMENTO
            txt_idoperacao.Enabled = false;
            txt_descricaooperacao.Enabled = false;
            txt_modelodoc.Enabled = false;
            txt_especiedoc.Enabled = false;
            txt_seriedoc.Enabled = false;
            txt_numerodoc.Enabled = false;
            txtmsk_dtemissaodoc.Enabled = false;
            txtmsk_dtreferenciadoc.Enabled = false;
            txt_idfornecedor.Enabled = false;
            txt_descricaofornecedor.Enabled = false;
            cbo_estadofornecedor.Enabled = false;
            cbo_formapgdoc.Enabled = false;
            cbo_prazopgdoc.Enabled = false;
            //ITENS
            lbIdProduto.Enabled = false;
            txt_idproduto.Enabled = false;
            txt_descricaoproduto.Enabled = false;
            txt_unidadevenda.Enabled = false;
            txt_precounitproduto.Enabled = false;
            txt_quantidadeproduto.Enabled = false;
            txt_descontoproduto.Enabled = false;
            txt_acrescimoproduto.Enabled = false;
            txt_vlrtotalproduto.Enabled = false;
            lvw_produtosdoc.Enabled = false;
            //TOTAIS
            txt_descontototaldoc.Enabled = false;
            txt_acrescimototaldoc.Enabled = false;
            txt_qnttotalprodutosdoc.Enabled = false;
            txt_vlrtotaldoc.Enabled = false;
            #endregion

            #region "ATIVA/DESATIVA BOTOES"
            //ATIVA/DESATIVA BOTOES
            btNovo.Enabled = true;
            btGravar.Enabled = false;
            btAlterar.Enabled = false;
            btEditar.Enabled = false;
            btCancelar.Enabled = false;
            btConsultar.Enabled = true;
            btRelatorio.Enabled = true;
            btFechar.Enabled = true;
            btnCerrar.Enabled = true;
            btAddProduto.Enabled = false;
            btExcProduto.Enabled = false;
            #endregion

            #region 'COLOCA O FOCO'
            //COLOCA O FOCUS
            btNovo.Focus();
            #endregion
        }

        private void GravarNf()
        {
            //COMANDO NÃO USA A CLASSE DE CONEXAO (GRAVAR ITENS)
            #region "GRAVA NF"

            #region 'VERIFICA SE A CONEXÃO COM O BANCO NÃO ESTÁ ABERTA E ABRE'
            string StrCon = "SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;"; //Caminho do banco
            MySqlConnection cn = new MySqlConnection(StrCon);
            MySqlCommand comm = new MySqlCommand();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;

            //Verifica se a conexão já está aberta
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open(); //Abre a conexão
            }
            #endregion

            #region 'LAÇO DE REPETIÇÃO PARA GRAVAR'
            //Faz o laço de repetição para gravar e atualizar item por item
            foreach (ListViewItem item in lvw_produtosdoc.Items)
            {
                #region 'DECLARANDO VARIAVEIS E GRAVANDO DADOS NELAS'
                //Declarando Variáveis e criando as strings
                string NFTidoperacao = txt_idoperacao.Text;
                string NFTdescroperacao = txt_descricaooperacao.Text;
                string NFTmodelo = txt_modelodoc.Text;
                string NFTespecie = txt_especiedoc.Text;
                string NFTserie = txt_seriedoc.Text;
                string NFTnumero = txt_numerodoc.Text;
                string NFTemissao = txtmsk_dtemissaodoc.Text;
                string NFTreferencia = txtmsk_dtreferenciadoc.Text;
                string NFTidfornecedor = txt_idfornecedor.Text;
                string NFTdescrfornecedor = txt_descricaofornecedor.Text;
                string NFTestadofornecedor = cbo_estadofornecedor.Text;
                string NFTformapagamento = cbo_formapgdoc.Text;
                string NFTprazopagamento = cbo_prazopgdoc.Text;
                string NFTidproduto = item.SubItems[0].Text;
                string NFTdescrproduto = item.SubItems[1].Text;
                string NFTunvendaproduto = item.SubItems[2].Text;
                string NFTunprecoproduto = item.SubItems[3].Text;
                string NFTqntproduto = item.SubItems[4].Text;
                string NFTdescoproduto = item.SubItems[5].Text;
                string NFTacrescimoproduto = item.SubItems[6].Text;
                string NFTvlrtotalproduto = item.SubItems[7].Text;
                string NFTdescontototal = txt_descontototaldoc.Text;
                string NFTacrescimototal = txt_acrescimototaldoc.Text;
                string NFTqntprodutostotal = txt_qnttotalprodutosdoc.Text;
                string NFTvlrdocumentototal = txt_vlrtotaldoc.Text;
                #endregion

                #region 'FORMATAÇÃO DA DATA'
                //BUSCA A FORMATAÇÃO DA DATA
                string NFTemissaoUS = FormatadataUS(NFTemissao);
                string NFTreferenciaUS = FormatadataUS(NFTreferencia);
                #endregion

                #region 'COMANDO PARA GRAVAR'
                //Comando para inserir no banco
                comm.CommandText = "Insert Into tb_nfe(IDOperacao, DescricaoOperacao, Modelo, Especie, Serie, Documentonr, " +
                    "Emissao, Referencia, IDFornecedor, DescricaoFornecedor, EstadoFornecedor, FormaPagamento, PrazoPagamento, " +
                    "IDProduto, DescricaoProduto, UnVenda, PrecoProduto, QntProduto, DescontoProduto, AcrescimoProduto, " +
                    "VlrTotalProduto, DescontoTotal, AcrescimoTotal, QntProdutosTotal, VlrTotalDocumento) Values";
                comm.CommandText += "('" + NFTidoperacao + "','" + NFTdescroperacao + "','" + NFTmodelo + "','" + NFTespecie + "'," +
                    "'" + NFTserie + "','" + NFTnumero + "','" + NFTemissaoUS + "','" + NFTreferenciaUS + "','" + NFTidfornecedor + "'," +
                    "'" + NFTdescrfornecedor + "','" + NFTestadofornecedor + "','" + NFTformapagamento + "','" + NFTprazopagamento + "'," +
                    "'" + NFTidproduto + "','" + NFTdescrproduto + "','" + NFTunvendaproduto + "','" + NFTunprecoproduto + "'," +
                    "'" + NFTqntproduto + "','" + NFTdescoproduto + "','" + NFTacrescimoproduto + "','" + NFTvlrtotalproduto + "'," +
                    "'" + NFTdescontototal + "','" + NFTacrescimototal + "','" + NFTqntprodutostotal + "','" + NFTvlrdocumentototal + "')";
                comm.ExecuteNonQuery();
                #endregion
            }
            #endregion

            #region 'MENSAGEM'
            //MENSAGEM DE EXECUÇÃO
            MessageBox.Show("NF Gravada com Sucesso!!!");
            #endregion

            #region 'FECHA A CONEXÃO'
            //Fecha a conexão
            comm.Connection.Close(); //Fecha a conexão
            cn.Close();
            #endregion

            #endregion
        }

        private void GravarNfTotal()
        {
            #region "GRAVA NF TOTAL"            

            #region 'DECLARANDO VARIAVEIS'
            //Declarando Variáveis
            string NFidoperacao;
            string NFdescroperacao;
            string NFmodelo;
            string NFespecie;
            string NFserie;
            string NFdocumentonr;
            string NFemissao;
            string NFreferencia;
            string NFidfornecedor;
            string NFdescrfornecedor;
            string NFestadofornecedor;
            string NFformapagamento;
            string NFprazopagamento;
            string NFdescontototal;
            string NFacrescimototal;
            string NFqntprodutostotal;
            string NFvlrtotaldocumento;
            #endregion

            #region 'ARMAZENA DADOS NAS VARIAVEIS'
            //Armazena os dados em variáveis
            NFidoperacao = txt_idoperacao.Text;
            NFdescroperacao = txt_descricaooperacao.Text;
            NFmodelo = txt_modelodoc.Text;
            NFespecie = txt_especiedoc.Text;
            NFserie = txt_seriedoc.Text;
            NFdocumentonr = txt_numerodoc.Text;
            NFemissao = txtmsk_dtemissaodoc.Text;
            NFreferencia = txtmsk_dtreferenciadoc.Text;
            NFidfornecedor = txt_idfornecedor.Text;
            NFdescrfornecedor = txt_descricaofornecedor.Text;
            NFestadofornecedor = cbo_estadofornecedor.Text;
            NFformapagamento = cbo_formapgdoc.Text;
            NFprazopagamento = cbo_prazopgdoc.Text;
            NFdescontototal = txt_descontototaldoc.Text;
            NFacrescimototal = txt_acrescimototaldoc.Text;
            NFqntprodutostotal = txt_qnttotalprodutosdoc.Text;
            NFvlrtotaldocumento = txt_vlrtotaldoc.Text;
            #endregion

            #region 'TRYCATCH PARA GRAVAR'
            try
            {
                #region 'FORMATAÇÃO DA DATA'
                //BUSCA A FORMATAÇÃO DA DATA
                string NFemissaoUS = FormatadataUS(NFemissao);
                string NFreferenciaUS = FormatadataUS(NFreferencia);
                #endregion

                #region 'COMANDO PARA GRAVAR TOTAL'
                //Começa o comando para gravar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "Insert Into tb_nfetotal(IDOperacao, DescricaoOperacao, " +
                    "Modelo, Especie, Serie, Documentonr, Emissao, Referencia, IDFornecedor, " +
                    "DescricaoFornecedor, EstadoFornecedor, FormaPagamento, PrazoPagamento, " +
                    "DescontoTotal, AcrescimoTotal, QuantidadeProdutos, TotalDocumento) Values";
                cmd.CommandText += "('" + NFidoperacao + "','" + NFdescroperacao + "','" + NFmodelo + "'," +
                    "'" + NFespecie + "','" + NFserie + "','" + NFdocumentonr + "','" + NFemissaoUS + "'," +
                    "'" + NFreferenciaUS + "','" + NFidfornecedor + "','" + NFdescrfornecedor + "'," +
                    "'" + NFestadofornecedor + "','" + NFformapagamento + "','" + NFprazopagamento + "'," +
                    "'" + NFdescontototal + "','" + NFacrescimototal + "','" + NFqntprodutostotal + "'," +
                    "'" + NFvlrtotaldocumento + "')";
                cmd.ExecuteNonQuery();
                cmd.Connection.Close(); //Fecha a conexão 
                #endregion
            }
            catch (Exception ex)
            {
                #region 'MENSAGEM'
                MessageBox.Show(ex.Message);
                #endregion
            }
            finally
            {
                #region 'COMANDO PARA GRAVAR ÍTEMS'
                //EXECUTA O COMANDO
                GravarNfItens();
                #endregion

                #region 'COMANDO PARA GRAVAR NF TOTAL'
                //EXECUTA O COMANDO
                GravarNf();
                #endregion

                #region "LIMPA AS CAIXAS"
                //DOCUMENTO
                txt_idoperacao.Text = "";
                txt_descricaooperacao.Text = "";
                txt_modelodoc.Text = "";
                txt_especiedoc.Text = "";
                txt_seriedoc.Text = "";
                txt_numerodoc.Text = "";
                txtmsk_dtemissaodoc.Text = "";
                txtmsk_dtreferenciadoc.Text = "";
                txt_idfornecedor.Text = "";
                txt_descricaofornecedor.Text = "";
                cbo_estadofornecedor.Text = "";
                cbo_formapgdoc.Text = "";
                cbo_prazopgdoc.Text = "";
                //ITENS
                txt_idproduto.Text = "";
                txt_descricaoproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
                txt_quantidadeproduto.Text = "";
                txt_descontoproduto.Text = "";
                txt_acrescimoproduto.Text = "";
                txt_vlrtotalproduto.Text = "";
                lvw_produtosdoc.Text = "";
                lvw_produtosdoc.Clear();
                //TOTAIS
                txt_descontototaldoc.Text = "";
                txt_acrescimototaldoc.Text = "";
                txt_qnttotalprodutosdoc.Text = "";
                txt_vlrtotaldoc.Text = "";
                #endregion

                #region "ADICIONA A LISTVIEW"
                //Adicionar colunas
                this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
                this.lvw_produtosdoc.Columns[0].Text = "Cód.";
                this.lvw_produtosdoc.Columns[0].Width = 50;
                this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
                this.lvw_produtosdoc.Columns[1].Text = "Descrição Produto";
                this.lvw_produtosdoc.Columns[1].Width = 300;
                this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
                this.lvw_produtosdoc.Columns[2].Text = "Un. Venda";
                this.lvw_produtosdoc.Columns[2].Width = 70;
                this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
                this.lvw_produtosdoc.Columns[3].Text = "Preço";
                this.lvw_produtosdoc.Columns[3].Width = 70;
                this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
                this.lvw_produtosdoc.Columns[4].Text = "Qnt.";
                this.lvw_produtosdoc.Columns[4].Width = 70;
                this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
                this.lvw_produtosdoc.Columns[5].Text = "Desconto";
                this.lvw_produtosdoc.Columns[5].Width = 70;
                this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
                this.lvw_produtosdoc.Columns[6].Text = "Acréscimo";
                this.lvw_produtosdoc.Columns[6].Width = 70;
                this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
                this.lvw_produtosdoc.Columns[7].Text = "Valor Total";
                this.lvw_produtosdoc.Columns[7].Width = 120;
                #endregion

                #region "DESATIVA AS CAIXAS"
                //DESATIVA AS CAIXAS
                //DOCUMENTO
                txt_idoperacao.Enabled = false;
                txt_descricaooperacao.Enabled = false;
                txt_modelodoc.Enabled = false;
                txt_especiedoc.Enabled = false;
                txt_seriedoc.Enabled = false;
                txt_numerodoc.Enabled = false;
                txtmsk_dtemissaodoc.Enabled = false;
                txtmsk_dtreferenciadoc.Enabled = false;
                txt_idfornecedor.Enabled = false;
                txt_descricaofornecedor.Enabled = false;
                cbo_estadofornecedor.Enabled = false;
                cbo_formapgdoc.Enabled = false;
                cbo_prazopgdoc.Enabled = false;
                //ITENS
                txt_idproduto.Enabled = false;
                txt_descricaoproduto.Enabled = false;
                txt_unidadevenda.Enabled = false;
                txt_precounitproduto.Enabled = false;
                txt_quantidadeproduto.Enabled = false;
                txt_descontoproduto.Enabled = false;
                txt_acrescimoproduto.Enabled = false;
                txt_vlrtotalproduto.Enabled = false;
                lvw_produtosdoc.Enabled = false;
                //TOTAIS
                txt_descontototaldoc.Enabled = false;
                txt_acrescimototaldoc.Enabled = false;
                txt_qnttotalprodutosdoc.Enabled = false;
                txt_vlrtotaldoc.Enabled = false;
                #endregion

                #region "ATIVA/DESATIVA BOTOES"
                //ATIVA/DESATIVA BOTOES
                btNovo.Enabled = true;
                btGravar.Enabled = false;
                btAlterar.Enabled = false;
                btEditar.Enabled = false;
                btCancelar.Enabled = false;
                btConsultar.Enabled = true;
                btRelatorio.Enabled = true;
                btFechar.Enabled = true;
                btnCerrar.Enabled = true;
                btAddProduto.Enabled = false;
                btExcProduto.Enabled = false;
                #endregion

                #region 'COLOCA O FOCO'
                //COLOCA O FOCUS
                btNovo.Focus();
                #endregion
            }
            #endregion

            #endregion
        }

        private void GravarNfItens()
        {
            //COMANDO NÃO USA A CLASSE DE CONEXAO (GRAVAR ITENS)
            #region "GRAVA NF ITENS"

            #region 'VERIFICA SE A CONEXÃO COM O BANCO NÃO ESTÁ ABERTA E ABRE'
            string StrCon = "SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;"; //Caminho do banco
            MySqlConnection cn = new MySqlConnection(StrCon);
            MySqlCommand comm = new MySqlCommand();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;

            //Verifica se a conexão já está aberta
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open(); //Abre a conexão
            }
            #endregion

            #region 'LAÇO DE REPETIÇÃO PARA GRAVAR'
            //Faz o laço de repetição para gravar e atualizar item por item
            foreach (ListViewItem item in lvw_produtosdoc.Items)
            {
                #region 'DECLARANDO VARIAVEIS E GRAVANDO DADOS NELAS'
                //Declarando Variáveis e criando as strings
                string NFIidoperacao = txt_idoperacao.Text;
                string NFIdocumentonr = txt_numerodoc.Text;
                string NFIemissao = txtmsk_dtemissaodoc.Text;
                string NFIreferencia = txtmsk_dtreferenciadoc.Text;
                string NFIidproduto = item.SubItems[0].Text;
                string NFIdescrproduto = item.SubItems[1].Text;
                string NFIunvendaproduto = item.SubItems[2].Text;
                string NFIunprecoproduto = item.SubItems[3].Text;
                string NFIqntproduto = item.SubItems[4].Text;
                string NFIdescoproduto = item.SubItems[5].Text;
                string NFIacrescimoproduto = item.SubItems[6].Text;
                string NFIvlrtotalproduto = item.SubItems[7].Text;
                string NFIdescontototal = txt_descontototaldoc.Text;
                string NFIacrescimototal = txt_acrescimototaldoc.Text;
                string NFIqntprodutostotal = txt_qnttotalprodutosdoc.Text;
                string NFIvlrtotaldocumento = txt_vlrtotaldoc.Text;
                #endregion

                #region 'FORMATAÇÃO DA DATA'
                //BUSCA A FORMATAÇÃO DA DATA
                string NFIemissaoUS = FormatadataUS(NFIemissao);
                string NFIreferenciaUS = FormatadataUS(NFIreferencia);
                #endregion

                #region 'COMANDO PARA GRAVAR'
                //Comando para inserir no banco
                comm.CommandText = "Insert Into tb_nfeitens(IDOperacao, Documentonr, " +
                    "Emissao, Referencia, IDProduto, DescricaoProduto, UnVenda, PrecoProduto, " +
                    "QntProduto, DescontoProduto, AcrescimoProduto, VlrTotalProduto, DescontoTotal, " +
                    "AcrescimoTotal, QntProdutosTotal, VlrTotalDocumento) Values";
                comm.CommandText += "('" + NFIidoperacao + "','" + NFIdocumentonr + "'," +
                    "'" + NFIemissaoUS + "','" + NFIreferenciaUS + "','" + NFIidproduto + "'," +
                    "'" + NFIdescrproduto + "','" + NFIunvendaproduto + "','" + NFIunprecoproduto + "','" + NFIqntproduto + "'," +
                    "'" + NFIdescoproduto + "','" + NFIacrescimoproduto + "','" + NFIvlrtotalproduto + "'," +
                    "'" + NFIdescontototal + "','" + NFIacrescimototal + "','" + NFIqntprodutostotal + "'," +
                    "'" + NFIvlrtotaldocumento + "')";
                comm.ExecuteNonQuery();
                #endregion

                #region 'ATUALIZANDO ESTOQUE NO BANCO'

                #region 'DECLARANDO VARIAVEL'
                //Declarando a variavel e deixando limpa
                string QntEstoqueBanco1 = string.Empty;
                #endregion

                #region 'ABRE A CONEXÃO COM O BANCO, BUSCA O ESTOQUE PELO ID E REPASSA PARA VARIAVEL'
                //Buscando a quantidade de estoque do produto no banco
                //Começa para selecionar dados no banco
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "SELECT * FROM tb_produtos where ID='" + NFIidproduto + "'";
                MySqlDataReader reader = cmd.ExecuteReader(); //Executa o comando selecionar

                //Faz a leitura e repassa os dados para variavel
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        QntEstoqueBanco1 = reader.GetString("Estoque");
                    }
                    cmd.Connection.Close(); //Fecha a conexão
                }
                #endregion

                #region 'DECLARANDO VARIAVEL, CONVERTENDO DADOS, REPASSANDO E FAZENDO A SUBTRAÇÃO DO ESTOQUE'
                //Declarando e convertendo string para decimal a variável que possui a quantidade que está no banco 
                decimal QntEstoqueBanco = Convert.ToDecimal(QntEstoqueBanco1);
                //-----------------------------------------------------------------------------------------------------                 
                //Declarando e convertendo string para decimal a variável que possui a quantidade que está na lista
                decimal QntProdutoLista = Convert.ToDecimal(NFIqntproduto);
                //-----------------------------------------------------------------------------------------------------                 
                //Declarando variavel e fazendo a subtração na quantidade do estoque 
                decimal AtualizaEstBanco = QntEstoqueBanco + QntProdutoLista;

                ////Declarando e convertendo string para inteiro a variável que possui a quantidade que está no banco                
                //int QntEstoqueBanco = Convert.ToInt32(QntEstoqueBanco1);
                ////-----------------------------------------------------------------------------------------------------                 
                ////Declarando e convertendo string para inteiro a variável que possui a quantidade que está na lista
                //int QntProdutoLista = Convert.ToInt32(NFIqntproduto);
                ////-----------------------------------------------------------------------------------------------------                 
                ////Declarando variavel e fazendo a subtração na quantidade do estoque 
                //int AtualizaEstBanco = QntEstoqueBanco + QntProdutoLista;
                #endregion

                #region 'COMANDO PARA GRAVAR'
                //Comando para atualizar o estoque
                comm.CommandText = "update tb_produtos set " +
                    "Estoque ='" + AtualizaEstBanco + "' Where ID = " + NFIidproduto + "";
                comm.ExecuteNonQuery();
                #endregion

                #endregion
            }
            #endregion

            #region 'MENSAGEM'
            //MENSAGEM DE EXECUÇÃO
            MessageBox.Show("Dados Gravados com Sucesso!!!");
            #endregion

            #region 'FECHA A CONEXÃO'
            //Fecha a conexão
            comm.Connection.Close(); //Fecha a conexão
            cn.Close();
            #endregion

            #endregion
        }

        private void add(string cod, string descricao, string unvenda, string preco, string qnt, string desconto, string acrescimo, string valortotal)
        {
            #region "ADICIONA A LISTVIEW"
            //Adicionar Linha
            //Matriz para Representar uma Linha
            string[] row = { cod, descricao, unvenda, preco, qnt, desconto, acrescimo, valortotal };
            ListViewItem item = new ListViewItem(row);

            //Adicione ao lv
            lvw_produtosdoc.Items.Add(item);
            #endregion
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            #region "ATIVA AS CAIXAS"
            //DOCUMENTO
            txt_idoperacao.Enabled = true;
            txt_descricaooperacao.Enabled = true;
            txt_modelodoc.Enabled = true;
            txt_especiedoc.Enabled = true;
            txt_seriedoc.Enabled = true;
            txt_numerodoc.Enabled = true;
            txtmsk_dtemissaodoc.Enabled = true;
            txtmsk_dtreferenciadoc.Enabled = true;
            txt_idfornecedor.Enabled = true;
            txt_descricaofornecedor.Enabled = true;
            cbo_estadofornecedor.Enabled = true;
            cbo_formapgdoc.Enabled = true;
            cbo_prazopgdoc.Enabled = true;
            //ITENS
            lbIdProduto.Enabled = false;
            txt_idproduto.Enabled = true;
            txt_descricaoproduto.Enabled = true;
            txt_unidadevenda.Enabled = false;
            txt_precounitproduto.Enabled = false;
            txt_quantidadeproduto.Enabled = true;
            txt_descontoproduto.Enabled = true;
            txt_acrescimoproduto.Enabled = true;
            txt_vlrtotalproduto.Enabled = false;
            lvw_produtosdoc.Enabled = true;
            //TOTAIS
            txt_descontototaldoc.Enabled = false;
            txt_acrescimototaldoc.Enabled = false;
            txt_qnttotalprodutosdoc.Enabled = false;
            txt_vlrtotaldoc.Enabled = false;
            #endregion

            #region "LIMPA AS CAIXAS"
            //DOCUMENTO
            txt_idoperacao.Text = "";
            txt_descricaooperacao.Text = "";
            txt_modelodoc.Text = "";
            txt_especiedoc.Text = "";
            txt_seriedoc.Text = "";
            txt_numerodoc.Text = "";
            txtmsk_dtemissaodoc.Text = "";
            txtmsk_dtreferenciadoc.Text = "";
            txt_idfornecedor.Text = "";
            txt_descricaofornecedor.Text = "";
            cbo_estadofornecedor.Text = "";
            cbo_formapgdoc.Text = "";
            cbo_prazopgdoc.Text = "";
            //ITENS
            lbIdProduto.Text = "";
            txt_idproduto.Text = "";
            txt_descricaoproduto.Text = "";
            txt_unidadevenda.Text = "";
            txt_precounitproduto.Text = "";
            txt_quantidadeproduto.Text = "";
            txt_descontoproduto.Text = "";
            txt_acrescimoproduto.Text = "";
            txt_vlrtotalproduto.Text = "";
            lvw_produtosdoc.Text = "";
            lvw_produtosdoc.Clear();
            //TOTAIS
            txt_descontototaldoc.Text = "";
            txt_acrescimototaldoc.Text = "";
            txt_qnttotalprodutosdoc.Text = "";
            txt_vlrtotaldoc.Text = "";
            #endregion

            #region "ADICIONA A LISTVIEW"
            //Adicionar colunas
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[0].Text = "Cód.";
            this.lvw_produtosdoc.Columns[0].Width = 50;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[1].Text = "Descrição Produto";
            this.lvw_produtosdoc.Columns[1].Width = 300;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[2].Text = "Un. Venda";
            this.lvw_produtosdoc.Columns[2].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[3].Text = "Preço";
            this.lvw_produtosdoc.Columns[3].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[4].Text = "Qnt.";
            this.lvw_produtosdoc.Columns[4].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[5].Text = "Desconto";
            this.lvw_produtosdoc.Columns[5].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[6].Text = "Acréscimo";
            this.lvw_produtosdoc.Columns[6].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[7].Text = "Valor Total";
            this.lvw_produtosdoc.Columns[7].Width = 120;
            #endregion

            #region 'PREENCHE AS CAIXAS'
            txt_quantidadeproduto.Text = "0,000";
            txt_precounitproduto.Text = "0,00";
            txt_descontoproduto.Text = "0,00";
            txt_acrescimoproduto.Text = "0,00";
            txt_vlrtotalproduto.Text = "0,00";
            txt_descontototaldoc.Text = "0,00";
            txt_acrescimototaldoc.Text = "0,00";
            txt_qnttotalprodutosdoc.Text = "00";
            txt_vlrtotaldoc.Text = "0,00";
            #endregion

            #region "ATIVA/DESATIVA BOTOES"
            btNovo.Enabled = false;
            btGravar.Enabled = true;
            btAlterar.Enabled = false;
            btEditar.Enabled = false;
            btCancelar.Enabled = true;
            btConsultar.Enabled = false;
            btRelatorio.Enabled = false;
            btFechar.Enabled = false;
            btnCerrar.Enabled = false;
            btAddProduto.Enabled = true;
            btExcProduto.Enabled = false;
            #endregion

            #region 'COLOCA O FOCO'
            //COLOCA O FOCUS
            txt_idoperacao.Focus();
            #endregion
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            #region "FAZ AS VERIFICAÇÕES PARA GRAVAR"
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_idoperacao.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idoperacao.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_descricaooperacao.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_descricaooperacao.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_modelodoc.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_modelodoc.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_especiedoc.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_especiedoc.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_seriedoc.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_seriedoc.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_numerodoc.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_numerodoc.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txtmsk_dtemissaodoc.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtmsk_dtemissaodoc.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txtmsk_dtreferenciadoc.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtmsk_dtreferenciadoc.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_idfornecedor.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_descricaofornecedor.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_descricaofornecedor.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_descricaofornecedor.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (cbo_estadofornecedor.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbo_estadofornecedor.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (cbo_formapgdoc.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbo_formapgdoc.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (cbo_prazopgdoc.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbo_prazopgdoc.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (lbIdProduto.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idproduto.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_descontototaldoc.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_descontototaldoc.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_acrescimototaldoc.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos da NF!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_acrescimototaldoc.Focus();
                return;
            }
            #endregion

            #region "FAZ A GRAVAÇÃO"
            //Verifica se foi lançado algum produto para finalizar a venda
            if (txt_vlrtotaldoc.Text != "")
            {
                GravarNfTotal();
            }
            else
            {
                MessageBox.Show("Adicione um produto para finalizar a venda!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_descricaoproduto.Focus();
            }
            #endregion
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {       
            #region 'EXCLUIR COM A TECLA DELETE ITEM DA LISTVIEW'        
            if (txt_idproduto.Text != "")
            {
                for (int i = lvw_produtosdoc.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem li = lvw_produtosdoc.SelectedItems[i];
                    lvw_produtosdoc.Items.Remove(li);
                }
            }
            #endregion
                                                
            #region 'VERIFICA SE TEM DADOS PARA LANÇAR'
            if (txt_idproduto.Text != "" && txt_descricaoproduto.Text != "" && txt_unidadevenda.Text != "" && txt_precounitproduto.Text != "" && txt_quantidadeproduto.Text != "" && txt_descontoproduto.Text != "" && txt_acrescimoproduto.Text != "" && txt_vlrtotalproduto.Text != "")
            {
                #region 'CONDIÇÃO PARA FORMATAR'
                if (txt_unidadevenda.Text == "UN")
                {
                    #region "SOMA A QUANTIDADE DE PRODUTOS"
                    if (txt_qnttotalprodutosdoc.Text != "")
                    {
                        //REALIZA A SOMA DAS CAIXAS  
                        int qnt1 = Convert.ToInt32(txt_quantidadeproduto.Text);
                        int qnt2 = Convert.ToInt32(txt_qnttotalprodutosdoc.Text);
                        int qnttotal = qnt1 + qnt2;
                        txt_qnttotalprodutosdoc.Text = Convert.ToString(qnttotal);
                    }
                    else
                    {
                        //REALIZA A SOMA DAS CAIXAS  
                        int qnt1 = Convert.ToInt32(txt_quantidadeproduto.Text);
                        int qnt2 = 0;
                        int qnttotal = qnt1 + qnt2;
                        txt_qnttotalprodutosdoc.Text = Convert.ToString(qnttotal);
                    }
                    #endregion

                    #region 'SOMA O DESCONTO'
                    if (txt_descontoproduto.Text != "" && txt_descontototaldoc.Text != "")
                    {
                        //SOMA OS VALORES
                        decimal DescProduto = Convert.ToDecimal(txt_descontoproduto.Text);
                        decimal DescTotalDoc = Convert.ToDecimal(txt_descontototaldoc.Text);
                        decimal DescontoTotal = DescProduto + DescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_descontototaldoc.Text = DescontoTotal.ToString();
                    }
                    else
                    {
                        //SOMA OS VALORES
                        decimal DescProduto = Convert.ToDecimal(txt_descontoproduto.Text);
                        decimal DescTotalDoc = Convert.ToDecimal(txt_descontototaldoc.Text);
                        decimal DescontoTotal = DescProduto + DescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_descontototaldoc.Text = DescontoTotal.ToString();
                    }
                    #endregion

                    #region 'SOMA O ACRÉSCIMO'
                    if (txt_acrescimoproduto.Text != "" && txt_acrescimototaldoc.Text != "")
                    {
                        ///SOMA OS VALORES
                        decimal AcrescProduto = Convert.ToDecimal(txt_acrescimoproduto.Text);
                        decimal AcrescTotalDoc = Convert.ToDecimal(txt_acrescimototaldoc.Text);
                        decimal AcrescimoTotal = AcrescProduto + AcrescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_acrescimototaldoc.Text = AcrescimoTotal.ToString();
                    }
                    else
                    {
                        //SOMA OS VALORES
                        decimal AcrescProduto = Convert.ToDecimal(txt_acrescimoproduto.Text);
                        decimal AcrescTotalDoc = Convert.ToDecimal(txt_acrescimototaldoc.Text);
                        decimal AcrescimoTotal = AcrescProduto + AcrescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_acrescimototaldoc.Text = AcrescimoTotal.ToString();
                    }
                    #endregion

                    #region "ADICIONAR PRODUTO E FAZ A SOMA DENTRO DA LISTA"

                    //ADICIONA NA LISTA
                    add(txt_idproduto.Text, txt_descricaoproduto.Text, txt_unidadevenda.Text, txt_precounitproduto.Text, txt_quantidadeproduto.Text, txt_descontoproduto.Text, txt_acrescimoproduto.Text, txt_vlrtotalproduto.Text);

                    //REALIZA A SOMA TOTAL DENTRO DA LISTVIEW
                    var vlrtotal = 0m;
                    for (int i = 0; i < lvw_produtosdoc.Items.Count; i++)
                    {
                        vlrtotal += decimal.Parse(lvw_produtosdoc.Items[i].SubItems[7].Text); ;
                    }
                    txt_vlrtotaldoc.Text = vlrtotal.ToString("N");
                    //txt_vlrtotaldoc.Text = vlrtotal.ToString("C");   

                    #endregion

                    #region "LIMPAS AS CAIXAS"            
                    //ITENS
                    lbIdProduto.Text = "";
                    lbIdProduto.Text = txt_idproduto.Text;
                    txt_idproduto.Text = "";
                    txt_descricaoproduto.Text = "";
                    txt_unidadevenda.Text = "";
                    txt_precounitproduto.Text = "";
                    txt_quantidadeproduto.Text = "";
                    txt_descontoproduto.Text = "";
                    txt_acrescimoproduto.Text = "";
                    txt_vlrtotalproduto.Text = "";
                    #endregion

                    #region "ATIVA/DESATIVA BOTOES"
                    //ATIVA/DESATIVA BOTOES
                    btNovo.Enabled = false;
                    btGravar.Enabled = true;
                    btAlterar.Enabled = false;
                    btEditar.Enabled = false;
                    btCancelar.Enabled = true;
                    btConsultar.Enabled = false;
                    btRelatorio.Enabled = false;
                    btFechar.Enabled = false;
                    btnCerrar.Enabled = false;
                    btAddProduto.Enabled = true;
                    btExcProduto.Enabled = false;
                    #endregion

                    #region 'COLOCA O FOCO'
                    //COLOCA O FOCUS
                    txt_idproduto.Focus();
                    #endregion
                }
                else if (txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
                {
                    #region "SOMA A QUANTIDADE DE PRODUTOS"
                    if (txt_qnttotalprodutosdoc.Text != "00")
                    {
                        //REALIZA A SOMA DAS CAIXAS  
                        int qnt = 1;
                        int qnt1 = Convert.ToInt32(qnt);
                        int qnt2 = Convert.ToInt32(txt_qnttotalprodutosdoc.Text);
                        int qnttotal = qnt1 + qnt2;

                        txt_qnttotalprodutosdoc.Text = Convert.ToString(qnttotal);
                    }
                    else
                    {
                        //REALIZA A SOMA DAS CAIXAS  
                        int qnt = 1;
                        int qntd = 0;
                        int qnt1 = Convert.ToInt32(qnt);
                        int qnt2 = Convert.ToInt32(qntd);
                        int qnttotal = qnt1 + qnt2;

                        txt_qnttotalprodutosdoc.Text = Convert.ToString(qnttotal);
                    }
                    #endregion

                    #region 'SOMA O DESCONTO'
                    if (txt_descontoproduto.Text != "" && txt_descontototaldoc.Text != "")
                    {
                        //SOMA OS VALORES
                        decimal DescProduto = Convert.ToDecimal(txt_descontoproduto.Text);
                        decimal DescTotalDoc = Convert.ToDecimal(txt_descontototaldoc.Text);
                        decimal DescontoTotal = DescProduto + DescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_descontototaldoc.Text = DescontoTotal.ToString();
                    }
                    else
                    {
                        //SOMA OS VALORES
                        decimal DescProduto = Convert.ToDecimal(txt_descontoproduto.Text);
                        decimal DescTotalDoc = Convert.ToDecimal(txt_descontototaldoc.Text);
                        decimal DescontoTotal = DescProduto + DescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_descontototaldoc.Text = DescontoTotal.ToString();
                    }
                    #endregion

                    #region 'SOMA O ACRÉSCIMO'
                    if (txt_acrescimoproduto.Text != "" && txt_acrescimototaldoc.Text != "")
                    {
                        ///SOMA OS VALORES
                        decimal AcrescProduto = Convert.ToDecimal(txt_acrescimoproduto.Text);
                        decimal AcrescTotalDoc = Convert.ToDecimal(txt_acrescimototaldoc.Text);
                        decimal AcrescimoTotal = AcrescProduto + AcrescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_acrescimototaldoc.Text = AcrescimoTotal.ToString();
                    }
                    else
                    {
                        //SOMA OS VALORES
                        decimal AcrescProduto = Convert.ToDecimal(txt_acrescimoproduto.Text);
                        decimal AcrescTotalDoc = Convert.ToDecimal(txt_acrescimototaldoc.Text);
                        decimal AcrescimoTotal = AcrescProduto + AcrescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_acrescimototaldoc.Text = AcrescimoTotal.ToString();
                    }
                    #endregion

                    #region "ADICIONAR PRODUTO E FAZ A SOMA DENTRO DA LISTA"

                    //ADICIONA NA LISTA
                    add(txt_idproduto.Text, txt_descricaoproduto.Text, txt_unidadevenda.Text, txt_precounitproduto.Text, txt_quantidadeproduto.Text, txt_descontoproduto.Text, txt_acrescimoproduto.Text, txt_vlrtotalproduto.Text);

                    //REALIZA A SOMA TOTAL DENTRO DA LISTVIEW
                    var vlrtotal = 0m;
                    for (int i = 0; i < lvw_produtosdoc.Items.Count; i++)
                    {
                        vlrtotal += decimal.Parse(lvw_produtosdoc.Items[i].SubItems[7].Text); ;
                    }
                    txt_vlrtotaldoc.Text = vlrtotal.ToString("N");
                    //txt_vlrtotaldoc.Text = vlrtotal.ToString("C");   

                    #endregion

                    #region "LIMPAS AS CAIXAS"            
                    //ITENS
                    lbIdProduto.Text = "";
                    lbIdProduto.Text = txt_idproduto.Text;
                    txt_idproduto.Text = "";
                    txt_descricaoproduto.Text = "";
                    txt_unidadevenda.Text = "";
                    txt_precounitproduto.Text = "";
                    txt_quantidadeproduto.Text = "";
                    txt_descontoproduto.Text = "";
                    txt_acrescimoproduto.Text = "";
                    txt_vlrtotalproduto.Text = "";
                    #endregion

                    #region "ATIVA/DESATIVA BOTOES"
                    //ATIVA/DESATIVA BOTOES
                    btNovo.Enabled = false;
                    btGravar.Enabled = true;
                    btAlterar.Enabled = false;
                    btEditar.Enabled = false;
                    btCancelar.Enabled = true;
                    btConsultar.Enabled = false;
                    btRelatorio.Enabled = false;
                    btFechar.Enabled = false;
                    btnCerrar.Enabled = false;
                    btAddProduto.Enabled = true;
                    btExcProduto.Enabled = false;
                    #endregion

                    #region 'COLOCA O FOCO'
                    //COLOCA O FOCUS
                    txt_idproduto.Focus();
                    #endregion
                }
                #endregion                
            }
            else
            {
                #region 'MENSAGEM'
                //MENSAGEM DE EXECUÇÃO
                MessageBox.Show("Preencha todos os campos para lançar!!!");
                #endregion

                #region "LIMPAS AS CAIXAS"            
                //ITENS
                txt_idproduto.Text = "";
                txt_descricaoproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
                txt_quantidadeproduto.Text = "";
                txt_descontoproduto.Text = "";
                txt_acrescimoproduto.Text = "";
                txt_vlrtotalproduto.Text = "";
                #endregion

                #region 'COLOCA O FOCO'
                //COLOCA O FOCUS
                txt_idproduto.Focus();
                #endregion
            }
            #endregion

            #region "LIMPAS AS CAIXAS"            
            //ITENS
            txt_idproduto.Text = "";
            txt_descricaoproduto.Text = "";
            txt_unidadevenda.Text = "";
            txt_precounitproduto.Text = "";
            txt_quantidadeproduto.Text = "";
            txt_descontoproduto.Text = "";
            txt_acrescimoproduto.Text = "";
            txt_vlrtotalproduto.Text = "";
            #endregion

            #region 'COLOCA O FOCO'
            //COLOCA O FOCUS
            txt_idproduto.Focus();
            #endregion
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            #region 'EDITAR'
            //FECHA O FORMULÁRIO COM MENSAGEM
            DialogResult dlgResult = MessageBox.Show("Clique SIM para Alterar" + "\r\n" + "Clique NÂO para Cancelar", "Editar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                #region 'VERIFICA SE TEM DADOS PARA DIMINUIR VALORES E QUANTIDADES'
                if (txt_idproduto.Text != "" && txt_descricaoproduto.Text != "" && txt_unidadevenda.Text != "" && txt_precounitproduto.Text != "" && txt_quantidadeproduto.Text != "" && txt_descontoproduto.Text != "" && txt_acrescimoproduto.Text != "" && txt_vlrtotalproduto.Text != "")
                {
                    #region 'CONDIÇÃO PARA FORMATAR'
                    if (txt_unidadevenda.Text == "UN")
                    {
                        #region "DIMINUI A QUANTIDADE DE PRODUTOS"
                        if (txt_qnttotalprodutosdoc.Text != "")
                        {
                            //REALIZA A SOMA DAS CAIXAS  
                            int qnt1 = Convert.ToInt32(txt_quantidadeproduto.Text);
                            int qnt2 = Convert.ToInt32(txt_qnttotalprodutosdoc.Text);
                            int qnttotal = qnt2 - qnt1;
                            txt_qnttotalprodutosdoc.Text = Convert.ToString(qnttotal);
                        }
                        else
                        {
                            txt_qnttotalprodutosdoc.Text = "00";
                        }
                        #endregion

                        #region 'DIMINUI O DESCONTO'
                        if (txt_descontoproduto.Text != "" && txt_descontototaldoc.Text != "")
                        {
                            //SOMA OS VALORES
                            decimal DescProduto = Convert.ToDecimal(txt_descontoproduto.Text);
                            decimal DescTotalDoc = Convert.ToDecimal(txt_descontototaldoc.Text);
                            decimal DescontoTotal = DescTotalDoc - DescProduto;
                            //MOSTRA O RESULTADO
                            txt_descontototaldoc.Text = DescontoTotal.ToString();
                        }
                        else
                        {
                            txt_descontototaldoc.Text = "0,00";
                        }
                        #endregion

                        #region 'DIMINUI O ACRÉSCIMO'
                        if (txt_acrescimoproduto.Text != "" && txt_acrescimototaldoc.Text != "")
                        {
                            ///SOMA OS VALORES
                            decimal AcrescProduto = Convert.ToDecimal(txt_acrescimoproduto.Text);
                            decimal AcrescTotalDoc = Convert.ToDecimal(txt_acrescimototaldoc.Text);
                            decimal AcrescimoTotal = AcrescTotalDoc - AcrescProduto;
                            //MOSTRA O RESULTADO
                            txt_acrescimototaldoc.Text = AcrescimoTotal.ToString();
                        }
                        else
                        {
                            txt_acrescimototaldoc.Text = "0,00";
                        }
                        #endregion

                        #region "FAZ A SOMA DENTRO DA LISTA"
                        //REALIZA A SOMA TOTAL DENTRO DA LISTVIEW
                        var vlrtotal = 0m;
                        for (int i = 0; i < lvw_produtosdoc.Items.Count; i++)
                        {
                            vlrtotal += decimal.Parse(lvw_produtosdoc.Items[i].SubItems[7].Text); ;
                        }
                        txt_vlrtotaldoc.Text = vlrtotal.ToString("N");
                        #endregion
                    }
                    else if (txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
                    {
                        #region "DIMINUI A QUANTIDADE DE PRODUTOS"
                        if (txt_qnttotalprodutosdoc.Text != "00")
                        {
                            //REALIZA A SOMA DAS CAIXAS  
                            int qnt = 1;
                            int qnt1 = Convert.ToInt32(qnt);
                            int qnt2 = Convert.ToInt32(txt_qnttotalprodutosdoc.Text);
                            int qnttotal = qnt2 - qnt1;
                            txt_qnttotalprodutosdoc.Text = Convert.ToString(qnttotal);
                        }
                        else
                        {
                            txt_qnttotalprodutosdoc.Text = "00";
                        }
                        #endregion

                        #region 'DIMINUI O DESCONTO'
                        if (txt_descontoproduto.Text != "" && txt_descontototaldoc.Text != "")
                        {
                            //SOMA OS VALORES
                            decimal DescProduto = Convert.ToDecimal(txt_descontoproduto.Text);
                            decimal DescTotalDoc = Convert.ToDecimal(txt_descontototaldoc.Text);
                            decimal DescontoTotal = DescTotalDoc - DescProduto;
                            //MOSTRA O RESULTADO
                            txt_descontototaldoc.Text = DescontoTotal.ToString();
                        }
                        else
                        {
                            txt_qnttotalprodutosdoc.Text = "0,00";
                        }
                        #endregion

                        #region 'DIMINUI O ACRÉSCIMO'
                        if (txt_acrescimoproduto.Text != "" && txt_acrescimototaldoc.Text != "")
                        {
                            ///SOMA OS VALORES
                            decimal AcrescProduto = Convert.ToDecimal(txt_acrescimoproduto.Text);
                            decimal AcrescTotalDoc = Convert.ToDecimal(txt_acrescimototaldoc.Text);
                            decimal AcrescimoTotal = AcrescTotalDoc - AcrescProduto;
                            //MOSTRA O RESULTADO
                            txt_acrescimototaldoc.Text = AcrescimoTotal.ToString();
                        }
                        else
                        {
                            txt_qnttotalprodutosdoc.Text = "0,00";
                        }
                        #endregion

                        #region "FAZ A SOMA DENTRO DA LISTA"
                        //REALIZA A SOMA TOTAL DENTRO DA LISTVIEW
                        var vlrtotal = 0m;
                        for (int i = 0; i < lvw_produtosdoc.Items.Count; i++)
                        {
                            vlrtotal += decimal.Parse(lvw_produtosdoc.Items[i].SubItems[7].Text); ;
                        }
                        txt_vlrtotaldoc.Text = vlrtotal.ToString("N");
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    #region 'MENSAGEM'
                    //MENSAGEM DE EXECUÇÃO
                    MessageBox.Show("Selecione um ítem para editar!!!");
                    #endregion

                    #region "LIMPAS AS CAIXAS"            
                    //ITENS
                    txt_idproduto.Text = "";
                    txt_descricaoproduto.Text = "";
                    txt_unidadevenda.Text = "";
                    txt_precounitproduto.Text = "";
                    txt_quantidadeproduto.Text = "";
                    txt_descontoproduto.Text = "";
                    txt_acrescimoproduto.Text = "";
                    txt_vlrtotalproduto.Text = "";
                    #endregion

                    #region 'COLOCA O FOCO'
                    //COLOCA O FOCUS
                    txt_idproduto.Focus();
                    #endregion
                }
                #endregion

                #region 'ATIVAR/DESATIVAR CAIXAS'
                txt_idproduto.Enabled = true;
                txt_descricaoproduto.Enabled = true;
                txt_unidadevenda.Enabled = false;
                txt_precounitproduto.Enabled = false;
                txt_quantidadeproduto.Enabled = true;
                txt_descontoproduto.Enabled = true;
                txt_acrescimoproduto.Enabled = true;
                txt_vlrtotalproduto.Enabled = false;
                lvw_produtosdoc.Enabled = false;
                #endregion

                #region 'ATIVA/DESATIVA OS BOTÕES'
                //DESATIVAR/ATIVAR BOTÕES
                btNovo.Enabled = false;
                btGravar.Enabled = false;
                btAlterar.Enabled = true;
                btEditar.Enabled = false;
                btCancelar.Enabled = false;
                btConsultar.Enabled = false;
                btRelatorio.Enabled = false;
                btFechar.Enabled = false;
                btnCerrar.Enabled = false;
                btAddProduto.Enabled = false;
                btExcProduto.Enabled = false;
                #endregion
            }
            if (dlgResult == DialogResult.No)
            {
                #region "ATIVA AS CAIXAS"
                //ITENS
                txt_idproduto.Enabled = true;
                txt_descricaoproduto.Enabled = true;
                txt_unidadevenda.Enabled = false;
                txt_precounitproduto.Enabled = false;
                txt_quantidadeproduto.Enabled = true;
                txt_descontoproduto.Enabled = true;
                txt_acrescimoproduto.Enabled = true;
                txt_vlrtotalproduto.Enabled = false;
                lvw_produtosdoc.Enabled = true;
                //TOTAIS
                txt_descontototaldoc.Enabled = false;
                txt_acrescimototaldoc.Enabled = false;
                txt_qnttotalprodutosdoc.Enabled = false;
                txt_vlrtotaldoc.Enabled = false;
                #endregion

                #region "LIMPA AS CAIXAS"
                //ITENS
                txt_idproduto.Text = "";
                txt_descricaoproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
                txt_quantidadeproduto.Text = "";
                txt_descontoproduto.Text = "";
                txt_acrescimoproduto.Text = "";
                txt_vlrtotalproduto.Text = "";
                #endregion

                #region "ATIVA/DESATIVA BOTOES"
                btNovo.Enabled = false;
                btGravar.Enabled = true;
                btAlterar.Enabled = false;
                btEditar.Enabled = false;
                btCancelar.Enabled = true;
                btConsultar.Enabled = false;
                btRelatorio.Enabled = false;
                btFechar.Enabled = false;
                btnCerrar.Enabled = false;
                btAddProduto.Enabled = true;
                btExcProduto.Enabled = false;
                #endregion

                #region 'COLOCA O FOCO'
                //COLOCA O FOCUS
                txt_idproduto.Focus();
                #endregion
            }
            #endregion
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            #region "LIMPAS AS CAIXAS"
            //LIMPA AS CAIXAS
            //DOCUMENTO            
            txt_idoperacao.Text = "";
            txt_descricaooperacao.Text = "";
            txt_modelodoc.Text = "";
            txt_especiedoc.Text = "";
            txt_seriedoc.Text = "";
            txt_numerodoc.Text = "";
            txtmsk_dtemissaodoc.Text = "";
            txtmsk_dtreferenciadoc.Text = "";
            txt_idfornecedor.Text = "";
            txt_descricaofornecedor.Text = "";
            cbo_estadofornecedor.Text = "";
            cbo_formapgdoc.Text = "";
            cbo_prazopgdoc.Text = "";
            //ITENS
            lbIdProduto.Text = "";
            txt_idproduto.Text = "";
            txt_descricaoproduto.Text = "";
            txt_unidadevenda.Text = "";
            txt_precounitproduto.Text = "";
            txt_quantidadeproduto.Text = "";
            txt_descontoproduto.Text = "";
            txt_acrescimoproduto.Text = "";
            txt_vlrtotalproduto.Text = "";
            lvw_produtosdoc.Text = "";
            lvw_produtosdoc.Clear();
            //TOTAIS
            txt_descontototaldoc.Text = "";
            txt_acrescimototaldoc.Text = "";
            txt_qnttotalprodutosdoc.Text = "";
            txt_vlrtotaldoc.Text = "";
            #endregion

            #region "ADICIONA A LISTVIEW"
            //Adicionar colunas
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[0].Text = "Cód.";
            this.lvw_produtosdoc.Columns[0].Width = 50;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[1].Text = "Descrição Produto";
            this.lvw_produtosdoc.Columns[1].Width = 300;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[2].Text = "Un. Venda";
            this.lvw_produtosdoc.Columns[2].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[3].Text = "Preço";
            this.lvw_produtosdoc.Columns[3].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[4].Text = "Qnt.";
            this.lvw_produtosdoc.Columns[4].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[5].Text = "Desconto";
            this.lvw_produtosdoc.Columns[5].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[6].Text = "Acréscimo";
            this.lvw_produtosdoc.Columns[6].Width = 70;
            this.lvw_produtosdoc.Columns.Add(new ColumnHeader());
            this.lvw_produtosdoc.Columns[7].Text = "Valor Total";
            this.lvw_produtosdoc.Columns[7].Width = 120;
            #endregion

            #region "DESATIVA AS CAIXAS"
            //DESATIVA AS CAIXAS
            //DOCUMENTO
            txt_idoperacao.Enabled = false;
            txt_descricaooperacao.Enabled = false;
            txt_modelodoc.Enabled = false;
            txt_especiedoc.Enabled = false;
            txt_seriedoc.Enabled = false;
            txt_numerodoc.Enabled = false;
            txtmsk_dtemissaodoc.Enabled = false;
            txtmsk_dtreferenciadoc.Enabled = false;
            txt_idfornecedor.Enabled = false;
            txt_descricaofornecedor.Enabled = false;
            cbo_estadofornecedor.Enabled = false;
            cbo_formapgdoc.Enabled = false;
            cbo_prazopgdoc.Enabled = false;
            //ITENS
            lbIdProduto.Enabled = false;
            txt_idproduto.Enabled = false;
            txt_descricaoproduto.Enabled = false;
            txt_unidadevenda.Enabled = false;
            txt_precounitproduto.Enabled = false;
            txt_quantidadeproduto.Enabled = false;
            txt_descontoproduto.Enabled = false;
            txt_acrescimoproduto.Enabled = false;
            txt_vlrtotalproduto.Enabled = false;
            lvw_produtosdoc.Enabled = false;
            //TOTAIS
            txt_descontototaldoc.Enabled = false;
            txt_acrescimototaldoc.Enabled = false;
            txt_qnttotalprodutosdoc.Enabled = false;
            txt_vlrtotaldoc.Enabled = false;
            #endregion

            #region 'PREENCHE AS CAIXAS'
            txt_quantidadeproduto.Text = "00";
            txt_precounitproduto.Text = "0,00";
            txt_descontoproduto.Text = "0,00";
            txt_acrescimoproduto.Text = "0,00";
            txt_vlrtotalproduto.Text = "0,00";
            txt_descontototaldoc.Text = "0,00";
            txt_acrescimototaldoc.Text = "0,00";
            txt_qnttotalprodutosdoc.Text = "00";
            txt_vlrtotaldoc.Text = "0,00";
            #endregion

            #region "ATIVA/DESATIVA BOTOES"
            //ATIVA/DESATIVA BOTOES
            btNovo.Enabled = true;
            btGravar.Enabled = false;
            btAlterar.Enabled = false;
            btEditar.Enabled = false;
            btCancelar.Enabled = false;
            btConsultar.Enabled = true;
            btRelatorio.Enabled = true;
            btFechar.Enabled = true;
            btnCerrar.Enabled = true;
            btAddProduto.Enabled = false;
            btExcProduto.Enabled = false;
            #endregion

            #region 'COLOCA O FOCO'
            //COLOCA O FOCUS
            btNovo.Focus();
            #endregion
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            #region "ABRINDO NOVA TELA"
            this.Hide();
            FrmNFConsultaTotal frm = new FrmNFConsultaTotal();
            frm.ShowDialog();
            #endregion            
        }

        private void btRelatorio_Click(object sender, EventArgs e)
        {

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

        private void btAddProduto_Click(object sender, EventArgs e)
        {            
            #region 'VERIFICA SE TEM DADOS PARA LANÇAR'
            if (txt_idproduto.Text != "" && txt_descricaoproduto.Text != "" && txt_unidadevenda.Text != "" && txt_precounitproduto.Text != "" && txt_quantidadeproduto.Text != "" && txt_descontoproduto.Text != "" && txt_acrescimoproduto.Text != "" && txt_vlrtotalproduto.Text != "")
            {
                #region 'CONDIÇÃO PARA FORMATAR'
                if (txt_unidadevenda.Text == "UN")
                {
                    #region "SOMA A QUANTIDADE DE PRODUTOS"
                    if (txt_qnttotalprodutosdoc.Text != "" && txt_qnttotalprodutosdoc.Text != "00")
                    {
                        //REALIZA A SOMA DAS CAIXAS  
                        int qnt = 1;
                        int qnt1 = Convert.ToInt32(qnt);
                        int qnt2 = Convert.ToInt32(txt_qnttotalprodutosdoc.Text);
                        int qnttotal = qnt1 + qnt2;
                        txt_qnttotalprodutosdoc.Text = Convert.ToString(qnttotal);
                    }
                    else
                    {
                        //REALIZA A SOMA DAS CAIXAS  
                        int qnt = 1;
                        int qntd = 0;
                        int qnt1 = Convert.ToInt32(qnt);
                        int qnt2 = Convert.ToInt32(qntd);
                        int qnttotal = qnt1 + qnt2;
                        txt_qnttotalprodutosdoc.Text = Convert.ToString(qnttotal);
                    }
                    #endregion

                    #region 'SOMA O DESCONTO'
                    if (txt_descontoproduto.Text != "" && txt_descontototaldoc.Text != "")
                    {
                        //SOMA OS VALORES
                        decimal DescProduto = Convert.ToDecimal(txt_descontoproduto.Text);
                        decimal DescTotalDoc = Convert.ToDecimal(txt_descontototaldoc.Text);
                        decimal DescontoTotal = DescProduto + DescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_descontototaldoc.Text = DescontoTotal.ToString();
                    }
                    else
                    {
                        //SOMA OS VALORES
                        decimal DescProduto = Convert.ToDecimal(txt_descontoproduto.Text);
                        decimal DescTotalDoc = Convert.ToDecimal(txt_descontototaldoc.Text);
                        decimal DescontoTotal = DescProduto + DescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_descontototaldoc.Text = DescontoTotal.ToString();
                    }
                    #endregion

                    #region 'SOMA O ACRÉSCIMO'
                    if (txt_acrescimoproduto.Text != "" && txt_acrescimototaldoc.Text != "")
                    {
                        ///SOMA OS VALORES
                        decimal AcrescProduto = Convert.ToDecimal(txt_acrescimoproduto.Text);
                        decimal AcrescTotalDoc = Convert.ToDecimal(txt_acrescimototaldoc.Text);
                        decimal AcrescimoTotal = AcrescProduto + AcrescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_acrescimototaldoc.Text = AcrescimoTotal.ToString();
                    }
                    else
                    {
                        //SOMA OS VALORES
                        decimal AcrescProduto = Convert.ToDecimal(txt_acrescimoproduto.Text);
                        decimal AcrescTotalDoc = Convert.ToDecimal(txt_acrescimototaldoc.Text);
                        decimal AcrescimoTotal = AcrescProduto + AcrescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_acrescimototaldoc.Text = AcrescimoTotal.ToString();
                    }
                    #endregion

                    #region "ADICIONAR PRODUTO E FAZ A SOMA DENTRO DA LISTA"

                    //ADICIONA NA LISTA
                    add(txt_idproduto.Text, txt_descricaoproduto.Text, txt_unidadevenda.Text, txt_precounitproduto.Text, txt_quantidadeproduto.Text, txt_descontoproduto.Text, txt_acrescimoproduto.Text, txt_vlrtotalproduto.Text);

                    //REALIZA A SOMA TOTAL DENTRO DA LISTVIEW
                    var vlrtotal = 0m;
                    for (int i = 0; i < lvw_produtosdoc.Items.Count; i++)
                    {
                        vlrtotal += decimal.Parse(lvw_produtosdoc.Items[i].SubItems[7].Text); ;
                    }
                    txt_vlrtotaldoc.Text = vlrtotal.ToString("N");
                    //txt_vlrtotaldoc.Text = vlrtotal.ToString("C");
                    #endregion

                    #region "LIMPAS AS CAIXAS"            
                    //ITENS
                    lbIdProduto.Text = "";
                    lbIdProduto.Text = txt_idproduto.Text;
                    txt_idproduto.Text = "";
                    txt_descricaoproduto.Text = "";
                    txt_unidadevenda.Text = "";
                    txt_precounitproduto.Text = "";
                    txt_quantidadeproduto.Text = "";
                    txt_descontoproduto.Text = "";
                    txt_acrescimoproduto.Text = "";
                    txt_vlrtotalproduto.Text = "";
                    #endregion

                    #region "ATIVA/DESATIVA BOTOES"
                    //ATIVA/DESATIVA BOTOES
                    btNovo.Enabled = false;
                    btGravar.Enabled = true;
                    btAlterar.Enabled = false;
                    btEditar.Enabled = false;
                    btCancelar.Enabled = true;
                    btConsultar.Enabled = false;
                    btRelatorio.Enabled = false;
                    btFechar.Enabled = false;
                    btnCerrar.Enabled = false;
                    btAddProduto.Enabled = true;
                    #endregion

                    #region 'COLOCA O FOCO'
                    //COLOCA O FOCUS
                    txt_idproduto.Focus();
                    #endregion
                }
                else if (txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
                {
                    #region "SOMA A QUANTIDADE DE PRODUTOS"
                    if (txt_qnttotalprodutosdoc.Text != "" && txt_qnttotalprodutosdoc.Text != "00")
                    {
                        //REALIZA A SOMA DAS CAIXAS  
                        int qnt = 1;
                        int qnt1 = Convert.ToInt32(qnt);
                        int qnt2 = Convert.ToInt32(txt_qnttotalprodutosdoc.Text);
                        int qnttotal = qnt1 + qnt2;
                        txt_qnttotalprodutosdoc.Text = Convert.ToString(qnttotal);
                    }
                    else
                    {
                        //REALIZA A SOMA DAS CAIXAS  
                        int qnt = 1;
                        int qntd = 0;
                        int qnt1 = Convert.ToInt32(qnt);
                        int qnt2 = Convert.ToInt32(qntd);
                        int qnttotal = qnt1 + qnt2;
                        txt_qnttotalprodutosdoc.Text = Convert.ToString(qnttotal);
                    }
                    #endregion

                    #region 'SOMA O DESCONTO'
                    if (txt_descontoproduto.Text != "" && txt_descontototaldoc.Text != "")
                    {
                        //SOMA OS VALORES
                        decimal DescProduto = Convert.ToDecimal(txt_descontoproduto.Text);
                        decimal DescTotalDoc = Convert.ToDecimal(txt_descontototaldoc.Text);
                        decimal DescontoTotal = DescProduto + DescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_descontototaldoc.Text = DescontoTotal.ToString();
                    }
                    else
                    {
                        //SOMA OS VALORES
                        decimal DescProduto = Convert.ToDecimal(txt_descontoproduto.Text);
                        decimal DescTotalDoc = Convert.ToDecimal(txt_descontototaldoc.Text);
                        decimal DescontoTotal = DescProduto + DescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_descontototaldoc.Text = DescontoTotal.ToString();
                    }
                    #endregion

                    #region 'SOMA O ACRÉSCIMO'
                    if (txt_acrescimoproduto.Text != "" && txt_acrescimototaldoc.Text != "")
                    {
                        ///SOMA OS VALORES
                        decimal AcrescProduto = Convert.ToDecimal(txt_acrescimoproduto.Text);
                        decimal AcrescTotalDoc = Convert.ToDecimal(txt_acrescimototaldoc.Text);
                        decimal AcrescimoTotal = AcrescProduto + AcrescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_acrescimototaldoc.Text = AcrescimoTotal.ToString();
                    }
                    else
                    {
                        //SOMA OS VALORES
                        decimal AcrescProduto = Convert.ToDecimal(txt_acrescimoproduto.Text);
                        decimal AcrescTotalDoc = Convert.ToDecimal(txt_acrescimototaldoc.Text);
                        decimal AcrescimoTotal = AcrescProduto + AcrescTotalDoc;
                        //MOSTRA O RESULTADO
                        txt_acrescimototaldoc.Text = AcrescimoTotal.ToString();
                    }
                    #endregion

                    #region "ADICIONAR PRODUTO E FAZ A SOMA DENTRO DA LISTA"

                    //ADICIONA NA LISTA
                    add(txt_idproduto.Text, txt_descricaoproduto.Text, txt_unidadevenda.Text, txt_precounitproduto.Text, txt_quantidadeproduto.Text, txt_descontoproduto.Text, txt_acrescimoproduto.Text, txt_vlrtotalproduto.Text);

                    //REALIZA A SOMA TOTAL DENTRO DA LISTVIEW
                    var vlrtotal = 0m;
                    for (int i = 0; i < lvw_produtosdoc.Items.Count; i++)
                    {
                        vlrtotal += decimal.Parse(lvw_produtosdoc.Items[i].SubItems[7].Text); ;
                    }
                    txt_vlrtotaldoc.Text = vlrtotal.ToString("N");
                    //txt_vlrtotaldoc.Text = vlrtotal.ToString("C");   

                    #endregion

                    #region "LIMPAS AS CAIXAS"            
                    //ITENS
                    lbIdProduto.Text = "";
                    lbIdProduto.Text = txt_idproduto.Text;
                    txt_idproduto.Text = "";
                    txt_descricaoproduto.Text = "";
                    txt_unidadevenda.Text = "";
                    txt_precounitproduto.Text = "";
                    txt_quantidadeproduto.Text = "";
                    txt_descontoproduto.Text = "";
                    txt_acrescimoproduto.Text = "";
                    txt_vlrtotalproduto.Text = "";
                    #endregion

                    #region "ATIVA/DESATIVA BOTOES"
                    //ATIVA/DESATIVA BOTOES
                    btNovo.Enabled = false;
                    btGravar.Enabled = true;
                    btAlterar.Enabled = false;
                    btEditar.Enabled = false;
                    btCancelar.Enabled = true;
                    btConsultar.Enabled = false;
                    btRelatorio.Enabled = false;
                    btFechar.Enabled = false;
                    btnCerrar.Enabled = false;
                    btAddProduto.Enabled = true;
                    #endregion

                    #region 'COLOCA O FOCO'
                    //COLOCA O FOCUS
                    txt_idproduto.Focus();
                    #endregion
                }
                #endregion                
            }
            else
            {
                #region 'MENSAGEM'
                //MENSAGEM DE EXECUÇÃO
                MessageBox.Show("Preencha todos os campos para lançar!!!");
                #endregion

                #region "LIMPAS AS CAIXAS"            
                //ITENS
                txt_idproduto.Text = "";
                txt_descricaoproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
                txt_quantidadeproduto.Text = "";
                txt_descontoproduto.Text = "";
                txt_acrescimoproduto.Text = "";
                txt_vlrtotalproduto.Text = "";
                #endregion

                #region 'COLOCA O FOCO'
                //COLOCA O FOCUS
                txt_idproduto.Focus();
                #endregion
            }
            #endregion
        }

        private void btExcProduto_Click(object sender, EventArgs e)
        {
            #region 'EXCLUIR ITEM DA LISTVIEW'        
            if (txt_idproduto.Text != "")
            {
                for (int i = lvw_produtosdoc.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem li = lvw_produtosdoc.SelectedItems[i];
                    lvw_produtosdoc.Items.Remove(li);
                }
            }

            //EXCLUI COM A TECLA DELETE
            //if (e.KeyCode == Keys.Delete)
            //{
            //    for (int i = lvw_produtosdoc.SelectedItems.Count - 1; i >= 0; i--)
            //    {
            //        ListViewItem li = lvw_produtosdoc.SelectedItems[i];
            //        lvw_produtosdoc.Items.Remove(li);
            //    }
            //}
            #endregion

            #region 'VERIFICA SE TEM DADOS PARA DIMINUIR VALORES E QUANTIDADES'
            if (txt_idproduto.Text != "" && txt_descricaoproduto.Text != "" && txt_unidadevenda.Text != "" && txt_precounitproduto.Text != "" && txt_quantidadeproduto.Text != "" && txt_descontoproduto.Text != "" && txt_acrescimoproduto.Text != "" && txt_vlrtotalproduto.Text != "")
            {
                #region 'CONDIÇÃO PARA FORMATAR'
                if (txt_unidadevenda.Text == "UN")
                {
                    #region "SOMA A QUANTIDADE DE PRODUTOS"
                    if (txt_qnttotalprodutosdoc.Text != "" && txt_qnttotalprodutosdoc.Text != "00")
                    {
                        //REALIZA A SOMA DAS CAIXAS  
                        int qnt = 1;
                        int qnt1 = Convert.ToInt32(qnt);
                        int qnt2 = Convert.ToInt32(txt_qnttotalprodutosdoc.Text);
                        int qnttotal = qnt2 - qnt1;
                        txt_qnttotalprodutosdoc.Text = Convert.ToString(qnttotal);
                    }
                    else
                    {
                        txt_qnttotalprodutosdoc.Text = "00";
                    }
                    #endregion

                    #region 'SOMA O DESCONTO'
                    if (txt_descontoproduto.Text != "" && txt_descontototaldoc.Text != "")
                    {
                        //SOMA OS VALORES
                        decimal DescProduto = Convert.ToDecimal(txt_descontoproduto.Text);
                        decimal DescTotalDoc = Convert.ToDecimal(txt_descontototaldoc.Text);
                        decimal DescontoTotal = DescTotalDoc - DescProduto;
                        //MOSTRA O RESULTADO
                        txt_descontototaldoc.Text = DescontoTotal.ToString();
                    }
                    else
                    {
                        txt_descontototaldoc.Text = "0,00";
                    }
                    #endregion

                    #region 'SOMA O ACRÉSCIMO'
                    if (txt_acrescimoproduto.Text != "" && txt_acrescimototaldoc.Text != "")
                    {
                        ///SOMA OS VALORES
                        decimal AcrescProduto = Convert.ToDecimal(txt_acrescimoproduto.Text);
                        decimal AcrescTotalDoc = Convert.ToDecimal(txt_acrescimototaldoc.Text);
                        decimal AcrescimoTotal = AcrescTotalDoc - AcrescProduto;
                        //MOSTRA O RESULTADO
                        txt_acrescimototaldoc.Text = AcrescimoTotal.ToString();
                    }
                    else
                    {
                        txt_acrescimototaldoc.Text = "0,00";
                    }
                    #endregion

                    #region "ADICIONAR PRODUTO E FAZ A SOMA DENTRO DA LISTA"
                    //REALIZA A SOMA TOTAL DENTRO DA LISTVIEW
                    var vlrtotal = 0m;
                    for (int i = 0; i < lvw_produtosdoc.Items.Count; i++)
                    {
                        vlrtotal += decimal.Parse(lvw_produtosdoc.Items[i].SubItems[7].Text); ;
                    }
                    txt_vlrtotaldoc.Text = vlrtotal.ToString("N");
                    #endregion

                    #region "LIMPAS AS CAIXAS"            
                    //ITENS
                    txt_idproduto.Text = "";
                    txt_descricaoproduto.Text = "";
                    txt_unidadevenda.Text = "";
                    txt_precounitproduto.Text = "";
                    txt_quantidadeproduto.Text = "";
                    txt_descontoproduto.Text = "";
                    txt_acrescimoproduto.Text = "";
                    txt_vlrtotalproduto.Text = "";
                    #endregion

                    #region "ATIVA/DESATIVA BOTOES"
                    //ATIVA/DESATIVA BOTOES
                    btNovo.Enabled = false;
                    btGravar.Enabled = true;
                    btAlterar.Enabled = false;
                    btEditar.Enabled = false;
                    btCancelar.Enabled = true;
                    btConsultar.Enabled = false;
                    btRelatorio.Enabled = false;
                    btFechar.Enabled = false;
                    btnCerrar.Enabled = false;
                    btAddProduto.Enabled = true;
                    #endregion

                    #region 'COLOCA O FOCO'
                    //COLOCA O FOCUS
                    txt_idproduto.Focus();
                    #endregion
                }
                else if (txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
                {
                    #region "SOMA A QUANTIDADE DE PRODUTOS"
                    if (txt_qnttotalprodutosdoc.Text != "" && txt_qnttotalprodutosdoc.Text != "00")
                    {
                        //REALIZA A SOMA DAS CAIXAS  
                        int qnt = 1;
                        int qnt1 = Convert.ToInt32(qnt);
                        int qnt2 = Convert.ToInt32(txt_qnttotalprodutosdoc.Text);
                        int qnttotal = qnt2 - qnt1;
                        txt_qnttotalprodutosdoc.Text = Convert.ToString(qnttotal);
                    }
                    else
                    {
                        txt_qnttotalprodutosdoc.Text = "00";
                    }
                    #endregion

                    #region 'SOMA O DESCONTO'
                    if (txt_descontoproduto.Text != "" && txt_descontototaldoc.Text != "")
                    {
                        //SOMA OS VALORES
                        decimal DescProduto = Convert.ToDecimal(txt_descontoproduto.Text);
                        decimal DescTotalDoc = Convert.ToDecimal(txt_descontototaldoc.Text);
                        decimal DescontoTotal = DescTotalDoc - DescProduto;
                        //MOSTRA O RESULTADO
                        txt_descontototaldoc.Text = DescontoTotal.ToString();
                    }
                    else
                    {
                        txt_qnttotalprodutosdoc.Text = "0,00";
                    }
                    #endregion

                    #region 'SOMA O ACRÉSCIMO'
                    if (txt_acrescimoproduto.Text != "" && txt_acrescimototaldoc.Text != "")
                    {
                        ///SOMA OS VALORES
                        decimal AcrescProduto = Convert.ToDecimal(txt_acrescimoproduto.Text);
                        decimal AcrescTotalDoc = Convert.ToDecimal(txt_acrescimototaldoc.Text);
                        decimal AcrescimoTotal = AcrescTotalDoc - AcrescProduto;
                        //MOSTRA O RESULTADO
                        txt_acrescimototaldoc.Text = AcrescimoTotal.ToString();
                    }
                    else
                    {
                        txt_qnttotalprodutosdoc.Text = "0,00";
                    }
                    #endregion

                    #region "ADICIONAR PRODUTO E FAZ A SOMA DENTRO DA LISTA"
                    //REALIZA A SOMA TOTAL DENTRO DA LISTVIEW
                    var vlrtotal = 0m;
                    for (int i = 0; i < lvw_produtosdoc.Items.Count; i++)
                    {
                        vlrtotal += decimal.Parse(lvw_produtosdoc.Items[i].SubItems[7].Text); ;
                    }
                    txt_vlrtotaldoc.Text = vlrtotal.ToString("N");
                    #endregion

                    #region "LIMPAS AS CAIXAS"            
                    //ITENS
                    txt_idproduto.Text = "";
                    txt_descricaoproduto.Text = "";
                    txt_unidadevenda.Text = "";
                    txt_precounitproduto.Text = "";
                    txt_quantidadeproduto.Text = "";
                    txt_descontoproduto.Text = "";
                    txt_acrescimoproduto.Text = "";
                    txt_vlrtotalproduto.Text = "";
                    #endregion

                    #region "ATIVA/DESATIVA BOTOES"
                    //ATIVA/DESATIVA BOTOES
                    btNovo.Enabled = false;
                    btGravar.Enabled = true;
                    btAlterar.Enabled = false;
                    btEditar.Enabled = false;
                    btCancelar.Enabled = true;
                    btConsultar.Enabled = false;
                    btRelatorio.Enabled = false;
                    btFechar.Enabled = false;
                    btnCerrar.Enabled = false;
                    btAddProduto.Enabled = true;
                    #endregion

                    #region 'COLOCA O FOCO'
                    //COLOCA O FOCUS
                    txt_idproduto.Focus();
                    #endregion
                }
                #endregion                
            }
            else
            {
                #region 'MENSAGEM'
                //MENSAGEM DE EXECUÇÃO
                MessageBox.Show("Selecione um ítem para deletar!!!");
                #endregion

                #region "LIMPAS AS CAIXAS"            
                //ITENS
                txt_idproduto.Text = "";
                txt_descricaoproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
                txt_quantidadeproduto.Text = "";
                txt_descontoproduto.Text = "";
                txt_acrescimoproduto.Text = "";
                txt_vlrtotalproduto.Text = "";
                #endregion

                #region 'COLOCA O FOCO'
                //COLOCA O FOCUS
                txt_idproduto.Focus();
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            //LIMPA AS CAIXAS
            txt_idproduto.Text = "";
            txt_descricaoproduto.Text = "";
            txt_unidadevenda.Text = "";
            txt_precounitproduto.Text = "";
            txt_quantidadeproduto.Text = "";
            txt_descontoproduto.Text = "";
            txt_acrescimoproduto.Text = "";
            txt_vlrtotalproduto.Text = "";
            #endregion

            #region "ATIVA AS CAIXAS"
            //ITENS
            txt_idproduto.Enabled = true;
            txt_descricaoproduto.Enabled = true;
            txt_unidadevenda.Enabled = false;
            txt_precounitproduto.Enabled = false;
            txt_quantidadeproduto.Enabled = true;
            txt_descontoproduto.Enabled = true;
            txt_acrescimoproduto.Enabled = true;
            txt_vlrtotalproduto.Enabled = false;
            lvw_produtosdoc.Enabled = true;
            //TOTAIS
            txt_descontototaldoc.Enabled = false;
            txt_acrescimototaldoc.Enabled = false;
            txt_qnttotalprodutosdoc.Enabled = false;
            txt_vlrtotaldoc.Enabled = false;
            #endregion

            #region "ATIVA/DESATIVA BOTOES"
            btNovo.Enabled = false;
            btGravar.Enabled = true;
            btAlterar.Enabled = false;
            btEditar.Enabled = false;
            btCancelar.Enabled = true;
            btConsultar.Enabled = false;
            btRelatorio.Enabled = false;
            btFechar.Enabled = false;
            btnCerrar.Enabled = false;
            btAddProduto.Enabled = true;
            btExcProduto.Enabled = false;
            #endregion

            #region 'COLOCA O FOCO'
            //COLOCA O FOCUS
            txt_idproduto.Focus();
            #endregion
        }

        private void imNovaOperacao_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btCancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmNFOperacoes frm = new FrmNFOperacoes();
            frm.ShowDialog();
            #endregion            
        }

        private void imNovoFornecedor_Click(object sender, EventArgs e)
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

        private void inNovoPagForma_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btCancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmPagamentoFormas frm = new FrmPagamentoFormas();
            frm.ShowDialog();
            #endregion            
        }

        private void imNovoPagPrazo_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btCancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmPagamentoPrazos frm = new FrmPagamentoPrazos();
            frm.ShowDialog();
            #endregion            
        }

        private void imNovoProduto_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btCancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmProdutos frm = new FrmProdutos();
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

        private void txt_idoperacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_modelodoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_seriedoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_idfornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_idproduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_quantidadeproduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'CONDIÇÃO PARA FORMATAR'
            if (txt_unidadevenda.Text == "UN")
            {
                #region 'ACEITA APENAS NÚMEROS'
                //Aceita apenas números, tecla backspace.
                if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
                {
                    e.Handled = true;
                }
                #endregion
            }
            else if (txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
            {
                #region 'ACEITA APENAS NUMERO E UMA VIRGULA'
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                {
                    e.Handled = true;
                    //MessageBox.Show("este campo aceita somente numero e virgula");
                }
                if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                    //MessageBox.Show("este campo não aceita ponto");
                }
                if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                {
                    e.Handled = true;
                    //MessageBox.Show("este campo não aceita duas virgulas");
                }
                #endregion
            }
            #endregion
        }

        private void txt_precounitproduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_descontoproduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_acrescimoproduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_vlrtotalproduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_descontototaldoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_acrescimototaldoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_qnttotalprodutosdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'CONDIÇÃO PARA FORMATAR'
            if (txt_unidadevenda.Text == "UN")
            {
                #region 'ACEITA APENAS NÚMEROS'
                //Aceita apenas números, tecla backspace.
                if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
                {
                    e.Handled = true;
                }
                #endregion
            }
            else if (txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
            {
                #region 'ACEITA APENAS NUMERO E UMA VIRGULA'
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                {
                    e.Handled = true;
                    //MessageBox.Show("este campo aceita somente numero e virgula");
                }
                if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                    //MessageBox.Show("este campo não aceita ponto");
                }
                if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                {
                    e.Handled = true;
                    //MessageBox.Show("este campo não aceita duas virgulas");
                }
                #endregion
            }
            #endregion
        }

        private void txt_vlrtotaldoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void cbo_estadofornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_formapgdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_prazopgdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void txtmsk_dtemissaodoc_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
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
                txtmsk_dtemissaodoc.Text = "";
                txtmsk_dtemissaodoc.Focus();
            }
            #endregion
        }

        private void txtmsk_dtreferenciadoc_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
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
                txtmsk_dtreferenciadoc.Text = "";
                txtmsk_dtreferenciadoc.Focus();
            }
            #endregion
        }

        private void txt_idoperacao_Leave(object sender, EventArgs e)
        {
            #region "PREENCHE CAIXAS"
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_nfeoperacoes WHERE ID = '" + txt_idoperacao.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    
                                                      
            //Limpa as caixas
            txt_idoperacao.Text = "";
            txt_descricaooperacao.Text = "";

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                txt_idoperacao.Text = dr["ID"].ToString();
                txt_descricaooperacao.Text = dr["DescricaoOperacoes"].ToString();
                txt_idoperacao.TextAlign = HorizontalAlignment.Center;
            }
            //Fecha a conexão
            cmd.Connection.Close();
            #endregion

            #region 'VERIFICA AS CAIXAS'
            if (txt_idoperacao.Text != "" && txt_descricaooperacao.Text != "")
            {
                //Coloca o foco
                txt_modelodoc.Focus();
            }
            else
            {
                //Limpa as caixas
                txt_idoperacao.Text = "";
                txt_descricaooperacao.Text = "";
            }
            #endregion
        }

        private void txt_descricaooperacao_Leave(object sender, EventArgs e)
        {
            #region "PREENCHE CAIXAS"
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_nfeoperacoes WHERE DescricaoOperacoes = '" + txt_descricaooperacao.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    
            
            //Limpa as caixas
            txt_idoperacao.Text = "";
            txt_descricaooperacao.Text = "";

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                txt_idoperacao.Text = dr["ID"].ToString();
                txt_descricaooperacao.Text = dr["DescricaoOperacoes"].ToString();
                txt_idoperacao.TextAlign = HorizontalAlignment.Center;
            }
            //Fecha a conexão
            cmd.Connection.Close();
            #endregion

            #region 'VERIFICA AS CAIXAS'
            if (txt_idoperacao.Text != "" && txt_descricaooperacao.Text != "")
            {
                //Coloca o foco
                txt_modelodoc.Focus();
            }
            else
            {
                //Limpa as caixas
                txt_idoperacao.Text = "";
                txt_descricaooperacao.Text = "";
            }
            #endregion
        }

        private void txt_numerodoc_Leave(object sender, EventArgs e)
        {
            #region "RETIRA O ZERO DA ESQUERDA"
            string NNumeroNf = txt_numerodoc.Text;
            txt_numerodoc.Text = NNumeroNf.TrimStart('0');
            #endregion

            #region 'COMEÇA A VERIFICAÇÃO DE DADOS'

            #region 'BUSCA OS DADOS E SELECIONA'
            i = 0;
            cn.Open();
            MySqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tb_nfe where Documentonr='" + txt_numerodoc.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            #endregion

            #region 'VERIFICA SE A NF JA ESTA CADASTRADA'
            if (i == 0)
            {
                //Não faz nada
            }
            else
            {
                #region 'MENSAGEM'
                MessageBox.Show("NF já cadastrada!!!");
                #endregion

                #region 'LIMPA AS CAIXAS E COLOCA O FOCO'
                txt_numerodoc.Text = "";
                txt_numerodoc.Focus();
                #endregion
            }
            #endregion

            #region 'FECHA A CONEXÃO'
            cn.Close(); //Fecha a conexão
            #endregion

            #endregion
        }

        private void txt_idfornecedor_Leave(object sender, EventArgs e)
        {
            #region "PREENCHE CAIXAS"
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_cadastromultiplo WHERE ID = '" + txt_idfornecedor.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    

            //Limpa as caixas
            txt_idfornecedor.Text = "";
            txt_descricaofornecedor.Text = "";

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                txt_idfornecedor.Text = dr["ID"].ToString();
                txt_descricaofornecedor.Text = dr["NomeRazaoSocial"].ToString();
                txt_idfornecedor.TextAlign = HorizontalAlignment.Center;
            }
            //Fecha a conexão
            cmd.Connection.Close();
            #endregion

            #region 'VERIFICA AS CAIXAS'
            if (txt_idfornecedor.Text != "" && txt_descricaofornecedor.Text != "")
            {
                //Coloca o foco
                cbo_estadofornecedor.Focus();
            }
            else
            {
                //Limpa as caixas
                txt_idfornecedor.Text = "";
                txt_descricaofornecedor.Text = "";
            }
            #endregion
        }

        private void txt_descricaofornecedor_Leave(object sender, EventArgs e)
        {
            #region "PREENCHE CAIXAS"
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_cadastromultiplo WHERE NomeRazaoSocial = '" + txt_descricaofornecedor.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    

            //Limpa as caixas
            txt_idfornecedor.Text = "";
            txt_descricaofornecedor.Text = "";

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                txt_idfornecedor.Text = dr["ID"].ToString();
                txt_descricaofornecedor.Text = dr["NomeRazaoSocial"].ToString();
                txt_idfornecedor.TextAlign = HorizontalAlignment.Center;
            }
            //Fecha a conexão
            cmd.Connection.Close();
            //Coloca o foco
            cbo_estadofornecedor.Focus();
            #endregion

            #region 'VERIFICA AS CAIXAS'
            if (txt_idfornecedor.Text != "" && txt_descricaofornecedor.Text != "")
            {
                //Coloca o foco
                cbo_estadofornecedor.Focus();
            }
            else
            {
                //Limpa as caixas
                txt_idfornecedor.Text = "";
                txt_descricaofornecedor.Text = "";
            }
            #endregion
        }

        private void txt_idproduto_Leave(object sender, EventArgs e)
        {
            #region "PREENCHE CAIXAS"
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_produtos WHERE ID = '" + txt_idproduto.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    

            //Limpa as caixas
            txt_idproduto.Text = "";
            txt_descricaoproduto.Text = "";
            txt_unidadevenda.Text = "";
            txt_precounitproduto.Text = "";
            txt_quantidadeproduto.Text = "";
            txt_descontoproduto.Text = "";
            txt_descontoproduto.Text = "0,00";
            txt_acrescimoproduto.Text = "";
            txt_acrescimoproduto.Text = "0,00";
            txt_vlrtotalproduto.Text = "";
            txt_vlrtotalproduto.Text = "0,00";

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                txt_idproduto.Text = dr["ID"].ToString();
                txt_descricaoproduto.Text = dr["DescricaoProduto"].ToString();
                txt_unidadevenda.Text = dr["UnVenda"].ToString();
                txt_precounitproduto.Text = dr["VlrVenda"].ToString();
                txt_idproduto.TextAlign = HorizontalAlignment.Center;
            }
            //Fecha a conexão
            cmd.Connection.Close();
            #endregion

            #region 'VERIFICA AS CAIXAS'
            if (txt_idproduto.Text != "" && txt_descricaoproduto.Text != "" && txt_unidadevenda.Text != "" && txt_precounitproduto.Text != "")
            {
                //Coloca o foco
                txt_quantidadeproduto.Focus();
            }
            else
            {
                //Limpa as caixas
                txt_idproduto.Text = "";
                txt_descricaoproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
            }
            #endregion

            #region 'CONDIÇÃO PARA FORMATAR UN OU KG'
            if (txt_unidadevenda.Text != "" && txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_quantidadeproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_quantidadeproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_quantidadeproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                    if (txt_precounitproduto.Text != "")
                    {
                        //Cálculos
                        txt_vlrtotalproduto.Text = "";
                        decimal QntProdutos = Convert.ToDecimal(txt_quantidadeproduto.Text);
                        decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                        decimal VlrTotal = Convert.ToDecimal(txt_vlrtotalproduto.Text);
                        VlrTotal = QntProdutos * PrecoUnitprodutos;
                        txt_vlrtotalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                        txt_descontoproduto.Focus();
                    }
                    else
                    {
                        txt_descricaoproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_quantidadeproduto.Focus();
                }
                #endregion
            }
            else
            if (txt_unidadevenda.Text != "" && txt_unidadevenda.Text == "UN")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_quantidadeproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_quantidadeproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_quantidadeproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                    if (txt_precounitproduto.Text != "")
                    {
                        //Cálculos
                        txt_vlrtotalproduto.Text = "";
                        decimal QntProdutos = Convert.ToDecimal(txt_quantidadeproduto.Text);
                        decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                        decimal VlrTotal = Convert.ToDecimal(txt_vlrtotalproduto.Text);
                        VlrTotal = QntProdutos * PrecoUnitprodutos;
                        txt_vlrtotalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                        txt_descontoproduto.Focus();
                    }
                    else
                    {
                        txt_descricaoproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_quantidadeproduto.Focus();
                }
                #endregion
            }
            #endregion
        }

        private void txt_descricaoproduto_Leave(object sender, EventArgs e)
        {
            #region "PREENCHE CAIXAS"
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_produtos WHERE DescricaoProduto = '" + txt_descricaoproduto.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    

            //Limpa as caixas
            txt_idproduto.Text = "";
            txt_descricaoproduto.Text = "";
            txt_unidadevenda.Text = "";
            txt_precounitproduto.Text = "";
            txt_quantidadeproduto.Text = "";
            txt_descontoproduto.Text = "";
            txt_descontoproduto.Text = "0,00";
            txt_acrescimoproduto.Text = "";
            txt_acrescimoproduto.Text = "0,00";
            txt_vlrtotalproduto.Text = "";
            txt_vlrtotalproduto.Text = "0,00";

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                txt_idproduto.Text = dr["ID"].ToString();
                txt_descricaoproduto.Text = dr["DescricaoProduto"].ToString();
                txt_unidadevenda.Text = dr["UnVenda"].ToString();
                txt_precounitproduto.Text = dr["VlrVenda"].ToString();
                txt_idproduto.TextAlign = HorizontalAlignment.Center;
            }
            //Fecha a conexão
            cmd.Connection.Close();
            #endregion

            #region 'VERIFICA AS CAIXAS'
            if (txt_idproduto.Text != "" && txt_descricaoproduto.Text != "" && txt_unidadevenda.Text != "" && txt_precounitproduto.Text != "")
            {
                //Coloca o foco
                txt_quantidadeproduto.Focus();
            }
            else
            {
                //Limpa as caixas
                txt_idproduto.Text = "";
                txt_descricaoproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
            }
            #endregion

            #region 'CONDIÇÃO PARA FORMATAR UN OU KG'
            if (txt_unidadevenda.Text != "" && txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_quantidadeproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_quantidadeproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_quantidadeproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                    if (txt_precounitproduto.Text != "")
                    {
                        //Cálculos
                        txt_vlrtotalproduto.Text = "";
                        decimal QntProdutos = Convert.ToDecimal(txt_quantidadeproduto.Text);
                        decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                        decimal VlrTotal = Convert.ToDecimal(txt_vlrtotalproduto.Text);
                        VlrTotal = QntProdutos * PrecoUnitprodutos;
                        txt_vlrtotalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                        txt_descontoproduto.Focus();
                    }
                    else
                    {
                        txt_descricaoproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_quantidadeproduto.Focus();
                }
                #endregion
            }
            else
            if (txt_unidadevenda.Text != "" && txt_unidadevenda.Text == "UN")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_quantidadeproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_quantidadeproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_quantidadeproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                    if (txt_precounitproduto.Text != "")
                    {
                        //Cálculos
                        txt_vlrtotalproduto.Text = "";
                        decimal QntProdutos = Convert.ToDecimal(txt_quantidadeproduto.Text);
                        decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                        decimal VlrTotal = Convert.ToDecimal(txt_vlrtotalproduto.Text);
                        VlrTotal = QntProdutos * PrecoUnitprodutos;
                        txt_vlrtotalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                        txt_descontoproduto.Focus();
                    }
                    else
                    {
                        txt_descricaoproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_quantidadeproduto.Focus();
                }
                #endregion
            }
            #endregion
        }

        private void txt_quantidadeproduto_Leave(object sender, EventArgs e)
        {
            #region "LIMPAS AS CAIXAS" 
            //Limpa as caixas
            txt_descontoproduto.Text = "";
            txt_descontoproduto.Text = "0,00";
            txt_acrescimoproduto.Text = "";
            txt_acrescimoproduto.Text = "0,00";
            #endregion

            #region "CONDIÇÃO PARA VERIFICAR CAIXAS"
            if (txt_idproduto.Text != "" && txt_unidadevenda.Text == "UN")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_quantidadeproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_quantidadeproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_quantidadeproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                    if (txt_precounitproduto.Text != "")
                    {
                        //Cálculos
                        txt_vlrtotalproduto.Text = "";
                        decimal QntProdutos = Convert.ToDecimal(txt_quantidadeproduto.Text);
                        decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                        decimal VlrTotal = Convert.ToDecimal(txt_vlrtotalproduto.Text);
                        VlrTotal = QntProdutos * PrecoUnitprodutos;
                        txt_vlrtotalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                        txt_descontoproduto.Focus();
                    }
                    else
                    {
                        txt_descricaoproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_quantidadeproduto.Focus();
                }
                #endregion
            }
            else if (txt_idproduto.Text != "" && txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_quantidadeproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_quantidadeproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_quantidadeproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                    if (txt_precounitproduto.Text != "")
                    {
                        //Cálculos
                        txt_vlrtotalproduto.Text = "";
                        decimal QntProdutos = Convert.ToDecimal(txt_quantidadeproduto.Text);
                        decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                        decimal VlrTotal = Convert.ToDecimal(txt_vlrtotalproduto.Text);
                        VlrTotal = QntProdutos * PrecoUnitprodutos;
                        txt_vlrtotalproduto.Text = Math.Round(VlrTotal,2).ToString();
                        txt_descontoproduto.Focus();
                    }
                    else
                    {
                        txt_descricaoproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_quantidadeproduto.Focus();
                }
                #endregion
            }
            else
            {
                #region "LIMPAS AS CAIXAS"            
                //ITENS
                //Limpa as caixas
                txt_idproduto.Text = "";
                txt_descricaoproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
                txt_quantidadeproduto.Text = "";
                txt_descontoproduto.Text = "";
                txt_descontoproduto.Text = "0,00";
                txt_acrescimoproduto.Text = "";
                txt_acrescimoproduto.Text = "0,00";
                txt_vlrtotalproduto.Text = "";
                txt_vlrtotalproduto.Text = "0,00";
                #endregion

                #region 'COLOCA O FOCO'
                //COLOCA O FOCUS
                txt_idproduto.Focus();
                #endregion
            }
            #endregion
        }

        private void txt_descontoproduto_Leave(object sender, EventArgs e)
        {
            #region "CONDIÇÃO PARA VERIFICAR CAIXAS"
            if (txt_idproduto.Text != "" && txt_unidadevenda.Text == "UN")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_quantidadeproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_quantidadeproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_quantidadeproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                    if (txt_precounitproduto.Text != "")
                    {                        
                        #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                        if (txt_descontoproduto.Text != "")
                        {
                            //Cálculos
                            txt_vlrtotalproduto.Text = "";
                            decimal QntProdutos = Convert.ToDecimal(txt_quantidadeproduto.Text);
                            decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                            decimal DescProdutos = Convert.ToDecimal(txt_descontoproduto.Text);
                            decimal VlrTotal = Convert.ToDecimal(txt_vlrtotalproduto.Text);
                            VlrTotal = (QntProdutos * PrecoUnitprodutos) - DescProdutos;
                            txt_vlrtotalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                            txt_acrescimoproduto.Focus();
                        }
                        else
                        {
                            txt_descontoproduto.Focus();
                        }
                        #endregion
                    }
                    else
                    {
                        txt_descricaoproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_quantidadeproduto.Focus();
                }
                #endregion
            }
            else if (txt_idproduto.Text != "" && txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_quantidadeproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_quantidadeproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_quantidadeproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                    if (txt_precounitproduto.Text != "")
                    {
                        #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                        if (txt_descontoproduto.Text != "")
                        {
                            //Cálculos
                            txt_vlrtotalproduto.Text = "";
                            decimal QntProdutos = Convert.ToDecimal(txt_quantidadeproduto.Text);
                            decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                            decimal DescProdutos = Convert.ToDecimal(txt_descontoproduto.Text);
                            decimal VlrTotal = Convert.ToDecimal(txt_vlrtotalproduto.Text);
                            VlrTotal = (QntProdutos * PrecoUnitprodutos) - DescProdutos;
                            txt_vlrtotalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                            txt_acrescimoproduto.Focus();
                        }
                        else
                        {
                            txt_descontoproduto.Focus();
                        }
                        #endregion
                    }
                    else
                    {
                        txt_precounitproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_quantidadeproduto.Focus();
                }
                #endregion
            }
            else
            {
                #region "LIMPAS AS CAIXAS"            
                //ITENS
                txt_idproduto.Text = "";
                txt_descricaoproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
                txt_quantidadeproduto.Text = "";
                txt_descontoproduto.Text = "";
                txt_acrescimoproduto.Text = "";
                txt_vlrtotalproduto.Text = "";
                #endregion

                #region 'COLOCA O FOCO'
                //COLOCA O FOCUS
                txt_idproduto.Focus();
                #endregion
            }
            #endregion                       
        }

        private void txt_acrescimoproduto_Leave(object sender, EventArgs e)
        {
            #region "CONDIÇÃO PARA VERIFICAR CAIXAS"
            if (txt_idproduto.Text != "" && txt_unidadevenda.Text == "UN")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_quantidadeproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_quantidadeproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_quantidadeproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                    if (txt_precounitproduto.Text != "")
                    {
                        #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                        if (txt_descontoproduto.Text != "")
                        {                            
                            #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                            if (txt_acrescimoproduto.Text != "")
                            {
                                //Cálculos
                                txt_vlrtotalproduto.Text = "";
                                decimal QntProdutos = Convert.ToDecimal(txt_quantidadeproduto.Text);
                                decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                                decimal DescProdutos = Convert.ToDecimal(txt_descontoproduto.Text);
                                decimal AcrescProdutos = Convert.ToDecimal(txt_acrescimoproduto.Text);
                                decimal VlrTotal = Convert.ToDecimal(txt_vlrtotalproduto.Text);
                                VlrTotal = (QntProdutos * PrecoUnitprodutos) - DescProdutos + AcrescProdutos;
                                txt_vlrtotalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                                btAddProduto.Focus();
                            }
                            else
                            {
                                txt_acrescimoproduto.Focus();
                            }
                            #endregion
                        }
                        else
                        {
                            txt_descontoproduto.Focus();
                        }
                        #endregion
                    }
                    else
                    {
                        txt_precounitproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_quantidadeproduto.Focus();
                }
                #endregion
            }
            else if (txt_idproduto.Text != "" && txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_quantidadeproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_quantidadeproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_quantidadeproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                    if (txt_precounitproduto.Text != "")
                    {
                        #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                        if (txt_descontoproduto.Text != "")
                        {                            
                            #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                            if (txt_acrescimoproduto.Text != "")
                            {
                                //Cálculos
                                txt_vlrtotalproduto.Text = "";
                                decimal QntProdutos = Convert.ToDecimal(txt_quantidadeproduto.Text);
                                decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                                decimal DescProdutos = Convert.ToDecimal(txt_descontoproduto.Text);
                                decimal AcrescProdutos = Convert.ToDecimal(txt_acrescimoproduto.Text);
                                decimal VlrTotal = Convert.ToDecimal(txt_vlrtotalproduto.Text);
                                VlrTotal = (QntProdutos * PrecoUnitprodutos) - DescProdutos + AcrescProdutos;
                                txt_vlrtotalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                                btAddProduto.Focus();
                            }
                            else
                            {
                                txt_acrescimoproduto.Focus();
                            }
                            #endregion
                        }
                        else
                        {
                            txt_descontoproduto.Focus();
                        }
                        #endregion
                    }
                    else
                    {
                        txt_precounitproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_quantidadeproduto.Focus();
                }
                #endregion
            }
            else
            {
                #region "LIMPAS AS CAIXAS"            
                //ITENS
                txt_idproduto.Text = "";
                txt_descricaoproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
                txt_quantidadeproduto.Text = "";
                txt_descontoproduto.Text = "";
                txt_acrescimoproduto.Text = "";
                txt_vlrtotalproduto.Text = "";
                #endregion

                #region 'COLOCA O FOCO'
                //COLOCA O FOCUS
                txt_idproduto.Focus();
                #endregion
            }
            #endregion                     
        }

        private void txt_precounitproduto_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_precounitproduto);
            txt_precounitproduto.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txt_descontoproduto_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_descontoproduto);
            txt_descontoproduto.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txt_acrescimoproduto_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_acrescimoproduto);
            txt_acrescimoproduto.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txt_vlrtotalproduto_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_vlrtotalproduto);
            txt_vlrtotalproduto.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txt_descontototaldoc_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_descontototaldoc);
            txt_descontototaldoc.TextAlign = HorizontalAlignment.Center;
            #endregion                        
        }

        private void txt_acrescimototaldoc_TextChanged(object sender, EventArgs e)
        {            
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_acrescimototaldoc);
            txt_acrescimototaldoc.TextAlign = HorizontalAlignment.Center;
            #endregion                        
        }

        private void txt_vlrtotaldoc_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_vlrtotaldoc);
            txt_vlrtotaldoc.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void lvw_produtosdoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 'CARREGA AS CAIXAS SELECIONANDO O LISTVIEW'
            if (lvw_produtosdoc.SelectedItems.Count != 0)
            {
                if (lvw_produtosdoc.SelectedItems[0].Selected)
                {
                    txt_idproduto.Text = lvw_produtosdoc.FocusedItem.SubItems[0].Text;
                    txt_descricaoproduto.Text = lvw_produtosdoc.FocusedItem.SubItems[1].Text;
                    txt_unidadevenda.Text = lvw_produtosdoc.FocusedItem.SubItems[2].Text;
                    txt_precounitproduto.Text = lvw_produtosdoc.FocusedItem.SubItems[3].Text;
                    txt_quantidadeproduto.Text = lvw_produtosdoc.FocusedItem.SubItems[4].Text;
                    txt_descontoproduto.Text = lvw_produtosdoc.FocusedItem.SubItems[5].Text;
                    txt_acrescimoproduto.Text = lvw_produtosdoc.FocusedItem.SubItems[6].Text;
                    txt_vlrtotalproduto.Text = lvw_produtosdoc.FocusedItem.SubItems[7].Text;
                }
            }
            #endregion

            #region 'ATIVAR/DESATIVAR CAIXAS'
            //DESATIVA AS CAIXAS
            //ITENS
            txt_idproduto.Enabled = false;
            txt_descricaoproduto.Enabled = false;
            txt_unidadevenda.Enabled = false;
            txt_precounitproduto.Enabled = false;
            txt_quantidadeproduto.Enabled = false;
            txt_descontoproduto.Enabled = false;
            txt_acrescimoproduto.Enabled = false;
            txt_vlrtotalproduto.Enabled = false;
            lvw_produtosdoc.Enabled = true;
            //TOTAIS
            txt_descontototaldoc.Enabled = false;
            txt_acrescimototaldoc.Enabled = false;
            txt_qnttotalprodutosdoc.Enabled = false;
            txt_vlrtotaldoc.Enabled = false;
            #endregion

            #region "ATIVA/DESATIVA BOTOES"
            //ATIVA/DESATIVA BOTOES
            btNovo.Enabled = false;
            btGravar.Enabled = false;
            btAlterar.Enabled = false;
            btEditar.Enabled = true;
            btCancelar.Enabled = false;
            btConsultar.Enabled = false;
            btRelatorio.Enabled = false;
            btFechar.Enabled = false;
            btnCerrar.Enabled = false;
            btAddProduto.Enabled = false;
            btExcProduto.Enabled = true;
            #endregion                                                            
        }
    }
}
