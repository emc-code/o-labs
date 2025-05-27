namespace Lab5_Solid.Player;

/// <summary>
/// Игрок - рандом
/// </summary>
internal class SimulationPlayer : IPlayer
{
    private int _minValue;
    private int _maxValue;
    private Random _random;

    public SimulationPlayer(int minValue, int maxValue) =>
        (_minValue, _maxValue, _random) = (minValue, maxValue, new Random());
    public int InputValue() => _random.Next(_minValue, _maxValue);
}
