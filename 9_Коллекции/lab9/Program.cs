using System.Collections;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

public class Servis
{

    public string Name;
    public int Users;

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

public class Www : IList<Servis>
{

    ConcurrentDictionary<int, Servis> Koni = new ConcurrentDictionary<int, Servis>();
    public Servis this[int index]
    {
        get => Koni[index];
        set => Koni[index] = value;
    }
    public int Count => Koni.Count;

    public bool IsReadOnly => false;

    public void Add(Servis item)
    {
        int key = Koni.Count;
        Koni.TryAdd(key,item);
     }

    public void Clear()
    {
        if (Koni.Count > 0) { Koni.Clear(); }
    }

    public bool Contains(Servis item)
    {
        foreach(var x in Koni)
        {
            if(x.Value.Equals(item)) return true;
        }
        return false;
    }

    public void CopyTo(Servis[] array, int arrayIndex)
    {
        int i = arrayIndex;
        foreach (var x in Koni)
        {
            array[i++] = x.Value;
        }
    }

    public IEnumerator<Servis> GetEnumerator()
    {
        return Koni.Values.GetEnumerator();  // Получаем перечислитель для значений в ConcurrentDictionary
    }

    public int IndexOf(Servis item)
    {
        int i = 0;
        foreach (var x in Koni)
        {
            if (x.Value == item) return i;
            ++i;
        }
        return -1;
        
    }

    public void Insert(int index, Servis item)
    {
        Koni[index] = item;
    }

    public bool Remove(Servis item)
    {
        foreach (var x in Koni)
        {
            if (item.Equals(x.Value))
            {
                Koni.TryRemove(x.Key, out _);
                return true;
            }
        }
        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Koni.Count)
        {
            Console.WriteLine("Недопустимый индекс");
            return;
        }

        
        var key = Koni.Keys.ElementAt(index);

        
        if (Koni.TryRemove(key, out _))
        {
            Console.WriteLine($"Элемент {index} удален");
        }
        else
        {
            Console.WriteLine("Элемент не удален");
        }
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


public class Programm
{
    public static void Main(string[] args)
    {
        Servis i1 = new Servis("Сервис 1", 1000);
        Servis i2 = new Servis("Сервис 2", 2400);
        Servis i3 = new Servis("Сервис 3", 3300);

        IList<Servis> class_temp = new Www();
        class_temp.Add(i1);
        class_temp.Add(i2);
        class_temp.Add(i3);

        
        foreach (var service in class_temp)
        {
            service.Info();
        }

        Console.WriteLine(class_temp.Contains(i2) ? "Сервис 2 найден" : "Сервис 2 не найден");
        class_temp.Remove(i2);

        Console.WriteLine(class_temp.Contains(i2) ? "Сервис 2 найден" : "Сервис 2 не найден");

        class_temp.RemoveAt(0);
        Console.WriteLine(class_temp.Contains(i1) ? "Сервис 1 найден" : "Сервис 1 не найден");
        Console.WriteLine(class_temp.Contains(i3) ? "Сервис 3 найден" : "Сервис 3 не найден");
        // Задание 2 ------------------>
        Exercise2<int,string>.TEST_Execise();


    }
}
class Exercise2<T, V> 
{
    ConcurrentDictionary<T?, V?> Ex2 = new ConcurrentDictionary<T?, V?>();
    public void  Add(T key, V value)
    {
        Ex2.TryAdd(key, value);
    }

    public void PrintInfo()
    {
        foreach(var x in Ex2)
        {
            Console.WriteLine($"{x.Key} : {x.Value}");
        }
    }

    public void Delete_N_elems(int count){

        foreach (var item in Ex2)
        {
            if(count > 0)
            {
                Ex2.TryRemove(item.Key, out _);
                count--;
            }
            else
            {
                return;
            }
           
        }
    }


    static public void TEST_Execise()
    {
        Exercise2<int, string> TmpClass1 = new Exercise2<int, string>();
        TmpClass1.Add(1, "AAA");
        TmpClass1.Add(2, "BBB");
        TmpClass1.Add(3, "CCC");
        TmpClass1.Add(4, "DDD");
        TmpClass1.Add(5, "III");

        TmpClass1.PrintInfo();
        Console.WriteLine();
        TmpClass1.Delete_N_elems(3);
        TmpClass1.PrintInfo();

        List<string> values = new List<string>();
        
        foreach(var x in TmpClass1.Ex2)
        {
            values.Add(x.Value);
        }

        Console.WriteLine(values.Contains("III") ? "Элемент найден" : "Элемент не найден");
        TEST_Execise3();
    }


    static void TEST_Execise3()
    {
        ObservableCollection<Servis> exersice3 = new ObservableCollection<Servis>();
        exersice3.CollectionChanged += Some_method;
        Servis i1 = new Servis("Сервис 1", 1000);
        Servis i2 = new Servis("Сервис 2", 2400);
        exersice3.Add(i1);
        exersice3.Add(i2);
        exersice3.Remove(i1);



    }

    static public void Some_method(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if(e.Action == NotifyCollectionChangedAction.Add)
        {
            Console.WriteLine("Событие: Добавление элемента");
        }

        if(e.Action == NotifyCollectionChangedAction.Remove)
        {
            Console.WriteLine($"Событие: Удаление элемента {(char)2}");
        }
        
        
    }

    


}
    
