using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_paint
{
    public static class MenuManager
    {
        public static int GetMenuChoice()
        {
            Console.WriteLine("Выберите фигуру:");
            Console.WriteLine("1 - Круг");
            Console.WriteLine("2 - Квадрат");
            Console.WriteLine("3 - Треугольник");
            Console.Write("Ваш выбор: ");

            return GetValidatedInput(3, "Пожалуйста, введите число от 1 до 3");
        }

        public static ConsoleColor GetColorChoice()
        {
            Console.Write("Выберите цвет (1-Желтый, 2-Красный, 3-Голубой): ");
            int choice = GetValidatedInput(3, "Пожалуйста, введите число от 1 до 3");

            return choice switch
            {
                1 => ConsoleColor.Yellow,
                2 => ConsoleColor.Red,
                3 => ConsoleColor.Cyan,
                _ => ConsoleColor.White
            };
        }

        public static char GetSymbol()
        {
            Console.Write("Введите символ для рисования: ");
            return Console.ReadKey().KeyChar;
        }

        public static int GetPositiveInt(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                {
                    return value;
                }
                Console.WriteLine(errorMessage);
            }
        }

        public static double GetPositiveDouble(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value) && value > 0)
                {
                    return value;
                }
                Console.WriteLine(errorMessage);
            }
        }

        private static int GetValidatedInput(int maxChoice, string errorMessage)
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxChoice)
                Console.WriteLine(errorMessage);
            return choice;
        }
    }
}
