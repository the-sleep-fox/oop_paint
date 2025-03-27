using oop_paint.shapes;


namespace oop_paint
{
    public static class ShapeFactory
    {
        public static Shape CreateShape(int choice, DrawingSettings settings)
        {
            return choice switch
            {
                1 => new Circle(settings),
                2 => new Rectangle(settings),
                3 => new Triangle(settings),
                _ => throw new ArgumentException("Неизвестный тип фигуры")
            };
        }
    }
}
