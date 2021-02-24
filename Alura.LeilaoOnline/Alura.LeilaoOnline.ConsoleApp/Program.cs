using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
        }

        private static void LeilaoComApenasUmLance()
        {
            //arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);

            //act
            leilao.RecebeLance(fulano, 800);

            leilao.TerminaPregao();

            //assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);
        }

        private static void LeilaoComVariosLances()
        {
            //arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            //act
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            leilao.TerminaPregao();

            //assert
            var valorEsperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }

        private static void Verifica(double valorEsperado, double valorObtido)
        {
            var cor = Console.ForegroundColor;
            if (valorEsperado == valorObtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teste ok");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Teste falhou! Esperado {valorEsperado}, Obtido {valorObtido}");
            }
            Console.ForegroundColor = cor;
        }
    }
}
