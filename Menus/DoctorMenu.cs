using CitasMedicas.Services;
using CitasMedicas.Utils;

namespace CitasMedicas.Menus;

public static class DoctorMenu
{
    public static void Show()
    {
        bool back = false;

        while (!back)
        {
            ConsoleUI.Title("DOCTOR MENU");
            Console.WriteLine("1. Register new doctor");
            Console.WriteLine("2. Show all doctors");
            Console.WriteLine("3. Search doctor by Name");
            Console.WriteLine("4. Update doctor information");
            Console.WriteLine("5. Delete doctor");
            Console.WriteLine("9. Back to Main Menu");
            ConsoleUI.Separator();

            string option = ConsoleUI.ReadOption();

            switch (option)
            {
                case "1":
                    string name = ConsoleInputHelper.ReadString("Enter doctor name");
                    string lastName = ConsoleInputHelper.ReadString("Enter doctor last name");
                    string identification = ConsoleInputHelper.ReadString("Enter identification");
                    string email = ConsoleInputHelper.ReadString("Enter email");
                    string phone = ConsoleInputHelper.ReadString("Enter phone number");
                    DateOnly birthDate = ConsoleInputHelper.ReadDate("Enter birth date (yyyy-MM-dd)");
                    string specialty = ConsoleInputHelper.ReadString("Enter specialty");

                    DoctorService.CreateDoctor(name, lastName, identification, email, phone, birthDate, specialty);
                    Console.WriteLine("→ Registering new doctor...");
                    break;

                case "2":
                    var doctors = DoctorService.GetDoctors();
                    if (doctors.Count == 0)
                    {
                        Console.WriteLine("No doctors found.");
                    }
                    else
                    {
                        Console.WriteLine("Doctors List:");
                        foreach (var doc in doctors)
                        {
                            Console.WriteLine($"- {doc.Name} {doc.LastName}, Specialty: {doc.Specialty}, Email: {doc.Email}, Phone: {doc.Phone}");
                        }
                    }
                    break;

                case "3":
                    string searchName = ConsoleInputHelper.ReadString("Enter doctor name to search");
                    var doctor = DoctorService.GetDoctorById(searchName); 

                    if (doctor != null)
                    {
                        Console.WriteLine(
                            $"Doctor found: {doctor.Name} {doctor.LastName}, Specialty: {doctor.Specialty}, Email: {doctor.Email}, Phone: {doctor.Phone}");
                    }
                    else
                    {
                        Console.WriteLine("Doctor not found.");
                    }
                    break;

                case "4":
                    UpdateDoctorMenu.Show(); 
                    break;

                case "5":
                    string idDoctor = ConsoleInputHelper.ReadString("Enter the doctor ID to delete");
                    DoctorService.DeleteDoctor(idDoctor);
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
