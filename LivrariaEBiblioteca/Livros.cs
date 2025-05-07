using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaEBiblioteca
{
    public class Livros
    {
        public int idLivro { get; set; }
        public string nomeLivro { get; set; }
        public decimal valorLivro { get; set; }
        public int quantidade { get; set; }

        public static List<Livros> ListaLivros = new List<Livros>();

        public Livros()
        {

        }

        public int codRetorno(int index)
        {
            int codLivro = ListaLivros[index].idLivro;

            return codLivro;
        }

        public string nomeRetorno(int index)
        {
            string titulo = ListaLivros[index].nomeLivro;

            return titulo;
        }

        public decimal valorRetorno(int index)
        {
            decimal valor = ListaLivros[index].valorLivro;

            return valor;
        }

        public int checarEstoque(int idLivro, string empVen)
        {
            int estoque = 0;

            MySqlCommand comm = new MySqlCommand();
            if (empVen == "Ven")
            {
                comm.CommandText = "select entradaVen, saidaVen, codLivro  from tbEstoque where codLivro like '%" + idLivro + "%';";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                estoque = DR.GetInt32(0) - DR.GetInt32(1);

                Conexao.fecharConexao();
            }
            if (empVen == "Emp")
            {
                comm.CommandText = "select entradaEmp, saidaEmp, codLivro  from tbEstoque where codLivro like '%" + idLivro + "%';";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                estoque = DR.GetInt32(0) - DR.GetInt32(1);

                Conexao.fecharConexao();
            }

            return estoque;
        }

        public int quantidadeLista()
        {
            int quantidadeLista = 1;

            for (int i = 0; i < ListaLivros.Count - 1; i++)
            {
                if (ListaLivros[i].idLivro != ListaLivros[i + 1].idLivro)
                {
                    quantidadeLista++;
                }
            }
            return quantidadeLista;
        }

        public int proximoLivro(int index)
        {
            int proximoId = 0;

            for (int i = 0; i < ListaLivros.Count; i++)
            {
                if (i == index)
                {
                    proximoId = ListaLivros[i].idLivro;
                }
                else
                {
                    if (ListaLivros[i].idLivro != proximoId)
                    {
                        proximoId = ListaLivros[i].idLivro;
                        break;
                    }
                }
            }
            return proximoId;
        }
    }
}
