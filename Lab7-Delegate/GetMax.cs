namespace Lab7_Delegate;

public static class GetMax
{
    public static void Start()
    {
        var files = Directory.GetFiles(".").Select(path => new FileInfo(path));
        var maxFile = files.GetMax(x => x.Length);
        Console.WriteLine($"Файл, имеющий набольший размер: {maxFile.Name}");
    }
}

public static class EnumerableEx
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        if (collection == null || !collection.Any()) throw new ArgumentNullException(nameof(collection));

        var maxItem = collection.First();
        var maxValue = convertToNumber(maxItem);

        foreach (var item in collection.Skip(1))
        {
            var value = convertToNumber(item);
            if (value > maxValue)
            {
                maxItem = item;
                maxValue = value;
            }
        }

        return maxItem;
    }
}