using System;

namespace PZ_16
{
    internal class Program
    {
        // Параметры карты
        static int mapSize = 25; // Фиксированный размер карты
        static char[,] map = new char[mapSize, mapSize]; // Массив для хранения данных карты

        // Координаты игрока в массиве
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;

        // Количество элементов
        static byte enemyCount = 5; // Количество врагов
        static byte buffCount = 5; // Количество усилений
        static int aidCount = 5;  // Количество аптечек  
        static int stepCount = 0; // Общее количество шагов
        static int stepsave = 0; // После баффа

        // Характеристики игрока
        static int playerHP = 50; // Здоровье 
        static int playerDMG = 10; // Урон

        // Характеристики врагов
        static int enemyHP = 30; // Здоровье
        static int enemyDMG = 5; // Урон

        // Расположение текста в окне
        static int centerY = Console.WindowHeight / 2;
        static int centerX = (Console.WindowHeight / 2) - 1;

        //Сервисные переменные
        static string lastAction = "Начало игры"; // Окошко информации
        static bool bringbuff = false; // Поднятие баффа
        static int selectedMenuItem = 0; // Пункт меню
        static void SplashScreen() // Стартовый экран
        {
            string[] str = new string[2];
            str[0] = "N - Начать новую игру";
            str[1] = "L - Загрузить последнее сохранение";

            int centerY = (Console.WindowHeight / 2) - (str.Length / 2);
            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < str.Length; i++)
            {
                int centerX = (Console.WindowWidth / 2) - (str[i].Length / 2);
                Console.SetCursorPosition(centerX, centerY + i);
                Console.WriteLine(str[i]);
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Game";
            Menu();
            Move();
        }
        static void GenerationMap() // Генерация карты с объектами
        {
            Random random = new Random();
            for (int i = 0; i < mapSize; i++) // Создание пустой карты
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (j == mapSize - 1)
                    {
                        Console.SetCursorPosition(i, j); 
                        map[i, j] = '_';
                    }
                    else
                    {
                        map[i, j] = '_';
                    }
                }
            }
            map[playerY, playerX] = 'P'; // В середину карты ставится игрок

            int x;
            int y;

            while (enemyCount > 0) // Добавление врагов
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'E';
                    enemyCount--;
                }
            }

            while (buffCount > 0) // Добавление баффов
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B';
                    buffCount--;
                }
            }

            while (aidCount > 0) // Добавление аптечек
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'H';
                    aidCount--;
                }
            }
            UpdateMap();
        }
        static void Move() // Перемещение 
        {
            // Предыдущие координаты игрока
            int playerOldY;
            int playerOldX;

            while (true)
            {
                playerOldX = playerX;
                playerOldY = playerY;

                switch (Console.ReadKey().Key) // Управление через клавиатуру
                {
                    case ConsoleKey.UpArrow:
                        playerX--;
                        stepCount++;
                        break;
                    case ConsoleKey.DownArrow:
                        playerX++;
                        stepCount++;
                        break;
                    case ConsoleKey.LeftArrow:
                        playerY--;
                        stepCount++;
                        break;
                    case ConsoleKey.RightArrow:
                        playerY++;
                        stepCount++;
                        break;
                    case ConsoleKey.Escape: // Сохранение и выход из игры
                        SaveProgress();
                        Console.Clear();
                        Centertext("Игра сохранена", centerY);
                        Console.ReadLine();
                        return;
                }

                // Ограничение по границам карты
                if (playerX < 0) playerX = 0;
                if (playerY < 0) playerY = 0;
                if (playerX >= mapSize) playerX = mapSize - 1;
                if (playerY >= mapSize) playerY = mapSize - 1;

                Console.CursorVisible = false; // Скрытый курсор

                // Предыдущее положение игрока затирается
                map[playerOldY, playerOldX] = '_';
                Console.SetCursorPosition(playerOldY, playerOldX);
                Console.Write('_');

                // Обновленное положение игрока
                map[playerY, playerX] = 'P';
                Console.SetCursorPosition(playerY, playerX);
                Console.ForegroundColor = ConsoleColor.Cyan; // Цвет игрока
                Console.Write('P');
                Console.ForegroundColor = ConsoleColor.White; // Цвет следа за игроком
                Console.SetCursorPosition(0, mapSize);

                // Применение функций боя, баффа, аптечки, победы
                Fight();
                BuffUp();
                Heal();
                Victory();

                int x, y;
                // Отображение показателей
                Console.SetCursorPosition(0, 25);
                Console.Write("Последнее действие: " + lastAction);
                
                Console.WriteLine($"\nЗдоровье: {playerHP}  ");
                Console.WriteLine($"Сила атаки: {playerDMG}  ");
                Console.WriteLine($"Пройдено шагов: {stepCount}  ");
            }
        }
        static void SaveProgress() // Сохранение в файл
        {
            string path = "save.txt"; // Создание текстового файла
            using (StreamWriter writer = new StreamWriter(path)) // Запись в него параметров
            {
                for (int i = 0; i < mapSize; i++) // Запись карты
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (map[i, j] == 'P')
                        {
                            map[i, j] = '_';
                        }
                        writer.Write(map[i, j]);
                    }
                    writer.WriteLine();
                }
                writer.WriteLine($"Положение игрока по оси X = {playerX}");
                writer.WriteLine($"Положение игрока по оси Y = {playerY}");
                writer.WriteLine($"Здоровье игрока = {playerHP}");
                writer.WriteLine($"Сила атаки = {playerDMG}");
                writer.WriteLine($"Пройдено шагов = {stepCount}");
                writer.WriteLine($"Здоровье врага = {enemyHP}");
                writer.WriteLine($"Использован ли бафф = {bringbuff}");
                writer.WriteLine($"Бафф = {stepsave}");

            }
        }
        static void LoadProgress() // Восстановление из файла
        {
            string path = "save.txt"; // Путь

            if (File.Exists(path)) // Если существует
            {
                string[] lines = File.ReadAllLines(path); // Передача файлов с документа в игру

                if (lines.Length >= mapSize)
                {
                    if (int.TryParse(lines[0].Split('=')[1], out int loadPlayerX) &&
                    int.TryParse(lines[1].Split('=')[1], out int loadPlayerY) &&
                    int.TryParse(lines[2].Split('=')[1], out int loadPlayerHP) &&
                    int.TryParse(lines[3].Split('=')[1], out int loadPlayerStrong) &&
                    int.TryParse(lines[4].Split('=')[1], out int loadPlayerStepCount) &&
                    int.TryParse(lines[5].Split('=')[1], out int loadEnemyHP) &&
                    bool.TryParse(lines[6].Split('=')[1], out bool loadHasBuff) &&
                    int.TryParse(lines[7].Split('=')[1], out int loadBuffStep))
                    {
                        playerX = loadPlayerX;
                        playerY = loadPlayerY;
                        playerHP = loadPlayerHP;
                        playerDMG = loadPlayerStrong;
                        stepCount = loadPlayerStepCount;
                        stepsave = loadBuffStep;
                        enemyHP = loadEnemyHP;
                        bringbuff = loadHasBuff;

                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = '_';
                            }
                        }

                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = lines[i + 8][j];
                            }
                        }

                        map[playerX, playerY] = 'P';

                        Console.Clear();
                        UpdateMap(); //Вывод на консоль
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка чтения файла сохранения.");
                }
            }
            else
            {
                Console.WriteLine("Файл сохранения не найден.");
            }
        }
        static void UpdateMap()  // Полное обновление карты на консоли
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++) //Запись карты в консоль
            {
                for (int j = 0; j < mapSize; j++)
                {
                    switch (map[i, j]) // Окраска элементов
                    {
                        case 'E':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 'B':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 'H':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                    Console.Write(map[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
        static void Victory()
        {
            for (int i = 0; i < mapSize; i++) // Проверка на наличие врагов
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == 'E')
                    {
                        return;
                    }
                }
            }

            Console.Clear();
            Centertext("_Игра пройдена", centerY);
            Centertext("Вы сделали " + stepCount + " шагов", centerY + 1);
            Centertext("Нажмите Enter для выхода из игры", centerY + 2);

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Enter);

            Environment.Exit(0); // Выход
        }
        static void BuffUp() // Логика баффов
        {
            if (map[playerX, playerY] == 'B')
            {   
                bringbuff = true;
                stepsave = stepCount; //сохранение шага на котором взят бафф
                playerDMG = playerDMG * 2;
                map[playerX, playerY] = '_'; // Решение проблемы "фантомного элемента"
                lastAction = "Поднят бафф. Усиление атак                        ";
            }
            if (stepsave == stepCount - 20) // Расчитан на 20 шагов
            {
                bringbuff = false;
                playerDMG = 10; // Возврат к изначальному урону
                lastAction = "Бафф закончился.                        ";
            }
        }
        static void Heal()
        {
            if (map[playerX, playerY] == 'H')
            {
                playerHP = 50; // Лечение до максимума
                map[playerX, playerY] = '_'; // Решение проблемы "фантомного элемента"
                lastAction = "Поднята аптечка. Восстановление здоровья                        ";
            }
        }
        static void Fight() // Логика поднятия аптечки
        {
            if (map[playerX, playerY] == 'E') // Если встать на врага
            {
                // Здесь мы проверяем, находится ли игрок на клетке с врагом, обозначенной символом 'E' в массиве карты.
                // Если да, то начинаем бой.

                while (playerHP > 0 && enemyHP > 0) // Пока оба живы
                {
                    enemyHP = enemyHP - playerDMG; // Уменьшаем здоровье врага на значение нанесенного игроком урона
                    playerHP = playerHP - enemyDMG; // Уменьшаем здоровье игрока на значение нанесенного врагом урона

                    if (playerHP <= 0) // Если здоровье игрока кончилось, экран проигрыша
                    {
                        Console.Clear();

                        string[] texts = { $"Вы проиграли, пройдено шагов {stepCount}. Игра окончена.", "Нажмите Enter для возвращения в меню" };
                        int centerY = Console.WindowHeight / 2 - texts.Length / 2;

                        for (int i = 0; i < texts.Length; i++)
                        {
                            Centertext(texts[i], centerY + i); // Центрируем текст по вертикали
                        }

                        ConsoleKeyInfo keyInfo;
                        do
                        {
                            keyInfo = Console.ReadKey();
                        } while (keyInfo.Key != ConsoleKey.Enter);

                        Menu(); // Выход в меню
                    }

                    if (enemyHP <= 0) // Если враг побежден, то игрок остается в ячейке
                    {
                        map[playerX, playerY] = '_'; // Обозначаем текущее местоположение игрока в массиве карты символом "_", обозначающим пустую клетку
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('_'); // Очищаем предыдущую позицию игрока на экране
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('P'); // Помечаем новую позицию игрока на экране символом "P"
                        lastAction = "Вы победили врага и потеряли " + (50 - playerHP) + " HP   "; // Записываем информацию о последнем действии игрока
                    }
                    else // Анимация боя
                    {
                        for (int i = 0; i < 3; i++) // Перебор символов анимации
                        {
                            Console.SetCursorPosition(playerY, playerX);
                            Console.Write('|');
                            Thread.Sleep(60);
                            Console.SetCursorPosition(playerY, playerX);
                            Console.Write('/');
                            Thread.Sleep(60);
                            Console.SetCursorPosition(playerY, playerX);
                            Console.Write('-');
                            Thread.Sleep(60);
                        }
                        Console.Write('_');
                    }
                }
                enemyHP = 30; // Возврат здоровья для следующего игрока
            }
        }
        static void Menu() // Управление стрелочками и основной вызов меню
        {
            ConsoleKeyInfo key;   
            do
            {
                Console.Clear(); // Очистка консоли
                SplashScreen(); // Отображение стартового экрана

                key = Console.ReadKey(true); // Ожидание нажатия клавиши

                switch (key.Key) // В зависимости от нажатой клавиши
                {
                    case ConsoleKey.N: // Создание новой карты
                        GenerationMap(); // Генерация карты
                        Move(); // Начало движения игрока
                        break;
                    case ConsoleKey.L: // Загрузка последней игры
                        LoadProgress(); // Загрузка последней игры
                        Move(); // Начало движения игрока
                        break;
                    case ConsoleKey.Enter: // Обработка выбранного пункта меню
                        HandleMenuSelection(); // Обработка выбранного пункта меню
                        break;
                }
            } while (key.Key != ConsoleKey.Enter); // Повторять цикл пока не будет нажата клавиша Enter
        }
        static void HandleMenuSelection() // Передача и открытие функций
        {
            Console.Clear(); // Очистка консоли
            switch (selectedMenuItem) // В зависимости от выбранного пункта меню
            {
                case 0: // Пункт меню "Создать новую карту"
                    GenerationMap(); // Создание новой карты
                    break;
                case 1: // Пункт меню "Загрузить последнюю игру"
                    Console.WriteLine("Выполняется загрузка..."); // Отображение сообщения о загрузке
                    LoadProgress(); // Загрузка последней игры
                    UpdateMap(); // Обновление карты
                    break;
                case 2: // Пункт меню "Выйти из игры"
                    Console.WriteLine("До следующей игры!"); // Отображение сообщения о выходе из игры
                    Environment.Exit(0); // Выход из приложения
                    break;
            }
            Console.ReadKey(true); // Ожидание нажатия клавиши
        }
        
        static void Centertext(string text, int y) // Сделано для оформления по середине
        {
            int centerX = Console.WindowWidth / 2 - text.Length / 2; // Вычисление координаты X для выравнивания текста по центру
            Console.SetCursorPosition(centerX, y); // Установка позиции курсора
            Console.WriteLine(text); // Вывод текста
        }
    }
}