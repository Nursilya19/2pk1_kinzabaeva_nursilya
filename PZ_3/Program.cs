namespace PZ_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сумму покупки");
            double sum = double.Parse(Console.ReadLine()); // Ввод и преобразование суммы покупки в тип double
            Console.WriteLine("Введите день недели");
            string day = Console.ReadLine(); // Ввод дня недели

            double discount = 0; // Переменная для хранения значения скидки

            switch (day)
            {
                case "понедельник":
                    discount = 0.05; // Если день недели - понедельник, устанавливаем скидку 5%
                    break;

                case "вторник":
                    discount = 0.05; // Если день недели - вторник, устанавливаем скидку 5%
                    break;

                case "среда":
                    discount = 0.05; // Если день недели - среда, устанавливаем скидку 5%
                    break;

                case "четверг":
                    discount = 0.05; // Если день недели - четверг, устанавливаем скидку 5%
                    break;

                case "пятница":
                    discount = 0.05; // Если день недели - пятница, устанавливаем скидку 5%
                    break;

                case "суббота":
                    discount = 0.1; // Если день недели - суббота, устанавливаем скидку 10%
                    break;

                case "воскресенье":
                    discount = 0.1; // Если день недели - воскресенье, устанавливаем скидку 10%
                    break;

                default:
                    Console.WriteLine("Некорректный ввод"); // Если введен некорректный день недели, выводим сообщение об ошибке
                    break;
            }

            double a = sum * discount; // Вычисляем сумму скидки
            double result = sum - a; // Вычисляем итоговую сумму со скидкой
            Console.WriteLine("Сумма со скидкой: " + result); // Выводим итоговую сумму со скидкой
            Console.ReadLine();
        }
    }
}