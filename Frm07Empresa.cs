using Correios.Net;
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
    public partial class Frm07Empresa : Form
    {
        public Frm07Empresa()
        {
            InitializeComponent();
        }

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

        private void Frm07Empresa_KeyDown(object sender, KeyEventArgs e)
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

        private void Frm07Empresa_Load(object sender, EventArgs e)
        {
            #region 'PREENCHE AS COMBOBOX'          
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

            #region 'VERIFICA SE TEM EMPRESA CADASTRADA E CARREGA OS DADOS'
            
            #region 'DECLARANDO VARIAVEL E DEIXANDO LIMPA'
            string codigo = string.Empty;
            string empresa = string.Empty;
            string cnpj = string.Empty;
            string endereco = string.Empty;
            string numero = string.Empty;
            string cep = string.Empty;
            string bairro = string.Empty;
            string cidade = string.Empty;
            string estado = string.Empty;
            string email = string.Empty;
            string telfixo = string.Empty;
            string telcelular = string.Empty;
            string datacadastro = string.Empty;
            #endregion

            #region 'COMANDO PARA SELECIONAR OS DADOS DO BANCO'
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "SELECT * FROM tb05empresaestabelecimento where ID = " + 1 + ""; //Seleciona a tabela e procura os dados            
            MySqlDataReader reader = cmd.ExecuteReader(); //Executa o comando selecionar
            #endregion

            #region 'FAZ A LEITURA E REPASSA OS DADOS PARA VARIAVEL'
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    codigo = reader.GetString("ID");
                    empresa = reader.GetString("Empresa");
                    cnpj = reader.GetString("Cnpj");
                    endereco = reader.GetString("Endereco");
                    numero = reader.GetString("Numero");
                    cep = reader.GetString("Cep");
                    bairro = reader.GetString("Bairro");
                    cidade = reader.GetString("Cidade");
                    estado = reader.GetString("Estado");
                    email = reader.GetString("Email");
                    telfixo = reader.GetString("TelFixo");
                    telcelular = reader.GetString("TelCelular");
                    datacadastro = reader.GetString("DataCadastro");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }
            #endregion

            #region 'VERIFICA SE A DATA NÃO ESTA VAZIA E CONVERTE O FORMATO DA DATA'
            if  (datacadastro != "")
            {
                //CONVERTENDO O FORMATO DA DATA
                var dataformatada = DateTime.Parse(datacadastro).ToString("dd-MM-yyyy");

                #region 'REPASSANDO OS DADOS DA VARIAVEL PARA AS CAIXAS'
                txt_id.Text = codigo;
                txt_empresa.Text = empresa;
                txtmsk_cnpj.Text = cnpj;
                txt_endereco.Text = endereco;
                txt_numero.Text = numero;
                txtmsk_cep.Text = cep;
                txt_bairro.Text = bairro;
                txt_cidade.Text = cidade;
                cbo_estado.Text = estado;
                txt_email.Text = email;
                txtmsk_telfixo.Text = telfixo;
                txtmsk_telcelular.Text = telcelular;
                txt_datacadastro.Text = dataformatada;
                #endregion
            }
            else
            {
                #region 'REPASSANDO OS DADOS DA VARIAVEL PARA AS CAIXAS'
                txt_id.Text = codigo;
                txt_empresa.Text = empresa;
                txtmsk_cnpj.Text = cnpj;
                txt_endereco.Text = endereco;
                txt_numero.Text = numero;
                txtmsk_cep.Text = cep;
                txt_bairro.Text = bairro;
                txt_cidade.Text = cidade;
                cbo_estado.Text = estado;
                txt_email.Text = email;
                txtmsk_telfixo.Text = telfixo;
                txtmsk_telcelular.Text = telcelular;
                txt_datacadastro.Text = datacadastro;
                #endregion
            }
            #endregion
                       
            #region 'VERIFICA A CAIXA'
            if (txt_id.Text != "")
            {
                #region 'ATIVAR/DESATIVAR CAIXAS'
                txt_id.Enabled = false;
                txt_empresa.Enabled = false;
                txtmsk_cnpj.Enabled = false;
                txt_endereco.Enabled = false;
                txt_numero.Enabled = false;
                txtmsk_cep.Enabled = false;
                txt_bairro.Enabled = false;
                txt_cidade.Enabled = false;
                cbo_estado.Enabled = false;
                txt_email.Enabled = false;
                txtmsk_telfixo.Enabled = false;
                txtmsk_telcelular.Enabled = false;
                txt_datacadastro.Enabled = false;
                #endregion

                #region 'ATIVAR/DESATIVAR BOTOES'
                btn_gravar.Enabled = false;
                btn_editar.Enabled = true;
                btn_alterar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_sair.Enabled = true;
                btnCerrar.Enabled = true;
                #endregion
            }
            else
            {
                #region 'CADASTRAR EMPRESA'

                #region 'MENSAGEM'
                MessageBox.Show("Cadastre sua Empresa!");
                #endregion

                #region 'PREENCHENDO A CAIXA DATA COM DATA ATUAL'
                //CAPTURAR DATA
                string DateTime = System.DateTime.Now.ToShortDateString();
                //PREENCHENDO AS CAIXAS
                txt_datacadastro.Text = (DateTime);
                #endregion

                #region 'ATIVAR/DESATIVAR CAIXAS'
                txt_id.Enabled = false;
                txt_empresa.Enabled = true;
                txtmsk_cnpj.Enabled = true;
                txtmsk_cep.Enabled = true;
                txt_endereco.Enabled = false;
                txt_numero.Enabled = true;
                txt_bairro.Enabled = false;
                txt_cidade.Enabled = false;
                cbo_estado.Enabled = false;
                txt_email.Enabled = true;
                txtmsk_telfixo.Enabled = true;
                txtmsk_telcelular.Enabled = true;
                txt_datacadastro.Enabled = false;
                #endregion

                #region 'ATIVAR/DESATIVAR BOTOES'
                btn_gravar.Enabled = true;
                btn_editar.Enabled = false;
                btn_alterar.Enabled = false;
                btn_cancelar.Enabled = true;
                btn_sair.Enabled = true;
                btnCerrar.Enabled = false;
                #endregion

                #region 'COLOCA O FOCO'
                txt_empresa.Focus();
                #endregion

                #endregion
            }
            #endregion

            #endregion
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            #region 'COMEÇA A GRAVAÇÃO'
            //BUSCA A FORMATAÇÃO DA DATA
            string dataformatada = Formatadata(txt_datacadastro.Text);
            try
            {
                #region 'VERIFICA SE AS CAIXAS ESTÃO PREENCHIDAS PARA GRAVAR'
                // VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_empresa.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_empresa.Focus();
                    return;
                }
                if (!txtmsk_cnpj.MaskCompleted)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmsk_cnpj.Text = "";
                    this.txtmsk_cnpj.Focus();
                    return;
                }
                if (txt_endereco.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_endereco.Focus();
                    return;
                }
                if (txt_numero.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_numero.Focus();
                    return;
                }
                if (!txtmsk_cep.MaskCompleted)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmsk_cep.Text = "";
                    this.txtmsk_cep.Focus();
                    return;
                }
                if (txt_bairro.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_bairro.Focus();
                    return;
                }
                if (txt_cidade.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_cidade.Focus();
                    return;
                }
                if (cbo_estado.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_estado.Focus();
                    return;
                }
                if (txt_email.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_email.Focus();
                    return;
                }
                if (!txtmsk_telfixo.MaskCompleted)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmsk_telfixo.Text = "";
                    this.txtmsk_telfixo.Focus();
                    return;
                }
                if (!txtmsk_telcelular.MaskCompleted)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmsk_telcelular.Text = "";
                    this.txtmsk_telcelular.Focus();
                    return;
                }
                #endregion

                #region 'COMANDO PARA GRAVAR'
                //Começa o comando para gravar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "Insert Into tb05empresaestabelecimento(Empresa,Cnpj,Endereco,Numero,Cep,Bairro,Cidade,Estado,Email,TelFixo,TelCelular,DataCadastro) " +
                "Values (@Empresa,@Cnpj,@Endereco,@Numero,@Cep,@Bairro,@Cidade,@Estado,@Email,@TelFixo,@TelCelular,@DataCadastro)";
                cmd.Parameters.AddWithValue("@Empresa", txt_empresa.Text);
                cmd.Parameters.AddWithValue("@Cnpj", txtmsk_cnpj.Text);
                cmd.Parameters.AddWithValue("@Endereco", txt_endereco.Text);
                cmd.Parameters.AddWithValue("@Numero", txt_numero.Text);
                cmd.Parameters.AddWithValue("@Cep", txtmsk_cep.Text);
                cmd.Parameters.AddWithValue("@Bairro", txt_bairro.Text);
                cmd.Parameters.AddWithValue("@Cidade", txt_cidade.Text);
                cmd.Parameters.AddWithValue("@Estado", cbo_estado.Text);
                cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                cmd.Parameters.AddWithValue("@TelFixo", txtmsk_telfixo.Text);
                cmd.Parameters.AddWithValue("@TelCelular", txtmsk_telcelular.Text);
                cmd.Parameters.AddWithValue("@DataCadastro", dataformatada);           
                cmd.ExecuteNonQuery();
                cmd.Connection.Close(); //Fecha a conexão
                #endregion

                #region 'MENSAGEM'
                //MENSAGEM DE EXECUÇÃO
                MessageBox.Show("Empresa Cadastrada com Sucesso!!!");
                #endregion

                #region 'ATIVA/DESATIVA AS CAIXAS'
                txt_id.Enabled = false;
                txt_empresa.Enabled = false;
                txtmsk_cnpj.Enabled = false;
                txt_endereco.Enabled = false;
                txt_numero.Enabled = false;
                txtmsk_cep.Enabled = false;
                txt_bairro.Enabled = false;
                txt_cidade.Enabled = false;
                cbo_estado.Enabled = false;
                txt_email.Enabled = false;
                txtmsk_telfixo.Enabled = false;
                txtmsk_telcelular.Enabled = false;
                txt_datacadastro.Enabled = false;
                #endregion

                #region 'ATIVA/DESATIVA OS BOTOES'
                btn_gravar.Enabled = false;
                btn_editar.Enabled = true;
                btn_alterar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_sair.Enabled = true;
                btnCerrar.Enabled = true;
                #endregion
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            #endregion
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            #region 'ATIVA/DESATIVA AS CAIXAS'
            //Ativar/Desativar caixas
            txt_id.Enabled = false;
            txt_empresa.Enabled = true;
            txtmsk_cnpj.Enabled = true;
            txtmsk_cep.Enabled = true;
            txt_endereco.Enabled = false;
            txt_numero.Enabled = true;
            txt_bairro.Enabled = false;
            txt_cidade.Enabled = false;
            cbo_estado.Enabled = false;
            txt_email.Enabled = true;
            txtmsk_telfixo.Enabled = true;
            txtmsk_telcelular.Enabled = true;
            txt_datacadastro.Enabled = false;
            #endregion

            #region 'ATIVA/DESATIVA OS BOTÕES'
            btn_gravar.Enabled = false;
            btn_editar.Enabled = false;
            btn_alterar.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_sair.Enabled = false;
            btnCerrar.Enabled = false;
            #endregion
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            #region 'COMEÇA A ALTERAÇÃO'
            //BUSCA A FORMATAÇÃO DA DATA
            string dataformatada = Formatadata(txt_datacadastro.Text);
            try
            {
                #region 'VERIFICA SE AS CAIXAS ESTÃO PREENCHIDAS PARA GRAVAR'
                // VERIFICAR CAIXAS VAZIAS PARA NÃO GRAVAR
                if (txt_empresa.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_empresa.Focus();
                    return;
                }
                if (!txtmsk_cnpj.MaskCompleted)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmsk_cnpj.Text = "";
                    this.txtmsk_cnpj.Focus();
                    return;
                }
                if (txt_endereco.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_endereco.Focus();
                    return;
                }
                if (txt_numero.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_numero.Focus();
                    return;
                }
                if (!txtmsk_cep.MaskCompleted)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmsk_cep.Text = "";
                    this.txtmsk_cep.Focus();
                    return;
                }
                if (txt_bairro.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_bairro.Focus();
                    return;
                }
                if (txt_cidade.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_cidade.Focus();
                    return;
                }
                if (cbo_estado.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cbo_estado.Focus();
                    return;
                }
                if (txt_email.Text == string.Empty)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txt_email.Focus();
                    return;
                }
                if (!txtmsk_telfixo.MaskCompleted)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmsk_telfixo.Text = "";
                    this.txtmsk_telfixo.Focus();
                    return;
                }
                if (!txtmsk_telcelular.MaskCompleted)
                {
                    MessageBox.Show("Preencha todos os campos para cadastrar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtmsk_telcelular.Text = "";
                    this.txtmsk_telcelular.Focus();
                    return;
                }
                #endregion

                #region 'COMANDO PARA ALTERAR'
                //Começa o comando para alterar
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
                cmd.CommandText = "update tb05empresaestabelecimento set " +
                "Empresa = @Empresa, " +
                "Cnpj = @Cnpj, " +
                "Endereco = @Endereco, " +
                "Numero = @Numero, " +
                "Cep = @Cep, " +
                "Bairro = @Bairro, " +
                "Cidade = @Cidade, " +
                "Estado = @Estado, " +
                "Email = @Email, " +
                "TelFixo = @TelFixo, " +
                "TelCelular = @TelCelular, " +
                "DataCadastro = @DataCadastro " +
                "Where ID = @ID";
                cmd.Parameters.AddWithValue("@ID", txt_id.Text);
                cmd.Parameters.AddWithValue("@Empresa", txt_empresa.Text);
                cmd.Parameters.AddWithValue("@Cnpj", txtmsk_cnpj.Text);
                cmd.Parameters.AddWithValue("@Endereco", txt_endereco.Text);
                cmd.Parameters.AddWithValue("@Numero", txt_numero.Text);
                cmd.Parameters.AddWithValue("@Cep", txtmsk_cep.Text);
                cmd.Parameters.AddWithValue("@Bairro", txt_bairro.Text);
                cmd.Parameters.AddWithValue("@Cidade", txt_cidade.Text);
                cmd.Parameters.AddWithValue("@Estado", cbo_estado.Text);
                cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                cmd.Parameters.AddWithValue("@TelFixo", txtmsk_telfixo.Text);
                cmd.Parameters.AddWithValue("@TelCelular", txtmsk_telcelular.Text);
                cmd.Parameters.AddWithValue("@DataCadastro", dataformatada);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close(); //Fecha a conexão
                #endregion

                #region 'MENSAGEM'
                //MENSAGEM DE EXECUÇÃO
                MessageBox.Show("Dados Alterados com Sucesso!!!");
                #endregion

                #region 'ATIVA/DESATIVA AS CAIXAS'
                txt_id.Enabled = false;
                txt_empresa.Enabled = false;
                txtmsk_cnpj.Enabled = false;
                txt_endereco.Enabled = false;
                txt_numero.Enabled = false;
                txtmsk_cep.Enabled = false;
                txt_bairro.Enabled = false;
                txt_cidade.Enabled = false;
                cbo_estado.Enabled = false;
                txt_email.Enabled = false;
                txtmsk_telfixo.Enabled = false;
                txtmsk_telcelular.Enabled = false;
                txt_datacadastro.Enabled = false;
                #endregion

                #region 'ATIVA/DESATIVA OS BOTOES'
                btn_gravar.Enabled = false;
                btn_editar.Enabled = true;
                btn_alterar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_sair.Enabled = true;
                btnCerrar.Enabled = true;
                #endregion
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

            #region 'COLOCA O FOCO'
            //POSICIONA O MOUSE
            btn_sair.Focus();
            #endregion

            #endregion
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            #region 'LIMPA AS CAIXAS'
            txt_id.Text = "";
            txt_empresa.Text = "";
            txtmsk_cnpj.Text = "";
            txt_endereco.Text = "";
            txt_numero.Text = "";
            txtmsk_cep.Text = "";
            txt_bairro.Text = "";
            txt_cidade.Text = "";
            cbo_estado.Text = "";
            txt_email.Text = "";
            txtmsk_telfixo.Text = "";
            txtmsk_telcelular.Text = "";
            txt_datacadastro.Text = "";
            #endregion

            #region 'ATIVA/DESATIVA AS CAIXAS'
            //Liberar caixas
            txt_id.Enabled = false;
            txt_empresa.Enabled = false;
            txtmsk_cnpj.Enabled = false;
            txt_endereco.Enabled = false;
            txt_numero.Enabled = false;
            txtmsk_cep.Enabled = false;
            txt_bairro.Enabled = false;
            txt_cidade.Enabled = false;
            cbo_estado.Enabled = false;
            txt_email.Enabled = false;
            txtmsk_telfixo.Enabled = false;
            txtmsk_telcelular.Enabled = false;
            txt_datacadastro.Enabled = false;
            #endregion
            
            #region 'ATIVA/DESTIVA OS BOTÕES
            btn_gravar.Enabled = false;
            btn_editar.Enabled = true;
            btn_alterar.Enabled = false;
            btn_cancelar.Enabled = false;
            btn_sair.Enabled = true;
            btnCerrar.Enabled = true;
            #endregion

            #region 'INICIALIZA O FORMULARIO'
            Frm07Empresa_Load(sender, e);
            #endregion
        }

        private void btn_sair_Click(object sender, EventArgs e)
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

        private void txt_numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'BLOQUEIA ENTRADA DE LETRAS E LIBERA SOMENTE NÚMEROS'
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                //MessageBox.Show("Digite Apenas Números!!!");
            }
            #endregion
        }

        private void txtmsk_cep_Leave(object sender, EventArgs e)
        {
            #region 'PREENCHIMENTO DE DADOS'
            if (txtmsk_cep.MaskCompleted)
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
                            var resultado = ws.consultaCEP(txtmsk_cep.Text);
                            txt_endereco.Text = resultado.end;
                            txt_bairro.Text = resultado.bairro;
                            txt_cidade.Text = resultado.cidade;
                            cbo_estado.Text = resultado.uf;
                            #endregion

                            #region 'ATIVA/DESATIVA AS CAIXAS'
                            txtmsk_cep.Enabled = true;
                            txt_endereco.Enabled = false;
                            txt_numero.Enabled = true;
                            txt_bairro.Enabled = false;
                            txt_cidade.Enabled = false;
                            cbo_estado.Enabled = false;
                            #endregion

                            #region 'COLOCA O FOCO'
                            txt_numero.Focus();
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
                            txtmsk_cep.Text = "";
                            txt_endereco.Text = "";
                            txt_numero.Text = "";
                            txt_bairro.Text = "";
                            txt_cidade.Text = "";
                            cbo_estado.Text = "";
                            #endregion

                            #region 'ATIVA/DESATIVA AS CAIXAS'
                            txtmsk_cep.Enabled = true;
                            txt_endereco.Enabled = true;
                            txt_numero.Enabled = true;
                            txt_bairro.Enabled = true;
                            txt_cidade.Enabled = true;
                            cbo_estado.Enabled = true;
                            #endregion

                            #region 'COLOCA O FOCO'
                            txtmsk_cep.Focus();
                            #endregion
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 'LIMPA AS CAIXAS'
                    //txtmsk_cep.Text = "";
                    txt_endereco.Text = "";
                    txt_numero.Text = "";
                    txt_bairro.Text = "";
                    txt_cidade.Text = "";
                    cbo_estado.Text = "";
                    #endregion

                    #region 'ATIVA/DESATIVA AS CAIXAS'
                    txtmsk_cep.Enabled = false;
                    txt_endereco.Enabled = true;
                    txt_numero.Enabled = true;
                    txt_bairro.Enabled = true;
                    txt_cidade.Enabled = true;
                    cbo_estado.Enabled = true;
                    #endregion

                    #region 'COLOCA O FOCO'
                    txt_endereco.Focus();
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
                txtmsk_cep.Text = "";
                txt_endereco.Text = "";
                txt_numero.Text = "";
                txt_bairro.Text = "";
                txt_cidade.Text = "";
                cbo_estado.Text = "";
                #endregion

                #region 'ATIVA/DESATIVA AS CAIXAS'
                txtmsk_cep.Enabled = true;
                txt_endereco.Enabled = true;
                txt_numero.Enabled = true;
                txt_bairro.Enabled = true;
                txt_cidade.Enabled = true;
                cbo_estado.Enabled = true;
                #endregion

                #region 'COLOCA O FOCO'
                txtmsk_cep.Focus();
                #endregion
            }
            #endregion                                    
        }

        private string Formatadata(string dataBR)
        {
            #region 'FORMATAÇÃO DE DATA'
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

        private void cbo_estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region "CANCELA DIGITAÇÃO COMBOBOX"
            e.Handled = true;
            #endregion
        }
    }
}
