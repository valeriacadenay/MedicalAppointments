using CitasMedicas.Services;
using CitasMedicas.Utils;

namespace CitasMedicas.Menus;

public static class PatientMenu
{
    public static void Show()
    {
        bool back = false;

        while (!back)
        {
            ConsoleUI.Title("🩺 PATIENT MENU");
            Console.WriteLine("1. Register new patient");
            Console.WriteLine("2. Show all patients");
            Console.WriteLine("3. Search patient by name");
            Console.WriteLine("4. Update patient information");
            Console.WriteLine("5. Delete patient");
            Console.WriteLine("9. Back to Main Menu");
            ConsoleUI.Separator();

            string option = ConsoleUI.ReadOption();

            switch (option)
            {
                case "1":
                    string name = ConsoleInputHelper.ReadString("Enter patient name");
                    string lastName = ConsoleInputHelper.ReadString("Enter patient last name");
                    string identification = ConsoleInputHelper.ReadString("Enter identification");
                    string email = ConsoleInputHelper.ReadString("Enter email");
                    string phone = ConsoleInputHelper.ReadString("Enter phone number");
                    DateOnly birthDate = ConsoleInputHelper.ReadDate("Enter birth date (yyyy-MM-dd)");

                    PatientService.CreatePatient(name, lastName, identification, email, phone, birthDate);
                    break;

                case "2":
                    var patients = PatientService.GetAllPatients();
                    if (patients.Count == 0)
                    {
                        Console.WriteLine("No patients found.");
                    }
                    else
                    {
                        Console.WriteLine("Patients List:");
                        foreach (var p in patients)
                        {
                            Console.WriteLine($"- {p.Name} {p.LastName}, Email: {p.Email}, Phone: {p.Phone}");
                        }
                    }
                    break;

                case "3":
                    string searchName = ConsoleInputHelper.ReadString("Enter patient name to search");
                    var patient = PatientService.GetPatientByName(searchName);

                    if (patient != null)
                    {
                        Console.WriteLine($"Patient found: {patient.Name} {patient.LastName}, Email: {patient.Email}, Phone: {patient.Phone}, Birth Date: {patient.BirthDate}");
                    }
                    else
                    {
                        Console.WriteLine("Patient not found.");
                    }
                    break;

                case "4":
                    UpdatePatient.Show();
                    break;

                case "5":
                    string idToDelete = ConsoleInputHelper.ReadString("Enter the patient ID to delete");
                    PatientService.DeletePatient(idToDelete);
                    break;

                case "9":
                    back = true;
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }

            if (!back)
                ConsoleUI.Pause();
        }
    }
}
