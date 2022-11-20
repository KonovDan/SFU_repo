
class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public Speciality PersonSpeciality { get; set; }
    public double Score { get; set; }
    public Person(string Name)
    {
        this.Name = Name;
        this.Age = new Random().Next(Program.minAge, Program.maxAge);
        PersonSpeciality = (Speciality)new Random().Next(0, 5);
        this.Score = ((double)new Random().Next((int)(Program.minScore * 10), (int)(Program.maxScore * 10))) / 10;
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
    public string PrintEmployees()
    {
        string result = "==Список сотрудников департамента " + this.Title + "==\n";
        foreach (var item in Employees)
        {
            result += item.Name + "\n";
        }
        result += "--------------";
        return result;
    }
}

class ElectricianDepartment : Department
{
    public ElectricianDepartment(string Title) : base(Title)
    {

    }
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

    new public string PrintEmployees()
    {
        string result = base.PrintEmployees();
        string[] subres = result.Split('\n');
        subres[0] += '\n';
        result = subres[0];
        int i = 0;
        foreach (var item in Employees)
        {
            i++;
            result += subres[i] + ' '  + item.Score + "\n";
        }

        return result;
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
    new public string PrintEmployees()
    {
        string result = base.PrintEmployees();
        string[] subres = result.Split('\n');
        subres[0] += '\n';
        result = subres[0];
        int i = 0;
        foreach (var item in Employees)
        {
            i++;
            result += subres[i] + ' ' + item.Score + ' ' + item.Age + "\n";
        }

        return result;
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

    new public string PrintEmployees()
    {
        string result = base.PrintEmployees();
        string[] subres = result.Split('\n');
        subres[0] += '\n';
        result = subres[0];
        int i = 0;
        foreach (var item in Employees)
        {
            i++;
            result += subres[i] + ' ' + item.Score + ' ' + item.Age + "\t" + item.PersonSpeciality + "\n";
        }

        return result;
    }
}