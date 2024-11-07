using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGRas
{
    class ClasseCriarBDTable
    {
        #region 'DECLARAÇÃO'
        //Responsável pela conexão com o banco
        public static MySqlConnection Conexao;
        //Função responsável pelas instruções a serem executadas
        public static MySqlCommand Comando;
        //Função responsável pelas instruções a serem executadas
        //public static MySqlDataReader Reader;
        //Adapter responsável por inserir dados em uma DataTable
        //public static MySqlDataAdapter Adaptador;
        //Responsável por ligar o banco em controles com a propriedade DataSource
        //public static DataTable datTabela;
        #endregion

        public static void conectar()
        {
            #region "PARAMETROS PARA CONEXÃO COM O BANCO"
            //Estabelece os parametros para a conexão com o banco
            Conexao = new MySqlConnection("server=localhost;uid=root;pwd=ABCmultseg01012020");
            //Abre a conexão com o banco de dados
            Conexao.Open();
            #endregion

            #region "CRIAÇÃO DO BANCO"
            //Informa a instrução no SQL e cria o banco se ele não existir
            Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS sigrassystembd; use sigrassystembd", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "CRIAÇÃO DAS TABELAS"

            #region "TABELA-01 ADMINISTRADOR USUARIO"
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb01admusuario " +
                                        "(ID integer auto_increment primary key, " +
                                        "Senha varchar(20))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();

            //Verifica se tem dados cadastrados, caso não tenha cadastre
            //CONEXÃO COM O BANCO MSQL
            MySqlConnection cn = new MySqlConnection(@"SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;");
            int i;
            i = 0;
            cn.Open();
            MySqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tb01admusuario where Senha ='1234567890'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MySqlCommand comm = new MySqlCommand();
                comm.Connection = cn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "Insert Into tb01admusuario(Senha) Values";
                comm.CommandText += "('1234567890')";
                comm.ExecuteNonQuery();
                comm.Connection.Close(); //Fecha a conexão
            }
            else
            {
                //CASO SEJA IGUAL, FAZ A SEQUÊNCIA NORMALMENTE
            }
            cn.Close(); //Fecha a conexão     
            #endregion

            #region "TABELA-02 USUARIO"
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb02usuario " +
                                        "(ID integer auto_increment primary key, " +
                                        "user varchar(50), " +
                                        "email varchar(50), " +
                                        "pass varchar(20), " +
                                        "passconf varchar(20), " +
                                        "nivelacesso varchar(50))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA-03 ACESSO USUARIOS CONTROLE"
            //TABELA ACESSO USUÁRIOS CONTROLE
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb03usuariocontrole " +
                                        "(ID integer auto_increment primary key, " +
                                        "Usuario varchar(50), " +
                                        "Senha varchar(20), " +
                                        "DataHora varchar(20), " +
                                        "TipoUsuario varchar(30))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA-04 ADMINISTRADOR REATIVAÇÃO"
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb04admreativacao " +
                                        "(ID integer auto_increment primary key, " +
                                        "Senha varchar(20))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();

            //Verifica se tem dados cadastrados, caso não tenha cadastre
            //CONEXÃO COM O BANCO MSQL
            MySqlConnection cn1 = new MySqlConnection(@"SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;");
            int i1;
            i1 = 0;
            cn1.Open();
            MySqlCommand cmd1 = cn1.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT * FROM tb04admreativacao where Senha ='ABCmultseg01012020'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
            da1.Fill(dt1);
            i1 = Convert.ToInt32(dt1.Rows.Count.ToString());

            if (i1 == 0)
            {
                MySqlCommand comm1 = new MySqlCommand();
                comm1.Connection = cn1;
                comm1.CommandType = CommandType.Text;
                comm1.CommandText = "Insert Into tb04admreativacao(Senha) Values";
                comm1.CommandText += "('ABCmultseg01012020')";
                comm1.ExecuteNonQuery();
                comm1.Connection.Close(); //Fecha a conexão
            }
            else
            {
                //CASO SEJA IGUAL, FAZ A SEQUÊNCIA NORMALMENTE
            }
            cn1.Close(); //Fecha a conexão     
            #endregion

            #region "TABELA-05 EMPRESA ESTABELECIMENTO"
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb05empresaestabelecimento " +
                                        "(ID integer auto_increment primary key, " +
                                        "Empresa varchar(50), " +
                                        "Cnpj varchar(20), " +
                                        "Endereco varchar(50), " +
                                        "Numero int(10), " +
                                        "Cep varchar(12), " +
                                        "Bairro varchar(50), " +
                                        "Cidade varchar(50), " +
                                        "Estado varchar(5), " +
                                        "Email varchar(50), " +
                                        "TelFixo varchar(20), " +
                                        "TelCelular varchar(20), " +
                                        "DataCadastro date)", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA-06 ADMINISTRADOR BACKUP"
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb06admbackup " +
                                        "(ID integer auto_increment primary key, " +
                                        "Senha varchar(20))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();

            //Verifica se tem dados cadastrados, caso não tenha cadastre
            //CONEXÃO COM O BANCO MSQL
            MySqlConnection cn2 = new MySqlConnection(@"SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;");
            int i2;
            i2 = 0;
            cn2.Open();
            MySqlCommand cmd2 = cn2.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT * FROM tb06admbackup where Senha ='1234567890'";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
            da2.Fill(dt2);
            i2 = Convert.ToInt32(dt2.Rows.Count.ToString());

            if (i2 == 0)
            {
                MySqlCommand comm2 = new MySqlCommand();
                comm2.Connection = cn2;
                comm2.CommandType = CommandType.Text;
                comm2.CommandText = "Insert Into tb06admbackup(Senha) Values";
                comm2.CommandText += "('1234567890')";
                comm2.ExecuteNonQuery();
                comm2.Connection.Close(); //Fecha a conexão
            }
            else
            {
                //CASO SEJA IGUAL, FAZ A SEQUÊNCIA NORMALMENTE
            }
            cn2.Close(); //Fecha a conexão     
            #endregion

            #region "TABELA-07 ACESSO VALIDADE"
            //TABELA ACESSO VALIDADE
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb07acessovalidade " +
                                        "(ID integer auto_increment primary key, " +
                                        "Datainicial varchar(20), " +
                                        "Dataatual varchar(20), " +
                                        "Datahoje varchar(20), " +
                                        "Dataexpiracao varchar(20), " +
                                        "Diasrestante int(5))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA FINANCEIRO"
            //TABELA DADOS FINANCEIROS
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_financeiro " +
                                        "(ID integer auto_increment primary key, " +
                                        "DataSistema date, " +
                                        "HoraSistema varchar(15), " +
                                        "Mes varchar(10), " +
                                        "Ano int(5), " +
                                        "TipoLancamento varchar(8), " +
                                        "DestinoLancamento varchar(50), " +
                                        "DepartamentoSetor varchar(50), " +
                                        "ContaDestino varchar(50), " +
                                        "Data date, " +
                                        "Especie varchar(20), " +
                                        "DescricaoLancamento varchar(100), " +
                                        "ValorEntrada varchar(30), " +
                                        "ValorSaida varchar(30), " +
                                        "Observacao varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA FINANCEIRO DESTINO LANCAMENTOS"
            //TABELA DADOS DESTINO LANCAMENTOS
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_financeirodestinolancamentos " +
                                        "(ID integer auto_increment primary key, " +
                                        "DescricaoLancamentos varchar(50), " +
                                        "Observacoes varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();

            //COMEÇA A SELEÇÃO DE DADOS PARA GRAVAR SE NÃO EXISTIR
            //Declarando a variavel e deixando limpa
            string DEL = string.Empty;
            MySqlConnection cn3 = new MySqlConnection(@"SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;");
            cn3.Open();
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd3 = new MySqlCommand();
            cmd3.Connection = cn3; //Abre a conexão
            cmd3.CommandText = "SELECT * FROM tb_financeirodestinolancamentos where ID = " + 1 + ""; //Seleciona a tabela e procura os dados            
            MySqlDataReader reader3 = cmd3.ExecuteReader(); //Executa o comando selecionar

            //Faz a leitura e repassa os dados para variavel
            if (reader3.HasRows)
            {
                if (reader3.Read())
                {
                    DEL = reader3.GetString("DescricaoLancamentos");
                }
                cmd3.Connection.Close(); //Fecha a conexão
                cn3.Close();
            }
            reader3.Close();

            if (DEL == "")
            {
                //DECLARANDO VARIÁVEIS                
                string DEL1 = "Empresa";
                string DELO = "";
                //COMEÇA O COMANDO PARA GRAVAR
                MySqlCommand comm3 = new MySqlCommand();
                comm3.Connection = cn3; //Abre a conexão
                comm3.CommandText = "Insert Into tb_financeirodestinolancamentos(DescricaoLancamentos,Observacoes) Values";
                comm3.CommandText += "('" + DEL1 + "','" + DELO + "')";
                comm3.ExecuteNonQuery(); //Atualiza os registros na tabela                       
                comm3.Connection.Close(); //Fecha a conexão
                cn3.Close();
            }
            else
            {
                //CASO TENHA DADOS, FAZ A SEQUÊNCIA NORMALMENTE
            }
            cn3.Close(); //Fecha a conexão
            #endregion

            #region "TABELA FINANCEIRO DEPARTAMENTO SETOR"
            //TABELA DADOS FINANCEIRO DEPARTAMENTO SETOR
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_financeirodepartamentosetores " +
                                        "(ID integer auto_increment primary key, " +
                                        "DescricaoDepartamentos varchar(50), " +
                                        "Observacoes varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();

            //COMEÇA A SELEÇÃO DE DADOS PARA GRAVAR SE NÃO EXISTIR
            //Declarando a variavel e deixando limpa
            string DPS = string.Empty;
            MySqlConnection cn4 = new MySqlConnection(@"SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;");
            cn4.Open();
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd4 = new MySqlCommand();
            cmd4.Connection = cn4; //Abre a conexão
            cmd4.CommandText = "SELECT * FROM tb_financeirodepartamentosetores where ID = " + 1 + ""; //Seleciona a tabela e procura os dados            
            MySqlDataReader reader4 = cmd4.ExecuteReader(); //Executa o comando selecionar

            //Faz a leitura e repassa os dados para variavel
            if (reader4.HasRows)
            {
                if (reader4.Read())
                {
                    DPS = reader4.GetString("DescricaoDepartamentos");
                }
                cmd4.Connection.Close(); //Fecha a conexão
                cn4.Close();
            }
            reader4.Close();

            if (DPS == "")
            {
                //DECLARANDO VARIÁVEIS                
                string DPS1 = "Geral";
                string DPSO = "";
                //COMEÇA O COMANDO PARA GRAVAR
                MySqlCommand comm4 = new MySqlCommand();
                comm4.Connection = cn4; //Abre a conexão
                comm4.CommandText = "Insert Into tb_financeirodepartamentosetores(DescricaoDepartamentos,Observacoes) Values";
                comm4.CommandText += "('" + DPS1 + "','" + DPSO + "')";
                comm4.ExecuteNonQuery(); //Atualiza os registros na tabela                       
                comm4.Connection.Close(); //Fecha a conexão
                cn4.Close();
            }
            else
            {
                //CASO TENHA DADOS, FAZ A SEQUÊNCIA NORMALMENTE
            }
            cn4.Close(); //Fecha a conexão
            #endregion

            #region "TABELA FINANCEIRO DESTINO OPERAÇÃO"
            //TABELA DADOS DESTINO OPERAÇÃO
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_financeirodestinooperacao " +
                                        "(ID integer auto_increment primary key, " +
                                        "DescricaoDestinos varchar(50), " +
                                        "Observacoes varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();

            //COMEÇA A SELEÇÃO DE DADOS PARA GRAVAR SE NÃO EXISTIR
            //Declarando a variavel e deixando limpa
            string DED = string.Empty;
            MySqlConnection cn5 = new MySqlConnection(@"SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;");
            cn5.Open();
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd5 = new MySqlCommand();
            cmd5.Connection = cn5; //Abre a conexão
            cmd5.CommandText = "SELECT * FROM tb_financeirodestinooperacao where ID = " + 1 + ""; //Seleciona a tabela e procura os dados            
            MySqlDataReader reader5 = cmd5.ExecuteReader(); //Executa o comando selecionar

            //Faz a leitura e repassa os dados para variavel
            if (reader5.HasRows)
            {
                if (reader5.Read())
                {
                    DED = reader5.GetString("DescricaoDestinos");
                }
                cmd5.Connection.Close(); //Fecha a conexão
                cn5.Close();
            }
            reader5.Close();

            if (DED == "")
            {
                //DECLARANDO VARIÁVEIS                
                string DED1 = "Cofre";
                string DEDO = "";
                //COMEÇA O COMANDO PARA GRAVAR
                MySqlCommand comm5 = new MySqlCommand();
                comm5.Connection = cn5; //Abre a conexão
                comm5.CommandText = "Insert Into tb_financeirodestinooperacao(DescricaoDestinos,Observacoes) Values";
                comm5.CommandText += "('" + DED1 + "','" + DEDO + "')";
                comm5.ExecuteNonQuery(); //Atualiza os registros na tabela                       
                comm5.Connection.Close(); //Fecha a conexão
                cn5.Close();
            }
            else
            {
                //CASO TENHA DADOS, FAZ A SEQUÊNCIA NORMALMENTE
            }
            cn5.Close(); //Fecha a conexão
            #endregion

            #region "TABELA CADASTRO MULTIPLOS"
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_cadastromultiplo " +
                                        "(ID integer auto_increment primary key, " +
                                        "DataSistema date, " +
                                        "Status varchar(8), " +
                                        "TipoCadastro varchar(12), " +
                                        "TipoPessoa varchar(16), " +
                                        "NomeRazaoSocial varchar(100), " +
                                        "NomeFantasiaApelido varchar(50), " +
                                        "DataAbertura date, " +
                                        "Cnpj varchar(20), " +
                                        "InscricaoEstadual varchar(20), " +
                                        "InscricaoMunicipal varchar(20), " +
                                        "DataNascimento date, " +
                                        "Cpf varchar(15), " +
                                        "Rg varchar(15), " +
                                        "DataExpedicaoRG date, " +
                                        "Nacionalidade varchar(20), " +
                                        "Naturalidade varchar(50), " +
                                        "EstadoCivil varchar(15), " +
                                        "GrauInstrucao varchar(30), " +
                                        "CtpsNumero varchar(15), " +
                                        "CtpsSerie varchar(8), " +
                                        "DataExpedicaoCtps date, " +
                                        "PisPasep varchar(15), " +
                                        "TituloNumero varchar(15), " +
                                        "TituloZona varchar(5), " +
                                        "TituloSecao varchar(5), " +
                                        "ValeTransporte varchar(4), " +
                                        "TipoAdmissao varchar(10), " +
                                        "Funcao varchar(50), " +
                                        "SalarioRegistrado varchar(12), " +
                                        "SalarioTotal varchar(12), " +
                                        "NomeMae varchar(50), " +
                                        "NomePai varchar(50), " +
                                        "ArmarioNumero varchar(4), " +
                                        "DataComecou date, " +
                                        "DataAdmissao date, " +
                                        "DataDemissao date, " +
                                        "Cep varchar(11), " +
                                        "TipoLogradouro varchar(11), " +
                                        "Endereco varchar(100), " +
                                        "Numero varchar(6), " +
                                        "Complemento varchar(20), " +
                                        "Bairro varchar(50), " +
                                        "Cidade varchar(50), " +
                                        "Estado varchar(3), " +
                                        "TelFixo varchar(16), " +
                                        "TelFixoComercial varchar(16), " +
                                        "TelCelular1 varchar(16), " +
                                        "TelCelular2 varchar(16), " +
                                        "Email varchar(100), " +
                                        "Contato varchar(50), " +
                                        "Observacao varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA VENDAS CLIENTES"
            //TABELA VENDAS CLIENTES
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_vendasclientes " +
                                        "(ID integer auto_increment primary key, " +
                                        "DataSistema date, " +
                                        "NomeCliente varchar(100), " +
                                        "NomeFantasiaApelido varchar(50), " +
                                        "TipoPessoa varchar(16), " +
                                        "CpfCnpj varchar(20), " +
                                        "TelFixo varchar(16), " +
                                        "TelCelular varchar(16), " +
                                        "TipoAtividade varchar(10), " +
                                        "DataCredito date, " +
                                        "DataDebito date, " +
                                        "Mes varchar(10), " +
                                        "Ano int(5), " +
                                        "Situacao varchar(15), " +
                                        "NumeroNota varchar(10), " +
                                        "Especie varchar(20), " +
                                        "ValorCredito varchar(30), " +
                                        "ValorDebito varchar(30), " +
                                        "Observacao varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA PRODUTOS"
            //TABELA PRODUTOS
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_produtos " +
                                        "(ID integer auto_increment primary key, " +
                                        "DataCadastro date, " +
                                        "Status varchar(8), " +
                                        "DescricaoProduto varchar(100), " +
                                        "TipoItem varchar(50), " +
                                        "Grupo varchar(50), " +
                                        "Familia varchar(50), " +
                                        "EAN varchar(20), " +
                                        "UNCompra varchar(30), " +
                                        "UNEstocagem varchar(30), " +
                                        "Estoque varchar(30), " +
                                        "DataAlteracao date, " +
                                        "VlrCompra varchar(30), " +
                                        "VlrVenda varchar(30), " +
                                        "UnVenda varchar(3), " +
                                        "Observacoes varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA PRODUTOS GRUPOS"
            //TABELA PRODUTOS GRUPOS
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_produtosgrupos " +
                                        "(ID integer auto_increment primary key, " +
                                        "DescricaoGrupos varchar(50), " +
                                        "Observacoes varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA PRODUTOS FAMILIAS"
            //TABELA PRODUTOS FAMILIAS
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_produtosfamilias " +
                                        "(ID integer auto_increment primary key, " +
                                        "DescricaoFamilia varchar(50), " +
                                        "Observacoes varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA PRODUTOS UNIDADES"
            //TABELA PRODUTOS UNIDADES
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_produtosunidades " +
                                        "(ID integer auto_increment primary key, " +
                                        "DescricaoUnidades varchar(50), " +
                                        "Abreviacao varchar(10), " +
                                        "Observacoes varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA NF"
            //TABELA NF ITEMS
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_nfe" +
                                        "(ID integer auto_increment primary key, " +
                                        "IdOperacao int(10), " +
                                        "DescricaoOperacao varchar(50), " +
                                        "Modelo int(5), " +
                                        "Especie varchar(5), " +
                                        "Serie int(5), " +
                                        "Documentonr varchar(50), " +
                                        "Emissao date, " +
                                        "Referencia date, " +
                                        "IDFornecedor int(10), " +
                                        "DescricaoFornecedor varchar(100), " +
                                        "EstadoFornecedor varchar(3), " +
                                        "FormaPagamento varchar(50), " +
                                        "PrazoPagamento varchar(50), " +
                                        "IDProduto int(10), " +
                                        "DescricaoProduto varchar(100), " +
                                        "UnVenda varchar(3), " +
                                        "PrecoProduto varchar(30), " +
                                        "QntProduto varchar(30), " +
                                        "DescontoProduto varchar(30), " +
                                        "AcrescimoProduto varchar(30), " +
                                        "VlrTotalProduto varchar(30), " +
                                        "DescontoTotal varchar(30), " +
                                        "AcrescimoTotal varchar(30), " +
                                        "QntProdutosTotal int(10), " +
                                        "VlrTotalDocumento varchar(30))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA NF TOTAL"
            //TABELA NF TOTAL
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_nfetotal " +
                                        "(ID integer auto_increment primary key, " +
                                        "IdOperacao int(10), " +
                                        "DescricaoOperacao varchar(50), " +
                                        "Modelo int(5), " +
                                        "Especie varchar(5), " +
                                        "Serie int(5), " +
                                        "Documentonr varchar(50), " +
                                        "Emissao date, " +
                                        "Referencia date, " +
                                        "IDFornecedor int(10), " +
                                        "DescricaoFornecedor varchar(100), " +
                                        "EstadoFornecedor varchar(3), " +
                                        "FormaPagamento varchar(50), " +
                                        "PrazoPagamento varchar(50), " +
                                        "DescontoTotal varchar(30), " +
                                        "AcrescimoTotal varchar(30), " +
                                        "QuantidadeProdutos int(10), " +
                                        "TotalDocumento varchar(30))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA NF ITEMS"
            //TABELA NF ITEMS
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_nfeitens " +
                                        "(ID integer auto_increment primary key, " +
                                        "IdOperacao int(10), " +
                                        "Documentonr varchar(50), " +
                                        "Emissao date, " +
                                        "Referencia date, " +
                                        "IDProduto int(10), " +
                                        "DescricaoProduto varchar(100), " +
                                        "UnVenda varchar(3), " +
                                        "PrecoProduto varchar(30), " +
                                        "QntProduto varchar(30), " +
                                        "DescontoProduto varchar(30), " +
                                        "AcrescimoProduto varchar(30), " +
                                        "VlrTotalProduto varchar(30), " +
                                        "DescontoTotal varchar(30), " +
                                        "AcrescimoTotal varchar(30), " +
                                        "QntProdutosTotal int(10), " +
                                        "VlrTotalDocumento varchar(30))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA NFe OPERAÇÕES"
            //TABELA DADOS NFe OPERAÇÕES
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_nfeoperacoes " +
                                        "(ID integer auto_increment primary key, " +
                                        "DescricaoOperacoes varchar(50), " +
                                        "Observacoes varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();

            //COMEÇA A SELEÇÃO DE DADOS PARA GRAVAR SE NÃO EXISTIR
            //Declarando a variavel e deixando limpa
            string DNFO = string.Empty;
            MySqlConnection cn9 = new MySqlConnection(@"SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;");
            cn9.Open();
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd9 = new MySqlCommand();
            cmd9.Connection = cn9; //Abre a conexão
            cmd9.CommandText = "SELECT * FROM tb_nfeoperacoes where ID = " + 1 + ""; //Seleciona a tabela e procura os dados            
            MySqlDataReader reader9 = cmd9.ExecuteReader(); //Executa o comando selecionar

            //Faz a leitura e repassa os dados para variavel
            if (reader9.HasRows)
            {
                if (reader9.Read())
                {
                    DNFO = reader9.GetString("DescricaoOperacoes");
                }
                cmd9.Connection.Close(); //Fecha a conexão
                cn9.Close();
            }
            reader9.Close();

            if (DNFO == "")
            {
                //DECLARANDO VARIÁVEIS                
                string DNFO1 = "Compra dentro do estado";
                string DNFO2 = "";
                //COMEÇA O COMANDO PARA GRAVAR
                MySqlCommand comm9 = new MySqlCommand();
                comm9.Connection = cn9; //Abre a conexão
                comm9.CommandText = "Insert Into tb_nfeoperacoes(DescricaoOperacoes,Observacoes) Values";
                comm9.CommandText += "('" + DNFO1 + "','" + DNFO2 + "')";
                comm9.ExecuteNonQuery(); //Atualiza os registros na tabela                       
                comm9.Connection.Close(); //Fecha a conexão
                cn9.Close();
            }
            else
            {
                //CASO TENHA DADOS, FAZ A SEQUÊNCIA NORMALMENTE
            }
            cn9.Close(); //Fecha a conexão
            #endregion

            #region "TABELA PAGAMENTO FORMAS"
            //TABELA DADOS FORMAS PAGAMENTOS
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_formaspagamento " +
                                        "(ID integer auto_increment primary key, " +
                                        "DescricaoFormasPagamento varchar(50), " +
                                        "Observacoes varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();

            //COMEÇA A SELEÇÃO DE DADOS PARA GRAVAR SE NÃO EXISTIR
            //Declarando a variavel e deixando limpa
            string DFP = string.Empty;
            MySqlConnection cn6 = new MySqlConnection(@"SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;");
            cn6.Open();
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd6 = new MySqlCommand();
            cmd6.Connection = cn6; //Abre a conexão
            cmd6.CommandText = "SELECT * FROM tb_formaspagamento where ID = " + 1 + ""; //Seleciona a tabela e procura os dados            
            MySqlDataReader reader6 = cmd6.ExecuteReader(); //Executa o comando selecionar

            //Faz a leitura e repassa os dados para variavel
            if (reader6.HasRows)
            {
                if (reader6.Read())
                {
                    DFP = reader6.GetString("DescricaoFormasPagamento");
                }
                cmd6.Connection.Close(); //Fecha a conexão
                cn6.Close();
            }
            reader6.Close();

            if (DFP == "")
            {
                //DECLARANDO VARIÁVEIS                
                string DFP1 = "Dinheiro";
                string DFP2 = "";
                //COMEÇA O COMANDO PARA GRAVAR
                MySqlCommand comm6 = new MySqlCommand();
                comm6.Connection = cn6; //Abre a conexão
                comm6.CommandText = "Insert Into tb_formaspagamento(DescricaoFormasPagamento,Observacoes) Values";
                comm6.CommandText += "('" + DFP1 + "','" + DFP2 + "')";
                comm6.ExecuteNonQuery(); //Atualiza os registros na tabela                       
                comm6.Connection.Close(); //Fecha a conexão
                cn6.Close();
            }
            else
            {
                //CASO TENHA DADOS, FAZ A SEQUÊNCIA NORMALMENTE
            }
            cn6.Close(); //Fecha a conexão
            #endregion
           
            #region "TABELA PAGAMENTO PRAZOS"
            //TABELA DADOS PAGAMENTOS PRAZOS
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_prazospagamento " +
                                        "(ID integer auto_increment primary key, " +
                                        "DescricaoPrazosPagamento varchar(50), " +
                                        "Observacoes varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();

            //COMEÇA A SELEÇÃO DE DADOS PARA GRAVAR SE NÃO EXISTIR
            //Declarando a variavel e deixando limpa
            string DPP = string.Empty;
            MySqlConnection cn7 = new MySqlConnection(@"SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;");
            cn7.Open();
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd7 = new MySqlCommand();
            cmd7.Connection = cn7; //Abre a conexão
            cmd7.CommandText = "SELECT * FROM tb_prazospagamento where ID = " + 1 + ""; //Seleciona a tabela e procura os dados            
            MySqlDataReader reader7 = cmd7.ExecuteReader(); //Executa o comando selecionar

            //Faz a leitura e repassa os dados para variavel
            if (reader7.HasRows)
            {
                if (reader7.Read())
                {
                    DPP = reader7.GetString("DescricaoPrazosPagamento");
                }
                cmd7.Connection.Close(); //Fecha a conexão
                cn7.Close();
            }
            reader7.Close();

            if (DPP == "")
            {
                //DECLARANDO VARIÁVEIS                
                string DPP1 = "A Vista";
                string DPP2 = "";
                //COMEÇA O COMANDO PARA GRAVAR
                MySqlCommand comm7 = new MySqlCommand();
                comm7.Connection = cn7; //Abre a conexão
                comm7.CommandText = "Insert Into tb_prazospagamento(DescricaoPrazosPagamento,Observacoes) Values";
                comm7.CommandText += "('" + DPP1 + "','" + DPP2 + "')";
                comm7.ExecuteNonQuery(); //Atualiza os registros na tabela                       
                comm7.Connection.Close(); //Fecha a conexão
                cn7.Close();
            }
            else
            {
                //CASO TENHA DADOS, FAZ A SEQUÊNCIA NORMALMENTE
            }
            cn7.Close(); //Fecha a conexão
            #endregion
            
            #region "TABELA PAGAMENTO PRAZOS ENTREGAS"
            //TABELA DADOS PAGAMENTOS PRAZOS ENTREGAS
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_prazosentrega " +
                                        "(ID integer auto_increment primary key, " +
                                        "DescricaoPrazosEntrega varchar(50), " +
                                        "Observacoes varchar(100))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();

            //COMEÇA A SELEÇÃO DE DADOS PARA GRAVAR SE NÃO EXISTIR
            //Declarando a variavel e deixando limpa
            string DPE = string.Empty;
            MySqlConnection cn8 = new MySqlConnection(@"SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;");
            cn8.Open();
            //Começa o comando para selecionar os dados do banco
            MySqlCommand cmd8 = new MySqlCommand();
            cmd8.Connection = cn8; //Abre a conexão
            cmd8.CommandText = "SELECT * FROM tb_prazosentrega where ID = " + 1 + ""; //Seleciona a tabela e procura os dados            
            MySqlDataReader reader8 = cmd8.ExecuteReader(); //Executa o comando selecionar

            //Faz a leitura e repassa os dados para variavel
            if (reader8.HasRows)
            {
                if (reader8.Read())
                {
                    DPE = reader8.GetString("DescricaoPrazosEntrega");
                }
                cmd8.Connection.Close(); //Fecha a conexão
                cn8.Close();
            }
            reader8.Close();

            if (DPE == "")
            {
                //DECLARANDO VARIÁVEIS                
                string DPE1 = "1 Dia";
                string DPE2 = "";
                //COMEÇA O COMANDO PARA GRAVAR
                MySqlCommand comm8 = new MySqlCommand();
                comm8.Connection = cn8; //Abre a conexão
                comm8.CommandText = "Insert Into tb_prazosentrega(DescricaoPrazosEntrega,Observacoes) Values";
                comm8.CommandText += "('" + DPE1 + "','" + DPE2 + "')";
                comm8.ExecuteNonQuery(); //Atualiza os registros na tabela                       
                comm8.Connection.Close(); //Fecha a conexão
                cn8.Close();
            }
            else
            {
                //CASO TENHA DADOS, FAZ A SEQUÊNCIA NORMALMENTE
            }
            cn8.Close(); //Fecha a conexão
            #endregion

            #region "TABELA ORÇAMENTOS"
            //TABELA DADOS ORÇAMENTOS
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_orcamentos " +
                                        "(ID integer auto_increment primary key, " +
                                        "IdOrcamento int(10), " +
                                        "IdCliente int(10), " +
                                        "NomeCliente varchar(100), " +
                                        "TotalOrcamento varchar(30))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #region "TABELA VENDAS ITENS PDV"
            //TABELA DADOS VENDAS ITENS PDV
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_vendasitenspdv " +
                                        "(ID integer auto_increment primary key, " +
                                        "IDVenda int(10), " +
                                        "DataVenda date, " +
                                        "HoraVenda varchar(15), " +
                                        "NomeCliente varchar(100), " +
                                        "IDProduto int(10), " +
                                        "DescricaoProduto varchar(100), " +
                                        "UnVenda varchar(3), " +
                                        "PrecoProduto varchar(30), " +
                                        "QuantidadeProduto varchar(30), " +
                                        "DescontoProduto varchar(30), " +
                                        "ValorTotalProduto varchar(30), " +
                                        "ValorTotalVenda varchar(30))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion
            
            #region "TABELA VENDAS TOTAL PDV"
            //TABELA DADOS VENDAS TOTAL PDV
            //Informa a instrução no SQL e cria a tabela se ela não existir
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS tb_vendastotalpdv " +
                                        "(ID integer auto_increment primary key, " +
                                        "IDVenda int(10), " +
                                        "DataVenda date, " +
                                        "HoraVenda varchar(15), " +
                                        "NomeCliente varchar(100), " +
                                        "TotalVenda varchar(30))", Conexao);
            //Executa a Query no MySQL (raio do workbench)
            Comando.ExecuteNonQuery();
            #endregion

            #endregion

            #region "FECHA A CONEXÃO COM O BANCO"
            //Fecha a conexão com o banco de dados
            Conexao.Close();
            #endregion
        }
    }
}
