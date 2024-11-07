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
    public partial class FrmCadastroMultiplos : Form
    {
        public FrmCadastroMultiplos()
        {
            InitializeComponent();
        }

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

        private void FrmCadastroMultiplos_KeyDown(object sender, KeyEventArgs e)
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

        private void tc_cadastro_DrawItem(object sender, DrawItemEventArgs e)
        {
            #region 'MUDA A COR DA GUIA AO CLICAR'
            //FORMATAÇÃO DA TABCONTROL'
            TabPage CurrentTab = tc_cadastro.TabPages[e.Index];
            Rectangle ItemRect = tc_cadastro.GetTabRect(e.Index);
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
            if (tc_cadastro.Alignment == TabAlignment.Left || tc_cadastro.Alignment == TabAlignment.Right)
            {
                float RotateAngle = 90;
                if (tc_cadastro.Alignment == TabAlignment.Left)
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

        private void FrmCadastroMultiplos_Load(object sender, EventArgs e)
        {
            #region 'PREENCHE AS COMBOBOX'
            //CARREGAR COMBOBOX STATUS            
            this.cbo_status.Items.Add("Ativo");
            this.cbo_status.Items.Add("Inativo");
            //CARREGAR COMBOBOX TIPO CADASTRO            
            this.cbo_tipocadastro.Items.Add("Cliente");
            this.cbo_tipocadastro.Items.Add("Colaborador");
            this.cbo_tipocadastro.Items.Add("Fornecedor");
            //CARREGAR COMBOBOX TIPO PESSOA            
            this.cbo_tipopessoa.Items.Add("Pessoa Física");
            this.cbo_tipopessoa.Items.Add("Pessoa Jurídica");
            //CARREGAR COMBOBOX ESTADO CIVIL           
            this.cbo_estadocivil.Items.Add("Casado(a)");
            this.cbo_estadocivil.Items.Add("Divorciado(a)");
            this.cbo_estadocivil.Items.Add("Solteiro(a)");
            this.cbo_estadocivil.Items.Add("União Estável");
            this.cbo_estadocivil.Items.Add("Viúvo(a)");
            //CARREGAR COMBOBOX GRAU DE INSTRUÇÃO         
            this.cbo_grauinstrucao.Items.Add("Ens.Fundamental Completo)");
            this.cbo_grauinstrucao.Items.Add("Ens.Fundamental Incompleto");
            this.cbo_grauinstrucao.Items.Add("Ens.Médio Completo");
            this.cbo_grauinstrucao.Items.Add("Ens.Médio Incompleto");
            this.cbo_grauinstrucao.Items.Add("Ens.Superior Completo");
            this.cbo_grauinstrucao.Items.Add("Ens.Superior Incompleto");
            //CARREGAR COMBOBOX VALE TRANSPORTE            
            this.cbo_valetransporte.Items.Add("Sim");
            this.cbo_valetransporte.Items.Add("Não");
            //CARREGAR COMBOBOX TIPO ADMISSÃO            
            this.cbo_tipoadmissao.Items.Add("Emprego");
            this.cbo_tipoadmissao.Items.Add("Reemprego");
            //CARREGAR COMBOBOX TIPO LOGRADOURO            
            this.cbo_tipologradouro.Items.Add("Avenida");
            this.cbo_tipologradouro.Items.Add("Rodovia");
            this.cbo_tipologradouro.Items.Add("Rua");
            this.cbo_tipologradouro.Items.Add("Travessia");
            this.cbo_tipologradouro.Items.Add("Zona Rural");
            //CARREGAR COMBOBOX ESTADO            
            this.cbo_estado.Items.Add("AC");
            this.cbo_estado.Items.Add("AL");
            this.cbo_estado.Items.Add("AP");
            this.cbo_estado.Items.Add("AM");
            this.cbo_estado.Items.Add("BA");
            this.cbo_estado.Items.Add("CE");
            this.cbo_estado.Items.Add("DF");
            this.cbo_estado.Items.Add("ES");
            this.cbo_estado.Items.Add("GO");
            this.cbo_estado.Items.Add("MA");
            this.cbo_estado.Items.Add("MT");
            this.cbo_estado.Items.Add("MS");
            this.cbo_estado.Items.Add("MG");
            this.cbo_estado.Items.Add("PA");
            this.cbo_estado.Items.Add("PB");
            this.cbo_estado.Items.Add("PR");
            this.cbo_estado.Items.Add("PE");
            this.cbo_estado.Items.Add("PI");
            this.cbo_estado.Items.Add("RJ");
            this.cbo_estado.Items.Add("RN");
            this.cbo_estado.Items.Add("RS");
            this.cbo_estado.Items.Add("RO");
            this.cbo_estado.Items.Add("RR");
            this.cbo_estado.Items.Add("SC");
            this.cbo_estado.Items.Add("SP");
            this.cbo_estado.Items.Add("SE");
            this.cbo_estado.Items.Add("TO");
            #endregion

            #region 'DESATIVAR CAIXAS'
            //CABEÇALHO
            this.txt_id.Enabled = false;
            this.txt_datacadastro.Enabled = false;
            this.cbo_status.Enabled = false;
            this.cbo_tipocadastro.Enabled = false;
            this.cbo_tipopessoa.Enabled = false;
            //DADOS PRINCIPAIS
            this.txt_nomerazao.Enabled = false;
            this.txt_nomefantasia.Enabled = false;
            this.txt_mskdataabertura.Enabled = false;
            this.txt_mskcnpj.Enabled = false;
            this.txt_inscricaoestadual.Enabled = false;
            this.txt_inscricaomunicipal.Enabled = false;
            this.txt_mskdatanascimento.Enabled = false;
            this.txt_mskcpf.Enabled = false;
            this.txt_rg.Enabled = false;
            this.txt_mskdataexprg.Enabled = false;
            this.txt_nacionalidade.Enabled = false;
            this.txt_naturalidade.Enabled = false;
            this.cbo_estadocivil.Enabled = false;
            //DADOS SECUNDÁRIOS
            this.cbo_grauinstrucao.Enabled = false;
            this.txt_ctps.Enabled = false;
            this.txt_seriectps.Enabled = false;
            this.txt_mskdataexpctps.Enabled = false;
            this.txt_pispasep.Enabled = false;
            this.txt_tituloeleitor.Enabled = false;
            this.txt_titulozona.Enabled = false;
            this.txt_titulosecao.Enabled = false;
            this.cbo_valetransporte.Enabled = false;
            this.cbo_tipoadmissao.Enabled = false;
            this.txt_funcao.Enabled = false;
            this.txt_salarioregistrado.Enabled = false;
            this.txt_salariototal.Enabled = false;
            this.txt_nomemae.Enabled = false;
            this.txt_nomepai.Enabled = false;
            this.txt_narmario.Enabled = false;
            this.txt_mskdatacomecou.Enabled = false;
            this.txt_mskdataadmissao.Enabled = false;
            this.txt_mskdatademissao.Enabled = false;
            //ENDEREÇO|CONTATO
            this.txt_mskcep.Enabled = false;
            this.cbo_tipologradouro.Enabled = false;
            this.txt_endereco.Enabled = false;
            this.txt_numero.Enabled = false;
            this.txt_complemento.Enabled = false;
            this.txt_bairro.Enabled = false;
            this.txt_cidade.Enabled = false;
            this.cbo_estado.Enabled = false;
            this.txt_msktelfixo.Enabled = false;
            this.txt_msktelfixocomercial.Enabled = false;
            this.txt_msktelcelular1.Enabled = false;
            this.txt_msktelcelular2.Enabled = false;
            this.txt_email.Enabled = false;
            this.txt_contato.Enabled = false;
            this.txt_obs.Enabled = false;
            #endregion

            #region 'VERIFICA SE O ID ESTA PREENCHIDO'
            if (txt_id.Text != "")
            {
                #region 'ATIVAR|DESATIVAR BOTÕES'
                this.btNovo.Enabled = false;
                this.btGravar.Enabled = false;
                this.btAlterar.Enabled = false;
                this.btEditar.Enabled = true;
                this.btCancelar.Enabled = true;
                this.btConsultar.Enabled = false;
                this.btRelatorio.Enabled = false;
                this.btFechar.Enabled = false;
                btnCerrar.Enabled = false;
                #endregion

                #region 'COLOCA O FOCO'
                btEditar.Focus();
                #endregion
            }
            else
            {
                #region 'ATIVAR|DESATIVAR BOTÕES'
                this.btNovo.Enabled = true;
                this.btGravar.Enabled = false;
                this.btAlterar.Enabled = false;
                this.btEditar.Enabled = false;
                this.btCancelar.Enabled = false;
                this.btConsultar.Enabled = true;
                this.btRelatorio.Enabled = true;
                this.btFechar.Enabled = true;
                btnCerrar.Enabled = true;
                #endregion

                #region 'COLOCA O FOCO'
                btNovo.Focus();
                #endregion
            }
            #endregion

            #region 'COLOCA O FOCO'
            btNovo.Focus();
            #endregion
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            #region 'PEGA A DATA ATUAL'
            //CAPTURAR DATA
            string DateTime = System.DateTime.Now.ToShortDateString();
            //PREENCHENDO AS CAIXAS
            txt_datacadastro.Text = (DateTime);
            #endregion

            #region 'LIMPAR CAIXAS'
            //CABEÇALHO
            this.txt_id.Text = "";
            //this.txt_datacadastro.Text = "";
            this.cbo_status.Text = "";
            this.cbo_tipocadastro.Text = "";
            this.cbo_tipopessoa.Text = "";
            //DADOS PRINCIPAIS
            this.txt_nomerazao.Text = "";
            this.txt_nomefantasia.Text = "";
            this.txt_mskdataabertura.Text = "";
            this.txt_mskcnpj.Text = "";
            this.txt_inscricaoestadual.Text = "";
            this.txt_inscricaomunicipal.Text = "";
            this.txt_mskdatanascimento.Text = "";
            this.txt_mskcpf.Text = "";
            this.txt_rg.Text = "";
            this.txt_mskdataexprg.Text = "";
            this.txt_nacionalidade.Text = "";
            this.txt_naturalidade.Text = "";
            this.cbo_estadocivil.Text = "";
            //DADOS SECUNDÁRIOS
            this.cbo_grauinstrucao.Text = "";
            this.txt_ctps.Text = "";
            this.txt_seriectps.Text = "";
            this.txt_mskdataexpctps.Text = "";
            this.txt_pispasep.Text = "";
            this.txt_tituloeleitor.Text = "";
            this.txt_titulozona.Text = "";
            this.txt_titulosecao.Text = "";
            this.cbo_valetransporte.Text = "";
            this.cbo_tipoadmissao.Text = "";
            this.txt_funcao.Text = "";
            this.txt_salarioregistrado.Text = "";
            this.txt_salariototal.Text = "";
            this.txt_nomemae.Text = "";
            this.txt_nomepai.Text = "";
            this.txt_narmario.Text = "";
            this.txt_mskdatacomecou.Text = "";
            this.txt_mskdataadmissao.Text = "";
            this.txt_mskdatademissao.Text = "";
            //ENDEREÇO|CONTATO
            this.txt_mskcep.Text = "";
            this.cbo_tipologradouro.Text = "";
            this.txt_endereco.Text = "";
            this.txt_numero.Text = "";
            this.txt_complemento.Text = "";
            this.txt_bairro.Text = "";
            this.txt_cidade.Text = "";
            this.cbo_estado.Text = "";
            this.txt_msktelfixo.Text = "";
            this.txt_msktelfixocomercial.Text = "";
            this.txt_msktelcelular1.Text = "";
            this.txt_msktelcelular2.Text = "";
            this.txt_email.Text = "";
            this.txt_contato.Text = "";
            this.txt_obs.Text = "";
            #endregion

            #region 'ATIVAR|DESATIVAR CAIXAS'
            //CABEÇALHO
            this.txt_id.Enabled = false;
            this.txt_datacadastro.Enabled = false;
            this.cbo_status.Enabled = true;
            this.cbo_tipocadastro.Enabled = true;
            this.cbo_tipopessoa.Enabled = true;
            //DADOS PRINCIPAIS
            this.txt_nomerazao.Enabled = true;
            this.txt_nomefantasia.Enabled = true;
            this.txt_mskdataabertura.Enabled = true;
            this.txt_mskcnpj.Enabled = true;
            this.txt_inscricaoestadual.Enabled = true;
            this.txt_inscricaomunicipal.Enabled = true;
            this.txt_mskdatanascimento.Enabled = true;
            this.txt_mskcpf.Enabled = true;
            this.txt_rg.Enabled = true;
            this.txt_mskdataexprg.Enabled = true;
            this.txt_nacionalidade.Enabled = true;
            this.txt_naturalidade.Enabled = true;
            this.cbo_estadocivil.Enabled = true;
            //DADOS SECUNDÁRIOS
            this.cbo_grauinstrucao.Enabled = true;
            this.txt_ctps.Enabled = true;
            this.txt_seriectps.Enabled = true;
            this.txt_mskdataexpctps.Enabled = true;
            this.txt_pispasep.Enabled = true;
            this.txt_tituloeleitor.Enabled = true;
            this.txt_titulozona.Enabled = true;
            this.txt_titulosecao.Enabled = true;
            this.cbo_valetransporte.Enabled = true;
            this.cbo_tipoadmissao.Enabled = true;
            this.txt_funcao.Enabled = true;
            this.txt_salarioregistrado.Enabled = true;
            this.txt_salariototal.Enabled = true;
            this.txt_nomemae.Enabled = true;
            this.txt_nomepai.Enabled = true;
            this.txt_narmario.Enabled = true;
            this.txt_mskdatacomecou.Enabled = true;
            this.txt_mskdataadmissao.Enabled = true;
            this.txt_mskdatademissao.Enabled = true;
            //ENDEREÇO|CONTATO
            this.txt_mskcep.Enabled = true;
            this.cbo_tipologradouro.Enabled = true;
            this.txt_endereco.Enabled = false;
            this.txt_numero.Enabled = true;
            this.txt_complemento.Enabled = true;
            this.txt_bairro.Enabled = false;
            this.txt_cidade.Enabled = false;
            this.cbo_estado.Enabled = false;
            this.txt_msktelfixo.Enabled = true;
            this.txt_msktelfixocomercial.Enabled = true;
            this.txt_msktelcelular1.Enabled = true;
            this.txt_msktelcelular2.Enabled = true;
            this.txt_email.Enabled = true;
            this.txt_contato.Enabled = true;
            this.txt_obs.Enabled = true;
            #endregion

            #region 'ATIVAR|DESATIVAR BOTÕES'
            this.btNovo.Enabled = false;
            this.btGravar.Enabled = true;
            this.btAlterar.Enabled = false;
            this.btEditar.Enabled = false;
            this.btCancelar.Enabled = true;
            this.btConsultar.Enabled = false;
            this.btRelatorio.Enabled = false;
            this.btFechar.Enabled = false;
            btnCerrar.Enabled = false;
            #endregion

            #region 'COLOCA O FOCO'
            cbo_status.Focus();
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
                if (cbo_status.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo status para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_status.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_tipocadastro.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tipo cadastro para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_tipocadastro.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_tipopessoa.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tipo pessoa para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_tipopessoa.Focus();
                    return;
                }
                #endregion

                #region 'DADOS PRINCIPAIS'
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_nomerazao.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nome/razão para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_nomerazao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_nomefantasia.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nome fantasia/apelido para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_nomefantasia.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdataabertura.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data abertura para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdataabertura.Text = "";
                    this.txt_mskdataabertura.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskcnpj.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo CNPJ para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskcnpj.Text = "";
                    this.txt_mskcnpj.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_inscricaoestadual.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo inscrição estadual para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_inscricaoestadual.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_inscricaomunicipal.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo inscrição municipal para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_inscricaomunicipal.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdatanascimento.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data nascimento para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdatanascimento.Text = "";
                    this.txt_mskdatanascimento.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskcpf.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo CPF para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskcpf.Text = "";
                    this.txt_mskcpf.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_rg.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo RG para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_rg.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdataexprg.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data expedição RG para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdataexprg.Text = "";
                    this.txt_mskdataexprg.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_nacionalidade.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nacionalidade para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_nacionalidade.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_naturalidade.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo naturalidade para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_naturalidade.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_estadocivil.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo estado civil para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_estadocivil.Focus();
                    return;
                }
                #endregion

                #region 'DADOS SECUNDÁRIOS'
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_grauinstrucao.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo grau de instrução para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_grauinstrucao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_ctps.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo CTPS Nº para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_ctps.Text = "";
                    this.txt_ctps.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_seriectps.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo CTPS série para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_seriectps.Text = "";
                    this.txt_seriectps.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdataexpctps.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data expedição CTPS para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdataexpctps.Text = "";
                    this.txt_mskdataexpctps.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_pispasep.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo PIS|PASEP para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_pispasep.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_tituloeleitor.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo título eleitor para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_tituloeleitor.Text = "";
                    this.txt_tituloeleitor.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_titulozona.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo título zona para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_titulozona.Text = "";
                    this.txt_titulozona.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_titulosecao.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo título seção para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_titulosecao.Text = "";
                    this.txt_titulosecao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_valetransporte.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo vale transporte para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_valetransporte.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_tipoadmissao.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tipo admissão para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_tipoadmissao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_funcao.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo função para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_funcao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_salarioregistrado.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo salário registrado para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_salarioregistrado.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_salariototal.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo salário total para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_salariototal.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_nomemae.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nome mãe para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_nomemae.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_nomepai.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nome pai para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_nomepai.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_narmario.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Nº armário para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_narmario.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdatacomecou.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data começou para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdatacomecou.Text = "";
                    this.txt_mskdatacomecou.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdataadmissao.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data admissão para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdataadmissao.Text = "";
                    this.txt_mskdataadmissao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdatademissao.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data demissão para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdatademissao.Text = "";
                    this.txt_mskdatademissao.Focus();
                    return;
                }
                #endregion

                #region 'ENDEREÇO CONTATO'
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskcep.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo CEP para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskcep.Text = "";
                    this.txt_mskcep.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_tipologradouro.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tipo logradouro para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_tipologradouro.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_endereco.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo endereço para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_endereco.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_numero.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo número para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_numero.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_complemento.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo complemento para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_complemento.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_bairro.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo bairro para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_bairro.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_cidade.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo cidade para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_cidade.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_estado.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo estado para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_estado.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_msktelfixo.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo telefone fixo para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_msktelfixo.Text = "";
                    this.txt_msktelfixo.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_msktelfixocomercial.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo telefone fixo comercial para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_msktelfixocomercial.Text = "";
                    this.txt_msktelfixocomercial.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_msktelcelular1.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo telefone celular 1 para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_msktelcelular1.Text = "";
                    this.txt_msktelcelular1.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_msktelcelular2.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo telefone celular 2 para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_msktelcelular2.Text = "";
                    this.txt_msktelcelular2.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_email.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo email para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_email.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_contato.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo contato para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_contato.Focus();
                    return;
                }
                #endregion

                #endregion

                #region 'FORMATAÇÃO DA DATA'
                string DataCadastroUS = FormatadataUS(txt_datacadastro.Text);
                string DataAberturaUS = FormatadataUS(txt_mskdataabertura.Text);
                string DataNascimentoUS = FormatadataUS(txt_mskdatanascimento.Text);
                string DataExpedicaoRgUS = FormatadataUS(txt_mskdataexprg.Text);
                string DataExpedicaoCtpsUS = FormatadataUS(txt_mskdataexpctps.Text);
                string DataComecouUS = FormatadataUS(txt_mskdatacomecou.Text);
                string DataAdmissaoUS = FormatadataUS(txt_mskdataadmissao.Text);
                string DataDemissaoUS = FormatadataUS(txt_mskdatademissao.Text);
                #endregion

                #region "COMANDO PARA GRAVAR"
                //Começa o comando para gravar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "Insert Into tb_cadastromultiplo(DataSistema,Status,TipoCadastro,TipoPessoa," +
                    "NomeRazaoSocial,NomeFantasiaApelido,DataAbertura,Cnpj,InscricaoEstadual,InscricaoMunicipal," +
                    "DataNascimento,Cpf,Rg,DataExpedicaoRG,Nacionalidade,Naturalidade,EstadoCivil,GrauInstrucao," +
                    "CtpsNumero,CtpsSerie,DataExpedicaoCtps,PisPasep,TituloNumero,TituloZona,TituloSecao,ValeTransporte," +
                    "TipoAdmissao,Funcao,SalarioRegistrado,SalarioTotal,NomeMae,NomePai,ArmarioNumero,DataComecou," +
                    "DataAdmissao,DataDemissao,Cep,TipoLogradouro,Endereco,Numero,Complemento,Bairro,Cidade,Estado," +
                    "TelFixo,TelFixoComercial,TelCelular1,TelCelular2,Email,Contato,Observacao) Values";
                cmd.CommandText += "('" + DataCadastroUS + "','" + cbo_status.Text + "','" + cbo_tipocadastro.Text + "','" + cbo_tipopessoa.Text + "'," +
                    "'" + txt_nomerazao.Text + "','" + txt_nomefantasia.Text + "','" + DataAberturaUS + "'," +
                    "'" + txt_mskcnpj.Text + "','" + txt_inscricaoestadual.Text + "','" + txt_inscricaomunicipal.Text + "'," +
                    "'" + DataNascimentoUS + "','" + txt_mskcpf.Text + "','" + txt_rg.Text + "'," +
                    "'" + DataExpedicaoRgUS + "','" + txt_nacionalidade.Text + "','" + txt_naturalidade.Text + "'," +
                    "'" + cbo_estadocivil.Text + "','" + cbo_grauinstrucao.Text + "','" + txt_ctps.Text + "'," +
                    "'" + txt_seriectps.Text + "','" + DataExpedicaoCtpsUS + "','" + txt_pispasep.Text + "'," +
                    "'" + txt_tituloeleitor.Text + "','" + txt_titulozona.Text + "','" + txt_titulosecao.Text + "'," +
                    "'" + cbo_valetransporte.Text + "','" + cbo_tipoadmissao.Text + "','" + txt_funcao.Text + "'," +
                    "'" + txt_salarioregistrado.Text + "','" + txt_salariototal.Text + "','" + txt_nomemae.Text + "'," +
                    "'" + txt_nomepai.Text + "','" + txt_narmario.Text + "','" + DataComecouUS + "'," +
                    "'" + DataAdmissaoUS + "','" + DataDemissaoUS + "','" + txt_mskcep.Text + "'," +
                    "'" + cbo_tipologradouro.Text + "','" + txt_endereco.Text + "','" + txt_numero.Text + "'," +
                    "'" + txt_complemento.Text + "','" + txt_bairro.Text + "','" + txt_cidade.Text + "'," +
                    "'" + cbo_estado.Text + "','" + txt_msktelfixo.Text + "','" + txt_msktelfixocomercial.Text + "'," +
                    "'" + txt_msktelcelular1.Text + "','" + txt_msktelcelular2.Text + "','" + txt_email.Text + "'," +
                    "'" + txt_contato.Text + "','" + txt_obs.Text + "')";
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
                if (cbo_status.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo status para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_status.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_tipocadastro.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tipo cadastro para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_tipocadastro.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_tipopessoa.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tipo pessoa para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_tipopessoa.Focus();
                    return;
                }
                #endregion

                #region 'DADOS PRINCIPAIS'
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_nomerazao.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nome/razão para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_nomerazao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_nomefantasia.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nome fantasia/apelido para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_nomefantasia.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdataabertura.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data abertura para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdataabertura.Text = "";
                    this.txt_mskdataabertura.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskcnpj.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo CNPJ para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskcnpj.Text = "";
                    this.txt_mskcnpj.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_inscricaoestadual.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo inscrição estadual para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_inscricaoestadual.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_inscricaomunicipal.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo inscrição municipal para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_inscricaomunicipal.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdatanascimento.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data nascimento para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdatanascimento.Text = "";
                    this.txt_mskdatanascimento.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskcpf.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo CPF para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskcpf.Text = "";
                    this.txt_mskcpf.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_rg.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo RG para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_rg.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdataexprg.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data expedição RG para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdataexprg.Text = "";
                    this.txt_mskdataexprg.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_nacionalidade.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nacionalidade para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_nacionalidade.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_naturalidade.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo naturalidade para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_naturalidade.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_estadocivil.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo estado civil para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_estadocivil.Focus();
                    return;
                }
                #endregion

                #region 'DADOS SECUNDÁRIOS'
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_grauinstrucao.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo grau de instrução para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_grauinstrucao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_ctps.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo CTPS Nº para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_ctps.Text = "";
                    this.txt_ctps.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_seriectps.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo CTPS série para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_seriectps.Text = "";
                    this.txt_seriectps.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdataexpctps.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data expedição CTPS para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdataexpctps.Text = "";
                    this.txt_mskdataexpctps.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_pispasep.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo PIS|PASEP para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_pispasep.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_tituloeleitor.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo título eleitor para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_tituloeleitor.Text = "";
                    this.txt_tituloeleitor.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_titulozona.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo título zona para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_titulozona.Text = "";
                    this.txt_titulozona.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_titulosecao.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo título seção para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_titulosecao.Text = "";
                    this.txt_titulosecao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_valetransporte.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo vale transporte para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_valetransporte.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_tipoadmissao.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tipo admissão para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_tipoadmissao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_funcao.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo função para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_funcao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_salarioregistrado.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo salário registrado para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_salarioregistrado.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_salariototal.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo salário total para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_salariototal.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_nomemae.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nome mãe para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_nomemae.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_nomepai.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo nome pai para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_nomepai.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_narmario.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo Nº armário para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_narmario.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdatacomecou.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data começou para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdatacomecou.Text = "";
                    this.txt_mskdatacomecou.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdataadmissao.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data admissão para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdataadmissao.Text = "";
                    this.txt_mskdataadmissao.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskdatademissao.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo data demissão para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskdatademissao.Text = "";
                    this.txt_mskdatademissao.Focus();
                    return;
                }
                #endregion

                #region 'ENDEREÇO CONTATO'
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_mskcep.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo CEP para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_mskcep.Text = "";
                    this.txt_mskcep.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_tipologradouro.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo tipo logradouro para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_tipologradouro.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_endereco.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo endereço para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_endereco.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_numero.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo número para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_numero.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_complemento.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo complemento para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_complemento.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_bairro.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo bairro para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_bairro.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_cidade.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo cidade para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_cidade.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (cbo_estado.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo estado para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_estado.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_msktelfixo.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo telefone fixo para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_msktelfixo.Text = "";
                    this.txt_msktelfixo.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_msktelfixocomercial.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo telefone fixo comercial para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_msktelfixocomercial.Text = "";
                    this.txt_msktelfixocomercial.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_msktelcelular1.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo telefone celular 1 para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_msktelcelular1.Text = "";
                    this.txt_msktelcelular1.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (!txt_msktelcelular2.MaskCompleted)
                {
                    MessageBox.Show("Preencha o campo telefone celular 2 para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_msktelcelular2.Text = "";
                    this.txt_msktelcelular2.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_email.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo email para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_email.Focus();
                    return;
                }
                //VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_contato.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo contato para gravar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_contato.Focus();
                    return;
                }
                #endregion

                #endregion

                #region 'FORMATAÇÃO DA DATA'
                string DataCadastroUS = FormatadataUS(txt_datacadastro.Text);
                string DataAberturaUS = FormatadataUS(txt_mskdataabertura.Text);
                string DataNascimentoUS = FormatadataUS(txt_mskdatanascimento.Text);
                string DataExpedicaoRgUS = FormatadataUS(txt_mskdataexprg.Text);
                string DataExpedicaoCtpsUS = FormatadataUS(txt_mskdataexpctps.Text);
                string DataComecouUS = FormatadataUS(txt_mskdatacomecou.Text);
                string DataAdmissaoUS = FormatadataUS(txt_mskdataadmissao.Text);
                string DataDemissaoUS = FormatadataUS(txt_mskdatademissao.Text);
                #endregion

                #region "COMANDO PARA ALTERAR"
                //Começa o comando para alterar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "update tb_cadastromultiplo set " +
                    "DataSistema = '" + DataCadastroUS + "',Status = '" + cbo_status.Text + "',TipoCadastro = '" + cbo_tipocadastro.Text + "'," +
                    "TipoPessoa = '" + cbo_tipopessoa.Text + "',NomeRazaoSocial = '" + txt_nomerazao.Text + "',NomeFantasiaApelido = '" + txt_nomefantasia.Text + "'," +
                    "DataAbertura = '" + DataAberturaUS + "',Cnpj = '" + txt_mskcnpj.Text + "',InscricaoEstadual = '" + txt_inscricaoestadual.Text + "'," +
                    "InscricaoMunicipal = '" + txt_inscricaomunicipal.Text + "',DataNascimento = '" + DataNascimentoUS + "',Cpf = '" + txt_mskcpf.Text + "'," +
                    "Rg = '" + txt_rg.Text + "',DataExpedicaoRG = '" + DataExpedicaoRgUS + "',Nacionalidade = '" + txt_nacionalidade.Text + "'," +
                    "Naturalidade = '" + txt_naturalidade.Text + "',EstadoCivil = '" + cbo_estadocivil.Text + "',GrauInstrucao = '" + cbo_grauinstrucao.Text + "'," +
                    "CtpsNumero = '" + txt_ctps.Text + "',CtpsSerie = '" + txt_seriectps.Text + "',DataExpedicaoCtps = '" + DataExpedicaoCtpsUS + "'," +
                    "PisPasep = '" + txt_pispasep.Text + "',TituloNumero = '" + txt_tituloeleitor.Text + "',TituloZona = '" + txt_titulozona.Text + "'," +
                    "TituloSecao = '" + txt_titulosecao.Text + "',ValeTransporte = '" + cbo_valetransporte.Text + "',TipoAdmissao = '" + cbo_tipoadmissao.Text + "'," +
                    "Funcao = '" + txt_funcao.Text + "',SalarioRegistrado = '" + txt_salarioregistrado.Text + "',SalarioTotal = '" + txt_salariototal.Text + "'," +
                    "NomeMae = '" + txt_nomemae.Text + "',NomePai = '" + txt_nomepai.Text + "',ArmarioNumero = '" + txt_narmario.Text + "'," +
                    "DataComecou = '" + DataComecouUS + "',DataAdmissao = '" + DataAdmissaoUS + "',DataDemissao = '" + DataDemissaoUS + "'," +
                    "Cep = '" + txt_mskcep.Text + "',TipoLogradouro = '" + cbo_tipologradouro.Text + "',Endereco = '" + txt_endereco.Text + "'," +
                    "Numero = '" + txt_numero.Text + "',Complemento = '" + txt_complemento.Text + "',Bairro = '" + txt_bairro.Text + "'," +
                    "Cidade = '" + txt_cidade.Text + "',Estado = '" + cbo_estado.Text + "',TelFixo = '" + txt_msktelfixo.Text + "'," +
                    "TelFixoComercial = '" + txt_msktelfixocomercial.Text + "',TelCelular1 = '" + txt_msktelcelular1.Text + "',TelCelular2 = '" + txt_msktelcelular2.Text + "'," +
                    "Email = '" + txt_email.Text + "',Contato = '" + txt_contato.Text + "',Observacao = '" + txt_obs.Text + "' Where ID = " + txt_id.Text + "";
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

            #region "COLOCA O FOCO"
            btNovo.Focus();
            #endregion
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            #region 'ATIVAR|DESATIVAR CAIXAS'
            //CABEÇALHO
            this.txt_id.Enabled = false;
            this.txt_datacadastro.Enabled = false;
            this.cbo_status.Enabled = true;
            this.cbo_tipocadastro.Enabled = true;
            this.cbo_tipopessoa.Enabled = true;
            //DADOS PRINCIPAIS
            this.txt_nomerazao.Enabled = true;
            this.txt_nomefantasia.Enabled = true;
            this.txt_mskdataabertura.Enabled = true;
            this.txt_mskcnpj.Enabled = true;
            this.txt_inscricaoestadual.Enabled = true;
            this.txt_inscricaomunicipal.Enabled = true;
            this.txt_mskdatanascimento.Enabled = true;
            this.txt_mskcpf.Enabled = true;
            this.txt_rg.Enabled = true;
            this.txt_mskdataexprg.Enabled = true;
            this.txt_nacionalidade.Enabled = true;
            this.txt_naturalidade.Enabled = true;
            this.cbo_estadocivil.Enabled = true;
            //DADOS SECUNDÁRIOS
            this.cbo_grauinstrucao.Enabled = true;
            this.txt_ctps.Enabled = true;
            this.txt_seriectps.Enabled = true;
            this.txt_mskdataexpctps.Enabled = true;
            this.txt_pispasep.Enabled = true;
            this.txt_tituloeleitor.Enabled = true;
            this.txt_titulozona.Enabled = true;
            this.txt_titulosecao.Enabled = true;
            this.cbo_valetransporte.Enabled = true;
            this.cbo_tipoadmissao.Enabled = true;
            this.txt_funcao.Enabled = true;
            this.txt_salarioregistrado.Enabled = true;
            this.txt_salariototal.Enabled = true;
            this.txt_nomemae.Enabled = true;
            this.txt_nomepai.Enabled = true;
            this.txt_narmario.Enabled = true;
            this.txt_mskdatacomecou.Enabled = true;
            this.txt_mskdataadmissao.Enabled = true;
            this.txt_mskdatademissao.Enabled = true;
            //ENDEREÇO|CONTATO
            this.txt_mskcep.Enabled = true;
            this.cbo_tipologradouro.Enabled = true;
            this.txt_endereco.Enabled = false;
            this.txt_numero.Enabled = true;
            this.txt_complemento.Enabled = true;
            this.txt_bairro.Enabled = false;
            this.txt_cidade.Enabled = false;
            this.cbo_estado.Enabled = false;
            this.txt_msktelfixo.Enabled = true;
            this.txt_msktelfixocomercial.Enabled = true;
            this.txt_msktelcelular1.Enabled = true;
            this.txt_msktelcelular2.Enabled = true;
            this.txt_email.Enabled = true;
            this.txt_contato.Enabled = true;
            this.txt_obs.Enabled = true;
            #endregion

            #region 'ATIVAR|DESATIVAR BOTÕES'
            this.btNovo.Enabled = false;
            this.btGravar.Enabled = false;
            this.btAlterar.Enabled = true;
            this.btEditar.Enabled = false;
            this.btCancelar.Enabled = true;
            this.btConsultar.Enabled = false;
            this.btRelatorio.Enabled = false;
            this.btFechar.Enabled = false;
            btnCerrar.Enabled = false;
            #endregion
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            #region 'LIMPAR CAIXAS'
            //CABEÇALHO
            this.txt_id.Text = "";
            this.txt_datacadastro.Text = "";
            this.cbo_status.Text = "";
            this.cbo_tipocadastro.Text = "";
            this.cbo_tipopessoa.Text = "";
            //DADOS PRINCIPAIS
            this.txt_nomerazao.Text = "";
            this.txt_nomefantasia.Text = "";
            this.txt_mskdataabertura.Text = "";
            this.txt_mskcnpj.Text = "";
            this.txt_inscricaoestadual.Text = "";
            this.txt_inscricaomunicipal.Text = "";
            this.txt_mskdatanascimento.Text = "";
            this.txt_mskcpf.Text = "";
            this.txt_rg.Text = "";
            this.txt_mskdataexprg.Text = "";
            this.txt_nacionalidade.Text = "";
            this.txt_naturalidade.Text = "";
            this.cbo_estadocivil.Text = "";
            //DADOS SECUNDÁRIOS
            this.cbo_grauinstrucao.Text = "";
            this.txt_ctps.Text = "";
            this.txt_seriectps.Text = "";
            this.txt_mskdataexpctps.Text = "";
            this.txt_pispasep.Text = "";
            this.txt_tituloeleitor.Text = "";
            this.txt_titulozona.Text = "";
            this.txt_titulosecao.Text = "";
            this.cbo_valetransporte.Text = "";
            this.cbo_tipoadmissao.Text = "";
            this.txt_funcao.Text = "";
            this.txt_salarioregistrado.Text = "";
            this.txt_salariototal.Text = "";
            this.txt_nomemae.Text = "";
            this.txt_nomepai.Text = "";
            this.txt_narmario.Text = "";
            this.txt_mskdatacomecou.Text = "";
            this.txt_mskdataadmissao.Text = "";
            this.txt_mskdatademissao.Text = "";
            //ENDEREÇO|CONTATO
            this.txt_mskcep.Text = "";
            this.cbo_tipologradouro.Text = "";
            this.txt_endereco.Text = "";
            this.txt_numero.Text = "";
            this.txt_complemento.Text = "";
            this.txt_bairro.Text = "";
            this.txt_cidade.Text = "";
            this.cbo_estado.Text = "";
            this.txt_msktelfixo.Text = "";
            this.txt_msktelfixocomercial.Text = "";
            this.txt_msktelcelular1.Text = "";
            this.txt_msktelcelular2.Text = "";
            this.txt_email.Text = "";
            this.txt_contato.Text = "";
            this.txt_obs.Text = "";
            #endregion

            #region 'DESATIVAR CAIXAS'
            //CABEÇALHO
            this.txt_id.Enabled = false;
            this.txt_datacadastro.Enabled = false;
            this.cbo_status.Enabled = false;
            this.cbo_tipocadastro.Enabled = false;
            this.cbo_tipopessoa.Enabled = false;
            //DADOS PRINCIPAIS
            this.txt_nomerazao.Enabled = false;
            this.txt_nomefantasia.Enabled = false;
            this.txt_mskdataabertura.Enabled = false;
            this.txt_mskcnpj.Enabled = false;
            this.txt_inscricaoestadual.Enabled = false;
            this.txt_inscricaomunicipal.Enabled = false;
            this.txt_mskdatanascimento.Enabled = false;
            this.txt_mskcpf.Enabled = false;
            this.txt_rg.Enabled = false;
            this.txt_mskdataexprg.Enabled = false;
            this.txt_nacionalidade.Enabled = false;
            this.txt_naturalidade.Enabled = false;
            this.cbo_estadocivil.Enabled = false;
            //DADOS SECUNDÁRIOS
            this.cbo_grauinstrucao.Enabled = false;
            this.txt_ctps.Enabled = false;
            this.txt_seriectps.Enabled = false;
            this.txt_mskdataexpctps.Enabled = false;
            this.txt_pispasep.Enabled = false;
            this.txt_tituloeleitor.Enabled = false;
            this.txt_titulozona.Enabled = false;
            this.txt_titulosecao.Enabled = false;
            this.cbo_valetransporte.Enabled = false;
            this.cbo_tipoadmissao.Enabled = false;
            this.txt_funcao.Enabled = false;
            this.txt_salarioregistrado.Enabled = false;
            this.txt_salariototal.Enabled = false;
            this.txt_nomemae.Enabled = false;
            this.txt_nomepai.Enabled = false;
            this.txt_narmario.Enabled = false;
            this.txt_mskdatacomecou.Enabled = false;
            this.txt_mskdataadmissao.Enabled = false;
            this.txt_mskdatademissao.Enabled = false;
            //ENDEREÇO|CONTATO
            this.txt_mskcep.Enabled = false;
            this.cbo_tipologradouro.Enabled = false;
            this.txt_endereco.Enabled = false;
            this.txt_numero.Enabled = false;
            this.txt_complemento.Enabled = false;
            this.txt_bairro.Enabled = false;
            this.txt_cidade.Enabled = false;
            this.cbo_estado.Enabled = false;
            this.txt_msktelfixo.Enabled = false;
            this.txt_msktelfixocomercial.Enabled = false;
            this.txt_msktelcelular1.Enabled = false;
            this.txt_msktelcelular2.Enabled = false;
            this.txt_email.Enabled = false;
            this.txt_contato.Enabled = false;
            this.txt_obs.Enabled = false;
            #endregion

            #region 'ATIVAR|DESATIVAR BOTÕES'
            this.btNovo.Enabled = true;
            this.btGravar.Enabled = false;
            this.btAlterar.Enabled = false;
            this.btEditar.Enabled = false;
            this.btCancelar.Enabled = false;
            this.btConsultar.Enabled = true;
            this.btRelatorio.Enabled = true;
            this.btFechar.Enabled = true;
            btnCerrar.Enabled = true;
            #endregion

            #region 'COLOCA O FOCO'
            btNovo.Focus();
            #endregion
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            #region "ABRINDO NOVA TELA"
            this.Hide();
            FrmCadastroMultiplosConsulta frm = new FrmCadastroMultiplosConsulta();
            frm.ShowDialog();
            #endregion            
        }

        private void btRelatorio_Click(object sender, EventArgs e)
        {
            #region "ABRINDO NOVA TELA"
            this.Hide();
            FrmCadastroMultiplosRelatorios frm = new FrmCadastroMultiplosRelatorios();
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

        private void cbo_tipocadastro_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 'FAZ VERIFICAÇÕES POR CHAVE'
            if (cbo_tipocadastro.Text == "Colaborador")
            {
                #region 'DETERMINAR AÇÕES'
                cbo_tipopessoa.Text = "Pessoa Física";
                cbo_tipopessoa.Enabled = false;

                txt_mskdataabertura.Text = "";
                txt_mskdataabertura.Text = "01/01/0001";
                txt_mskdataabertura.Enabled = false;

                txt_mskcnpj.Text = "";
                txt_mskcnpj.Text = "00.000.000/0000-00";
                txt_mskcnpj.Enabled = false;

                txt_inscricaoestadual.Text = "";
                txt_inscricaoestadual.Text = "0000000000000";
                txt_inscricaoestadual.Enabled = false;

                txt_inscricaomunicipal.Text = "";
                txt_inscricaomunicipal.Text = "0000000000";
                txt_inscricaomunicipal.Enabled = false;
                #endregion

                #region 'LIMPAR CAIXAS'
                //CABEÇALHO
                //this.txt_id.Text = "";
                //this.txt_datacadastro.Text = "";
                //this.cbo_status.Text = "";
                //this.cbo_tipocadastro.Text = "";
                //this.cbo_tipopessoa.Text = "";
                //DADOS PRINCIPAIS
                this.txt_nomerazao.Text = "";
                this.txt_nomefantasia.Text = "";
                //this.txt_mskdataabertura.Text = "";
                //this.txt_mskcnpj.Text = "";
                //this.txt_inscricaoestadual.Text = "";
                //this.txt_inscricaomunicipal.Text = "";
                this.txt_mskdatanascimento.Text = "";
                this.txt_mskcpf.Text = "";
                this.txt_rg.Text = "";
                this.txt_mskdataexprg.Text = "";
                this.txt_nacionalidade.Text = "";
                this.txt_naturalidade.Text = "";
                this.cbo_estadocivil.Text = "";
                //DADOS SECUNDÁRIOS
                this.cbo_grauinstrucao.Text = "";
                this.txt_ctps.Text = "";
                this.txt_seriectps.Text = "";
                this.txt_mskdataexpctps.Text = "";
                this.txt_pispasep.Text = "";
                this.txt_tituloeleitor.Text = "";
                this.txt_titulozona.Text = "";
                this.txt_titulosecao.Text = "";
                this.cbo_valetransporte.Text = "";
                this.cbo_tipoadmissao.Text = "";
                this.txt_funcao.Text = "";
                this.txt_salarioregistrado.Text = "";
                this.txt_salariototal.Text = "";
                this.txt_nomemae.Text = "";
                this.txt_nomepai.Text = "";
                this.txt_narmario.Text = "";
                this.txt_mskdatacomecou.Text = "";
                this.txt_mskdataadmissao.Text = "";
                this.txt_mskdatademissao.Text = "";
                //ENDEREÇO|CONTATO
                this.txt_mskcep.Text = "";
                this.cbo_tipologradouro.Text = "";
                this.txt_endereco.Text = "";
                this.txt_numero.Text = "";
                this.txt_complemento.Text = "";
                this.txt_bairro.Text = "";
                this.txt_cidade.Text = "";
                this.cbo_estado.Text = "";
                this.txt_msktelfixo.Text = "";
                this.txt_msktelfixocomercial.Text = "";
                this.txt_msktelcelular1.Text = "";
                this.txt_msktelcelular2.Text = "";
                this.txt_email.Text = "";
                this.txt_contato.Text = "";
                this.txt_obs.Text = "";
                #endregion

                #region 'ATIVAR|DESATIVAR CAIXAS'
                //CABEÇALHO
                this.txt_id.Enabled = false;
                this.txt_datacadastro.Enabled = false;
                this.cbo_status.Enabled = true;
                this.cbo_tipocadastro.Enabled = true;
                //this.cbo_tipopessoa.Enabled = true;
                //DADOS PRINCIPAIS
                this.txt_nomerazao.Enabled = true;
                this.txt_nomefantasia.Enabled = true;
                //this.txt_mskdataabertura.Enabled = true;
                //this.txt_mskcnpj.Enabled = true;
                //this.txt_inscricaoestadual.Enabled = true;
                //this.txt_inscricaomunicipal.Enabled = true;
                this.txt_mskdatanascimento.Enabled = true;
                this.txt_mskcpf.Enabled = true;
                this.txt_rg.Enabled = true;
                this.txt_mskdataexprg.Enabled = true;
                this.txt_nacionalidade.Enabled = true;
                this.txt_naturalidade.Enabled = true;
                this.cbo_estadocivil.Enabled = true;
                //DADOS SECUNDÁRIOS
                this.cbo_grauinstrucao.Enabled = true;
                this.txt_ctps.Enabled = true;
                this.txt_seriectps.Enabled = true;
                this.txt_mskdataexpctps.Enabled = true;
                this.txt_pispasep.Enabled = true;
                this.txt_tituloeleitor.Enabled = true;
                this.txt_titulozona.Enabled = true;
                this.txt_titulosecao.Enabled = true;
                this.cbo_valetransporte.Enabled = true;
                this.cbo_tipoadmissao.Enabled = true;
                this.txt_funcao.Enabled = true;
                this.txt_salarioregistrado.Enabled = true;
                this.txt_salariototal.Enabled = true;
                this.txt_nomemae.Enabled = true;
                this.txt_nomepai.Enabled = true;
                this.txt_narmario.Enabled = true;
                this.txt_mskdatacomecou.Enabled = true;
                this.txt_mskdataadmissao.Enabled = true;
                this.txt_mskdatademissao.Enabled = true;
                //ENDEREÇO|CONTATO
                this.txt_mskcep.Enabled = true;
                this.cbo_tipologradouro.Enabled = true;
                this.txt_endereco.Enabled = false;
                this.txt_numero.Enabled = true;
                this.txt_complemento.Enabled = true;
                this.txt_bairro.Enabled = false;
                this.txt_cidade.Enabled = false;
                this.cbo_estado.Enabled = false;
                this.txt_msktelfixo.Enabled = true;
                this.txt_msktelfixocomercial.Enabled = true;
                this.txt_msktelcelular1.Enabled = true;
                this.txt_msktelcelular2.Enabled = true;
                this.txt_email.Enabled = true;
                this.txt_contato.Enabled = true;
                this.txt_obs.Enabled = true;
                #endregion
            }
            else
            {
                #region 'LIMPAR CAIXAS'
                //CABEÇALHO
                //this.txt_id.Text = "";
                //this.txt_datacadastro.Text = "";
                //this.cbo_status.Text = "";
                this.cbo_tipocadastro.Text = "";
                this.cbo_tipopessoa.Text = "";
                //DADOS PRINCIPAIS
                this.txt_nomerazao.Text = "";
                this.txt_nomefantasia.Text = "";
                this.txt_mskdataabertura.Text = "";
                this.txt_mskcnpj.Text = "";
                this.txt_inscricaoestadual.Text = "";
                this.txt_inscricaomunicipal.Text = "";
                this.txt_mskdatanascimento.Text = "";
                this.txt_mskcpf.Text = "";
                this.txt_rg.Text = "";
                this.txt_mskdataexprg.Text = "";
                this.txt_nacionalidade.Text = "";
                this.txt_naturalidade.Text = "";
                this.cbo_estadocivil.Text = "";
                //DADOS SECUNDÁRIOS
                this.cbo_grauinstrucao.Text = "";
                this.txt_ctps.Text = "";
                this.txt_seriectps.Text = "";
                this.txt_mskdataexpctps.Text = "";
                this.txt_pispasep.Text = "";
                this.txt_tituloeleitor.Text = "";
                this.txt_titulozona.Text = "";
                this.txt_titulosecao.Text = "";
                this.cbo_valetransporte.Text = "";
                this.cbo_tipoadmissao.Text = "";
                this.txt_funcao.Text = "";
                this.txt_salarioregistrado.Text = "";
                this.txt_salariototal.Text = "";
                this.txt_nomemae.Text = "";
                this.txt_nomepai.Text = "";
                this.txt_narmario.Text = "";
                this.txt_mskdatacomecou.Text = "";
                this.txt_mskdataadmissao.Text = "";
                this.txt_mskdatademissao.Text = "";
                //ENDEREÇO|CONTATO
                this.txt_mskcep.Text = "";
                this.cbo_tipologradouro.Text = "";
                this.txt_endereco.Text = "";
                this.txt_numero.Text = "";
                this.txt_complemento.Text = "";
                this.txt_bairro.Text = "";
                this.txt_cidade.Text = "";
                this.cbo_estado.Text = "";
                this.txt_msktelfixo.Text = "";
                this.txt_msktelfixocomercial.Text = "";
                this.txt_msktelcelular1.Text = "";
                this.txt_msktelcelular2.Text = "";
                this.txt_email.Text = "";
                this.txt_contato.Text = "";
                this.txt_obs.Text = "";
                #endregion

                #region 'ATIVAR|DESATIVAR CAIXAS'
                //CABEÇALHO
                this.txt_id.Enabled = false;
                this.txt_datacadastro.Enabled = false;
                this.cbo_status.Enabled = true;
                this.cbo_tipocadastro.Enabled = true;
                this.cbo_tipopessoa.Enabled = true;
                //DADOS PRINCIPAIS
                this.txt_nomerazao.Enabled = true;
                this.txt_nomefantasia.Enabled = true;
                this.txt_mskdataabertura.Enabled = true;
                this.txt_mskcnpj.Enabled = true;
                this.txt_inscricaoestadual.Enabled = true;
                this.txt_inscricaomunicipal.Enabled = true;
                this.txt_mskdatanascimento.Enabled = true;
                this.txt_mskcpf.Enabled = true;
                this.txt_rg.Enabled = true;
                this.txt_mskdataexprg.Enabled = true;
                this.txt_nacionalidade.Enabled = true;
                this.txt_naturalidade.Enabled = true;
                this.cbo_estadocivil.Enabled = true;
                //DADOS SECUNDÁRIOS
                this.cbo_grauinstrucao.Enabled = true;
                this.txt_ctps.Enabled = true;
                this.txt_seriectps.Enabled = true;
                this.txt_mskdataexpctps.Enabled = true;
                this.txt_pispasep.Enabled = true;
                this.txt_tituloeleitor.Enabled = true;
                this.txt_titulozona.Enabled = true;
                this.txt_titulosecao.Enabled = true;
                this.cbo_valetransporte.Enabled = true;
                this.cbo_tipoadmissao.Enabled = true;
                this.txt_funcao.Enabled = true;
                this.txt_salarioregistrado.Enabled = true;
                this.txt_salariototal.Enabled = true;
                this.txt_nomemae.Enabled = true;
                this.txt_nomepai.Enabled = true;
                this.txt_narmario.Enabled = true;
                this.txt_mskdatacomecou.Enabled = true;
                this.txt_mskdataadmissao.Enabled = true;
                this.txt_mskdatademissao.Enabled = true;
                //ENDEREÇO|CONTATO
                this.txt_mskcep.Enabled = true;
                this.cbo_tipologradouro.Enabled = true;
                this.txt_endereco.Enabled = false;
                this.txt_numero.Enabled = true;
                this.txt_complemento.Enabled = true;
                this.txt_bairro.Enabled = false;
                this.txt_cidade.Enabled = false;
                this.cbo_estado.Enabled = false;
                this.txt_msktelfixo.Enabled = true;
                this.txt_msktelfixocomercial.Enabled = true;
                this.txt_msktelcelular1.Enabled = true;
                this.txt_msktelcelular2.Enabled = true;
                this.txt_email.Enabled = true;
                this.txt_contato.Enabled = true;
                this.txt_obs.Enabled = true;
                #endregion
            }
            #endregion
        }

        private void cbo_tipopessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 'FAZ VERIFICAÇÕES POR CHAVE'
            if (cbo_tipopessoa.Text == "Pessoa Física")
            {
                #region 'DETERMINAR AÇÕES'

                txt_mskdataabertura.Text = "";
                txt_mskdataabertura.Text = "01/01/0001";
                txt_mskdataabertura.Enabled = false;

                txt_mskcnpj.Text = "";
                txt_mskcnpj.Text = "00.000.000/0000-00";
                txt_mskcnpj.Enabled = false;

                txt_inscricaoestadual.Text = "";
                txt_inscricaoestadual.Text = "0000000000000";
                txt_inscricaoestadual.Enabled = false;

                txt_inscricaomunicipal.Text = "";
                txt_inscricaomunicipal.Text = "0000000000";
                txt_inscricaomunicipal.Enabled = false;
                
                cbo_grauinstrucao.Text = "";
                cbo_grauinstrucao.Text = "Nada";
                cbo_grauinstrucao.Enabled = false;

                txt_ctps.Text = "";
                txt_ctps.Text = "00000000000";
                txt_ctps.Enabled = false;

                txt_seriectps.Text = "";
                txt_seriectps.Text = "0000";
                txt_seriectps.Enabled = false;

                txt_mskdataexpctps.Text = "";
                txt_mskdataexpctps.Text = "01/01/0001";
                txt_mskdataexpctps.Enabled = false;

                txt_pispasep.Text = "";
                txt_pispasep.Text = "00000000000";
                txt_pispasep.Enabled = false;

                txt_tituloeleitor.Text = "";
                txt_tituloeleitor.Text = "000000000000";
                txt_tituloeleitor.Enabled = false;

                txt_titulozona.Text = "";
                txt_titulozona.Text = "00000";
                txt_titulozona.Enabled = false;

                txt_titulosecao.Text = "";
                txt_titulosecao.Text = "00000";
                txt_titulosecao.Enabled = false;

                cbo_valetransporte.Text = "";
                cbo_valetransporte.Text = "Nada";
                cbo_valetransporte.Enabled = false;

                cbo_tipoadmissao.Text = "";
                cbo_tipoadmissao.Text = "Nada";
                cbo_tipoadmissao.Enabled = false;

                txt_funcao.Text = "";
                txt_funcao.Text = "Nada";
                txt_funcao.Enabled = false;

                txt_salarioregistrado.Text = "";
                txt_salarioregistrado.Text = "0,00";
                txt_salarioregistrado.Enabled = false;

                txt_salariototal.Text = "";
                txt_salariototal.Text = "0,00";
                txt_salariototal.Enabled = false;

                txt_nomemae.Text = "";
                txt_nomemae.Text = "Nada";
                txt_nomemae.Enabled = false;

                txt_nomepai.Text = "";
                txt_nomepai.Text = "Nada";
                txt_nomepai.Enabled = false;

                txt_narmario.Text = "";
                txt_narmario.Text = "00";
                txt_narmario.Enabled = false;

                txt_mskdatacomecou.Text = "";
                txt_mskdatacomecou.Text = "01/01/0001";
                txt_mskdatacomecou.Enabled = false;

                txt_mskdataadmissao.Text = "";
                txt_mskdataadmissao.Text = "01/01/0001";
                txt_mskdataadmissao.Enabled = false;

                txt_mskdatademissao.Text = "";
                txt_mskdatademissao.Text = "01/01/0001";
                txt_mskdatademissao.Enabled = false;
                #endregion

                #region 'LIMPAR CAIXAS'
                //CABEÇALHO
                //this.txt_id.Text = "";
                //this.txt_datacadastro.Text = "";
                //this.cbo_status.Text = "";
                //this.cbo_tipocadastro.Text = "";
                //this.cbo_tipopessoa.Text = "";
                //DADOS PRINCIPAIS
                this.txt_nomerazao.Text = "";
                this.txt_nomefantasia.Text = "";
                //this.txt_mskdataabertura.Text = "";
                //this.txt_mskcnpj.Text = "";
                //this.txt_inscricaoestadual.Text = "";
                //this.txt_inscricaomunicipal.Text = "";
                this.txt_mskdatanascimento.Text = "";
                this.txt_mskcpf.Text = "";
                this.txt_rg.Text = "";
                this.txt_mskdataexprg.Text = "";
                this.txt_nacionalidade.Text = "";
                this.txt_naturalidade.Text = "";
                this.cbo_estadocivil.Text = "";
                //DADOS SECUNDÁRIOS
                //this.cbo_grauinstrucao.Text = "";
                //this.txt_ctps.Text = "";
                //this.txt_seriectps.Text = "";
                //this.txt_mskdataexpctps.Text = "";
                //this.txt_pispasep.Text = "";
                //this.txt_tituloeleitor.Text = "";
                //this.txt_titulozona.Text = "";
                //this.txt_titulosecao.Text = "";
                //this.cbo_valetransporte.Text = "";
                //this.cbo_tipoadmissao.Text = "";
                //this.txt_funcao.Text = "";
                //this.txt_salarioregistrado.Text = "";
                //this.txt_salariototal.Text = "";
                //this.txt_nomemae.Text = "";
                //this.txt_nomepai.Text = "";
                //this.txt_narmario.Text = "";
                //this.txt_mskdatacomecou.Text = "";
                //this.txt_mskdataadmissao.Text = "";
                //this.txt_mskdatademissao.Text = "";
                //ENDEREÇO|CONTATO
                this.txt_mskcep.Text = "";
                this.cbo_tipologradouro.Text = "";
                this.txt_endereco.Text = "";
                this.txt_numero.Text = "";
                this.txt_complemento.Text = "";
                this.txt_bairro.Text = "";
                this.txt_cidade.Text = "";
                this.cbo_estado.Text = "";
                this.txt_msktelfixo.Text = "";
                this.txt_msktelfixocomercial.Text = "";
                this.txt_msktelcelular1.Text = "";
                this.txt_msktelcelular2.Text = "";
                this.txt_email.Text = "";
                this.txt_contato.Text = "";
                this.txt_obs.Text = "";
                #endregion

                #region 'ATIVAR|DESATIVAR CAIXAS'
                //CABEÇALHO
                this.txt_id.Enabled = false;
                this.txt_datacadastro.Enabled = false;
                this.cbo_status.Enabled = true;
                this.cbo_tipocadastro.Enabled = true;
                this.cbo_tipopessoa.Enabled = true;
                //DADOS PRINCIPAIS
                this.txt_nomerazao.Enabled = true;
                this.txt_nomefantasia.Enabled = true;
                //this.txt_mskdataabertura.Enabled = true;
                //this.txt_mskcnpj.Enabled = true;
                //this.txt_inscricaoestadual.Enabled = true;
                //this.txt_inscricaomunicipal.Enabled = true;
                this.txt_mskdatanascimento.Enabled = true;
                this.txt_mskcpf.Enabled = true;
                this.txt_rg.Enabled = true;
                this.txt_mskdataexprg.Enabled = true;
                this.txt_nacionalidade.Enabled = true;
                this.txt_naturalidade.Enabled = true;
                this.cbo_estadocivil.Enabled = true;
                //DADOS SECUNDÁRIOS
                //this.cbo_grauinstrucao.Enabled = true;
                //this.txt_ctps.Enabled = true;
                //this.txt_seriectps.Enabled = true;
                //this.txt_mskdataexpctps.Enabled = true;
                //this.txt_pispasep.Enabled = true;
                //this.txt_tituloeleitor.Enabled = true;
                //this.txt_titulozona.Enabled = true;
                //this.txt_titulosecao.Enabled = true;
                //this.cbo_valetransporte.Enabled = true;
                //this.cbo_tipoadmissao.Enabled = true;
                //this.txt_funcao.Enabled = true;
                //this.txt_salarioregistrado.Enabled = true;
                //this.txt_salariototal.Enabled = true;
                //this.txt_nomemae.Enabled = true;
                //this.txt_nomepai.Enabled = true;
                //this.txt_narmario.Enabled = true;
                //this.txt_mskdatacomecou.Enabled = true;
                //this.txt_mskdataadmissao.Enabled = true;
                //this.txt_mskdatademissao.Enabled = true;
                //ENDEREÇO|CONTATO
                this.txt_mskcep.Enabled = true;
                this.cbo_tipologradouro.Enabled = true;
                this.txt_endereco.Enabled = false;
                this.txt_numero.Enabled = true;
                this.txt_complemento.Enabled = true;
                this.txt_bairro.Enabled = false;
                this.txt_cidade.Enabled = false;
                this.cbo_estado.Enabled = false;
                this.txt_msktelfixo.Enabled = true;
                this.txt_msktelfixocomercial.Enabled = true;
                this.txt_msktelcelular1.Enabled = true;
                this.txt_msktelcelular2.Enabled = true;
                this.txt_email.Enabled = true;
                this.txt_contato.Enabled = true;
                this.txt_obs.Enabled = true;
                #endregion
            }
            if (cbo_tipopessoa.Text == "Pessoa Jurídica")
            {
                #region 'DETERMINAR AÇÕES'

                txt_mskdatanascimento.Text = "";
                txt_mskdatanascimento.Text = "01/01/0001";
                txt_mskdatanascimento.Enabled = false;

                txt_mskcpf.Text = "";
                txt_mskcpf.Text = "000.000.000-00";
                txt_mskcpf.Enabled = false;

                txt_rg.Text = "";
                txt_rg.Text = "00000000";
                txt_rg.Enabled = false;

                txt_mskdataexprg.Text = "";
                txt_mskdataexprg.Text = "01/01/0001";
                txt_mskdataexprg.Enabled = false;

                txt_nacionalidade.Text = "";
                txt_nacionalidade.Text = "Nada";
                txt_nacionalidade.Enabled = false;

                txt_naturalidade.Text = "";
                txt_naturalidade.Text = "Nada";
                txt_naturalidade.Enabled = false;

                cbo_estadocivil.Text = "";
                cbo_estadocivil.Text = "Nada";
                cbo_estadocivil.Enabled = false;

                cbo_grauinstrucao.Text = "";
                cbo_grauinstrucao.Text = "Nada";
                cbo_grauinstrucao.Enabled = false;

                txt_ctps.Text = "";
                txt_ctps.Text = "00000000000";
                txt_ctps.Enabled = false;

                txt_seriectps.Text = "";
                txt_seriectps.Text = "0000";
                txt_seriectps.Enabled = false;

                txt_mskdataexpctps.Text = "";
                txt_mskdataexpctps.Text = "01/01/0001";
                txt_mskdataexpctps.Enabled = false;

                txt_pispasep.Text = "";
                txt_pispasep.Text = "00000000000";
                txt_pispasep.Enabled = false;

                txt_tituloeleitor.Text = "";
                txt_tituloeleitor.Text = "000000000000";
                txt_tituloeleitor.Enabled = false;

                txt_titulozona.Text = "";
                txt_titulozona.Text = "00000";
                txt_titulozona.Enabled = false;

                txt_titulosecao.Text = "";
                txt_titulosecao.Text = "00000";
                txt_titulosecao.Enabled = false;

                cbo_valetransporte.Text = "";
                cbo_valetransporte.Text = "Nada";
                cbo_valetransporte.Enabled = false;

                cbo_tipoadmissao.Text = "";
                cbo_tipoadmissao.Text = "Nada";
                cbo_tipoadmissao.Enabled = false;

                txt_funcao.Text = "";
                txt_funcao.Text = "Nada";
                txt_funcao.Enabled = false;

                txt_salarioregistrado.Text = "";
                txt_salarioregistrado.Text = "0,00";
                txt_salarioregistrado.Enabled = false;

                txt_salariototal.Text = "";
                txt_salariototal.Text = "0,00";
                txt_salariototal.Enabled = false;

                txt_nomemae.Text = "";
                txt_nomemae.Text = "Nada";
                txt_nomemae.Enabled = false;

                txt_nomepai.Text = "";
                txt_nomepai.Text = "Nada";
                txt_nomepai.Enabled = false;

                txt_narmario.Text = "";
                txt_narmario.Text = "00";
                txt_narmario.Enabled = false;

                txt_mskdatacomecou.Text = "";
                txt_mskdatacomecou.Text = "01/01/0001";
                txt_mskdatacomecou.Enabled = false;

                txt_mskdataadmissao.Text = "";
                txt_mskdataadmissao.Text = "01/01/0001";
                txt_mskdataadmissao.Enabled = false;

                txt_mskdatademissao.Text = "";
                txt_mskdatademissao.Text = "01/01/0001";
                txt_mskdatademissao.Enabled = false;
                #endregion

                #region 'LIMPAR CAIXAS'
                //CABEÇALHO
                //this.txt_id.Text = "";
                //this.txt_datacadastro.Text = "";
                //this.cbo_status.Text = "";
                //this.cbo_tipocadastro.Text = "";
                //this.cbo_tipopessoa.Text = "";
                //DADOS PRINCIPAIS
                this.txt_nomerazao.Text = "";
                this.txt_nomefantasia.Text = "";
                this.txt_mskdataabertura.Text = "";
                this.txt_mskcnpj.Text = "";
                this.txt_inscricaoestadual.Text = "";
                this.txt_inscricaomunicipal.Text = "";
                //this.txt_mskdatanascimento.Text = "";
                //this.txt_mskcpf.Text = "";
                //this.txt_rg.Text = "";
                //this.txt_mskdataexprg.Text = "";
                //this.txt_nacionalidade.Text = "";
                //this.txt_naturalidade.Text = "";
                //this.cbo_estadocivil.Text = "";
                //DADOS SECUNDÁRIOS
                //this.cbo_grauinstrucao.Text = "";
                //this.txt_ctps.Text = "";
                //this.txt_seriectps.Text = "";
                //this.txt_mskdataexpctps.Text = "";
                //this.txt_pispasep.Text = "";
                //this.txt_tituloeleitor.Text = "";
                //this.txt_titulozona.Text = "";
                //this.txt_titulosecao.Text = "";
                //this.cbo_valetransporte.Text = "";
                //this.cbo_tipoadmissao.Text = "";
                //this.txt_funcao.Text = "";
                //this.txt_salarioregistrado.Text = "";
                //this.txt_salariototal.Text = "";
                //this.txt_nomemae.Text = "";
                //this.txt_nomepai.Text = "";
                //this.txt_narmario.Text = "";
                //this.txt_mskdatacomecou.Text = "";
                //this.txt_mskdataadmissao.Text = "";
                //this.txt_mskdatademissao.Text = "";
                //ENDEREÇO|CONTATO
                this.txt_mskcep.Text = "";
                this.cbo_tipologradouro.Text = "";
                this.txt_endereco.Text = "";
                this.txt_numero.Text = "";
                this.txt_complemento.Text = "";
                this.txt_bairro.Text = "";
                this.txt_cidade.Text = "";
                this.cbo_estado.Text = "";
                this.txt_msktelfixo.Text = "";
                this.txt_msktelfixocomercial.Text = "";
                this.txt_msktelcelular1.Text = "";
                this.txt_msktelcelular2.Text = "";
                this.txt_email.Text = "";
                this.txt_contato.Text = "";
                this.txt_obs.Text = "";
                #endregion

                #region 'ATIVAR|DESATIVAR CAIXAS'
                //CABEÇALHO
                this.txt_id.Enabled = false;
                this.txt_datacadastro.Enabled = false;
                this.cbo_status.Enabled = true;
                this.cbo_tipocadastro.Enabled = true;
                this.cbo_tipopessoa.Enabled = true;
                //DADOS PRINCIPAIS
                this.txt_nomerazao.Enabled = true;
                this.txt_nomefantasia.Enabled = true;
                this.txt_mskdataabertura.Enabled = true;
                this.txt_mskcnpj.Enabled = true;
                this.txt_inscricaoestadual.Enabled = true;
                this.txt_inscricaomunicipal.Enabled = true;
                //this.txt_mskdatanascimento.Enabled = true;
                //this.txt_mskcpf.Enabled = true;
                //this.txt_rg.Enabled = true;
                //this.txt_mskdataexprg.Enabled = true;
                //this.txt_nacionalidade.Enabled = true;
                //this.txt_naturalidade.Enabled = true;
                //this.cbo_estadocivil.Enabled = true;
                //DADOS SECUNDÁRIOS
                //this.cbo_grauinstrucao.Enabled = true;
                //this.txt_ctps.Enabled = true;
                //this.txt_seriectps.Enabled = true;
                //this.txt_mskdataexpctps.Enabled = true;
                //this.txt_pispasep.Enabled = true;
                //this.txt_tituloeleitor.Enabled = true;
                //this.txt_titulozona.Enabled = true;
                //this.txt_titulosecao.Enabled = true;
                //this.cbo_valetransporte.Enabled = true;
                //this.cbo_tipoadmissao.Enabled = true;
                //this.txt_funcao.Enabled = true;
                //this.txt_salarioregistrado.Enabled = true;
                //this.txt_salariototal.Enabled = true;
                //this.txt_nomemae.Enabled = true;
                //this.txt_nomepai.Enabled = true;
                //this.txt_narmario.Enabled = true;
                //this.txt_mskdatacomecou.Enabled = true;
                //this.txt_mskdataadmissao.Enabled = true;
                //this.txt_mskdatademissao.Enabled = true;
                //ENDEREÇO|CONTATO
                this.txt_mskcep.Enabled = true;
                this.cbo_tipologradouro.Enabled = true;
                this.txt_endereco.Enabled = false;
                this.txt_numero.Enabled = true;
                this.txt_complemento.Enabled = true;
                this.txt_bairro.Enabled = false;
                this.txt_cidade.Enabled = false;
                this.cbo_estado.Enabled = false;
                this.txt_msktelfixo.Enabled = true;
                this.txt_msktelfixocomercial.Enabled = true;
                this.txt_msktelcelular1.Enabled = true;
                this.txt_msktelcelular2.Enabled = true;
                this.txt_email.Enabled = true;
                this.txt_contato.Enabled = true;
                this.txt_obs.Enabled = true;
                #endregion
            }
            if (cbo_tipopessoa.Text == "")
            {
                #region 'LIMPAR CAIXAS'
                //CABEÇALHO
                //this.txt_id.Text = "";
                //this.txt_datacadastro.Text = "";
                this.cbo_status.Text = "";
                this.cbo_tipocadastro.Text = "";
                this.cbo_tipopessoa.Text = "";
                //DADOS PRINCIPAIS
                this.txt_nomerazao.Text = "";
                this.txt_nomefantasia.Text = "";
                this.txt_mskdataabertura.Text = "";
                this.txt_mskcnpj.Text = "";
                this.txt_inscricaoestadual.Text = "";
                this.txt_inscricaomunicipal.Text = "";
                this.txt_mskdatanascimento.Text = "";
                this.txt_mskcpf.Text = "";
                this.txt_rg.Text = "";
                this.txt_mskdataexprg.Text = "";
                this.txt_nacionalidade.Text = "";
                this.txt_naturalidade.Text = "";
                this.cbo_estadocivil.Text = "";
                //DADOS SECUNDÁRIOS
                this.cbo_grauinstrucao.Text = "";
                this.txt_ctps.Text = "";
                this.txt_seriectps.Text = "";
                this.txt_mskdataexpctps.Text = "";
                this.txt_pispasep.Text = "";
                this.txt_tituloeleitor.Text = "";
                this.txt_titulozona.Text = "";
                this.txt_titulosecao.Text = "";
                this.cbo_valetransporte.Text = "";
                this.cbo_tipoadmissao.Text = "";
                this.txt_funcao.Text = "";
                this.txt_salarioregistrado.Text = "";
                this.txt_salariototal.Text = "";
                this.txt_nomemae.Text = "";
                this.txt_nomepai.Text = "";
                this.txt_narmario.Text = "";
                this.txt_mskdatacomecou.Text = "";
                this.txt_mskdataadmissao.Text = "";
                this.txt_mskdatademissao.Text = "";
                //ENDEREÇO|CONTATO
                this.txt_mskcep.Text = "";
                this.cbo_tipologradouro.Text = "";
                this.txt_endereco.Text = "";
                this.txt_numero.Text = "";
                this.txt_complemento.Text = "";
                this.txt_bairro.Text = "";
                this.txt_cidade.Text = "";
                this.cbo_estado.Text = "";
                this.txt_msktelfixo.Text = "";
                this.txt_msktelfixocomercial.Text = "";
                this.txt_msktelcelular1.Text = "";
                this.txt_msktelcelular2.Text = "";
                this.txt_email.Text = "";
                this.txt_contato.Text = "";
                this.txt_obs.Text = "";
                #endregion

                #region 'ATIVAR|DESATIVAR CAIXAS'
                //CABEÇALHO
                this.txt_id.Enabled = false;
                this.txt_datacadastro.Enabled = false;
                this.cbo_status.Enabled = true;
                this.cbo_tipocadastro.Enabled = true;
                this.cbo_tipopessoa.Enabled = true;
                //DADOS PRINCIPAIS
                this.txt_nomerazao.Enabled = true;
                this.txt_nomefantasia.Enabled = true;
                this.txt_mskdataabertura.Enabled = true;
                this.txt_mskcnpj.Enabled = true;
                this.txt_inscricaoestadual.Enabled = true;
                this.txt_inscricaomunicipal.Enabled = true;
                this.txt_mskdatanascimento.Enabled = true;
                this.txt_mskcpf.Enabled = true;
                this.txt_rg.Enabled = true;
                this.txt_mskdataexprg.Enabled = true;
                this.txt_nacionalidade.Enabled = true;
                this.txt_naturalidade.Enabled = true;
                this.cbo_estadocivil.Enabled = true;
                //DADOS SECUNDÁRIOS
                this.cbo_grauinstrucao.Enabled = true;
                this.txt_ctps.Enabled = true;
                this.txt_seriectps.Enabled = true;
                this.txt_mskdataexpctps.Enabled = true;
                this.txt_pispasep.Enabled = true;
                this.txt_tituloeleitor.Enabled = true;
                this.txt_titulozona.Enabled = true;
                this.txt_titulosecao.Enabled = true;
                this.cbo_valetransporte.Enabled = true;
                this.cbo_tipoadmissao.Enabled = true;
                this.txt_funcao.Enabled = true;
                this.txt_salarioregistrado.Enabled = true;
                this.txt_salariototal.Enabled = true;
                this.txt_nomemae.Enabled = true;
                this.txt_nomepai.Enabled = true;
                this.txt_narmario.Enabled = true;
                this.txt_mskdatacomecou.Enabled = true;
                this.txt_mskdataadmissao.Enabled = true;
                this.txt_mskdatademissao.Enabled = true;
                //ENDEREÇO|CONTATO
                this.txt_mskcep.Enabled = true;
                this.cbo_tipologradouro.Enabled = true;
                this.txt_endereco.Enabled = false;
                this.txt_numero.Enabled = true;
                this.txt_complemento.Enabled = true;
                this.txt_bairro.Enabled = false;
                this.txt_cidade.Enabled = false;
                this.cbo_estado.Enabled = false;
                this.txt_msktelfixo.Enabled = true;
                this.txt_msktelfixocomercial.Enabled = true;
                this.txt_msktelcelular1.Enabled = true;
                this.txt_msktelcelular2.Enabled = true;
                this.txt_email.Enabled = true;
                this.txt_contato.Enabled = true;
                this.txt_obs.Enabled = true;
                #endregion
            }
            #endregion
        }

        private void txt_salarioregistrado_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_salarioregistrado);
            txt_salarioregistrado.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txt_salariototal_TextChanged(object sender, EventArgs e)
        {
            #region 'FORMATAÇÃO MOEDA'
            //BUSCANDO A REFERÊNCIA DE FORMATAÇÃO
            Moeda(ref txt_salariototal);
            txt_salariototal.TextAlign = HorizontalAlignment.Center;
            #endregion
        }

        private void txt_ctps_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_seriectps_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_pispasep_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_tituloeleitor_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_titulozona_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_titulosecao_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_salarioregistrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_salariototal_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_narmario_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void cbo_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_tipocadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_tipopessoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_estadocivil_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_grauinstrucao_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_valetransporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_tipoadmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_tipologradouro_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void cbo_estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }

        private void txt_mskcep_Leave(object sender, EventArgs e)
        {
            #region 'PREENCHIMENTO DE DADOS'
            if (txt_mskcep.MaskCompleted)
            {
                #region 'MENSAGEM DE VERIFICAÇÃO'
                if (MessageBox.Show("Clique SIM para preencher automaticamente!" + "\n" + "Clique NÂO para preencher manualmente!", "Preenchimento ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    #region 'COMEÇA A BUSCA E O TRATAMENTO DE ERRO'
                    using (var ws = new WSCorreios.AtendeClienteClient())
                    {
                        try
                        {
                            #region 'REPASSA OS DADOS'
                            var resultado = ws.consultaCEP(txt_mskcep.Text);
                            txt_endereco.Text = resultado.end;
                            txt_bairro.Text = resultado.bairro;
                            txt_cidade.Text = resultado.cidade;
                            cbo_estado.Text = resultado.uf;
                            #endregion

                            #region 'ATIVA/DESATIVA AS CAIXAS'
                            txt_mskcep.Enabled = true;
                            txt_endereco.Enabled = false;
                            txt_numero.Enabled = true;
                            txt_bairro.Enabled = false;
                            txt_cidade.Enabled = false;
                            cbo_estado.Enabled = false;
                            #endregion

                            #region 'COLOCA O FOCO'
                            cbo_tipologradouro.Focus();
                            #endregion
                        }
                        catch (Exception)
                        {
                            #region 'MENSAGEM'
                            //MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            #endregion

                            #region 'MENSAGEM'
                            MessageBox.Show("CEP não encontrado!");
                            #endregion

                            #region 'LIMPA AS CAIXAS'
                            txt_mskcep.Text = "";
                            txt_endereco.Text = "";
                            txt_numero.Text = "";
                            txt_bairro.Text = "";
                            txt_cidade.Text = "";
                            cbo_estado.Text = "";
                            #endregion

                            #region 'ATIVA/DESATIVA AS CAIXAS'
                            txt_mskcep.Enabled = true;
                            txt_endereco.Enabled = true;
                            txt_numero.Enabled = true;
                            txt_bairro.Enabled = true;
                            txt_cidade.Enabled = true;
                            cbo_estado.Enabled = true;
                            #endregion

                            #region 'COLOCA O FOCO'
                            txt_mskcep.Focus();
                            #endregion
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 'LIMPA AS CAIXAS'
                    //txt_mskcep.Text = "";
                    txt_endereco.Text = "";
                    txt_numero.Text = "";
                    txt_bairro.Text = "";
                    txt_cidade.Text = "";
                    cbo_estado.Text = "";
                    #endregion

                    #region 'ATIVA/DESATIVA AS CAIXAS'
                    txt_mskcep.Enabled = false;
                    txt_endereco.Enabled = true;
                    txt_numero.Enabled = true;
                    txt_bairro.Enabled = true;
                    txt_cidade.Enabled = true;
                    cbo_estado.Enabled = true;
                    #endregion

                    #region 'COLOCA O FOCO'
                    cbo_tipologradouro.Focus();
                    #endregion
                }
                #endregion
            }
            else
            {
                #region 'MENSAGEM'
                MessageBox.Show("Informe um CEP válido...");
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_mskcep.Text = "";
                txt_endereco.Text = "";
                txt_numero.Text = "";
                txt_bairro.Text = "";
                txt_cidade.Text = "";
                cbo_estado.Text = "";
                #endregion

                #region 'ATIVA/DESATIVA AS CAIXAS'
                txt_mskcep.Enabled = true;
                txt_endereco.Enabled = true;
                txt_numero.Enabled = true;
                txt_bairro.Enabled = true;
                txt_cidade.Enabled = true;
                cbo_estado.Enabled = true;
                #endregion

                #region 'COLOCA O FOCO'
                txt_mskcep.Focus();
                #endregion
            }
            #endregion                                    
        }

        private void txt_mskdataabertura_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
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
                txt_mskdataabertura.Text = "";
                txt_mskdataabertura.Focus();
            }
            #endregion
        }

        private void txt_mskdatanascimento_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
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
                txt_mskdatanascimento.Text = "";
                txt_mskdatanascimento.Focus();
            }
            #endregion
        }

        private void txt_mskdataexprg_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
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
                txt_mskdataexprg.Text = "";
                txt_mskdataexprg.Focus();
            }
            #endregion
        }
        
        private void txt_mskdataexpctps_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
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
                txt_mskdataexpctps.Text = "";
                txt_mskdataexpctps.Focus();
            }
            #endregion
        }

        private void txt_mskdatacomecou_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
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
                txt_mskdatacomecou.Text = "";
                txt_mskdatacomecou.Focus();
            }
            #endregion
        }

        private void txt_mskdataadmissao_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
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
                txt_mskdataadmissao.Text = "";
                txt_mskdataadmissao.Focus();
            }
            #endregion
        }

        private void txt_mskdatademissao_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
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
                txt_mskdatademissao.Text = "";
                txt_mskdatademissao.Focus();
            }
            #endregion
        }
    }
}
