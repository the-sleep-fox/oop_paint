using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_paint
{
    public class DrawingSettings
    {
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
        public char Symbol { get; set; } = '*';
        public double AspectRatio { get; set; } = 2.0;
        public double BorderThickness { get; set; } = 0.4;
    }
}
