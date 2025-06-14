// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

string SerializeToString(object obj)
{
    Type type = obj.GetType();

    var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);

    var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.CanRead);

    var fieldPairs = fields.Select(f => $"{f.Name}={f.GetValue(obj)}");
    var propertyPairs = properties.Select(p => $"{p.Name}={p.GetValue(obj)}");

    return string.Join(", ", fieldPairs.Concat(propertyPairs));
}


F DeserializeFromString(object data)
{
    var f = new F();
    var type = typeof(F);
    var rawPairs = data.ToString().Split(',', StringSplitOptions.RemoveEmptyEntries);

    foreach (var rawPair in rawPairs)
    {
        var pair = rawPair.Split('=', StringSplitOptions.RemoveEmptyEntries);
        var key = pair[0].Trim();
        var value = int.Parse(pair[1].Trim());

        var field = type.GetField(key);
        if (field != null && field.FieldType == typeof(int))
            field.SetValue(f, value);
    }

    return f;
}

string SerializeToJson<T>(T obj)
{
    var oprions = new JsonSerializerOptions() { IgnoreReadOnlyProperties = false };
    string json = JsonSerializer.Serialize(obj, oprions);
    return json;
}

F DeserializeFromJson(object data)
{
    var options = new JsonSerializerOptions();
    var f = JsonSerializer.Deserialize<F>(data.ToString(), options);
    return f;
}

List<T> CsvDeserialize<T>(object csvData) where T : new()
{
    var lines = csvData.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

    string[] headers = lines[0].Split(',');
    var fields = typeof(T).GetFields(BindingFlags.Instance | BindingFlags.Public)
                          .ToDictionary(f => f.Name, f => f, StringComparer.OrdinalIgnoreCase);

    var result = new List<T>();

    for (int i = 1; i < lines.Length; i++)
    {
        string[] values = lines[i].Split(',');
        var obj = new T();

        for (int j = 0; j < headers.Length && j < values.Length; j++)
        {
            string header = headers[j].Trim();
            string value = values[j].Trim();

            if (fields.TryGetValue(header, out var field))
            {
                object converted = Convert.ChangeType(value, field.FieldType);
                field.SetValue(obj, converted);
            }
        }

        result.Add(obj);
    }

    return result;
}

void Test(Func<object, object> func, object arg, string name, int attemptCount)
{
    var result = string.Empty;

    var stopwatch = Stopwatch.StartNew();

    for (int i = 0; i < attemptCount; i++)
        result = func(arg).ToString();

    stopwatch.Stop();

    Console.WriteLine($"Метод {name} был выполен {attemptCount} раз за {stopwatch.ElapsedMilliseconds} мс");
    Console.WriteLine($"Результат операции: {result}");
}

int attemptCount = 100000;
var f = new F();
f = f.Get();
string str = SerializeToString(f);

Test(SerializeToString, f, nameof(SerializeToString), attemptCount);
Test(DeserializeFromString, str, nameof(SerializeToString), attemptCount);

string json = SerializeToJson(f);
Test(SerializeToJson, f, nameof(SerializeToJson), attemptCount);
Test(DeserializeFromJson, json, nameof(DeserializeFromJson), attemptCount);


string csvData =
@"i1,i2,i3,i4,i5
1,2,3,4,5
10,20,30,40,50";

Test(CsvDeserialize<F>, csvData, nameof(CsvDeserialize), attemptCount);


class F
{
    public int i1, i2, i3, i4, i5;
    public F Get() => new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
}

