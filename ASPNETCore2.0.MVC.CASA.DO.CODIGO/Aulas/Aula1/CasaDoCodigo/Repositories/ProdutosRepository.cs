using CasaDoCodigo.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Repositories
{
    public class ProdutosRepository : BaseRepository<Produto>, IProdutosRepository
    {
        public ProdutosRepository(ApplicationContext contexto): base(contexto) { }

        public IList<Produto> GetProdutos()
        {
            return new List<Produto>(dbSet);
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if(dbSet.Find(livro.Nome) == null)
                {
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }

            contexto.SaveChanges();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
