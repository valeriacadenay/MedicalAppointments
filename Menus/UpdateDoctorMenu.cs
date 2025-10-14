using CitasMedicas.Services;
using CitasMedicas.Utils;

namespace CitasMedicas.Menus;

public static class UpdateDoctorMenu
{
    public static void Show()
    {
        Console.WriteLine("\n--- UPDATE DOCTOR INFORMATION ---");
        string id = ConsoleInputHelper.ReadString("Enter Doctor Identification");

        Console.WriteLine("Select the field you want to update:");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Last Name");
        Console.WriteLine("3. Email");
        Console.WriteLine("4. Phone");
        Console.WriteLine("5. Birth Date");
        Console.WriteLine("0. Return to Doctor Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                string newName = ConsoleInputHelper.ReadString("Enter new Name");
                DoctorService.UpdateDoctorName(id, newName);
                break;

            case "2":
                string newLastName = ConsoleInputHelper.ReadString("Enter new Last Name");
                DoctorService.UpdateDoctorLastName(id, newLastName);
                break;

            case "3":
                string newEmail = ConsoleInputHelper.ReadString("Enter new Email");
                DoctorService.UpdateDoctorEmail(id, newEmail);
                break;

            case "4":
                string newPhone = ConsoleInputHelper.ReadString("Enter new Phone Number");
                DoctorService.UpdateDoctorPhone(id, newPhone);
                break;

            case "5":
                DateOnly newBirthDate = ConsoleInputHelper.ReadDate("Enter new Birth Date (yyyy-MM-dd)");
                DoctorService.UpdateDoctorBirthDate(id, newBirthDate);
                break;
            
            case "0":
                Console.WriteLine("Returning to Doctor Menu...");
                return;

            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}
