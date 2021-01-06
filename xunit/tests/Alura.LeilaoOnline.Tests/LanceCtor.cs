using System;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {   
        [Fact]
        public void LancaArgumentoExceptionDoValorNegativo()
        {
            //arranje
            var valorNegativo = -1000;

            //assert
            Assert.Throws<ArgumentException>(
                //act
                () => new Lance(null, valorNegativo)
            );
        }
    }
}
