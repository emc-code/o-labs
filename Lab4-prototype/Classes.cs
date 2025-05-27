using System.Globalization;

namespace Lab4_prototype;

/// <summary>
/// Устройство ввода
/// </summary>
abstract class InputDevice : ICloneable
{
    public object Clone() => throw new NotImplementedException();

    /// <summary>
    /// Вывод информации
    /// </summary>
    public abstract void Print(string data);
}

/// <summary>
/// Устройство вывода
/// </summary>
abstract class OutputDevice : ICloneable
{
    public object Clone() => throw new NotImplementedException();

    public abstract void Connect(string data);
}

/// <summary>
/// архиватор
/// </summary>
abstract class Archiver : ICloneable
{
    public object Clone() => throw new NotImplementedException();

    public abstract void Compress(string data);
}

/// <summary>
/// специализированное ПО
/// </summary>
abstract class CADSystem : ICloneable
{
    public object Clone() => throw new NotImplementedException();

    public abstract void LoadData(string data);
}
