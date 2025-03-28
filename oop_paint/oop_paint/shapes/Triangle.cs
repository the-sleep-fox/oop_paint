

namespace oop_paint.shapes
{
    using System;
    using System.Text.Json.Serialization;

    namespace oop_paint.shapes
    {
        public class Triangle : Shape
        {
            public int A { get; set; } // Side lengths
            public int B { get; set; }
            public int C { get; set; }

            [JsonConstructor]
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

            public override bool IsPointInside(int px, int py)
            {
                // Compute area of the main triangle
                double areaMain = TriangleArea(X, Y, X + A, Y, X, Y + B);

                // Compute sub-triangle areas
                double area1 = TriangleArea(px, py, X + A, Y, X, Y + B);
                double area2 = TriangleArea(X, Y, px, py, X, Y + B);
                double area3 = TriangleArea(X, Y, X + A, Y, px, py);

                // If sum of sub-areas equals the main area, the point is inside
                return Math.Abs(areaMain - (area1 + area2 + area3)) < 1e-2;
            }

            private double TriangleArea(int x1, int y1, int x2, int y2, int x3, int y3)
            {
                return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
            }

            public override void Draw(char[,] buffer)
            {
                int x2 = X + A;
                int y2 = Y;
                int x3 = X;
                int y3 = Y + B;

                // Draw triangle edges using Bresenham's algorithm
                DrawLine(buffer, X, Y, x2, y2);
                DrawLine(buffer, X, Y, x3, y3);
                DrawLine(buffer, x2, y2, x3, y3);

                // Fill background if needed
                if (BackgroundChar != ' ')
                {
                    for (int i = 1; i < buffer.GetLength(1) - 1; i++)
                    {
                        for (int j = 1; j < buffer.GetLength(0) - 1; j++)
                        {
                            if (IsPointInside(i, j))
                            {
                                buffer[j, i] = BackgroundChar;
                            }
                        }
                    }
                }
            }

            private void DrawLine(char[,] buffer, int x1, int y1, int x2, int y2)
            {
                int dx = Math.Abs(x2 - x1), sx = x1 < x2 ? 1 : -1;
                int dy = -Math.Abs(y2 - y1), sy = y1 < y2 ? 1 : -1;
                int err = dx + dy, e2;

                while (true)
                {
                    if (x1 >= 1 && x1 < buffer.GetLength(1) - 1 && y1 >= 1 && y1 < buffer.GetLength(0) - 1)
                    {
                        buffer[y1, x1] = '*';
                    }

                    if (x1 == x2 && y1 == y2) break;
                    e2 = 2 * err;
                    if (e2 >= dy) { err += dy; x1 += sx; }
                    if (e2 <= dx) { err += dx; y1 += sy; }
                }
            }
        }
    }

}
