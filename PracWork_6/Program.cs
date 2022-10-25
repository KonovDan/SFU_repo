

public class Program
{

    public static double minScore = 0;
    public static double maxScore = 5;
    public static int minAge = 18;
    public static  int maxAge = 60;

    public static void Main()
    {
        Factory fact = new Factory();
        fact.Departments.Add(new InformDepartment("InformDepartment"));
        fact.Departments.Add(new ElectricianDepartment("ElectricianDepartment"));
        fact.Departments.Add(new MechanicDepartment("MechanicDepartment"));
        fact.Departments.Add(new Department("Department"));

        for (int i = 0; i < 10; i++)
        {
            fact.Candidates.Add(new Person($"{i}"));
            Console.WriteLine($"{fact.Candidates[i].Name} : {fact.Candidates[i].Age} лет: Score - {fact.Candidates[i].Score} : {fact.Candidates[i].PersonSpeciality}");
        }

        foreach (var department in fact.Departments)
        {
            department.StaffSelection(fact.Candidates);
        }
                    Console.WriteLine();
        foreach (var candidate in fact.Candidates)
        {
            Console.WriteLine($"{candidate.Name} : {candidate.Age} лет: Score - {candidate.Score} : {candidate.PersonSpeciality}");
        }


    }
}

class Person
{
    public string Name { get; init; } = "";
    public int Age { get; init; }
    public Speciality PersonSpeciality { get; init; }
    public double Score { get; init; }
    public Person(string Name)
    {
        this.Name = Name;
        this.Age = new Random().Next(Program.minAge, Program.maxAge);
        PersonSpeciality = (Speciality)new Random().Next(0, 5);
        this.Score = ((double)new Random().Next((int)Program.minScore * 10, (int)Program.maxScore * 10)) / 10;
    }
}

enum Speciality
{
    Electrician,
    Mechanic,
    Mathematitian,
    Programmer,
    Lawyer
}

class Factory
{
    public List<Department> Departments;
    public List<Person> Candidates;

    public Factory()
    {
        this.Departments = new List<Department> { };
        this.Candidates = new List<Person> { };
    }
}

class Department
{
    public string Title;
    public List<Person> Employees;
    public int NumberOfVacancies { get => Employees.Count; }

    public Department(string Title)
    {
        this.Title = Title;
        Employees = new List<Person> { };
    }
    public virtual void StaffSelection(List<Person> candidates)
    {
        List<Person> tmp = new List<Person> { };
        foreach (var candidate in candidates)
            if (candidate.Score >= 3.0)
            {
                this.Employees.Add(candidate);
                Console.WriteLine($"Кандидат с именем {candidate.Name} успешно устроен.");
                tmp.Add(candidate);
            }
        foreach (var candidate in tmp)
        {
            candidates.Remove(candidate);
        }
    }
}

class ElectricianDepartment : Department
{
    public ElectricianDepartment(string Title) : base(Title) { }
    public override void StaffSelection(List<Person> candidates)
    {
        List<Person> tmp = new List<Person> { };
        foreach (var candidate in candidates)
            if (candidate.PersonSpeciality == Speciality.Electrician &&
            candidate.Score >= 4.5)
            {
                this.Employees.Add(candidate);
                Console.WriteLine($"Кандидат с именем {candidate.Name} успешно устроен в отдел электриков");
                tmp.Add(candidate);
            }
        foreach (var candidate in tmp)
        {
            candidates.Remove(candidate);
        }
    }
}
class MechanicDepartment : Department
{
    public MechanicDepartment(string Title) : base(Title) { }
    public override void StaffSelection(List<Person> candidates)
    {
        List<Person> tmp = new List<Person> { };
        foreach (var candidate in candidates)
            if (candidate.PersonSpeciality == Speciality.Mechanic &&
            candidate.Score >= 4.0 && candidate.Age <= 35)
            {
                this.Employees.Add(candidate);
                Console.WriteLine($"Кандидат с именем {candidate.Name} успешно устроен в отдел механиков.");
                tmp.Add(candidate);
            }
        foreach (var candidate in tmp)
        {
            candidates.Remove(candidate);
        }
    }
}
class InformDepartment : Department
{
    public InformDepartment(string Title) : base(Title) { }

    public override void StaffSelection(List<Person> candidates)
    {
        List<Person> tmp = new List<Person> { };
        foreach (var candidate in candidates)
            if ((candidate.PersonSpeciality == Speciality.Mathematitian || candidate.PersonSpeciality == Speciality.Programmer) &&
            candidate.Score >= 4.8 && candidate.Age >= 22)
            {
                this.Employees.Add(candidate);
                Console.WriteLine($"Кандидат с именем {candidate.Name} успешно устроен в отдел информатиков.");
                tmp.Add(candidate);
            }
        foreach (var candidate in tmp)
        {
            candidates.Remove(candidate);
        }
    }
}