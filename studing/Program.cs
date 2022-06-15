
Console.WriteLine("Hello Word!!!");

Worker myWorkerDefault = new Worker();
Worker myWorkerInited = new Worker(96, "name");

myWorkerDefault.PrintData();

int requareMaxInt = 1;
Console.WriteLine($"Is '{myWorkerDefault}' list have values maxer '{requareMaxInt}': {myWorkerDefault.IsSomeMaxerOf(requareMaxInt)}");

BaseContainer requareMaxCont = new Cat();
Console.WriteLine($"Is '{myWorkerDefault}' list have values maxer '{requareMaxCont}': {myWorkerDefault.IsSomeMaxerOf(requareMaxCont)}");

Console.WriteLine("refilling data");
List<BaseContainer> container = new();
myWorkerDefault.ReFillData(11, "newData", container);

myWorkerDefault.PrintData();

Console.WriteLine("rendomig data");
myWorkerDefault.RandomData();

myWorkerDefault.PrintData();

Console.WriteLine($"Ages sum is: {myWorkerDefault.GetAgesSum()}");

abstract class BaseContainer
{
    public string? Name = "empty";
    public int Age = -1;

    protected void SetAge(int age)
    {
        Age = age;
    }

    public static bool operator >(BaseContainer b1, BaseContainer b2) { return b1.Age > b2.Age; }
    public static bool operator <(BaseContainer b1, BaseContainer b2) { return b1.Age < b2.Age; }

    //protected только для наследников
}

sealed class Empty : BaseContainer
{
    public static bool operator >(Empty b1, Empty b2) { return b1.Age > b2.Age; }
    public static bool operator <(Empty b1, Empty b2) { return b1.Age < b2.Age; }

    public Empty() { }
    public Empty(int age, string name)
    {
        Age = age;
        Name = name;
    }
}

sealed class Cat : BaseContainer
{
    public static bool operator >(Cat b1, Cat b2) { return b1.Age > b2.Age; }
    public static bool operator <(Cat b1, Cat b2) { return b1.Age < b2.Age; }

    public Cat() { }
    public Cat(int age, string name)
    {
        Age = age;
        Name = name;
    }
}

sealed class Dog : BaseContainer
{
    public static bool operator >(Dog b1, Dog b2) { return b1.Age > b2.Age; }
    public static bool operator <(Dog b1, Dog b2) { return b1.Age < b2.Age; }

    public Dog() { }
    public Dog(int age, string name)
    {
        Age = age;
        Name = name;
    }
}

sealed class Worker
{
    public float Value { get; }

    private int _valueOfSothing;
    private string _nameOfSomthing;

    private List<BaseContainer> _listOfSomthing;

    #region Constuctors
    public Worker()
    {
        //init default
        _valueOfSothing =  69;
        _nameOfSomthing = "69";

        _listOfSomthing = new List<BaseContainer>();

        _listOfSomthing.Add(new Cat());
        _listOfSomthing.Add(new Cat(50, "name"));
        _listOfSomthing.Add(new Dog());
        _listOfSomthing.Add(new Dog(69, "name"));        
    }

    public Worker(int value, string name)
    {
        _valueOfSothing = value;
        _nameOfSomthing = name;

        _listOfSomthing = new List<BaseContainer>();
    }

    public Worker(int value, string name, List<BaseContainer> cont1)
    {
        _valueOfSothing = value;
        _nameOfSomthing = name;

        _listOfSomthing = cont1;
    }
    #endregion

    public void PrintData()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("<----------------------------------->");
        Console.WriteLine($"| Name of some field: {_nameOfSomthing}");
        Console.WriteLine($"| Value of some field: {_valueOfSothing}");
        Console.WriteLine();

        foreach (var item in _listOfSomthing)
            Console.WriteLine($"| Type: {item}. Name: {item.Name}. Age: {item.Age}");

        Console.WriteLine("<____________________________________>");
        Console.WriteLine();
        Console.WriteLine();
    }

    public void ReFillData(int value, string name, List<BaseContainer> cont1)
    {
        _valueOfSothing = value;
        _nameOfSomthing = name;

        _listOfSomthing = cont1;
    }

    public void RandomData()
    {
        Random rand = new Random();

        _valueOfSothing = rand.Next(0, int.MaxValue);
        _nameOfSomthing = Convert.ToString(rand.Next(0, int.MaxValue));

        for (int i = 0; i < rand.Next(0, 10); i++)
        {
            _listOfSomthing.Add(
                new Empty(
                    rand.Next(0, int.MaxValue),
                    Convert.ToString(rand.Next(0, int.MaxValue))
                ));
        }
    }

    public void KeyboardData()
    {
        Random rand = new Random();

        Console.WriteLine("Enter valueOfSothing");
        _valueOfSothing = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter nameOfSomthing");
        _nameOfSomthing = Console.ReadLine();

        foreach (var item in _listOfSomthing)
        {
            Console.WriteLine("Enter age of smt");
            item.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter name of smt");
            item.Name = Console.ReadLine();
        }
    }

    public bool IsSomeMaxerOf(int requaredAge)
    {
        BaseContainer newMax = new Empty();

        foreach (var item in _listOfSomthing)
        {
            if (item.Age > requaredAge)
            {
                return true;
            }
        }

        return false;
    }

    public bool IsSomeMaxerOf(BaseContainer requaredAge)
    {
        foreach (var item in _listOfSomthing)
        {
            if (item > requaredAge)
            {
                return true;
            }
        }

        return false;
    }

    public BaseContainer GetMax()
    {
        int max = int.MinValue;

        foreach (var item in _listOfSomthing)
        {
            if (max > item.Age)
                item.Age = max;
        }

        foreach (var item in _listOfSomthing)
        {
            if (item.Age == max)
                return item;
        }

        return new Empty();
    }

    public BaseContainer GetSomething(int age, string name)
    {
        foreach (var item in _listOfSomthing)
        {
            if(item.Age == age && item.Name == name)
            {
                return item;
            }
        }

        return new Empty();
    }

    public int GetAgesSum()
    {
        int i = 0;

        foreach (var item in _listOfSomthing)
            i += item.Age;

        return i;
    }
}

