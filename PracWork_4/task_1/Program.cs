const int N = 10;

List<int> a = new List<int> {};
for (int i = 0; i < N; i++) a.Add(new Random().Next() % 100);

void f1(List<int> lst)
{
    int i = 0;
    foreach (int c in lst) i++;
    Console.WriteLine($"Number of elements: {i}\nMin: {lst.Min()}\nMax: {lst.Max()}");
    Console.WriteLine(f2(lst.Min(), lst.Max()));
}

double f2(double a, double b) { return a * b; }

f1(a);
Console.ReadKey();