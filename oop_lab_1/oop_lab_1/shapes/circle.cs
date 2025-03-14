using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_1.shapes
{
    class circle : shape
    {
        private int radius;

        public int Radius
        {
            get { return radius; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Радиус не может быть отрицательным.");
                }
                radius = value;
            }
        }


        public override void Draw(char[,] canvas)
        {
            int x0 = CenterX;
            int y0 = CenterY;
            int radius = Radius;

            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    if (x * x + y * y <= radius * radius)
                    {
                        int drawX = x0 + x;
                        int drawY = y0 + y;
                        if (drawX >= 0 && drawX < canvas.GetLength(0) && drawY >= 0 && drawY < canvas.GetLength(1))
                        {
                            canvas[drawX, drawY] = Symbol;
                        }
                    }
                }
            }
        }

        public override void Erase(char[,] canvas)
        {
            int x0 = CenterX;
            int y0 = CenterY;
            int radius = Radius;

            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    if (x * x + y * y <= radius * radius)
                    {
                        int drawX = x0 + x;
                        int drawY = y0 + y;
                        if (drawX >= 0 && drawX < canvas.GetLength(0) && drawY >= 0 && drawY < canvas.GetLength(1))
                        {
                            canvas[drawX, drawY] = ' '; 
                        }
                    }
                }
            }
        }
    }
}
