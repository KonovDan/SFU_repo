
bool check(string passwd) {
    bool c1 = false;
    bool c2 = false;
    bool c3 = false;
    bool c4 = false;

    foreach(char c in passwd) foreach(char i in "abcdefghijklmnopqrstuvwxyz") if (c == i) {c1 = true; break;}
    foreach(char c in passwd) foreach(char i in "ABCDEFGHIJKLMNOPQRSTUVWXYZ") if (c == i) {c2 = true; break;}
    foreach(char c in passwd) foreach(char i in "0123456789") if (c == i) {c3 = true; break;}
    foreach(char c in passwd) foreach(char i in "!@#$%^&*()\":;/.,\\<>^~`") if (c == i) {c4 = true; break;}

    return c1 && c2 && c3 && c4 && passwd.Length >= 6 && passwd.Length <= 12;
}

string passwd = "";
do {
    Console.WriteLine("Введите пороль");
    passwd = Console.ReadLine();
}
while (!check(passwd));
Console.WriteLine("Пороль подходит");
Console.ReadKey();