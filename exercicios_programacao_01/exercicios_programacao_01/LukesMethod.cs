using System;

namespace exercicios_programacao_01
{
    class LukesMethod
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
            Console.WriteLine("************* Método do Luke **************");
            Console.WriteLine("*******************************************");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Escolha a opção desejada e pressione Enter");
            Console.WriteLine(string.Empty);
            Console.WriteLine("1 - Exibir Método Original.");
            Console.WriteLine("2 - Solução 1.");
            Console.WriteLine("3 - Solução 2.");
            Console.WriteLine("4 - Solução 3.");
            Console.WriteLine("5 - Acessar menu de testes.");
            Console.WriteLine("6 - Fecha aplicação.");
            Console.WriteLine(string.Empty);
            Console.WriteLine("******************************************");
        }

        private static void ExecutarOpcaoSelecionada(int opcaoSelecionada)
        {
            switch (opcaoSelecionada)
            {
                case 1:
                    ExibirMetodoOriginal();
                    break;
                case 2:
                    ExibirPrimeiraSolucao();
                    break;
                case 3:
                    ExibirSegundaSolucao();
                    break;
                case 4:
                    ExibirTerceiraSolucao();
                    break;
                case 5:
                    AcessoTestes.MenuInicial();
                    break;
                case 6:
                    FecharAplicacao();
                    break;
                default:
                    Console.WriteLine("\n   Opção inválida.");
                    break;
            }

            Console.Write("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        private static void ExibirMetodoOriginal()
        {
            /*
             * Erro: InvalidOperationException: “A sequência não contém elementos”
             
            public Person GetFirst(List<Person> people)
            {
                return people.First();
            }
            */

            Console.WriteLine("\n   public Person GetFirst(List<Person> people)");
            Console.WriteLine("     {");
            Console.WriteLine("         return people.First();");
            Console.WriteLine("     }");
        }

        private static void ExibirPrimeiraSolucao()
        {
            /*
             
            public Person GetFirst(List<Person> people)
            {
                return people.FirstOrDefault();
            }
            */

            Console.WriteLine("\nUtilizando 'FirstOrDefault()' ao invés de 'First()'");

            Console.WriteLine("\n   public Person GetFirst(List<Person> people)");
            Console.WriteLine("     {");
            Console.WriteLine("         return people.FirstOrDefault();");
            Console.WriteLine("     }");
        }

        private static void ExibirSegundaSolucao()
        {
            /*
            public Person GetFirst(List<Person> people)
            {
                try
                {
                    return people.First();
                }
                catch
                {
                    throw new Exception("Nenhuma pessoa encontrada.");
                }
            }
            */

            Console.WriteLine("\nUtilizando 'try..catch' genérico e tratando na chamada do método conforme necessário");

            Console.WriteLine("\n   public Person GetFirst(List<Person> people)");
            Console.WriteLine("     {");
            Console.WriteLine("         try");
            Console.WriteLine("         {");
            Console.WriteLine("             return people.First();");
            Console.WriteLine("         }");
            Console.WriteLine("         catch");
            Console.WriteLine("         {");
            Console.WriteLine("             throw new Exception(\"Nenhuma pessoa encontrada.\");");
            Console.WriteLine("         }");
            Console.WriteLine("     }");
        }

        private static void ExibirTerceiraSolucao()
        {
            /*
            public Person GetFirst(List<Person> people)
            {
                if (people.Count > 0)
                {
                    return people.First();
                }
                else
                {
                    return new Person();
                }
            }
            */

            Console.WriteLine("\nRealizando um teste antes de acessar a lista e tratando a chamada do método conforme necessário");

            Console.WriteLine("\n   public Person GetFirst(List<Person> people)");
            Console.WriteLine("     {");
            Console.WriteLine("         if (people.Count > 0)");
            Console.WriteLine("         {");
            Console.WriteLine("             return people.First();");
            Console.WriteLine("         }");
            Console.WriteLine("         else");
            Console.WriteLine("         {");
            Console.WriteLine("             return new Person();");
            Console.WriteLine("         }");
            Console.WriteLine("     }");
        }

        private static void FecharAplicacao()
        {
            Environment.Exit(0);
        }
    }
}
