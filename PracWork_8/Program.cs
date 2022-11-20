class Program
{
    private const int numberOfSmartphonesToProduce = 2;
    public static void Main(string[] args)
    {

        Factory fact = new Factory(producePhones());
        fact.Customers.Add(
            new Customer(
                "Петя",
                60,
                new Transformator(
                    0, TransformatorType.Multipier
                )
            )
        );
        fact.Customers.Add(
            new Customer(
                "Коля",
                30,
                new Transformator(
                    0, TransformatorType.Multipier
                )
            )
        );
        fact.Customers.Add(
            new Customer(
                "Саня",
                100,
                new Transformator(
                    0, TransformatorType.Divider
                )
            )
        );
        showStatistics(fact);

        fact.SaleSmartphone();

        showStatistics(fact);

    }

    private static List<GentleSmartphone> producePhones()
    {
        List<GentleSmartphone> smartphones = new List<GentleSmartphone> { };
        for (int i = 0; i < numberOfSmartphonesToProduce; i++)
        {
            TactileSensor sensor = new TactileSensor((byte)new Random().Next(0, 100));
            GentleSmartphone smartphone = new GentleSmartphone(i, sensor);
            smartphones.Add(smartphone);
        }
        return smartphones;
    }

    private static void showStatistics(Factory factory)
    {
        if (factory.Customers == null || factory.Smartphones == null) return;
        Console.WriteLine("Покупатели:");
        foreach (Customer customer in factory.Customers)
        {
            string line = customer.FullName + "    " + customer.GentleRate + "    " + customer.TransformModule.TransformType + "    ";
            if (customer.Smartphone != null) line +=customer.Smartphone.SerialNumber;
            Console.WriteLine(line);
        }
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
    public TactileSensor(byte sensetivity)
    {
        this.sensetivity = sensetivity;
    }
}

class GentleSmartphone
{
    public int SerialNumber { get; init; }
    public TactileSensor sensor { get; init; }

    public GentleSmartphone(int SerialNumber, TactileSensor sensor)
    {
        this.SerialNumber = SerialNumber;
        this.sensor = sensor;
    }

}

enum TransformatorType
{
    Multipier,
    Divider
}

class Transformator
{
    public int SerialNumber { get; init; }
    public TransformatorType TransformType { get; init; }

    public Transformator(int SerialNumber, TransformatorType TransformType)
    {
        this.SerialNumber = SerialNumber;
        this.TransformType = TransformType;
    }
}
class Customer
{
    public string FullName { get; init; }
    public byte GentleRate { get; init; }
    public GentleSmartphone? Smartphone { get; set; }
    public Transformator TransformModule { get; init; }

    public Customer(string FullName, byte GentleRate, Transformator TransformModule)
    {
        this.FullName = FullName;
        this.GentleRate = GentleRate;
        this.TransformModule = TransformModule;
    }
}

class Factory
{
    public List<GentleSmartphone>? Smartphones { get; init; } = new List<GentleSmartphone> { };
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
                    int customerFinalGentleRate = (int)(customer.GentleRate * (customer.TransformModule.TransformType == TransformatorType.Multipier ? 2 : 0.5));
                    if ((int)(customerFinalGentleRate / 1.5) >= smartphone.sensor.sensetivity ||
                    customerFinalGentleRate * 2 <= smartphone.sensor.sensetivity)
                    {
                        customer.Smartphone = smartphone;

                        this.Smartphones.Remove(smartphone);
                        break;
                    }
                }
            }
        
    }
}