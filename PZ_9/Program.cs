using System.Diagnostics;

namespace PZ_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите символ: ");
            string inputC = Console.ReadLine();
            char c = char.Parse(inputC); // Преобразование строки в символ

            Console.Write("Введите строку: ");
            string text = Console.ReadLine();

            string result = ""; // создаем пустую строку
            for (int i = 0; i < text.Length; i++)
            {
                result += text[i];
                if (text[i] == c) // если текущий символ равен введенному символу C
                {
                    result += c; // удваиваем символ
                }
            }
            Console.WriteLine("Результат: " + result);
        }
    }
}