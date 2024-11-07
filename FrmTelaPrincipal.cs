using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGRas
{
    public partial class FrmTelaPrincipal : Form
    {
        public FrmTelaPrincipal()
        {
            InitializeComponent();
        }

        #region 'REDIMENSIONAMENTO DO FORMULÁRIO COM ELIPSE NO CANTO INFERIOR DIREITO'
        private const int tamañogrid = 10;
        private const int areamouse = 132;
        private const int botonizquierdo = 17;
        private Rectangle rectangulogrid;

        protected override void OnSizeChanged(EventArgs e)
        {
            #region 'REDIMENSIONAMENTO DO FORMULÁRIO'
            base.OnSizeChanged(e);

            var region = new Region(new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));

            rectangulogrid = new Rectangle(ClientRectangle.Width - tamañogrid, ClientRectangle.Height - tamañogrid, tamañogrid, tamañogrid);

            region.Exclude(rectangulogrid);

            pnPrincipal.Region = region;
            Invalidate();
            #endregion

            #region 'VISUALIZA BOTÕES SELECIONADOS'
            //***RELÓGIO TELA PRINCIPAL***
            lblhora.Visible = true;
            lblhora.Location = new Point(15, 10);
            //lblhora.Location = new Point(232, 203);
            lblData.Visible = true;
            lblData.Location = new Point(45, 148);
            //lblData.Location = new Point(262, 341);
            #endregion
        }

        protected override void WndProc(ref Message sms)
        {
            #region 'ELIPSE NO CANTO INFERIOR DIREITO'
            switch (sms.Msg)
            {
                case areamouse:
                    base.WndProc(ref sms);

                    var RefPoint = PointToClient(new Point(sms.LParam.ToInt32() & 0xffff, sms.LParam.ToInt32() >> 16));

                    if (!rectangulogrid.Contains(RefPoint))
                    {
                        break;
                    }

                    sms.Result = new IntPtr(botonizquierdo);
                    break;
                default:
                    base.WndProc(ref sms);
                    break;
            }
            #endregion
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            #region 'TRANSPARENCIA DA ELIPSE NO CANTO INFERIOR DIREITO  
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(64, 69, 76));

            e.Graphics.FillRectangle(solidBrush, rectangulogrid);

            base.OnPaint(e);

            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, rectangulogrid);
            #endregion
        }
        #endregion

        #region 'BOTÕES ENCERRAR,MAXIMIZAR,RESTAURAR E MINIMIZAR'
        int lx, ly;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            #region 'ENCERRAR A APLICAÇÃO'
            //FECHA O FORMULÁRIO COM MENSAGEM
            DialogResult dlgResult = MessageBox.Show("Deseja sair da aplicação ?", "Encerrar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                #region "CRIAR PASTAS SE NÃO EXISTIR NO DIRETÓRIO C:"
                //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
                string pastabkpBKPSilencioso = @"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp\BKP_Silencioso";
                if (!Directory.Exists(pastabkpBKPSilencioso))
                {
                    Directory.CreateDirectory(pastabkpBKPSilencioso);
                }
                #endregion

                #region 'COMEÇA O BACKUP'
                //Caminho do banco MySQL
                string constring = "SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;";

                //Opções de conexão adicionais importantes
                constring += "charset=utf8;convertzerodatetime=true;";

                //DEFINE O NOME DO ARQUIVO DE ACORDO COM DATA E HORA.
                string dia = DateTime.Now.Day.ToString();
                string mes = DateTime.Now.Month.ToString();
                string ano = DateTime.Now.Year.ToString();
                string hora = DateTime.Now.ToLongTimeString().Replace(":", "");
                string nomedoarquivo = "_" + dia + "-" + mes + "-" + ano + "_" + hora;

                string file = "C:/SIGRASSYSTEMBD/SIGRASSYSTEMBD_bkp/BKP_Silencioso/BKP_SIGRASSYSTEMBD_Mysql" + nomedoarquivo + ".sql";

                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
                #endregion

                #region 'MENSAGEM E SAIR'
                //MENSAGEM                
                MessageBox.Show("Sistema Encerrado!!!");
                Application.Exit();
                //this.Close();
                #endregion
            }
            #endregion
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            #region 'MAXIMIZAR'
            lx = Location.X;
            ly = Location.Y;
            sw = Size.Width;
            sh = Size.Height;

            Size = Screen.PrimaryScreen.WorkingArea.Size;
            Location = Screen.PrimaryScreen.WorkingArea.Location;

            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            #endregion

            #region 'VISUALIZA BOTÕES SELECIONADOS'
            //***RELÓGIO TELA PRINCIPAL***
            lblhora.Visible = true;
            lblhora.Location = new Point(15, 10);
            //lblhora.Location = new Point(232, 203);
            lblData.Visible = true;
            lblData.Location = new Point(45, 148);
            //lblData.Location = new Point(262, 341);
            #endregion
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            #region 'RESTAURAR'
            Size = new Size(sw, sh);
            Location = new Point(lx, ly);

            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
            #endregion

            #region 'VISUALIZA BOTÕES SELECIONADOS'
            //***RELÓGIO TELA PRINCIPAL***
            lblhora.Visible = true;
            lblhora.Location = new Point(15, 10);
            //lblhora.Location = new Point(232, 203);
            lblData.Visible = true;
            lblData.Location = new Point(45, 148);
            //lblData.Location = new Point(262, 341);
            #endregion
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            #region 'MINIMIZAR'
            WindowState = FormWindowState.Minimized;
            #endregion
        }

        private void timerTelaInicial_Tick(object sender, EventArgs e)
        {
            #region "CONTAGEM DE TEMPO (RELÓGIO) E DATA"
            //DECLARANDO VARIÁVEIS
            DateTime Data_Hora;
            Data_Hora = DateTime.Now;

            //PREENCHE A LABEL COM OS DADOS
            lblhora.Text = Data_Hora.ToLongTimeString();
            lblData.Text = Data_Hora.ToLongDateString();
            #endregion
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            #region 'ENCERRAR A APLICAÇÃO'
            //FECHA O FORMULÁRIO COM MENSAGEM
            DialogResult dlgResult = MessageBox.Show("Deseja sair da aplicação ?", "Encerrar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                #region "CRIAR PASTAS SE NÃO EXISTIR NO DIRETÓRIO C:"
                //DECLARA A VARIÁVEL E CRIA A PASTA SE NÃO EXISTIR NO DIRETÓRIO            
                string pastabkpBKPSilencioso = @"C:\SIGRASSYSTEMBD\SIGRASSYSTEMBD_bkp\BKP_Silencioso";
                if (!Directory.Exists(pastabkpBKPSilencioso))
                {
                    Directory.CreateDirectory(pastabkpBKPSilencioso);
                }
                #endregion

                #region 'COMEÇA O BACKUP'
                //Caminho do banco MySQL
                string constring = "SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;";

                //Opções de conexão adicionais importantes
                constring += "charset=utf8;convertzerodatetime=true;";

                //DEFINE O NOME DO ARQUIVO DE ACORDO COM DATA E HORA.
                string dia = DateTime.Now.Day.ToString();
                string mes = DateTime.Now.Month.ToString();
                string ano = DateTime.Now.Year.ToString();
                string hora = DateTime.Now.ToLongTimeString().Replace(":", "");
                string nomedoarquivo = "_" + dia + "-" + mes + "-" + ano + "_" + hora;

                string file = "C:/SIGRASSYSTEMBD/SIGRASSYSTEMBD_bkp/BKP_Silencioso/BKP_SIGRASSYSTEMBD_Mysql" + nomedoarquivo + ".sql";

                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
                #endregion

                #region 'MENSAGEM E SAIR'
                //MENSAGEM                
                MessageBox.Show("Sistema Encerrado!!!");
                Application.Exit();
                //this.Close();
                #endregion
            }
            #endregion
        }

        int sw, sh;

        #endregion

        private void btnSlide_Click(object sender, EventArgs e)
        {
            #region "CARREGA EMPRESA"

            #region 'DECLARA A VARIAVEL E DEIXA LIMPA'         
            string empresa = string.Empty;
            #endregion

            #region 'FAZ O SELECT E REPASSA OS DADOS'
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
                    empresa = reader.GetString("Empresa");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }

            //Repassando os dados da variável para as caixas            
            lbl_empresa.Text = empresa;
            #endregion

            #region 'VERIFICA SE ESTÁ CADASTRADO'
            if (lbl_empresa.Text != "")
            {
                #region 'CARREGA SE ESTIVER CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.ForeColor = System.Drawing.Color.White;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            else
            {
                #region 'AVISA QUE NÃO ESTÁ CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.Text = "Cadastre sua Empresa no Menu!";
                lbl_empresa.ForeColor = System.Drawing.Color.Black;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            #endregion

            #endregion
        }
        // TELA INICIAL
        private void FrmTelaPrincipal_Load(object sender, EventArgs e)
        {
            #region 'MAXIMIZAR'
            lx = Location.X;
            ly = Location.Y;
            sw = Size.Width;
            sh = Size.Height;

            Size = Screen.PrimaryScreen.WorkingArea.Size;
            Location = Screen.PrimaryScreen.WorkingArea.Location;

            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            #endregion

            #region "CARREGA EMPRESA"

            #region 'DECLARA A VARIAVEL E DEIXA LIMPA'         
            string empresa = string.Empty;
            #endregion

            #region 'FAZ O SELECT E REPASSA OS DADOS'
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
                    empresa = reader.GetString("Empresa");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }

            //Repassando os dados da variável para as caixas            
            lbl_empresa.Text = empresa;
            #endregion

            #region 'VERIFICA SE ESTÁ CADASTRADO'
            if (lbl_empresa.Text != "")
            {
                #region 'CARREGA SE ESTIVER CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.ForeColor = System.Drawing.Color.White;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            else
            {
                #region 'AVISA QUE NÃO ESTÁ CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.Text = "Cadastre sua Empresa no Menu!";
                lbl_empresa.ForeColor = System.Drawing.Color.Black;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            #endregion

            #endregion

            #region 'VISUALIZA BOTÕES SELECIONADOS'
            //***RELÓGIO TELA PRINCIPAL***
            lblhora.Visible = true;
            lblhora.Location = new Point(15, 10);
            //lblhora.Location = new Point(232, 203);
            lblData.Visible = true;
            lblData.Location = new Point(45, 148);
            //lblData.Location = new Point(262, 341);

            //***MENU***
            btnBackup.Visible = false;
            //btnBackup.Location = new Point(15, 10);
            btnCalculadora.Visible = false;
            //btnCalculadora.Location = new Point(205, 10);
            btnContatos.Visible = false;
            //btnContatos.Location = new Point(15, 80);
            btnEmpresa.Visible = false;
            //btnEmpresa.Location = new Point(205, 80);

            //***FINANCEIRO***
            btnFinanceiroCadastro.Visible = false;
            //btnFinanceiroCadastro.Location = new Point(15, 10);
            btnFinanceiroPesquisa.Visible = false;
            //btnFinanceiroPesquisa.Location = new Point(205, 10);
            btnFinanceiroRelatorio.Visible = false;
            //btnFinanceiroRelatorio.Location = new Point(15, 80);

            //***CADASTROS MÚLTIPLOS***
            btnCadastroMultiplos.Visible = false;
            //btnCadastroMultiplos.Location = new Point(15, 10);
            btnCadastroMultiplosPesquisa.Visible = false;
            //btnCadastroMultiplosPesquisa.Location = new Point(205, 10);
            btnCadastroMultiplosRelatorio.Visible = false;
            //btnCadastroMultiplosRelatorio.Location = new Point(15, 80);

            //***PRODUTOS***
            btnProdutosCadastro.Visible = false;
            //btnProdutosCadastro.Location = new Point(15, 10);
            btnProdutosPesquisa.Visible = false;
            //btnProdutosPesquisa.Location = new Point(205, 10);
            btnProdutosRelatorio.Visible = false;
            //btnProdutosRelatorio.Location = new Point(15, 80);

            //***NFs***
            btnNFsCadastro.Visible = false;
            //btnNFsCadastro.Location = new Point(15, 10);
            btnNFsPesquisa.Visible = false;
            //btnNFsPesquisa.Location = new Point(205, 10);
            btnNFsPesquisaTotal.Visible = false;
            //btnNFsPesquisaTotal.Location = new Point(15, 80);

            //***ORÇAMENTOS***
            btnOrcamentosCadastro.Visible = false;
            //btnOrcamentosCadastro.Location = new Point(15, 10);

            //***VENDAS CLIENTES e PDV***
            btnVendasClientesCadastro.Visible = false;
            //btnVendasClientesCadastro.Location = new Point(15, 10);
            btnVendasClientesRelatorio.Visible = false;
            //btnVendasClientesRelatorio.Location = new Point(205, 10);
            btnVendasPDVCadastro.Visible = false;
            //btnVendasPDVCadastro.Location = new Point(15, 80);

            #endregion
        }
        // BOTÃO TELA INICIAL
        private void btnInicio_Click(object sender, EventArgs e)
        {
            #region "CARREGA EMPRESA"

            #region 'DECLARA A VARIAVEL E DEIXA LIMPA'         
            string empresa = string.Empty;
            #endregion

            #region 'FAZ O SELECT E REPASSA OS DADOS'
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
                    empresa = reader.GetString("Empresa");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }

            //Repassando os dados da variável para as caixas            
            lbl_empresa.Text = empresa;
            #endregion

            #region 'VERIFICA SE ESTÁ CADASTRADO'
            if (lbl_empresa.Text != "")
            {
                #region 'CARREGA SE ESTIVER CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.ForeColor = System.Drawing.Color.White;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            else
            {
                #region 'AVISA QUE NÃO ESTÁ CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.Text = "Cadastre sua Empresa no Menu!";
                lbl_empresa.ForeColor = System.Drawing.Color.Black;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            #endregion

            #endregion

            #region 'VISUALIZA BOTÕES SELECIONADOS'
            //***RELÓGIO TELA PRINCIPAL***
            lblhora.Visible = true;
            lblhora.Location = new Point(15, 10);
            //lblhora.Location = new Point(232, 203);
            lblData.Visible = true;
            lblData.Location = new Point(45, 148);
            //lblData.Location = new Point(262, 341);

            //***MENU***
            btnBackup.Visible = false;
            //btnBackup.Location = new Point(15, 10);
            btnCalculadora.Visible = false;
            //btnCalculadora.Location = new Point(205, 10);
            btnContatos.Visible = false;
            //btnContatos.Location = new Point(15, 80);
            btnEmpresa.Visible = false;
            //btnEmpresa.Location = new Point(205, 80);

            //***FINANCEIRO***
            btnFinanceiroCadastro.Visible = false;
            //btnFinanceiroCadastro.Location = new Point(15, 10);
            btnFinanceiroPesquisa.Visible = false;
            //btnFinanceiroPesquisa.Location = new Point(205, 10);
            btnFinanceiroRelatorio.Visible = false;
            //btnFinanceiroRelatorio.Location = new Point(15, 80);

            //***CADASTROS MÚLTIPLOS***
            btnCadastroMultiplos.Visible = false;
            //btnCadastroMultiplos.Location = new Point(15, 10);
            btnCadastroMultiplosPesquisa.Visible = false;
            //btnCadastroMultiplosPesquisa.Location = new Point(205, 10);
            btnCadastroMultiplosRelatorio.Visible = false;
            //btnCadastroMultiplosRelatorio.Location = new Point(15, 80);

            //***PRODUTOS***
            btnProdutosCadastro.Visible = false;
            //btnProdutosCadastro.Location = new Point(15, 10);
            btnProdutosPesquisa.Visible = false;
            //btnProdutosPesquisa.Location = new Point(205, 10);
            btnProdutosRelatorio.Visible = false;
            //btnProdutosRelatorio.Location = new Point(15, 80);

            //***NFs***
            btnNFsCadastro.Visible = false;
            //btnNFsCadastro.Location = new Point(15, 10);
            btnNFsPesquisa.Visible = false;
            //btnNFsPesquisa.Location = new Point(205, 10);
            btnNFsPesquisaTotal.Visible = false;
            //btnNFsPesquisaTotal.Location = new Point(15, 80);

            //***ORÇAMENTOS***
            btnOrcamentosCadastro.Visible = false;
            //btnOrcamentosCadastro.Location = new Point(15, 10);

            //***VENDAS CLIENTES e PDV***
            btnVendasClientesCadastro.Visible = false;
            //btnVendasClientesCadastro.Location = new Point(15, 10);
            btnVendasClientesRelatorio.Visible = false;
            //btnVendasClientesRelatorio.Location = new Point(205, 10);
            btnVendasPDVCadastro.Visible = false;
            //btnVendasPDVCadastro.Location = new Point(15, 80);

            #endregion
        }
        // BOTÃO MENU
        private void btnMenu_Click(object sender, EventArgs e)
        {
            #region "CARREGA EMPRESA"

            #region 'DECLARA A VARIAVEL E DEIXA LIMPA'         
            string empresa = string.Empty;
            #endregion

            #region 'FAZ O SELECT E REPASSA OS DADOS'
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
                    empresa = reader.GetString("Empresa");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }

            //Repassando os dados da variável para as caixas            
            lbl_empresa.Text = empresa;
            #endregion

            #region 'VERIFICA SE ESTÁ CADASTRADO'
            if (lbl_empresa.Text != "")
            {
                #region 'CARREGA SE ESTIVER CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.ForeColor = System.Drawing.Color.White;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            else
            {
                #region 'AVISA QUE NÃO ESTÁ CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.Text = "Cadastre sua Empresa no Menu!";
                lbl_empresa.ForeColor = System.Drawing.Color.Black;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            #endregion

            #endregion

            #region 'VISUALIZA BOTÕES SELECIONADOS'
            //***RELÓGIO TELA PRINCIPAL***
            lblhora.Visible = false;
            //lblhora.Location = new Point(232, 203);
            lblData.Visible = false;
            //lblData.Location = new Point(262, 341);

            //***MENU***
            btnBackup.Visible = true;
            btnBackup.Location = new Point(15, 10);
            btnCalculadora.Visible = true;
            btnCalculadora.Location = new Point(205, 10);
            btnContatos.Visible = true;
            btnContatos.Location = new Point(15, 80);
            btnEmpresa.Visible = true;
            btnEmpresa.Location = new Point(205, 80);

            //***FINANCEIRO***
            btnFinanceiroCadastro.Visible = false;
            //btnFinanceiroCadastro.Location = new Point(15, 10);
            btnFinanceiroPesquisa.Visible = false;
            //btnFinanceiroPesquisa.Location = new Point(205, 10);
            btnFinanceiroRelatorio.Visible = false;
            //btnFinanceiroRelatorio.Location = new Point(15, 80);

            //***CADASTROS MÚLTIPLOS***
            btnCadastroMultiplos.Visible = false;
            //btnCadastroMultiplos.Location = new Point(15, 10);
            btnCadastroMultiplosPesquisa.Visible = false;
            //btnCadastroMultiplosPesquisa.Location = new Point(205, 10);
            btnCadastroMultiplosRelatorio.Visible = false;
            //btnCadastroMultiplosRelatorio.Location = new Point(15, 80);

            //***PRODUTOS***
            btnProdutosCadastro.Visible = false;
            //btnProdutosCadastro.Location = new Point(15, 10);
            btnProdutosPesquisa.Visible = false;
            //btnProdutosPesquisa.Location = new Point(205, 10);
            btnProdutosRelatorio.Visible = false;
            //btnProdutosRelatorio.Location = new Point(15, 80);

            //***NFs***
            btnNFsCadastro.Visible = false;
            //btnNFsCadastro.Location = new Point(15, 10);
            btnNFsPesquisa.Visible = false;
            //btnNFsPesquisa.Location = new Point(205, 10);
            btnNFsPesquisaTotal.Visible = false;
            //btnNFsPesquisaTotal.Location = new Point(15, 80);

            //***ORÇAMENTOS***
            btnOrcamentosCadastro.Visible = false;
            //btnOrcamentosCadastro.Location = new Point(15, 10);

            //***VENDAS CLIENTES e PDV***
            btnVendasClientesCadastro.Visible = false;
            //btnVendasClientesCadastro.Location = new Point(15, 10);
            btnVendasClientesRelatorio.Visible = false;
            //btnVendasClientesRelatorio.Location = new Point(205, 10);
            btnVendasPDVCadastro.Visible = false;
            //btnVendasPDVCadastro.Location = new Point(15, 80);

            #endregion
        }
        // BOTÃO SUBMENU
        private void btnBackup_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            Frm08BackupMenu frm = new Frm08BackupMenu();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO SUBMENU
        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            System.Diagnostics.Process.Start("calc.exe");
            #endregion
        }
        // BOTÃO SUBMENU
        private void btnContatos_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            Frm12Contatos frm = new Frm12Contatos();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO SUBMENU
        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            Frm07Empresa frm = new Frm07Empresa();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO FINANCEIRO
        private void btnFinanceiro_Click(object sender, EventArgs e)
        {
            #region "CARREGA EMPRESA"

            #region 'DECLARA A VARIAVEL E DEIXA LIMPA'         
            string empresa = string.Empty;
            #endregion

            #region 'FAZ O SELECT E REPASSA OS DADOS'
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
                    empresa = reader.GetString("Empresa");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }

            //Repassando os dados da variável para as caixas            
            lbl_empresa.Text = empresa;
            #endregion

            #region 'VERIFICA SE ESTÁ CADASTRADO'
            if (lbl_empresa.Text != "")
            {
                #region 'CARREGA SE ESTIVER CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.ForeColor = System.Drawing.Color.White;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            else
            {
                #region 'AVISA QUE NÃO ESTÁ CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.Text = "Cadastre sua Empresa no Menu!";
                lbl_empresa.ForeColor = System.Drawing.Color.Black;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            #endregion

            #endregion

            #region 'VISUALIZA BOTÕES SELECIONADOS'
            //***RELÓGIO TELA PRINCIPAL***
            lblhora.Visible = false;
            //lblhora.Location = new Point(232, 203);
            lblData.Visible = false;
            //lblData.Location = new Point(262, 341);

            //***MENU***
            btnBackup.Visible = false;
            //btnBackup.Location = new Point(15, 10);
            btnCalculadora.Visible = false;
           //btnCalculadora.Location = new Point(205, 10);
            btnContatos.Visible = false;
            //btnContatos.Location = new Point(15, 80);
            btnEmpresa.Visible = false;
            //btnEmpresa.Location = new Point(205, 80);

            //***FINANCEIRO***
            btnFinanceiroCadastro.Visible = true;
            btnFinanceiroCadastro.Location = new Point(15, 10);
            btnFinanceiroPesquisa.Visible = true;
            btnFinanceiroPesquisa.Location = new Point(205, 10);
            btnFinanceiroRelatorio.Visible = true;
            btnFinanceiroRelatorio.Location = new Point(15, 80);

            //***CADASTROS MÚLTIPLOS***
            btnCadastroMultiplos.Visible = false;
            //btnCadastroMultiplos.Location = new Point(15, 10);
            btnCadastroMultiplosPesquisa.Visible = false;
            //btnCadastroMultiplosPesquisa.Location = new Point(205, 10);
            btnCadastroMultiplosRelatorio.Visible = false;
            //btnCadastroMultiplosRelatorio.Location = new Point(15, 80);

            //***PRODUTOS***
            btnProdutosCadastro.Visible = false;
            //btnProdutosCadastro.Location = new Point(15, 10);
            btnProdutosPesquisa.Visible = false;
            //btnProdutosPesquisa.Location = new Point(205, 10);
            btnProdutosRelatorio.Visible = false;
            //btnProdutosRelatorio.Location = new Point(15, 80);

            //***NFs***
            btnNFsCadastro.Visible = false;
            //btnNFsCadastro.Location = new Point(15, 10);
            btnNFsPesquisa.Visible = false;
            //btnNFsPesquisa.Location = new Point(205, 10);
            btnNFsPesquisaTotal.Visible = false;
            //btnNFsPesquisaTotal.Location = new Point(15, 80);

            //***ORÇAMENTOS***
            btnOrcamentosCadastro.Visible = false;
            //btnOrcamentosCadastro.Location = new Point(15, 10);

            //***VENDAS CLIENTES e PDV***
            btnVendasClientesCadastro.Visible = false;
            //btnVendasClientesCadastro.Location = new Point(15, 10);
            btnVendasClientesRelatorio.Visible = false;
            //btnVendasClientesRelatorio.Location = new Point(205, 10);
            btnVendasPDVCadastro.Visible = false;
            //btnVendasPDVCadastro.Location = new Point(15, 80);

            #endregion
        }
        // BOTÃO SUBFINANCEIRO
        private void btnFinanceiroCadastro_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmFinanceiro frm = new FrmFinanceiro();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO SUBFINANCEIRO
        private void btnFinanceiroPesquisa_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmFinanceiroConsulta frm = new FrmFinanceiroConsulta();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO SUBFINANCEIRO
        private void btnFinanceiroRelatorio_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmFinanceiroRelatorio frm = new FrmFinanceiroRelatorio();
            frm.ShowDialog();
            #endregion
        }    
        // BOTÃO CADASTROS MÚLTIPLOS
        private void btnCadastros_Click(object sender, EventArgs e)
        {
            #region "CARREGA EMPRESA"

            #region 'DECLARA A VARIAVEL E DEIXA LIMPA'         
            string empresa = string.Empty;
            #endregion

            #region 'FAZ O SELECT E REPASSA OS DADOS'
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
                    empresa = reader.GetString("Empresa");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }

            //Repassando os dados da variável para as caixas            
            lbl_empresa.Text = empresa;
            #endregion

            #region 'VERIFICA SE ESTÁ CADASTRADO'
            if (lbl_empresa.Text != "")
            {
                #region 'CARREGA SE ESTIVER CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.ForeColor = System.Drawing.Color.White;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            else
            {
                #region 'AVISA QUE NÃO ESTÁ CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.Text = "Cadastre sua Empresa no Menu!";
                lbl_empresa.ForeColor = System.Drawing.Color.Black;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            #endregion

            #endregion

            #region 'VISUALIZA BOTÕES SELECIONADOS'
            //***RELÓGIO TELA PRINCIPAL***
            lblhora.Visible = false;
            //lblhora.Location = new Point(232, 203);
            lblData.Visible = false;
            //lblData.Location = new Point(262, 341);

            //***MENU***
            btnBackup.Visible = false;
            //btnBackup.Location = new Point(15, 10);
            btnCalculadora.Visible = false;
            //btnCalculadora.Location = new Point(205, 10);
            btnContatos.Visible = false;
            //btnContatos.Location = new Point(15, 80);
            btnEmpresa.Visible = false;
            //btnEmpresa.Location = new Point(205, 80);

            //***FINANCEIRO***
            btnFinanceiroCadastro.Visible = false;
            //btnFinanceiroCadastro.Location = new Point(15, 10);
            btnFinanceiroPesquisa.Visible = false;
            //btnFinanceiroPesquisa.Location = new Point(205, 10);
            btnFinanceiroRelatorio.Visible = false;
            //btnFinanceiroRelatorio.Location = new Point(15, 80);

            //***CADASTROS MÚLTIPLOS***
            btnCadastroMultiplos.Visible = true;
            btnCadastroMultiplos.Location = new Point(15, 10);
            btnCadastroMultiplosPesquisa.Visible = true;
            btnCadastroMultiplosPesquisa.Location = new Point(205, 10);
            btnCadastroMultiplosRelatorio.Visible = true;
            btnCadastroMultiplosRelatorio.Location = new Point(15, 80);

            //***PRODUTOS***
            btnProdutosCadastro.Visible = false;
            //btnProdutosCadastro.Location = new Point(15, 10);
            btnProdutosPesquisa.Visible = false;
            //btnProdutosPesquisa.Location = new Point(205, 10);
            btnProdutosRelatorio.Visible = false;
            //btnProdutosRelatorio.Location = new Point(15, 80);

            //***NFs***
            btnNFsCadastro.Visible = false;
            //btnNFsCadastro.Location = new Point(15, 10);
            btnNFsPesquisa.Visible = false;
            //btnNFsPesquisa.Location = new Point(205, 10);
            btnNFsPesquisaTotal.Visible = false;
            //btnNFsPesquisaTotal.Location = new Point(15, 80);

            //***ORÇAMENTOS***
            btnOrcamentosCadastro.Visible = false;
            //btnOrcamentosCadastro.Location = new Point(15, 10);

            //***VENDAS CLIENTES e PDV***
            btnVendasClientesCadastro.Visible = false;
            //btnVendasClientesCadastro.Location = new Point(15, 10);
            btnVendasClientesRelatorio.Visible = false;
            //btnVendasClientesRelatorio.Location = new Point(205, 10);
            btnVendasPDVCadastro.Visible = false;
            //btnVendasPDVCadastro.Location = new Point(15, 80);

            #endregion
        }
        // BOTÃO SUBCADASTROS MÚLTIPLOS
        private void btnCadastroMultiplos_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmCadastroMultiplos frm = new FrmCadastroMultiplos();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO SUBCADASTROS MÚLTIPLOS
        private void btnCadastroMultiplosPesquisa_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmCadastroMultiplosConsulta frm = new FrmCadastroMultiplosConsulta();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO SUBCADASTROS MÚLTIPLOS
        private void btnCadastroMultiplosRelatorio_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmCadastroMultiplosRelatorios frm = new FrmCadastroMultiplosRelatorios();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO CADASTRO PRODUTOS
        private void btnProdutos_Click(object sender, EventArgs e)
        {
            #region "CARREGA EMPRESA"

            #region 'DECLARA A VARIAVEL E DEIXA LIMPA'         
            string empresa = string.Empty;
            #endregion

            #region 'FAZ O SELECT E REPASSA OS DADOS'
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
                    empresa = reader.GetString("Empresa");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }

            //Repassando os dados da variável para as caixas            
            lbl_empresa.Text = empresa;
            #endregion

            #region 'VERIFICA SE ESTÁ CADASTRADO'
            if (lbl_empresa.Text != "")
            {
                #region 'CARREGA SE ESTIVER CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.ForeColor = System.Drawing.Color.White;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            else
            {
                #region 'AVISA QUE NÃO ESTÁ CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.Text = "Cadastre sua Empresa no Menu!";
                lbl_empresa.ForeColor = System.Drawing.Color.Black;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            #endregion

            #endregion

            #region 'VISUALIZA BOTÕES SELECIONADOS'
            //***RELÓGIO TELA PRINCIPAL***
            lblhora.Visible = false;
            //lblhora.Location = new Point(232, 203);
            lblData.Visible = false;
            //lblData.Location = new Point(262, 341);

            //***MENU***
            btnBackup.Visible = false;
            //btnBackup.Location = new Point(15, 10);
            btnCalculadora.Visible = false;
            //btnCalculadora.Location = new Point(205, 10);
            btnContatos.Visible = false;
            //btnContatos.Location = new Point(15, 80);
            btnEmpresa.Visible = false;
            //btnEmpresa.Location = new Point(205, 80);

            //***FINANCEIRO***
            btnFinanceiroCadastro.Visible = false;
            //btnFinanceiroCadastro.Location = new Point(15, 10);
            btnFinanceiroPesquisa.Visible = false;
            //btnFinanceiroPesquisa.Location = new Point(205, 10);
            btnFinanceiroRelatorio.Visible = false;
            //btnFinanceiroRelatorio.Location = new Point(15, 80);

            //***CADASTROS MÚLTIPLOS***
            btnCadastroMultiplos.Visible = false;
            //btnCadastroMultiplos.Location = new Point(15, 10);
            btnCadastroMultiplosPesquisa.Visible = false;
            //btnCadastroMultiplosPesquisa.Location = new Point(205, 10);
            btnCadastroMultiplosRelatorio.Visible = false;
            //btnCadastroMultiplosRelatorio.Location = new Point(15, 80);

            //***PRODUTOS***
            btnProdutosCadastro.Visible = true;
            btnProdutosCadastro.Location = new Point(15, 10);
            btnProdutosPesquisa.Visible = true;
            btnProdutosPesquisa.Location = new Point(205, 10);
            btnProdutosRelatorio.Visible = true;
            btnProdutosRelatorio.Location = new Point(15, 80);

            //***NFs***
            btnNFsCadastro.Visible = false;
            //btnNFsCadastro.Location = new Point(15, 10);
            btnNFsPesquisa.Visible = false;
            //btnNFsPesquisa.Location = new Point(205, 10);
            btnNFsPesquisaTotal.Visible = false;
            //btnNFsPesquisaTotal.Location = new Point(15, 80);

            //***ORÇAMENTOS***
            btnOrcamentosCadastro.Visible = false;
            //btnOrcamentosCadastro.Location = new Point(15, 10);

            //***VENDAS CLIENTES e PDV***
            btnVendasClientesCadastro.Visible = false;
            //btnVendasClientesCadastro.Location = new Point(15, 10);
            btnVendasClientesRelatorio.Visible = false;
            //btnVendasClientesRelatorio.Location = new Point(205, 10);
            btnVendasPDVCadastro.Visible = false;
            //btnVendasPDVCadastro.Location = new Point(15, 80);

            #endregion
        }
        // BOTÃO SUBCADASTRO PRODUTOS
        private void btnProdutosCadastro_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmProdutos frm = new FrmProdutos();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO SUBCADASTRO PRODUTOS
        private void btnProdutosPesquisa_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmProdutosConsulta frm = new FrmProdutosConsulta();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO SUBCADASTRO PRODUTOS
        private void btnProdutosRelatorio_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmProdutosRelatorio frm = new FrmProdutosRelatorio();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO CADASTRO NFs
        private void btnNF_Click(object sender, EventArgs e)
        {
            #region "CARREGA EMPRESA"

            #region 'DECLARA A VARIAVEL E DEIXA LIMPA'         
            string empresa = string.Empty;
            #endregion

            #region 'FAZ O SELECT E REPASSA OS DADOS'
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
                    empresa = reader.GetString("Empresa");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }

            //Repassando os dados da variável para as caixas            
            lbl_empresa.Text = empresa;
            #endregion

            #region 'VERIFICA SE ESTÁ CADASTRADO'
            if (lbl_empresa.Text != "")
            {
                #region 'CARREGA SE ESTIVER CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.ForeColor = System.Drawing.Color.White;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            else
            {
                #region 'AVISA QUE NÃO ESTÁ CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.Text = "Cadastre sua Empresa no Menu!";
                lbl_empresa.ForeColor = System.Drawing.Color.Black;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            #endregion

            #endregion

            #region 'VISUALIZA BOTÕES SELECIONADOS'
            //***RELÓGIO TELA PRINCIPAL***
            lblhora.Visible = false;
            //lblhora.Location = new Point(232, 203);
            lblData.Visible = false;
            //lblData.Location = new Point(262, 341);

            //***MENU***
            btnBackup.Visible = false;
            //btnBackup.Location = new Point(15, 10);
            btnCalculadora.Visible = false;
            //btnCalculadora.Location = new Point(205, 10);
            btnContatos.Visible = false;
            //btnContatos.Location = new Point(15, 80);
            btnEmpresa.Visible = false;
            //btnEmpresa.Location = new Point(205, 80);

            //***FINANCEIRO***
            btnFinanceiroCadastro.Visible = false;
            //btnFinanceiroCadastro.Location = new Point(15, 10);
            btnFinanceiroPesquisa.Visible = false;
            //btnFinanceiroPesquisa.Location = new Point(205, 10);
            btnFinanceiroRelatorio.Visible = false;
            //btnFinanceiroRelatorio.Location = new Point(15, 80);

            //***CADASTROS MÚLTIPLOS***
            btnCadastroMultiplos.Visible = false;
            //btnCadastroMultiplos.Location = new Point(15, 10);
            btnCadastroMultiplosPesquisa.Visible = false;
            //btnCadastroMultiplosPesquisa.Location = new Point(205, 10);
            btnCadastroMultiplosRelatorio.Visible = false;
            //btnCadastroMultiplosRelatorio.Location = new Point(15, 80);

            //***PRODUTOS***
            btnProdutosCadastro.Visible = false;
            //btnProdutosCadastro.Location = new Point(15, 10);
            btnProdutosPesquisa.Visible = false;
            //btnProdutosPesquisa.Location = new Point(205, 10);
            btnProdutosRelatorio.Visible = false;
            //btnProdutosRelatorio.Location = new Point(15, 80);

            //***NFs***
            btnNFsCadastro.Visible = true;
            btnNFsCadastro.Location = new Point(15, 10);
            btnNFsPesquisa.Visible = true;
            btnNFsPesquisa.Location = new Point(205, 10);
            btnNFsPesquisaTotal.Visible = true;
            btnNFsPesquisaTotal.Location = new Point(15, 80);

            //***ORÇAMENTOS***
            btnOrcamentosCadastro.Visible = false;
            //btnOrcamentosCadastro.Location = new Point(15, 10);

            //***VENDAS CLIENTES e PDV***
            btnVendasClientesCadastro.Visible = false;
            //btnVendasClientesCadastro.Location = new Point(15, 10);
            btnVendasClientesRelatorio.Visible = false;
            //btnVendasClientesRelatorio.Location = new Point(205, 10);
            btnVendasPDVCadastro.Visible = false;
            //btnVendasPDVCadastro.Location = new Point(15, 80);

            #endregion
        }
        // BOTÃO SUBCADASTRO NFs
        private void btnNFsCadastro_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmNF frm = new FrmNF();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO SUBCADASTRO NFs
        private void btnNFsPesquisa_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmNFConsulta frm = new FrmNFConsulta();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO SUBCADASTRO NFs
        private void btnNFsPesquisaTotal_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmNFConsultaTotal frm = new FrmNFConsultaTotal();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO CADASTRO ORÇAMENTO
        private void btnOrcamentos_Click(object sender, EventArgs e)
        {
            #region "CARREGA EMPRESA"

            #region 'DECLARA A VARIAVEL E DEIXA LIMPA'         
            string empresa = string.Empty;
            #endregion

            #region 'FAZ O SELECT E REPASSA OS DADOS'
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
                    empresa = reader.GetString("Empresa");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }

            //Repassando os dados da variável para as caixas            
            lbl_empresa.Text = empresa;
            #endregion

            #region 'VERIFICA SE ESTÁ CADASTRADO'
            if (lbl_empresa.Text != "")
            {
                #region 'CARREGA SE ESTIVER CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.ForeColor = System.Drawing.Color.White;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            else
            {
                #region 'AVISA QUE NÃO ESTÁ CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.Text = "Cadastre sua Empresa no Menu!";
                lbl_empresa.ForeColor = System.Drawing.Color.Black;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            #endregion

            #endregion

            #region 'VISUALIZA BOTÕES SELECIONADOS'
            //***RELÓGIO TELA PRINCIPAL***
            lblhora.Visible = false;
            //lblhora.Location = new Point(232, 203);
            lblData.Visible = false;
            //lblData.Location = new Point(262, 341);

            //***MENU***
            btnBackup.Visible = false;
            //btnBackup.Location = new Point(15, 10);
            btnCalculadora.Visible = false;
            //btnCalculadora.Location = new Point(205, 10);
            btnContatos.Visible = false;
            //btnContatos.Location = new Point(15, 80);
            btnEmpresa.Visible = false;
            //btnEmpresa.Location = new Point(205, 80);

            //***FINANCEIRO***
            btnFinanceiroCadastro.Visible = false;
            //btnFinanceiroCadastro.Location = new Point(15, 10);
            btnFinanceiroPesquisa.Visible = false;
            //btnFinanceiroPesquisa.Location = new Point(205, 10);
            btnFinanceiroRelatorio.Visible = false;
            //btnFinanceiroRelatorio.Location = new Point(15, 80);

            //***CADASTROS MÚLTIPLOS***
            btnCadastroMultiplos.Visible = false;
            //btnCadastroMultiplos.Location = new Point(15, 10);
            btnCadastroMultiplosPesquisa.Visible = false;
            //btnCadastroMultiplosPesquisa.Location = new Point(205, 10);
            btnCadastroMultiplosRelatorio.Visible = false;
            //btnCadastroMultiplosRelatorio.Location = new Point(15, 80);

            //***PRODUTOS***
            btnProdutosCadastro.Visible = false;
            //btnProdutosCadastro.Location = new Point(15, 10);
            btnProdutosPesquisa.Visible = false;
            //btnProdutosPesquisa.Location = new Point(205, 10);
            btnProdutosRelatorio.Visible = false;
            //btnProdutosRelatorio.Location = new Point(15, 80);

            //***NFs***
            btnNFsCadastro.Visible = false;
            //btnNFsCadastro.Location = new Point(15, 10);
            btnNFsPesquisa.Visible = false;
            //btnNFsPesquisa.Location = new Point(205, 10);
            btnNFsPesquisaTotal.Visible = false;
            //btnNFsPesquisaTotal.Location = new Point(15, 80);

            //***ORÇAMENTOS***
            btnOrcamentosCadastro.Visible = true;
            btnOrcamentosCadastro.Location = new Point(15, 10);

            //***VENDAS CLIENTES e PDV***
            btnVendasClientesCadastro.Visible = false;
            //btnVendasClientesCadastro.Location = new Point(15, 10);
            btnVendasClientesRelatorio.Visible = false;
            //btnVendasClientesRelatorio.Location = new Point(205, 10);
            btnVendasPDVCadastro.Visible = false;
            //btnVendasPDVCadastro.Location = new Point(15, 80);

            #endregion
        }
        // BOTÃO SUBCADASTRO ORÇAMENTO
        private void btnOrcamentosCadastro_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmOrcamentos frm = new FrmOrcamentos();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO VENDAS CLIENTES
        private void btnVendas_Click(object sender, EventArgs e)
        {
            #region "CARREGA EMPRESA"

            #region 'DECLARA A VARIAVEL E DEIXA LIMPA'         
            string empresa = string.Empty;
            #endregion

            #region 'FAZ O SELECT E REPASSA OS DADOS'
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
                    empresa = reader.GetString("Empresa");
                }
                cmd.Connection.Close(); //Fecha a conexão
            }

            //Repassando os dados da variável para as caixas            
            lbl_empresa.Text = empresa;
            #endregion

            #region 'VERIFICA SE ESTÁ CADASTRADO'
            if (lbl_empresa.Text != "")
            {
                #region 'CARREGA SE ESTIVER CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.ForeColor = System.Drawing.Color.White;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            else
            {
                #region 'AVISA QUE NÃO ESTÁ CADASTRADO'
                lbl_empresa.Parent = pnSuperior;
                lbl_empresa.BackColor = Color.Transparent;
                lbl_empresa.Text = "Cadastre sua Empresa no Menu!";
                lbl_empresa.ForeColor = System.Drawing.Color.Black;
                //lbl_empresa.Left = 10;
                //lbl_empresa.Top = 10;
                #endregion
            }
            #endregion

            #endregion

            #region 'VISUALIZA BOTÕES SELECIONADOS'
            //***RELÓGIO TELA PRINCIPAL***
            lblhora.Visible = false;
            //lblhora.Location = new Point(232, 203);
            lblData.Visible = false;
            //lblData.Location = new Point(262, 341);

            //***MENU***
            btnBackup.Visible = false;
            //btnBackup.Location = new Point(15, 10);
            btnCalculadora.Visible = false;
            //btnCalculadora.Location = new Point(205, 10);
            btnContatos.Visible = false;
            //btnContatos.Location = new Point(15, 80);
            btnEmpresa.Visible = false;
            //btnEmpresa.Location = new Point(205, 80);

            //***FINANCEIRO***
            btnFinanceiroCadastro.Visible = false;
            //btnFinanceiroCadastro.Location = new Point(15, 10);
            btnFinanceiroPesquisa.Visible = false;
            //btnFinanceiroPesquisa.Location = new Point(205, 10);
            btnFinanceiroRelatorio.Visible = false;
            //btnFinanceiroRelatorio.Location = new Point(15, 80);

            //***CADASTROS MÚLTIPLOS***
            btnCadastroMultiplos.Visible = false;
            //btnCadastroMultiplos.Location = new Point(15, 10);
            btnCadastroMultiplosPesquisa.Visible = false;
            //btnCadastroMultiplosPesquisa.Location = new Point(205, 10);
            btnCadastroMultiplosRelatorio.Visible = false;
            //btnCadastroMultiplosRelatorio.Location = new Point(15, 80);

            //***PRODUTOS***
            btnProdutosCadastro.Visible = false;
            //btnProdutosCadastro.Location = new Point(15, 10);
            btnProdutosPesquisa.Visible = false;
            //btnProdutosPesquisa.Location = new Point(205, 10);
            btnProdutosRelatorio.Visible = false;
            //btnProdutosRelatorio.Location = new Point(15, 80);

            //***NFs***
            btnNFsCadastro.Visible = false;
            //btnNFsCadastro.Location = new Point(15, 10);
            btnNFsPesquisa.Visible = false;
            //btnNFsPesquisa.Location = new Point(205, 10);
            btnNFsPesquisaTotal.Visible = false;
            //btnNFsPesquisaTotal.Location = new Point(15, 80);

            //***ORÇAMENTOS***
            btnOrcamentosCadastro.Visible = false;
            //btnOrcamentosCadastro.Location = new Point(15, 10);

            //***VENDAS CLIENTES e PDV***
            btnVendasClientesCadastro.Visible = true;
            btnVendasClientesCadastro.Location = new Point(15, 10);
            btnVendasClientesRelatorio.Visible = true;
            btnVendasClientesRelatorio.Location = new Point(205, 10);
            btnVendasPDVCadastro.Visible = true;
            btnVendasPDVCadastro.Location = new Point(15, 80);

            #endregion
        }
        // BOTÃO SUBVENDAS CLIENTES
        private void btnVendasClientesCadastro_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmVendasClientes frm = new FrmVendasClientes();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO SUBVENDAS CLIENTES
        private void btnVendasClientesRelatorio_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmVendasClientesRelatorios frm = new FrmVendasClientesRelatorios();
            frm.ShowDialog();
            #endregion
        }
        // BOTÃO SUBVENDAS PDV
        private void btnVendasPDVCadastro_Click(object sender, EventArgs e)
        {
            #region 'ABRE NOVA TELA'
            FrmVendasPDV frm = new FrmVendasPDV();
            frm.ShowDialog();
            #endregion
        }
    }
}
