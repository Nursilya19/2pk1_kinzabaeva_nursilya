namespace PZ_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int count = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    Console.WriteLine("Индекс: " + i + ", Число: " + array[i]);
                    count++;
                }
            }

            Console.WriteLine("Количество четных чисел: " + count);
        }
    }
}