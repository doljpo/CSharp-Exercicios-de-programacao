using System;

namespace exercicios_programacao_01
{
    class CaixaEletronico
    {
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
            Console.WriteLine("************ Caixa  Eletrônico ************");
            Console.WriteLine("*******************************************");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Escolha a opção desejada e pressione Enter");
            Console.WriteLine(string.Empty);
            Console.WriteLine("1 - Sacar.");
            Console.WriteLine("2 - Acessar o menu de testes.");
            Console.WriteLine("3 - Fechar aplicação.");
            Console.WriteLine(string.Empty);
            Console.WriteLine("******************************************");
        }

        private static void ExecutarOpcaoSelecionada(int opcaoSelecionada)
        {
            switch (opcaoSelecionada)
            {
                case 1:
                    ProcessarSaque();
                    break;
                case 2:
                    AcessoTestes.MenuInicial();
                    break;
                case 3:
                    FecharAplicacao();
                    break;
                default:
                    Console.WriteLine("\n   Opção inválida.");
                    break;
            }

            Console.Write("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private static void ProcessarSaque()
        {
            var valorSaque = SolicitarValorDeSaque();

            if (valorSaque < 2)
            {
                InformarSaqueInvalido();
            }
            else
            {
                var saque = new Saque();

                CalcularNotasDeSaque(saque, valorSaque);

                if (saque.saqueImpossivel)
                {
                    InformarSaqueInvalido();
                }
                else
                {
                    Console.WriteLine("\nNotas sacadas: \n");

                    if (saque.notas100 > 0)
                        Console.WriteLine($"    >> R$ 100,00: {saque.notas100} notas");
                    if (saque.notas50 > 0)
                        Console.WriteLine($"    >> R$  50,00: {saque.notas50} notas");
                    if (saque.notas20 > 0)
                        Console.WriteLine($"    >> R$  20,00: {saque.notas20} notas");
                    if (saque.notas10 > 0)
                        Console.WriteLine($"    >> R$  10,00: {saque.notas10} notas");
                    if (saque.notas5 > 0)
                        Console.WriteLine($"    >> R$   5,00: {saque.notas5} notas");
                    if (saque.notas2 > 0)
                        Console.WriteLine($"    >> R$   2,00: {saque.notas2} notas");
                }
            }
        }

        private static int SolicitarValorDeSaque()
        {
            Console.Write("Informe o valor desejado para o saque e pressione Enter: ");

            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                return -1;
            }
        }

        private static void CalcularNotasDeSaque(Saque saque, int valorSaque)
        {
            if (valorSaque >= 100)
            {
                saque.notas100 = valorSaque / 100;
                valorSaque -= (saque.notas100 * 100);
            }

            if (valorSaque >= 50)
            {
                saque.notas50 = valorSaque / 50;
                valorSaque -= (saque.notas50 * 50);
            }

            if (valorSaque >= 20)
            {
                saque.notas20 = valorSaque / 20;
                valorSaque -= (saque.notas20 * 20);
            }

            if (valorSaque >= 10)
            {
                saque.notas10 = valorSaque / 10;
                valorSaque -= (saque.notas10 * 10);
            }

            if (valorSaque % 2 == 0)
            {
                saque.notas2 = valorSaque / 2;
                valorSaque -= (saque.notas2 * 2);
            }
            else
            {
                if (valorSaque >= 5)
                {
                    saque.notas5 = valorSaque / 5;
                    valorSaque -= (saque.notas5 * 5);
                }

                if (valorSaque >= 2)
                {
                    saque.notas2 = valorSaque / 2;
                    valorSaque -= (saque.notas2 * 2);
                }
            }

            saque.saqueImpossivel = valorSaque > 0;
        }

        private static void InformarSaqueInvalido()
        {
            Console.WriteLine("\n   O valor solicitado para saque é inválido.");
        }

        private static void FecharAplicacao()
        {
            Environment.Exit(0);
        }
    }

    class Saque
    {
        public int notas100;
        public int notas50;
        public int notas20;
        public int notas10;
        public int notas5;
        public int notas2;

        public bool saqueImpossivel;
    }
}
