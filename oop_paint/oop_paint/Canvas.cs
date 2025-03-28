using oop_paint.shapes;
using System.Text.Json.Serialization;
using System.Text.Json;



public class Canvas
{
    private const int Width = 200;
    private const int Height = 100;
    private List<Shape> shapes = new List<Shape>();
    private Stack<List<Shape>> undoStack = new Stack<List<Shape>>();
    private Stack<List<Shape>> redoStack = new Stack<List<Shape>>();
    public int ShapesCount => shapes.Count;

    public int GetWidth() => Width;
    public int GetHeight() => Height;

    public void SetShapeBackground(int index, char backgroundChar)
    {
        if (index >= 0 && index < shapes.Count)
        {
            SaveState();
            shapes[index].BackgroundChar = backgroundChar;
            Redraw();
        }
    }
    public void AddShape(Shape shape)
    {
        SaveState();
        shapes.Add(shape);
        Redraw();
    }

    public void MoveShape(int index, int newX, int newY)
    {
        if (index >= 0 && index < shapes.Count)
        {
            SaveState();
            shapes[index].X = Math.Clamp(newX, 1, Width - 2);
            shapes[index].Y = Math.Clamp(newY, 1, Height - 2);
            Redraw();
        }
    }

    public void DeleteShape(int index)
    {
        if (index >= 0 && index < shapes.Count)
        {
            SaveState();
            shapes.RemoveAt(index);
            Redraw();
        }
    }

    public void SaveCanvas(string filename)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };
            string json = JsonSerializer.Serialize(shapes, options);
            File.WriteAllText(filename, json);
            Console.WriteLine("Canvas saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving canvas: {ex.Message}");
        }
    }

    public void LoadCanvas(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };
            string json = File.ReadAllText(filename);
            shapes = JsonSerializer.Deserialize<List<Shape>>(json, options) ?? new List<Shape>();
            Console.WriteLine("Canvas loaded successfully.");
            Redraw();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading canvas: {ex.Message}");
        }
    }

    public void Undo()
    {
        if (undoStack.Count > 0)
        {
           
            redoStack.Push(CreateShapesCopy(shapes));

         
            shapes = CreateShapesCopy(undoStack.Pop());
            Redraw();
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }

    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            
            undoStack.Push(CreateShapesCopy(shapes));

            shapes = CreateShapesCopy(redoStack.Pop());
            Redraw();
        }
        else
        {
            Console.WriteLine("Nothing to redo.");
        }
    }
    private void SaveState()
    {
        undoStack.Push(CreateShapesCopy(shapes));
        redoStack.Clear();
    }

    private List<Shape> CreateShapesCopy(List<Shape> original)
    {
        var copy = new List<Shape>();
        foreach (var shape in original)
        {
            if (shape is Circle circle)
            {
                copy.Add(new Circle(circle.X, circle.Y, circle.Radius, circle.BackgroundChar));
            }
            else if (shape is Triangle triangle)
            {
                copy.Add(new Triangle(triangle.X, triangle.Y, triangle.A, triangle.B, triangle.C, triangle.BackgroundChar));
                
            }
            else if (shape is Rectangle rectangle)
            {
                copy.Add(new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, rectangle.BackgroundChar));

            }
            
        }
        return copy; 
    }
    private void Redraw()
    {
        Console.Clear();
        DrawFrame();

        
        char[,] buffer = new char[Height, Width];

       
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (y == 0 || y == Height - 1) buffer[y, x] = '-';
                else if (x == 0 || x == Width - 1) buffer[y, x] = '|';
                else buffer[y, x] = ' ';
            }
        }

        
        foreach (var shape in shapes)
        {
            shape.Draw(buffer);
        }

      
        Console.SetCursorPosition(0, 0);
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Console.Write(buffer[y, x]);
            }
            Console.WriteLine();
        }

        
        Console.SetCursorPosition(0, Height + 1);
    }

    private void DrawFrame()
    { 
        
    }
    public void DisplayShapeInfo()
    {
        Console.WriteLine($"Canvas contains {shapes.Count} shapes:");
        for (int i = 0; i < shapes.Count; i++)
        {
            var shape = shapes[i];
            if (shape is Triangle triangle)
            {
                Console.WriteLine($"[{i}] Triangle at ({triangle.X},{triangle.Y}) " +
                    $"with sides {triangle.A},{triangle.B},{triangle.C} an background char {triangle.BackgroundChar}");
            }
            else if (shape is Circle circle)
            {
                Console.WriteLine($"[{i}] Circle at ({circle.X},{circle.Y}) " +
                    $"with radius {circle.Radius} and background char {circle.BackgroundChar}");
            }
            else if(shape is Rectangle rectangle)
            {
                Console.WriteLine($"[{i}] Rectangle at ({rectangle.X},{rectangle.Y}) " +
                   $"with sides {rectangle.Width},{rectangle.Height} and background char {rectangle.BackgroundChar}");
            }
        }
    }
}