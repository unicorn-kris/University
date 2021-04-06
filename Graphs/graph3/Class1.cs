using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Graphs
{
    public class Graph
    {
        private class Node //вложенный класс для скрытия данных и алгоритмов
        {
            private int[,] array; //матрица смежности
            public int this[int i, int j] //индексатор для обращения к матрице смежности
            {
                get
                {
                    return array[i, j];
                }
                set
                {
                    array[i, j] = value;
                }
            }
            public int Size //свойство для получения размерности матрицы смежности
            {
                get
                {
                    return array.GetLength(0);
                }

            }
            private bool[] nov; //вспомогательный массив: если i-ый элемент массива равен
                                //true, то i-ая вершина еще не просмотрена; если i-ый
                                //элемент равен false, то i-ая вершина просмотрена
            public void NovSet() //метод помечает все вершины графа как непросмотреные
            {
                for (int i = 0; i < Size; i++)
                {
                    nov[i] = true;
                }
            }
            public bool NovGet(int i)
            {
                return nov[i];
            }

            //конструктор вложенного класса, инициализирует матрицу смежности и
            // вспомогательный массив
            public Node(int[,] a)
            {
                array = a;
                nov = new bool[a.GetLength(0)];
            }
            //реализация алгоритма обхода графа в глубину

            public void Dfs(int v)
            {
                Console.Write("{0} ", v); //просматриваем текущую вершину
                nov[v] = false; //помечаем ее как просмотренную
                                // в матрице смежности просматриваем строку с номером v
                for (int u = 0; u < Size; u++)
                {
                    //если вершины v и u смежные, к тому же вершина u не просмотрена,
                    if (array[v, u] != 0 && nov[u])
                    {
                        Dfs(u); // то рекурсивно просматриваем вершину
                    }
                }
            }
            //реализация алгоритма обхода графа в ширину
            public void Bfs(int v)
            {
                Queue q = new Queue(); // инициализируем очередь
                q.Enqueue(v); //помещаем вершину v в очередь
                nov[v] = false; // помечаем вершину v как просмотренную
                while (q.Count != 0) // пока очередь не пуста
                {
                    v = (int)q.Dequeue(); //извлекаем вершину из очереди

                    Console.Write("{0} ", v); //просматриваем ее
                    for (int u = 0; u < Size; u++) //находим все вершины
                    {
                        if (array[v, u] != 0 && nov[u]) // смежные с данной и еще не просмотренные
                        {
                            q.Enqueue(u); //помещаем их в очередь
                            nov[u] = false; //и помечаем как просмотренные
                        }
                    }
                }
            }
            //реализация алгоритма Дейкстры
            public long[] Dijkstr(int v, out int[] p)
            {
                nov[v] = false; // помечаем вершину v как просмотренную
                                //создаем матрицу с
                int[,] c = new int[Size, Size];
                for (int i = 0; i < Size; i++)
                {
                    for (int u = 0; u < Size; u++)
                    {
                        if (array[i, u] == 0 || i == u)
                        {
                            c[i, u] = int.MaxValue;
                        }
                        else
                        {
                            c[i, u] = array[i, u];
                        }

                    }
                }
                //создаем матрицы d и p
                long[] d = new long[Size];
                p = new int[Size];
                for (int u = 0; u < Size; u++)
                {
                    if (u != v)
                    {
                        d[u] = c[v, u];
                        p[u] = v;
                    }
                }
                for (int i = 0; i < Size - 1; i++) // на каждом шаге цикла
                {
                    // выбираем из множества V\S такую вершину w, что D[w] минимально
                    long min = int.MaxValue;
                    int w = 0;
                    for (int u = 0; u < Size; u++)
                    {
                        if (nov[u] && min > d[u])
                        {
                            min = d[u];
                            w = u;
                        }
                    }
                    nov[w] = false; //помещаем w в множество S
                                    //для каждой вершины из множества V\S определяем кратчайший путь от
                                    // источника до этой вершины
                    for (int u = 0; u < Size; u++)
                    {
                        long distance = d[w] + c[w, u];
                        if (nov[u] && d[u] > distance)
                        {
                            d[u] = distance;
                            p[u] = w;
                        }
                    }
                }
                return d; //в качестве результата возвращаем массив кратчайших путей для
            } //заданного источника
              //восстановление пути от вершины a до вершины b для алгоритма Дейкстры
            public void WayDijkstr(int a, int b, int[] p, ref Stack items)
            {
                items.Push(b); //помещаем вершину b в стек
                if (a == p[b]) //если предыдущей для вершины b является вершина а, то
                {
                    items.Push(a); //помещаем а в стек и завершаем восстановление пути
                }
                else //иначе метод рекурсивно вызывает сам себя для поиска пути
                { //от вершины а до вершины, предшествующей вершине b
                    WayDijkstr(a, p[b], p, ref items);

                }
            }

            //реализация алгоритма Флойда
            public long[,] Floyd(out int[,] p)
            {
                int i, j, k;
                //создаем массивы р и а
                long[,] a = new long[Size, Size];
                p = new int[Size, Size];
                for (i = 0; i < Size; i++)
                {
                    for (j = 0; j < Size; j++)
                    {
                        if (i == j)
                        {
                            a[i, j] = 0;
                        }
                        else
                        {
                            if (array[i, j] == 0)
                            {
                                a[i, j] = int.MaxValue;
                            }
                            else
                            {
                                a[i, j] = array[i, j];
                            }
                        }
                        p[i, j] = -1;
                    }
                }
                //осуществляем поиск кратчайших путей
                for (k = 0; k < Size; k++)
                {
                    for (i = 0; i < Size; i++)
                    {
                        for (j = 0; j < Size; j++)
                        {
                            long distance = a[i, k] + a[k, j];
                            if (a[i, j] > distance)
                            {
                                a[i, j] = distance;
                                p[i, j] = k;
                            }
                        }
                    }
                }
                return a;//в качестве результата возвращаем массив кратчайших путей между
            } //всеми парами вершин
              //восстановление пути от вершины a до вершины в для алгоритма Флойда
            public void WayFloyd(int a, int b, int[,] p, ref Queue items)

            {
                int k = p[a, b];
                //если k<> -1, то путь состоит более чем из двух вершин а и b, и проходит через
                //вершину k, поэтому
                if (k != -1)
                {
                    // рекурсивно восстанавливаем путь между вершинами а и k
                    WayFloyd(a, k, p, ref items);
                    items.Enqueue(k); //помещаем вершину к в очередь
                                      // рекурсивно восстанавливаем путь между вершинами k и b
                    WayFloyd(k, b, p, ref items);
                }
            }
            public void Delete(int v)
            {
                int[,] arraynew = new int[Size - 1, Size - 1];
                int i1 = 0;
                int j1 = 0;
                for (int i = 0; i < Size; ++i)
                {
                    if (i != v)
                    {
                        j1 = 0;
                        for (int j = 0; j < Size; ++j)
                        {
                            if (j != v)
                            {
                                arraynew[i1, j1] = array[i, j];
                                ++j1;
                            }
                        }
                        ++i1;
                    }
                }
                array = arraynew;
            }
            public void Reach(int v)
            {
                nov[v] = false;
                for (int u = 0; u < Size; u++)
                {
                    if (array[v, u] != 0 && nov[u])
                    {
                        Reach(u);
                    }
                }
            }

        } //конец вложенного клаcса
        private Node graph; //закрытое поле, реализующее АТД «граф»
        public string[] names;
        public Graph(string name) //конструктор внешнего класса
        {
            using (StreamReader file = new StreamReader(name))
            {
                int n = int.Parse(file.ReadLine());
                int[,] a = new int[n, n];
                string linename = file.ReadLine();
                names = linename.Split(' ');
                for (int i = 0; i < n; i++)
                {
                    string line = file.ReadLine();
                    string[] mas = line.Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = int.Parse(mas[j]);
                    }
                }
                graph = new Node(a);
            }
        }
        public void Delete(int v)
        {
            graph.Delete(v);

        }
        public void Reachable(int v)
        {
            graph.NovSet();
            Console.Write("Вершины не достижимые из {0} вершины: ", v);
            graph.Reach(v);
            for (int i = 0; i < graph.Size; i++)
            {
                if (graph.NovGet(i) && i != v) //если вершина была просмотрена, то она достижима
                {
                    Console.Write("{0} ", i);
                }
            }
            Console.WriteLine();
        }

        //метод выводит матрицу смежности на консольное окно
        public void Show()
        {
            foreach (string name in names)
            {
                Console.Write($"{name} ");
            }
            Console.WriteLine();
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    Console.Write("{0,4}", graph[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void Dfs(int v)
        {
            graph.NovSet();//помечаем все вершины графа как непросмотренные
            graph.Dfs(v); //запускаем алгоритм обхода графа в глубину
            Console.WriteLine();
        }
        public void Bfs(int v)
        {
            graph.NovSet();//помечаем все вершины графа как непросмотренные
            graph.Bfs(v); //запускаем алгоритм обхода графа в ширину
            Console.WriteLine();
        }
        public void Dijkstr(int v)
        {
            graph.NovSet();//помечаем все вершины графа как непросмотренные
            int[] p;
            long[] d = graph.Dijkstr(v, out p); //запускаем алгоритм Дейкстры
                                                //анализируем полученные данные и выводим их на экран
            Console.WriteLine("Длина кратчайшие пути от вершины {0} до вершины", v);
            for (int i = 0; i < graph.Size; i++)
            {
                if (i != v)
                {
                    Console.Write("{0} равна {1}, ", i, d[i]);
                    Console.Write("путь ");
                    if (d[i] != int.MaxValue)
                    {
                        Stack items = new Stack();
                        graph.WayDijkstr(v, i, p, ref items);
                        while (items.Count != 0)
                        {
                            Console.Write("{0} ", items.Pop());
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        public void Floyd(int max)
        {
            int[,] p;
            bool closeWay = true;
            long[,] a = graph.Floyd(out p); //запускаем алгоритм Флойда
            int i, j;
            int countWay = 0;
            int count = 0;
            //анализируем полученные данные и выводим их на экран
            for (i = 0; i < graph.Size; i++)
            {
                for (j = 0; j < graph.Size; j++)
                {
                    if (i != j)
                    {
                        if (a[i, j] != int.MaxValue && a[i,j] > 0)
                        {
                            ++countWay;
                            if (a[i, j] > max)
                                ++count;
                            
                        }
                    }
                }
            }
            if (countWay == count)
            {
                Console.WriteLine($"Кратчайшие пути больше {max}, поэтому дорогу нельзя перекрыть");
            }

            else
            {
                countWay = 0;
                count = 0;
                int countRealWays = 0;
                Node graph1;
                int wayi = -1;
                int wayj = -1;
                closeWay = false;

                for (i = 0; i < Size; ++i)
                {
                    {
                        for (j = 0; j < Size; ++j)
                        {

                            if (graph[i, j] != 0)
                            {
                                if (wayi < 0 && wayj < 0)
                                {
                                    wayi = i;
                                    wayj = j;
                                }

                                ++countRealWays;
                            }

                        }
                    }
                }

                int C = -1;
                while (!closeWay && C<Size*Size)
                {
                    ++C;
                    countWay = 0;
                    count = 0;
                    int[,] arraynew = new int[Size, Size];
                    bool change = false;
                    bool change1 = false;
                    int wi = -1;
                    int wj = -1;
                    for (i = 0; i < Size; ++i)
                    {

                        for (j = 0; j < Size; ++j)
                        {
                            if (graph[i, j] != 0 && wayi == i && wayj == j)
                            {
                                arraynew[i, j] = 0;
                                wi = i;
                                wj = j;
                                change = true;
                                
                            }
                            else
                                arraynew[i, j] = graph[i, j];

                        }

                    }
                    arraynew[wj, wi] = 0;
                    graph1 = new Node(arraynew);

                    a = graph1.Floyd(out p); //запускаем алгоритм Флойда
                    for (i = 0; i < graph1.Size; i++)
                    {
                        for (j = 0; j < graph1.Size; j++)
                        {
                            if (i != j)
                            {
                                if (a[i, j] != int.MaxValue && a[i, j] > 0)
                                {
                                    ++countWay;
                                    if (a[i, j] <= max)
                                        ++count;
                                }
                            }
                        }
                    }
                    
                    if (countWay == count)
                    {
                        closeWay = true;

                        foreach (string name in names)
                        {
                            Console.Write($"{name} ");
                        }
                        Console.WriteLine();
                        for (int ii = 0; ii < graph1.Size; ii++)
                        {
                            for (int jj = 0; jj < graph1.Size; jj++)
                            {
                                if (ii != jj)
                                {
                                    if (a[ii, jj] == int.MaxValue)
                                    {
                                        Console.WriteLine($"Пути из вершины {ii} в вершину {jj} не существует");
                                    }
                                    else
                                    {
                                        Console.Write($"Кратчайший путь от вершины {ii} до вершины {jj} равен {a[ii, jj]} ");
                                        Console.WriteLine();
                                    }
                                }
                            }
                        }

                        for (int ii = 0; ii < graph1.Size; ii++)
                        {
                            for (int jj = 0; jj < graph1.Size; jj++)
                            {

                                Console.Write($"{arraynew[ii, jj]} ");

                            }
                            Console.WriteLine();
                        }
                    }

                    else if (countWay != count)
                    {
                        for (i = 0; i < Size; ++i)
                        {

                            for (j = 0; j < Size; ++j)
                            {
                                 if (arraynew[i, j] != 0 && !change1)
                                {
                                    wayi = i;
                                    wayj = j;
                                    
                                    change1 = true;
                                }

                            }

                        }
                    }
                }

                if (closeWay == true)
                    Console.WriteLine($" Можно закрыть дорогу {names[wayi]} - {names[wayj]}");

                else
                    Console.WriteLine("Нельзя перекрыть ни одну дорогу");
            }

        }
        public int Size
        {
            get { return graph.Size; }
        }
        public void FloydCloseWay()
        {

        }
    }
}
