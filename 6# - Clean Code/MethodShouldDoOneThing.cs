namespace CleanCodeBestPractices;

public class MethodShouldDoOneThing_DontDoThis
{
    public void DontDoThis()
    {
        List<User> users = new List<User>
        {
            new User { FirstName = "Stefan", LastName = "Djokic" },
            new User { FirstName = "Elon", LastName = "Musk" },
            new User { FirstName = "Steve", LastName = "Jobs" }
        };

        foreach (var user in users)
        {
            Console.WriteLine($"User: {user.FirstName} - {user.LastName}");
        }
    }

    public void DoThis()
    {
        List<User> users = SetupUsers();

        PrintUsers(users);
    }

    private List<User> SetupUsers()
    {
        var users = new List<User>
        {
            new User { FirstName = "Stefan", LastName = "Djokic" },
            new User { FirstName = "Elon", LastName = "Musk" },
            new User { FirstName = "Steve", LastName = "Jobs" }
        };

        return users;
    }

    private void PrintUsers(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine($"User: {user.FirstName} - {user.LastName}");
        }
    }
}

public class User
{ 
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}