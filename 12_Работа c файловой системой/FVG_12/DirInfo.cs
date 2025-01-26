using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


 public static class FVGDirInfo
 {
 
     public static void DirManager()
     {
        Console.Write("Введите путь к директорию: ");
        string path = Console.ReadLine();
        int key = 0;
        Console.WriteLine("Выберите действие \n 1 - Количестве файлов директория  \n 2 -  Время создания директория  \n 3 - Количестве поддиректориев директория \n 4 - Список родительских директориев директория  \n 9 - выход");
        key = int.Parse(Console.ReadLine());
        do
        {
            switch(key)
            {

             case 1:
                    FVGLog.File_Write($"Вывод информации о Количестве файлов директория ");
                    foreach (var file in Directory.GetFiles(path))
                    {
                        Console.WriteLine($"{file}");
                    }
                    break;

             case 2:
                    FVGLog.File_Write($"Вывод информации о времени создвния директория ");
                    Console.WriteLine(Directory.GetCreationTime(path));break;

             case 3:
                    FVGLog.File_Write($"Вывод информации о Количестве поддиректориев директория ");
                    foreach (var dir in Directory.GetDirectories(path))
                    {
                        Console.WriteLine($"{dir}");
                    }
                    break;
             case 4:
                    FVGLog.File_Write($"Вывод информации о корне директория ");
                    Console.WriteLine(Directory.GetParent(path));break;

             case 9: return;

            }
            Console.WriteLine("Выберите действие \n 1 - Количестве файлов директория  \n 2 -  Время создания директория  \n 3 - Количестве поддиректориев директория \n 4 - Список родительских директориев директория  \n 9 - выход");
            key = int.Parse(Console.ReadLine());

        }while (key != 9);
    }




}

