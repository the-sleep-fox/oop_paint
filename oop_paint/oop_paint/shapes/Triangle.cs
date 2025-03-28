using System;
using System.Text.Json.Serialization;

namespace oop_paint.shapes
{
    [JsonDerivedType(typeof(Triangle), typeDiscriminator: "triangle")]
    public class Triangle : Shape
    {
        public int A { get; set; } // Side 1
        public int B { get; set; } // Side 2
        public int C { get; set; } // Side 3

        public Triangle() { }

        public Triangle(int x, int y, int a, int b, int c, char backgroundChar = ' ')
        {
            X = x;
            Y = y;
            A = a;
            B = b;
            C = c;
            BackgroundChar = backgroundChar;
        }

        public override void Draw(char[,] buffer)
        {
            
            (int x2, int y2) = (X - B / 2, Y + A);
            (int x3, int y3) = (X + C / 2, Y + A);

            DrawLine(buffer, X, Y, x2, y2);
            DrawLine(buffer, X, Y, x3, y3);
            DrawLine(buffer, x2, y2, x3, y3);

           
            if (BackgroundChar != ' ')
            {
                for (int py = Math.Min(Y, y2); py <= Math.Max(y2, y3); py++)
                {
                    for (int px = Math.Min(x2, x3); px <= Math.Max(x2, x3); px++)
                    {
                        if (IsPointInside(px, py))
                        {
                            buffer[py, px] = BackgroundChar;
                        }
                    }
                }
            }
        }

        public override bool IsPointInside(int px, int py)
        {
            (int x2, int y2) = (X - B / 2, Y + A);
            (int x3, int y3) = (X + C / 2, Y + A);

            double areaOrig = TriangleArea(X, Y, x2, y2, x3, y3);
            double area1 = TriangleArea(px, py, x2, y2, x3, y3);
            double area2 = TriangleArea(X, Y, px, py, x3, y3);
            double area3 = TriangleArea(X, Y, x2, y2, px, py);

            return Math.Abs(areaOrig - (area1 + area2 + area3)) < 0.5;
        }

        private double TriangleArea(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
        }

        private void DrawLine(char[,] buffer, int x1, int y1, int x2, int y2)
        {
            int dx = Math.Abs(x2 - x1), sx = x1 < x2 ? 1 : -1;
            int dy = -Math.Abs(y2 - y1), sy = y1 < y2 ? 1 : -1;
            int err = dx + dy, e2;

            while (true)
            {
                if (x1 >= 0 && x1 < buffer.GetLength(1) && y1 >= 0 && y1 < buffer.GetLength(0))
                    buffer[y1, x1] = '*';

                if (x1 == x2 && y1 == y2) break;
                e2 = 2 * err;
                if (e2 >= dy) { err += dy; x1 += sx; }
                if (e2 <= dx) { err += dx; y1 += sy; }
            }
        }
    }
}
