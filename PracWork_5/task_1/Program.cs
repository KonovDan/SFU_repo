

class StudentOfISIT
{
    private string _Name;
    private string _Speciality;
    private int _Check;
    private int _AScholarshipAmount;

    public string Name => _Name != null ? _Name  : "None";
    public string Speciality => _Speciality != null ? _Speciality  : "None";
    public int Check => _Check != 0 ? _Check  : 0;
    public int AScholarshipAmount => _AScholarshipAmount != 0 ? _AScholarshipAmount  : 0;
    private bool Warning { get; }
    public StudentOfISIT(string Name, string Speciality, int Check, int AScholarshipAmount)
    {
        this._Name = Name;
        this._Speciality = Speciality;
        this._Check = Check;
        this._AScholarshipAmount = AScholarshipAmount;
    }

    public void Get_AScholarship()
    {
        if (DateTime.Now.Day == 20) this._Check += this.AScholarshipAmount;
        else Console.WriteLine("Сегодня не 20 число!");
    }
    public void SpendAScholarship(int money, string itemOfExpenditure)
    {
        if (Check >= money)
        {
            this._Check -= money;
        }
        else { Console.WriteLine("Денег на счету нет!"); }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        StudentOfISIT student = null;
        bool f1 = true;
        
        while (f1)
        {

            Console.WriteLine("_____MENU_____\n1 Создать студента\n2 Получить данные студента\n3 Получить стпендию\n4 Потратить стипендию\n5 Проверить баланс\n6 Выйти");
            Console.Write("Введите число: ");
            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    {
                        Console.Write("Введите имя: "); string Name = Console.ReadLine();
                        Console.Write("Введите специальность: "); string Speciality = Console.ReadLine();
                        Console.Write("Введите сумму на счете: "); int Check = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите размер стипендии: "); int AScholarshipAmount = Convert.ToInt32(Console.ReadLine());
                        student = new StudentOfISIT(Name, Speciality, Check, AScholarshipAmount);
                    }
                    break;
                case "2":
                    {
                        if (student == null) continue;

                        Console.WriteLine("Имя: " + student.Name);
                        Console.WriteLine("Специальность: " + student.Speciality);
                        Console.WriteLine("Счет: " + student.Check);
                        Console.WriteLine("Стипендия: " + student.AScholarshipAmount);
                    }
                    break;
                case "3":
                    {
                        if (student == null) continue;

                        student.Get_AScholarship();
                    }
                    break;
                case "4":
                    {
                        if (student == null) continue;

                        Console.Write("Введите цену покупки: "); int money = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите объект покупки: "); string itemOfExpenditure = Console.ReadLine();
                        student.SpendAScholarship(money, itemOfExpenditure);
                    }
                    break;
                case "5":
                    {
                        if (student == null) continue;

                        Console.WriteLine("Баланс равен: " + student.Check);
                    }
                    break;
                case "6": { f1 = false; } break;
                default: break;
            }
        }
    }
}