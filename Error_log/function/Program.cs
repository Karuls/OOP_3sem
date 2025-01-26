public static class Programm
{
    public static void Main(string[] args)
    {
        FileManager.Create_Directory();
    }
}

public static class FileManager
{
    public static void Create_Directory()
    {
        
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


        string[] word = new string[]
         {
            "########     ########   ###########  ###########        #########  ",
            "##      ##   ##               ##     ##        ##     ##        ## ",
            "##      ##   ##             ##       ##        ##    ##        ##  ",
            "########     ######        ##        ##        ##   #############  ",
            "##           ##           ##         ##        ##   ##        ##   ",
            "##           ##          ##          ##        ##   ##        ##   ",
            "##           ########   ###########  ###########     ##        ##  "
         };




        // Цикл для создания 100 файлов

        for (int j = 0; j < 100; j++)
        {
            string directoryPath = Path.Combine(desktopPath, $"alicce{j}");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            for (int i = 0; i < 100; i++)
            {


                // Формируем путь к файлу
                string filePath = Path.Combine(directoryPath, $"alice{i}.txt");

                // Записываем текст в файл
                File.WriteAllText(filePath,
                    $"\"########     ########   ###########  ###########        #########  \"" +
                    $"" +
                    $"" +
                    $"" +
                    $"" +
                    $"");
            }


        }
       
    }
}
