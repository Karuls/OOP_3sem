using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;


public static class FVFFileManager
{

public static void File_Manager_EX5()
    {
        string?[] files = { };
        bool flagForFiles = false;
        int key;
        do
        {
            Console.WriteLine("1 - создание директория\n 2 - копия файла \n 3 - Вывод файлов + запоминание(.exe)\n 4 - переместить файл\n 5 - архив \n 6 - Прочитать список файлов и папок заданного диска\n");
            key = int.Parse(Console.ReadLine());
            switch (key)
            {
                case 1:
                    Console.WriteLine("введите путь для создвния Директория");
                    string dirPath = Console.ReadLine();
                    Console.WriteLine("Имя Директория");
                    string dirName = Console.ReadLine();
                    Create_Directory(dirPath + "//" + dirName);
                    FVGLog.File_Write($"создание директория {dirPath}");
                    break;
                    
                case 2:
                    Console.WriteLine("1 файл(1) или сохраненный массив файлов?(2)" +
                        "Выбор:");
                    string path_ishod;
                    string path_copy ;
                    int key_case = int.Parse(Console.ReadLine());
                    switch (key_case)
                    {
                        case 1:
                            Console.WriteLine("Введите путь копируемого файла");
                            path_ishod = Console.ReadLine();
                            Console.WriteLine("введите путь для копирования файла");
                            path_copy = Console.ReadLine();
                            File.Copy(path_ishod, path_copy, true);
                            FVGLog.File_Write($"Копирование файла {path_ishod} в {path_copy}");
                            break;
                        case 2:
                            Console.WriteLine("введите путь для копирования файла");
                            path_copy = Console.ReadLine();
                            if (flagForFiles)
                            {
                                FVGLog.File_Write($"Копирование файлов");
                                foreach (var file in files)
                                {
                                  string filename = Path.GetFileName(file);
                                  string FullNameToCopy = Path.Combine(path_copy, filename);
                                    File.Copy(file, FullNameToCopy, true);
                                    FVGLog.File_Write($"{FullNameToCopy}");
                                }
                            }
                            break; 
                    }
                  
                    break;

                case 3:
                    Console.Write($"Абсолный путь:");
                    string user_string = Console.ReadLine();
                    Console.Write($"Расширение (png/exe ..):");
                    string expansion = Console.ReadLine();
                    files = Directory.GetFiles(user_string, $"*.{expansion}");
                    flagForFiles = true;
                    FVGLog.File_Write($"Копирование и сохранение файлов файлов");
                    foreach (var file in files)
                    {
                        Console.WriteLine($"{file}");
                        FVGLog.File_Write($"{file}");
                    }
                    break;

                case 5:
                    Console.WriteLine("Введите расположения файла для Zip-сжатия");
                    string FileForZip = Console.ReadLine();
                    string Zipfile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Path.GetFileName(FileForZip) + ".zip";
                    ZipFile.CreateFromDirectory(FileForZip, Zipfile);
                    FVGLog.File_Write($"Cоздание {Path.GetFileName(FileForZip) + ".zip"} в {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}");
                    Console.WriteLine($"{Path.GetFileName(FileForZip) + ".zip"} на рабочем столе");
                    Console.WriteLine("Куда разорхивировать?");
                    string PATH_OPEN_ZIP = Console.ReadLine();
                    ZipFile.ExtractToDirectory(Zipfile, PATH_OPEN_ZIP);
                    FVGLog.File_Write($"Распаковка {Path.GetFileName(FileForZip) + ".zip"} в {PATH_OPEN_ZIP}");
                    break;

                case 6:
                    ReadAllFiles();

                    break;
                case 9: return;
            }

        }while (key!=9);

    }

    public static void Create_Directory(string path)
    {
        DirectoryInfo directory = new DirectoryInfo(path);
        if (!directory.Exists) 
        {
            directory.Create();
            Console.WriteLine("Директорий создан");
        }
        else
        {
            Console.WriteLine("Директорий уже существует");
        }
    }

    public static void ReadAllFiles()
    {

        var DiskList = DriveInfo.GetDrives();
        Console.WriteLine("Файлы какого диска вывести?");
        int i = 1;
        foreach (var Disk in DiskList)
        {
            Console.WriteLine($"{Disk.Name} - {i}");
            i++;
        }
        int user_disk = int.Parse( Console.ReadLine() );
        var Files = Directory.GetFiles(DiskList[user_disk - 1].ToString());
        var directores = Directory.GetDirectories(DiskList[user_disk - 1].ToString());
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
        
    }
   


}
