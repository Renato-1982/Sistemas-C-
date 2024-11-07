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
    public partial class FrmProdutosConsulta : Form
    {
        public FrmProdutosConsulta()
        {
            InitializeComponent();
        }

        #region "PREENCHE DATAGRID"
        //preecnher dados no listview
        public void preencheListView(string strSql, string tstr)
        {
            #region 'PREENCHE LISTVIEW'
            lvw_produtos.Items.Clear();
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
                    lvw_produtos.Items.Add(lvitem);
                }
                lb_totalregistros.Text = lvw_produtos.Items.Count.ToString();
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

        private void FrmProdutosConsulta_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmProdutosConsulta_Load(object sender, EventArgs e)
        {
            #region 'CARREGAR COMBOBOX'
            this.cbo_procurar.Items.Add("ID");
            this.cbo_procurar.Items.Add("Status");
            this.cbo_procurar.Items.Add("DescricaoProduto");
            this.cbo_procurar.Items.Add("TipoItem");
            this.cbo_procurar.Items.Add("Grupo");
            this.cbo_procurar.Items.Add("Familia");
            this.cbo_procurar.Items.Add("EAN");
            #endregion

            #region 'PREENCHE O LISTVIEW'
            //preenche o ListView com os dados no evento Load
            //chamando a função preencheListView e PreencheTexto que definimos anteriormente
            //desabilita(false);
            try
            {
                string strSQL = "Select * from tb_produtos order by ID";
                string tstr = "tb_produtos";
                preencheListView(strSQL, tstr);
                //preencheTexto(strSQL, tstr);
                cbo_procurar.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'ATIVAR/DESATIVAR BOTÕES'
            this.btn_carregar.Enabled = false;
            #endregion

            #region 'LIMPAR CAIXAS'
            cbo_procurar.Text = "";
            txt_procurar.Text = "";
            #endregion

            #region 'COLOCA O FOCO'
            //POSICIONA DENTRO DA CAIXA
            cbo_procurar.Focus();
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
                string strSQL = "Select * from tb_produtos " + "where " + cbo_procurar.Text + " like'%" + txt_procurar.Text + "%'";
                string tstr = "tb_produtos";
                preencheListView(strSQL, tstr);
                //preencheTexto(strSQL, tstr, cbtext);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion
        }

        private void lvw_produtos_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 'ATIVAR/DESATIVAR BOTÕES'
            btn_carregar.Enabled = true;
            #endregion
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            #region 'LIMPA AS CAIXAS'
            cbo_procurar.Text = "";
            txt_procurar.Text = "";
            #endregion

            #region 'ATUALIZA INICIALIZANDO A TELA'
            FrmProdutosConsulta_Load(sender, e);
            #endregion

            #region 'ATIVAR/DESATIVAR BOTÕES'
            btn_carregar.Enabled = false;
            #endregion
        }

        private void btn_carregar_Click(object sender, EventArgs e)
        {            
            #region "ESTANCIA O NOVO FORMULÁRIO"
            //CÓDIGO PARA PREENCHER AS CAIXAS COM DADOS DO BANCO
            //PARA ISSO TEM QUE TORNAR AS CAIXAS DO FORMÚLARIO PÚBLICAS
            FrmProdutos frm = new FrmProdutos();
            #endregion

            #region 'CARREGA OS DADOS EM OUTRO FORMULÁRIO'
            //CONTINUAÇÃO DO CÓDIGO PARA PREENCHER AS CAIXAS
            frm.txt_id.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[0].Text);
            frm.txt_datacadastro.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[1].Text);
            frm.cbo_status.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[2].Text);
            frm.txt_descricaoproduto.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[3].Text);
            frm.cbo_tipoitem.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[4].Text);
            frm.cbo_grupo.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[5].Text);
            frm.cbo_familia.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[6].Text);
            frm.txt_ean.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[7].Text);
            frm.cbo_uncompra.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[8].Text);
            frm.cbo_unestocagem.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[9].Text);
            frm.txt_estoque.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[10].Text);
            frm.txt_dataalteracao.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[11].Text);
            frm.txt_vlrcompra.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[12].Text);
            frm.txt_vlrvenda.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[13].Text);
            frm.cbo_unvenda.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[14].Text);
            frm.txt_obs.Text = (lvw_produtos.Items[lvw_produtos.FocusedItem.Index].SubItems[15].Text);
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
                FrmProdutos frm = new FrmProdutos();
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
