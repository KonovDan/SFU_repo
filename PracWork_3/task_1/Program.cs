Console.Write("Угадайте число: ");
int n = Convert.ToInt32(Console.ReadLine());
int x = new Random().Next() % 10 + 1;
while (x != n) {
    if (x > n) {
        Console.WriteLine("Загаданное число больше");
    } else {
        Console.WriteLine("Загаданное число меньше");
    }
    n = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Отлично! Вы угадали!");
Console.ReadKey();