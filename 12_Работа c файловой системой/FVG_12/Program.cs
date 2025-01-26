public class Programm
{
    public static void Main(string[] args)
    {
        
        

        int key = 0;
        do
        {
            Console.WriteLine("Выберите действие" +
            "\n 1 - Работа с Log.txt" +
            "\n 2 - Работа с Дисковой сиситемой" +
            "\n 3 - Работа с конкретным файлом" +
            "\n 4 - Работа с конкретным директорием" +
            "\n 5 - Работа с FVGFileManager ");
            key = int.Parse(Console.ReadLine());
            switch(key)
            {
                case 1: 
                    FVGLog.File_Manager(); break;
                case 2
                : FVGDickInfo.Dick_Manager(); break;  
                case 3:
                    FVGFileInfo.FileInfo(); break;
                case 4:
                    FVGDirInfo.DirManager(); break;
                case 5:
                    FVFFileManager.File_Manager_EX5(); break;
                default: Console.WriteLine("Такого варианта нету...");break;
                case 9: return;
            }
            
        }while (key != 9);



    }
}