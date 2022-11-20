public class Program
{

    public static double minScore = 4.8;
    public static double maxScore = 5;
    public static int minAge = 24;
    public static int maxAge = 30;

    public static void Main()
    {
        Factory fact = new Factory();
        InformDepartment In = new InformDepartment("InformDepartment");
        ElectricianDepartment El = new ElectricianDepartment("ElectricianDepartment");
        MechanicDepartment Me = new MechanicDepartment("MechanicDepartment");
        fact.Departments.Add(In);
        fact.Departments.Add(El);
        fact.Departments.Add(Me);
        fact.Departments.Add(new Department("Department"));

        for (int i = 0; i < 10; i++)
        {
            fact.Candidates.Add(new Person($"Человек_{i}"));
            // Console.WriteLine($"{fact.Candidates[i].Name} : {fact.Candidates[i].Age} лет: Score - {fact.Candidates[i].Score} : {fact.Candidates[i].PersonSpeciality}");
        }

        foreach (var department in fact.Departments)
        {
            department.StaffSelection(fact.Candidates);
        }

        Console.WriteLine(In.PrintEmployees());
        Console.WriteLine(El.PrintEmployees());
        Console.WriteLine(Me.PrintEmployees());
        // Console.WriteLine();
        // Console.WriteLine("Не трудоустроенные:");
        // foreach (var candidate in fact.Candidates)
        // {
        //     Console.WriteLine($"{candidate.Name} : {candidate.Age} лет: Score - {candidate.Score} : {candidate.PersonSpeciality}");
        // }
    }
}
