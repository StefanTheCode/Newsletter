namespace CleanCodeBestPractices;

public class AvoidReturnNull
{
    //Edge case: Only if you need explicitly to return null
    public IEnumerable<string> DontDoThis()
    {
        return null;
    }

    public IEnumerable<string> DoThis()
    {
        return Enumerable.Empty<string>();
    }
}