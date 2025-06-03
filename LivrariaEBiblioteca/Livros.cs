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

        public int checarEstoque(int idLivro, string tipo)
        {
            int estoque = 0;

            MySqlCommand comm = new MySqlCommand();
            if (tipo == "Ven")
            {
                comm.CommandText = "select entradaVen, saidaVen, codLivro  from tbEstoqueL where codLivro = @codLivro;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = idLivro;

                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                DR.Read();

                estoque = DR.GetInt32(0) - DR.GetInt32(1);

                Conexao.fecharConexao();
            }
            if (tipo == "Emp")
            {
                comm.CommandText = "select entradaEmp, saidaEmp, codLivro  from tbEstoqueB where codLivro = @codLivro;";
                comm.CommandType = CommandType.Text;

                comm.Parameters.Clear();
                comm.Parameters.Add("@codLivro", MySqlDbType.Int32).Value = idLivro;

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

        public int pegarID(string nomeLivroPesquisa, string tipoPesquisa)
        {
            int idLivroPesquisa = 0;

            MySqlCommand comm = new MySqlCommand();
            if (tipoPesquisa == "emprestimo")
            {
                comm.CommandText = "select codLivro from tbLivroB where nome = @nome;";
                comm.CommandType = CommandType.Text;
            }
            if (tipoPesquisa == "venda")
            {
                comm.CommandText = "select codLivro from tbLivroL where nome = @nome;";
                comm.CommandType = CommandType.Text;
            }
            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nomeLivroPesquisa;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            idLivroPesquisa = DR.GetInt32(0);

            Conexao.fecharConexao();

            return idLivroPesquisa;
        }
    }
}
