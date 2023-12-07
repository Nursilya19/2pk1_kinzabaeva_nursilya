using System;
using System.IO;
namespace PZ_15
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите полный путь к каталогу:");
            string directory = Console.ReadLine();
            TraverseDirectory(directory); // Вызываем метод для обхода каталога
        }
        static void TraverseDirectory(string directory)
        {
            try
            {
                string[] subDirectories = Directory.GetDirectories(directory); // Получаем список подкаталогов
                Console.WriteLine("Содержимое каталога " + directory + ":"); // Выводим содержимое текущего каталога
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
                foreach (string subDirectory in subDirectories)
                {
                    TraverseDirectory(subDirectory); // Рекурсивно вызываем метод для каждого подкаталога
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при обходе каталога: " + e.Message);
            }
        }
    }
}