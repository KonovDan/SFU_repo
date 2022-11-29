/*--------------------------------------------------<Main>--------------------------------------------------*/
class Program
{
    public static void Main(string[] args)
    {
        List<Discipline> disciplines = new List<Discipline> {
            new MathematicalAnalysis(80),
            new History(90),
            new Programming(75)
        };

        List<Student> students = new List<Student>{
            new Student( "Антон",
                        new Dictionary<Discipline, int>{
                            {disciplines[0], 90},
                            {disciplines[1], 90}
                        },
                        new Dictionary<Discipline, int>{
                            {disciplines[1], 90},
                            {disciplines[2], 30}
                        }
            ),
            new Student( "Александр",
                        new Dictionary<Discipline, int>{
                            {disciplines[0], 90},
                            {disciplines[1], 90}
                        },
                        new Dictionary<Discipline, int>{
                            {disciplines[1], 90},
                            {disciplines[2], 30}
                        }
            ),
            new Student( "Михаил",
                        new Dictionary<Discipline, int>{
                            {disciplines[0], 90},
                            {disciplines[1], 90}
                        },
                        new Dictionary<Discipline, int>{
                            {disciplines[1], 90},
                            {disciplines[2], 30}
                        }
            )
        };

        foreach( Discipline discipline in disciplines)
        {
            Console.WriteLine($"{discipline.Name}: \n");
            foreach (Student student in students){
                if (discipline is IHaveAngryTeacher)
                {
                    Console.WriteLine("Этот препод не дает автоматов!");
                    break;
                }
                Console.WriteLine(discipline.Check(student));
            }
            Console.WriteLine();
        }
    }
}
/*--------------------------------------------------<Interfaces>--------------------------------------------------*/
interface IHaveAngryTeacher { }

interface IHaveFinalControll
{
    public int PassingScore { get; set; }
}

interface IHavePractice
{
    public int PracticeCount { get; set; }
}
/*--------------------------------------------------<Classes>--------------------------------------------------*/
abstract class Discipline
{
    public string Name { get; set; }
    public Discipline(string Name)
    {
        this.Name = Name;
    }
    public abstract string Check(Student student);
}

class Student
{
    public string Name;
    public Dictionary<Discipline, int> FinalControl;
    public Dictionary<Discipline, int> Practices;

    public Student(
                    string Name,
                    Dictionary<Discipline, int> FinalControl,
                    Dictionary<Discipline, int> Practices
                )
    {
        this.Name = Name;
        this.Practices = Practices;
        this.FinalControl = FinalControl;
    }
}

class MathematicalAnalysis : Discipline, IHaveFinalControll, IHaveAngryTeacher
{
    public int PassingScore { get; set; }
    public MathematicalAnalysis(int PassingScore) : base("MathematicalAnalysis")
    {
        this.PassingScore = PassingScore;
    }
    override public string Check(Student student)
    {
        if(student.FinalControl[this] >= this.PassingScore)
        return $"{student.Name} получает достаточный бал на итоговой аттестации и может расчитывать на автомат по математическому анализу";
        return $"{student.Name} не получает достаточный бал на итоговой аттестации и не может расчитывать на автомат по математическому анализу";
    }
}

class History : Discipline, IHaveFinalControll, IHavePractice
{
    public int PassingScore { get; set; }
    public int PracticeCount { get; set; }
    public History(int PassingScore) : base("History")
    {
        this.PassingScore = PassingScore;
        this.PracticeCount = PassingScore;
    }
    public History(int PassingScore, int PracticeCount) : base("History")
    {
        this.PassingScore = PassingScore;
        this.PracticeCount = PracticeCount;
    }
    override public string Check(Student student)
    {
        if(student.FinalControl[this] >= this.PassingScore)
        if(student.Practices[this] >= this.PracticeCount)
        return $"{student.Name} получает достаточный бал на итоговой аттестации и может расчитывать на автомат по истории";
        return $"{student.Name} не получает достаточный бал на итоговой аттестации и не может расчитывать на автомат по истории";
    }
}

class Programming : Discipline, IHavePractice
{
    public int PracticeCount { get; set; }
    public Programming(int PracticeCount) : base("Programming")
    {
        this.PracticeCount = PracticeCount;
    }
    override public string Check(Student student)
    {
        if(student.Practices[this] >= this.PracticeCount)
        return $"{student.Name} получает достаточный бал на итоговой аттестации и может расчитывать на автомат по программированию";
        return $"{student.Name} не получает достаточный бал на итоговой аттестации и не может расчитывать на автомат по программированию";
    }
}
/*--------------------------------------------------<End>--------------------------------------------------*/