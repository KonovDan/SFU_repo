Console.Write("\nВведите количество чисел: ");
int n = Convert.ToInt32(Console.ReadLine());

int[] a = new int[n];
int m = 0, index = 0;

for (int i = 0; i < n; i++)
{
    Console.Write($"Введите число №{i + 1}: ");
    a[i] = Convert.ToInt32(Console.ReadLine());
    if (a[i] > m)
    {
        m = a[i];
        index = i;
    }
}


if (index == 0)
{
    for (int i = index + 1; i < a.Length; i++) a[i - 1] = a[i];

}
else if (index == a.Length - 1) {}
else { for (int i = index; i < a.Length - 1; i++) a[i] = a[i + 1]; }

a[a.Length - 1] = m;

for (int i = 0; i < n; i++) Console.Write(a[i]);
Console.WriteLine();
Console.ReadKey();