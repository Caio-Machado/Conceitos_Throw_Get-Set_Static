using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {

    // Instanciando
    Empregado atualiza_empregado = new Empregado("Nome", "Sobrenome", 0);
    
    // Atributos
    List<Empregado> lista_empregados = new List<Empregado>{};

    string adiciona_pri_nome, adiciona_sob_nome, atualiza_pri, atualiza_sob;

    double adiciona_sal, atualiza_sal;

    int resposta_menu, funcionario_selecionado, atributo_selecionado;

    bool sentinela = true;

    while (sentinela == true) {
      try {
        Console.Write(@"Digite o que deseja fazer:
1 - Adiciona Funcionário
2 - Listar Funcionários
3 - Ajustar informações de algum Funcionário
4 - Dar aumento de 10% ao salário do Funcionário
5 - Sair
>> ");
        resposta_menu = int.Parse(Console.ReadLine());

        switch (resposta_menu) {
          case 1:
            Console.Clear();
            Console.Write("Digite o nome do funcionário >> ");
            adiciona_pri_nome = Console.ReadLine();

            if (adiciona_pri_nome == "") {
              throw new ArgumentException();
            }

            Console.Write("Digite o sobrenome do funcionário >> ");
            adiciona_sob_nome = Console.ReadLine();

            if (adiciona_sob_nome == "") {
              throw new ArgumentException();
            }

            Console.Write("Digite o salário mensal do funcoonário >> ");
            adiciona_sal = double.Parse(Console.ReadLine());

            if (adiciona_sal <= 0) {
              throw new SystemException();
            }

            atualiza_empregado = new Empregado(adiciona_pri_nome, adiciona_sob_nome, adiciona_sal);
            lista_empregados.Add(atualiza_empregado);

            break;

          case 2:
            if (lista_empregados.Count == 0) {
              Console.WriteLine("Não há funcionários cadastrados!!");
              delay();
            }

            else if (lista_empregados.Count > 0) {
              Console.Clear();
              for (int x=0; x < lista_empregados.Count; x++) {
                Console.WriteLine($@"
                --------------------------------------
                ID do funcionário: {x}
                Nome completo do funcionário: {lista_empregados[x].get_pri_nome()} {lista_empregados[x].get_sob_nome()}
                Salário mensal do funcionário: {lista_empregados[x].get_sal_mensal()}R$
                --------------------------------------");
              }
            }

            break;

          case 3:
            if (lista_empregados.Count == 0) {
              Console.WriteLine("Não há funcionários cadastrados!!");
              delay();
            }

            else if (lista_empregados.Count > 0) {
              Console.Write("Digite o ID do funcionário que pode ser obtido listando os funcionários >> ");
              funcionario_selecionado = int.Parse(Console.ReadLine());

              if (funcionario_selecionado < 0 || funcionario_selecionado >= lista_empregados.Count) {
                Console.WriteLine("ID de funcionário não cadastrado!!");

                break;
              }

              Console.Write(@"Selecione o atributo a ser atualizado:
1 - Nome
2 - Sobrenome
3 - Salário
>> ");
            atributo_selecionado = int.Parse(Console.ReadLine());

              if (atributo_selecionado < 1 || atributo_selecionado > 3) {
                throw new ArgumentException();
              }

              else if (atributo_selecionado >= 1 || atributo_selecionado <= 3) {
                if (atributo_selecionado == 1) {
                  Console.Write("Digite o novo nome >> ");
                  atualiza_pri = Console.ReadLine();

                  lista_empregados[funcionario_selecionado].set_pri_nome(atualiza_pri);
                }

                else if (atributo_selecionado == 2) {
                  Console.Write("Digite o novo sobrenome >> ");
                  atualiza_sob = Console.ReadLine();

                  lista_empregados[funcionario_selecionado].set_sob_nome(atualiza_sob);
                }

                else {
                  Console.Write("Digite o novo salário >> ");
                  atualiza_sal = double.Parse(Console.ReadLine());

                  lista_empregados[funcionario_selecionado].set_sal(atualiza_sal);
                }

                Console.WriteLine("Dados atualizados com sucesso!!");
                delay();
              }
            }

            break;

          case 4:
            Console.Write("Digite o ID do funcionário que pode ser obtido listando os funcionários >> ");
            funcionario_selecionado = int.Parse(Console.ReadLine());

            if (lista_empregados.Count == 0) {
              Console.WriteLine("Não há funcionários cadastrados!!");
              delay();
            }

            else if (lista_empregados.Count > 0) {
              Console.Write("Digite o ID do funcionário que pode ser obtido listando os funcionários >> ");
              funcionario_selecionado = int.Parse(Console.ReadLine());

              if (funcionario_selecionado < 0 || funcionario_selecionado >= lista_empregados.Count) {
                Console.WriteLine("ID de funcionário não cadastrado!!");

                break;
              }

              else {
                lista_empregados[funcionario_selecionado].set_sal(lista_empregados[funcionario_selecionado].aumento_10(lista_empregados[funcionario_selecionado].get_sal_mensal()));

                Console.WriteLine("Aumento concedido!!");
              }
            }
            break;

          case 5:
            sentinela = false;
            break;
        }
      }

      catch (ArgumentException) {
        Console.WriteLine("Campo digitado Inválido!!");
        delay();
      }

      catch (SystemException) {
        Console.WriteLine("Salário negativo é inválido!!");
        delay();
      }
    }
  }

  public static void delay() {
    Console.Write("Precione qualquer tecla para continuar...");
    Console.ReadLine();
    Console.Clear();
  }
}