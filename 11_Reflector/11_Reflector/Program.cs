using System;
using System.Net.Http.Headers;
using System.Reflection;

static class Reflector
{

    public static string GetInfo_Assembly(this string tmp)
    {
        Type type = Type.GetType(tmp);
        Console.WriteLine($"Имя сборки: \n" + type.Assembly.FullName.ToString());
        return ("Имя сборки: \n" + type.Assembly.FullName.ToString());



    }

    public static string GetInfo_PublicKonstrycyots(this string tmp)
    {
        Type type = Type.GetType(tmp);
        ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        string finish_string = "Конструкторы: \n";
        foreach(var w in constructors)
        {
            finish_string += w.Name + "\n";
        }
        
        Console.WriteLine(finish_string);
        return finish_string;
    }

    public static string GetInfo_Methods(this string tmp)//t
    {
        Type type = Type.GetType(tmp);
        string w = "";

        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
        Console.WriteLine("Методы класса:");
        foreach (var method in methods)
        {
            w += method.Name + "\n";
            Console.WriteLine(method.Name);

        }

        return ("Методы: \n" + w + "\n");
    }

    public static string GetInfo_Fields(this string tmp)
    {
        Type type = Type.GetType(tmp);
        string finish_string = "Поля :\n";
        foreach(var field in type.GetFields())
        {
            finish_string += (field + "\n");
        }
        Console.WriteLine(finish_string);
        return finish_string;
    }

    public static string GetInfo_ReleasedInterfaces(this string tmp)
    {
        Type type = Type.GetType(tmp);
        string finish_string = "Интерфейсы :\n";
        foreach(var x in type.GetInterfaces())
        {

        }
        if(finish_string == "Интерфейсы :\n")
        {
            return "Реализованных интерфесов нету";
        }
        return finish_string;
    }

    public static string GetInfo_MethodsWithType(this string tmp, Type data_t)
    {
        Type type = Type.GetType(tmp);
        string finish_string = "";
        Console.WriteLine($"Методы класса c параметром типа {data_t}:");
        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
        {
            foreach (var x in method.GetParameters())
            {
                if (x.ParameterType == data_t)
                {
                    finish_string += method.Name;
                    Console.WriteLine($"{method.Name}");
                    break;
                }
            }

        }
        Console.WriteLine(finish_string);
        if (finish_string == "")
        {
            return ($"Методов с параметром {data_t} нету");
        }
        return $"\nМетоды с параметром {data_t}:\n {finish_string} " ;
    }

    public static void Invoke(string filePath = "Q:\\2 Курс\\ООП\\11_Reflector\\11_Reflector\\lab11.txt")
    {
        
        string[] lines = File.ReadAllLines(filePath);
        if (lines.Length < 2)
        {
            throw new InvalidOperationException("Файл должен содержать имя класса и метода.");
        }

        string className = lines[0];
        string methodName = lines[1]; 

        
        string[] parameterStrings = lines.Length > 2 ? lines.Skip(2).ToArray() : Array.Empty<string>();

        
        Type type = Type.GetType(className);
        if (type == null)
        {
            throw new InvalidOperationException($"Класс {className} не найден.");
        }

        
        object instance = Activator.CreateInstance(type);

        
        MethodInfo method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        if (method == null)
        {
            throw new InvalidOperationException($"Метод {methodName} не найден в классе {className}.");
        }

        
        ParameterInfo[] parameters = method.GetParameters();
        object[] methodParameters = new object[parameters.Length];

        
        for (int i = 0; i < parameters.Length; i++)
        {
            
            if (i < parameterStrings.Length)
            {
                methodParameters[i] = Convert.ChangeType(parameterStrings[i], parameters[i].ParameterType);
            }
            else
            {
                
                methodParameters[i] = GenerateValue(parameters[i].ParameterType);
            }
        }

        
        object result = method.Invoke(instance, methodParameters);
        if (result != null)
        {
            Console.WriteLine($"Результат вызова метода {methodName}: {result}");
        }
    }
    private static object GenerateValue(Type type)
    {
        if (type == typeof(int)) return 42;
        if (type == typeof(string)) return "DefaultString";
        if (type == typeof(double)) return 3.14;
        if (type == typeof(bool)) return true;

        // Для сложных типов рекурсивно создаем объект
        if (type.IsClass) return Activator.CreateInstance(type);

        throw new InvalidOperationException($"Не удалось сгенерировать значение для типа {type}");
    }

    public static T Create<T>(params object[] args)
    {
        Type type = typeof(T);
        ConstructorInfo constructor = type.GetConstructor(args.Select(a => a.GetType()).ToArray());

        if (constructor == null)
        {
            throw new InvalidOperationException($"Не найден подходящий конструктор для типа {typeof(T).Name}");
        }

        return (T)constructor.Invoke(args);
    }


}

class Prepod
{
    public string Name;
    public static int Mmm;
    public Prepod(string name)
    {
          Name = name;
    }

    public void Method1()
    {
        Console.WriteLine("Method1");
    }

    public void Method2()
    {
        Console.WriteLine("Method2");
    }

    public void Method3()
    {
        Console.WriteLine("Method3");
    }

    public string Method4(string x)
    {
        
        return $"Method3 {x}";
    }
    
     static public void Method5(object x, MyDelegate myDelegateб, string[] something)
    {
        Console.Write("www");
    }

    public delegate string MyDelegate(string x);

}

class Programm
{
    public static void Main(string[] args)
    {

        
        string filePath = @"Q:\2 Курс\ООП\11_Reflector\11_Reflector\11lab.txt";
        File.Create(filePath).Close();
        Prepod tmp = new Prepod("Барковкский топ 1 по квизу"); 
        string tmp1 = "Prepod";
        string Servic = "Servis";


        File.AppendAllText(filePath, "Prepod".GetInfo_Assembly());
        File.AppendAllText(filePath, tmp1.GetInfo_PublicKonstrycyots());
        File.AppendAllText(filePath, "Prepod".GetInfo_Methods()); 
        File.AppendAllText(filePath, "Prepod".GetInfo_Fields());
        File.AppendAllText(filePath, "Prepod".GetInfo_ReleasedInterfaces());
        File.AppendAllText(filePath, "Prepod".GetInfo_MethodsWithType(typeof(string)));


        "Reflector".GetInfo_Assembly();
        "Reflector".GetInfo_PublicKonstrycyots();
        "Reflector".GetInfo_Methods();
        "Reflector".GetInfo_Fields();
        "Reflector".GetInfo_ReleasedInterfaces();
        "Reflector".GetInfo_MethodsWithType(typeof(string));




        Console.WriteLine();

        Servic.GetInfo_Assembly();
        Servic.GetInfo_PublicKonstrycyots();
        Servic.GetInfo_Methods();
        Servic.GetInfo_Fields();
        Servic.GetInfo_ReleasedInterfaces();
        Servic.GetInfo_MethodsWithType(typeof(string));


        Prepod prepod1 = Reflector.Create<Prepod>("Иван Иванов");
        Reflector.Invoke();


    }
}




public class Servis
{

    public string Name;
    public int Users;

    public Servis() 
    {
    }
    public Servis(string name, int users)
    {
        Name = name;
        Users = users;
    }

    public void Info()
    {
        Console.WriteLine(Name + ": " + Users);
    }

}