namespace PZ_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Решение линейной задачи");

            double a = 1; // Вводим данные
            double b = Math.PI / 4;
            double c = 1;

            double part1 = Math.Pow(Math.Abs(a * Math.Pow(c, 2) - Math.Pow(b, 3)), 1 / 5) + Math.Log(3 * c); // Разделим выражение на 3 части
            double part2 = ((Math.Pow(Math.E, 3 * c)) + Math.Pow(c, 2)) / (Math.Sin(2 * c));
            double part3 = Math.Pow(10, -3) * Math.Sqrt(2157 * a);

            double result = part1 - part2 - part3; // Подсчитываем результат

            Console.WriteLine("Ответ: " + result); // Выводим результат
        }
    }
}