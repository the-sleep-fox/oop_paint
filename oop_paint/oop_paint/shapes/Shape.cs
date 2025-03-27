using oop_paint;
public abstract class Shape
{
    protected DrawingSettings Settings { get; }

    protected Shape(DrawingSettings settings)
    {
        Settings = settings;
    }

    public abstract void Draw();
    public abstract void RequestDimensions();
}