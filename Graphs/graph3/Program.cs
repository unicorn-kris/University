using System;
using System.IO;

namespace Graphs
{
    class Program
    {
        static int Input()
        {
            int n;
            bool input = int.TryParse(Console.ReadLine(), out n);
            while (!input || n < 0)
            {
                Console.WriteLine("Введите корректное значение");
                input = int.TryParse(Console.ReadLine(), out n);
            }
            return n;
        }
        static void Main(string[] args)
        {
            Graph g = new Graph("C:/Users/Кристина/source/repos/Graphs/graph3/TextFile1.txt");
            Console.WriteLine("Graph:");
            g.Show();
            Console.WriteLine("Введите максимальное значение длины пути");
            int n = g.Size;
            int max = Input();
            g.Floyd(max);
        }
    }
}
