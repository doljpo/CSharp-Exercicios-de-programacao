using System;
using System.Collections.Generic;
using System.Linq;

namespace exercicios_programacao_01.BancoTPeople
{
    public class BancoTPeople
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
            Console.WriteLine("************* Tabela  Pessoas *************");
            Console.WriteLine("*******************************************");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Escolha a opção desejada e pressione Enter");
            Console.WriteLine(string.Empty);
            Console.WriteLine("1 - Listar todas pessoas.");
            Console.WriteLine("2 - Listar pessoas com nome contendo 'Rodr' e ordenadas por Documento.");
            Console.WriteLine("3 - Listar pessoas com idade superior a 20 anos.");
            Console.WriteLine("4 - Acessar menu de testes.");
            Console.WriteLine("5 - Fechar aplicação.");
            Console.WriteLine(string.Empty);
            Console.WriteLine("******************************************");
        }

        private static void ExecutarOpcaoSelecionada(int opcaoSelecionada)
        {
            var apresentarPontoDeParada = true;

            switch (opcaoSelecionada)
            {
                case 1:
                    ListPeople();
                    break;
                case 2:
                    ListPeople(name: "Rodr", sorted: true);
                    break;
                case 3:
                    ListPeople(age: 20);
                    break;
                case 4:
                    AcessoTestes.MenuInicial();
                    break;
                case 5:
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

        private static void ListPeople(string name = "", bool sorted = false, int age = -1)
        {
            using (var repository = new PersonDAO())
            {
                if (sorted)
                {
                    var peopleNameContains = repository.People()
                        .Where(p => p.FullName.ToUpper().Contains(name.ToUpper())).ToList();

                    peopleNameContains.Sort((p1, p2) => string.Compare(p1.Document, p2.Document));

                    PrintPerson(peopleNameContains, age);
                }
                else
                {
                    PrintPerson(repository.People(), age);
                }
            };
        }

        private static void PrintPerson(List<Person> people, int filterAge)
        {
            var baseDate = new DateTime(1, 1, 1);

            Console.WriteLine("*****");

            foreach (var person in people)
            {
                var timeSpan = DateTime.Today - person.BornDate;
                var idade = ((baseDate + timeSpan).Year - 1);

                if (idade > filterAge)
                {
                    Console.WriteLine($"ID:        {person.ID}");
                    Console.WriteLine($"Nome:      {person.FullName}");
                    Console.WriteLine($"Idade:     {idade}");
                    Console.WriteLine($"Documento: {person.Document}");

                    Console.WriteLine("*****");
                }
            }
        }

        private static void FecharAplicacao()
        {
            Environment.Exit(0);
        }
    }
}
