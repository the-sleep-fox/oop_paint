using System;
using System.IO;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;



class CanvasManager
{
    private const string canvasFolder = "Canvases";


    public void OpenCanvas(string fileName)
    {
        string filePath = Path.Combine(canvasFolder, fileName);

        if (!System.IO.File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }

        Console.Clear();
        Console.WriteLine($"Открыт файл: {fileName}");
        Console.WriteLine(new string('-', 40));

        string[] lines = System.IO.File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }

        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
    public CanvasManager()
    {
        if (!Directory.Exists(canvasFolder))
        {
            Directory.CreateDirectory(canvasFolder);
        }
    }

    public void CreateNewCanvas(int width, int height)
    {
        List<string> existingCanvases = GetCanvasList();
        int canvasNumber = existingCanvases.Count + 1;
        string fileName = $"canvas_{canvasNumber}.txt";
        string filePath = Path.Combine(canvasFolder, fileName);

        char[,] canvas = GenerateCanvas(width, height);

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < height + 2; i++)
            {
                for (int j = 0; j < width + 2; j++)
                {
                    writer.Write(canvas[i, j]);
                }
                writer.WriteLine();
            }
        }

        Console.WriteLine($"Создан новый холст: {fileName}");
    }

    public void ShowAllCanvases()
    {
        List<string> canvases = GetCanvasList();
        if (canvases.Count == 0)
        {
            Console.WriteLine("Нет созданных холстов.");
            return;
        }

        Console.WriteLine("Список доступных холстов:");
        for (int i = 0; i < canvases.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {canvases[i]}");
        }
        Console.Write("Введите номер файла для открытия: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= canvases.Count)
        {
            OpenCanvas(Path.GetFileName(canvases[index - 1]));
        }
        else
        {
            Console.WriteLine("Некорректный номер.");
            Console.ReadKey();
        }
    }

    private List<string> GetCanvasList()
    {
        List<string> canvases = new List<string>();
        if (Directory.Exists(canvasFolder))
        {
            foreach (var file in Directory.GetFiles(canvasFolder, "canvas_*.txt"))
            {
                canvases.Add(Path.GetFileName(file));
            }
        }
        return canvases;
    }

    private char[,] GenerateCanvas(int width, int height)
    {
        char[,] canvas = new char[height + 2, width + 2];

        for (int i = 0; i < height + 2; i++)
        {
            for (int j = 0; j < width + 2; j++)
            {
                if (i == 0 || i == height + 1)
                    canvas[i, j] = '-';
                else if (j == 0 || j == width + 1)
                    canvas[i, j] = '|';
                else
                    canvas[i, j] = ' ';
            }
        }

        return canvas;
    }
}
