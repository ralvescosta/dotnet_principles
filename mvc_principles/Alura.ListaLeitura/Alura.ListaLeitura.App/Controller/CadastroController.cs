using Alura.ListaLeitura.App.Model;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        public IActionResult NovoLivro()
        {
            var html = new ViewResult { ViewName = "formulario" };
            return html;
        }

        public string Incluir(Livro livro)
        {
            var _repo = new LivroRepositorioCSV();

            _repo.Incluir(livro);

            return "Livro foi adicionado com sucesso";
        }
    }
}
