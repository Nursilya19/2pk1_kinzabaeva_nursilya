namespace Methods
{
    internal class Program
    {
        static double GetArea(double radius, double len)
        {
            return 3.14 * radius * (len + radius);
        }

        private static void ArrayGeneration(int n)
        {
            int[,] array = new int[n, n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = random.Next(1, 100);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void P(int a, ref int b)
        {
            a = 44; b = 33;
            Console.WriteLine($" внутри метода {a} {b}");
        }
        static void K(int v, out int w)
        {
            v = 44; w = 33;
            Console.WriteLine($" внутри метода {v} {w}");
        }


        static void Main(string[] args)
        {
            double r, l;
            double s;
            Console.WriteLine("Задача 1. Введите данные для вычисления площади поверхности конуса");
            Console.Write("Введите значение радиуса основания в см: ");
            r = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение боковой стороны в см: ");
            l = Convert.ToDouble(Console.ReadLine());
            s = GetArea(r, l);
            Console.WriteLine("Площадь поверхности конуса: " + s);

            int size;
            Console.Write("Задача 2. Введите размер массива: ");
            size = int.Parse(Console.ReadLine());
            ArrayGeneration(size);

            int a = 2, b = 4;
            Console.WriteLine($"Задача 3. до вызова {a} {b}");
            P(a, ref b);
            Console.WriteLine($" после вызова {a} {b}");

            int v = 2, w;
            K(v, out w);
            Console.WriteLine($"Задача 4. после вызова {v} {w}");

        }

    }
}