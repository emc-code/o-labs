namespace Lab5_Solid;

public class SettingsDto
{
    public int MinValue { get; init; } = int.MinValue;
    public int MaxValue { get; init; } = int.MaxValue;
    public int TargetValue { get; init; } = 0;
    public int AttemptCount { get; init; } = 1;
}
