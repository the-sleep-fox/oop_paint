using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_paint.shapes
{
    public class Circle : Shape
    {
        private double _radius;

        public Circle(DrawingSettings settings) : base(settings) { }

        public override void RequestDimensions()
        {
            do
            {
                Console.Write("Введите радиус: ");
                if (!double.TryParse(Console.ReadLine(), out _radius) || _radius <= 0)
                {
                    Console.WriteLine("Радиус должен быть положительным числом");
                }
            }
            while (_radius <= 0);
        }

        public override void Draw()
        {
            Console.ForegroundColor = Settings.Color;

            double rIn = _radius - Settings.BorderThickness;
            double rOut = _radius + Settings.BorderThickness;

            for (double y = _radius; y >= -_radius; --y)
            {
                for (double x = -_radius; x < rOut; x += 0.5)
                {
                    double value = x * x + (y * Settings.AspectRatio) * (y * Settings.AspectRatio);
                    Console.Write(value >= rIn * rIn && value <= rOut * rOut ? Settings.Symbol : ' ');
                }
                Console.WriteLine();
            }
        }
    }
}
