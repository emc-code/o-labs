namespace Lab7_Delegate;

public static class Files
{
    public static void Start()
    {
        var scaner = new DirScanner();
        scaner.FileFound += Scaner_FileFound;
        scaner.Scan(".");
    }

    static void Scaner_FileFound(object? sender, FileArgs e)
    {
        Console.WriteLine($"Найден файл: {e.FileName}");

        if (e.FileName.Contains(".exe"))
        {
            (sender as DirScanner).Stop();
            Console.WriteLine("Найден .exe. Поиск прерван.");
        }
    }
}


public class FileArgs : EventArgs
{
    public string FileName { get; init; }

    public FileArgs(string fileName) =>
        FileName = fileName;
}

public class DirScanner
{
    public event EventHandler<FileArgs> FileFound;
    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    public void Scan(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
            throw new DirectoryNotFoundException($"Каталог не найден: {directoryPath}");

        foreach (var filePath in Directory.EnumerateFiles(directoryPath, "*", SearchOption.AllDirectories))
        {
            if (_cancellationTokenSource.Token.IsCancellationRequested)
                return;

            FileFound?.Invoke(this, new FileArgs(filePath));
        }
    }

    public void Stop() => _cancellationTokenSource.Cancel();
}