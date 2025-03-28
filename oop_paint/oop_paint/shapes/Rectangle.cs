
using System.Text.Json.Serialization;


namespace oop_paint.shapes
{
    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        [JsonConstructor]
        public Rectangle() { }

        public Rectangle(int x, int y, int width, int height, char backgroundChar = ' ')
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;   
            BackgroundChar = backgroundChar;
        }

        public override void Draw(char[,] buffer)
        {
           
            if (BackgroundChar != ' ')
            {
                for (int y = Y; y < Y + Height; y++)
                {
                    for (int x = X; x < X + Width; x++)
                    {
                        if (x >= 1 && x < buffer.GetLength(1) - 1 &&
                            y >= 1 && y < buffer.GetLength(0) - 1)
                        {
                            buffer[y, x] = BackgroundChar;
                        }
                    }
                }
            }

     
            for (int x = X; x < X + Width; x++)
            {
                if (x >= 1 && x < buffer.GetLength(1) - 1 &&
                    Y >= 1 && Y < buffer.GetLength(0) - 1)
                {
                    buffer[Y, x] = '*'; 
                }

                if (x >= 1 && x < buffer.GetLength(1) - 1 &&
                    (Y + Height - 1) >= 1 && (Y + Height - 1) < buffer.GetLength(0) - 1)
                {
                    buffer[Y + Height - 1, x] = '*'; 
                }
            }

          
            for (int y = Y; y < Y + Height; y++)
            {
                if (y >= 1 && y < buffer.GetLength(0) - 1 &&
                    X >= 1 && X < buffer.GetLength(1) - 1)
                {
                    buffer[y, X] = '*'; 
                }

                if (y >= 1 && y < buffer.GetLength(0) - 1 &&
                    (X + Width - 1) >= 1 && (X + Width - 1) < buffer.GetLength(1) - 1)
                {
                    buffer[y, X + Width - 1] = '*'; 
                }
            }

            Console.ResetColor();
        }

        public override bool IsPointInside(int px, int py)
        {
            return px >= X && px <= X + Width - 1 &&
                   py >= Y && py <= Y + Height - 1;
        }
    }
}

