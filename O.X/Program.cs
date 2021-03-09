using System;

// - желательно рефакторить и посмотреть доктрины по нецймингу CamelCase и тп 

namespace O.X
{
    class Program  // почему если ставить паблик( но не работает с интернал хотя по логике должно) то ошибка в MethodForChiseCell(int a, char[,] Gird, ClassGird CG) с передачей ClassGird пропадает, не понятно.
    {
        static void Main(string[] args)
        {
            ClassLogicOfGame CLFG = new ClassLogicOfGame();
        }
    }

    public class ClassLogicOfGame
    {
        public ClassLogicOfGame()
        {
            int GamePlay = 1;
            int NumberOfPlayer = 1;    // Переменная отвечает за цифру которая обозначет символ которым будет ходитьт игрок.
            ClassGird CG = new ClassGird();
            DrowGird.gird(CG.GetSetGird);
            CoreOFTheProcess(GamePlay, CG, NumberOfPlayer);
        }

        public static int NumberOfTheCharChose()
        {
            Console.WriteLine("Выберите ячейку числом от 1 до 9!\n");
            Console.WriteLine("================================================\n");
            string str = Console.ReadLine();
            if (Int32.TryParse(str, out int a))
            {
                a = Convert.ToInt32(str);
            }
            else
            {
                Console.WriteLine("Неверно введен символ выберите другой");
                a = NumberOfTheCharChose();
            }
            return a;
        }

        public static void ChangeOfNumberPlayer(ref int NumberOfPlayer)
        {
            if (NumberOfPlayer > 0)
            {
                NumberOfPlayer = NumberOfPlayer - 1;
            }
            else
            {
                NumberOfPlayer++;
            }
        }

        public static void CoreOFTheProcess(int GamePlay, ClassGird CG, int NumberOfPlayer)
        {
            while (GamePlay > 0)
            {
                if (NumberOfPlayer == 0)
                {
                    Bot.PlayerBot(ref NumberOfPlayer, CG.GetSetGird);
                }
                else
                {
                    int a = NumberOfTheCharChose();
                    CG.GetSetGird = ChiseCell.MethodForChiseCell(a, CG.GetSetGird, ref NumberOfPlayer);
                }
                HandlerOfTheGrid.MethodHandlerOfTheGrid(CG.GetSetGird);
                CoreLogicOfGanePlay.CoreLogic(CG.GetSetGird);
                //Console.WriteLine("\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                Console.WriteLine("================================================\n");
            }
        }
    }
    public class ClassGird
    {
        public ClassGird()
        {
            GetSetGird = GetGird;
        }
        private char[,] OriginalGrid = new char[,]
        {
            {'-','-','-' },
            {'-','-','-' },
            {'-','-','-' }
        };

        public char[,] GetGird
        {
            get
            {
                return OriginalGrid;
            }
        }

        private char[,] WorkingGrid;

        public char[,] GetSetGird
        {
            get
            {
                return WorkingGrid;
            }
            set
            {
                WorkingGrid = value;
            }
        }

    }

    public class ChiseCell       // Разобраться почему без статика не работает //видать потомучто без статика нужно создать экземпляр
    {
        public static char[,] MethodForChiseCell(int a, char[,] Gird, ref int NumberOfPlayer)
        {
            int columns = Gird.GetUpperBound(0) + 1;
            int rows = Gird.Length / columns;

            int NumberOFStroke = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    NumberOFStroke++;
                    if (a == NumberOFStroke)
                    {
                        if (Gird[i, j] != '-')
                        {
                            if (NumberOfPlayer == 1)
                            {
                                Console.WriteLine("Ячейка уже занята выберите другую ");
                            }
                            else
                            {
                                Bot.PlayerBot(ref NumberOfPlayer, Gird);
                            }
                        }
                        else
                        {
                            char result = NumberOfPlayer > 0 ? 'x' : 'o';
                            Gird[i, j] = result;
                            if (NumberOfPlayer == 0)
                            {
                                Console.WriteLine($"Бот выюрал ячейку {a} ");
                            }
                            ClassLogicOfGame.ChangeOfNumberPlayer(ref NumberOfPlayer);
                        }

                    }
                }
            }
            return Gird;
        }
    }

    public class DrowGird
    {
        public static void gird(char[,] GGird)
        {
            char[,] Gird = GGird;

            int columns = Gird.GetUpperBound(0) + 1;
            int rows = Gird.Length / columns;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write(Gird[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

    public class HandlerOfTheGrid
    {
        public static void MethodHandlerOfTheGrid(char[,] Grid)
        {
            int x = 0;
            foreach (char i in Grid) // Перебирает все ячейки и подсчитывает все в x
            {
                switch (i)
                {
                    case 'x':
                    case 'o':
                        x += 0;
                        break;

                    case '-':
                        x += 1;
                        break;
                    default:
                        Console.WriteLine("Ошибка в классе MethodHandlerOfTheGrid ");
                        break;
                }

            }
            DrowGird.gird(Grid);
            switch (x)  // Анализирует x и говрит продолжать игру или нет.
            {
                case (0):
                    Console.WriteLine($"Игра окончена, ты не выйграл рандом ) \n");
                    Console.WriteLine("Нажмите любую клавишу для завершения игры ");
                    Console.ReadKey();
                    Environment.Exit(0); // = команда оканчивает процесс игры 
                    break;
                default:

                    break;
            }
        }
    }

    class Bot
    {
        public static void PlayerBot(ref int NumberOfPlayer, char[,] Gird)
        {
            if (NumberOfPlayer == 0)
            {
                Random RandomN = new Random();
                int value = RandomN.Next(1, 9);
                ChiseCell.MethodForChiseCell(value, Gird, ref NumberOfPlayer);

            }
        }
    }

    class CoreLogicOfGanePlay
    {
        public static void CoreLogic(char[,] Gird)   // Понять почему если не писать статик то выдает 120 ошибка
        {
            int columns = Gird.GetUpperBound(0) + 1;
            int rows = Gird.Length / columns;

            char[] q = new char[columns];
            int NumberOfCoincidences = 0;

            for (int c = 0; c < columns; c++)
            {
                for(int r = 0; r < rows; r++)
                {
                    q[r] = Gird[c, r];
                }
                foreach (char i in q)
                {
                    if (i == q[0] && i != '-')
                    {
                        NumberOfCoincidences++;
                        if (NumberOfCoincidences == 3)
                        {
                            if (q[0] == 'x')
                            {
                                Console.WriteLine($"Вы победил бота замечательно!)");
                            }
                            if (q[0] == 'o')
                            {
                                Console.WriteLine($"Вас победил бот");
                            }
                            Console.WriteLine("Нажмите клавишу чтобы выйти из игры");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                }
                NumberOfCoincidences = 0;
            }
            for (int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    q[r] = Gird[r, c];
                }
                foreach (char i in q)
                {
                    if (i == q[0] && i != '-')
                    {
                        NumberOfCoincidences++;
                        if (NumberOfCoincidences == 3)
                        {
                            if (q[0] == 'x')
                            {
                                Console.WriteLine($"Вы пgitобедил бота замечательно!)");
                            }
                            if (q[0] == 'o')
                            {
                                Console.WriteLine($"Вас победил бот");
                            }
                            Console.WriteLine("Нажмите клавишу чтобы выйти из игры");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                }
                NumberOfCoincidences = 0;
            }
        }
    }
}

