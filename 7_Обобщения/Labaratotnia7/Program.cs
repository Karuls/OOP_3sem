using System;
using System.ComponentModel;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
public class PASSWORD
{
    public string Google_password;
    public string Telegram_password;
    private string[] passwords_mass;
    public PASSWORD(string pass1, string pass2)
    {
        Google_password = pass1.length();
        Telegram_password = pass2.length();
    }
    public PASSWORD()
    {
        string[] passwords_mass = new string[5];
    }
    public PASSWORD(string pass1)
    {

        Google_password = pass1;
    }

    //---->
    public string this[int index]
    {
        get
        {
            if ((index > 0) && (index < passwords_mass.Length))
            {
                return passwords_mass[index];
            }
            else
            {
                return "Некорректный индекс";
            }
        }

        set
        {
            if ((index > 0) && (index < passwords_mass.Length))
            {
                passwords_mass[index] = value;
            }
            else
            {
                Console.WriteLine("Некорректный индекс");

            }
        }
    }
    //----->

    public static bool operator !=(PASSWORD c1, PASSWORD c2)
    {
        return (c1.Telegram_password != c2.Telegram_password && c1.Google_password != c2.Google_password);
    }

    public static bool operator ==(PASSWORD c1, PASSWORD c2)
    {
        return (c1.Telegram_password == c2.Telegram_password && c1.Google_password == c2.Google_password);
    }

    public static PASSWORD operator --(PASSWORD c1)
    {
        c1.Google_password = c1.Google_password.Substring(0, c1.Google_password.Length - 1);
        c1.Telegram_password = c1.Telegram_password.Substring(0, c1.Telegram_password.Length - 1);
        return c1;
    }

    public static PASSWORD operator ++(PASSWORD p)
    {
        p.Google_password = "";
        p.Telegram_password = "";
        return p;
    }

    public static bool operator >(PASSWORD p1, PASSWORD p2)
    {
        return (p1.Telegram_password.Length > p2.Telegram_password.Length && p1.Google_password.Length > p2.Google_password.Length);
    }

    public static bool operator <(PASSWORD p1, PASSWORD p2)
    {
        return (p1.Telegram_password.Length < p2.Telegram_password.Length && p1.Google_password.Length < p2.Google_password.Length);
    }
    //-------------------> secondTasck
    public class Production
    {
        public int ID;
        public string Compani_name;

        public Production()
        {
            ID = 0;
            Compani_name = "Alone";
        }

    }

   


    static class StatisticOperation
    {
        public static string passwords_sum(PASSWORD p)
        {
            string n = $"{p.Telegram_password} {p.Google_password}";
            return n;
        }

        public static int different(PASSWORD p)
        {
            int n = Math.Abs(p.Telegram_password.Length - p.Google_password.Length);
            return n;
        }

        public static int count_elements(PASSWORD p)
        {
            int n = Math.Abs(p.Telegram_password.Length + p.Google_password.Length);
            return n;
        }


    }

}

public static class NewObjectFunction
{
    public static int length_(this string password)
    {
        if (password.Length > 12 || password.Length < 6)
        {
            Console.WriteLine($"Недопустимый пароль\nВаша длинна строки: {password.Length}");
            return 0;
        }
        return 1;
    }
    public static string length(this string password)
    {

        int valid;
        do
        {
            if (NewObjectFunction.length_(password) == 1) { return password; }
            else
            {
                Console.WriteLine("Введите пароль: ");
                password = Console.ReadLine();
                valid = 0;
            }
        } while (valid == 0);
        return password;
    }


    public static void mid_symbol(this PASSWORD password)
    {

        Console.WriteLine($"Средний символ певрого пароля: {password.Telegram_password.Length / 2}");
        Console.WriteLine($"Средний символ второго пароля: {password.Google_password.Length / 2}");

    }

    public static int Count_A(this string password)
    {
        int count = 0;
        for (int i = 0; i < password.Length; i++)
        {
            if (password[i] == 'a' || password[i] == 'A')
            {
                count++;
            }
        }
        return count;
    }


}

public class Developer<T, V> : Ilab<T> where V : T
{
    
    public T ID;
    public V code;
    public string sector_name;
    public static List<T> elements;

    public Developer(T iD, V code, string sector_name)
    {
        ID = iD;
        this.code = code;
        this.sector_name = sector_name;
    }

    static Developer()
    {
        elements = new List<T>(); 
    }
    public static void Add(T value)
    {
        elements.Add(value);
    }

    public static void Remove(T value)
    {
        elements.Remove(value);
    }

    public static void CheckAll()
    {
        foreach (var x in elements)
        {
            Console.WriteLine(x);
        }
    }
     public static void AddFile<T>(T value)
    {
        File.AppendAllText("Q:\\2 Курс\\ООП\\7_Обощения\\Labaratotnia7\\C.txt", value.ToString() + Environment.NewLine);
    }
 
    public static void ReadFile(){
        string[] lines = File.ReadAllLines("Q:\\2 Курс\\ООП\\7_Обощения\\Labaratotnia7\\C.txt");
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }


}

class Program
{
    public static void Main(string[] args)
    {
        string password;

        //PASSWORD passwords1 = new PASSWORD("qeegre");
        //PASSWORD passwords2 = new PASSWORD("qwerrrr", "fghregg");
        //Console.WriteLine(passwords1.Google_password);
        //
        //PASSWORD password_mass = new PASSWORD();
        //password_mass[0] = "examplePassword1";
        //password_mass[1] = "examplePassword2";
        //PASSWORD.Mid_symbol(password);
        //String s1 = "AwwwA a w";
        //Console.WriteLine(s1.Count_A());
        //PASSWORD passwords11 = new PASSWORD("vwwwwm", "kopeichka");
        //PASSWORD passwords22 = new PASSWORD("vadimmm", "kopeichka");
        //bool key = passwords11 != passwords22;

        //passwords11.mid_symbol();

        //Console.WriteLine(key.ToString());
        //Console.WriteLine(passwords11.Telegram_password + passwords11.Google_password);
        //passwords11--;
        //Console.WriteLine(passwords11.Telegram_password + passwords11.Google_password);
        //passwords11++;
        //if (passwords11.Telegram_password != "")
        //{
        //    Console.WriteLine(passwords11.Telegram_password + passwords11.Google_password);
        //}
        //else { Console.WriteLine("чисто"); }

        try
        {
            Developer<int, int> dev1 = new Developer<int, int>(44, 33, "3");
            Developer<string, string> dev2 = new Developer<string, string>("444", "V : T", "Finance");

            Developer<int,int>.elements.Add(13);
            Developer<string,string>.elements.Add("fff");
            Developer<char,char>.elements.Add('L');

            
            

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Developer<int, int>.CheckAll();
            Developer<string, string>.CheckAll();
            Developer<char, char>.CheckAll();

            Figure figure = new Figure();
            Figure figure1 = new Figure(44, 44);
            Developer<Figure, Figure>.elements.Add(figure);
            Developer<Figure, Figure>.AddFile(figure);
            Developer<Figure, Figure>.AddFile(figure1);
            Developer<Figure, Figure>.ReadFile();
            
        }
        




    }
}

public interface Ilab<T>
{

    public static void Add(T value) { }
    public static void Remove(T value) { }
    public static void CheckAll() 
    {
        
    }

}

class Figure
{
    public int width;
    public int height;
    public Figure()
    {
        width = 10;
        height = 10;
    }
    public Figure(int w, int h)
    {
        width = w;
        height = h;
    }
    public void Sqare( int x, int y)
    {
        Console.WriteLine(x * y);
    }
    public void Write()
    {
        Console.WriteLine("Фигура!");
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {this.width}, {this.height}";
    }
}