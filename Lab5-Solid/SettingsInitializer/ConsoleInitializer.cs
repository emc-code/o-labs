using Lab5_Solid.SettingsGenerator;

namespace Lab5_Solid.SettingsInitializer;

/// <summary>
/// Ввод настроек вручную
/// </summary>
internal class ConsoleInitializer : IInitializer
{
    public SettingsDto Init()
    {
        Console.WriteLine("input min value");
        var minValue = int.Parse(Console.ReadLine());
        
        Console.WriteLine("input max value");
        var maxValue = int.Parse(Console.ReadLine());
        
        Console.WriteLine("input target value");
        var targetValue = int.Parse(Console.ReadLine());
        
        Console.WriteLine("input attempt count");
        var attemptCount = int.Parse(Console.ReadLine());

        return new SettingsDto { AttemptCount = attemptCount, MaxValue = maxValue, TargetValue = targetValue, MinValue = minValue };
    }
}
