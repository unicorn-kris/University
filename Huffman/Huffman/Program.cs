using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace haffman
{

    class Program
    {

        static void Main(string[] args)
        {
        //HuffmanTree huffmanTree = new HuffmanTree();
        //Console.WriteLine("Enter string to encode: ");
        //string input = Console.ReadLine();
        //if (input.Length > 1)
        //{

        //    // получаю дерево
        //    huffmanTree.Build(input);

        //    // кодирую последовательность
        //    BitArray encoded = huffmanTree.Encode(input);

        //    using (StreamWriter file = new StreamWriter("C:/Users/Кристина/Desktop/test.txt", false))
        //    {
        //        foreach (bool bit in encoded)
        //        {
        //            file.Write((bit ? 1 : 0) + "");
        //        }
        //    }
        //}
        //Console.WriteLine("Do you want decode file?");

        //string a = Console.ReadLine();
        //// Decode
        //if (a == "yes")
        //{
        //    string decoded = "";
        //    using (StreamReader file = new StreamReader("C:/Users/Кристина/Desktop/test.txt"))
        //    {

        //        decoded = file.ReadToEnd();
        //    }


        //    string decode = huffmanTree.Decode(decoded);

        //    Console.WriteLine("Decoded: " + decode);
        //}
        //Console.ReadLine();
        HuffmanTree huffmanTree = new HuffmanTree();
            //Console.WriteLine("Enter string to encode: ");
            string input = "";
        
            using (StreamReader file1 = new StreamReader("C:/Users/Кристина/Documents/University/Huffman/Huffman/fileIn.txt"))
            {
                input = file1.ReadToEnd();
            }
            if (input.Length > 1)
            {
                // получаю дерево
                huffmanTree.Build(input);

                // кодирую последовательность
                BitArray encoded = huffmanTree.Encode(input);

                using (BinaryWriter writer = new BinaryWriter(File.Open("C:/Users/Кристина/Desktop/test.bin", FileMode.Create)))
                {

                    byte[] bytes = new byte[encoded.Length / 8 + (encoded.Length % 8 == 0 ? 0 : 1)];
                    encoded.CopyTo(bytes, 0);
                    writer.Write(bytes);
                }
            }
            Console.WriteLine("Do you want decode file?");

            string a = Console.ReadLine();

            // Decode
            if (a == "yes")
            {
                BitArray array;
                int i;
                using (BinaryReader reader = new BinaryReader(File.Open("C:/Users/Кристина/Desktop/test.bin", FileMode.Open)))
                {

                    byte[] bytes = new byte[(int)(reader.BaseStream.Length)];
                    int k = 0;
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        bytes[k] = reader.ReadByte();
                        k++;
                    }
                    array = new BitArray(bytes);
                }
                string decode = huffmanTree.Decode(array);

                using (StreamWriter file1 = new StreamWriter("C:/Users/Кристина/Desktop/test1.txt", false))
                {
                    file1.WriteLine("Decoded: " + decode);
                }
                Console.WriteLine("Decoded: " + decode);
                Console.ReadLine();
            }
        }
    }
}