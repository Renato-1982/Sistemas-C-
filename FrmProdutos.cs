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
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        #region "PREENCHENDO COMBOBOX COM DADOS DO BANCO"
        public void FillComboFamilia(string strSql, string tstr)
        {
            #region 'CAIXA FAMILIA'
            cbo_familia.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    cbo_familia.Items.Add(datareader[0]);
                }
                cmd.Connection.Close(); //Fecha a conexão
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion
        }

        public void FillComboGrupo(string strSql, string tstr)
        {
            #region ' CAIXA GRUPO'
            cbo_grupo.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    cbo_grupo.Items.Add(datareader[0]);
                }
                cmd.Connection.Close(); //Fecha a conexão
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion
        }

        public void FillComboUnidadeCompra(string strSql, string tstr)
        {
            #region 'CAIXA UNIDADE COMPRA'
            cbo_uncompra.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    cbo_uncompra.Items.Add(datareader[0]);
                }
                cmd.Connection.Close(); //Fecha a conexão
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion
        }

        public void FillComboUnidadeEstocagem(string strSql, string tstr)
        {
            #region 'CAIXA UNIDADE ESTOCAGEM'
            cbo_unestocagem.Items.Clear();
            try
            {
                //Começa o comando para selecionar e preencher
                MySqlCommand cmd = new MySqlCommand(strSql);
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                MySqlDataReader datareader;
                datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    cbo_unestocagem.Items.Add(datareader[0]);
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

        private void FrmProdutos_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            #region 'CARREGAR COMBOBOX COM DADOS'   

            #region 'CARREGAR COMBOBOX STATUS'           
            this.cbo_status.Items.Add("Ativo");
            this.cbo_status.Items.Add("Inativo");
            #endregion

            #region 'CARREGAR COMBOBOX TIPO DO ÍTEM' 
            this.cbo_tipoitem.Items.Add("Mercadoria para Revenda");
            this.cbo_tipoitem.Items.Add("Matéria Prima");
            this.cbo_tipoitem.Items.Add("Produto Acabado");
            this.cbo_tipoitem.Items.Add("Ativo Imobilizado");
            this.cbo_tipoitem.Items.Add("Embalagem");
            this.cbo_tipoitem.Items.Add("Material de Uso e Consumo");
            this.cbo_tipoitem.Items.Add("Serviços");
            this.cbo_tipoitem.Items.Add("SubProduto");
            this.cbo_tipoitem.Items.Add("Produto em Processo");
            this.cbo_tipoitem.Items.Add("Produto Intermediário");
            this.cbo_tipoitem.Items.Add("Outros Insumos");
            this.cbo_tipoitem.Items.Add("Outros");
            #endregion

            #region 'CARREGAR COMBOBOX UN VENDA'           
            this.cbo_unvenda.Items.Add("UN");
            this.cbo_unvenda.Items.Add("KG");
            this.cbo_unvenda.Items.Add("MT");
            #endregion

            #endregion

            #region 'ATIVAR/DESATIVAR CAIXAS'
            this.txt_id.Enabled = false;
            this.txt_datacadastro.Enabled = false;
            this.cbo_status.Enabled = false;
            this.txt_descricaoproduto.Enabled = false;
            this.cbo_tipoitem.Enabled = false;
            this.cbo_grupo.Enabled = false;
            this.cbo_familia.Enabled = false;
            this.txt_ean.Enabled = false;
            this.cbo_uncompra.Enabled = false;
            this.cbo_unestocagem.Enabled = false;
            this.txt_estoque.Enabled = false;
            this.txt_dataalteracao.Enabled = false;
            this.txt_vlrcompra.Enabled = false;
            this.txt_vlrvenda.Enabled = false;
            this.cbo_unvenda.Enabled = false;
            this.txt_obs.Enabled = false;
            #endregion

            #region 'VERIFICA SE O ID ESTA PREENCHIDO PARA ATIVAR E DESATIVAR BOTOES'
            if (txt_id.Text != "")
            {
                #region'DESATIVAR/ATIVAR BOTÕES'
                this.btNovo.Enabled = false;
                this.btGravar.Enabled = false;
                this.btAlterar.Enabled = false;
                this.btEditar.Enabled = true;
                this.btCancelar.Enabled = true;
                this.btConsultar.Enabled = false;
                this.btRelatorio.Enabled = true;
                this.btFechar.Enabled = false;
                this.btn_estoqueajuste.Enabled = false;
                this.btnCerrar.Enabled = false;
                #endregion
            }
            else
            {
                #region'DESATIVAR/ATIVAR BOTÕES'
                this.btNovo.Enabled = true;
                this.btGravar.Enabled = false;
                this.btAlterar.Enabled = false;
                this.btEditar.Enabled = false;
                this.btCancelar.Enabled = false;
                this.btConsultar.Enabled = true;
                this.btRelatorio.Enabled = true;
                this.btFechar.Enabled = true;
                this.btn_estoqueajuste.Enabled = false;
                this.btnCerrar.Enabled = true;
                #endregion

                #region 'COLOCA O FOCO'
                //POSICIONA O MOUSE
                btNovo.Focus();
                #endregion
            }
            #endregion
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            #region 'PREENCHENDO A CAIXA DATA COM DADOS ATUAIS'
            //CAPTURAR DATA
            string DateTime = System.DateTime.Now.ToShortDateString();
            //PREENCHENDO AS CAIXAS
            txt_datacadastro.Text = (DateTime);
            txt_dataalteracao.Text = (DateTime);
            #endregion
     
            #region 'LIMPA AS CAIXAS'
            this.txt_id.Text = "";
            //this.txt_datacadastro.Text = "";
            this.cbo_status.Text = "";
            this.txt_descricaoproduto.Text = "";
            this.cbo_tipoitem.Text = "";
            this.cbo_grupo.Text = "";
            this.cbo_familia.Text = "";
            this.txt_ean.Text = "";
            this.cbo_uncompra.Text = "";
            this.cbo_unestocagem.Text = "";
            //this.txt_estoque.Text = "";
            //this.txt_dataalteracao.Text = "";
            this.txt_vlrcompra.Text = "";
            this.txt_vlrvenda.Text = "";
            this.cbo_unvenda.Text = "";
            this.txt_obs.Text = "";
            #endregion

            #region CARREGA AS COMBOBOX'

            #region 'CARREGAR COMBOBOX GRUPO'
            try
            {
                string strSQL = "Select DescricaoGrupos from tb_produtosgrupos order by DescricaoGrupos";
                string tstr = "tb_produtosgrupos";
                FillComboGrupo(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'CARREGAR COMBOBOX FAMILIA'
            try
            {
                string strSQL = "Select DescricaoFamilia from tb_produtosfamilias order by DescricaoFamilia";
                string tstr = "tb_produtosfamilias";
                FillComboFamilia(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'CARREGAR COMBOBOX UNIDADE COMPRA'
            try
            {
                string strSQL = "Select Abreviacao from tb_produtosunidades order by Abreviacao";
                string tstr = "tb_produtosunidades";
                FillComboUnidadeCompra(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'CARREGAR COMBOBOX UNIDADE ESTOCAGEM'
            try
            {
                string strSQL = "Select Abreviacao from tb_produtosunidades order by Abreviacao";
                string tstr = "tb_produtosunidades";
                FillComboUnidadeEstocagem(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #endregion

            #region 'PREENCHE AS CAIXAS'
            txt_estoque.Text = "0,000";
            txt_vlrcompra.Text = "0,00";
            txt_vlrvenda.Text = "0,00";
            #endregion

            #region 'ATIVAR/DESATIVAR CAIXAS'
            this.txt_id.Enabled = false;
            this.txt_datacadastro.Enabled = false;
            this.cbo_status.Enabled = true;
            this.txt_descricaoproduto.Enabled = true;
            this.cbo_tipoitem.Enabled = true;
            this.cbo_grupo.Enabled = true;
            this.cbo_familia.Enabled = true;
            this.txt_ean.Enabled = true;
            this.cbo_uncompra.Enabled = true;
            this.cbo_unestocagem.Enabled = true;
            this.txt_estoque.Enabled = false;
            this.txt_dataalteracao.Enabled = false;
            this.txt_vlrcompra.Enabled = true;
            this.txt_vlrvenda.Enabled = true;
            this.cbo_unvenda.Enabled = true;
            this.txt_obs.Enabled = true;
            #endregion

            #region 'COLOCA O FOCO'
            //POSICIONA DENTRO DA CAIXA
            cbo_status.Focus();
            #endregion

            #region 'ATIVAR/DESATIVAR BOTÕES'
            this.btNovo.Enabled = false;
            this.btGravar.Enabled = true;
            this.btAlterar.Enabled = false;
            this.btEditar.Enabled = false;
            this.btCancelar.Enabled = true;
            this.btConsultar.Enabled = false;
            this.btRelatorio.Enabled = false;
            this.btFechar.Enabled = false;
            this.btn_estoqueajuste.Enabled = false;
            this.btnCerrar.Enabled = false;
            #endregion
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            #region 'COMEÇA A GRAVAÇÃO'
            try
            {
                #region 'VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR'
                if (cbo_status.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Status para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_status.Focus();
                    return;
                }
                if (txt_descricaoproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Descrição Produto para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_descricaoproduto.Focus();
                    return;
                }
                if (cbo_tipoitem.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Tipo Item para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_tipoitem.Focus();
                    return;
                }
                if (cbo_grupo.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Grupo para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_grupo.Focus();
                    return;
                }
                if (cbo_familia.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Família para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_familia.Focus();
                    return;
                }
                if (txt_ean.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo EAN para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_ean.Focus();
                    return;
                }
                if (cbo_uncompra.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo UN.Compra para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_uncompra.Focus();
                    return;
                }
                if (cbo_unestocagem.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo UN.Estocagem para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_unestocagem.Focus();
                    return;
                }
                if (txt_vlrcompra.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Valor Compra para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_vlrcompra.Focus();
                    return;
                }
                if (txt_vlrvenda.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Valor Venda para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_vlrvenda.Focus();
                    return;
                }
                if (cbo_unvenda.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo UN.Venda para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_unvenda.Focus();
                    return;
                }
                #endregion

                #region 'FORMATAÇÃO DA DATA'
                string DataCadastroUS = FormatadataUS(txt_datacadastro.Text);
                string DataAlteracaoUS = FormatadataUS(txt_dataalteracao.Text);
                #endregion

                #region 'CONDIÇÃO PARA GRAVAR'
                if (txt_estoque.Text == "")
                {
                    txt_estoque.Text = "0,000";
                }
                #endregion

                #region 'COMANDO PARA GRAVAR'
                //Começa o comando para gravar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "Insert Into tb_produtos(DataCadastro,Status,DescricaoProduto,TipoItem," +
                    "Grupo,Familia,EAN,UNCompra,UNEstocagem,Estoque,DataAlteracao,VlrCompra,VlrVenda,UnVenda,Observacoes) Values";
                cmd.CommandText += "('" + DataCadastroUS + "','" + cbo_status.Text + "','" + txt_descricaoproduto.Text + "'," +
                    "'" + cbo_tipoitem.Text + "','" + cbo_grupo.Text + "','" + cbo_familia.Text + "','" + txt_ean.Text + "'," +
                    "'" + cbo_uncompra.Text + "','" + cbo_unestocagem.Text + "','" + txt_estoque.Text + "','" + DataAlteracaoUS + "'," +
                    "'" + txt_vlrcompra.Text + "','" + txt_vlrvenda.Text + "','" + cbo_unvenda.Text + "','" + txt_obs.Text + "')";
                cmd.ExecuteNonQuery();
                cmd.Connection.Close(); //Fecha a conexão
                #endregion

                #region 'MENSAGEM'
                MessageBox.Show("Produto Cadastrado com Sucesso!!!");
                #endregion

                #region 'EXECUTA O BOTÃO'
                btCancelar.PerformClick();
                #endregion

                #region 'COLOCA O FOCO'
                //POSICIONA O MOUSE
                btNovo.Focus();
                #endregion
            }
            catch (Exception erro)
            {
                #region 'MENSAGEM'
                MessageBox.Show(erro.Message);
                #endregion
            }
            #endregion

            #region 'COLOCA O FOCO'
            //POSICIONA O MOUSE
            btNovo.Focus();
            #endregion
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            #region 'COMEÇA A ALTERAÇÃO
            try
            {
                #region 'VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR'
                if (cbo_status.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Status para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_status.Focus();
                    return;
                }
                if (txt_descricaoproduto.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Descrição Produto para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_descricaoproduto.Focus();
                    return;
                }
                if (cbo_tipoitem.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Tipo Item para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_tipoitem.Focus();
                    return;
                }
                if (cbo_grupo.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Grupo para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_grupo.Focus();
                    return;
                }
                if (cbo_familia.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Família para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_familia.Focus();
                    return;
                }
                if (txt_ean.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo EAN para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_ean.Focus();
                    return;
                }
                if (cbo_uncompra.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo UN.Compra para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_uncompra.Focus();
                    return;
                }
                if (cbo_unestocagem.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo UN.Estocagem para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_unestocagem.Focus();
                    return;
                }
                if (txt_vlrcompra.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Valor Compra para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_vlrcompra.Focus();
                    return;
                }
                if (txt_vlrvenda.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Valor Venda para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_vlrvenda.Focus();
                    return;
                }
                if (cbo_unvenda.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo UN.Venda para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_unvenda.Focus();
                    return;
                }
                #endregion

                #region 'FORMATAÇÃO DA DATA'
                string DataCadastroUS = FormatadataUS(txt_datacadastro.Text);
                string DataAlteracaoUS = FormatadataUS(txt_dataalteracao.Text);
                #endregion

                #region 'COMANDO PARA GRAVAR'
                //Começa o comando para gravar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "update tb_produtos set " +
                    "DataCadastro ='" + DataCadastroUS + "' ,Status = '" + cbo_status.Text + "' ," +
                    "DescricaoProduto = '" + txt_descricaoproduto.Text + "' ,TipoItem = '" + cbo_tipoitem.Text + "' ," +
                    "Grupo = '" + cbo_grupo.Text + "' ,Familia = '" + cbo_familia.Text + "' ,EAN = '" + txt_ean.Text + "' ," +
                    "UNCompra = '" + cbo_uncompra.Text + "' ,UNEstocagem = '" + cbo_unestocagem.Text + "' ," +
                    "Estoque = '" + txt_estoque.Text + "' ,DataAlteracao = '" + DataAlteracaoUS + "' ," +
                    "VlrCompra = '" + txt_vlrcompra.Text + "' ,VlrVenda = '" + txt_vlrvenda.Text + "' ," +
                    "UnVenda = '" + cbo_unvenda.Text + "' ,Observacoes = '" + txt_obs.Text + "' Where ID = " + txt_id.Text + "";
                cmd.ExecuteNonQuery();
                cmd.Connection.Close(); //Fecha a conexão
                #endregion

                #region 'MENSAGEM'
                MessageBox.Show("Produto Alterado com Sucesso!!!");
                #endregion

                #region 'EXECUTA O BOTÃO'
                btCancelar.PerformClick();
                #endregion

                #region 'COLOCA O FOCO'
                //POSICIONA O MOUSE
                btNovo.Focus();
                #endregion
            }
            catch (Exception erro)
            {
                #region 'MENSAGEM'
                MessageBox.Show(erro.Message);
                #endregion
            }
            #endregion

            #region 'COLOCA O FOCO'
            //POSICIONA O MOUSE
            btNovo.Focus();
            #endregion
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            #region 'LIMPA AS CAIXAS'
            this.txt_dataalteracao.Text = "";
            #endregion

            #region 'PREENCHENDO A CAIXA DATA COM DADOS ATUAIS'
            //CAPTURAR DATA
            string DateTime = System.DateTime.Now.ToShortDateString();
            //PREENCHENDO AS CAIXAS            
            txt_dataalteracao.Text = (DateTime);
            #endregion

            #region CARREGA AS COMBOBOX'

            #region 'CARREGAR COMBOBOX GRUPO'
            try
            {
                string strSQL = "Select DescricaoGrupos from tb_produtosgrupos order by DescricaoGrupos";
                string tstr = "tb_produtosgrupos";
                FillComboGrupo(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'CARREGAR COMBOBOX FAMILIA'
            try
            {
                string strSQL = "Select DescricaoFamilia from tb_produtosfamilias order by DescricaoFamilia";
                string tstr = "tb_produtosfamilias";
                FillComboFamilia(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'CARREGAR COMBOBOX UNIDADE COMPRA'
            try
            {
                string strSQL = "Select Abreviacao from tb_produtosunidades order by Abreviacao";
                string tstr = "tb_produtosunidades";
                FillComboUnidadeCompra(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'CARREGAR COMBOBOX UNIDADE ESTOCAGEM'
            try
            {
                string strSQL = "Select Abreviacao from tb_produtosunidades order by Abreviacao";
                string tstr = "tb_produtosunidades";
                FillComboUnidadeEstocagem(strSQL, tstr);
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #endregion

            #region 'ATIVAR/DESATIVAR CAIXAS'
            this.txt_id.Enabled = false;
            this.txt_datacadastro.Enabled = false;
            this.cbo_status.Enabled = true;
            this.txt_descricaoproduto.Enabled = true;
            this.cbo_tipoitem.Enabled = true;
            this.cbo_grupo.Enabled = true;
            this.cbo_familia.Enabled = true;
            this.txt_ean.Enabled = true;
            this.cbo_uncompra.Enabled = true;
            this.cbo_unestocagem.Enabled = true;
            this.txt_estoque.Enabled = false;
            this.txt_dataalteracao.Enabled = false;
            this.txt_vlrcompra.Enabled = true;
            this.txt_vlrvenda.Enabled = true;
            this.cbo_unvenda.Enabled = true;
            this.txt_obs.Enabled = true;
            #endregion

            #region 'ATIVAR/DESATIVAR BOTÕES'
            this.btNovo.Enabled = false;
            this.btGravar.Enabled = false;
            this.btAlterar.Enabled = true;
            this.btEditar.Enabled = false;
            this.btCancelar.Enabled = true;
            this.btConsultar.Enabled = false;
            this.btRelatorio.Enabled = false;
            this.btFechar.Enabled = false;
            this.btn_estoqueajuste.Enabled = true;
            this.btnCerrar.Enabled = false;
            #endregion
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            #region 'LIMPA AS CAIXAS'
            this.txt_id.Text = "";
            this.txt_datacadastro.Text = "";
            this.cbo_status.Text = "";
            this.txt_descricaoproduto.Text = "";
            this.cbo_tipoitem.Text = "";
            this.cbo_grupo.Text = "";
            this.cbo_familia.Text = "";
            this.txt_ean.Text = "";
            this.cbo_uncompra.Text = "";
            this.cbo_unestocagem.Text = "";
            this.txt_estoque.Text = "";
            this.txt_dataalteracao.Text = "";
            this.txt_vlrcompra.Text = "";
            this.txt_vlrvenda.Text = "";
            this.txt_obs.Text = "";
            #endregion

            #region 'ATIVAR/DESATIVAR CAIXAS'
            this.txt_id.Enabled = false;
            this.txt_datacadastro.Enabled = false;
            this.cbo_status.Enabled = false;
            this.txt_descricaoproduto.Enabled = false;
            this.cbo_tipoitem.Enabled = false;
            this.cbo_grupo.Enabled = false;
            this.cbo_familia.Enabled = false;
            this.txt_ean.Enabled = false;
            this.cbo_uncompra.Enabled = false;
            this.cbo_unestocagem.Enabled = false;
            this.txt_estoque.Enabled = false;
            this.txt_dataalteracao.Enabled = false;
            this.txt_vlrcompra.Enabled = false;
            this.txt_vlrvenda.Enabled = false;
            this.cbo_unvenda.Enabled = false;
            this.txt_obs.Enabled = false;
            #endregion

            #region 'ATIVAR/DESATIVAR BOTÕES'
            this.btNovo.Enabled = true;
            this.btGravar.Enabled = false;
            this.btAlterar.Enabled = false;
            this.btCancelar.Enabled = false;
            this.btEditar.Enabled = false;
            this.btConsultar.Enabled = true;
            this.btRelatorio.Enabled = true;
            this.btFechar.Enabled = true;
            this.btn_estoqueajuste.Enabled = false;
            this.btnCerrar.Enabled = true;
            #endregion

            #region 'COLOCA O FOCO'
            //POSICIONA O MOUSE
            btNovo.Focus();
            #endregion
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            #region "ABRINDO NOVA TELA"
            this.Hide();
            FrmProdutosConsulta frm = new FrmProdutosConsulta();
            frm.ShowDialog();
            #endregion            
        }

        private void btRelatorio_Click(object sender, EventArgs e)
        {
            #region "ABRINDO NOVA TELA"
            this.Hide();
            FrmProdutosRelatorio frm = new FrmProdutosRelatorio();
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

        private void btn_estoqueajuste_Click(object sender, EventArgs e)
        {
            #region 'LIBERAR AJUSTE DE ESTOQUE'
            //LIBERA O AJUSTE DE ESTOQUE
            DialogResult dlgResult = MessageBox.Show("Deseja Ajustar Estoque ?", "Ajustar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                this.txt_estoque.Enabled = true;
            }
            #endregion
        }

        private void img_novogrupo_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btCancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmProdutosGrupos frm = new FrmProdutosGrupos();
            frm.ShowDialog();
            #endregion            
        }

        private void img_novafamilia_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btCancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmProdutosFamilias frm = new FrmProdutosFamilias();
            frm.ShowDialog();
            #endregion            
        }

        private void img_novaunidadecompra_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btCancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmProdutosUnidades frm = new FrmProdutosUnidades();
            frm.ShowDialog();
            #endregion            
        }

        private void img_novaunidadeestocagem_Click(object sender, EventArgs e)
        {
            #region "APLICANDO AÇÕES DE BOTÕES"
            //EXECUTA O BOTÃO LIMPAR
            btCancelar.PerformClick();
            #endregion

            #region "ABRINDO NOVO FORM"
            this.Hide();
            FrmProdutosUnidades frm = new FrmProdutosUnidades();
            frm.ShowDialog();
            #endregion            
        }

        private void cbo_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_tipoitem_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_grupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_familia_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_uncompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_unestocagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_unvenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void txt_estoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'CONDIÇÃO PARA FORMATAR'
            if (cbo_unvenda.Text == "UN")
            {
                #region 'ACEITA APENAS NÚMEROS'
                //Aceita apenas números, tecla backspace.
                if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
                {
                    e.Handled = true;
                }
                #endregion
            }
            else if (cbo_unvenda.Text == "KG" || cbo_unvenda.Text == "MT")
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

        private void txt_vlrcompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_vlrvenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_vlrcompra_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_vlrcompra);
            txt_vlrcompra.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txt_vlrvenda_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_vlrvenda);
            txt_vlrvenda.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txt_estoque_Leave(object sender, EventArgs e)
        {
            #region "CONDIÇÃO PARA VERIFICAR CAIXAS"
            if (txt_descricaoproduto.Text != "")
            {
                //Converte para três casas decimais
                txt_estoque.Text = string.Format("{0:N3}", Convert.ToDecimal(txt_estoque.Text));
            }
            else
            {
                txt_estoque.Text = "0,000";
            }
            #endregion
        }
    }
}
