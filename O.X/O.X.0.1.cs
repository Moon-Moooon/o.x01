//using System;
////using static O.X.Program;

//namespace O.X
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //ClassGird CG = new ClassGird();
//            //CG.GetSetGird = CG.GetGird;
//            //DrowGird.gird(CG.GetSetGird);
//            //Console.WriteLine("Выберите ячейку числом от 1 до 9!");
//            //int a = Convert.ToInt32(Console.ReadLine());
//            //CG.GetSetGird = ChiseCell.MethodForChiseCell(a, CG.GetSetGird, CG);
//            //DrowGird.gird(CG.GetSetGird);
//            ClassLogicOfGame.MethodLogicOfGame();
//        }
//        public class ClassLogicOfGame
//        {
//            public static void MethodLogicOfGame()
//            {
//                ClassGird CG = new ClassGird();
//                CG.GetSetGird = CG.GetGird;
//                DrowGird.gird(CG.GetSetGird);
//                Console.WriteLine("Выберите ячейку числом от 1 до 9!");
//                int a = Convert.ToInt32(Console.ReadLine());
//                CG.GetSetGird = ChiseCell.MethodForChiseCell(a, CG.GetSetGird);
//                DrowGird.gird(CG.GetSetGird);
//            }
//        }
//        public class ClassGird
//        {
//            public char[,] OriginalGrid = new char[,]
//            {
//            {'-','-','-' },
//            {'-','-','-' },
//            {'-','-','-' }
//            };

//            public char[,] GetGird
//            {
//                get
//                {
//                    return OriginalGrid;
//                    Console.WriteLine("Сработало");
//                }
//            }

//            private char[,] WorkingGrid; // = new char[,] { };

//            public char[,] GetSetGird
//            {
//                get
//                {
//                    return WorkingGrid;
//                }
//                set
//                {
//                WorkingGrid = value;
//                }
//            }


//        }

//        public class ChiseCell                       // Разобраться почему без статика не работает //видать потомучто без статика нужно создать экземпляр
//        {
//            public static char[,] MethodForChiseCell(int a, char[,] Gird)   // надо менять символ постоновки.
//            {
//                int columns = Gird.GetUpperBound(0) + 1;
//                int rows = Gird.Length / columns;

//                int NumberOFStroke = 0;

//                for (int i = 0; i < 3; i++)
//                {
//                    for (int j = 0; j < rows; j++)
//                    {
//                        NumberOFStroke++;
//                        if (a == NumberOFStroke)
//                        {
//                            HandlerOfTheGrid.MethodHandlerOfTheGrid(Gird);
//                            Gird[i, j] = 'x';

//                            break;
//                        } 
//                        //else if ( a != NumberOFStroke)
//                        //{
//                        //    Console.WriteLine("Ячейка уже занята выберети другую");
//                        //}
                        
//                    }
//                }   
                
//                return Gird;
//            }
//        }
//    }

//    public class ChangingSides
//    {
//        public static void MethodChangingSides()
//        {

//        }
//    }

//    public class DrowGird
//    {
//        public static void gird(char[,] GGird)
//        {
//            char[,] Gird = GGird;

//            int columns = Gird.GetUpperBound(0) + 1;
//            int rows = Gird.Length / columns;
//            for (int i = 0; i < columns; i++)
//            {
//                for (int j = 0; j < rows; j++)
//                {
//                    Console.Write(Gird[i, j]);
//                }
//                Console.WriteLine();
//            }
//        }
//    }


//    public class HandlerOfTheGrid
//    {
//        public static void MethodHandlerOfTheGrid(char [,] Grid)
//        {
//            int x = 0;
//            foreach (char i in Grid) // Перебирает все ячейки и подсчитывает все в x
//            {
//                switch (i)
//                {
//                    case 'x':
//                    case 'o':
//                        x = 0; 
//                        break;

//                    case '-':
//                        x += 1;
//                        break;
//                    default:
//                        Console.WriteLine("Ошибка в классе MethodHandlerOfTheGrid ");
//                        break;
//                } 
                
//            }

//            switch (x)  // Анализирует x и говрит продолжать игру или нет.
//            {
//                case (0):
//                    Console.WriteLine($"Игра окончена, победил <>");
//                    // Реализовать 
//                    break;
//                default:
//                    Console.WriteLine($"Игра Продолжается");
//                    break;
//            }
//            DrowGird.gird(Grid);
//            Console.WriteLine("Выберите ячейку числом от 1 до 9!");
//            //return Grid;
//        }
//    }
//}
////public static class ChooseCell
////{
////    static void chooseCell(char[,] GGird, int a)
////    {
////        for (int i = 0; i < 3; i++)
////        {
////            for (int j = 0; j < 3; j++)
////            {
////                if (a == j + i && GGird[j, i] != '-')
////                {
////                    //вызов функции по смене значения ячейки
////                    GGird[j, i] = 'x';
////                    break;
////                }

////                break;
////            }

////            break;
////        }
////    }
////}

////вызов функции по смене значения ячейки

////public char[,] chooseCell(int a)
////{
////    for (int i = 0; i < 3; i++)
////    {
////        for (int j = 0; j < 3; j++)
////        {
////            if (a == 4) //&& GGird[j, i] != '-'
////            {
////                //вызов функции по смене значения ячейки
////                GGird[0, 0] = 'x';
////            }
////            else
////            {
////                Console.WriteLine("Не прошло");
////            }


////            break;
////        }

////        break;
////    }

////    return GGird;

////public static void gird()
////{
////    char[,] GGird = new char[,]
////    {
////        {'-','-','-' },
////        {'-','-','-' },
////        {'-','-','-' }
////    };

////    int columns = GGird.GetUpperBound(0) + 1;
////    int rows = GGird.Length / columns;
////    for (int i = 0; i < columns; i++)
////    {
////        for (int j = 0; j < rows; j++)
////        {
////            Console.Write(GGird[i, j]);
////        }
////        Console.WriteLine();
////    }
////}