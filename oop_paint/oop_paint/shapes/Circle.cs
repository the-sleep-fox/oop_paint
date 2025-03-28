using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace oop_paint.shapes
{

    [JsonDerivedType(typeof(Circle), typeDiscriminator: "circle")]
    public class Circle : Shape
    {
        public int Radius { get; set; }


        public Circle() { } // Required for deserialization

        public Circle(int x, int y, int radius, char backgroundChar = ' ')
        {
            X = x;
            Y = y;
            Radius = radius;
            BackgroundChar = backgroundChar;

        }

        public override bool IsPointInside(int px, int py)
        {
            int dx = px - X;
            int dy = py - Y;
            return dx * dx + dy * dy <= Radius * Radius;
        }

        public override void Draw(char[,] buffer)
        {
            if (BackgroundChar != ' ')
            {
                // Use canvas dimensions through parent reference
                int left = Math.Max(1, X - Radius);
                int right = Math.Min(200 - 2, X + Radius);
                int top = Math.Max(1, Y - Radius);
                int bottom = Math.Min(100 - 2, Y + Radius);

                for (int y = top; y <= bottom; y++)
                {
                    for (int x = left; x <= right; x++)
                    {
                        if (IsPointInside(x, y))
                        {
                            buffer[y, x] = BackgroundChar;
                        }
                    }
                }
            }


            for (double angle = 0; angle < 360; angle += 10)
            {
                int px = (int)(X + Radius * Math.Cos(angle * Math.PI / 180));
                int py = (int)(Y + Radius * Math.Sin(angle * Math.PI / 180));

                if (px >= 1 && px < 200 - 1 &&
                    py >= 1 && py < 100 - 1)
                {
                    buffer[py, px] = '*';
                }
            }

        }
    }
}

