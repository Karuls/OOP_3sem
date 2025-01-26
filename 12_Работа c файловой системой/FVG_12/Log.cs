using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;


static public class FVGLog
{
    public static string File_Create()
    {
        string path = @"Q:\2 Курс\ООП\12_Работа c файловой системой\FVG_12\FVGLog.txt";

        if (File.Exists(path)) {

            return path;

        }
        else {
            File.Create(path).Close();
            return path;
        }

        
    }
     public static void File_Manager() {

            int key = 0;
            Console.WriteLine("Выберите действие \n 1 - запись в файл  \n 2 - чтение из файла  \n 3 - поиск информации \n 9 - выход");
            key = int.Parse(Console.ReadLine());
        do
            {
         
            switch (key)
                {
                 case 1: 
                     string user_str = Console.ReadLine();
                     FVGLog.File_Write(user_str); break;
                 case 2:
                    int key_case;
                    Console.WriteLine("Выберите действие \n 1 - я за определенный  день \n 2 -  диапазон времени  \n 3 - по ключевому слову  \n 4 -   количество записей \n 5 - Оставить только записи за текущий час \n 9 - выход");
                    key_case = int.Parse(Console.ReadLine());
                    do
                    {
                        switch (key_case)
                        {
                            case 1:
                                Console.WriteLine("За какой именно? (пример 28.11.2024)");
                                string UserTime = Console.ReadLine();
                                string path = File_Create();
                                List<string> lines = File.ReadLines(path).ToList();
                                string temp = "";
                                foreach (string line in lines)
                                {
                                    if(line.Length > 10)
                                    {
                                     temp = line.Substring(line.Length - 10);
                                        if(temp == UserTime)
                                        {
                                            Console.WriteLine($"{line} \n");
                                        }
                                    }
                                    
                                    
                                }
                                break;
                            case 2:
                                Console.Write("За какой именно? (28.11.2024)" +
                                    "с ");
                                string UserTimeFrom = Console.ReadLine();
                                Console.Write("По");
                                string UserTimeTo = Console.ReadLine();
                                string path2 = File_Create();
                                List<string> lines2 = File.ReadLines(path2).ToList();
                                string temp2 = "";
                                foreach (string line in lines2)
                                {
                                    if (line.Length > 10)
                                    {
                                        temp = line.Substring(line.Length - 10);
                                        if (DateTime.TryParse(UserTimeFrom, out DateTime dateFrom) && DateTime.TryParse(UserTimeTo, out DateTime dateTo) && DateTime.TryParse(temp, out DateTime lineDate))
                                        {
                                            if (dateFrom <= lineDate && lineDate <= dateTo)
                                            {
                                                Console.WriteLine($"{line} \n");
                                            }
                                        }
                                    }


                                }


                                break;
                            case 3:
                                Console.WriteLine("Ключевое слово: ");
                                string found = Console.ReadLine();
                                FVGLog.File_Found(found);
                                break;
                            case 4:
                                Console.Write("Колличество записей : ");
                                string path4 = File_Create();
                                List<string> lines4 = File.ReadLines(path4).ToList();
                                Console.WriteLine(lines4.Count);
                                break;
                            case 5:
                                string UserTime5 = DateTime.Now.ToString("HH");

                                // Получаем текущую дату и время
                                DateTime currentTime = DateTime.Now;
                                DateTime lastHourStart = currentTime.AddHours(-1); 
                                DateTime lastHourEnd = currentTime; 

                                string path5 = File_Create(); 
                                List<string> lines5 = File.ReadLines(path5).ToList();

                                List<string> newList = new List<string>(); 
                                foreach (string line in lines5)
                                {
                                    if (line.Length > 10)
                                    {
                                  
                                        int timeStartIndex = line.IndexOf("Время: ") + "Время: ".Length;
                                        string time = line.Substring(timeStartIndex, 8);

                                        
                                        if (DateTime.TryParseExact(time, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime lineTime))
                                        {
                                            
                                            if (lineTime >= lastHourStart && lineTime <= lastHourEnd)
                                            {
                                                newList.Add(line); 
                                            }
                                        }
                                    }
                                }

                                File.WriteAllLines(path5, newList);
                                foreach (var entry in newList)
                                {
                                    Console.WriteLine(entry);
                                }
                                break;

                        }

                    } while (true); 
                    string user_str1 = Console.ReadLine();
                     FVGLog.File_Found(user_str1); break;
                 case 3:
                     FVGLog.File_Print(); break;
                    case 9: return;
            
            }
            Console.WriteLine("Выберите действие \n 1 - запись в файл  \n 2 - чтение из файла  \n 3 - поиск информации");
            key = int.Parse(Console.ReadLine());

        } while (true);
        

    }


    public static void File_Write(string user_str) {
        string path = File_Create();
        File.AppendAllText(path, "\n" + user_str + " Время: " + DateTime.Now.ToString("HH:mm:ss") + " Дата "  + DateTime.Now.ToString("dd.MM.yyyy"));
    }

    public static void File_Found(string user_str) {
        string path = File_Create();
       List<string> lines =  File.ReadLines(path).ToList();
        for(int i = 0; i < lines.Count; i++)
        {
            if (lines[i].Contains(user_str))
            {
                Console.WriteLine($"Есть такое, строка {i}\n" +
                    $"{lines[i]}");
            }
        }
       
    }

    public static void File_Print()
    {
        string path = File_Create();
        List<string> lines = File.ReadLines(path).ToList();
        Console.WriteLine("Содержимое файла...");
        foreach(string line in lines)
        {
           Console.WriteLine($"{line} \n");
        }

    }


}

