using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1200, 1250, new double[] { 800, 1150, 1400, 1250})]
        public void RetornaValorSuperiorMaisProximoDadoLeilaoNessaModalidade(double valorDestino, double valorEsperado, double[] ofertas) {
            //arranje
            var modalidade = new OfertaSuperiorMiasProxima(valorDestino);
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

            //act
            leilao.TerminaPregao();

            //assert
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        [Theory]
        [InlineData(1000, new double[] { 800, 900, 1000})]
        [InlineData(1000, new double[] { 900, 800, 1000 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPelomenosUmLance(double valorEsperado, double[] ofertas)
        {
            //arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var beltrano = new Interessada("Beltrano", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                if((i%2) == 0)
                {
                    leilao.RecebeLance(fulano, ofertas[i]);
                }else
                {
                    leilao.RecebeLance(beltrano, ofertas[i]);
                }
            }

            //act
            leilao.TerminaPregao();

            //assert
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadoPregaoNaoIniciado()
        {
            //arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);

            //assert
            var execao = Assert.Throws<System.InvalidOperationException>(
                () => 
                //act 
                leilao.TerminaPregao()
            );
            Assert.Equal("Nao e possivel terminar o pregao sem que ele tenha comecado. Para isso, utilize o metodo IniciaPregao().", execao.Message);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemNenhumLance()
        {
            //arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();

            //act
            leilao.TerminaPregao();

            //assert
            Assert.Equal(0, leilao.Ganhador.Valor);
        }
    }
}
