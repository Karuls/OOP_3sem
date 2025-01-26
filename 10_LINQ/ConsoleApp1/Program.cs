using System;
using System.Text.RegularExpressions;
using System.Text;
partial class Programm
{
    static public void Main(string[] args)
    {
        string[] task1 = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var task_1 = task1.Where(n => n.Length > 5).Select(n => n);

        var task_2 = task1.Take(2).Skip(3).Take(3).Skip(3).Take(1).Select(n => n);

        var task_3 = from p in task1
                     orderby p
                     select p;

        var task_4 = task1.Where( n=> n.Contains("u")).Where(n => n.Length >= 4).Select(n => n);  
       
        foreach ( var tas in task_4)
        {
           Console.WriteLine(tas);
        }

        List<Set> list = new List<Set>();
        list.Add(new Set(12,  "Березовка", 15, 270000));
        list.Add(new Set(2,   "Лида",      3,   14000));
        list.Add(new Set(321, "Щучин",     7,   90000));
        list.Add(new Set(153, "Белогрудо", 22, 410000));
        list.Add(new Set(145, "Гродно",    1,    2500));
        list.Add(new Set(95,  "Дитва",     5,   65000));
        list.Add(new Set(85,  "Дубчаны",   2,   27000));
        list.Add(new Set(40,  "Березовка", 10, 100000));
        list.Add(new Set(36,  "Минск",     20, 240000));
        list.Add(new Set(94,  "Лида",      18, 310000));

         List<Set> list1 = (from p in list
                           where p.Marshrut.Equals("Березовка")
                           select p).ToList();//1

        List<Set> list2 = (list.Where(n => n.WorkTime > 10).Select(n => n)).ToList(); //2

        int minCountKM = list.Min(obj => obj.Count_KM);
        Set BusMinKM = list.FirstOrDefault(n => n.Count_KM == minCountKM);


        List<Set> BusMaxKM_2 = list.OrderByDescending(w => w.Count_KM).Take(2).ToList();

        List<Set> Ordered_list = (from p in list
                                  orderby p.BusNumber
                                  select p).ToList();
        //Задание 4
        List<Set> Exersice4 = list.OrderBy(n => n.WorkTime).Skip(1).Take(6).Where(n => n.Marshrut.StartsWith("Л") || n.Marshrut.StartsWith("Д")).Select(n => n).ToList();

        //Задание 5
        Ex5[] guys =
        {
            new Ex5(18, 100, "Лида"),
            new Ex5(25, 78, "Барановичи"),
            new Ex5(32, 55, "Афганистан"),
            new Ex5(55, 122, "Березовка"),
            new Ex5(20, 0, "Дитва")
        };
        var Exersice5 = from l in list
                        join t in guys on l.Marshrut equals t.Town
                        select new { Age = t.Age, IQ = t.IQ , Town = l.Marshrut};
        Console.WriteLine();
       

       
       
    }  
}