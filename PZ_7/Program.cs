namespace PZ_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] A = new double[8, 6];   // Создание матрицы и заполнение ее случайными вещественными числами
            Random random = new Random();

            // Заполнение и вывод матрицы
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    A[i, j] = random.Next(1, 101); // Генерация числа от 1 до 100
                    Console.Write(A[i, j] + "\t");
                }
                Console.WriteLine();
            }

            double min = double.MaxValue; // Поиск минимального элемента и суммы положительных элементов
            double sum = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    double element = A[i, j];
                    if (element < min)
                    {
                        min = element; // Обновление минимального элемента, если текущий элемент меньше
                    }
                    if (element > 0)
                    {
                        sum += element; // Добавление положительного элемента к сумме
                    }
                }
            }

            double result = min * sum; // Вычисление произведения минимального элемента на сумму положительных элементов

            Console.WriteLine("Минимальный элемент: " + min);
            Console.WriteLine("Сумма положительных элементов: " + sum);
            Console.WriteLine("Произведение минимального элемента на сумму положительных элементов: " + result);
        }   
    }
}