namespace LiskovSubstitution;

public class Pigeon : Bird, IFly
{
    public override void MakeSound()
    {
        Console.WriteLine("Coo!");
    }

    public void Fly()
    {
        Console.WriteLine("Pigeon is flying.");
    }
}