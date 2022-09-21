Console.Write("\nВведите R: "); int R = Convert.ToInt32(Console.ReadLine());

double[,] dots = new double[12, 2];
int n = 0;

for (int i = 0; i < 12; i++)
{
    Console.Write($"Введите X для точки №{i + 1}: "); dots[i, 0] = Convert.ToDouble(Console.ReadLine());
    Console.Write($"Введите Y для точки №{i + 1}: "); dots[i, 1] = Convert.ToDouble(Console.ReadLine());

    double dx = Math.Abs(dots[i, 0]);
    double dy = Math.Abs(dots[i, 1]);

    double r = Math.Sqrt(Math.Pow((double)dx, 2.0) + Math.Pow((double)dy, 2.0));
    if (r <= 2 * R) { Console.WriteLine("Пересекает!"); n++; }
}
Console.ReadKey();

