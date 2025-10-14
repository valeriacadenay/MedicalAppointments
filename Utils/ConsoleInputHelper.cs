namespace CitasMedicas.Utils;

public class ConsoleInputHelper
{
    public static string ReadString(string message)
    {
        Console.Write(message + ": ");
        string input = Console.ReadLine();
        while (string.IsNullOrEmpty(input))
        {
            Console.Write("Input cannot be empty. Please try again: ");
            input = Console.ReadLine();
        }
        return input;
    }

    public static int ReadInt(string message)
    {
        Console.Write(message + ": ");
        string input = Console.ReadLine();
        int value;
        while (!int.TryParse(input, out value))
        {
            Console.Write("Invalid number. Please try again: ");
            input = Console.ReadLine();
        }
        return value;
    }
    public static DateOnly ReadDate(string message)
    {
        Console.Write(message + ": ");
        string input = Console.ReadLine();
        DateOnly dateValue;
    
        while (!DateOnly.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dateValue))
        {
            Console.Write("Invalid date format. Please enter the date in yyyy-MM-dd format: ");
            input = Console.ReadLine();
        }
    
        return dateValue;
    }
    
    public static DateTime ReadDateTime(string message)
    {
        Console.Write(message + ": ");
        string input = Console.ReadLine();
        DateTime dateValue;

        while (!DateTime.TryParse(input, out dateValue))
        {
            Console.Write("Fecha inválida. Por favor escribe la fecha y hora en formato correcto (ejemplo: 2025-10-14 15:30): ");
            input = Console.ReadLine();
        }

        return dateValue;
    }



}
