using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();

var result = GetAllSpaces(@".\..\..\..\data");

Debug.WriteLine(result);

int GetAllSpaces(string dirPath, int limit = 3)
{
    var files = Directory.GetFiles(dirPath);

    var tasks = new List<Task<int>>();
    for (int i = 0; i < files.Length; i++)
    {
        if (i == limit)
            break;

        /// прикольный кейс с замыканием переменной цикла I внутри лямбы
        /// т.е. в цикле "1.txt", а в методе - выводится и обсчитывается "2.txt" или вовсе I уже инкрементировано и мы вываливаемся за пределы массива
        //Debug.WriteLine($"in cycle {files[i]}");
        //tasks.Add(Task.Run(() => GetFileSpaceCount(files[i])));

        string fileName = files[i];
        tasks.Add(Task.Run(() => GetFileSpaceCount(fileName)));
    }

    Task.WaitAll(tasks.ToArray());

    return tasks.Sum(t => t.Result);
}

int GetFileSpaceCount(string filePath)
{
    Debug.WriteLine($"in method {filePath}");
    using var reader = new StreamReader(filePath);
    return reader.ReadToEnd().Count(c => c == ' ');
}

sw.Stop();
Debug.WriteLine(sw.ElapsedMilliseconds);