using System.Reflection.Metadata;

public delegate void Exapple1(int x);
class Programm {
    static public void print_counts(int x)
    {
        for (int i = 0; i <= x; i++)
        {
            Console.Write(i);
        }
        Console.WriteLine();
    }

    static public void print_letters(int x)
    {
        for (int i = 0; i <= x; i++)
        {
            Console.Write((char)i);
        }
        Console.WriteLine();
    }
    public static void Main(String[] args)
    {
        Exapple1 ex1;
        ex1 = print_counts;
        ex1 += print_letters;
        ex1?.Invoke(6);
        //
        TestEvents temp = new TestEvents();
        Evi ev = new Evi();
        Leni leni = new Leni();
        temp.event_test += new Exapple2(ev.evi);
        temp.event_test += new Exapple2(leni.leni);
        temp.some_func();
        temp.event_test -= new Exapple2(leni.leni);
        temp.some_func();
        string www = ",hello.!!   ? world?";
        string input = ",hello world!  how are you?";


        Func<string, string> removePunctuation = work_with_str.Delete;

        Func<string, string> replaceSpacesWithHash = str => str.Replace(' ', '#');

        Func<string, string> toUpperCase = str => str.ToUpper();


        Func<string, string> removeExtraSpaces = work_with_str.Add_space;

        Func<string, string> duplicateCharacters = work_with_str.Add_symbol;

        Action<string> print_rez = str => Console.WriteLine($"Промежуточный результат: {str}");

        Predicate<string> isNotEmpty = str => !string.IsNullOrEmpty(str);

        Func<string, string> go_str = removePunctuation;
        go_str += replaceSpacesWithHash;
        go_str += toUpperCase;
        go_str += removeExtraSpaces;
        go_str += duplicateCharacters;


        string result = input;
        foreach (Func<string, string> func in go_str.GetInvocationList())
        {
            result = func(result);
            print_rez(result);
        }


        if (isNotEmpty(result))
        {
            Console.WriteLine($"Финальный результат: {result}");
        }
        else
        {
            Console.WriteLine("Результат пустой.");
        }
        //------------------------------->
        PO po1 = new PO("fortnite", 2014, 5000);
        PO po2 = new PO("Warhammer 40,000", 2011, 4000);
        PO po3 = new PO("CS:GO ", 2012, 3000);

        Programmer programmer = new Programmer();
        programmer.work += po1.work_po;
        programmer.work += po2.work_po;
        programmer.upgrade += po1.Create_new_version;
        programmer.upgrade += po2.Create_new_version;
        programmer.upgrade += po3.Create_new_version;
        programmer.installs += po1.add_installs;
        programmer.installs += po2.add_installs;
        programmer.installs += po3.add_installs;

        Console.WriteLine("Начала работы..");
        programmer.start_work();
        Console.WriteLine();

        Console.WriteLine("Разработка нового..");
        programmer.AddNewFunctions();
        Console.WriteLine();

        Console.WriteLine("До : ");
        Console.WriteLine($"{po1.name} -  {po1.installs} скачиваний");
        Console.WriteLine($"{po2.name} -  {po2.installs} скачиваний");
        Console.WriteLine($"{po3.name} -  {po3.installs} скачиваний");

        Console.WriteLine("Добавление скачиваний");
        programmer.Users_trigger();
        Console.WriteLine();

        Console.WriteLine("после : ");
        Console.WriteLine($"{po1.name} -  {po1.installs} скачиваний");
        Console.WriteLine($"{po2.name} -  {po2.installs} скачиваний");
        Console.WriteLine($"{po3.name} -  {po3.installs} скачиваний");

    }   
}


public delegate void Exapple2();
class TestEvents
{
    public event Exapple2 event_test;
    
    public void some_func()
    {
        Console.WriteLine("Запустили функцию экземпляра");
        event_test?.Invoke();
    }

}

public class Evi
{
    public void evi()
    {
        Console.WriteLine("evi");
    }
}

public class Leni
{
    public void leni()
    {
        Console.WriteLine("Leni");
    }
}

static public class work_with_str
{
   static public string Delete(this string str)
    {
        string new_str = "";
        foreach (var item in str)
        {
        if(item == ',' || item == '!' || item == '.' || item == '?')
            {
                continue;
            }
            else
            {
                new_str += item;
            }
        }
        return new_str;
    }


    static public string Add_symbol(this string str)
    {
        string new_str = "";
        foreach (var item in str)
        {
            if (item == ' ')
            {
                new_str += ((char)1);
            }
            else
            {
                new_str += item;
            }
        }

        return new_str;
    }

    static public string ToupperCase(this string str)
    {
        return str.ToUpper();
    }

    static public string Add_space(this string str)
    {
        string new_str = "";
        foreach (var item in str)
        {
                new_str += item;
            new_str += ' ';
        }

        return new_str;
    }

    static public string X2(this string str)
    {
        string new_str = "";
        foreach (var item in str)
        {
            new_str += item;
            new_str += item;
        }

        return new_str;
    }


}

public delegate void ProgrammerEvent(string message);
public class Programmer
{
    public event ProgrammerEvent upgrade;
    public event ProgrammerEvent work;
    public event ProgrammerEvent installs;

    public void AddNewFunctions()
    {
        upgrade?.Invoke("Снова обнова...");
    }

    public void start_work() {
        Console.ForegroundColor = ConsoleColor.Blue;
        work?.Invoke($"Разработчики что-то делают {(char)1}");
        Console.ResetColor();
    }

    public void Users_trigger()
    {
        installs?.Invoke("Пользователи заинтересовались игрой...");
    }
}

class PO
{
    public string name;
    public int year;
    public int installs;

    public PO(string name, int year, int installs)
    {
        this.name = name;
        this.year = year;
        this.installs = installs;
    }

    public void Create_new_version(string message)
    {
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Разработана новая версия {name} : ({year+1})");
        Console.ResetColor();
        year += 1; 
    }

    public void work_po(string message)
    {
        Console.WriteLine($"Working... {message} ({name})");
    }

    public void add_installs(string message)
    {
        Console.WriteLine(message);
        installs += 7000;
    }
}
 