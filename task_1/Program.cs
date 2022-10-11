

class StudentOfISIT
{
    public string Name;
    public string Speciality;
    public int Check;
    public int AScholarshipAmount;
    public StudentOfISIT(string Name, string Speciality, int Check, int AScholarshipAmount)
    {
        this.Name = Name;
        this.Speciality = Speciality;
        this.Check = Check;
        this.AScholarshipAmount = AScholarshipAmount;
    }
    public bool get_Warning()
    {
        return Check > 100 ? true : false;
    }

    public void GetAScholarship()
    {
        if (DateTime.Now.Day == 20) this.Check += AScholarshipAmount;
        else Console.WriteLine("Сегодная не 20 чисдо!");
    }
    public void SpendAScholarship(int money, string itemOfExpenditure)
    {
        if (Check >= money)
        {

        }
        else { Console.WriteLine("Денег на счету нет!"); }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        StudentOfISIT student = new StudentOfISIT("None", "None", 0, 0);
        bool f1 = true;
        while (f1 == true)
        {
            Console.Write("Введите число: ");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine(); string Name = Console.ReadLine();
                        Console.WriteLine(); string Speciality = Console.ReadLine();
                        Console.WriteLine(); int Check = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(); int AScholarshipAmount = Convert.ToInt32(Console.ReadLine());
                        student = new StudentOfISIT(Name, Speciality, Check, AScholarshipAmount);
                    }
                    break;
                case "2":
                    {
                        Console.WriteLine(student.Name);
                        Console.WriteLine(student.Speciality);
                        Console.WriteLine(student.Check);
                        Console.WriteLine(student.AScholarshipAmount);
                    }
                    break;
                case "3": { Console.WriteLine(student.AScholarshipAmount); } break;
                case "4":
                    {
                        Console.WriteLine(); int money = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(); string itemOfExpenditure = Console.ReadLine();
                        student.SpendAScholarship(money, itemOfExpenditure);
                    }
                    break;
                case "5": {Console.WriteLine(student.Check);} break;
                case "6": {f1 = false;} break;
            }
        }

    }
}