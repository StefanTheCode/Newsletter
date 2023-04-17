namespace CleanCodeBestPractices;

public class BeStronglyTyped
{
    public void DontDoThis(string employeeType)
    {
        if (employeeType == "administrator")
        {
            //Do something
        }
    }

    public void DoThis(Employee employee)
    {
        if (employee.Type == Type.Administrator)
        {
            //Do something
        }
    }
}

public class Employee
{
    public string Name { get; set; } = String.Empty;
    public Type Type { get; set; }
}

public enum Type
{
    Manager = 1,
    Administrator = 2
}