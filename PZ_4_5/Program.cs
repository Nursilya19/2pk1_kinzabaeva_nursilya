namespace PZ_4_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Практика 4
            //задача 1
            Console.WriteLine("Задача 1");
            int i;  //обьявляем переменную
            for (i = -100; i <= 50; i += 5) //условия для for
            {
                Console.WriteLine(i); //выводит числа от -100 до 50 с шагом 5
            }


            //задача 2
            Console.WriteLine("Задача 2");
            int k;  //обьявляем переменную
            char startChar = 'n';
            for (k = 0; k < 6; k++)
            {
                Console.Write(startChar);
                startChar++;  //пишет дополнительную букву 
            }

            //задача 3
            Console.WriteLine("Задача 3");
            int m, n;  //обьявляем переменные
            for (m = 0; m < 4; m++)
            {
                for (n = 0; n < 5; n++)
                {
                    Console.Write("#");

                }
                Console.WriteLine();  //выводим результат
            }

            //задача 4
            Console.WriteLine("Задача 4");
            {
                int count = 0;  //обьявляем переменную и присваиваем значение
                {
                    int a;   //обьявляем переменную
                    for (a = -200; a <= 200; a++)
                    {
                        if (a % 5 == 0)
                        {
                            Console.WriteLine(a + "");
                            count++;
                        }
                    }
                    Console.WriteLine("Количество кратных чисел равно: " + count);   //выводим результат
                }
            }

            //задача 5

            Console.WriteLine("Задача 5");
            int v, t;   //обьявляем переменные
            for (v = 4, t = 50; Math.Abs(v - t) != 22; v++, t--)
            {
                Console.WriteLine("{0} {1}", v, t);  //выводим результат
            }

            //Практика 5

            Console.WriteLine("Введите число N: ");
            int N = int.Parse(Console.ReadLine());
            double doubleFactorial = 1;

            if (N % 2 == 0) //выполняется если N четное
            {
                int s = N;
                do
                {
                    doubleFactorial *= s; //находим факториал
                    s -= 2;
                } while (s >= 2);
            }
            else //выполняется если N нечетное
            {
                int s = N;
                do
                {
                    doubleFactorial *= s;
                    s -= 2;
                } while (s >= 1);
            }

            Console.WriteLine("Двойной факториал числа N: " + doubleFactorial); //выводим результат
        }
    }
}