using Lab5_Solid.Common;
using Lab5_Solid.SettingsGenerator;

namespace Lab5_Solid.SettingsInitializer;

/// <summary>
/// Генерация настроек рандомно
/// </summary>
internal class RandomInitializer : IInitializer, IRandom
{
    public int GetRandomValue(int minValue, int maxValue) =>
        new Random().Next(minValue, maxValue);

    public SettingsDto Init()
    {
        Random random = new();

        int v1 = random.Next();
        int v2;
        while ((v2 = random.Next()) == v1)
        { }

        int minValue = v1 < v2 ? v1 : v2;
        int maxValue = v1 > v2 ? v1 : v2;
        int targetValue = random.Next(minValue, maxValue);
        int attemptCount = random.Next(100);

        return new SettingsDto { AttemptCount = attemptCount, MaxValue = maxValue, TargetValue = targetValue, MinValue = minValue };
    }
}
