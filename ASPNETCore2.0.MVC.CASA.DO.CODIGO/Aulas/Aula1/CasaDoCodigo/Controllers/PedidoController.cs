using Microsoft.AspNetCore.Mvc;
using CasaDoCodigo.Repositories;
using System;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {

        private readonly IProdutosRepository produtoRepository;

        public PedidoController(IProdutosRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public IActionResult Carrossel()
        {
            var produtos = produtoRepository.GetProdutos();
            
            return View(produtos);
        }
        //

        public IActionResult Carrinho()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Resumo()
        {
            return View();
        }
    }
}
