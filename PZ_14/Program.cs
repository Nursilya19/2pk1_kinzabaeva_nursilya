using System;
using System.IO;
namespace PZ_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Text.txt");
            int sum = 0;
            int count = 0;
            Console.WriteLine("Оценки меньше 3 баллов у:");
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                string name = parts[0] + " " + parts[1];
                int mark = int.Parse(parts[2]);

                if (mark < 3)
                {
                    Console.WriteLine(name);
                }
                sum += mark;
                count++;
            }
            double average = (double)sum / count;
            Console.WriteLine($"Средний балл по классу: {{0,5:F1}} ", average);
        }
    }
}