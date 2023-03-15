using NUnit.Framework;

namespace NumerosRomanos
{
    public class NumerosRomanosTeste
    {
        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("X", 10)]
        [TestCase("L", 50)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        [TestCase("III", 3)]
        [TestCase("LVIII", 58)]
        [TestCase("MCMXCIV", 1994)]
        public void Teste(string numeroRomano, int resultadoEsperado)
        {
            var resultado = NumeroRomanoParaInteiro(numeroRomano);

            Assert.AreEqual(resultadoEsperado, resultado);
        }

        public int NumeroRomanoParaInteiro(string str)
        {
            int valorFinal = 0;

            for (var r = 0; r < str.Length; r++)
            {
                switch (str[r])
                {
                    case 'M':
                        valorFinal += 1000;
                        break;

                    case 'D':
                        valorFinal += 500;
                        break;

                    case 'C':
                        _ = (r + 1 < str.Length && (str[r + 1] == 'M' || str[r + 1] == 'D')) ? valorFinal -= 100 : valorFinal += 100;
                        break;

                    case 'L':
                        valorFinal += 50;
                        break;

                    case 'X':
                        _ = (r + 1 < str.Length && (str[(r + 1)] == 'L' || str[r + 1] == 'C')) ? valorFinal -= 10 : valorFinal += 10;
                        break;

                    case 'V':
                        valorFinal += 5;
                        break;

                    case 'I':
                        _ = (r + 1 < str.Length && (str[r + 1] == 'X' || str[r + 1] == 'V')) ? valorFinal -= 1 : valorFinal += 1;
                        break;
                }
            }

            return valorFinal;
        }
    }
}