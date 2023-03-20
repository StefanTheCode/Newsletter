namespace CleanCodeBestPractices;

public class AvoidPyramids
{
    public int DontDoThis(int x, bool y)
    {
        if (x > 0)
        {
            if (y)
            {
                if (x == 10)
                {
                    return 0;
                }

                return 2;
            }

            return 1;
        }

        return 3;
    }

    public int DoThis(int x, bool y)
    {
        if (x <= 0) return 3;

        if (!y) return 1;

        if (x == 10) return 0;

        return 2;
    }
}