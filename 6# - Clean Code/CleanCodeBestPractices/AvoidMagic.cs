namespace CleanCodeBestPractices;

public class AvoidMagic
{
    //It doesn't have to be all capital letters
    public const int MAXIMUM_NUMBER_OF_USERS = 100;

    public void DontDoThis(int numberOfUsers)
    {
        //100 is called a "Magic number"
        if (numberOfUsers < 100)
        {
            //Do something
        }
    }

    public void DoThis(int numberOfUsers)
    {
        if(numberOfUsers < MAXIMUM_NUMBER_OF_USERS)
        {
            //Do something
        }
    }
}