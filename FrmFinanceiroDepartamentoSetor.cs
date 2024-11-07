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
    public partial class FrmFinanceiroDepartamentoSetor : Form
    {
        public FrmFinanceiroDepartamentoSetor()
        {
            InitializeComponent();
        }

        #region 'DECLARAÇÃO'
        Boolean estado = false;
        #endregion

        #region 'PREENCHE DATAGRID'
        //preecnher dados no listview
        public void preencheListView(string strSql, string tstr)
        {
            #region 'PREENCHE LISTVIEW'
            lvw_departamento.Items.Clear();
            //lvw_financeiro.Sorting = SortOrder.Ascending;
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
                    lvw_departamento.Items.Add(lvitem);
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
            #region 'PREENCHE TEXTO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd = new MySqlCommand(strSql);
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            MySqlDataReader datareader;
            datareader = cmd.ExecuteReader();

            datareader.Read();
            {
                txt_id.Text = datareader["ID"].ToString();
                txt_descricaodepartamento.Text = datareader["DescricaoDepartamentos"].ToString();
                txt_obs.Text = datareader["Observacoes"].ToString();
            }
            datareader.Close(); //Fecha o datareader
            cmd.Connection.Close(); //Fecha a conexão
            #endregion
        }
        private void desabilita(bool a)
        {
            #region 'DESABILITA'
            txt_id.Enabled = a;
            txt_descricaodepartamento.Enabled = a;
            txt_obs.Enabled = a;
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

        private void FrmFinanceiroDepartamentoSetor_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmFinanceiroDepartamentoSetor_Load(object sender, EventArgs e)
        {
            #region 'CARREGA AS COMBOBOX'
            //CARREGAR COMBOBOX PROCURAR
            this.cbo_procurar.Items.Clear();
            this.cbo_procurar.Items.Add("ID");
            this.cbo_procurar.Items.Add("DescricaoDepartamentos");
            this.cbo_procurar.Items.Add("Observacoes");
            #endregion

            #region 'ATIVA/DESATIVA OS BOTÕES'
            //DESATIVAR/ATIVAR BOTÕES
            this.btn_novo.Enabled = true;
            this.btn_gravar.Enabled = false;
            this.btn_cancelar.Enabled = false;
            this.btn_editar.Enabled = true;
            this.btn_alterar.Enabled = false;
            this.btn_fechar.Enabled = true;
            btnCerrar.Enabled = true;
            #endregion

            #region 'PREENCHE O LISTVIEW'
            //preenche o ListView com os dados no evento Load
            //chamando a função preencheListView e PreencheTexto que definimos anteriormente
            desabilita(false);
            try
            {
                string strSQL = "Select * from tb_financeirodepartamentosetores order by ID";
                string tstr = "tb_financeirodepartamentosetores";
                preencheListView(strSQL, tstr);
                preencheTexto(strSQL, tstr);
                cbo_procurar.SelectedIndex = 0;
                //DESABILITA AS CAIXAS
                this.txt_id.Enabled = false;
                this.txt_descricaodepartamento.Enabled = false;
                this.txt_obs.Enabled = false;
                this.cbo_procurar.Text = "";
                this.txt_procurar.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Banco de Dados Vazio!!!");
            }
            #endregion

            #region 'COLOCA O FOCO'
            //POSICIONA O FOCO
            btn_novo.Focus();
            #endregion
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            #region 'LIMPA AS CAIXAS'
            //LIMPAR CAIXAS
            this.txt_id.Text = "";
            this.txt_descricaodepartamento.Text = "";
            this.txt_obs.Text = "";
            this.cbo_procurar.Text = "";
            this.txt_procurar.Text = "";
            #endregion

            #region 'ATIVA/DESATIVA AS CAIXAS'
            //DESATIVAR CAIXAS
            this.txt_id.Enabled = false;
            this.txt_descricaodepartamento.Enabled = true;
            this.txt_obs.Enabled = true;
            this.cbo_procurar.Enabled = false;
            this.txt_procurar.Enabled = false;
            this.lvw_departamento.Enabled = false;
            #endregion

            #region 'ATIVA/DESATIVA OS BOTÕES'
            //DESATIVAR/ATIVAR BOTÕES
            this.btn_novo.Enabled = false;
            this.btn_gravar.Enabled = true;
            this.btn_cancelar.Enabled = true;
            this.btn_editar.Enabled = false;
            this.btn_alterar.Enabled = false;
            this.btn_fechar.Enabled = false;
            btnCerrar.Enabled = false;
            #endregion

            #region 'COLOCA O FOCO'
            //POSICIONA DENTRO DA CAIXA
            txt_descricaodepartamento.Focus();
            #endregion
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            #region 'COMEÇA A GRAVAÇÃO'
            try
            {
                #region 'VERIFICA SE AS CAIXAS ESTÃO PREENCHIDAS PARA GRAVAR'
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_descricaodepartamento.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Descrição para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_descricaodepartamento.Focus();
                    return;
                }
                #endregion

                #region 'COMANDO PARA GRAVAR'
                //Começa o comando para gravar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "Insert Into tb_financeirodepartamentosetores(DescricaoDepartamentos,Observacoes) Values";
                cmd.CommandText += "('" + txt_descricaodepartamento.Text + "','" + txt_obs.Text + "')";
                cmd.ExecuteNonQuery();
                cmd.Connection.Close(); //Fecha a conexão
                #endregion

                #region 'MENSAGEM'
                MessageBox.Show("Departamento Cadastrado com Sucesso!!!");
                #endregion

                #region 'EXECUTA O BOTÃO'
                //EXECUTA O BOTÃO LIMPAR
                btn_cancelar.PerformClick();
                #endregion
            }
            catch (Exception erro)
            {
                #region 'MENSAGEM'
                MessageBox.Show(erro.Message);
                #endregion
            }
            #endregion

            #region 'ATUALIZA INICIALIZANDO'
            //ATUALIZAR TELA COM INICIALIZAÇÃO
            FrmFinanceiroDepartamentoSetor_Load(sender, e);
            #endregion

            #region 'COLOCA O FOCO'
            //POSICIONA DENTRO DA CAIXA
            btn_novo.Focus();
            #endregion
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            #region 'COMEÇA A ALTERAÇÃO'
            try
            {
                #region 'VERIFICA SE AS CAIXAS ESTÃO PREENCHIDAS PARA GRAVAR'
                //VERIFICAR CAIXAS VAZIAS PARA NÃO ALTERAR
                if (txt_descricaodepartamento.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Descrição para continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_descricaodepartamento.Focus();
                    return;
                }
                #endregion

                #region 'COMANDO PARA GRAVAR'
                //Começa o comando para gravar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "update tb_financeirodepartamentosetores set DescricaoDepartamentos ='" + txt_descricaodepartamento.Text + "' ,Observacoes = '" + txt_obs.Text + "' Where ID = " + txt_id.Text + "";
                cmd.ExecuteNonQuery();
                cmd.Connection.Close(); //Fecha a conexão
                #endregion

                #region 'MENSAGEM DE EXECUÇÃO'
                MessageBox.Show("Dados Alterados com Sucesso!!!");
                #endregion

                #region 'EXECUTA O BOTÃO'
                btn_cancelar.PerformClick();
                #endregion
            }
            catch (Exception erro)
            {
                #region 'MENSAGEM'
                MessageBox.Show(erro.Message);
                #endregion
            }
            #endregion

            #region 'ATUALIZA INICIALIZANDO'
            //ATUALIZAR TELA COM INICIALIZAÇÃO
            FrmFinanceiroDepartamentoSetor_Load(sender, e);
            #endregion

            #region 'COLOCA O FOCO'
            //POSICIONA DENTRO DA CAIXA
            btn_novo.Focus();
            #endregion
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            #region 'LIMPA AS CAIXAS'
            //LIMPAR AS CAIXAS
            this.cbo_procurar.Text = "";
            this.txt_procurar.Text = "";
            #endregion

            #region 'ATIVA/DESATIVA AS CAIXAS'
            //DESATIVAR CAIXAS
            this.txt_id.Enabled = false;
            this.txt_descricaodepartamento.Enabled = true;
            this.txt_obs.Enabled = true;
            this.cbo_procurar.Enabled = false;
            this.txt_procurar.Enabled = false;
            this.lvw_departamento.Enabled = false;
            #endregion

            #region 'ATIVA/DESATIVA OS BOTÕES'
            //DESATIVAR/ATIVAR BOTÕES
            this.btn_novo.Enabled = false;
            this.btn_gravar.Enabled = false;
            this.btn_cancelar.Enabled = true;
            this.btn_editar.Enabled = false;
            this.btn_alterar.Enabled = true;
            this.btn_fechar.Enabled = false;
            btnCerrar.Enabled = false;

            estado = true;
            #endregion
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            #region 'LIMPA AS CAIXAS'
            //LIMPAR CAIXAS
            this.txt_id.Text = "";
            this.txt_descricaodepartamento.Text = "";
            this.txt_obs.Text = "";
            this.cbo_procurar.Text = "";
            this.txt_procurar.Text = "";
            #endregion

            #region 'ATIVA/DESATIVA AS CAIXAS'
            //DESATIVAR CAIXAS
            this.txt_id.Enabled = false;
            this.txt_descricaodepartamento.Enabled = false;
            this.txt_obs.Enabled = false;
            this.cbo_procurar.Enabled = true;
            this.txt_procurar.Enabled = true;
            this.lvw_departamento.Enabled = true;
            #endregion

            #region 'ATIVA/DESATIVA OS BOTÕES'
            //DESATIVAR/ATIVAR BOTÕES
            this.btn_novo.Enabled = true;
            this.btn_gravar.Enabled = false;
            this.btn_cancelar.Enabled = false;
            this.btn_editar.Enabled = true;
            this.btn_alterar.Enabled = false;
            this.btn_fechar.Enabled = true;
            btnCerrar.Enabled = true;
            #endregion

            #region 'PREENCHE O LISTVIEW'
            try
            {
                string str = "Select * from tb_financeirodepartamentosetores order by ID";
                string tstr = "tb_financeirodepartamentosetores";
                preencheListView(str, tstr);
                preencheTexto(str, tstr);
                cbo_procurar.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Operação Cancelada!!!");
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            this.cbo_procurar.Text = "";
            this.txt_procurar.Text = "";
            #endregion

            #region 'COLOCA O FOCO'
            //POSICIONA O FOCO
            btn_novo.Focus();
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

        private void txt_procurar_TextChanged(object sender, EventArgs e)
        {
            #region 'VERIFICA SE A COMBOBOX NÃO ESTÁ VAZIA'
            //VERIFICA SE A CAIXA ESTÁ VAZIA
            if (cbo_procurar.Text == string.Empty)
            {
                MessageBox.Show("Selecione um Registro na Caixa para Prosseguir!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbo_procurar.Focus();
                return;
            }
            #endregion

            #region 'PREENCHE O LISTVIEW'
            //PROCURA OS DADOS QUE VOCÊ PREENCHEU NO TEXTBOX E SELECIONOU NO CRITÉRIO DA COMBOBOX            
            try
            {
                //string cbtexto = cbo_procurar.Text;
                string strSQL = "Select * from tb_financeirodepartamentosetores " + "where " + cbo_procurar.Text + " like'%" + txt_procurar.Text + "%'";
                string tstr = "tb_financeirodepartamentosetores";
                preencheListView(strSQL, tstr);
                //preencheTexto(strSQL, tstr, cbtext);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            #endregion
        }

        private void lvw_departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 'CARREGA AS CAIXAS SELECIONANDO O LISTVIEW'
            //CARREGA AS CAIXAS
            txt_id.Text = (lvw_departamento.Items[lvw_departamento.FocusedItem.Index].SubItems[0].Text);
            txt_descricaodepartamento.Text = (lvw_departamento.Items[lvw_departamento.FocusedItem.Index].SubItems[1].Text);
            txt_obs.Text = (lvw_departamento.Items[lvw_departamento.FocusedItem.Index].SubItems[2].Text);
            #endregion

            #region 'LIMPA AS CAIXAS'
            //LIMPAR AS CAIXAS
            this.cbo_procurar.Text = "";
            this.txt_procurar.Text = "";
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
