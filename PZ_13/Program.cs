namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1. Введите количество шагов: "); // ввод количества шагов
            int n = int.Parse(Console.ReadLine());
            int a1 = 33; // первичные данные
            int d = -5;
            Console.Write("N\tn\n1\t" + Recursion1(a1, d, 1) + "\n"); // вывод результатов
            for (int i = 2; i <= n; i++)
            {
                Console.WriteLine(i + "\t" + Recursion1(a1, d, i));
            }

            Console.WriteLine("Задача 2. Введите количество шагов: "); // ввод количества шагов
            int n2 = int.Parse(Console.ReadLine());
            double b1 = 11; // первичные данные
            double q = 0.6;
            Console.Write("N\tn\n1\t" + Recursion2(b1, q, 1) + "\n"); // вывод результатов
            for (int i = 2; i <= n2; i++)
            {
                Console.WriteLine(i + "\t" + Recursion2(b1, q, i));
            }

            int A = 22; //данные для 3 задачи
            int B = 100;
            Console.WriteLine("Задача 3");
            Recursion3(A, B);

            Console.WriteLine("\nЗадача 4. Введите число: "); //ввод числа
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Summ(" + k + ") = " + Summ(k));
        }

        private static int Recursion1(int a1, int d, int n) //создаем метод для 1 задачи
        {
            if (n == 1)
                return a1;
            else
                return Recursion1(a1 + d, d, n - 1); //арифметическая прогрессия
        }

        private static double Recursion2(double b1, double q, int n) //создаем метод для 2 задачи
        {
            if (n == 1)
                return b1;
            else
                return Recursion2(b1 * q, q, n - 1); //геометрическая прогрессия
        }

        private static void Recursion3(int a, int b) //создаем метод для 3 задачи
        {
            if (a <= b) //выполняется только в случае если а меньше б
            {
                Console.Write(a + " ");
                Recursion3(a + 1, b); //прибавляет +1 к числу и после чего останавливается у определенного числа 
            }
        }

        static int Summ(int x)
        {
            if (x == 1) //если введено число 1 то мы возвращаем число 1
            {
                return 1;
            }
            else
            {
                return x + Summ(x - 1); // вызываем функцию с аргументом x-1 и прибавляем x
            }
        }
    }
}
