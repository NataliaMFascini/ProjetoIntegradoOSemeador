using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LivrariaEBiblioteca
{
    public class Conexao
    {
        private static string stringConn = "Server=localhost;Port=3306;Database=dbOSemeador;Uid=root;Pwd=''";
        private static MySqlConnection conn = null;

        public static MySqlConnection obterConexao()
        {
            conn = new MySqlConnection(stringConn);

            try
            {
                conn.Open();
            }
            catch (MySqlException)
            {
                conn = null;
            }

            return conn;
        }

        public static void fecharConexao()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
