namespace CitasMedicas.Utils;

public class ConsoleUI
{
    public static void Title(string text)
    {
        Console.Clear();
        Console.WriteLine("===================================");
        Console.WriteLine(text);
        Console.WriteLine("===================================");
    }

    public static void Separator()
    {
        Console.WriteLine("-----------------------------------");
    }

    public static string ReadOption(string message = "Choose an option: ")
    {
        Console.Write(message);
        return Console.ReadLine()?.Trim() ?? "";
    }

    public static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}