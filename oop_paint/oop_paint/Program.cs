using oop_paint;

class Program
{
    static void Main()
    {
        var settings = ConfigureDrawingSettings();
        Shape shape = CreateSelectedShape(settings);

        DrawShape(shape);
        Console.ReadKey();
    }

    private static DrawingSettings ConfigureDrawingSettings()
    {
        return new DrawingSettings
        {
            Color = MenuManager.GetColorChoice(),
            Symbol = MenuManager.GetSymbol()
        };
    }

    private static Shape CreateSelectedShape(DrawingSettings settings)
    {
        int choice = MenuManager.GetMenuChoice();
        Shape shape = ShapeFactory.CreateShape(choice, settings);
        shape.RequestDimensions();
        return shape;
    }

    private static void DrawShape(Shape shape)
    {
        Console.Clear();
        shape.Draw();
        Console.ResetColor();
    }
}