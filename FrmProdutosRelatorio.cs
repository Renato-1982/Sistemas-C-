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
    public partial class FrmProdutosRelatorio : Form
    {
        public FrmProdutosRelatorio()
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

        private void FrmProdutosRelatorio_KeyDown(object sender, KeyEventArgs e)
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

        private void tc_cadastroprodutos_DrawItem(object sender, DrawItemEventArgs e)
        {
            #region 'MUDA A COR DA GUIA AO CLICAR'

            //FORMATAÇÃO DA TABCONTROL'
            TabPage CurrentTab = tc_cadastroprodutos.TabPages[e.Index];
            Rectangle ItemRect = tc_cadastroprodutos.GetTabRect(e.Index);
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
            if (tc_cadastroprodutos.Alignment == TabAlignment.Left || tc_cadastroprodutos.Alignment == TabAlignment.Right)
            {
                float RotateAngle = 90;
                if (tc_cadastroprodutos.Alignment == TabAlignment.Left)
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

        private void FrmProdutosRelatorio_Load(object sender, EventArgs e)
        {
            #region 'CARREGA TUDO'
            // TODO: esta linha de código carrega dados na tabela 'sigrassystembdDataSet.tb_produtos'. 
            // Você pode movê-la ou removê-la conforme necessário.
            this.tb_produtosTableAdapter.Fill(this.sigrassystembdDataSet.tb_produtos);
            this.RVprodutosbd.RefreshReport();
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipoitem.Text = "";
            txt_tipoitemstatus.Text = "";
            txt_grupo.Text = "";
            txt_familia.Text = "";
            txt_descricaoproduto.Text = "";
            txt_eanproduto.Text = "";
            #endregion

            #region "AUTO COMPLETA AS TEXTBOX"
            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX STATUS'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd.CommandText = "Select Status from tb_produtos order by Status";
            cmd.ExecuteNonQuery();
            MySqlDataReader datareader;
            datareader = cmd.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

            while (datareader.Read())
            {
                autotext.Add(datareader.GetString(0));
            }
            txt_status.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_status.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_status.AutoCompleteCustomSource = autotext;
            cmd.Connection.Close(); //Fecha a conexão 
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX STATUS TIPO ITEM'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd1.CommandText = "Select Status from tb_produtos order by Status";
            cmd1.ExecuteNonQuery();
            MySqlDataReader datareader1;
            datareader1 = cmd1.ExecuteReader();
            AutoCompleteStringCollection autotext1 = new AutoCompleteStringCollection();

            while (datareader1.Read())
            {
                autotext1.Add(datareader1.GetString(0));
            }
            txt_statustipoitem.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_statustipoitem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_statustipoitem.AutoCompleteCustomSource = autotext1;
            cmd1.Connection.Close(); //Fecha a conexão 
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX TIPO ITEM STATUS'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd2.CommandText = "Select TipoItem from tb_produtos order by TipoItem";
            cmd2.ExecuteNonQuery();
            MySqlDataReader datareader2;
            datareader2 = cmd2.ExecuteReader();
            AutoCompleteStringCollection autotext2 = new AutoCompleteStringCollection();

            while (datareader2.Read())
            {
                autotext2.Add(datareader2.GetString(0));
            }
            txt_tipoitemstatus.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_tipoitemstatus.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_tipoitemstatus.AutoCompleteCustomSource = autotext2;
            cmd2.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX GRUPO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd3 = new MySqlCommand();
            cmd3.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd3.CommandText = "Select Grupo from tb_produtos order by Grupo";
            cmd3.ExecuteNonQuery();
            MySqlDataReader datareader3;
            datareader3 = cmd3.ExecuteReader();
            AutoCompleteStringCollection autotext3 = new AutoCompleteStringCollection();

            while (datareader3.Read())
            {
                autotext3.Add(datareader3.GetString(0));
            }
            txt_grupo.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_grupo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_grupo.AutoCompleteCustomSource = autotext3;
            cmd3.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX FAMILIA'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd4 = new MySqlCommand();
            cmd4.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd4.CommandText = "Select Familia from tb_produtos order by Familia";
            cmd4.ExecuteNonQuery();
            MySqlDataReader datareader4;
            datareader4 = cmd4.ExecuteReader();
            AutoCompleteStringCollection autotext4 = new AutoCompleteStringCollection();

            while (datareader4.Read())
            {
                autotext4.Add(datareader4.GetString(0));
            }
            txt_familia.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_familia.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_familia.AutoCompleteCustomSource = autotext4;
            cmd4.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX DESCRIÇÃO PRODUTO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd5 = new MySqlCommand();
            cmd5.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd5.CommandText = "Select DescricaoProduto from tb_produtos order by DescricaoProduto";
            cmd5.ExecuteNonQuery();
            MySqlDataReader datareader5;
            datareader5 = cmd5.ExecuteReader();
            AutoCompleteStringCollection autotext5 = new AutoCompleteStringCollection();

            while (datareader5.Read())
            {
                autotext5.Add(datareader5.GetString(0));
            }
            txt_descricaoproduto.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_descricaoproduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_descricaoproduto.AutoCompleteCustomSource = autotext5;
            cmd5.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #region 'AUTOCOMPLETE TEXTBOX EAN PRODUTO'
            //Começa o comando para selecionar e preencher
            MySqlCommand cmd6 = new MySqlCommand();
            cmd6.Connection = ClasseBDConexao.abrir(); //Abre a conexão
            cmd6.CommandText = "Select EAN from tb_produtos order by EAN";
            cmd6.ExecuteNonQuery();
            MySqlDataReader datareader6;
            datareader6 = cmd6.ExecuteReader();
            AutoCompleteStringCollection autotext6 = new AutoCompleteStringCollection();

            while (datareader6.Read())
            {
                autotext6.Add(datareader6.GetString(0));
            }
            txt_eanproduto.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_eanproduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_eanproduto.AutoCompleteCustomSource = autotext6;
            cmd6.Connection.Close(); //Fecha a conexão
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////////

            #endregion
        }

        private void btStatus_Click(object sender, EventArgs e)
        {
            #region "CARREGA O STATUS"
            if (txt_status.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_status.Text = "";
                txt_statustipoitem.Text = "";
                txt_tipoitemstatus.Text = "";
                txt_grupo.Text = "";
                txt_familia.Text = "";
                txt_descricaoproduto.Text = "";
                txt_eanproduto.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_status.Focus();
                #endregion
            }
            else
            {
                #region "CARREGA O STATUS"
                try
                {
                    this.tb_produtosTableAdapter.FillBy01Status(this.sigrassystembdDataSet.tb_produtos, txt_status.Text);
                    this.RVprodutosbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipoitem.Text = "";
            txt_tipoitemstatus.Text = "";
            txt_grupo.Text = "";
            txt_familia.Text = "";
            txt_descricaoproduto.Text = "";
            txt_eanproduto.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_status.Focus();
            #endregion
        }

        private void btStatusTipoItem_Click(object sender, EventArgs e)
        {
            #region "CARREGA O STATUS COM O TIPO ITEM"
            if (txt_statustipoitem.Text == "" || txt_tipoitemstatus.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_status.Text = "";
                txt_statustipoitem.Text = "";
                txt_tipoitemstatus.Text = "";
                txt_grupo.Text = "";
                txt_familia.Text = "";
                txt_descricaoproduto.Text = "";
                txt_eanproduto.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_statustipoitem.Focus();
                #endregion
            }
            else
            {
                #region "CARREGA O STATUS COM O TIPO ITEM"
                try
                {
                    this.tb_produtosTableAdapter.FillBy02StatusTipoItem(this.sigrassystembdDataSet.tb_produtos, txt_statustipoitem.Text, txt_tipoitemstatus.Text);
                    this.RVprodutosbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipoitem.Text = "";
            txt_tipoitemstatus.Text = "";
            txt_grupo.Text = "";
            txt_familia.Text = "";
            txt_descricaoproduto.Text = "";
            txt_eanproduto.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_statustipoitem.Focus();
            #endregion
        }

        private void btGrupo_Click(object sender, EventArgs e)
        {
            #region "CARREGA O GRUPO"
            if (txt_grupo.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_status.Text = "";
                txt_statustipoitem.Text = "";
                txt_tipoitemstatus.Text = "";
                txt_grupo.Text = "";
                txt_familia.Text = "";
                txt_descricaoproduto.Text = "";
                txt_eanproduto.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_grupo.Focus();
                #endregion
            }
            else
            {
                #region "CARREGA O GRUPO"
                try
                {
                    this.tb_produtosTableAdapter.FillBy03Grupo(this.sigrassystembdDataSet.tb_produtos, txt_grupo.Text);
                    this.RVprodutosbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipoitem.Text = "";
            txt_tipoitemstatus.Text = "";
            txt_grupo.Text = "";
            txt_familia.Text = "";
            txt_descricaoproduto.Text = "";
            txt_eanproduto.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_grupo.Focus();
            #endregion
        }

        private void btFamilia_Click(object sender, EventArgs e)
        {
            #region "CARREGA A FAMILIA"
            if (txt_familia.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_status.Text = "";
                txt_statustipoitem.Text = "";
                txt_tipoitemstatus.Text = "";
                txt_grupo.Text = "";
                txt_familia.Text = "";
                txt_descricaoproduto.Text = "";
                txt_eanproduto.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_familia.Focus();
                #endregion
            }
            else
            {
                #region "CARREGA A FAMILIA"
                try
                {
                    this.tb_produtosTableAdapter.FillBy04Familia(this.sigrassystembdDataSet.tb_produtos, txt_familia.Text);
                    this.RVprodutosbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipoitem.Text = "";
            txt_tipoitemstatus.Text = "";
            txt_grupo.Text = "";
            txt_familia.Text = "";
            txt_descricaoproduto.Text = "";
            txt_eanproduto.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_familia.Focus();
            #endregion
        }

        private void btDescricaoProduto_Click(object sender, EventArgs e)
        {
            #region "CARREGA A DESCRIÇÃO PRODUTO"
            if (txt_descricaoproduto.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_status.Text = "";
                txt_statustipoitem.Text = "";
                txt_tipoitemstatus.Text = "";
                txt_grupo.Text = "";
                txt_familia.Text = "";
                txt_descricaoproduto.Text = "";
                txt_eanproduto.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_descricaoproduto.Focus();
                #endregion
            }
            else
            {
                #region "CARREGA A DESCRIÇÃO PRODUTO"
                try
                {
                    this.tb_produtosTableAdapter.FillBy05DescricaoProduto(this.sigrassystembdDataSet.tb_produtos, txt_descricaoproduto.Text);
                    this.RVprodutosbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipoitem.Text = "";
            txt_tipoitemstatus.Text = "";
            txt_grupo.Text = "";
            txt_familia.Text = "";
            txt_descricaoproduto.Text = "";
            txt_eanproduto.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_descricaoproduto.Focus();
            #endregion
        }

        private void btEanProduto_Click(object sender, EventArgs e)
        {
            #region "CARREGA O EAN PRODUTO"
            if (txt_eanproduto.Text == "")
            {
                #region 'MENSAGEM'
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion

                #region 'LIMPA AS CAIXAS'
                txt_status.Text = "";
                txt_statustipoitem.Text = "";
                txt_tipoitemstatus.Text = "";
                txt_grupo.Text = "";
                txt_familia.Text = "";
                txt_descricaoproduto.Text = "";
                txt_eanproduto.Text = "";
                #endregion

                #region "COLOCA O FOCO" 
                txt_eanproduto.Focus();
                #endregion
            }
            else
            {
                #region "CARREGA O EAN PRODUTO"
                try
                {
                    this.tb_produtosTableAdapter.FillBy06EAN(this.sigrassystembdDataSet.tb_produtos, txt_eanproduto.Text);
                    this.RVprodutosbd.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                #endregion
            }
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipoitem.Text = "";
            txt_tipoitemstatus.Text = "";
            txt_grupo.Text = "";
            txt_familia.Text = "";
            txt_descricaoproduto.Text = "";
            txt_eanproduto.Text = "";
            #endregion

            #region "COLOCA O FOCO" 
            txt_eanproduto.Focus();
            #endregion
        }

        private void btn_carregartudo_Click(object sender, EventArgs e)
        {
            #region 'CARREGA TUDO'
            // TODO: esta linha de código carrega dados na tabela 'sigrassystembdDataSet.tb_produtos'. 
            // Você pode movê-la ou removê-la conforme necessário.
            this.tb_produtosTableAdapter.Fill(this.sigrassystembdDataSet.tb_produtos);
            this.RVprodutosbd.RefreshReport();
            #endregion

            #region 'LIMPA AS CAIXAS'
            txt_status.Text = "";
            txt_statustipoitem.Text = "";
            txt_tipoitemstatus.Text = "";
            txt_grupo.Text = "";
            txt_familia.Text = "";
            txt_descricaoproduto.Text = "";
            txt_eanproduto.Text = "";
            #endregion
        }

        private void btn_sair_Click(object sender, EventArgs e)
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

        private void txt_status_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_statustipoitem_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_tipoitemstatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_grupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_familia_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_descricaoproduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS LETRAS'
            //Aceita apenas letras
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txt_eanproduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region 'ACEITA APENAS NÚMEROS'
            //Aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            #endregion
        }
    }
}
