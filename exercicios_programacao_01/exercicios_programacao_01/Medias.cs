using System;
using System.Collections.Generic;

namespace exercicios_programacao_01
{
    class Medias
    {
        private static List<decimal> numeros = new List<decimal>();

        public static void MenuInicial()
        {
            while (true)
            {
                var opcaoSelecionada = 0;

                ApresentarMenu();

                try
                {
                    opcaoSelecionada = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opcaoSelecionada = -1;
                }

                ExecutarOpcaoSelecionada(opcaoSelecionada);
            }
        }

        private static void ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("*******************************************");
            Console.WriteLine("******** Média, Mediana e Conceito ********");
            Console.WriteLine("*******************************************\n");
            Console.WriteLine("Escolha a opção desejada e pressione Enter\n");
            Console.WriteLine("1 - Informar um novo número.");
            Console.WriteLine("2 - Calcular a média.");
            Console.WriteLine("3 - Calcular a mediana.");
            Console.WriteLine("4 - Calcular o conceito.");
            Console.WriteLine("5 - Realizar todos os cálculos.");
            Console.WriteLine("6 - Reiniciar aplicação.");
            Console.WriteLine("7 - Voltar ao menu de testes.");
            Console.WriteLine("8 - Fechar aplicação.");
            Console.WriteLine("\n*******************************************");

            if (numeros.Count > 0)
            {
                var valoresInformados = string.Empty;
                for (int i = 0; i < numeros.Count; i++)
                {
                    valoresInformados += numeros[i].ToString() + " ";
                }

                Console.WriteLine("\nValores até o momento: " + valoresInformados);
                Console.WriteLine("\n******************************************");
            }
        }

        private static void ExecutarOpcaoSelecionada(int opcaoSelecionada)
        {
            var apresentarPontoDeParada = true;

            switch (opcaoSelecionada)
            {
                case 1:
                    ReceberValores();
                    apresentarPontoDeParada = false;
                    break;
                case 2:
                    CalcularMedia();
                    break;
                case 3:
                    CalcularMediana();
                    break;
                case 4:
                    CalcularConceito();
                    break;
                case 5:
                    CalcularTudo();
                    break;
                case 6:
                    ReiniciarAplicacao();
                    apresentarPontoDeParada = false;
                    break;
                case 7:
                    AcessoTestes.MenuInicial();
                    break;
                case 8:
                    FecharAplicacao();
                    break;
                default:
                    Console.WriteLine("\n   Opção inválida.");
                    break;
            }

            if (apresentarPontoDeParada)
            {
                Console.Write("\nPressione qualquer tecla para continuar.");
                Console.ReadKey();
            }
        }

        private static void ReceberValores()
        {
            Console.Write("\nInforme o valor desejado e pressione Enter: ");

            try
            {
                var numero = Console.ReadLine();
                numeros.Add(Convert.ToDecimal(numero));
            }
            catch
            {
                Console.WriteLine("\n   O valor informado é inválido.");
                Console.Write("\nPressione qualquer tecla para continuar.");
                Console.ReadKey();
            }
        }

        private static void CalcularMedia()
        {
            decimal media = 0;
            foreach (var numero in numeros)
            {
                media += numero;
            }

            ApresentarResultado("\n     A média calculada", (media / numeros.Count).ToString());
        }

        private static void CalcularMediana()
        {
            var numerosOrdenados = new List<decimal>();
            numerosOrdenados.AddRange(numeros);
            numerosOrdenados.Sort();

            var indiceMediana = Convert.ToInt32(Math.Floor(Convert.ToDecimal(numerosOrdenados.Count / 2)));

            decimal mediana = 0;
            if ((numerosOrdenados.Count % 2) == 0)
            {
                mediana = (numerosOrdenados[indiceMediana - 1] + numerosOrdenados[indiceMediana]) / 2;
            }
            else
            {
                mediana = numerosOrdenados[indiceMediana];
            }

            ApresentarResultado("\n     A mediana calculada", mediana.ToString());
        }

        private static void CalcularConceito()
        {
            decimal media = 0;
            foreach (var numero in numeros)
            {
                media += numero;
            }

            media = media / numeros.Count;
            var conceito = string.Empty;

            if (media >= 9)
            {
                conceito = "A";
            }
            else if (media >= Convert.ToDecimal(7.5) && media < 9)
            {
                conceito = "B";
            }
            else if (media >= 6 && media < Convert.ToDecimal(7.5))
            {
                conceito = "C";
            }
            else if (media >= 4 && media < 6)
            {
                conceito = "D";
            }
            else
            {
                conceito = "E";
            }

            ApresentarResultado("\n     O conceito calculado", conceito);
        }

        private static void CalcularTudo()
        {
            CalcularMedia();
            CalcularMediana();
            CalcularConceito();
        }

        private static void ApresentarResultado(string tipoCalculo, string valor)
        {
            Console.WriteLine($"{tipoCalculo} dos valores informados é: {valor}");
        }

        private static void ReiniciarAplicacao()
        {
            numeros.Clear();
        }

        private static void FecharAplicacao()
        {
            Environment.Exit(0);
        }
    }
}
