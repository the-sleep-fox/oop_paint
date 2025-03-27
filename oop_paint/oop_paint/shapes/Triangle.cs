using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_paint.shapes
{
    public class Triangle : Shape
    {
        private int _height;

        public Triangle(DrawingSettings settings) : base(settings) { }

        public override void RequestDimensions()
        {
            do
            {
                Console.Write("Введите высоту: ");
                if (!int.TryParse(Console.ReadLine(), out _height) || _height <= 0)
                {
                    Console.WriteLine("Высота должна быть положительным числом");
                }
            }
            while (_height <= 0);
        }

        public override void Draw()
        {
            Console.ForegroundColor = Settings.Color;

            for (int y = 0; y < _height; y++)
            {
                int stars = y * 2 + 1;
                int spaces = _height - y - 1;

                Console.Write(new string(' ', spaces));
                Console.WriteLine(new string(Settings.Symbol, stars));
            }
        }
    }
}
