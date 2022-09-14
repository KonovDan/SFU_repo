Console.WriteLine("Введите число N");
int N = Convert.ToInt32(Console.ReadLine());
int sum = 0, sumSq = 0;
for (int i = 1; i < N; i++)
{
    sum += i;
    sumSq += (int) Math.Pow(i, 2);
    if (sumSq > 500) {
        break;
    }
}
Console.WriteLine($"Сумма чисел: {sum}\nСумма квадратов: {sumSq}");
Console.ReadKey();

