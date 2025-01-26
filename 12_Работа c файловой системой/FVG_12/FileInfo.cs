using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class FVGFileInfo
    {
       
     public static void FileInfo()
    {

        Console.Write("Введите имя файла");
        string file_name = Console.ReadLine();
        Console.WriteLine();
        

        Console.Write("Введите путь: ");
        string file_path = Console.ReadLine();
        Console.WriteLine();


        int key = 0;
        Console.WriteLine("Выберите действие \n 1 -  Полный путь  \n 2 - Размер, расширение, имя  \n 3 - Дата создания, изменения  \n 9 - выход");
        key = int.Parse(Console.ReadLine());
        do
        {

            switch (key)
            {
                case 1:

                    FVGFileInfo.FileInfoA(file_path, file_name); break;
                case 2:
                    FVGFileInfo.FileInfoB(file_path, file_name); break;
                case 3:
                    FVGFileInfo.FileInfoC(file_path, file_name); break;
                case 9: return;

            }
            Console.WriteLine("Выберите действие \n 1 -  Полный путь  \n 2 - Размер, расширение, имя  \n 3 - Дата создания, изменения  \n 9 - выход");
            key = int.Parse(Console.ReadLine());

        } while (key != 9);

    }


    public static void FileInfoA(string path ,string filename) {
        Console.WriteLine($"Полный путь к {filename} -> {Directory.GetParent(path) + path}");
        FVGLog.File_Write($"Вывод полного пути к файлу {filename} ");
    }



    public static void FileInfoB(string path, string filename)
    {
        FVGLog.File_Write($"Вывод информации о файле {filename} ");
        FileInfo file = new FileInfo(path);
        Console.Write($"Размер: {file.Length} \n");
        Console.Write($"Раcширение: {file.Extension} \n");
        Console.Write($"Имя: {file.Name} \n");
    }


    public static void FileInfoC(string path, string filename)
    {
        FVGLog.File_Write($"Вывод информации о файле {filename} ");
        FileInfo file = new FileInfo(path);
        if(file.Exists)
        {
            Console.WriteLine($"Дата создания: {file.CreationTime}");
            Console.WriteLine($"Дата последнего изменения: {file.LastWriteTime}");
            Console.WriteLine($"Дата последнего доступа: {file.LastAccessTime}");
            Console.WriteLine($"Расширение: {file.Extension}");
        }
        else { Console.WriteLine("Такого файла нет"); }
        
    }

}

