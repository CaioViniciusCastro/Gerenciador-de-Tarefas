namespace Gerenciador_Grau;

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();
        bool cond = true;

        while (cond == true)
        {
            Console.WriteLine("1. Adicionar nova tarefa");
            Console.WriteLine("2. Mostrar tarefas");
            Console.WriteLine("3. Concluir tarefa");
            Console.WriteLine("4. Deletar tarefa");
            Console.WriteLine("5. Sair");
            Console.WriteLine("Escolha uma opção:");

            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Digite a nova tarefa:");
                    string novaTarefa = Console.ReadLine()!;
                    if (taskManager.adicionarNovaTarefa(novaTarefa))
                    {
                        Console.WriteLine("Inserção completa " + init());
                    }
                    else
                    {
                        Console.WriteLine("Inserção falhou, favor tente novamente " + init());
                    }
                    break;
                case "2":
                    Console.WriteLine(taskManager.mostrarTarefas());
                    break;

                case "3":
                    Console.WriteLine("Digite o número da tarefa a ser concluída:");
                    int posicaoConcluir = int.Parse(Console.ReadLine()!) - 1;
                    if (taskManager.concluirTarefa(posicaoConcluir))
                    {
                        Console.WriteLine("Conclusão completa " + init());
                    }
                    else
                    {
                        Console.WriteLine("Conclusão falhou, favor tente novamente " + init());
                    }
                    break;
                case "4":
                    Console.WriteLine("Digite o número da tarefa a ser concluída:");
                    int posicaoDeletar = int.Parse(Console.ReadLine()!) - 1;
                    if (taskManager.deletarTarefa(posicaoDeletar))
                    {
                        Console.WriteLine("Remoção completa " + init());
                    }
                    else
                    {
                        Console.WriteLine("Remoção falhou, favor tente novamente " + init());
                    }
                    break;
                case "5":
                    cond = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        Console.WriteLine("Obrigado por usar :)");
    }

    static string init()
    {
        return "(aperte qualquer tecla para continuar)";
    }
}


