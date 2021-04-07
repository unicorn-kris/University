using System;

namespace Medicine_center
{
    class Program
    {
        static int Input()
        {
            int N;
            bool input = int.TryParse(Console.ReadLine(), out N);
            while (!input || N < 0 || N > 10)
            {
                Console.WriteLine("Введите корректное значение");
                input = int.TryParse(Console.ReadLine(), out N);
            }
            return N;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите, что вы хотите сделать: 1 - добавить пациента в базу, 2 - добавить доктора в базу, 3 - добавить кабинет в базу, \n" +
                "4 - создать запись для доктора, 5 - добавить пациента в запись, 6 - удалить пациента из записи, \n" +
                "7 - удалить пациента из базы, 8 - удалить доктора из базы, 9 - удалить кабинет из базы, \n" +
                "10 - вывести расписание");
            int n = Input();
        }
    }
}
