class Program
{
    private const int numberOfSmartphonesToProduce = 2;
    public static void Main(string[] args)
    {

        Factory fact = new Factory(producePhones());
        fact.Customers.Add(new Customer("Петя", 60));
        fact.Customers.Add(new Customer("Коля", 30));
        fact.Customers.Add(new Customer("Саня", 100));
        showStatistics(fact);

        fact.SaleSmartphone();

        showStatistics(fact);

    }

    private static List<GentleSmartphone> producePhones()
    {
        List<GentleSmartphone> smartphones = new List<GentleSmartphone> { };
        for (int i = 0; i < numberOfSmartphonesToProduce; i++)
        {
            GentleSmartphone smartphone = new GentleSmartphone();
            smartphones.Add(smartphone);
        }
        return smartphones;
    }

    private static void showStatistics(Factory factory)
    {
        if (factory.Customers == null || factory.Smartphones == null) return;
        Console.WriteLine("Покупатели:");
        Console.WriteLine("Name    Sens    Tran    Smart#");
        foreach (Customer customer in factory.Customers)
        {
            string line = customer.FullName + "    " + customer.GentleRate;
            if (customer.TransformModule != null) line += "    " + customer.TransformModule.TransformType + " ";
            else line += "          ";
            if (customer.Smartphone != null) line += "\t" + customer.Smartphone.SerialNumber;
            Console.WriteLine(line);
        }
        Console.WriteLine();
        Console.WriteLine("Смартфоны на складе:");
        foreach (GentleSmartphone smartphone in factory.Smartphones)
        {
            Console.WriteLine("#" + smartphone.SerialNumber + " : " + smartphone.sensor.sensetivity);
        }
        Console.WriteLine();
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////
class TactileSensor
{
    public byte sensetivity { get; init; }
    public TactileSensor()
    {
        this.sensetivity = (byte)new Random().Next(0, 100);
    }
}

class GentleSmartphone
{
    public static int _SerialNumber { get; set; } = 0;
    public int SerialNumber { get; init; }
    public TactileSensor sensor { get; init; }

    public GentleSmartphone()
    {
        this.SerialNumber = GentleSmartphone._SerialNumber;
        GentleSmartphone._SerialNumber += 1;
        this.sensor = new TactileSensor();
    }

}

enum TransformatorType
{
    Multipier,
    Divider
}

class Transformator
{
    static public int _SerialNumber { get; set; } = 0;
    public int SerialNumber { get; init; }
    public TransformatorType TransformType { get; init; }

    public Transformator(TransformatorType TransformType)
    {
        this.SerialNumber = Transformator._SerialNumber;
        Transformator._SerialNumber += 1;
        this.TransformType = TransformType;
    }
}
class Customer
{
    public string FullName { get; init; }
    public byte GentleRate { get; init; }
    public GentleSmartphone? Smartphone { get; set; }
    public Transformator? TransformModule { get; set; }

    public Customer(string FullName, byte GentleRate)
    {
        this.FullName = FullName;
        this.GentleRate = GentleRate;
    }
}

class Factory
{
    public List<GentleSmartphone>? Smartphones { get; init; }
    public List<Customer> Customers { get; init; } = new List<Customer> { };

    public Factory(List<GentleSmartphone> Smartphones)
    {
        this.Smartphones = Smartphones;
    }

    public void SaleSmartphone()
    {
        if (this.Customers == null || this.Smartphones == null) return;
        int size = this.Customers.Count;

        foreach (Customer customer in this.Customers)
        {
            foreach (GentleSmartphone smartphone in this.Smartphones)
            {

                if ((float)customer.GentleRate > (float)smartphone.sensor.sensetivity / 1.5 &&
                customer.GentleRate < smartphone.sensor.sensetivity * 2)
                {
                    customer.Smartphone = smartphone;

                    this.Smartphones.Remove(smartphone);
                    break;
                }
                if ((float)customer.GentleRate * 2 > (float)smartphone.sensor.sensetivity / 1.5 &&
                customer.GentleRate * 2 < smartphone.sensor.sensetivity * 2)
                {
                    customer.TransformModule = new Transformator(TransformatorType.Multipier);
                    customer.Smartphone = smartphone;

                    this.Smartphones.Remove(smartphone);
                    break;
                }
                if ((float)customer.GentleRate / 2 > (float)smartphone.sensor.sensetivity / 1.5 &&
                (float)customer.GentleRate / 2 < smartphone.sensor.sensetivity * 2)
                {
                    customer.TransformModule = new Transformator(TransformatorType.Divider);
                    customer.Smartphone = smartphone;

                    this.Smartphones.Remove(smartphone);
                    break;
                }
            }
        }
        this.Smartphones.Clear();
    }
}