class Program
{
    public static void Main(string[] agrs)
    {
        SortingDepartment s = new SortingDepartment();
        s.produceItems(10);
        s.Check(s.StockItems);
        foreach (var item in s.StockItems)
        {
            Console.WriteLine($"{item} {item.IndexNumber}");
        }
        Console.WriteLine("==============");
        foreach (var item in s.ShopItems)
        {
            Console.WriteLine($"{item} {item.IndexNumber}");
        }
    }
}
/*---<Enums>---*/
enum ScreenType
{
    IPS,
    TN_film,
    OLED
}

/*---<Interfaces>---*/
interface IPear
{
    public bool IsPear { get; init; }
}
interface IUnbroken
{
    public bool IsUnbroken { get; init; }
}
interface IFake
{
    public bool IsFake { get; init; }
}
interface IItem
{
    public string IndexNumber { get; init; }
}


interface IScreen
{
    public ScreenType Screen { get; init; }
}

/*---<Classes>---*/

class Peripheral : IItem
{
    public string IndexNumber { get; init; }
    public bool IsGaming { get; init; }

    public Peripheral(string IndexNumber, bool IsGaming)
    {
        this.IndexNumber = IndexNumber;
        this.IsGaming = IsGaming;
    }
}

class TouchDevice : IItem, IScreen
{
    public string IndexNumber { get; init; }
    public ScreenType Screen { get; init; }

    public TouchDevice(string IndexNumber, ScreenType Screen)
    {
        this.IndexNumber = IndexNumber;
        this.Screen = Screen;
    }
}

class PC : IItem, IUnbroken
{
    public string IndexNumber { get; init; }
    public bool IsUnbroken { get; init; }

    public PC(string IndexNumber, bool IsUnbroken)
    {

        this.IndexNumber = IndexNumber;
        this.IsUnbroken = IsUnbroken;
    }
}

class Mouse : Peripheral
{
    public Mouse(string IndexNumber, bool IsGaming) : base(IndexNumber, IsGaming)
    {
    }
}

class Monitor : Peripheral, IScreen, IPear, IFake
{
    public ScreenType Screen { get; init; }
    public bool IsPear { get; init; }
    public bool IsFake { get; init; }
    public Monitor(string IndexNumber,
                    bool IsGaming,
                    ScreenType Screen,
                    bool IsPear,
                    bool IsFake) :
                                    base(IndexNumber, IsGaming)
    {

        this.IsGaming = IsGaming;
        this.Screen = Screen;
        this.IsPear = IsPear;
        this.IsFake = IsFake;
    }
}

class Keyboard : Peripheral, IUnbroken
{
    public bool IsUnbroken { get; init; }

    public Keyboard(string IndexNumber, bool IsGaming, bool IsUnbroken) :
        base(IndexNumber, IsGaming)
    {
        this.IsUnbroken = IsUnbroken;
    }
}

class Smartphone : TouchDevice, IPear, IUnbroken, IFake
{
    public bool IsPear { get; init; }
    public bool IsUnbroken { get; init; }
    public bool IsFake { get; init; }

    public Smartphone(string IndexNumber,
                        ScreenType Screen,
                        bool IsPear,
                        bool IsUnbroken,
                        bool IsFake) :
                                        base(IndexNumber, Screen)
    {
        this.IsPear = IsPear;
        this.IsUnbroken = IsUnbroken;
        this.IsFake = IsFake;
    }
}

class Tablet : TouchDevice, IFake
{
    public bool IsFake { get; init; }

    public Tablet(string IndexNumber,
                    ScreenType Screen,
                    bool IsFake) :
                                    base(IndexNumber, Screen)
    {
        this.IsFake = IsFake;
    }
}
class Monoblock : PC, IUnbroken
{
    public bool IsFake { get; init; }

    public Monoblock(string IndexNumber,
                        bool IsUnbroken,
                        bool IsFake) :
                                        base(IndexNumber, IsUnbroken)
    {
        this.IsFake = IsFake;
    }
}
class Disposable : IItem
{
    public string IndexNumber { get; init; }
    public Disposable(string IndexNumber)
    {
        this.IndexNumber = IndexNumber;
    }
}
class SortingDepartment
{
    private int NumberOfProducedItems = 0;
    public List<IItem> StockItems = new List<IItem> { };
    public List<IItem> ShopItems = new List<IItem> { };
    public SortingDepartment() { }
    public void Check(List<IItem> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            IItem item = list[i];
            switch (Convert.ToString(item.GetType()))
            {
                case "Mouse":
                    {
                        if (!this.ShopItems.Contains(item)) this.ShopItems.Add(item);
                    }
                    break;
                case "Monitor":
                    {
                        Monitor _item = (Monitor)item;
                        if (_item.IsPear) if (_item.Screen != ScreenType.TN_film)
                                if (!_item.IsFake)
                                    if (!this.ShopItems.Contains(_item)) this.ShopItems.Add(_item);
                    }
                    break;
                case "Keyboard":
                    {
                        Keyboard _item = (Keyboard)item;
                        if (_item.IsUnbroken)
                            if (!this.ShopItems.Contains(_item)) this.ShopItems.Add(_item);
                    }
                    break;
                case "Smartphone":
                    {
                        Smartphone _item = (Smartphone)item;
                        if (_item.IsPear) if (_item.Screen != ScreenType.TN_film)
                                if (_item.IsUnbroken)
                                    if (!_item.IsFake)
                                        if (!this.ShopItems.Contains(_item)) this.ShopItems.Add(_item);
                    }
                    break;
                case "Tablet":
                    {
                        Tablet _item = (Tablet)item;
                        if (!_item.IsFake)
                            if (!this.ShopItems.Contains(_item)) this.ShopItems.Add(_item);
                    }
                    break;
                case "Monoblock":
                    {
                        Monoblock _item = (Monoblock)item;
                        if (_item.IsUnbroken)
                            if (!_item.IsFake)
                                if (!this.ShopItems.Contains(_item)) this.ShopItems.Add(_item);
                    }
                    break;
            }
        }
    }
    public void produceItems(int MaxRandom)
    {
        for (int i = 0; i < MaxRandom; i++)
        {
            this.StockItems.Add(new Mouse(Convert.ToString(this.NumberOfProducedItems),
            new Random().Next(2) == 1 ? true : false));
            this.NumberOfProducedItems++;
        }
        for (int i = 0; i < MaxRandom; i++)
        {
            this.StockItems.Add(new Monitor(Convert.ToString(NumberOfProducedItems),
                                            new Random().Next(0, 2) == 1 ? true : false,
                                            (ScreenType)new Random().Next(0, 2),
                                            new Random().Next(0, 2) == 1 ? true : false,
                                            new Random().Next(0, 2) == 1 ? true : false));
            this.NumberOfProducedItems++;
        }
        for (int i = 0; i < MaxRandom; i++)
        {
            this.StockItems.Add(new Keyboard(Convert.ToString(NumberOfProducedItems),
                                            new Random().Next(0, 2) == 1 ? true : false,
                                            new Random().Next(0, 2) == 1 ? true : false));
            this.NumberOfProducedItems++;
        }
        for (int i = 0; i < MaxRandom; i++)
        {
            this.StockItems.Add(new Smartphone(Convert.ToString(NumberOfProducedItems),
                                            (ScreenType)new Random().Next(0, 2),
                                            new Random().Next(0, 2) == 1 ? true : false,
                                            new Random().Next(0, 2) == 1 ? true : false,
                                            new Random().Next(0, 2) == 1 ? true : false));
            this.NumberOfProducedItems++;
        }
        for (int i = 0; i < MaxRandom; i++)
        {
            this.StockItems.Add(new Tablet(Convert.ToString(NumberOfProducedItems),
                                            (ScreenType)new Random().Next(0, 2),
                                            new Random().Next(0, 2) == 1 ? true : false));
            this.NumberOfProducedItems++;
        }
        for (int i = 0; i < MaxRandom; i++)
        {
            this.StockItems.Add(new Monoblock(Convert.ToString(NumberOfProducedItems),
                                            new Random().Next(0, 2) == 1 ? true : false,
                                            new Random().Next(0, 2) == 1 ? true : false));
            this.NumberOfProducedItems++;
        }
    }
}