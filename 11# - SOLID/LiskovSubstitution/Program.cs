using LiskovSubstitution;

Console.WriteLine("L - Liskov Substitution Principle");

List<Bird> birds = new()
{
    new Pigeon(),
    new Penguin()
};

foreach (var bird in birds)
{
    bird.MakeSound();

    if (bird is IFly flyingBird)
    {
        flyingBird.Fly();
    }
    else
    {
        Console.WriteLine($"{bird.GetType().Name} cannot fly.");
    }
}