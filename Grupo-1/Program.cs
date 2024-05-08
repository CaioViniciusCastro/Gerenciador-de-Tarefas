using System;
using System.Collections.Generic;

public class TaskManager
{
    private List<TaskItem> minhaListaDeItens = new List<TaskItem>();

    public void AdicionarNovaTarefa(string tarefa)
    {
        minhaListaDeItens.Add(new TaskItem(tarefa));
        MostrarTarefas();
    }

    public void MostrarTarefas()
    {
        Console.Clear();
        if (minhaListaDeItens.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa cadastrada.");
        }
        else
        {
            for (int i = 0; i < minhaListaDeItens.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {minhaListaDeItens[i]}");
            }
        }
    }

    public void ConcluirTarefa(int posicao)
    {
        if (posicao >= 0 && posicao < minhaListaDeItens.Count)
        {
            minhaListaDeItens[posicao].Concluida = true;
            MostrarTarefas();
        }
        else
        {
            Console.WriteLine("Posição inválida.");
        }
    }

    public void DeletarItem(int posicao)
    {
        if (posicao >= 0 && posicao < minhaListaDeItens.Count)
        {
            minhaListaDeItens.RemoveAt(posicao);
            MostrarTarefas();
        }
        else
        {
            Console.WriteLine("Posição inválida.");
        }
    }

    public void RecarregarTarefas()
    {
        // Lógica para recarregar tarefas do armazenamento local (não implementado)
    }
}

public class TaskItem
{
    public string Tarefa { get; }
    public bool Concluida { get; set; }

    public TaskItem(string tarefa)
    {
        Tarefa = tarefa;
        Concluida = false;
    }

    public override string ToString()
    {
        return $"{Tarefa} {(Concluida ? "[Concluída]" : "[Pendente]")}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.WriteLine("1. Adicionar nova tarefa");
            Console.WriteLine("2. Mostrar tarefas");
            Console.WriteLine("3. Concluir tarefa");
            Console.WriteLine("4. Deletar item");
            Console.WriteLine("5. Sair");
            Console.WriteLine("Escolha uma opção:");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Digite a nova tarefa:");
                    string novaTarefa = Console.ReadLine();
                    taskManager.AdicionarNovaTarefa(novaTarefa);
                    break;
                case "2":
                    taskManager.MostrarTarefas();
                    break;
                case "3":
                    Console.WriteLine("Digite o número da tarefa a ser concluída:");
                    int posicaoConcluir = int.Parse(Console.ReadLine()) - 1;
                    taskManager.ConcluirTarefa(posicaoConcluir);
                    break;
                case "4":
                    Console.WriteLine("Digite o número da tarefa a ser deletada:");
                    int posicaoDeletar = int.Parse(Console.ReadLine()) - 1;
                    taskManager.DeletarItem(posicaoDeletar);
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
