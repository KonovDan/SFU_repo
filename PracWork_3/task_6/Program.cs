Console.Write("Введите R: "); int R = Convert.ToInt32(Console.ReadLine());




int[,] dots = new int[12,2];
int n = 0;

for (int i = 0; i < 12; i++)
{
    Console.Write($"Введите X для точки №{i + 1}: "); dots[i,0] = Convert.ToInt32(Console.ReadLine());
    Console.Write($"Введите Y для точки №{i + 1}: "); dots[i,1] = Convert.ToInt32(Console.ReadLine());

    int dx = Math.Abs(dots[i,0]);
    int dy = Math.Abs(dots[i,1]);

    double r = Math.Sqrt(Math.Pow((double) dx, 2.0) + Math.Pow((double) dy, 2.0));
    if (r <= 2 * R) {Console.WriteLine("Пересекает!"); n++;}
}
Console.ReadKey();

