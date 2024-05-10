using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerênciador_de_tarefas_OFC
{
    public class TaskManager
    {
        private string _path;
        public TaskManager()
        {
            _path = @"D:\task.txt";
            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }
        public bool adicionarNovaTarefa(string tarefa)
        {
            if (File.Exists(_path))
            {
                File.AppendAllText(_path, tarefa + "\n");
                return true;
            }
            return false;
        }

        public string mostrarTarefas()
        {
            if (File.Exists(_path))
            {
                using (StreamReader sr = File.OpenText(_path))
                {
                    StringBuilder sb = new StringBuilder();
                    string s;
                    int count = 0;

                    if (lerArquivo() != null)
                    {
                        while ((s = sr.ReadLine()) != null)
                        {
                            count++;
                            sb.AppendLine("ID " + count + ": " + s);
                        }
                    }
                    return sb.ToString();
                }
            }
            return "Nenhuma tarefa foi cadastrada";
        }

        public bool concluirTarefa(int posicao)
        {
            if (File.Exists(_path))
            {
                if (posicao >= 0 && posicao <= lenghtFile())
                {
                    StringBuilder sb = new StringBuilder();
                    string s = "";

                    using (StreamReader sr = File.OpenText(_path))
                    {
                        for (int i = 1; i < posicao; i++)
                        {
                            s = sr.ReadLine();
                            sb.AppendLine(s);
                        }
                        s = sr.ReadLine();
                        sb.AppendLine(s + " | Concluída");
                        for (int i = posicao + 1; i <= lenghtFile(); i++)
                        {
                            s = sr.ReadLine();
                            sb.AppendLine(s);
                        }
                    }
                    File.WriteAllText(_path, sb.ToString());

                    return true;
                }
            }
            return false;
        }

        public bool deletarTarefa(int posicao)
        {
            if (File.Exists(_path))
            {
                if (posicao >= 0 && posicao <= lenghtFile())
                {
                    StringBuilder sb = new StringBuilder();
                    string s = "";

                    using (StreamReader sr = File.OpenText(_path))
                    {
                        for (int i = 1; i < posicao; i++)
                        {
                            s = sr.ReadLine();
                            sb.AppendLine(s);
                        }
                        sr.ReadLine();
                        for (int i = posicao + 1; i <= lenghtFile(); i++)
                        {
                            s = sr.ReadLine();
                            sb.AppendLine(s);
                        }
                    }
                    File.WriteAllText(_path, sb.ToString());

                    return true;
                }
            }
            return false;
        }

        private int lenghtFile()
        {
            if (File.Exists(_path))
            {
                using (StreamReader sr = File.OpenText(_path))
                {
                    int count = 0;
                    while (sr.ReadLine() != null)
                    {
                        count++;
                    }

                    return count - 1;
                }
            }
            return -1;
        }

        private string lerArquivo()
        {
            return File.ReadAllText(_path);
        }
    }
}


