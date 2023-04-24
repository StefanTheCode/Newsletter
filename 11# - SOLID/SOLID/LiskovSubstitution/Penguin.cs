namespace LiskovSubstitution;

public class Penguin : Bird
{
    public override void MakeSound()
    {
        Console.WriteLine("Quak!");
    }
}