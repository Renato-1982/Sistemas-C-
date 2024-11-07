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
    public partial class FrmVendasPDV : Form
    {
        public FrmVendasPDV()
        {
            InitializeComponent();
        }

        #region "DECLARAÇÃO"
        //DECLARANDO VARIÁVEIS
        DateTime Data_Hora;
        int i;
        StreamReader rdr = null;
        #endregion

        #region "FORMATAÇÃO MOEDA TEXTBOX"
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

        #region 'GERAR CÓDIGO VENDA'
        private void GerarCodigoVenda()
        {
            #region "GERAR CÓDIGO VENDA"
            //PREENCHE AS CAIXAS DE ÚLTIMO LANÇAMENTO - EXEMPLO 1
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT max(IDVenda) from tb_vendastotalpdv";

            try
            {
                if (cmd.ExecuteScalar() == DBNull.Value)
                {
                    lbl_codvenda.Text = "1";
                }
                else
                {
                    Int32 ra = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    lbl_codvenda.Text = ra.ToString();
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

        #region 'GRAVAR VENDA'
        private void GravarVenda()
        {
            #region 'DECLARANDO VARIAVEIS E GRAVANDO DADOS NELAS'
            string idvenda = lbl_codvenda.Text;
            string datavenda = lbl_dataemp.Text;
            string horavenda = lbl_horaemp.Text;
            string nomecliente = txt_cliente.Text;
            string totalvenda = txt_totalvenda.Text;
            #endregion

            #region 'FORMATAÇÃO DA DATA'
            //BUSCA A FORMATAÇÃO DA DATA
            string datavendaF = FormatadataUS(datavenda);
            #endregion

            #region "TRY CATCH PARA GRAVAR"
            try
            {
                //Começa o comando para gravar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "Insert Into tb_vendastotalpdv(IDVenda, DataVenda, HoraVenda, NomeCliente, TotalVenda) Values";
                cmd.CommandText += "('" + idvenda + "','" + datavendaF + "','" + horavenda + "','" + nomecliente + "','" + totalvenda + "')";
                cmd.ExecuteNonQuery();
                cmd.Connection.Close(); //Fecha a conexão
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GravarItens();
            }
            #endregion
        }
        #endregion

        #region 'GRAVAR ITENS'
        private void GravarItens()
        {
            //COMANDO NÃO USANDO A CLASSE DE CONEXAO (GRAVAR ITENS)
            #region "GRAVAR ITENS"

            #region 'VERIFICA SE A CONEXÃO COM O BANCO NÃO ESTÁ ABERTA E ABRE'
            string StrCon = "SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;";
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
            foreach (ListViewItem item in lvw_vendas.Items)
            {
                #region 'DECLARANDO VARIAVEIS E GRAVANDO DADOS NELAS'
                //Declarando Variáveis e criando as strings
                string idvenda = lbl_codvenda.Text;
                string datavenda = lbl_dataemp.Text;
                string horavenda = lbl_horaemp.Text;
                string nomecliente = txt_cliente.Text;
                string idproduto = item.SubItems[0].Text;
                string descrproduto = item.SubItems[1].Text;
                string unvenda = item.SubItems[2].Text;
                string precoproduto = item.SubItems[3].Text;
                string qntproduto = item.SubItems[4].Text;
                string descoproduto = item.SubItems[5].Text;
                string totalproduto = item.SubItems[6].Text;
                string totalvenda = txt_totalvenda.Text;
                #endregion

                #region 'FORMATAÇÃO DA DATA'
                //BUSCA A FORMATAÇÃO DA DATA
                string datavendaF = FormatadataUS(datavenda);
                #endregion

                #region 'COMANDO PARA GRAVAR'
                //Comando para inserir no banco
                comm.CommandText = "Insert Into tb_vendasitenspdv(IDVenda, DataVenda, HoraVenda, " +
                    "NomeCliente, IDProduto, DescricaoProduto, UnVenda, PrecoProduto, " +
                    "QuantidadeProduto,DescontoProduto, ValorTotalProduto, ValorTotalVenda) Values";
                comm.CommandText += "('" + idvenda + "','" + datavendaF + "','" + horavenda + "','" + nomecliente + "'," +
                    "'" + idproduto + "','" + descrproduto + "','" + unvenda + "','" + precoproduto + "'," +
                    "'" + qntproduto + "','" + descoproduto + "','" + totalproduto + "','" + totalvenda + "')";
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
                cmd.CommandText = "SELECT * FROM tb_produtos where ID='" + idproduto + "'";
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
                decimal QntProdutoLista = Convert.ToDecimal(qntproduto);
                //-----------------------------------------------------------------------------------------------------                 
                //Declarando variavel e fazendo a subtração na quantidade do estoque 
                decimal AtualizaEstBanco = QntEstoqueBanco - QntProdutoLista;
                #endregion

                #region 'COMANDO PARA GRAVAR'
                //Comando para atualizar o estoque
                comm.CommandText = "update tb_produtos set " +
                    "Estoque ='" + AtualizaEstBanco + "' Where ID = " + idproduto + "";
                comm.ExecuteNonQuery();
                #endregion

                #endregion
            }
            #endregion

            #region "MENSAGEM DE EXECUÇÃO"
            //MENSAGEM DE EXECUÇÃO
            MessageBox.Show("Venda Finalizada com Sucesso!!!");
            #endregion

            #region "FECHA A CONEXÃO"
            //Fecha a conexão
            comm.Connection.Close(); //Fecha a conexão
            cn.Close();
            #endregion

            #endregion
        }
        #endregion

        #region 'ADICIONA A LISTVIEW'
        private void add(string cod, string descricao, string un, string preco, string qnt, string desconto, string valortotal)
        {
            #region "DESENHA A LISTVIEW"
            //Adicionar Linha
            //Matriz para Representar uma Linha
            string[] row = { cod, descricao, un, preco, qnt, desconto, valortotal };
            ListViewItem item = new ListViewItem(row);

            //Adicione ao lv
            lvw_vendas.Items.Add(item);
            #endregion
        }
        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            #region 'VERIFICA E LIMPA O ARQUIVO DE TEXTO'
            if (new FileInfo(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt").Length == 0)
            {
                // empty
            }
            else
            {
                List<string> mensagemLinha = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt");
                System.IO.File.WriteAllLines(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt", lines.Take<string>(lines.Length - 1000));
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

        private void FrmVendasPDV_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmVendasPDV_Load(object sender, EventArgs e)
        {
            #region "PREENCHENDO O CUPOM COM OS DADOS DA EMPRESA"

            #region "DECLARANDO VARIAVEL E DEIXANDO LIMPA"
            //Declarando a variavel e deixando limpa            
            string nomeempresa = string.Empty;
            string cnpjempresa = string.Empty;
            string cepempresa = string.Empty;
            string ruaempresa = string.Empty;
            string numeroempresa = string.Empty;
            string bairroempresa = string.Empty;
            string cidadeempresa = string.Empty;
            string estadoempresa = string.Empty;
            string telefoneempresa = string.Empty;
            #endregion

            #region "SELECIONA OS DADOS NO BANCO E REPASSA PARA A VARIAVEL"
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
                    nomeempresa = reader.GetString("Empresa");
                    cnpjempresa = reader.GetString("Cnpj");
                    cepempresa = reader.GetString("Cep");
                    ruaempresa = reader.GetString("Endereco");
                    numeroempresa = reader.GetString("Numero");
                    bairroempresa = reader.GetString("Bairro");
                    cidadeempresa = reader.GetString("Cidade");
                    estadoempresa = reader.GetString("Estado");
                    telefoneempresa = reader.GetString("TelFixo");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }
            #endregion

            #region "REPASSA OS DADOS DA VARIAVEL PARA A CAIXA"
            //Repassando os dados da variável para as caixas            
            lbl_nomeemp.Text = nomeempresa;
            lbl_cnpjemp.Text = cnpjempresa;
            lbl_cepemp.Text = cepempresa;
            lbl_ruaemp.Text = ruaempresa;
            lbl_numeroemp.Text = numeroempresa;
            lbl_bairroemp.Text = bairroempresa;
            lbl_cidadeemp.Text = cidadeempresa;
            lbl_estadoemp.Text = estadoempresa;
            lbl_telefoneemp.Text = telefoneempresa;
            //lbl_dataemp.Text = dataempresa;
            //lbl_horaemp.Text = horaempresa;  
            #endregion

            #endregion

            #region "VERIFICA SE A EMPRESA ESTÁ CADASTRADA"
            if (lbl_nomeemp.Text != "")
            {

            }
            else
            {
                #region "MENSAGEM"
                //MENSAGEM DE EXECUÇÃO
                MessageBox.Show("Cadastre sua empresa no menu, \n para fazer uma venda!");
                #endregion

                #region "FECHA A CONEXAO"
                //Fecha a aplicação
                this.Close();
                #endregion
            }
            #endregion

            #region "CAPTURAR DATA E HORA SISTEMA"
            //CAPTURAR HORA ATUAL
            string hora = System.DateTime.Now.ToShortTimeString();
            //CAPTURAR DATA ATUAL
            string DateTime = System.DateTime.Now.ToShortDateString();
            //PREENCHENDO AS CAIXAS COM DATA E HORA
            lbl_dataemp.Text = (DateTime);
            lbl_horaemp.Text = (hora);
            #endregion

            #region "LIMPAR CAIXAS"
            //Desativar/Ativar
            this.txt_cliente.Text = "";
            this.txt_idproduto.Text = "";
            this.txt_nomeproduto.Text = "";
            this.txt_unidadevenda.Text = "";
            this.txt_precounitproduto.Text = "";
            this.txt_qntproduto.Text = "";
            this.txt_descontoproduto.Text = "";
            this.txt_totalproduto.Text = "";
            this.txt_totalvenda.Text = "";
            this.lbl_codvenda.Text = "";
            this.txt_vendas.Text = "";
            this.lvw_vendas.Text = "";
            this.lvw_vendas.Clear();
            #endregion

            #region 'PREENCHE AS CAIXAS'
            txt_qntproduto.Text = "0,000";
            txt_precounitproduto.Text = "0,00";
            txt_descontoproduto.Text = "0,00";
            txt_totalproduto.Text = "0,00";
            txt_totalvenda.Text = "0,00";
            #endregion

            #region "ATIVA/DESATIVA AS CAIXAS"
            //Desativar/Ativar
            this.txt_cliente.Enabled = false;
            this.txt_idproduto.Enabled = false;
            this.txt_nomeproduto.Enabled = false;
            this.txt_unidadevenda.Enabled = false;
            this.txt_precounitproduto.Enabled = false;
            this.txt_qntproduto.Enabled = false;
            this.txt_descontoproduto.Enabled = false;
            this.txt_totalproduto.Enabled = false;
            this.txt_totalvenda.Enabled = false;
            this.txt_vendas.Text = "";
            this.txt_vendas.Enabled = false;
            this.lvw_vendas.Enabled = false;
            #endregion

            #region "ATIVA/DESATIVA BOTOES"
            this.btn_novavenda.Enabled = true;
            this.btn_addproduto.Enabled = false;
            this.btn_finalizarvenda.Enabled = false;
            this.btn_cancelar.Enabled = false;
            this.btn_fechar.Enabled = true;
            this.btnCerrar.Enabled = true;
            this.btn_liberacliente.Enabled = false;
            #endregion

            #region "PREENCHE A SITUAÇÃO E COLOCA O FOCO"            
            //ESCREVE SITUAÇÃO
            lbl_cxlivre.Text = "CAIXA LIVRE";
            lbl_cxlivre.ForeColor = Color.White;
            //COLOCA O FOCO
            this.btn_novavenda.Focus();
            #endregion

            #region 'VERIFICA E LIMPA O ARQUIVO DE TEXTO'
            if (new FileInfo(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt").Length == 0)
            {
                // empty
            }
            else
            {
                List<string> mensagemLinha = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt");
                System.IO.File.WriteAllLines(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt", lines.Take<string>(lines.Length - 1000));
            }
            #endregion

            #region 'COLOCA O FOCO'
            //Posiciona o foco
            btn_novavenda.Focus();
            #endregion
        }

        public string AbreArquivoTexto(string caminho)
        {
            #region 'ABRE ARQUIVO'
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

        private void btn_liberacliente_Click(object sender, EventArgs e)
        {
            #region "ATIVA/DESATIVA AS CAIXAS"
            //Desativar/Ativar
            this.txt_cliente.Enabled = true;
            this.txt_idproduto.Enabled = false;
            this.txt_nomeproduto.Enabled = false;
            this.txt_unidadevenda.Enabled = false;
            this.txt_precounitproduto.Enabled = false;
            this.txt_qntproduto.Enabled = false;
            this.txt_descontoproduto.Enabled = false;
            this.txt_totalproduto.Enabled = false;
            this.txt_totalvenda.Enabled = false;
            //this.txt_vendas.Text = "";
            this.txt_vendas.Enabled = false;
            #endregion

            #region "ATIVAR/DESATIVAR BOTOES"
            this.btn_novavenda.Enabled = false;
            this.btn_addproduto.Enabled = false;
            this.btn_finalizarvenda.Enabled = false;
            this.btn_cancelar.Enabled = true;
            this.btn_fechar.Enabled = false;
            this.btnCerrar.Enabled = false;
            this.btn_liberacliente.Enabled = false;
            #endregion

            #region 'COLOCA O FOCO'
            //Posiciona o foco
            txt_cliente.Focus();
            #endregion
        }

        private void btn_novavenda_Click(object sender, EventArgs e)
        {
            #region 'VERIFICA E LIMPA O ARQUIVO DE TEXTO'
            if (new FileInfo(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt").Length == 0)
            {
                // empty
            }
            else
            {
                List<string> mensagemLinha = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt");
                System.IO.File.WriteAllLines(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt", lines.Take<string>(lines.Length - 1000));
            }
            #endregion

            #region "VERIFICA SE A EMPRESA ESTÁ CADASTRADA"
            if (lbl_nomeemp.Text != "")
            {

            }
            else
            {
                //MENSAGEM DE EXECUÇÃO
                MessageBox.Show("Cadastre sua empresa no menu, \n para fazer uma venda!");

                //Fecha a aplicação
                this.Close();
            }
            #endregion

            #region "CAPTURAR DATA E HORA SISTEMA"
            //CAPTURAR HORA ATUAL
            string hora = System.DateTime.Now.ToShortTimeString();
            //CAPTURAR DATA ATUAL
            string DateTime = System.DateTime.Now.ToShortDateString();
            //PREENCHENDO AS CAIXAS
            lbl_dataemp.Text = (DateTime);
            lbl_horaemp.Text = (hora);
            #endregion

            #region "LIMPAR CAIXAS"
            //Desativar/Ativar
            this.txt_cliente.Text = "";
            this.txt_idproduto.Text = "";
            this.txt_nomeproduto.Text = "";
            this.txt_unidadevenda.Text = "";
            this.txt_precounitproduto.Text = "";
            this.txt_qntproduto.Text = "";
            this.txt_descontoproduto.Text = "";
            this.txt_totalproduto.Text = "";
            this.txt_totalvenda.Text = "";
            this.lbl_codvenda.Text = "";
            this.txt_vendas.Text = "";
            this.lvw_vendas.Text = "";
            this.lvw_vendas.Clear();
            #endregion

            #region 'PREENCHE AS CAIXAS'
            txt_cliente.Text = "Consumidor Final";
            txt_qntproduto.Text = "0,000";
            txt_precounitproduto.Text = "0,00";
            txt_descontoproduto.Text = "0,00";
            txt_totalproduto.Text = "0,00";
            txt_totalvenda.Text = "0,00";
            #endregion

            #region "ATIVA/DESATIVA AS CAIXAS"
            //Desativar/Ativar
            this.txt_cliente.Enabled = false;
            this.txt_idproduto.Enabled = true;
            this.txt_nomeproduto.Enabled = true;
            this.txt_unidadevenda.Enabled = false;
            this.txt_precounitproduto.Enabled = false;
            this.txt_qntproduto.Enabled = true;
            this.txt_descontoproduto.Enabled = true;
            this.txt_totalproduto.Enabled = false;
            this.txt_totalvenda.Enabled = false;
            this.txt_vendas.Text = "";
            this.txt_vendas.Enabled = false;
            this.lvw_vendas.Enabled = false;
            #endregion

            #region "ATIVAR/DESATIVAR BOTOES"
            this.btn_novavenda.Enabled = false;
            this.btn_addproduto.Enabled = true;
            this.btn_finalizarvenda.Enabled = true;
            this.btn_cancelar.Enabled = true;
            this.btn_fechar.Enabled = false;
            this.btnCerrar.Enabled = false;
            this.btn_liberacliente.Enabled = true;
            #endregion

            #region "PREENCHE A SITUAÇÃO E COLOCA O FOCO"            
            lbl_cxlivre.Text = "CUPOM ABERTO";
            lbl_cxlivre.ForeColor = Color.Red;
            this.txt_idproduto.Focus();
            #endregion

            #region "CÓDIGO DE VENDA"
            GerarCodigoVenda();
            #endregion

            #region "COMPLETA A TEXTBOX"

            #region 'AUTOCOMPLETE TEXTBOX NOME PRODUTO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "Select DescricaoProduto from tb_produtos order by DescricaoProduto";
            cmd.ExecuteNonQuery();
            MySqlDataReader datareader;
            datareader = cmd.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

            while (datareader.Read())
            {
                autotext.Add(datareader.GetString(0));
            }
            txt_nomeproduto.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_nomeproduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_nomeproduto.AutoCompleteCustomSource = autotext;
            cmd.Connection.Close(); //Fecha a conexão
            #endregion

            #region 'AUTOCOMPLETE TEXTBOX NOME CLIENTE'
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

            #endregion
        }

        private void btn_addproduto_Click(object sender, EventArgs e)
        {
            #region 'VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR'
            if (txt_idproduto.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idproduto.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_nomeproduto.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_nomeproduto.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_qntproduto.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_qntproduto.Focus();
                return;
            }
            //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
            if (txt_precounitproduto.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_nomeproduto.Focus();
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
            if (txt_totalproduto.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_nomeproduto.Focus();
                return;
            }
            #endregion

            #region 'ADICIONA OS ITENS'
            //Adiciona os itens
            add(txt_idproduto.Text, txt_nomeproduto.Text, txt_unidadevenda.Text, txt_precounitproduto.Text, txt_qntproduto.Text, txt_descontoproduto.Text, txt_totalproduto.Text);

            #endregion

            #region 'REALIZA A SOMA DAS CAIXAS'                 
            //REALIZA A SOMA DAS CAIXAS  
            Decimal valor1 = Convert.ToDecimal(txt_totalproduto.Text);
            Decimal valor2 = Convert.ToDecimal(txt_totalvenda.Text);
            Decimal saldo = valor1 + valor2;

            //MOSTRA O RESULTADO DA SOMA
            txt_totalvenda.Text = saldo.ToString();
            #endregion

            #region 'ADICIONA E ESCREVE OS DADOS NO ARQUIVO'
            //ATIVA/DESATIVA AS CAIXAS
            txt_vendas.Enabled = true;

            //Declara variaveis e preenche com os dados
            string codigo = txt_idproduto.Text;
            string descricao = txt_nomeproduto.Text;
            string unvenda = txt_unidadevenda.Text;
            string precounit = txt_precounitproduto.Text;
            string quantidade = txt_qntproduto.Text;
            string desconto = txt_descontoproduto.Text;
            string total = txt_totalproduto.Text;

            string nomeArquivo = @"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt";
            string textoInserir = codigo + "   |   " + descricao + "     |   " + unvenda + "   |   " + precounit + "   |   " + quantidade + "   |   " + desconto + "   |   " + total;

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
            txt_vendas.Text = AbreArquivoTexto(nomeArquivo);

            #endregion

            #region 'FAZ A CONTAGEM DE LINHAS E LIMITA O LANÇAMENTO'

            //Faz a contagem de linhas do arquivo e limita a 45 lançamentos
            if (linhas.Count >= 45)
            {
                MessageBox.Show("Limite máximo de ítens");
                btn_addproduto.Enabled = false;
            }
            else
            {

            }
            #endregion

            #region 'ATIVA/DESATIVA AS CAIXAS'
            //ATIVA/DESATIVA AS CAIXAS
            txt_vendas.Enabled = false;
            #endregion

            #region 'LIMPAS AS CAIXAS'
            txt_idproduto.Text = "";
            txt_nomeproduto.Text = "";
            txt_unidadevenda.Text = "";
            txt_precounitproduto.Text = "";
            txt_qntproduto.Text = "";
            txt_descontoproduto.Text = "";
            txt_totalproduto.Text = "";
            #endregion

            #region 'COLOCA O FOCO'
            //Coloca o foco na caixa
            txt_idproduto.Focus();
            #endregion                        
        }

        private void btn_finalizarvenda_Click(object sender, EventArgs e)
        {
            #region "FINALIZA A VENDA E IMPRIME"
            //Verifica se foi lançado algum produto para finalizar a venda
            if (txt_vendas.Text != "")
            {
                #region "GRAVA A VENDA"
                GravarVenda();
                #endregion

                #region 'COPIA O ARQUIVO PARA PASTA SELECIONADA'
                //DEFINE O NOME DO ARQUIVO DE ACORDO COM DATA E HORA.
                string dia = DateTime.Now.Day.ToString();
                string mes = DateTime.Now.Month.ToString();
                string ano = DateTime.Now.Year.ToString();
                string hora = DateTime.Now.ToLongTimeString().Replace(":", "");
                string nomedoarquivo = "_" + dia + "-" + mes + "-" + ano + "_" + hora;
                string codvenda = "_" + lbl_codvenda.Text;
                string cliente = "_" + txt_cliente.Text;

                //COPIANDO O ARQUIVO DA PASTA MUTSEGBD\VENDA.TXT PARA A PASTA MULTSEGARQUIVOS\VENDAS
                File.Copy(@"C:\SIGRASSYSTEMBD\VENDAS\Venda" + ".txt", @"C:\SIGRASSYSTEMBD\VENDAS\Venda" + codvenda + cliente + nomedoarquivo + ".txt");
                //Fim
                #endregion

                #region 'VERIFICA E LIMPA O ARQUIVO DE TEXTO'
                if (new FileInfo(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt").Length == 0)
                {
                    // empty
                }
                else
                {
                    List<string> mensagemLinha = new List<string>();
                    string[] lines = System.IO.File.ReadAllLines(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt");
                    System.IO.File.WriteAllLines(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt", lines.Take<string>(lines.Length - 1000));
                }
                #endregion

                #region 'DESENHAR O QUE SERÁ IMPRESSO NO PDF'

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
                graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(25, 15, 450, 40));
                //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));                    
                #endregion

                #region 'TEXTOS EMPRESA'
                // Textos. Empresa-----------------------------------------------------------------------------------------------------Início/Altura----------------------------
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(lbl_nomeemp.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 18, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(lbl_cnpjemp.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(300, 18, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(lbl_cepemp.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 28, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(lbl_ruaemp.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(80, 28, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(lbl_bairroemp.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(250, 28, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(lbl_cidadeemp.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(350, 28, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(lbl_estadoemp.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(450, 28, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(lbl_telefoneemp.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 38, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(lbl_dataemp.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(150, 38, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(lbl_horaemp.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(250, 38, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("DOCUMENTO NÃO FISCAL", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(250, 56, page.Width - 70, page.Height - 70));
                #endregion

                #region 'FIGURA GEOMÉTRICA'
                // Figuras geométricas. ID Numero Cupom-------------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
                graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(480, 15, 95, 40));
                //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));
                #endregion

                #region 'TEXTOS ID VENDA'
                // Textos. ID Numero Cupom--------------------------------------------------------------------------------------------------------------------------------------
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Venda", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(510, 18, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Nº", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(520, 28, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(lbl_codvenda.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(520, 38, page.Width - 60, page.Height - 60));
                #endregion

                #region 'FIGURA GEOMÉTRICA'
                // Figuras geométricas. Cliente---------------------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
                graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(25, 70, 550, 18));
                //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));
                #endregion

                #region 'TEXTO CLIENTE'
                // Textos. Cliente-----------------------------------------------------------------------------------------------------------------------------------------------
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Cliente:", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 72, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(txt_cliente.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(65, 72, page.Width - 60, page.Height - 60));
                #endregion

                #region 'FIGURA GEOMÉTRICA'
                // Figuras geométricas. Cabeçalho Produtos----------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
                graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(25, 93, 550, 15));
                //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));
                #endregion

                #region 'TEXTO LISTA DE CABEÇALHO'
                //----------------------------------------Lista de Produtos Cabeçalho-------------------------------------------------------------------------------------------
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("COD", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 95, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("DESC.", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(70, 95, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("QTD", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(165, 95, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("VLR.UN", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(200, 95, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("DESC.UN", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(250, 95, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("VLR.TOTAL", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(300, 95, page.Width - 60, page.Height - 60));
                #endregion

                #region 'TEXTO LISTA DE PRODUTOS'
                //----------------------------------------Lista de Produtos-----------------------------------------------------------------------------------------------------
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(txt_vendas.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 110, page.Width - 60, page.Height - 60));
                #endregion

                #region 'FIGURA GEOMÉTRICA'
                // Figuras geométricas. Observação------------------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
                graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(25, 800, 450, 30));
                //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));                    
                #endregion

                #region 'TEXTO OBSERVAÇÃO'
                // Textos. Observação-------------------------------------------------------------------------------------------------------------------------------------------
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Devolução/Troca - Apresentar esse Cupom", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 803, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("Obrigado, Volte Sempre!!!", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 815, page.Width - 60, page.Height - 60));
                #endregion

                #region 'FIGURA GEOMÉTRICA'
                // Figuras geométricas. Valor Total------------------------------------------------------Início/Altura de cima/Largura comprimento/Altura de baixo---------------
                graphics.DrawRectangle(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(480, 800, 95, 30));
                //graphics.DrawEllipse(PdfSharp.Drawing.XPens.Black, PdfSharp.Drawing.XBrushes.White, new PdfSharp.Drawing.XRect(350, 33, 100, 100));
                #endregion

                #region 'TEXTO VALOR TOTAL'
                // Textos. Valor Total-------------------------------------------------------------------------------------------------------------------------------------------
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString("TOTAL", font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(485, 803, page.Width - 60, page.Height - 60));

                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
                textFormatter.DrawString(txt_totalvenda.Text, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(510, 815, page.Width - 60, page.Height - 60));
                #endregion

                #region 'INICIA O PDF'
                // Inicia o PDF--------------------------------------------------------------------------------------------------------------------------------------------------                                     
                document.Save("Venda.pdf");
                System.Diagnostics.Process.Start("Venda.pdf");
                #endregion

                #endregion
            }
            else
            {
                #region "MENSAGEM E COLOCA O FOCO"
                MessageBox.Show("Adicione um produto para finalizar a venda!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txt_idproduto.Focus();
                return;
                #endregion
            }
            #endregion

            #region "LIMPAR CAIXAS"
            //Desativar/Ativar
            this.txt_cliente.Text = "";
            this.txt_idproduto.Text = "";
            this.txt_nomeproduto.Text = "";
            this.txt_unidadevenda.Text = "";
            this.txt_precounitproduto.Text = "";
            this.txt_qntproduto.Text = "";
            this.txt_descontoproduto.Text = "";
            this.txt_totalproduto.Text = "";
            this.txt_totalvenda.Text = "";
            this.lbl_codvenda.Text = "";
            this.txt_vendas.Text = "";
            #endregion

            #region "ATIVA/DESATIVA AS CAIXAS"
            //Desativar/Ativar
            this.txt_cliente.Enabled = false;
            this.txt_idproduto.Enabled = false;
            this.txt_nomeproduto.Enabled = false;
            this.txt_unidadevenda.Enabled = false;
            this.txt_precounitproduto.Enabled = false;
            this.txt_qntproduto.Enabled = false;
            this.txt_descontoproduto.Enabled = false;
            this.txt_totalproduto.Enabled = false;
            this.txt_totalvenda.Enabled = false;
            this.txt_vendas.Text = "";
            this.txt_vendas.Enabled = false;
            #endregion

            #region "ATIVAR/DESATIVAR BOTOES"
            this.btn_novavenda.Enabled = true;
            this.btn_addproduto.Enabled = false;
            this.btn_finalizarvenda.Enabled = false;
            this.btn_cancelar.Enabled = false;
            this.btn_fechar.Enabled = true;
            this.btn_liberacliente.Enabled = false;
            #endregion

            #region "PREENCHE A SITUAÇÃO"
            //ESCREVE SITUAÇÃO
            lbl_cxlivre.Text = "CAIXA LIVRE";
            lbl_cxlivre.ForeColor = Color.White;
            #endregion

            #region 'COLOCA O FOCO'
            //Posiciona o foco
            btn_novavenda.Focus();
            #endregion
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            #region "CANCELAR"
            //fecha o formulário
            DialogResult dlgResult = MessageBox.Show("Deseja realmente cancelar o cupom em aberto ?                        Clicando em sim, a venda será cancelada ! ", "Encerrar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                #region 'VERIFICA E LIMPA O ARQUIVO DE TEXTO'
                if (new FileInfo(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt").Length == 0)
                {
                    // empty
                }
                else
                {
                    List<string> mensagemLinha = new List<string>();
                    string[] lines = System.IO.File.ReadAllLines(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt");
                    System.IO.File.WriteAllLines(@"C:\SIGRASSYSTEMBD\VENDAS\Venda.txt", lines.Take<string>(lines.Length - 1000));
                }
                #endregion

                #region "LIMPAR CAIXAS"
                //Desativar/Ativar
                this.txt_cliente.Text = "";
                this.txt_idproduto.Text = "";
                this.txt_nomeproduto.Text = "";
                this.txt_unidadevenda.Text = "";
                this.txt_precounitproduto.Text = "";
                this.txt_qntproduto.Text = "";
                this.txt_descontoproduto.Text = "";
                this.txt_totalproduto.Text = "";
                this.txt_totalvenda.Text = "";
                this.lbl_codvenda.Text = "";
                this.txt_vendas.Text = "";
                this.lvw_vendas.Text = "";
                this.lvw_vendas.Clear();
                #endregion

                #region "ATIVA/DESATIVA AS CAIXAS"
                //Desativar/Ativar
                this.txt_cliente.Enabled = false;
                this.txt_idproduto.Enabled = false;
                this.txt_nomeproduto.Enabled = false;
                this.txt_unidadevenda.Enabled = false;
                this.txt_precounitproduto.Enabled = false;
                this.txt_qntproduto.Enabled = false;
                this.txt_descontoproduto.Enabled = false;
                this.txt_totalproduto.Enabled = false;
                this.txt_totalvenda.Enabled = false;
                this.txt_vendas.Text = "";
                this.txt_vendas.Enabled = false;
                this.lvw_vendas.Enabled = false;
                #endregion

                #region "ATIVAR/DESATIVAR BOTOES"
                this.btn_novavenda.Enabled = true;
                this.btn_addproduto.Enabled = false;
                this.btn_finalizarvenda.Enabled = false;
                this.btn_cancelar.Enabled = false;
                this.btn_fechar.Enabled = true;
                this.btn_liberacliente.Enabled = false;
                #endregion

                #region "PREENCHE A SITUAÇÃO"
                //ESCREVE SITUAÇÃO
                lbl_cxlivre.Text = "CAIXA LIVRE";
                lbl_cxlivre.ForeColor = Color.White;
                #endregion

                #region 'ATUALIZA INICIALIZANDO'
                //ATUALIZAR TELA COM INICIALIZAÇÃO
                FrmVendasPDV_Load(sender, e);
                #endregion

                #region 'COLOCA O FOCO'
                //Posiciona o foco
                btn_novavenda.Focus();
                #endregion
            }
            #endregion
        }

        private void btn_encerrar_Click(object sender, EventArgs e)
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

        private void txt_qntproduto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_totalproduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_totalvenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_cliente_Leave(object sender, EventArgs e)
        {
            #region "ATIVA/DESATIVA AS CAIXAS"
            //Desativar/Ativar
            this.txt_cliente.Enabled = false;
            this.txt_idproduto.Enabled = true;
            this.txt_nomeproduto.Enabled = true;
            this.txt_unidadevenda.Enabled = false;
            this.txt_precounitproduto.Enabled = false;
            this.txt_qntproduto.Enabled = true;
            this.txt_descontoproduto.Enabled = true;
            this.txt_totalproduto.Enabled = false;
            this.txt_totalvenda.Enabled = false;
            this.txt_vendas.Text = "";
            this.txt_vendas.Enabled = false;
            this.lvw_vendas.Enabled = false;
            #endregion

            #region "ATIVAR/DESATIVAR BOTOES"
            this.btn_novavenda.Enabled = false;
            this.btn_addproduto.Enabled = true;
            this.btn_finalizarvenda.Enabled = true;
            this.btn_cancelar.Enabled = true;
            this.btn_fechar.Enabled = false;
            this.btn_liberacliente.Enabled = true;
            this.btnCerrar.Enabled = false;
            #endregion

            #region 'COLOCA O FOCO'
            //Posiciona o foco
            txt_idproduto.Focus();
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
                txt_nomeproduto.Text = dr["DescricaoProduto"].ToString();
                txt_unidadevenda.Text = dr["UnVenda"].ToString();
                txt_precounitproduto.Text = dr["VlrVenda"].ToString();
            }
            //Fecha a conexão
            cmd.Connection.Close();
            #endregion

            #region 'COLOCA O FOCO'
            //Coloca o foco
            this.txt_qntproduto.Focus();
            #endregion
        }

        private void txt_nomeproduto_Leave(object sender, EventArgs e)
        {
            #region 'SELECIONA OS DADOS E PREENCHE AO SAIR DA CAIXA'
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb_produtos WHERE DescricaoProduto = '" + txt_nomeproduto.Text + "'"; //Seleciona a tabela e procura os dados            
            MySqlDataReader dr = cmd.ExecuteReader(); //Executa o comando selecionar                    

            while (dr.Read())
            {
                //Repassa os dados da tabela para a textbox
                txt_idproduto.Text = dr["ID"].ToString();
                txt_nomeproduto.Text = dr["DescricaoProduto"].ToString();
                txt_unidadevenda.Text = dr["UnVenda"].ToString();
                txt_precounitproduto.Text = dr["VlrVenda"].ToString();
            }
            //Fecha a conexão
            cmd.Connection.Close();
            #endregion

            #region 'COLOCA O FOCO'
            //Coloca o foco
            this.txt_qntproduto.Focus();
            #endregion
        }

        private void txt_qntproduto_Leave(object sender, EventArgs e)
        {
            #region "LIMPAS AS CAIXAS" 
            //Limpa as caixas
            txt_descontoproduto.Text = "";
            txt_descontoproduto.Text = "0,00";
            #endregion

            #region "CONDIÇÃO PARA VERIFICAR CAIXAS"
            if (txt_idproduto.Text != "" && txt_unidadevenda.Text == "UN")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_qntproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_qntproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_qntproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                    if (txt_precounitproduto.Text != "")
                    {
                        //Cálculos
                        txt_totalproduto.Text = "";
                        txt_totalproduto.Text = "0,00";
                        decimal QntProdutos = Convert.ToDecimal(txt_qntproduto.Text);
                        decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                        decimal VlrTotal = Convert.ToDecimal(txt_totalproduto.Text);
                        VlrTotal = QntProdutos * PrecoUnitprodutos;
                        txt_totalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                        txt_descontoproduto.Focus();
                    }
                    else
                    {
                        txt_nomeproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_qntproduto.Focus();
                }
                #endregion
            }
            else if (txt_idproduto.Text != "" && txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_qntproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_qntproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_qntproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                    if (txt_precounitproduto.Text != "")
                    {
                        //Cálculos
                        txt_totalproduto.Text = "";
                        txt_totalproduto.Text = "0,00";
                        decimal QntProdutos = Convert.ToDecimal(txt_qntproduto.Text);
                        decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                        decimal VlrTotal = Convert.ToDecimal(txt_totalproduto.Text);
                        VlrTotal = QntProdutos * PrecoUnitprodutos;
                        txt_totalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                        txt_descontoproduto.Focus();
                    }
                    else
                    {
                        txt_nomeproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_qntproduto.Focus();
                }
                #endregion
            }
            else
            {
                #region "LIMPAS AS CAIXAS"            
                //ITENS
                //Limpa as caixas
                txt_idproduto.Text = "";
                txt_nomeproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
                txt_qntproduto.Text = "";
                txt_descontoproduto.Text = "";
                txt_descontoproduto.Text = "0,00";
                txt_totalproduto.Text = "";
                txt_totalproduto.Text = "0,00";
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
                if (txt_qntproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_qntproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_qntproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                    if (txt_precounitproduto.Text != "")
                    {
                        #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                        if (txt_descontoproduto.Text != "")
                        {
                            //Cálculos
                            txt_totalproduto.Text = "";
                            decimal QntProdutos = Convert.ToDecimal(txt_qntproduto.Text);
                            decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                            decimal DescProdutos = Convert.ToDecimal(txt_descontoproduto.Text);
                            decimal VlrTotal = Convert.ToDecimal(txt_totalproduto.Text);
                            VlrTotal = (QntProdutos * PrecoUnitprodutos) - DescProdutos;
                            txt_totalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                            btn_addproduto.Focus();
                        }
                        else
                        {
                            txt_descontoproduto.Focus();
                        }
                        #endregion
                    }
                    else
                    {
                        txt_nomeproduto.Focus();
                    }
                    #endregion
                }
                else
                {
                    txt_qntproduto.Focus();
                }
                #endregion
            }
            else if (txt_idproduto.Text != "" && txt_unidadevenda.Text == "KG" || txt_unidadevenda.Text == "MT")
            {
                #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                if (txt_qntproduto.Text != "")
                {
                    //Converte para três casas decimais
                    txt_qntproduto.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_qntproduto.Text));

                    #region 'CONDIÇÃO PARA VERIFICAR CAIXAS'
                    if (txt_precounitproduto.Text != "")
                    {
                        #region 'CONDIÇÃO PARA VERIFICAR CAIXAS E FAZER OS CÁLCULOS'
                        if (txt_descontoproduto.Text != "")
                        {
                            //Cálculos
                            txt_totalproduto.Text = "";
                            decimal QntProdutos = Convert.ToDecimal(txt_qntproduto.Text);
                            decimal PrecoUnitprodutos = Convert.ToDecimal(txt_precounitproduto.Text);
                            decimal DescProdutos = Convert.ToDecimal(txt_descontoproduto.Text);
                            decimal VlrTotal = Convert.ToDecimal(txt_totalproduto.Text);
                            VlrTotal = (QntProdutos * PrecoUnitprodutos) - DescProdutos;
                            txt_totalproduto.Text = Math.Round(VlrTotal, 2).ToString();
                            btn_addproduto.Focus();
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
                    txt_qntproduto.Focus();
                }
                #endregion
            }
            else
            {
                #region "LIMPAS AS CAIXAS"            
                //ITENS
                txt_idproduto.Text = "";
                txt_nomeproduto.Text = "";
                txt_unidadevenda.Text = "";
                txt_precounitproduto.Text = "";
                txt_qntproduto.Text = "";
                txt_descontoproduto.Text = "";
                txt_totalproduto.Text = "";
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

        private void txt_totalproduto_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_totalproduto);
            txt_totalproduto.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txt_totalvenda_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_totalvenda);
            txt_totalvenda.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void timer_pdv_Tick(object sender, EventArgs e)
        {
            #region "COLOCA DATA E HORA ATUAL"
            //PREENCHE A LABEL COM OS DADOS
            Data_Hora = DateTime.Now;
            lbl_marcasistema.Text =  Data_Hora.ToLongDateString() + "  /  " + Data_Hora.ToLongTimeString();
            //lbl_marcasistema.Text = "Data: " + Data_Hora.ToLongDateString() + "  /  Hora: " + Data_Hora.ToLongTimeString();
            #endregion
        }
    }
}
