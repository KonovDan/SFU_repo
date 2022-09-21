Console.Write("\nВведите количество чисел: ");
int n = Convert.ToInt32(Console.ReadLine());

int[] a = new int[n];
int m = 0, index = 0;

for (int i = 0; i < n; i++) {
    Console.Write($"Введите число №{i + 1}: ");
    a[i] = Convert.ToInt32(Console.ReadLine());
    if (a[i] > m) {
        m = a[i];
        index = i;
    }
}

int tmp = a[n - 1];
a[n - 1] = a[index];
a[index] = tmp;


for (int i = 0; i < n; i++) Console.Write(a[i]);
Console.WriteLine();
Console.ReadKey();