using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_1
{
    class Canvas
    {
        private char[,] grid; // Двумерный массив символов (холст)
        private int width, height;
        private string filePath; // Путь к файлу

        public Canvas(int w, int h, string path)
        {
            width = w;
            height = h;
            filePath = path;
            grid = new char[height, width];

            InitializeCanvas();
        }

        private void InitializeCanvas()
        {
            // Заполняем пробелами (внутреннюю часть)
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }

        public void LoadFromFile()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден, создаем новый холст.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < Math.Min(height, lines.Length); i++)
            {
                for (int j = 0; j < Math.Min(width, lines[i].Length); j++)
                {
                    grid[i, j] = lines[i][j];
                }
            }
        }

        public void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        sw.Write(grid[i, j]);
                    }
                    sw.WriteLine();
                }
            }
            Console.WriteLine("Холст сохранен!");
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("=== Холст ===");

            // Верхняя граница
            Console.Write("+");
            for (int i = 0; i < width; i++) Console.Write("-");
            Console.WriteLine("+");

            // Основная область
            for (int i = 0; i < height; i++)
            {
                Console.Write("|"); // Левая граница
                for (int j = 0; j < width; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine("|"); // Правая граница
            }

            // Нижняя граница
            Console.Write("+");
            for (int i = 0; i < width; i++) Console.Write("-");
            Console.WriteLine("+");
        }

        public void Draw(int x, int y, char symbol)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                grid[y, x] = symbol;
            }
        }
    }
}
