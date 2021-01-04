using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.RecebeLance(fulano, 1000);

            leilao.TerminaPregao();

            Console.WriteLine(leilao.Ganhador.Valor);

            Console.ReadLine();
        }
    }
}
