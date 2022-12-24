class Program
{
    public static void Main()
    {

        Factory fact = new();
        fact.ProducePhones(10);
        fact.Customers.Add(new Customer("Петя", 60));
        fact.Customers.Add(new Customer("Коля", 30));
        fact.Customers.Add(new Customer("Саня", 100));

        ShowStatistics(fact);

        fact.SaleSmartphone();

        ShowStatistics(fact);

    }



    private static void ShowStatistics(Factory factory)
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
            Console.WriteLine("#" + smartphone.SerialNumber + " : " + smartphone.Sensor.Sensetivity);
        }
        Console.WriteLine();
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////
class TactileSensor
{
    public byte Sensetivity { get; init; }
    public TactileSensor()
    {
        this.Sensetivity = (byte)new Random().Next(0, 100);
    }
}

class GentleSmartphone
{
    public static int AbsoluteSerialNumber { get; set; } = 0;
    public int SerialNumber { get; init; }
    public TactileSensor Sensor { get; init; }

    public GentleSmartphone()
    {
        this.SerialNumber = GentleSmartphone.AbsoluteSerialNumber;
        GentleSmartphone.AbsoluteSerialNumber += 1;
        this.Sensor = new TactileSensor();
    }

}

enum TransformatorType
{
    Multipier,
    Divider
}

class Transformator
{
    static public int AbsoluteSerialNumber { get; set; } = 0;
    public int SerialNumber { get; init; }
    public TransformatorType TransformType { get; init; }

    public Transformator(TransformatorType TransformType)
    {
        this.SerialNumber = Transformator.AbsoluteSerialNumber;
        Transformator.AbsoluteSerialNumber += 1;
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
    public List<GentleSmartphone> Smartphones { get;} = new List<GentleSmartphone> { };
    public List<Customer> Customers { get;} = new List<Customer> { };

    public Factory()
    {

    }

    public void SaleSmartphone()
    {
        if (this.Customers == null || this.Smartphones == null) return;


        foreach (Customer customer in this.Customers)
        {
            foreach (GentleSmartphone smartphone in this.Smartphones)
            {

                if ((float)customer.GentleRate > (float)smartphone.Sensor.Sensetivity / 1.5 &&
                customer.GentleRate < smartphone.Sensor.Sensetivity * 2)
                {
                    customer.Smartphone = smartphone;

                    this.Smartphones.Remove(smartphone);
                    break;
                }
                if ((float)customer.GentleRate * 2 > (float)smartphone.Sensor.Sensetivity / 1.5 &&
                customer.GentleRate * 2 < smartphone.Sensor.Sensetivity * 2)
                {
                    customer.TransformModule = new Transformator(TransformatorType.Multipier);
                    customer.Smartphone = smartphone;

                    this.Smartphones.Remove(smartphone);
                    break;
                }
                if ((float)customer.GentleRate / 2 > (float)smartphone.Sensor.Sensetivity / 1.5 &&
                (float)customer.GentleRate / 2 < smartphone.Sensor.Sensetivity * 2)
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

    public void ProducePhones(int numberOfSmartphonesToProduce)
    {
        for (int i = 0; i < numberOfSmartphonesToProduce; i++)
        {
            GentleSmartphone smartphone = new();
            this.Smartphones.Add(smartphone);
        }
    }
}