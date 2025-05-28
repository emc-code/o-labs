using Lab5_Solid.Common;

namespace Lab5_Solid.Player;

/// <summary>
/// Игрок - рандом
/// </summary>
internal class SimulationPlayer : IPlayer, IRandom
{
    private int _minValue;
    private int _maxValue;
    private Random _random;

    public SimulationPlayer(int minValue, int maxValue) =>
        (_minValue, _maxValue, _random) = (minValue, maxValue, new Random());

    public int GetRandomValue(int minValue, int maxValue) => new Random().Next(minValue, maxValue);

    public int InputValue() => GetRandomValue(_minValue, _maxValue);
}
