using oop_paint;
using oop_paint.shapes;
using oop_paint.shapes.oop_paint.shapes;
using System;

class Program
{
    static void Main()
    {
        Canvas canvas = new Canvas();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Add Circle");
            Console.WriteLine("2. Add Triangle");
            Console.WriteLine("3. Add Rectangle");
            Console.WriteLine("4. Move Shape");
            Console.WriteLine("5. Delete Shape");
            Console.WriteLine("6. Save Canvas");
            Console.WriteLine("7. Load Canvas");
            Console.WriteLine("8. Undo");
            Console.WriteLine("9. Redo");
            Console.WriteLine("10. Set Background");
            Console.WriteLine("11. Display info about canvas");
            Console.WriteLine("12. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter X (1-48): ");
                    int x = int.Parse(Console.ReadLine());
                    Console.Write("Enter Y (1-18): ");
                    int y = int.Parse(Console.ReadLine());
                    Console.Write("Enter Radius (1-10): ");
                    int r = int.Parse(Console.ReadLine());
                    Console.Write("Enter Background Symbol: ");
                    Console.Write("Enter Background Character (space for none): ");
                    char bgChar = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    canvas.AddShape(new Circle(x, y, r, bgChar));
                    break;
                case "2":
                    Console.Write("Enter X (1-48): ");
                    int x1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter Y (1-18): ");
                    int y1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter A side: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("Enter B side): ");
                    int b = int.Parse(Console.ReadLine());
                    Console.Write("Enter C side: ");
                    int c = int.Parse(Console.ReadLine());
                    Console.Write("Enter Background Character (space for none): ");
                    char bgChar1 = Console.ReadKey().KeyChar;
                    canvas.AddShape(new Triangle(x1, y1, a, b, c, bgChar1));
                    break;
                case "3":
                    
                    break;
                case "4":
                    Console.Write("Enter shape index to move: ");
                    int index = int.Parse(Console.ReadLine());
                    Console.Write("Enter new X: ");
                    int newX = int.Parse(Console.ReadLine());
                    Console.Write("Enter new Y: ");
                    int newY = int.Parse(Console.ReadLine());
                    canvas.MoveShape(index, newX, newY);
                    break;
                case "5":
                    Console.Write("Enter shape index to delete: ");
                    int deleteIndex = int.Parse(Console.ReadLine());
                    canvas.DeleteShape(deleteIndex);
                    break;
                case "6":
                    canvas.SaveCanvas("canvas.json");
                    break;
                case "7":
                    canvas.LoadCanvas("canvas.json");
                    break;
                case "8":
                    canvas.Undo();
                    break;
                case "9":
                    canvas.Redo();
                    break;
                case "10":
                    if (canvas.ShapesCount > 0)
                    {
                        Console.Write("Enter shape index: ");
                        int ind = int.Parse(Console.ReadLine());
                        Console.Write("Enter background character: ");
                        char bgchar = Console.ReadLine()[0]; // Take first character
                        canvas.SetShapeBackground(ind, bgchar);
                    }
                    else
                    {
                        Console.WriteLine("No shapes available.");
                    }
                    break;
                case "11":
                    canvas.DisplayShapeInfo();
                    break;
                case "12":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
