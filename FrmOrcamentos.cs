using MySql.Data.MySqlClient;
using System;
using System.Collections;
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

namespace SIGRas
{
    public partial class FrmOrcamentos : Form
    {
        public FrmOrcamentos()
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
            cbo_formapagamento.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    cbo_formapagamento.Items.Add(datareader[0]);
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
            #region 'CAIXA PRAZO PAGAMENTO  
            //DECLARAÇÃO PARA PREENCHER A COMBOBOX
            cbo_prazopagamento.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    cbo_prazopagamento.Items.Add(datareader[0]);
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
        public void FillComboEntregaPrazos(string strSql, string tstr)
        {
            #region 'CAIXA PRAZO ENTREGA'
            //DECLARAÇÃO PARA PREENCHER A COMBOBOX
            cbo_prazoentrega.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    cbo_prazoentrega.Items.Add(datareader[0]);
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

        #region 'DECLARAÇÃO'
        StreamReader rdr = null;
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

        #region 'GERAR CÓDIGO ORÇAMENTO'
        private void GerarCodigoOrcamento()
        {
            #region "GERAR CÓDIGO ORÇAMENTO"
            //PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO - EXEMPLO 1
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT max(IdOrcamento) from tb_orcamentos";

            try
            {
                if (cmd.ExecuteScalar() == DBNull.Value)
                {
                    txt_idorcamento.Text = "1";
                }
                else
                {
                    Int32 ra = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    txt_idorcamento.Text = ra.ToString();
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
            #endregion
        }
        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            #region 'VERIFICA E LIMPA O ARQUIVO DE TEXTO'
            if (new FileInfo(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt").Length == 0)
            {
                // empty
            }
            else
            {
                List<string> mensagemLinha = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt");
                System.IO.File.WriteAllLines(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt", lines.Take<string>(lines.Length - 1000));
            }
            #endregion

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

        private void FrmOrcamentos_KeyDown(object sender, KeyEventArgs e)
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

        private void tc_orcamento_DrawItem(object sender, DrawItemEventArgs e)
        {
            #region 'MUDA A COR DA GUIA AO CLICAR'

            //FORMATAÇÃO DA TABCONTROL'
            TabPage CurrentTab = tc_orcamento.TabPages[e.Index];
            Rectangle ItemRect = tc_orcamento.GetTabRect(e.Index);
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
            if (tc_orcamento.Alignment == TabAlignment.Left || tc_orcamento.Alignment == TabAlignment.Right)
            {
                float RotateAngle = 90;
                if (tc_orcamento.Alignment == TabAlignment.Left)
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

        private void FrmOrcamentos_Load(object sender, EventArgs e)
        {
            #region "CARREGAR COMBOBOX COM DADOS DO BANCO"  

            #region 'CARREGAR COMBOBOX PAGAMENTO FORMAS
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
            #endregion

            #region 'CARREGAR COMBOBOX PAGAMENTO PRAZOS'
            //CARREGAR COMBOBOX PAGAMENTO PRAZOS
            try
            {
                string strSQL = "Select DescricaoPrazosPagamento from tb_prazospagamento order by DescricaoPrazosPagamento";
                string tstr = "tb_prazospagamento";
                FillComboPagamentoPrazos(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'CARREGAR COMBOBOX ENTREGA PRAZOS'
            //CARREGAR COMBOBOX ENTREGA PRAZOS
            try
            {
                string strSQL = "Select DescricaoPrazosEntrega from tb_prazosentrega order by DescricaoPrazosEntrega";
                string tstr = "tb_prazosentrega";
                FillComboEntregaPrazos(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #endregion

            #region 'AUTOCOMPLETE TEXTBOX CLIENTE'
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
            txt_cliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_cliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_cliente.AutoCompleteCustomSource = autotext1;
            cmd1.Connection.Close(); //Fecha a conexão 
            #endregion

            #region 'AUTOCOMPLETE TEXTBOX VENDEDOR'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd2.CommandText = "Select NomeRazaoSocial from tb_cadastromultiplo order by NomeRazaoSocial";
            cmd2.ExecuteNonQuery();
            MySqlDataReader datareader2;
            datareader2 = cmd2.ExecuteReader();
            AutoCompleteStringCollection autotext2 = new AutoCompleteStringCollection();

            while (datareader2.Read())
            {
                autotext2.Add(datareader2.GetString(0));
            }
            txt_vendedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_vendedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_vendedor.AutoCompleteCustomSource = autotext2;
            cmd2.Connection.Close(); //Fecha a conexão 
            #endregion

            #region 'AUTOCOMPLETE TEXTBOX PRODUTO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd3 = new MySqlCommand();
            cmd3.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd3.CommandText = "Select DescricaoProduto from tb_produtos order by DescricaoProduto";
            cmd3.ExecuteNonQuery();
            MySqlDataReader datareader3;
            datareader3 = cmd3.ExecuteReader();
            AutoCompleteStringCollection autotext3 = new AutoCompleteStringCollection();

            while (datareader3.Read())
            {
                autotext3.Add(datareader3.GetString(0));
            }
            txt_descricaoproduto.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_descricaoproduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_descricaoproduto.AutoCompleteCustomSource = autotext3;
            cmd3.Connection.Close(); //Fecha a conexão 
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_idorcamento.Text = "";
            txt_idempresa.Text = "";
            txt_empresa.Text = "";
            txtmsk_telefonefixoempresa.Text = "";
            txtmsk_telefonecelularempresa.Text = "";
            txt_emailempresa.Text = "";
            txt_idcliente.Text = "";
            txt_cliente.Text = "";
            txt_enderecocliente.Text = "";
            txt_numerocliente.Text = "";
            txt_bairrocliente.Text = "";
            txt_cidadecliente.Text = "";
            txtmsk_telefonefixocliente.Text = "";
            txtmsk_telefonecelularcliente.Text = "";
            txt_emailcliente.Text = "";
            txt_dataorcamento.Text = "";
            cbo_formapagamento.Text = "";
            cbo_prazopagamento.Text = "";
            cbo_prazoentrega.Text = "";
            txt_vendedor.Text = "";
            txt_idproduto.Text = "";
            txt_descricaoproduto.Text = "";
            txt_unidadevenda.Text = "";
            txt_quantidadeproduto.Text = "";
            txt_precounitproduto.Text = "";
            txt_descontoproduto.Text = "";
            txt_acrescimoproduto.Text = "";
            txt_vlrtotalproduto.Text = "";
            txt_listaprodutos.Text = "";
            txt_observacao.Text = "";
            txt_totalorcamento.Text = "";
            lv_listaprodutos.Text = "";
            lv_listaprodutos.Clear();
            #endregion

            #region "ADICIONA A LISTVIEW (NÃO USADO)"
            //Adicionar colunas
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[0].Text = "Cód.";
            this.lv_listaprodutos.Columns[0].Width = 50;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[1].Text = "Descrição";
            this.lv_listaprodutos.Columns[1].Width = 300;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[2].Text = "Un.";
            this.lv_listaprodutos.Columns[2].Width = 50;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[3].Text = "Preço";
            this.lv_listaprodutos.Columns[3].Width = 70;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[4].Text = "Qtd.";
            this.lv_listaprodutos.Columns[4].Width = 70;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[5].Text = "Desconto";
            this.lv_listaprodutos.Columns[5].Width = 70;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[6].Text = "Acréscimo";
            this.lv_listaprodutos.Columns[6].Width = 70;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[7].Text = "Valor Total";
            this.lv_listaprodutos.Columns[7].Width = 120;
            #endregion

            #region 'ATIVA/DESATIVA AS CAIXAS'
            txt_idorcamento.Enabled = false;
            txt_idempresa.Enabled = false;
            txt_empresa.Enabled = false;
            txtmsk_telefonefixoempresa.Enabled = false;
            txtmsk_telefonecelularempresa.Enabled = false;
            txt_emailempresa.Enabled = false;
            txt_idcliente.Enabled = false;
            txt_cliente.Enabled = false;
            txt_enderecocliente.Enabled = false;
            txt_numerocliente.Enabled = false;
            txt_bairrocliente.Enabled = false;
            txt_cidadecliente.Enabled = false;
            txtmsk_telefonefixocliente.Enabled = false;
            txtmsk_telefonecelularcliente.Enabled = false;
            txt_emailcliente.Enabled = false;
            txt_dataorcamento.Enabled = false;
            cbo_formapagamento.Enabled = false;
            cbo_prazopagamento.Enabled = false;
            cbo_prazoentrega.Enabled = false;
            txt_vendedor.Enabled = false;
            txt_idproduto.Enabled = false;
            txt_descricaoproduto.Enabled = false;
            txt_unidadevenda.Enabled = false;
            txt_quantidadeproduto.Enabled = false;
            txt_precounitproduto.Enabled = false;
            txt_descontoproduto.Enabled = false;
            txt_acrescimoproduto.Enabled = false;
            txt_vlrtotalproduto.Enabled = false;
            txt_listaprodutos.Enabled = false;
            txt_observacao.Enabled = false;
            txt_totalorcamento.Enabled = false;
            #endregion

            #region 'ATIVA/DESATIVA OS BOTÕES'
            btAddProduto.Enabled = false;
            btNovo.Enabled = true;
            btCancelar.Enabled = false;
            btImprimir.Enabled = false;
            btFechar.Enabled = true;
            btnCerrar.Enabled = true;
            #endregion

            #region 'VERIFICA E LIMPA O ARQUIVO DE TEXTO'
            if (new FileInfo(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt").Length == 0)
            {
                // empty
            }
            else
            {
                List<string> mensagemLinha = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt");
                System.IO.File.WriteAllLines(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt", lines.Take<string>(lines.Length - 1000));
            }
            #endregion

            #region 'COLOCA O FOCO'
            //Posiciona o foco
            btNovo.Focus();
            #endregion
        }

        private void add(string cod, string descricao, string unvenda, string preco, string qnt, string desconto, string acrescimo, string valortotal)
        {
            #region "ADICIONA A LISTVIEW (NÃO USADO)"
            //Adicionar Linha
            //Matriz para Representar uma Linha
            string[] row = { cod, descricao, unvenda, preco, qnt, desconto, acrescimo, valortotal };
            ListViewItem item = new ListViewItem(row);

            //Adicione ao lv
            lv_listaprodutos.Items.Add(item);
            #endregion
        }

        public string AbreArquivoTexto(string caminho)
        {
            #region 'VERIFICA SE O ARQUIVO EXISTE PARA ABRIR'
            // Cria StreamReader
            StreamReader sr;
            // Verifica se o Arquivo Existe
            if (!File.Exists(caminho))
            {
                throw (new FileNotFoundException("Não foi Possível Localizar o Arquivo Especificado"));
            }

            // Inicializa o StreamReader e retorna o conteudo
            using (sr = new StreamReader(caminho))
            {
                return sr.ReadToEnd();
            }
            #endregion
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            #region 'VERIFICA E LIMPA O ARQUIVO DE TEXTO'
            if (new FileInfo(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt").Length == 0)
            {
                // empty
            }
            else
            {
                List<string> mensagemLinha = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt");
                System.IO.File.WriteAllLines(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt", lines.Take<string>(lines.Length - 1000));
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_idorcamento.Text = "";
            txt_idempresa.Text = "";
            txt_empresa.Text = "";
            txtmsk_telefonefixoempresa.Text = "";
            txtmsk_telefonecelularempresa.Text = "";
            txt_emailempresa.Text = "";
            txt_idcliente.Text = "";
            txt_cliente.Text = "";
            txt_enderecocliente.Text = "";
            txt_numerocliente.Text = "";
            txt_bairrocliente.Text = "";
            txt_cidadecliente.Text = "";
            txtmsk_telefonefixocliente.Text = "";
            txtmsk_telefonecelularcliente.Text = "";
            txt_emailcliente.Text = "";
            txt_dataorcamento.Text = "";
            cbo_formapagamento.Text = "";
            cbo_prazopagamento.Text = "";
            cbo_prazoentrega.Text = "";
            txt_vendedor.Text = "";
            txt_idproduto.Text = "";
            txt_descricaoproduto.Text = "";
            txt_unidadevenda.Text = "";
            txt_quantidadeproduto.Text = "";
            txt_quantidadeproduto.Text = "0,000";
            txt_precounitproduto.Text = "";
            txt_precounitproduto.Text = "0,00";
            txt_descontoproduto.Text = "";
            txt_descontoproduto.Text = "0,00";
            txt_acrescimoproduto.Text = "";
            txt_acrescimoproduto.Text = "0,00";
            txt_vlrtotalproduto.Text = "";
            txt_vlrtotalproduto.Text = "0,00";
            txt_listaprodutos.Text = "";
            txt_totalorcamento.Text = "";
            txt_totalorcamento.Text = "0,00";
            lv_listaprodutos.Text = "";
            lv_listaprodutos.Clear();
            #endregion

            #region "ADICIONA A LISTVIEW (NÃO USADO)"
            //Adicionar colunas
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[0].Text = "Cód.";
            this.lv_listaprodutos.Columns[0].Width = 50;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[1].Text = "Descrição";
            this.lv_listaprodutos.Columns[1].Width = 300;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[2].Text = "Un.";
            this.lv_listaprodutos.Columns[2].Width = 50;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[3].Text = "Preço";
            this.lv_listaprodutos.Columns[3].Width = 70;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[4].Text = "Qtd.";
            this.lv_listaprodutos.Columns[4].Width = 70;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[5].Text = "Desconto";
            this.lv_listaprodutos.Columns[5].Width = 70;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[6].Text = "Acréscimo";
            this.lv_listaprodutos.Columns[6].Width = 70;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[7].Text = "Valor Total";
            this.lv_listaprodutos.Columns[7].Width = 120;
            #endregion

            #region "PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO"   
            //PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO - EXEMPLO 1
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd0 = new MySqlCommand();
            cmd0.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd0.CommandText = "SELECT max(IdOrcamento) from tb_orcamentos";

            try
            {
                if (cmd0.ExecuteScalar() == DBNull.Value)
                {
                    txt_idorcamento.Text = "1";
                }
                else
                {
                    Int32 ra = Convert.ToInt32(cmd0.ExecuteScalar()) + 1;
                    txt_idorcamento.Text = ra.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd0.Connection.Close(); //Fecha a conexão
            }
            cmd0.Connection.Close(); //Fecha a conexão
            #endregion

            #region 'PREENCHE OS DADOS DA EMPRESA'
            //Declarando a variavel e deixando limpa
            string codigo = string.Empty;
            string empresa = string.Empty;
            string email = string.Empty;
            string telfixo = string.Empty;
            string telcelular = string.Empty;

            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão 
            cmd.CommandText = "SELECT * FROM tb05empresaestabelecimento where ID = " + 1 + ""; //Seleciona a tabela e procura os dados            
            MySqlDataReader reader = cmd.ExecuteReader(); //Executa o comando selecionar

            //Faz a leitura e repassa os dados para variavel
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    codigo = reader.GetString("ID");
                    empresa = reader.GetString("Empresa");
                    email = reader.GetString("Email");
                    telfixo = reader.GetString("TelFixo");
                    telcelular = reader.GetString("TelCelular");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }

            //Repassando os dados da variável para as caixas
            txt_idempresa.Text = codigo;
            txt_empresa.Text = empresa;
            txt_emailempresa.Text = email;
            txtmsk_telefonefixoempresa.Text = telfixo;
            txtmsk_telefonecelularempresa.Text = telcelular;

            if (txt_idempresa.Text != "")
            {
                //NÃO FAZ NADA
            }
            else
            {
                //MENSAGEM DE EXECUÇÃO
                MessageBox.Show("Cadastre sua empresa no menu, \n para fazer um orçamento!");

                //Fecha a aplicação
                this.Close();
            }
            #endregion

            #region 'PREENCHENDO A CAIXA DATA COM DADOS ATUAIS'
            //CAPTURAR DATA
            string DateTime = System.DateTime.Now.ToShortDateString();
            //PREENCHENDO AS CAIXAS
            txt_dataorcamento.Text = (DateTime);
            #endregion

            #region 'ATIVAR/DESATIVAR AS CAIXAS'
            txt_idorcamento.Enabled = false;
            txt_idempresa.Enabled = false;
            txt_empresa.Enabled = false;
            txtmsk_telefonefixoempresa.Enabled = false;
            txtmsk_telefonecelularempresa.Enabled = false;
            txt_emailempresa.Enabled = false;
            txt_idcliente.Enabled = true;
            txt_cliente.Enabled = true;
            txt_enderecocliente.Enabled = false;
            txt_numerocliente.Enabled = false;
            txt_bairrocliente.Enabled = false;
            txt_cidadecliente.Enabled = false;
            txtmsk_telefonefixocliente.Enabled = false;
            txtmsk_telefonecelularcliente.Enabled = false;
            txt_emailcliente.Enabled = false;
            txt_dataorcamento.Enabled = false;
            cbo_formapagamento.Enabled = true;
            cbo_prazopagamento.Enabled = true;
            cbo_prazoentrega.Enabled = true;
            txt_vendedor.Enabled = true;
            txt_idproduto.Enabled = true;
            txt_descricaoproduto.Enabled = true;
            txt_unidadevenda.Enabled = false;
            txt_quantidadeproduto.Enabled = true;
            txt_precounitproduto.Enabled = false;
            txt_descontoproduto.Enabled = true;
            txt_acrescimoproduto.Enabled = true;
            txt_vlrtotalproduto.Enabled = false;
            txt_listaprodutos.Text = "";
            txt_listaprodutos.Enabled = false;
            txt_observacao.Enabled = true;
            txt_totalorcamento.Enabled = false;
            lv_listaprodutos.Enabled = false;
            #endregion

            #region 'ATIVAR/DESATIVAR OS BOTÕES'
            btAddProduto.Enabled = true;
            btNovo.Enabled = false;
            btCancelar.Enabled = true;
            btImprimir.Enabled = false;
            btFechar.Enabled = false;
            btnCerrar.Enabled = false;
            #endregion

            #region "CÓDIGO DE ORÇAMENTO"
            GerarCodigoOrcamento();
            #endregion

            #region 'COLOCA O FOCO'
            //Posiciona o foco
            txt_idcliente.Focus();
            #endregion
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            #region 'VERIFICA E LIMPA O ARQUIVO DE TEXTO'
            if (new FileInfo(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt").Length == 0)
            {
                // empty
            }
            else
            {
                List<string> mensagemLinha = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt");
                System.IO.File.WriteAllLines(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt", lines.Take<string>(lines.Length - 1000));
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_idorcamento.Text = "";
            txt_idempresa.Text = "";
            txt_empresa.Text = "";
            txtmsk_telefonefixoempresa.Text = "";
            txtmsk_telefonecelularempresa.Text = "";
            txt_emailempresa.Text = "";
            txt_idcliente.Text = "";
            txt_cliente.Text = "";
            txt_enderecocliente.Text = "";
            txt_numerocliente.Text = "";
            txt_bairrocliente.Text = "";
            txt_cidadecliente.Text = "";
            txtmsk_telefonefixocliente.Text = "";
            txtmsk_telefonecelularcliente.Text = "";
            txt_emailcliente.Text = "";
            txt_dataorcamento.Text = "";
            cbo_formapagamento.Text = "";
            cbo_prazopagamento.Text = "";
            cbo_prazoentrega.Text = "";
            txt_vendedor.Text = "";
            txt_idproduto.Text = "";
            txt_descricaoproduto.Text = "";
            txt_unidadevenda.Text = "";
            txt_quantidadeproduto.Text = "";
            txt_quantidadeproduto.Text = "0,000";
            txt_precounitproduto.Text = "";
            txt_precounitproduto.Text = "0,00";
            txt_descontoproduto.Text = "";
            txt_descontoproduto.Text = "0,00";
            txt_acrescimoproduto.Text = "";
            txt_acrescimoproduto.Text = "0,00";
            txt_vlrtotalproduto.Text = "";
            txt_vlrtotalproduto.Text = "0,00";
            txt_listaprodutos.Text = "";
            txt_observacao.Text = "";
            txt_totalorcamento.Text = "";
            txt_totalorcamento.Text = "0,00";
            lv_listaprodutos.Text = "";
            lv_listaprodutos.Clear();
            #endregion

            #region "ADICIONA A LISTVIEW (NÃO USADO)"
            //Adicionar colunas
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[0].Text = "Cód.";
            this.lv_listaprodutos.Columns[0].Width = 50;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[1].Text = "Descrição";
            this.lv_listaprodutos.Columns[1].Width = 300;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[2].Text = "Un.";
            this.lv_listaprodutos.Columns[2].Width = 50;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[3].Text = "Preço";
            this.lv_listaprodutos.Columns[3].Width = 70;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[4].Text = "Qtd.";
            this.lv_listaprodutos.Columns[4].Width = 70;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[5].Text = "Desconto";
            this.lv_listaprodutos.Columns[5].Width = 70;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[6].Text = "Acréscimo";
            this.lv_listaprodutos.Columns[6].Width = 70;
            this.lv_listaprodutos.Columns.Add(new ColumnHeader());
            this.lv_listaprodutos.Columns[7].Text = "Valor Total";
            this.lv_listaprodutos.Columns[7].Width = 120;
            #endregion

            #region 'ATIVA/DESATIVA AS CAIXAS'
            txt_idorcamento.Enabled = false;
            txt_idempresa.Enabled = false;
            txt_empresa.Enabled = false;
            txtmsk_telefonefixoempresa.Enabled = false;
            txtmsk_telefonecelularempresa.Enabled = false;
            txt_emailempresa.Enabled = false;
            txt_idcliente.Enabled = false;
            txt_cliente.Enabled = false;
            txt_enderecocliente.Enabled = false;
            txt_numerocliente.Enabled = false;
            txt_bairrocliente.Enabled = false;
            txt_cidadecliente.Enabled = false;
            txtmsk_telefonefixocliente.Enabled = false;
            txtmsk_telefonecelularcliente.Enabled = false;
            txt_emailcliente.Enabled = false;
            txt_dataorcamento.Enabled = false;
            cbo_formapagamento.Enabled = false;
            cbo_prazopagamento.Enabled = false;
            cbo_prazoentrega.Enabled = false;
            txt_vendedor.Enabled = false;
            txt_idproduto.Enabled = false;
            txt_descricaoproduto.Enabled = false;
            txt_unidadevenda.Enabled = false;
            txt_quantidadeproduto.Enabled = false;
            txt_precounitproduto.Enabled = false;
            txt_descontoproduto.Enabled = false;
            txt_acrescimoproduto.Enabled = false;
            txt_vlrtotalproduto.Enabled = false;
            txt_listaprodutos.Enabled = false;
            txt_observacao.Enabled = false;
            txt_totalorcamento.Enabled = false;
            #endregion

            #region 'ATIVA/DESATIVA OS BOTÕES'
            btAddProduto.Enabled = false;
            btNovo.Enabled = true;
            btCancelar.Enabled = false;
            btImprimir.Enabled = false;
            btFechar.Enabled = true;
            btnCerrar.Enabled = true;
            #endregion

            #region 'COLOCA O FOCO'
            //Posiciona o foco
            btNovo.Focus();
            #endregion
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            #region 'VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR'
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_idorcamento.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_idempresa.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_empresa.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txtmsk_telefonefixoempresa.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txtmsk_telefonecelularempresa.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_emailempresa.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_idcliente.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_cliente.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_cliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_enderecocliente.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_numerocliente.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_bairrocliente.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_cidadecliente.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txtmsk_telefonefixocliente.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txtmsk_telefonecelularcliente.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_emailcliente.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_dataorcamento.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbo_prazopagamento.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (cbo_prazopagamento.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbo_prazopagamento.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (cbo_formapagamento.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbo_formapagamento.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (cbo_prazoentrega.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbo_prazoentrega.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_vendedor.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_vendedor.Focus();
                return;
            }              
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_totalorcamento.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idcliente.Focus();
                return;
            }
            #endregion

            #region 'DECLARAÇÃO PARA DESENHAR O QUE SERÁ IMPRESSO NO PDF'

            #region 'DECLARAÇÃO'
            //Começa a declaração para desenhar no PDF o que será impresso
            var document = new PdfSharp.Pdf.PdfDocument();
            var page = document.AddPage();
            var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
            var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);
            var font = new PdfSharp.Drawing.XFont("Calibri", 10);
            #endregion

            #region 'FIGURA GEOMÉTRICA'
            // Figuras geométricas. Empresa---------------------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
            graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(25, 15, 450, 60));
            //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));       
            #endregion

            #region 'TEXTOS EMPRESA'
            // Textos. Empresa----------------------------------------------------------------------------------------------------------------------------------------------
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_idempresa.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 18, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_idempresa.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 30, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_empresa.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(70, 18, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_empresa.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(70, 30, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_telefonefixoempresa.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(320, 18, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txtmsk_telefonefixoempresa.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(320, 30, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_telefonecelularempresa.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(390, 18, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txtmsk_telefonecelularempresa.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(390, 30, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_emailempresa.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 45, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_emailempresa.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 57, page.Width - 60, page.Height - 60));
            #endregion

            #region 'FIGURA GEOMÉTRICA'
            // Figuras geométricas. ID Orçamento----------------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
            graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(480, 15, 95, 60));
            //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));
            #endregion

            #region 'TEXTOS ID ORÇAMENTO'
            // Textos. ID Orçamento-----------------------------------------------------------------------------------------------------------------------------------------
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_orcamento.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(500, 18, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_numerocliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(510, 35, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_idorcamento.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(510, 50, page.Width - 60, page.Height - 60));
            #endregion

            #region 'FIGURA GEOMÉTRICA'
            // Figuras geométricas. Cliente---------------------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
            graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(25, 80, 550, 60));
            //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));
            #endregion

            #region 'TEXTO CLIENTE'
            // Textos. Cliente-----------------------------------------------------------------------------------------------------------------------------------------------
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_idcliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 83, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_idcliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 95, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_cliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(70, 83, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_cliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(70, 95, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_enderecocliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(250, 83, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_enderecocliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(250, 95, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_numerocliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(430, 83, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_numerocliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(430, 95, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_bairrocliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(470, 83, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_bairrocliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(470, 95, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_cidadecliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 110, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_cidadecliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 122, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_telefonefixocliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(200, 110, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txtmsk_telefonefixocliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(200, 122, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_telefonecelularcliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(270, 110, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txtmsk_telefonecelularcliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(270, 122, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_emailcliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(380, 110, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_emailcliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(380, 122, page.Width - 60, page.Height - 60));
            #endregion

            #region 'FIGURA GEOMÉTRICA'
            // Figuras geométricas. Forma Pagamento-------------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
            graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(25, 145, 550, 30));
            //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));
            #endregion

            #region 'TEXTO FORMA DE PAGAMENTO'
            // Textos. Forma Pagamento---------------------------------------------------------------------------------------------------------------------------------------
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_dataorcamento.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 148, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_dataorcamento.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 160, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_formapagamento.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(90, 148, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(cbo_formapagamento.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(90, 160, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_prazopagamento.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(180, 148, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(cbo_prazopagamento.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(180, 160, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_prazoentrega.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(290, 148, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(cbo_prazoentrega.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(290, 160, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_vendedor.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(430, 148, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_vendedor.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(430, 160, page.Width - 60, page.Height - 60));
            #endregion

            #region 'FIGURA GEOMÉTRICA'
            // Figuras geométricas. Cabeçalho Produtos----------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
            graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(25, 180, 550, 18));
            //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));
            #endregion

            #region 'TEXTO LISTA DE CABEÇALHO'
            //----------------------------------------Lista de Produtos Cabeçalho-------------------------------------------------------------------------------------------
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_idproduto.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 183, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_descricaoproduto.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(60, 183, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_unidadevenda.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(280, 183, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_precounitproduto.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(320, 183, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_quantidadeproduto.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(370, 183, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_descontoproduto.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(420, 183, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_acrescimoproduto.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(470, 183, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_vlrtotalproduto.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(520, 183, page.Width - 60, page.Height - 60));
            #endregion

            #region 'TEXTO LISTA DE PRODUTOS'
            //----------------------------------------Lista de Produtos-----------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_listaprodutos.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 200, page.Width - 60, page.Height - 60));


            //foreach (ListViewItem item in lv_listaprodutos.Items)
            //{
            //    textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            //    textFormatter.DrawString(item.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 200, page.Width - 60, page.Height - 60));
            //    textFormatter.DrawString(item.SubItems[0].Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 200, page.Width - 60, page.Height - 60));
            //    textFormatter.DrawString(item.SubItems[1].Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(60, 200, page.Width - 60, page.Height - 60));
            //    textFormatter.DrawString(item.SubItems[2].Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(280, 200, page.Width - 60, page.Height - 60));
            //    textFormatter.DrawString(item.SubItems[3].Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(320, 200, page.Width - 60, page.Height - 60));
            //    textFormatter.DrawString(item.SubItems[4].Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(370, 200, page.Width - 60, page.Height - 60));
            //    textFormatter.DrawString(item.SubItems[5].Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(420, 200, page.Width - 60, page.Height - 60));
            //    textFormatter.DrawString(item.SubItems[6].Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(470, 200, page.Width - 60, page.Height - 60));
            //    textFormatter.DrawString(item.SubItems[7].Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(520, 200, page.Width - 60, page.Height - 60));
            //}
            #endregion

            #region 'FIGURA GEOMÉTRICA'
            // Figuras geométricas. Observação------------------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
            graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(25, 800, 450, 30));
            //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));                    
            #endregion

            #region 'TEXTO OBSERVAÇÃO'
            // Textos. Observação-------------------------------------------------------------------------------------------------------------------------------------------
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(gb_observacao.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 803, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_observacao.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 815, page.Width - 60, page.Height - 60));
            #endregion

            #region 'FIGURA GEOMÉTRICA'
            // Figuras geométricas. Valor Total------------------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
            graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(480, 800, 95, 30));
            //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));
            #endregion

            #region 'TEXTO VALOR TOTAL'
            // Textos. Valor Total-------------------------------------------------------------------------------------------------------------------------------------------
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(lbl_totalorcamento.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(485, 803, page.Width - 60, page.Height - 60));

            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString(txt_totalorcamento.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(510, 815, page.Width - 60, page.Height - 60));
            #endregion

            #region 'INICIA O PDF'
            // Inicia o PDF--------------------------------------------------------------------------------------------------------------------------------------------------                                     
            document.Save("Orcamento.pdf");
            System.Diagnostics.Process.Start("Orcamento.pdf");
            #endregion

            // Exemplo:-----------------------------------------------------------------------------------------------------------------------------------------------------
            // Imagem.
            //graphics.DrawImage(PdfSharp.Drawing.XImage.FromFile("penguins.jpg"), 80, 350, 400, 300);

            //textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Justify;
            //textFormatter.DrawString("E, finalmente, aqui temos um parágrafo justificado. Aqui precisamos de mais texto para ver se o texto está realmente sendo justificado! Confira as outras categorias do meu site para artigos relacionados a outras tecnologias de desenvolvimento de software!",
            //font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 120, page.Width - 60, page.Height - 60));
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------
            #endregion

            #region 'NÃO USADO'
            ////usado foxlean
            //if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            //    printDocument1.Print();

            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();

            //printDialog1.Document = printDocument1;
            //printDocument1.PrinterSettings = printDialog1.PrinterSettings;
            //printDocument1.PrinterSettings.DefaultPageSettings.Landscape = false;
            #endregion
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            #region 'VERIFICA E LIMPA O ARQUIVO DE TEXTO'
            if (new FileInfo(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt").Length == 0)
            {
                // empty
            }
            else
            {
                List<string> mensagemLinha = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt");
                System.IO.File.WriteAllLines(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt", lines.Take<string>(lines.Length - 1000));
            }
            #endregion

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
            #region 'CONDIÇÃO'
            //FECHA O FORMULÁRIO COM MENSAGEM
            DialogResult dlgResult = MessageBox.Show("Deseja adicionar mais ítens ?", "Adicionar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                #region 'CRIANDO PASTA E ARQUIVO DE TEXTO SE NÃO EXISTIREM'
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
                #endregion

                #region 'VERIFICA SE TEM DADOS PARA LANÇAR, LISTVIEW (NÃO USADO)'
                /*
                if (txt_idproduto.Text != "" && txt_descricaoproduto.Text != "" && txt_unidadevenda.Text != "" && txt_precounitproduto.Text != "" && txt_quantidadeproduto.Text != "" && txt_descontoproduto.Text != "" && txt_acrescimoproduto.Text != "" && txt_vlrtotalproduto.Text != "")
                {
                    #region 'CONDIÇÃO PARA FORMATAR'
                    if (txt_unidadevenda.Text == "UN")
                    {
                        #region "ADICIONAR PRODUTO E FAZ A SOMA DENTRO DA LISTA"

                        //ADICIONA NA LISTA
                        add(txt_idproduto.Text, txt_descricaoproduto.Text, txt_unidadevenda.Text, txt_precounitproduto.Text, txt_quantidadeproduto.Text, txt_descontoproduto.Text, txt_acrescimoproduto.Text, txt_vlrtotalproduto.Text);

                        //REALIZA A SOMA TOTAL DENTRO DA LISTVIEW
                        var vlrtotal = 0m;
                        for (int i = 0; i < lv_listaprodutos.Items.Count; i++)
                        {
                            vlrtotal += decimal.Parse(lv_listaprodutos.Items[i].SubItems[7].Text); ;
                        }
                        txt_totalorcamento.Text = vlrtotal.ToString("N");
                        #endregion

                        #region "LIMPAS AS CAIXAS"            
                        //ITENS
                        //lbIdProduto.Text = "";
                        //lbIdProduto.Text = txt_idproduto.Text;
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
                        btCancelar.Enabled = true;
                        btImprimir.Enabled = true;
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
                        #region "ADICIONAR PRODUTO E FAZ A SOMA DENTRO DA LISTA"

                        //ADICIONA NA LISTA
                        add(txt_idproduto.Text, txt_descricaoproduto.Text, txt_unidadevenda.Text, txt_precounitproduto.Text, txt_quantidadeproduto.Text, txt_descontoproduto.Text, txt_acrescimoproduto.Text, txt_vlrtotalproduto.Text);

                        //REALIZA A SOMA TOTAL DENTRO DA LISTVIEW
                        var vlrtotal = 0m;
                        for (int i = 0; i < lv_listaprodutos.Items.Count; i++)
                        {
                            vlrtotal += decimal.Parse(lv_listaprodutos.Items[i].SubItems[7].Text); ;
                        }
                        txt_totalorcamento.Text = vlrtotal.ToString("N"); 

                        #endregion

                        #region "LIMPAS AS CAIXAS"            
                        //ITENS
                        //lbIdProduto.Text = "";
                        //lbIdProduto.Text = txt_idproduto.Text;
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
                        btCancelar.Enabled = true;
                        btImprimir.Enabled = true;
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
                */
                //copia dados do listview para textbox
                //textBox1.Text = string.Join(", ", listView1.Items.Cast<ListViewItem>().Select(i => i.Text));
                #endregion

                #region 'VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR'
                if (txt_idproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_idproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_descricaoproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_idproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_unidadevenda.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_idproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_precounitproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_idproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_quantidadeproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_quantidadeproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_descontoproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_descontoproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_acrescimoproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_acrescimoproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_vlrtotalproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_descricaoproduto.Focus();
                    return;
                }
                #endregion

                #region 'REALIZA A SOMA NAS CAIXAS'
                //--------------------------------------------------------------------------------------------------------------------                    
                //REALIZA A SOMA DAS CAIXAS  
                Decimal valor1 = Convert.ToDecimal(txt_vlrtotalproduto.Text);
                Decimal valor2 = Convert.ToDecimal(txt_totalorcamento.Text);
                Decimal saldo = valor1 + valor2;

                //MOSTRA O RESULTADO DA SOMA
                txt_totalorcamento.Text = saldo.ToString();

                //COLOCA A FORMATAÇÃO DE MOEDA NAS CAIXAS E MOSTRA O RESULTADO DA SOMA
                //txt_totalorcamento.Text = saldo.ToString("C");
                #endregion

                #region 'CRIANDO O ARQUIVO DE TEXTO, ESCREVENDO E LENDO, (NÃO USADO)'
                /*
                //ATIVA/DESATIVA AS CAIXAS
                txt_listaprodutos.Enabled = true;

                //DECLARA VARIÁVEIS
                string codigo = txt_idproduto.Text;
                string descricao = txt_descricaoproduto.Text;
                string unvenda = txt_unidadevenda.Text;
                string precounit = txt_precounitproduto.Text;
                string quantidade = txt_quantidadeproduto.Text;
                string desconto = txt_descontoproduto.Text;
                string acrescimo = txt_acrescimoproduto.Text;
                string total = txt_vlrtotalproduto.Text;

                string nomeArquivo = @"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt";
                string textoInserir = codigo + " | " + descricao + " | " + unvenda + " | " + precounit + " | " + quantidade + " | " + desconto + " | " + acrescimo + " | " + total;

                int numeroLinha = 0;
                ArrayList linhas = new ArrayList();
                string linha;

                /////////////////////////////////////////////////////////////////////////////
                if (File.Exists(nomeArquivo))
                {
                    try
                    {
                        rdr = new StreamReader(nomeArquivo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao acessar o arquivo : " + ex.Message);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo : " + nomeArquivo + " não existe...");
                    return;
                }

                /////////////////////////////////////////////////////////////////////////////
                while ((linha = rdr.ReadLine()) != null)
                {
                    try
                    {
                        linhas.Add(linha);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao acessar o arquivo : " + ex.Message);
                        return;
                    }
                }
                rdr.Close();

                /////////////////////////////////////////////////////////////////////////////
                if (linhas.Count > numeroLinha)
                    linhas.Insert(numeroLinha, textoInserir);
                else
                    linhas.Add(textoInserir);

                /////////////////////////////////////////////////////////////////////////////
                StreamWriter wrtr = new StreamWriter(nomeArquivo);

                foreach (string strNewLine in linhas)
                {
                    wrtr.WriteLine(strNewLine);
                }
                wrtr.Close();
                */

                #region 'FAZ A LEITURA DO ARQUIVO DE TEXTO'
                /*
                StringBuilder sb = new StringBuilder();
                //string caminhoArquivo = @"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt";
                var consulta = from linha1 in File.ReadAllLines(nomeArquivo)
                               let OrcamentoDados = linha1.Split('|')
                               select new Orcamentos()
                               {
                                   Codigo = Convert.ToInt32(OrcamentoDados[0]),
                                   Descricao = OrcamentoDados[1],
                                   Unvenda = OrcamentoDados[2],
                                   Precounit = OrcamentoDados[3],
                                   Quantidade = OrcamentoDados[4],
                                   Desconto = OrcamentoDados[5],
                                   Acrescimo = OrcamentoDados[6],
                                   Total = OrcamentoDados[7],
                               };

                foreach (var item in consulta)
                {
                    //lstTexto.Items.Add(item.Codigo + "|" + item.Descricao + "|" + item.Unvenda + "|" + item.Precounit + "|" + item.Quantidade + "|" + item.Desconto + "|" + item.Acrescimo + "|" + item.Total);

                    //sb.AppendFormat("{0,-8}{1,-20}{2,-15}{3,-10:yyyyMMdd}{4}",
                    sb.AppendFormat("{0,-10}{1,-100}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}{7,-15}{2}",
                        item.Codigo.ToString().PadLeft(5, '0'),
                        item.Descricao,
                        item.Unvenda,
                        item.Precounit,
                        item.Quantidade,
                        item.Desconto,
                        item.Acrescimo,
                        item.Total,
                        Environment.NewLine);
                }
                File.WriteAllText(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento_Formatado.txt", sb.ToString());
                */
                #endregion

                //lstTexto.Text = AbreArquivoTexto(nomeArquivo);
                //txt_listaprodutos.Text = AbreArquivoTexto(nomeArquivo);

                #region 'FORMATA O ARQUIVO DE TEXTO 
                /*
                using (StreamReader reader = new StreamReader(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento_Formatado.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lstTexto.Items.Add(line); // Write to console.
                    }
                }
                */
                #endregion

                #endregion

                #region 'ADICIONA OS DADOS NA CAIXA E ESCREVE NO ARQUIVO DE TEXTO'
                //ATIVA/DESATIVA AS CAIXAS
                txt_listaprodutos.Enabled = true;

                //DECLARA VARIÁVEIS
                string codigo = txt_idproduto.Text;
                string descricao = txt_descricaoproduto.Text;
                string unvenda = txt_unidadevenda.Text;
                string precounit = txt_precounitproduto.Text;
                string quantidade = txt_quantidadeproduto.Text;
                string desconto = txt_descontoproduto.Text;
                string acrescimo = txt_acrescimoproduto.Text;
                string total = txt_vlrtotalproduto.Text;

                string nomeArquivo = @"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt";
                string textoInserir = codigo + "       |   " + descricao + "                                                   |   " + unvenda + "   |   " + precounit + "   |   " + quantidade + "   |   " + desconto + "   |   " + acrescimo + "   |   " + total;
                //string textoInserir ="Cod:" + codigo + " | " + "Descr: " + descricao + " | " + "Un: " + unvenda + " | " + "Custo: " + precounit + " | " + "Qtde: " + quantidade + " | " + "Desc: " + desconto + " | " + "Acr: " + acrescimo + " | " + "Vlr.Total: " + total;

                int numeroLinha = 0;
                ArrayList linhas = new ArrayList();

                /////////////////////////////////////////////////////////////////////////////
                if (File.Exists(nomeArquivo))
                {
                    try
                    {
                        rdr = new StreamReader(nomeArquivo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao acessar o arquivo : " + ex.Message);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo : " + nomeArquivo + " não existe...");
                    return;
                }

                /////////////////////////////////////////////////////////////////////////////
                string linha;
                while ((linha = rdr.ReadLine()) != null)
                {
                    try
                    {
                        linhas.Add(linha);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao acessar o arquivo : " + ex.Message);
                        return;
                    }
                }
                rdr.Close();

                /////////////////////////////////////////////////////////////////////////////
                if (linhas.Count > numeroLinha)
                    linhas.Insert(numeroLinha, textoInserir);
                else
                    linhas.Add(textoInserir);

                /////////////////////////////////////////////////////////////////////////////
                StreamWriter wrtr = new StreamWriter(nomeArquivo);
                foreach (string strNewLine in linhas)
                {
                    wrtr.WriteLine(strNewLine);
                }
                wrtr.Close();

                /////////////////////////////////////////////////////////////////////////////
                //Abre o arquivo TXT e repassa os dados
                txt_listaprodutos.Text = AbreArquivoTexto(nomeArquivo);

                #endregion

                #region 'FAZ A CONTAGEM DE LINHAS E LIMITA O LANÇAMENTO'
                ///////////////////////////////////////////////////////////////////////////////////
                //Faz a contagem de linhas do arquivo e limita a 45 lançamentos
                if (linhas.Count >= 45)
                {
                    MessageBox.Show("Limite máximo de ítens");
                    btAddProduto.Enabled = false;
                }
                else
                {

                }
                #endregion

                #region 'ATIVA/DESATIVA AS CAIXAS'
                //ATIVA/DESATIVA AS CAIXAS
                txt_listaprodutos.Enabled = false;
                #endregion

                #region 'LIMPA AS CAIXAS'
                //Limpa as caixas
                txt_idproduto.Text = "";
                txt_descricaoproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
                txt_quantidadeproduto.Text = "";
                txt_descontoproduto.Text = "";
                txt_acrescimoproduto.Text = "";
                txt_vlrtotalproduto.Text = "";
                #endregion

                #region 'ATIVA/DESATIVA OS BOTÕES'
                btAddProduto.Enabled = true;
                btNovo.Enabled = false;
                btCancelar.Enabled = true;
                btImprimir.Enabled = false;
                btFechar.Enabled = false;
                btnCerrar.Enabled = false;
                #endregion

                #region 'COLOCA O FOCO'
                //Coloca o foco na caixa
                txt_idproduto.Focus();
                #endregion
            }
            else
            {
                #region 'CRIANDO PASTA E ARQUIVO DE TEXTO SE NÃO EXISTIREM'
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
                #endregion

                #region 'VERIFICA SE TEM DADOS PARA LANÇAR, LISTVIEW (NÃO USADO)'
                /*
                if (txt_idproduto.Text != "" && txt_descricaoproduto.Text != "" && txt_unidadevenda.Text != "" && txt_precounitproduto.Text != "" && txt_quantidadeproduto.Text != "" && txt_descontoproduto.Text != "" && txt_acrescimoproduto.Text != "" && txt_vlrtotalproduto.Text != "")
                {
                    #region 'CONDIÇÃO PARA FORMATAR'
                    if (txt_unidadevenda.Text == "UN")
                    {
                        #region "ADICIONAR PRODUTO E FAZ A SOMA DENTRO DA LISTA"

                        //ADICIONA NA LISTA
                        add(txt_idproduto.Text, txt_descricaoproduto.Text, txt_unidadevenda.Text, txt_precounitproduto.Text, txt_quantidadeproduto.Text, txt_descontoproduto.Text, txt_acrescimoproduto.Text, txt_vlrtotalproduto.Text);

                        //REALIZA A SOMA TOTAL DENTRO DA LISTVIEW
                        var vlrtotal = 0m;
                        for (int i = 0; i < lv_listaprodutos.Items.Count; i++)
                        {
                            vlrtotal += decimal.Parse(lv_listaprodutos.Items[i].SubItems[7].Text); ;
                        }
                        txt_totalorcamento.Text = vlrtotal.ToString("N");
                        #endregion

                        #region "LIMPAS AS CAIXAS"            
                        //ITENS
                        //lbIdProduto.Text = "";
                        //lbIdProduto.Text = txt_idproduto.Text;
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
                        btCancelar.Enabled = true;
                        btImprimir.Enabled = true;
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
                        #region "ADICIONAR PRODUTO E FAZ A SOMA DENTRO DA LISTA"

                        //ADICIONA NA LISTA
                        add(txt_idproduto.Text, txt_descricaoproduto.Text, txt_unidadevenda.Text, txt_precounitproduto.Text, txt_quantidadeproduto.Text, txt_descontoproduto.Text, txt_acrescimoproduto.Text, txt_vlrtotalproduto.Text);

                        //REALIZA A SOMA TOTAL DENTRO DA LISTVIEW
                        var vlrtotal = 0m;
                        for (int i = 0; i < lv_listaprodutos.Items.Count; i++)
                        {
                            vlrtotal += decimal.Parse(lv_listaprodutos.Items[i].SubItems[7].Text); ;
                        }
                        txt_totalorcamento.Text = vlrtotal.ToString("N"); 

                        #endregion

                        #region "LIMPAS AS CAIXAS"            
                        //ITENS
                        //lbIdProduto.Text = "";
                        //lbIdProduto.Text = txt_idproduto.Text;
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
                        btCancelar.Enabled = true;
                        btImprimir.Enabled = true;
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
                */
                //copia dados do listview para textbox
                //textBox1.Text = string.Join(", ", listView1.Items.Cast<ListViewItem>().Select(i => i.Text));
                #endregion

                #region 'VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR'
                if (txt_idproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_idproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_descricaoproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_idproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_unidadevenda.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_idproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_precounitproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_idproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_quantidadeproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_quantidadeproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_descontoproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_descontoproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_acrescimoproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_acrescimoproduto.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_vlrtotalproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_descricaoproduto.Focus();
                    return;
                }
                #endregion

                #region 'REALIZA A SOMA NAS CAIXAS'
                //--------------------------------------------------------------------------------------------------------------------                    
                //REALIZA A SOMA DAS CAIXAS  
                Decimal valor1 = Convert.ToDecimal(txt_vlrtotalproduto.Text);
                Decimal valor2 = Convert.ToDecimal(txt_totalorcamento.Text);
                Decimal saldo = valor1 + valor2;

                //MOSTRA O RESULTADO DA SOMA
                txt_totalorcamento.Text = saldo.ToString();

                //COLOCA A FORMATAÇÃO DE MOEDA NAS CAIXAS E MOSTRA O RESULTADO DA SOMA
                //txt_totalorcamento.Text = saldo.ToString("C");
                #endregion

                #region 'CRIANDO O ARQUIVO DE TEXTO, ESCREVENDO E LENDO, (NÃO USADO)'
                /*
                //ATIVA/DESATIVA AS CAIXAS
                txt_listaprodutos.Enabled = true;

                //DECLARA VARIÁVEIS
                string codigo = txt_idproduto.Text;
                string descricao = txt_descricaoproduto.Text;
                string unvenda = txt_unidadevenda.Text;
                string precounit = txt_precounitproduto.Text;
                string quantidade = txt_quantidadeproduto.Text;
                string desconto = txt_descontoproduto.Text;
                string acrescimo = txt_acrescimoproduto.Text;
                string total = txt_vlrtotalproduto.Text;

                string nomeArquivo = @"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt";
                string textoInserir = codigo + " | " + descricao + " | " + unvenda + " | " + precounit + " | " + quantidade + " | " + desconto + " | " + acrescimo + " | " + total;

                int numeroLinha = 0;
                ArrayList linhas = new ArrayList();
                string linha;

                /////////////////////////////////////////////////////////////////////////////
                if (File.Exists(nomeArquivo))
                {
                    try
                    {
                        rdr = new StreamReader(nomeArquivo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao acessar o arquivo : " + ex.Message);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo : " + nomeArquivo + " não existe...");
                    return;
                }

                /////////////////////////////////////////////////////////////////////////////
                while ((linha = rdr.ReadLine()) != null)
                {
                    try
                    {
                        linhas.Add(linha);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao acessar o arquivo : " + ex.Message);
                        return;
                    }
                }
                rdr.Close();

                /////////////////////////////////////////////////////////////////////////////
                if (linhas.Count > numeroLinha)
                    linhas.Insert(numeroLinha, textoInserir);
                else
                    linhas.Add(textoInserir);

                /////////////////////////////////////////////////////////////////////////////
                StreamWriter wrtr = new StreamWriter(nomeArquivo);

                foreach (string strNewLine in linhas)
                {
                    wrtr.WriteLine(strNewLine);
                }
                wrtr.Close();
                */

                #region 'FAZ A LEITURA DO ARQUIVO DE TEXTO'
                /*
                StringBuilder sb = new StringBuilder();
                //string caminhoArquivo = @"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt";
                var consulta = from linha1 in File.ReadAllLines(nomeArquivo)
                               let OrcamentoDados = linha1.Split('|')
                               select new Orcamentos()
                               {
                                   Codigo = Convert.ToInt32(OrcamentoDados[0]),
                                   Descricao = OrcamentoDados[1],
                                   Unvenda = OrcamentoDados[2],
                                   Precounit = OrcamentoDados[3],
                                   Quantidade = OrcamentoDados[4],
                                   Desconto = OrcamentoDados[5],
                                   Acrescimo = OrcamentoDados[6],
                                   Total = OrcamentoDados[7],
                               };

                foreach (var item in consulta)
                {
                    //lstTexto.Items.Add(item.Codigo + "|" + item.Descricao + "|" + item.Unvenda + "|" + item.Precounit + "|" + item.Quantidade + "|" + item.Desconto + "|" + item.Acrescimo + "|" + item.Total);

                    //sb.AppendFormat("{0,-8}{1,-20}{2,-15}{3,-10:yyyyMMdd}{4}",
                    sb.AppendFormat("{0,-10}{1,-100}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}{7,-15}{2}",
                        item.Codigo.ToString().PadLeft(5, '0'),
                        item.Descricao,
                        item.Unvenda,
                        item.Precounit,
                        item.Quantidade,
                        item.Desconto,
                        item.Acrescimo,
                        item.Total,
                        Environment.NewLine);
                }
                File.WriteAllText(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento_Formatado.txt", sb.ToString());
                */
                #endregion

                //lstTexto.Text = AbreArquivoTexto(nomeArquivo);
                //txt_listaprodutos.Text = AbreArquivoTexto(nomeArquivo);

                #region 'FORMATA O ARQUIVO DE TEXTO 
                /*
                using (StreamReader reader = new StreamReader(@"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento_Formatado.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lstTexto.Items.Add(line); // Write to console.
                    }
                }
                */
                #endregion

                #endregion

                #region 'ADICIONA OS DADOS NA CAIXA E ESCREVE NO ARQUIVO DE TEXTO'
                //ATIVA/DESATIVA AS CAIXAS
                txt_listaprodutos.Enabled = true;

                //DECLARA VARIÁVEIS
                string codigo = txt_idproduto.Text;
                string descricao = txt_descricaoproduto.Text;
                string unvenda = txt_unidadevenda.Text;
                string precounit = txt_precounitproduto.Text;
                string quantidade = txt_quantidadeproduto.Text;
                string desconto = txt_descontoproduto.Text;
                string acrescimo = txt_acrescimoproduto.Text;
                string total = txt_vlrtotalproduto.Text;

                string nomeArquivo = @"C:\SIGRASSYSTEMBD\ORCAMENTOS\Orcamento.txt";
                string textoInserir = codigo + "       |   " + descricao + "                                                   |   " + unvenda + "   |   " + precounit + "   |   " + quantidade + "   |   " + desconto + "   |   " + acrescimo + "   |   " + total;
                //string textoInserir ="Cod:" + codigo + " | " + "Descr: " + descricao + " | " + "Un: " + unvenda + " | " + "Custo: " + precounit + " | " + "Qtde: " + quantidade + " | " + "Desc: " + desconto + " | " + "Acr: " + acrescimo + " | " + "Vlr.Total: " + total;

                int numeroLinha = 0;
                ArrayList linhas = new ArrayList();

                /////////////////////////////////////////////////////////////////////////////
                if (File.Exists(nomeArquivo))
                {
                    try
                    {
                        rdr = new StreamReader(nomeArquivo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao acessar o arquivo : " + ex.Message);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo : " + nomeArquivo + " não existe...");
                    return;
                }

                /////////////////////////////////////////////////////////////////////////////
                string linha;
                while ((linha = rdr.ReadLine()) != null)
                {
                    try
                    {
                        linhas.Add(linha);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao acessar o arquivo : " + ex.Message);
                        return;
                    }
                }
                rdr.Close();

                /////////////////////////////////////////////////////////////////////////////
                if (linhas.Count > numeroLinha)
                    linhas.Insert(numeroLinha, textoInserir);
                else
                    linhas.Add(textoInserir);

                /////////////////////////////////////////////////////////////////////////////
                StreamWriter wrtr = new StreamWriter(nomeArquivo);

                foreach (string strNewLine in linhas)
                {
                    wrtr.WriteLine(strNewLine);
                }
                wrtr.Close();

                //ABRE O ARQUIVO TXT
                txt_listaprodutos.Text = AbreArquivoTexto(nomeArquivo);

                #endregion

                #region 'FAZ A CONTAGEM DE LINHAS E LIMITA O LANÇAMENTO'
                ///////////////////////////////////////////////////////////////////////////////////
                //Faz a contagem de linhas do arquivo e limita a 45 lançamentos
                if (linhas.Count >= 45)
                {
                    MessageBox.Show("Limite máximo de ítens");
                    btAddProduto.Enabled = false;
                }
                else
                {

                }
                #endregion

                #region 'ATIVA/DESATIVA AS CAIXAS'
                //ATIVA/DESATIVA AS CAIXAS
                txt_idproduto.Enabled = false;
                txt_descricaoproduto.Enabled = false;
                txt_unidadevenda.Enabled = false;
                txt_precounitproduto.Enabled = false;
                txt_quantidadeproduto.Enabled = false;
                txt_descontoproduto.Enabled = false;
                txt_acrescimoproduto.Enabled = false;
                txt_vlrtotalproduto.Enabled = false;
                txt_listaprodutos.Enabled = false;
                #endregion

                #region 'LIMPA AS CAIXAS'
                //Limpa as caixas
                txt_idproduto.Text = "";
                txt_descricaoproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
                txt_quantidadeproduto.Text = "";
                txt_descontoproduto.Text = "";
                txt_acrescimoproduto.Text = "";
                txt_vlrtotalproduto.Text = "";
                #endregion

                #region 'ATIVA/DESATIVA OS BOTÕES'
                btAddProduto.Enabled = false;
                btNovo.Enabled = false;
                btCancelar.Enabled = true;
                btImprimir.Enabled = true;
                btFechar.Enabled = false;
                btnCerrar.Enabled = false;
                #endregion

                #region 'COLOCA O FOCO'
                //Coloca o foco na caixa
                btImprimir.Focus();
                #endregion
            }
            #endregion
        }

        private void imNovoCliente_Click(object sender, EventArgs e)
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

        private void imNovoEntregaPrazo_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btCancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmPagamentoPrazosEntrega frm = new FrmPagamentoPrazosEntrega();
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

        private void txt_idcliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbo_prazopagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_formapagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_prazoentrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void txt_idcliente_Leave(object sender, EventArgs e)
        {
            #region 'SELECIONA OS DADOS E PREENCHE AO SAIR DA CAIXA'
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_cadastromultiplo WHERE ID = '" + txt_idcliente.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                txt_idcliente.Text = dr["ID"].ToString();
                txt_cliente.Text = dr["NomeRazaoSocial"].ToString();
                txt_enderecocliente.Text = dr["Endereco"].ToString();
                txt_numerocliente.Text = dr["Numero"].ToString();
                txt_bairrocliente.Text = dr["Bairro"].ToString();
                txt_cidadecliente.Text = dr["Cidade"].ToString();
                txtmsk_telefonefixocliente.Text = dr["TelFixo"].ToString();
                txtmsk_telefonecelularcliente.Text = dr["TelCelular1"].ToString();
                txt_emailcliente.Text = dr["Email"].ToString();
            }
            cmd.Connection.Close(); //Fecha a conexão 
            #endregion

            #region 'COLOCA O FOCO'
            //Coloca o foco
            this.cbo_prazopagamento.Focus();
            #endregion
        }

        private void txt_cliente_Leave(object sender, EventArgs e)
        {
            #region 'SELECIONA OS DADOS E PREENCHE AO SAIR DA CAIXA'
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_cadastromultiplo WHERE NomeRazaoSocial = '" + txt_cliente.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                txt_idcliente.Text = dr["ID"].ToString();
                txt_cliente.Text = dr["NomeRazaoSocial"].ToString();
                txt_enderecocliente.Text = dr["Endereco"].ToString();
                txt_numerocliente.Text = dr["Numero"].ToString();
                txt_bairrocliente.Text = dr["Bairro"].ToString();
                txt_cidadecliente.Text = dr["Cidade"].ToString();
                txtmsk_telefonefixocliente.Text = dr["TelFixo"].ToString();
                txtmsk_telefonecelularcliente.Text = dr["TelCelular1"].ToString();
                txt_emailcliente.Text = dr["Email"].ToString();
            }
            cmd.Connection.Close(); //Fecha a conexão 
            #endregion

            #region 'COLOCA O FOCO'
            //Coloca o foco
            this.cbo_prazopagamento.Focus();
            #endregion
        }

        private void txt_idproduto_Leave(object sender, EventArgs e)
        {
            #region 'SELECIONA OS DADOS E PREENCHE AO SAIR DA CAIXA'
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_produtos WHERE ID = '" + txt_idproduto.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                txt_idproduto.Text = dr["ID"].ToString();
                txt_descricaoproduto.Text = dr["DescricaoProduto"].ToString();
                txt_unidadevenda.Text = dr["UnVenda"].ToString();
                txt_precounitproduto.Text = dr["VlrVenda"].ToString();
            }
            //Fecha a conexão
            cmd.Connection.Close();
            #endregion

            #region 'COLOCA O FOCO'
            //Coloca o foco
            this.txt_quantidadeproduto.Focus();
            #endregion
        }

        private void txt_descricaoproduto_Leave(object sender, EventArgs e)
        {
            #region 'SELECIONA OS DADOS E PREENCHE AO SAIR DA CAIXA'
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_produtos WHERE DescricaoProduto = '" + txt_descricaoproduto.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                txt_idproduto.Text = dr["ID"].ToString();
                txt_descricaoproduto.Text = dr["DescricaoProduto"].ToString();
                txt_unidadevenda.Text = dr["UnVenda"].ToString();
                txt_precounitproduto.Text = dr["VlrVenda"].ToString();
            }
            //Fecha a conexão
            cmd.Connection.Close();
            #endregion

            #region 'COLOCA O FOCO'
            //Coloca o foco
            this.txt_quantidadeproduto.Focus();
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

        private void txt_totalorcamento_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_totalorcamento);
            txt_totalorcamento.TextAlign = HorizontalAlignment.Center;
            #endregion
        }
    }
}
