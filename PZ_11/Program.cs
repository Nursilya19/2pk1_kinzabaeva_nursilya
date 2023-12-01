using System.Numerics;
using System.Security.Cryptography;

namespace PZ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты вершин четырехугольника"); //вводим координаты вершин
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            int x3 = int.Parse(Console.ReadLine());
            int y3 = int.Parse(Console.ReadLine());
            int x4 = int.Parse(Console.ReadLine());
            int y4 = int.Parse(Console.ReadLine());

            Distance(x1, y1, x2, y2, out double res1); //значение в параметров используемые в методе для всех сторон
            Distance(x2, y2, x3, y3, out double res2);
            Distance(x3, y3, x4, y4, out double res3);
            Distance(x4, y4, x1, y1, out double res4);
            double perimetr;
            perimetr = res1+res2+ res3+res4; 
            Console.WriteLine("Периметр четырехугольника: {0,5:F2} ", perimetr); //выводим результат
        }

        static void Distance(int x1, int y1, int x2, int y2, out double r) //создаем метод Distance
        {
            r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));  //формула для подсчета одной стороны
        }


    }

} 
