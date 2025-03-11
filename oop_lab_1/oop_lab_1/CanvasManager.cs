using System;
using System.IO;
using System.Collections.Generic;
using oop_lab_1;

class CanvasManager
{
    private const string CanvasFolder = "Canvases";

    public CanvasManager()
    {
        if (!Directory.Exists(CanvasFolder))
        {
            Directory.CreateDirectory(CanvasFolder);
        }
    }

    public void CreateNewCanvas(int width, int height)
    {
        List<string> existingCanvases = GetCanvasList();
        int canvasNumber = existingCanvases.Count + 1;
        string fileName = $"canvas_{canvasNumber}.txt";
        string filePath = Path.Combine(CanvasFolder, fileName);

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
    }

    private List<string> GetCanvasList()
    {
        List<string> canvases = new List<string>();
        if (Directory.Exists(CanvasFolder))
        {
            foreach (var file in Directory.GetFiles(CanvasFolder, "canvas_*.txt"))
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
