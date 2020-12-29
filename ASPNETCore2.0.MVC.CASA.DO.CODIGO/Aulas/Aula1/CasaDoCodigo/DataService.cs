using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    public partial class Startup
    {
        public class DataService : IDataService
        {
            private readonly ApplicationContext contexto;
            private readonly IProdutosRepository produtoRepository;

            public DataService(ApplicationContext contexto, IProdutosRepository produtoRepository)
            {
                this.contexto = contexto;
                this.produtoRepository = produtoRepository;
            }

            private static List<Livro> GetLivros()
            {
                var json = File.ReadAllText("livros.json");
                var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
                return livros;
            }

            public void inicializaDatabase()
            {
                contexto.Database.Migrate();

                //var livros = GetLivros();
                //produtoRepository.SaveProdutos(livros);
            }

            
        }

 
    }
}
