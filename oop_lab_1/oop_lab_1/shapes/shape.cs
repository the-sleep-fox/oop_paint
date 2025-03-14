using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_1.shapes
{
    abstract class shape
    {
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public char Symbol { get; set; }

        public abstract void Draw(char[,] canvas);
        public abstract void Erase(char[,] canvas);
    }
}
