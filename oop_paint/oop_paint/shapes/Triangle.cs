/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_paint.shapes
{
    public class Triangle : Shape
    {
        private int _topX, _topY;
        private double _leftSide, _rightSide, _base;

        public Triangle(DrawingSettings settings) : base(settings) { }

        public override void RequestDimensions()
        {
            _topX = MenuManager.GetPositiveInt("Enter top vertex X coordinate: ", "Coordinate must be positive");
            _topY = MenuManager.GetPositiveInt("Enter top vertex Y coordinate: ", "Coordinate must be positive");

            _leftSide = MenuManager.GetPositiveDouble("Enter left side length: ", "Side must be positive");
            _rightSide = MenuManager.GetPositiveDouble("Enter right side length: ", "Side must be positive");
            _base = MenuManager.GetPositiveDouble("Enter base length: ", "Base must be positive");
        }

        public override void Draw(Canvas canvas)
        {
            // Calculate triangle points
            double angle = CalculateAngle(_leftSide, _rightSide, _base);
            int leftX = (int)(_topX - _base / 2);
            int leftY = (int)(_topY + _leftSide * Math.Sin(angle));
            int rightX = (int)(_topX + _base / 2);
            int rightY = leftY;

            // Draw three sides
            DrawLine(canvas, _topX, _topY, leftX, leftY);
            DrawLine(canvas, _topX, _topY, rightX, rightY);
            DrawLine(canvas, leftX, leftY, rightX, rightY);
        }

        private double CalculateAngle(double a, double b, double c)
        {
            return Math.Acos((a * a + b * b - c * c) / (2 * a * b));
        }

        private void DrawLine(Canvas canvas, int x1, int y1, int x2, int y2)
        {
            // Bresenham's line algorithm
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                canvas.SetPixel(x1, y1, Settings.Symbol);

                if (x1 == x2 && y1 == y2) break;

                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }
            }
        }
    }
}
*/