using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_paint
{
    public class Canvas
    {
        private readonly char[,] _pixels;
        public int Width { get; }
        public int Height { get; }
        public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.White;
        public char EmptyPixel { get; set; } = ' ';

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
            _pixels = new char[height, width];
            Clear();
        }

        public void Clear()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    _pixels[y, x] = EmptyPixel;
                }
            }
        }

        public void SetPixel(int x, int y, char value)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                _pixels[y, x] = value;
            }
        }

        public void DrawPoint(double x, double y, char symbol)
        {
            int canvasX = (int)Math.Round(x);
            int canvasY = (int)Math.Round(y);
            SetPixel(canvasX, canvasY, symbol);
        }

        public void Render()
        {
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;

            var sb = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    sb.Append(_pixels[y, x]);
                }
                sb.AppendLine();
            }
            Console.Write(sb.ToString());
        }

        public void DrawShape(Shape shape)
        {
            shape.Draw();
        }
    }
}
