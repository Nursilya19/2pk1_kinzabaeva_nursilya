namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();
            string[] textArray = text.Split('.'); // разделяем текст на предложения с помощью метода Split()

            for (int i = 0; i < textArray.Length - 1; i++) // сортируем предложения по длине
            {
                for (int j = i + 1; j < textArray.Length; j++)
                {
                    if (textArray[i].Length > textArray[j].Length)
                    {
                        string temp = textArray[i];
                        textArray[i] = textArray[j];
                        textArray[j] = temp;
                    }
                }
            }

            foreach (string sentence in textArray) // перебираем предложения из текста
            {
                int sentenceLength = 0;

                foreach (char c in sentence) // перебираем символы в предложении
                {
                    if (!Char.IsSeparator(c))
                    {
                        sentenceLength++;
                    }
                }

                string simvol = $"{sentence} ({sentenceLength} символов)";
                Console.WriteLine(simvol);
            }
        }
        }
    }
