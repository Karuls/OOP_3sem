public class Set
{
    public int BusNumber;
    public string Marshrut;
    public int WorkTime;
    public int Count_KM;

    public Set(int busNumber, string marshrut, int workTime, int count_KM)
    {
        BusNumber = busNumber;
        Marshrut = marshrut;
        WorkTime = workTime;
        Count_KM = count_KM;
    }

}

public class Ex5
{
    public int Age;
    public int IQ;
    public string Town; 

    public Ex5(int age, int iQ, string town)
    {
        Age = age;
        IQ = iQ;
        Town = town;
    }
}






















































partial class Programm
{
    static public void ErrorMessage()
    {
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
        Console.WriteLine("\n");

       //Console.ForegroundColor = ConsoleColor.Blue;


        for (int row = 0; row < word.Length; row++)
        {
            string line = word[row];
            int spacesToPad = (Console.WindowWidth - line.Length) / 2;

            Console.SetCursorPosition(spacesToPad, Console.CursorTop);
            foreach (char c in line)
            {
                Console.Write(c);

            }
            Thread.Sleep(80);
            Console.WriteLine();
        }



        //-------------------------------------------------------------------
        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(400);
        int linesToClear = word.Length + 1;
        for (int i = 0; i < linesToClear; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1); // Поднимаемся на строку вверх
            Console.Write(new string(' ', Console.WindowWidth)); // Очищаем строку пробелами
            Console.SetCursorPosition(1, Console.CursorTop);     // Возвращаемся в начало строки
        }
    }

    static public void Error()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        ErrorMessage();
        Console.SetCursorPosition(1, Console.CursorTop - 1);
        Console.ForegroundColor = ConsoleColor.Red;
        ErrorMessage();
        Console.SetCursorPosition(1, Console.CursorTop - 1);
    }

}

