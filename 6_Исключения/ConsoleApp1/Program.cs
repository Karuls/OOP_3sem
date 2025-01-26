using CustomExceptions;
using System;
using System.Diagnostics;
using System.Reflection;

namespace CustomExceptions
{
    // Базовый класс для всех пользовательских исключений
    public class CustomBaseException : Exception
    {
        public CustomBaseException() : base() { }
        public CustomBaseException(string message) : base(message) { }
        public CustomBaseException(string message, Exception innerException) : base(message, innerException) { }
    }

    // Исключение, связанное с диапазоном значений
    public class CustomRangeException : CustomBaseException
    {
        public CustomRangeException() : base("Произошла ошибка пользовательского диапазона") { }
        public CustomRangeException(string message) : base(message) { }
        public CustomRangeException(string message, Exception innerException) : base(message, innerException) { }
    }

    // Исключение, связанное с Делением на 0
    public class CustomDevisionException : CustomBaseException
    {
        public CustomDevisionException() : base("Ошибка деления на ноль!") { }
        public CustomDevisionException(string message) : base(message) { }
        public CustomDevisionException(string message, Exception innerException) : base(message, innerException) { }
    }

    // Исключение, связанное с выходом индекса за пределы массива
    public class CustomMassIndexException : CustomBaseException
    {
        public CustomMassIndexException() : base("Индекс за пределами массива.") { }
        public CustomMassIndexException(string message) : base(message) { }
        public CustomMassIndexException(string message, Exception innerException) : base(message, innerException) { }
    }
}

class Program


{

    static void FirstMethod()
    {
        try
        {
            SecondMethod();
        }
        catch (CustomExceptions.CustomDevisionException ex)
        {
            Console.WriteLine($"Первичная обработка в FirstMethod: {ex.Message}");
            // Повторный проброс вверх по стеку 
            throw;
        }
    }
    static void SecondMethod()
    {
        try
        {
            int x = 5;
            int y = 0;
            Button bbb1 = new Button(x / y, 5, "кнопка1");

        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Обработка деления на ноль в SecondMethod");
            // Пробрасываем исключение
            throw new CustomExceptions.CustomDevisionException("Ошибка деления на ноль в SecondMethod", ex);
        }
    }
    public static void Main(string[] args)
    {
        try
        {
            Debug.WriteLine("Программа начала выполнение");
            
            int[] mass = { 1, 2, 3 };
            int index = 5;
            Button bbb1 = new Button(mass[6],5,"кнопка2");
           
            Console.WriteLine(mass[index]);
        }
        catch (IndexOutOfRangeException ex)
        {
            
            Console.WriteLine($"Ошибка индекса массива: {ex.Message}");
            Console.WriteLine($"Место возникновения: {ex.StackTrace}");
            
        }
        catch(CustomExceptions.CustomMassIndexException ex) {
            Console.WriteLine($"Индекс находится за пределами массива");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Общая ошибка: {ex.Message}");
        }

        try
        {
            int x = 5;
            int y = 0;
            Button bbb1 = new Button(x / y, 5, "кнопка1");


        }
        catch (DivideByZeroException ex)
        {
            var customEx = new CustomExceptions.CustomDevisionException("Попытка деления на ноль", ex);
            Console.WriteLine($"Ошибка деления: {customEx.Message}");
        }

        try
        {
          int x = int.Parse( Console.ReadLine() );
                        

            
        }
        catch (System.FormatException ex)
        {
            var customEx = new CustomExceptions.CustomDevisionException("Не введен нужный диапазон значений", ex);
            Console.WriteLine($"Ошибка деления: {customEx.Message}");
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Общая ошибка: {ex.Message}");
        }

        try
        {
            FirstMethod();
        }
        catch (CustomExceptions.CustomDevisionException ex)
        {
            Console.WriteLine($"Финальная обработка: {ex.Message}");
            Console.WriteLine($"Полный стек вызовов: {ex.StackTrace}");
        }



        try
        {
            int[] aa = null;
            Debug.Assert(aa != null, "Values array cannot be null");
            Assert(5 > 10, "Значение должно быть больше 10."); // Пример использования Assert
        }
        catch (CustomBaseException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }


        finally
        {
            Console.WriteLine("Программа закончена..");
        }











        static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                throw new CustomExceptions.CustomBaseException(message);
            }
        }
    }
}


