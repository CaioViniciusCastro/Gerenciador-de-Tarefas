using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerênciador_de_tarefas_OFC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            bool cond = true;

            while (cond == true)
            {
                Console.WriteLine("\n-------------------------");
                Console.WriteLine("--Gerenciador de arquivos--");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1. Adicionar nova tarefa");
                Console.WriteLine("2. Mostrar tarefas");
                Console.WriteLine("3. Concluir tarefa");
                Console.WriteLine("4. Deletar tarefa");
                Console.WriteLine("5. Sair");
                Console.WriteLine("-------------------------");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Digite a nova tarefa:");
                        string novaTarefa = Console.ReadLine();
                        if (taskManager.adicionarNovaTarefa(novaTarefa))
                        {
                            Console.WriteLine("\nInserção completa");
                        }
                        else
                        {
                            Console.WriteLine("\nInserção falhou, favor tente novamente");
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(taskManager.mostrarTarefas());
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Digite o número da tarefa a ser concluída:");
                        int posicaoConcluir = int.Parse(Console.ReadLine()) - 1;
                        if (taskManager.concluirTarefa(posicaoConcluir))
                        {
                            Console.WriteLine("\nConclusão completa");
                        }
                        else
                        {
                            Console.WriteLine("\nConclusão falhou, favor tente novamente");
                        }
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Digite o número da tarefa a ser concluída:");
                        int posicaoDeletar = int.Parse(Console.ReadLine()) - 1;
                        if (taskManager.deletarTarefa(posicaoDeletar))
                        {
                            Console.WriteLine("\nRemoção completa");
                        }
                        else
                        {
                            Console.WriteLine("\nRemoção falhou, favor tente novamente");
                        }
                        break;
                    case "5":
                        Console.Clear();
                        cond = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }

            Console.WriteLine("Obrigado por usar :)");
            Console.ReadKey();
        }
    }
}
