using Alura.LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
   public class LeilaoRecebeOferta
    {

        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimo()
        {
            //arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);


            //act
            leilao.RecebeLance(fulano, 1000);

            // assert
            var qtdeEsperada = 1;
            var qtdeObtido = leilao.Lances.Count();
            Assert.Equal(qtdeEsperada, qtdeObtido);
        }

        [Theory]
        [InlineData(2, new double[] { 800, 900})]
        [InlineData(3, new double[] { 800, 900, 1000 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperada, double[] ofertas)
        {
            //arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var beltrano = new Interessada("Beltrano", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, ofertas[i]);
                }
                else
                {
                    leilao.RecebeLance(beltrano, ofertas[i]);
                }
            }
            leilao.TerminaPregao();

            //act
            leilao.RecebeLance(fulano, 1000);

            // assert
            var qtdeObtido = leilao.Lances.Count();
            Assert.Equal(qtdeEsperada, qtdeObtido);
        }
    }
}
