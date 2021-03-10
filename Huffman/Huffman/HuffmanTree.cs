using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace haffman
{

    public class Node
    {
        public char Symbol { get; set; } //символ
        public int Frequency { get; set; } //частота
        public Node Right { get; set; } //ссылка направо
        public Node Left { get; set; } //ссылка налево

        public List<bool> Traverse(char symbol, List<bool> data)
        {
            // Leaf
            if (Right == null && Left == null)
            {
                if (symbol == (this.Symbol)) //если просматриваемый - лист
                {
                    return data; //вернуть закодированную последовательность
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> left = null; //для поддеревьев создаются списки
                List<bool> right = null;

                if (Left != null)
                {
                    List<bool> leftPath = new List<bool>(); //если слева не пусто, то создается список для левого поддерева
                    leftPath.AddRange(data); //элементы сверху добавляются в его персональную последовательность
                    leftPath.Add(false); //т.к. слева заполняется нулями, добалвяем нуль

                    left = Left.Traverse(symbol, leftPath); //перемещение дальше по левому поддереву
                }

                if (Right != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);
                    right = Right.Traverse(symbol, rightPath);
                }

                if (left != null)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }
    }
    public class HuffmanTree

    {
        private List<Node> nodes = new List<Node>(); //список последовательностей
        public Node Root { get; set; }
        public Dictionary<char, int> alphabet = new Dictionary<char, int>(); //символ - код


        public void Build(string source) //построение дерева
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (!alphabet.ContainsKey(source[i])) //если в словаре слова нет
                {
                    alphabet.Add(source[i], 0); //его код 0
                }

                alphabet[source[i]]++;
            }

            foreach (KeyValuePair<char, int> symbol in alphabet) //просматриваю пары ключ-значение
            {

                nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value }); //заношу ключи в список
            }


            while (nodes.Count > 1)
            {
                List<Node> order = nodes.OrderBy(node => node.Frequency).ToList<Node>(); //если символов больше 1 то сортирую по возрастанию частоты

                if (order.Count == 2 || order[0].Symbol != '*') //если больше 2 и дерево еще не было тронуто, то строю дерево
                {
                    // беру первые 2 
                    List<Node> taken = order.Take(2).ToList<Node>();

                    // формирую из них узел
                    Node parent = new Node() //его символ звездочка, частота - сумма частот, слева и справа выбранные элементы
                    {
                        Symbol = '*',
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        Left = taken[0],
                        Right = taken[1]
                    };
                    //элементы удаляются и прибавляется новый узел
                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }
                else if (order.Count > 2 && order[0].Symbol == '*') //если больше 2 и дерево было тронуто, то строю дерево
                {
                    List<Node> taken = order.Take(3).ToList<Node>();

                    // формирую узел смотря на частоту и алфавитный порядок
                    if (order[0].Frequency != order[1].Frequency)
                    {
                        Node parent = new Node() //его символ звездочка, частота - сумма частот, слева и справа выбранные элементы
                        {
                            Symbol = '*',
                            Frequency = taken[0].Frequency + taken[1].Frequency,
                            Left = taken[0],
                            Right = taken[1]
                        };
                        //элементы удаляются и прибавляется новый узел
                        nodes.Remove(taken[0]);
                        nodes.Remove(taken[1]);
                        nodes.Add(parent);
                    }
                    else if (order[0].Frequency == order[1].Frequency) //если частоты равны
                    {
                        Node parent = new Node() //его символ звездочка, частота - сумма частот, слева и справа выбранные элементы
                        {
                            Symbol = '*',
                            Frequency = taken[1].Frequency + taken[2].Frequency,
                            Left = taken[1],
                            Right = taken[2]

                        };
                        nodes.Remove(taken[1]);
                        nodes.Remove(taken[2]);
                        nodes.Add(parent);
                        if (parent.Frequency < taken[0].Frequency)
                        {
                            Node parent1 = new Node() //его символ звездочка, частота - сумма частот, слева и справа выбранные элементы
                            {
                                Symbol = '*',
                                Frequency = parent.Frequency + taken[0].Frequency,
                                Left = taken[0],
                                Right = parent,
                            };

                            nodes.Remove(taken[0]);
                            nodes.Add(parent1);
                        }
                        else
                        {
                            Node parent1 = new Node() //его символ звездочка, частота - сумма частот, слева и справа выбранные элементы
                            {
                                Symbol = '*',
                                Frequency = parent.Frequency + taken[0].Frequency,
                                Left = taken[0],
                                Right = parent,
                            };

                            nodes.Remove(taken[0]);
                            nodes.Add(parent1);
                        }

                    }
                }

                Root = nodes.FirstOrDefault(); //корень - первый элемент списка 

            }

        }

        public BitArray Encode(string source) //кодирование строки и информации для раскодировки
        {
            List<bool> encodedSource = new List<bool>();

            string symbols = "";  //строка из разных символов введенной строки
            for (int i = 0; i < source.Length; ++i)
            {
                char a = source[i];
                if (symbols.IndexOf(a) < 0)
                    symbols += a;
            }

            List<bool>[] inform = new List<bool>[symbols.Length]; //для кодов символов
            for (int i = 0; i < symbols.Length; ++i)
            {
                List<bool> encodedSymbol = this.Root.Traverse(symbols[i], new List<bool>());
                inform[i] = encodedSymbol;
            }

            List<string> s = new List<string>();

            for (int i = 0; i < symbols.Length; ++i)
            {
                s.Add(Convert.ToString((int)symbols[i], 2));
            }

            string lenght = Convert.ToString((int)symbols.Length, 2); //число символов
            List<bool> Bit = new List<bool>(); //служебная инофрмация
            if (lenght.Length < 8) //код кол-ва символов "алфавита"
            {
                for (int i = 0; i < 8 - lenght.Length; ++i)
                {
                    Bit.Add(false);
                }
            }
            for (int i = 0; i < lenght.Length; ++i)
            {
                if (lenght[i] == '0')
                {
                    Bit.Add(false);
                }
                else
                {
                    Bit.Add(true);
                }
            }

            for (int i = 0; i < symbols.Length; ++i) //для каждого сивола
            {
                if (s[i].Length < 8) //номер символа в аски в двоичном виде
                    for (int j = 0; j < 8 - s[i].Length; ++j)
                        Bit.Add(false);
                for (int j = 0; j < s[i].Length; ++j)
                {
                    if (s[i][j] == '0')
                        Bit.Add(false);
                    else
                        Bit.Add(true);
                }
                int bb = inform[i].Count; //кол-во бит для кода символа в двоичном виде

                string lenghtbb = Convert.ToString(bb, 2);
                if (lenghtbb.Length < 8)
                    for (int j = 0; j < 8 - lenghtbb.Length; ++j)
                        Bit.Add(false);
                for (int j = 0; j < lenghtbb.Length; ++j)
                {
                    if (lenghtbb[j] == '0')
                        Bit.Add(false);
                    else
                        Bit.Add(true);
                }

                foreach (bool b in inform[i]) //код символа из дерева в двоичном виде
                    Bit.Add(b);
            }

            for (int i = 0; i < source.Length; i++) //код строки
            {
                List<bool> encodedSymbol = this.Root.Traverse(source[i], new List<bool>());
                foreach (bool b in encodedSymbol)
                    Bit.Add(b);
            }

            BitArray bits = new BitArray(Bit.ToArray());
            return bits;
        }

        public string Decode(BitArray bitt)
        {
            string num = "";
            string bit = "";
            foreach (bool bits in bitt)
            {
                bit += ((bits ? 1 : 0) + "");
            }

            for (int i = 0; i < 8; ++i)//кол-во символов алфавита
            {
                num += bit[i];
            }
            int N = 8;
            int numm = 0;
            int k = 1;
            for (int i = num.Length - 1; i >= 0; --i)
            {
                if (num[i] == '1')
                    numm += k;
                k *= 2;
            }
            Dictionary<char, string> alphabet1 = new Dictionary<char, string>(); //символ - код
            for (int i = 0; i < numm; ++i)
            {
                char a;
                int a1 = 0;
                string bitss = "";
                int kk = 1;
                for (int j = N + 7; j >= N; --j) //код символа
                {
                    if (bit[j] == '1')
                        a1 += kk;
                    kk *= 2;
                }
                kk = 1;
                N = N + 8;
                a = (char)a1;
                a1 = 0;
                for (int j = N + 7; j >= N; --j) //кол-во бит для кода символа
                {
                    if (bit[j] == '1')
                        a1 += kk;
                    kk *= 2;
                }
                N = N + 8;
                kk = 1;
                for (int j = N; j < N + a1; ++j) //код символа
                {
                    bitss += bit[j];
                }
                N = N + a1;
                alphabet1.Add(a, bitss);
            }

            foreach (KeyValuePair<char, string> symbol in alphabet1)
            {
                Console.WriteLine($"{symbol.Key} - {symbol.Value}");
            }

            string result = "";
            string numsym = "";
            for (int i = N; i < bit.Length; ++i)
            {
                numsym += bit[i];
                foreach (KeyValuePair<char, string> symbol in alphabet1)
                {
                    int n1 = numsym.Length;
                    int n2 = symbol.Value.Length;
                    int n = 0;
                    if (n1 == n2)
                    {
                        for (int j = 0; j < n1; ++j)
                            if (numsym[j] == symbol.Value[j])
                                ++n;
                        if (n == n1)
                        {
                            result += symbol.Key;
                            numsym = "";
                        }
                    }
                }
            }

            return result;
        }

        public bool IsLeaf(Node node)
        {
            return (node.Left == null && node.Right == null);
        }

    }
}
