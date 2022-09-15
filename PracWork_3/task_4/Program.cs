Console.WriteLine("Введите A"); double A = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите B"); double B = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите C"); double C = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите D"); double D = Convert.ToDouble(Console.ReadLine());

double [] res = new double[10];
double sump = 0, sum = 0;

for (int x = 1; x <= 10; x++) {
    res[x-1] = A * Math.Sqrt(B * x + D) - C * x;
    if (res[x-1] > 0)  sump += res[x-1];
    sum += res[x-1];
}

Console.WriteLine($"Сумма положительных значений: {sump}");
Console.WriteLine($"Среднее значение: {(double) sum / 10}");
Console.ReadKey();

