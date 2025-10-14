using CitasMedicas.Menus;
using CitasMedicas.Utils;

namespace CitasMedicas;

public class MainMenu
{
    public static void Show()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Medical Appointment System ===");
            Console.WriteLine("1. Doctor Menu");
            Console.WriteLine("2. Patient Menu");
            Console.WriteLine("3. Medical Appointment Menu");
            Console.WriteLine("0. Exit");
            Console.WriteLine("-------------------------------");
            Console.Write("Select an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    DoctorMenu.Show();
                    break;
                case "2":
                    PatientMenu.Show();
                    break;
                case "3":
                    MedicalAppointmentMenu.Show();
                    break;
                case "0":
                    Console.WriteLine("Exiting application. Goodbye!");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}