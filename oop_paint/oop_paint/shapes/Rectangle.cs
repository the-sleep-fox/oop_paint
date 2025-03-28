/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_paint.shapes
{
    using System;
    using System.Text.Json.Serialization;

    namespace oop_paint.shapes
    {
        [JsonDerivedType(typeof(Triangle), typeDiscriminator: "triangle")]
        public class Triangle : Shape
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }

            public (int, int) P2 { get; set; } // Second vertex
            public (int, int) P3 { get; set; } // Third vertex

            public Triangle() { } // Required for deserialization

            public Triangle(int x, int y, int a, int b, int c, char backgroundChar = ' ')
            {
                X = x;
                Y = y;
                A = a;
                B = b;
                C = c;
                BackgroundChar = backgroundChar;
                CalculateVertices();
            }

            private void CalculateVertices()
            {
                P2 = (X + A, Y); // Place second point horizontally to the right
                int px = X + (int)((B * B - C * C + A * A) / (2.0 * A));
                int py = Y - (int)Math.Sqrt(Math.Max(0, B * B - (px - X) * (px - X)));
                P3 = (px, py);
            }

            private void DrawLine(int x1, int y1, int x2, int y2, char[,] buffer)
            {
                int dx = Math.Abs(x2 - x1), sx = x1 < x2 ? 1 : -1;
                int dy = -Math.Abs(y2 - y1), sy = y1 < y2 ? 1 : -1;
                int err = dx + dy, e2;

                while (true)
                {
                    if (x1 >= 1 && x1 < 200 - 1 && y1 >= 1 && y1 < 100 - 1)
                        buffer[y1, x1] = '*';

                    if (x1 == x2 && y1 == y2) break;
                    e2 = 2 * err;
                    if (e2 >= dy) { err += dy; x1 += sx; }
                    if (e2 <= dx) { err += dx; y1 += sy; }
                }
            }

            public override void Draw(char[,] buffer)
            {
                DrawLine(X, Y, P2.Item1, P2.Item2, buffer);
                DrawLine(P2.Item1, P2.Item2, P3.Item1, P3.Item2, buffer);
                DrawLine(P3.Item1, P3.Item2, X, Y, buffer);
            }
        }
    }
}*//**/
