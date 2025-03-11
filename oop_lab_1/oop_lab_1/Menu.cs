using System;
using System.IO;

class Menu
{
    private CanvasManager manager;

    public Menu()
    {
        manager = new CanvasManager();
    }

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Консольный Paint ===");
            Console.WriteLine("1. Создать новый холст");
            Console.WriteLine("2. Просмотреть существующие холсты");
            Console.WriteLine("3. Выйти");

            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateCanvas();
                    break;
                case "2":
                    manager.ShowAllCanvases();
                    Console.WriteLine("Нажмите любую клавишу для возврата...");
                    Console.ReadKey();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод! Попробуйте снова...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void CreateCanvas()
    {
        Console.Write("Введите ширину холста: ");
        int width = int.Parse(Console.ReadLine());

        Console.Write("Введите высоту холста: ");
        int height = int.Parse(Console.ReadLine());

        manager.CreateNewCanvas(width, height);
    }
}
