Dictionary<string, double> lst = new Dictionary<string, double> { };
lst["Маша"] = 10000;
lst["Петя"] = 30000;
lst["Вася"] = 100000;

void main()
{

    Console.WriteLine("Введите имя");
    string name = Console.ReadLine();

    Console.WriteLine("Введите сумму");
    double sum = Convert.ToDouble(Console.ReadLine());

    foreach (string client_name in lst.Keys)
    {
        if (client_name == name)
        {
            lst[client_name] += sum;
            Console.WriteLine($"Благодарим, что вы стали клиетном нашего банка! {client_name}, Ваш баланс изменен! Текущий баланс {lst[client_name]} рублей.");
        
            Console.WriteLine($"Вы можете воспользоваться стандартным вкладом нашего банка! Вложив сумму остатка {lst[client_name]} на 3 года под 17% годовых Вы получите прибыль {count_profit(lst[client_name], 3, 0.17F)}. Для активации вклада войдите в мобильное приложение!");
        }
    }
    Console.ReadKey();
}

double count_profit(double sum, int years, double percentage) {
    return sum * Math.Pow(1+percentage, years) / 100;
}

main();