namespace PZ_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int N = int.Parse(Console.ReadLine());
            int[] n = new int[N];
            Console.WriteLine("Введите элемент массива: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write($"Элемент {i + 1}: " );
                n[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Четные числа в порядке убывания:");
            int count = 0;

            for (int i = N - 1; i >= 0; i--) // Проходим по массиву в обратном порядке, начиная с последнего элемента
            {
                if (n[i] % 2 == 0)   // Проверяем, является ли текущий элемент четным
                {
                    Console.WriteLine("Число: " + n[i]);  // Выводим значение четного числа
                    count++; // Увеличиваем счетчик четных чисел
                }
            }
            Console.WriteLine("Количество четных чисел: " + count);   // Выводим количество найденных четных чисел
        }
    }
}