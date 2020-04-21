using System;
using System.Collections.Generic;

namespace exercicios_programacao_01
{
    class AcessoTestes
    {
        private static List<decimal> numeros = new List<decimal>();

        static void Main(string[] args)
        {
            MenuInicial();
        }

        public static void MenuInicial()
        {
            while (true)
            {
                ApresentarMenu();

                var opcaoSelecionada = 0;
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
            Console.WriteLine("******** Menu de Acesso aos Testes ********");
            Console.WriteLine("*******************************************\n");
            Console.WriteLine("Escolha o teste desejado e pressione Enter:\n");
            Console.WriteLine("1 - Cálculo de médias (Teste 01).");
            Console.WriteLine("2 - Caixa Eletrônico (Teste 02).");
            Console.WriteLine("3 - Banco TPeople (Teste 03).");
            Console.WriteLine("4 - Método do Luke (Teste 04).");
            Console.WriteLine("5 - Fechar aplicação.");
            Console.WriteLine("\n*******************************************");
        }

        private static void ExecutarOpcaoSelecionada(int opcaoSelecionada)
        {
            switch (opcaoSelecionada)
            {
                case 1:
                    Medias.MenuInicial();
                    break;
                case 2:
                    CaixaEletronico.MenuInicial();
                    break;
                case 3:
                    BancoTPeople.BancoTPeople.MenuInicial();
                    break;
                case 4:
                    LukesMethod.MenuInicial();
                    break;
                case 5:
                    FecharAplicacao();
                    break;
                default:
                    Console.WriteLine("\nOpção inválida.");
                    break;
            }
        }

        private static void FecharAplicacao()
        {
            Environment.Exit(0);
        }
    }
}
