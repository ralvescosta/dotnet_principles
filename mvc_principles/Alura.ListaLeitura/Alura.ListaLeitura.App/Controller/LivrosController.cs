using Alura.ListaLeitura.App.Model;
using Alura.ListaLeitura.App.Repositorio;
using Alura.ListaLeitura.App.View;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController : Controller
    {
        public IActionResult ParaLer()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.ParaLer.Livros;

            return View("para-ler");
        }

        public IActionResult Lendo()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lendo.Livros;

            return View("lendo");
        }

        public IActionResult Lidos()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lendo.Livros;

            return View("lidos");
        }


        public string Detalhes(int id)
        {
            var _repo = new LivroRepositorioCSV();

            Livro livro = null;
            foreach (var item in _repo.Todos)
            {
                if (item.Id == id)
                {
                    livro = item;
                    break;
                }
            }

            if (livro == null)
            {
                return "";
            }
            return livro.Detalhes();
        }
    }
}
