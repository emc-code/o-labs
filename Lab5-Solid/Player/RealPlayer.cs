namespace Lab5_Solid.Player;

internal class RealPlayer : IPlayer
{
    public int InputValue()
    {
        Console.WriteLine("Input value: ");
        return int.Parse(Console.ReadLine());
    }
}
