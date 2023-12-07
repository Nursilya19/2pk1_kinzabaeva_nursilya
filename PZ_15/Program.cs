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

        static void DisplayDirectoryContents(string folderPath) 
        {
            string[] files = Directory.GetFiles(folderPath); // Получение массива файлов в указанном каталоге
            string[] subDirectories = Directory.GetDirectories(folderPath); // Получение массива подкаталогов в указанном каталоге

            Console.WriteLine($"Каталог: {folderPath}"); 

            Console.WriteLine("Файлы:"); 
            foreach (string file in files) 
            {
                Console.WriteLine(file);
            }

            if (subDirectories.Length > 0) // Проверка наличия подкаталогов
            {
                Console.WriteLine("\nВложенные каталоги:"); 
                foreach (string subDir in subDirectories) 
                {
                    DisplayDirectoryContents(subDir); // Рекурсивный вызов метода для обхода вложенных каталогов
                }
            }
        }
    }
}
