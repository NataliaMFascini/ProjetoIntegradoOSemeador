using System;
using System.Collections.Generic;
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

        public int quantidadeRetorno(int index)
        {
            int quantTotal = 0;

            while (ListaLivros[index].Equals(ListaLivros[index + 1]))
            {
                quantTotal++;
            }

            return quantTotal;
        }
    }
}
