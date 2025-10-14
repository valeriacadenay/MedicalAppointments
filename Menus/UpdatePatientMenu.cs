using CitasMedicas.Services;
using CitasMedicas.Utils;

namespace CitasMedicas.Menus;

public static class UpdatePatient
{
    public static void Show()
    {
        Console.WriteLine("\n--- UPDATE PATIENT INFORMATION ---");
        string id = ConsoleInputHelper.ReadString("Enter Patient Identification");

        Console.WriteLine("Select the field you want to update:");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Last Name");
        Console.WriteLine("3. Identification");
        Console.WriteLine("4. Email");
        Console.WriteLine("5. Phone");
        Console.WriteLine("6. Birth Date");
        Console.WriteLine("0. Return to Patient Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                string newName = ConsoleInputHelper.ReadString("Enter new Name");
                PatientService.UpdatePatientName(id, newName);
                break;
            case "2":
                string newLastName = ConsoleInputHelper.ReadString("Enter new Last Name");
                PatientService.UpdatePatientLastName(id, newLastName);
                break;
            case "3":
                string newIdentification = ConsoleInputHelper.ReadString("Enter new Identification");
                PatientService.UpdatePatientIdentification(id, newIdentification);
                break;
            case "4":
                string newEmail = ConsoleInputHelper.ReadString("Enter new Email");
                PatientService.UpdatePatientEmail(id, newEmail);
                break;
            case "5":
                string newPhone = ConsoleInputHelper.ReadString("Enter new Phone");
                PatientService.UpdatePatientPhone(id, newPhone);
                break;
            case "6":
                DateOnly newBirthDate = ConsoleInputHelper.ReadDate("Enter new Birth Date (yyyy-MM-dd)");
                PatientService.UpdatePatientBirthDate(id, newBirthDate);
                break;
            case "0":
                Console.WriteLine("Returning to Patient Menu...");
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}
