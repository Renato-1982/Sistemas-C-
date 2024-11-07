using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGRas
{
    public class ClasseBDConexao
    {
        public static MySqlConnection abrir()
        {
            #region 'CONEXÃO DO BANCO'
            string StrCon = "SERVER=localhost; DATABASE=sigrassystembd; UID=root; PWD=ABCmultseg01012020;"; //Caminho do banco
            MySqlConnection cn = new MySqlConnection(StrCon);
            cn.Open(); //Abre a conexão
            return cn;
            #endregion
        }
    }
}
