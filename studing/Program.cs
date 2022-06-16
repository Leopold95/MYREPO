
Console.WriteLine("Hello Word!!!");

Worker MyWorker = new Worker(30);
//Console.WriteLine(MyWorker.ContSerBal(9));

//Student min = MyWorker.FoundMinAge();
//min.PrintConsole();

MyWorker.PrintStudents();
//MyWorker.SortStudentsByNameAndSurname();
//Console.WriteLine();
//Console.WriteLine();
//MyWorker.PrintStudents();

//Console.WriteLine(MyWorker.FountMinAgeInStudents());

MyWorker.CountMaleFemale();

class Worker
{
    private List<Student> _students;

    public Worker(int studentsCount)
    {
        _students = new();

        for (int i = 0; i < studentsCount; i++)
            _students.Add(Student.GenerateRandom());
        
    }

    public void SortStudentsByNameAndSurname()
    {
        var sorted = from student in _students
                     orderby student.Name, student.Age
                     select student;

        _students = sorted.ToList();
    }

    public Student FoundByName(string name)
    {
        foreach (var item in _students)
            if (item.Name == name)
                return item;

        return new Student();
    }

    public Student FoundBySurname(string surename)
    {
        foreach (var item in _students)
            if (item.Name == surename)
                return item;

        return new Student();
    }

    public Student FoundByAge(int age)
    {
        foreach (var item in _students)
            if (item.Age == age)
                return item;

        return new Student();
    }

    public int ContSerBal(int group)
    {
        List<Student> _newStudents = new();
        int serbalValue = 0;
        int serbalCount = 0;

        foreach (var item in _students)
            if (item.Group == group)
            {
                _newStudents.Add(item);
                serbalCount++;
                serbalValue += item.SerBal;
            }


        if (serbalCount == 0)
        {
            Console.WriteLine($"не найденно ниодного студента заданной ({group}) группы");
            return -1;
        }

        //возвращает посчитанный средний бал
        return serbalValue / serbalCount;
    }

    public void PrintStudents()
    {    
        foreach (var item in _students)
            item.PrintConsole();
    }

    public void KeyboardStudents()
    {
        foreach (var item in _students)
            item.FillKeybpard();
    }

    public Student FoundStudentWithMinAge()
    {
        int min = _students[0].Age;
        int both = 0;

        //comparing students
        foreach (var item in _students)
        {
            if (item.Age < min)
            {
                min = item.Age;
                continue;
            }
            else if (item.Age == min)
                both++;
        }

        Console.WriteLine($"Студентов с одним возростom: {both}");

        //hetting student
        foreach (var item in _students)
            if (item.Age == min)
                return item;

        return new Student();
    }

    public int FountMinAgeInStudents()
    {
        int min = _students[0].Age;

        foreach (var item in _students)
            if (item.Age < min)
                min = item.Age;

        return min;
    }

    public void CountMaleFemale()
    {
        int male = 0;
        int female = 0;

        foreach (var item in _students)
        {
            if (item.State is Male)
                male++;
            else
                female++;
        }

        Console.WriteLine($"Males: {male}");
        Console.WriteLine($"Females: {female}");
    }
}


class Student
{
    public string? Name;
    public string? Surename;
    public int Age;
    public DateTime BornTime;
    public State? State;
    public int Group;
    public int SerBal;

    public Student()
    {
        Name = "name";
        Surename = "surname";
        Age = 0;
        BornTime = DateTime.Now;
        State = new Male();
        Group = 0;
        SerBal = 0;
    }

    public Student(string name, string surname, int age, DateTime time, State state, int group, int serbal)
    {
        Name = name;
        Surename = surname;
        Age = age;
        BornTime = time;
        State = state;
        Group = group;
        SerBal = serbal;
    }

    public static Student GenerateRandom()
    {
        Student student = new Student();
        Random rand = new Random();

        student.Name = RandomName();
        student.Surename = RandomSurename();
        student.Age = rand.Next(16, 35);

        int year = rand.Next(1988, 2010);
        int month = rand.Next(1, 11);
        int day = rand.Next(1, 29);

        student.BornTime = new DateTime(year, month, day);

        student.State = RandomState();
        student.Group = rand.Next(0, 10);
        student.SerBal = rand.Next(40, 100);

        return student;
    }

    public void FillKeybpard()
    {
        Name = Console.ReadLine();
        Surename = Console.ReadLine();
        Age = Convert.ToInt32(Console.ReadLine());

        int year = Convert.ToInt32(Console.ReadLine());
        int month = Convert.ToInt32(Console.ReadLine());
        int day = Convert.ToInt32(Console.ReadLine());

        BornTime = new DateTime(year, month, day);

        State = new Male();
        Group = Convert.ToInt32(Console.ReadLine());
        SerBal = Convert.ToInt32(Console.ReadLine());
    }

    public void PrintConsole()
    {
        Console.WriteLine($"Имя: {Name} Фамилия: {Surename} Возраст: {Age}");
        Console.WriteLine($"Дата рождения: {BornTime}");
        Console.WriteLine($"Пол: {State}");
        Console.WriteLine($"Средний балл {SerBal}");
    }

    private static string RandomName()
    {
        Random randomiser = new();
        string[] names = { "NameOne", "NameTwo" };

        int rand = randomiser.Next(0, names.Length);

        return names[rand];
    }

    private static string RandomSurename()
    {
        Random randomiser = new();
        string[] names = { "SureNameOne", "SurenameTwo" };

        int rand = randomiser.Next(0, names.Length);

        return names[rand];
    }

    private static State RandomState()
    {
        Random r = new();
        int i = r.Next(-1, 2);
        if (i == 1)
            return new Male();
        else 
            return new Female();
    }
}

interface State
{
    State GetState();
}

class Male : State
{
    public State GetState()
    {
        return new Male();
    }
}

class Female : State
{
    public State GetState()
    {
        return new Female();
    }
}



