using System;
using System.IO;

namespace PZ_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полный путь к каталогу:");
            string folderPath = Console.ReadLine();
            try
            {
                if (Directory.Exists(folderPath)) // Проверка существования указанного каталога
                {
                    Console.WriteLine("Содержимое каталогов:");
                    DisplayDirectoryContents(folderPath); // Вызов метода для отображения содержимого каталога
                }
                else
                {
                    Console.WriteLine("Каталог не существует");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }

        // Метод для отображения содержимого каталога
        static void DisplayDirectoryContents(string folderPath)
        {
            try
            {
                string[] files = Directory.GetFiles(folderPath); // Получение массива файлов в указанном каталоге
                string[] subDirectories = Directory.GetDirectories(folderPath); // Получение массива подкаталогов в указанном каталоге

                Console.WriteLine($"Каталог: {folderPath}"); // Отображение пути к текущему каталогу

                Console.WriteLine("Файлы:");
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }

                if (subDirectories.Length > 0) // Проверка наличия подкаталогов
                {
                    Console.WriteLine("\nВложенные каталоги:"); // Исправленный текст для отображения вложенных каталогов
                    foreach (string subDir in subDirectories)
                    {
                        DisplayDirectoryContents(subDir); // Рекурсивный вызов метода для обхода вложенных каталогов
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при обработке каталога: " + ex.Message);
            }
        }
    }
}
