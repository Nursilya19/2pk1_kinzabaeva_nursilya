namespace PZ_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите данные"); //Вводим данные 
            int a = int.Parse(Console.ReadLine()); //Облявляем переменные, вводим с консоли
            int k = int.Parse(Console.ReadLine());
            double x, y, t; //Объявляем переменные

            if (k > 0) //Начало цикла
            {
                x = Math.Sin(a + (Math.Sqrt(a + k) / 1.5)); //Действие если выполняется условие
            }
            else
                x = Math.Cos(a * k) + 2.5 * a; //Действие если условие не выполняется

            if (x <= 1) //Второй цикл
            {
                y = k + 5 * Math.Cos(Math.Abs(a) * x) + x; //Действие если выполняется условие
            }
            else
                y = (2 * a) * Math.Pow(x, 2) - (3 * k) * x; //Действие если не выполняется условие

            t = 1.3 * Math.Pow(x, 2) + 1.7 * Math.Pow(a, 2) - 3.1 * Math.Pow(y, 2); //Вычисляем результат
            t = Math.Round(t, 2);
            Console.WriteLine("Результат: " + t); //Выводим результат на консоль
        }
    }
}