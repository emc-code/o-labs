namespace Lab5_Solid.Player;

/// <summary>
/// Игрок - человек с клавиатурой
/// </summary>
internal class RealPlayer : IPlayer
{
    public int InputValue()
    {
        Console.WriteLine("Input value: ");
        return int.Parse(Console.ReadLine());
    }
}
