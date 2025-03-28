using oop_paint.shapes;
using System.Text.Json.Serialization;

[JsonPolymorphic]
[JsonDerivedType(typeof(Circle), typeDiscriminator: "circle")]
[JsonDerivedType(typeof(Triangle), typeDiscriminator: "triangle")]
[JsonDerivedType(typeof(Rectangle), typeDiscriminator: "rectangle")]
public abstract class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public char BackgroundChar { get; set; } = ' '; // Space means no background
    [JsonConstructor]
    protected Shape() { }
    public abstract void Draw(char[,] buffer);
    public abstract bool IsPointInside(int px, int py);
}
