using Set_partial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
class Set
{
    public string Name;
    public int Age;
    private int Code;
    private static Set example;
    public readonly int ID = 0;
    public const int con = 22;
    static int object_counter = 0;
    private string Pr_Name;
    private int Pr_age;
    //
    public Set(string name, int age)
    {
        Name = name;
        Age = age;
        ID = age + 22;
        Console.Write($" {name} {age}  ");
        Getinfo(ref object_counter);
        
    }
    public Set(string name = "vadim")
    {
        Name = name;
        Getinfo(ref object_counter);
        Console.Write($" {name} "); ;
    }
    public Set()
    {
        Getinfo(ref object_counter);
        Name = "www";
        Age = 12;
        Console.Write($" {Name} {Age}  "); ;
    }
    //1
    static Set()
    {
        
        Console.WriteLine("Конструктор запущен...");
        Getinfo(ref object_counter);
    }
    //2
    private Set(string name, int age, int code)
    {
        Getinfo(ref object_counter);
        Name = name;
        Age = age;
        Code = code;
    }

    public static Set GetExample()
    {

        if (example == null)
        {
            example = new Set("www", 22, 652526);
        }
        return example;
    }
    //3
  
    public string Pub_Name
    {
        get { return Pr_Name; }
        set { Pr_Name = value; }
    }
    public int Pub_age
    {
        get { return Pr_age; }
        set
        {
            if (value >= 18)
            {
                Pr_age = value;
            }
            else { Pr_age = value + 10; }
        }


    }
    //4
    public static void GetExample_ref_out(ref int ref_value, out string out_value)
    {
        out_value = "OUT";
        ref_value = 52;

    }
    public static void Getinfo(ref int object_counter)
    {
        object_counter += 1;
        Console.WriteLine($"Колличество созданных объектов = {object_counter}");
    }
    //----------------->
    public override bool Equals(object obj)
    {
        if (obj is Set other)
        {
            return Name == other.Name && Age == other.Age; 
        }
        return false;
    }

    public override int GetHashCode()
    {
        // Используем свойства, которые участвуют в сравнении
        return (Name, Age).GetHashCode();
    }

}
class programm
{
    static void Main(String[] args)
    {
           Set set1 = new Set("ff", 11);
        //    Set set2 = new Set("ff", 11);
        //    Set set3 = set1;

        //    Console.WriteLine(set1.Equals(set2)); // true (значения одинаковы)
        //    Console.WriteLine(set1.Equals(set3)); // true (ссылаются на один и тот же объект)
        //    Console.WriteLine(set1.GetHashCode() == set2.GetHashCode()); // true (хэш-коды совпадают)

        //    Set[] sets = new Set[4];

        //    // Инициализация объектов
        //    sets[0] = new Set("Alice", 30);
        //    sets[1] = new Set("Bob", 25);
        //    sets[2] = new Set("Charlie", 35);
        //    sets[3] = new Set("Ani", 30);

        //    // Вывод информации об объектах
        //    foreach (Set set in sets)
        //    {
        //        Console.WriteLine(set.ToString); // Использует метод ToString
        //    }
        //    Set set4 = new Set();
        //    Set set5 = Set.GetExample();
        //    Set Pr_set = new Set();
        //    Pr_set.Pub_age = 2;
        //    Console.WriteLine(Pr_set.Pub_age);
        //    Set.GetExample_ref_out(ref set1.Age, out set2.Name);
        //}

        second_main.sec_main();
    }
}



class MASS
{
    public string Name;
    public int Age;
    public int Course;
    public static int index = 0;  // Поле должно быть статическим, чтобы отслеживать количество объектов
    const int MAX_SIZE = 10;

    // Массив объектов MASS
    static MASS[] arr = new MASS[MAX_SIZE];

    // Конструктор
    public MASS(string name, int age, int course)
    {
        Name = name;
        Age = age;
        Course = course;
        Getinfo(ref index);
    }

    // Метод для вывода информации
    public static void Getinfo(ref int index)
    {
        index += 1;
        Console.WriteLine($" Количество созданных объектов = {index}");
    }

    // Метод для добавления объекта в массив
    public static void AddElem(MASS obj)
    {
        if (index < MAX_SIZE)
        {
            arr[index] = obj;
            Console.WriteLine($"Объект добавлен в массив на позицию {index}");
        }
        else
        {
            Console.WriteLine("Массив заполнен");
        }
    }

    // Метод для вывода всех элементов массива
    public static void PrintAll()
    {
        Console.WriteLine("Элементы массива:");
        for (int i = 0; i < index+1; i++)
        {
            if (arr[i] != null){
                Console.WriteLine($"Имя: {arr[i].Name}, Возраст: {arr[i].Age}, Курс: {arr[i].Course}");
             }
        }
    }
    public static void Delete_Elem(int i){
        if (index >= 0 && index < arr.Length)
        {
            arr[index] = null;
            Console.WriteLine($"Объект на позиции {index} был удален.");
        }
        else
        {
            Console.WriteLine("Неверный индекс.");
        }
    }
    public static void Both(int first, int second)
    {
        if (arr[first] != null && arr[second] != null)
        {
            ValueTuple<string, int, int> mass = ("", 0, 0);
            if (arr[first].Name == arr[second].Name)
            {
                mass.Item1 = arr[first].Name;
            }
            if (arr[first].Age == arr[second].Age)
            {
                mass.Item2 = arr[first].Age;
            }
            if (arr[first].Course == arr[second].Course)
            {
                mass.Item3 = arr[first].Course;
            }
            Console.WriteLine($"{mass.Item1} {mass.Item2} {mass.Item3}");
        }
    }

    public static void Not_Both(int first, int second)
    {
        if (arr[first] != null && arr[second] != null)
        {
            ValueTuple<string, int, int> mass = ("", 0, 0);
            if (arr[first].Name != arr[second].Name)
            {
                mass.Item1 = arr[first].Name;
            }
            if (arr[first].Age != arr[second].Age)
            {
                mass.Item2 = arr[first].Age;
            }
            if (arr[first].Course != arr[second].Course)
            {
                mass.Item3 = arr[first].Course;
            }
            Console.WriteLine($"{mass.Item1} {mass.Item2} {mass.Item3}");
        }
    }

    public static void Print_Ziro(int x){
        if( x == 0)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != null) { 
                    if (arr[i].Age%2 != 0)
                {
                    Console.WriteLine($"{arr[i].Name} {arr[i].Age} {arr[i].Course}");
                }
                }
            }
        }
        else if( x == 1)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != null)
                {
                    if (arr[i].Age % 2 == 0)
                    {
                        Console.WriteLine($"{arr[i].Name} {arr[i].Age} {arr[i].Course}");
                    }
                }
            }
        }

    }

    public static void Smaller_Than_Ziro()
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null)
            {
                if (arr[i].Age < 0 || arr[i].Course < 0)
                {
                    Console.WriteLine($"{arr[i].Name} {arr[i].Age} {arr[i].Course}");
                }
            }
        }
    }

}

class second_main
{
    public static void sec_main()
    {
        int key = 0;

        do
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1 - Добавить элемент");
            Console.WriteLine("2 - Показать все элементы");
            Console.WriteLine("3 - Удалить элементы");
            Console.WriteLine("4 - Пересечение элементов");
            Console.WriteLine("5 - Разность множеств");
            Console.WriteLine("6 - Вывод множеств только с четными/нечетными элементами");
            Console.WriteLine("7  - Вывод множеств, содержащие отрицательные элементы");
            Console.WriteLine("0 - Выход");
            Console.Write("Выберите действие: ");

            key = int.Parse(Console.ReadLine());

            switch (key)
            {
                case 1:
                    {
                        // Создаем новый объект MASS и добавляем его в массив
                        Console.Write("Введите имя: ");
                        string name = Console.ReadLine();

                        Console.Write("Введите возраст: ");
                        int age = int.Parse(Console.ReadLine());

                        Console.Write("Введите курс: ");
                        int course = int.Parse(Console.ReadLine());

                        MASS newObj = new MASS(name, age, course);
                        MASS.AddElem(newObj);
                        break;
                    }
                case 2:
                    MASS.PrintAll();
                    break; 

                case 3:
                    Console.Write("Введите позицию : ");
                    int digit = int.Parse(Console.ReadLine());
                    MASS.Delete_Elem(digit);
                    break;
                
                case 4:
                    Console.Write("Пересечение каких элементов будем искать? : ");
                    Console.Write("Первый элемент: ");
                    int first = int.Parse(Console.ReadLine());
                    Console.Write("Второй элемент: ");
                    int second = int.Parse(Console.ReadLine());
                    MASS.Both(first, second);
                    break;

                case 5:
                    Console.Write("Пересечение каких элементов будем искать? : ");
                    Console.Write("Первый элемент: ");
                    int first_ = int.Parse(Console.ReadLine());
                    Console.Write("Второй элемент: ");
                    int second_ = int.Parse(Console.ReadLine());
                    MASS.Not_Both(first_, second_);
                    break;

                case 6:
                    Console.Write("с четными(1) или нечетными(0) элементами? ");
                    Console.Write("Ответ: ");
                    int x = int.Parse(Console.ReadLine());
                    MASS.Print_Ziro(x);
                    break;

                case 7:
                    MASS.Smaller_Than_Ziro();
                    break;


                case 0:
                    Console.WriteLine("Выход...");
                    break;
                default:
                    Console.WriteLine("Неверная команда.");
                    break;
            }

        } while (key != 0);
        // Создание анонимного типа
        var person = new { Name = "Alice", Age = 25 };

        // Доступ к свойствам
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
    }
}
