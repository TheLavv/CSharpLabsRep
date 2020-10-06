using System;

namespace BiqEquation
{
    class Program
    {
        static void Find_Root(double A, double B, double C)
        {
            double D;
            D = B * B - 4 * A * C;
            if (D < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nДискриминант отрицательный => корней нет.");
                Console.ResetColor();
                return;
            }
            double y1, y2;
            y1 = (-B + Math.Sqrt(D)) / (2 * A);
            y2 = (-B - Math.Sqrt(D)) / (2 * A);
            int counter = 1;
            Console.WriteLine("\nРезультат:");
            Console.ForegroundColor = ConsoleColor.Green;
            if (C == 0)
                Console.WriteLine("root" + counter++ + " = 0");
            if (y1 < 0 && y2 < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Корней нет.");
                Console.ResetColor();
            }
            if (y1 > 0)
            {
                Console.WriteLine("root" + counter++ + " = " + Math.Sqrt(y1) + "\nroot" + counter++ + " = " + Math.Sqrt(y1) * -1);
            }
            if (y2 > 0 && D > 0)
            {
                Console.WriteLine("root" + counter++ + " = " + Math.Sqrt(y2) + "\nroot" + counter++ + " = " + Math.Sqrt(y2) * -1);
            }
            Console.ResetColor();
        }
        static int Input_Num(ref double A, string temp)
        {
            int i = 0;
            if (temp.Length == 0)
                return (-1);
            while (i < temp.Length)
            {
                if (temp[i] != ' ' && (temp[i] < '0' || temp[i] > '9') && temp[i] != '-')
                    return (-1);
                else if (temp[i] >= '0' && temp[i] <= '9')
                    break;
                else if (temp[i] == '-')
                {
                    i++;
                    break;
                }
                i++;
            }
            if (i == temp.Length)
                return (-1);
            while (i < temp.Length)
            {
                if (temp[i] < '0' || temp[i] > '9')
                    return (-1);
                i++;
            }
            A = double.Parse(temp);
            return (0);
        }
        static void Main(string[] args)
        {
            double A, B, C;
            A = B = C = 1;
            string temp;
            Console.WriteLine("Разработчик: Головацкий Андрей\nГруппа: ИУ5-31Б");
            if (args.Length > 0)
            {
                if (args.Length != 3)
                {
                    Console.WriteLine("\nОшибка. Неверное количество аргументов. Повторите ввод.");
                    return;
                }
                temp = args[0];
                if (Input_Num(ref A, temp) == -1 || A == 0)
                {
                    Console.WriteLine("\nНеверный формат. Повторите ввод.");
                    return;
                }
                temp = args[1];
                if (Input_Num(ref B, temp) == -1)
                {
                    Console.WriteLine("\nНеверный формат. Повторите ввод.");
                    return;
                }
                temp = args[2];
                if (Input_Num(ref C, temp) == -1)
                {
                    Console.WriteLine("\nНеверный формат. Повторите ввод.");
                    return;
                }
                Console.WriteLine("\nВведенные коэффициенты:\nA = " + A + "\nB = " + B + "\nC = " + C);
                Find_Root(A, B, C);
                return;
            }
            Console.Write("\nВведите коэффициенты:\nA: ");
            temp = Console.ReadLine();
            while ((Input_Num(ref A, temp)) == -1 || A == 0)
            { 
                Console.Write("Неверный формат. Повторите ввод.\nA: ");
                temp = Console.ReadLine();
            }
            Console.Write("B: ");
            temp = Console.ReadLine();
            while ((Input_Num(ref B, temp)) == -1)
            {
                Console.Write("Неверный формат. Повторите ввод.\nB: ");
                temp = Console.ReadLine();
            }
            Console.Write("C: ");
            temp = Console.ReadLine();
            while ((Input_Num(ref C, temp)) == -1)
            {
                Console.Write("Неверный формат. Повторите ввод.\nC: ");
                temp = Console.ReadLine();
            }
            Find_Root(A, B, C);
        }
    }
}
