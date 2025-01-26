using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


 static public class FVGDickInfo
{

    public static void Dick_Manager()
    {

        int key = 0;
        Console.WriteLine("Выберите действие \n 1 - Свободное место да дисках  \n 2 -  Файловая система  \n 3 - Все инфо о дисках \n 9 - выход");
        key = int.Parse(Console.ReadLine());
        do
        {

            switch (key)
            {
                case 1:
                    FVGLog.File_Write($"Вывод свободного места на дисках: ");
                    FVGDickInfo.FreeSpace(); break;
                    
                case 2:
                    FVGLog.File_Write($"Вывод свободного места на дисках: ");
                    FVGDickInfo.FileSystem(); break;
                case 3:
                    FVGLog.File_Write($"Все инфо о дисках: ");
                    FVGDickInfo.DisksInfo(); break;
                case 9: return;

            }
            Console.WriteLine("Выберите действие \n 1 - запись в файл  \n 2 - чтение из файла  \n 3 - поиск информации");
            key = int.Parse(Console.ReadLine());

        } while (key != 9);


    }


    public static void FreeSpace()
    {
        var DiskList = DriveInfo.GetDrives();
        foreach (var Disk in DiskList)
        {
            Console.WriteLine($"{Disk.Name}  {Math.Round(Disk.TotalFreeSpace / 1_000_000_000.0),1} GB");
            FVGLog.File_Write($"{Disk.Name}  {Math.Round(Disk.TotalFreeSpace / 1_000_000_000.0),1} GB");
        }
    }

    public static void DisksInfo()
    {
        var DiskList = DriveInfo.GetDrives();
        foreach (var Disk in DiskList)
        {
            Console.WriteLine($"{Disk.Name}" + $" ({Disk.VolumeLabel}) " +
                $"Место на диске: {Math.Round(Disk.TotalFreeSpace / 1_000_000_000.0),1}/" +
                $"{Math.Round(Disk.TotalSize / 1_000_000_000.0),1} GB\n");

            FVGLog.File_Write($"{Disk.Name}" + $" ({Disk.VolumeLabel}) " +
                $"Место на диске: {Math.Round(Disk.TotalFreeSpace / 1_000_000_000.0),1}/" +
                $"{Math.Round(Disk.TotalSize / 1_000_000_000.0),1} GB\n");
        }
    }

    public static void FileSystem()
    {
        FVGLog.File_Write($"Вывод инфо о файловой системе: ");
        var DiskList = DriveInfo.GetDrives();
        Console.WriteLine("Выберите диск : ");
        int i = 1;
        foreach (var Disk in DiskList)
        {
            Console.WriteLine($"{Disk.Name} - {i}");
            i++;
        }

        int key = int.Parse(Console.ReadLine());

        do
        {
            switch(key)
            {
                case 1: var Files = Directory.GetFiles(DiskList[0].ToString());
                    var directores = Directory.GetDirectories(DiskList[0].ToString());
                    Console.WriteLine("Папки:");
                    foreach (var dir in directores)
                    {
                        Console.WriteLine(dir);
                    }
                    Console.WriteLine("Файлы:");
                    foreach (var File in Files)
                    {
                        Console.WriteLine(File);
                    }
                    break;
                  

                case 2:
                    var Files1 = Directory.GetFiles(DiskList[1].ToString());
                    var directores1 = Directory.GetDirectories(DiskList[1].ToString());
                    Console.WriteLine("Папки:");
                    foreach (var dir in directores1)
                    {
                        Console.WriteLine(dir);
                    }
                    Console.WriteLine("Файлы:");
                    foreach (var File in Files1)
                    {
                        Console.WriteLine(File);
                    }
                    break;

                case 3:
                    var Files2 = Directory.GetFiles(DiskList[0].ToString());
                    var directores2 = Directory.GetDirectories(DiskList[0].ToString());
                    Console.WriteLine("Папки:");
                    foreach (var dir in directores2)
                    {
                        Console.WriteLine(dir);
                    }
                    Console.WriteLine("Файлы:");
                    foreach (var File in Files2)
                    {
                        Console.WriteLine(File);
                    }
                    break;

                case 0: return;
                    
            }

            Console.WriteLine("Выберите диск : ");
            key = int.Parse(Console.ReadLine());

        } while (key != 0);
    }

     
}

