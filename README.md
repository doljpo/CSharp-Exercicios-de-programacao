Desenvolvida em .netcore Console Application, a aplicação resolve alguns exercícios propostos e possui um sistema de navegação pelo teclado acessando opções de um menu em interface console.

Exemplo de menu de navegação (menu inicial):

      *******************************************
      ******** Menu de Acesso aos Testes ********
      *******************************************

      Escolha o teste desejado e pressione Enter:

      1 - Cálculo de médias (Teste 01).
      2 - Caixa Eletrônico (Teste 02).
      3 - Banco TPeople (Teste 03).
      4 - Método do Luke (Teste 04).
      5 - Fechar aplicação.

      *******************************************

Exercícios propostos:

1) Crie um método que receba n números decimais e calcule a média, a mediana e o
conceito desta lista. Os três valores devem ser retornados.
Conceito deve utilizar a média e ser calculado da seguinte forma:

* A >= 9,0;
* B >= 7,5 e < 9,0;
* C >= 6,0 e < 7,5;
* D >= 4,0 e < 6,0;
* E < 4,0
     
-----------

2) Desenvolva uma solução que simule um caixa eletrônico e que permita ao cliente
efetuar um saque. Os requisitos básicos são os seguintes:

* Entregar o menor número de notas possível;
* Só deve ser possível sacar o valor solicitado com as notas disponíveis;
* Saldo do cliente infinito;
* Quantidade de notas infinito;
* Notas disponíveis de R$ 100,00; R$ 50,00; R$ 20,00; R$ 10,00; R$ 5,00; R$ 2,00;
    
-----------

3 - Em um banco já existente, existe uma tabela com nome TPEOPLE, nessa tabela existem
as seguintes colunas: CPERSON_ID, CCODE, CFULL_NAME, CDOCUMENT, CBORN_DATE;

* Crie uma query que selecione todos os registros que contém “Rodr” no Nome Completo e ordene os resultados pelo Documento;
* Crie uma query que selecione todos os registros da tabela TPEOPLE onde a idade seja maior que 20 anos;

-----------

4 - Luke Skywalker fez um método para retornar a primeira pessoa em uma lista, Leia foi
testar e o método deu erro em sua única linha, você ficou encarregado de arrumar e
recebeu apenas os seguintes dados:

->InvalidOperationException: “A sequência não contém elementos”

public Person GetFirst(List<Person> people) {
     return people.First();
 }
  
* Descreva em código três maneiras de resolução do erro para ajudar Luke;
