/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_paint.shapes
{
    public class Rectangle : Shape
{
    private int _size;

    public Rectangle(DrawingSettings settings) : base(settings) { }

    public override void RequestDimensions()
    {
        do
        {
            Console.Write("Введите размер стороны: ");
            if (!int.TryParse(Console.ReadLine(), out _size) || _size <= 0)
            {
                Console.WriteLine("Размер должен быть положительным числом");
            }
        }
        while (_size <= 0);
    }

    public override void Draw(Canvas canvas)
    {
        Console.ForegroundColor = Settings.Color;
        int height = (int)(_size / Settings.AspectRatio);
        
        for (int y = 0; y < height; y++)
        {
            Console.WriteLine(new string(Settings.Symbol, _size));
        }
    }
}
}
*/