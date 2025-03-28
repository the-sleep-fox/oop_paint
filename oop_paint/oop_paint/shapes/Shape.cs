using oop_paint;
using oop_paint.shapes;
using System.Text.Json.Serialization;

public abstract class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public char BackgroundChar { get; set; } = ' '; // Space means no background

    public abstract void Draw(char[,] buffer);

    // Helper method to check if point is inside shape
    public abstract bool IsPointInside(int px, int py);
}
