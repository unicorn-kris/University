using System;
using System.IO;

namespace Graphs
{
    class Program
    {
        static int Input(int N)
        {
            int n;
            bool input = int.TryParse(Console.ReadLine(), out n);
            while (!input || n >= N || n < 0)
            {
                Console.WriteLine("Введите корректное значение");
                input = int.TryParse(Console.ReadLine(), out n);
            }
            return n;
        }
        static void Main(string[] args)
        {
            Graph g = new Graph("C:/Users/Кристина/source/repos/Graphs/graph2/TextFile1.txt");
            Console.WriteLine("Graph:");
            g.Show();
            int N = g.Size;
            Console.WriteLine($"Введите номер вершины, чтобы узнать не достижимые из нее (от 0 до {g.Size - 1})");
            int v = Input(N);
            g.Reachable(v);
        }
    }
}
