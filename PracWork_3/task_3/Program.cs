void ex()
{
    Console.WriteLine("Отрицательные числа не допускаются!");
    Console.ReadKey();
    System.Environment.Exit(1);
}

Console.Write("\nВведите количество студентов: ");
int N = Convert.ToInt32(Console.ReadLine());
if (N < 0) ex();

int[] scores = new int[N];
int[] marks = new int[N];
for (int i = 0; i < N; i++)
{
    Console.Write($"Введите результат ученика №{i + 1}: ");
    int score = Convert.ToInt32(Console.ReadLine());
    if (score < 0) ex();
    scores[i] = score;
    if (score == 12 || score == 13) { marks[i] = 3; Console.WriteLine($"Ученик №{i + 1} получает 3"); continue; }
    if (score == 14 || score == 15) { marks[i] = 4; Console.WriteLine($"Ученик №{i + 1} получает 4"); continue; }
    if (score >= 16) { marks[i] = 5; Console.WriteLine($"Ученик №{i + 1} получает 5"); continue; }
    if (score < 12) { marks[i] = 2; Console.WriteLine($"У ученика №{i + 1} незачет!"); continue; }
}
Console.WriteLine($"Максимальное кол-во подятгиваний: {scores.Max()}");
Console.WriteLine($"Минимальное кол-во подятгиваний: {scores.Min()}");
return 0;

