Console.Write("\nУгадайте число: ");
int n = Convert.ToInt32(Console.ReadLine());
int x = new Random().Next() % 10 + 1;
int attampts = 1;
while (x != n) {
    attampts++;
    if (x > n) {
        Console.WriteLine("Загаданное число больше");
    } else {
        Console.WriteLine("Загаданное число меньше");
    }

    n = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine($"Отлично! Вы угадали c {attampts} попытки!");
Console.ReadKey();