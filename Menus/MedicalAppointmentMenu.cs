using CitasMedicas.Data;
using CitasMedicas.Models;
using CitasMedicas.Services;
using CitasMedicas.Utils;

namespace CitasMedicas.Menus;

public static class MedicalAppointmentMenu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- MEDICAL APPOINTMENTS MENU ---");
            Console.WriteLine("1. Create Appointment");
            Console.WriteLine("2. List All Appointments");
            Console.WriteLine("3. Update Appointment");
            Console.WriteLine("4. Delete Appointment");
            Console.WriteLine("5. Show emails sent history");
            Console.WriteLine("0. Return to Main Menu");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateAppointment();
                    break;
                case "2":
                    ListAppointments();
                    break;
                case "3":
                    UpdateAppointment();
                    break;
                case "4":
                    DeleteAppointment();
                    break;
                case "5":
                    if (Database.Emails.Count == 0)
                    {
                        Console.WriteLine("No emails have been sent yet.");
                    }
                    else
                    {
                        foreach (var email in Database.Emails)
                        {
                            Console.WriteLine($"To: {email.ToEmail}, Subject: {email.Subject}, Date: {email.SentDate}, Success: {email.SentSuccessfully}");
                        }
                    }
                    break;
                case "0":
                    Console.WriteLine("Returning to Main Menu...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private static void CreateAppointment()
    {
        Console.WriteLine("\n--- CREATE NEW APPOINTMENT ---");
        Console.WriteLine("Specialy Available: Cardiology, Dermatology, Neurology," +
                          " Pediatrics, Psychiatry,Radiology, Surgery");
        string specialty = ConsoleInputHelper.ReadString("Enter Specialty for Doctor");
        var doctors = DoctorService.GetDoctorsBySpecialty(specialty);

        if (doctors == null || doctors.Count == 0)
        {
            Console.WriteLine($"No doctors found with specialty '{specialty}'.");
            return;
        }

        Console.WriteLine("Available Doctors:");
        foreach (var doc in doctors)
        {
            Console.WriteLine($"ID: {doc.Identification} - {doc.Name} {doc.LastName}");
        }

        string doctorId = ConsoleInputHelper.ReadString("Enter Doctor Identification from the list above");
        var doctor = doctors.FirstOrDefault(d => d.Identification == doctorId);

        if (doctor == null)
        {
            Console.WriteLine("Invalid Doctor ID or doctor not found.");
            return;
        }

        string patientId = ConsoleInputHelper.ReadString("Enter Patient Identification");
        var patient = PatientService.GetPatientById(patientId);

        if (patient == null)
        {
            Console.WriteLine("Patient not found.");
            return;
        }

        DateTime serviceDate = ConsoleInputHelper.ReadDateTime("Enter Service Date and Time (yyyy-MM-dd HH:mm)");

        if (serviceDate <= DateTime.Now)
        {
            Console.WriteLine("Service date must be in the future.");
            return;
        }

        // Check if doctor is available at that date and time
        bool available = MedicalAppoinmentService.IsDoctorAvailable(doctor, serviceDate);
        if (!available)
        {
            Console.WriteLine("The doctor already has an appointment at that time. Please select another time.");
            return;
        }

        MedicalAppoinmentService.CreateAppointment(doctor, patient, serviceDate);
    }

    private static void ListAppointments()
    {
        Console.WriteLine("\n--- LIST OF ALL APPOINTMENTS ---");
        var appointments = MedicalAppoinmentService.GetAllAppointments();

        if (appointments.Count == 0)
        {
            Console.WriteLine("No appointments found.");
            return;
        }

        foreach (var appointment in appointments)
        {
            Console.WriteLine($"ID: {appointment.IdAppointment}");
            Console.WriteLine($"Doctor: {appointment.Doctor.Name} {appointment.Doctor.LastName} (ID: {appointment.Doctor.Identification})");
            Console.WriteLine($"Patient: {appointment.Patient.Name} {appointment.Patient.LastName} (ID: {appointment.Patient.Identification})");
            Console.WriteLine($"Service Date: {appointment.ServiceDate}");
            Console.WriteLine($"State: {(appointment.State ? "Active" : "Inactive")}");
            Console.WriteLine("------------------------------");
        }
    }

    private static void UpdateAppointment()
    {
        Console.WriteLine("\n--- UPDATE APPOINTMENT ---");
        string appointmentId = ConsoleInputHelper.ReadString("Enter Appointment ID");

        Console.WriteLine("Select the field to update:");
        Console.WriteLine("1. Doctor");
        Console.WriteLine("2. Patient");
        Console.WriteLine("3. Service Date");
        Console.WriteLine("4. State (Active/Inactive)");
        Console.WriteLine("0. Cancel");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.WriteLine("Specialy Available: Cardiology, Dermatology, Neurology," +
                                  " Pediatrics, Psychiatry,Radiology, Surgery");
                string specialty = ConsoleInputHelper.ReadString("Enter Specialty for Doctor"); ;
                var doctors = DoctorService.GetDoctorsBySpecialty(specialty);
                if (doctors == null || doctors.Count == 0)
                {
                    Console.WriteLine($"No doctors found with specialty '{specialty}'.");
                    return;
                }
                Console.WriteLine("Available Doctors:");
                foreach (var doc in doctors)
                {
                    Console.WriteLine($"ID: {doc.Identification} - {doc.Name} {doc.LastName}");
                }
                string newDoctorId = ConsoleInputHelper.ReadString("Enter new Doctor Identification");
                var newDoctor = doctors.FirstOrDefault(d => d.Identification == newDoctorId);
                if (newDoctor == null)
                {
                    Console.WriteLine("Doctor not found.");
                    return;
                }
                MedicalAppoinmentService.UpdateDoctor(appointmentId, newDoctor);
                break;

            case "2":
                string newPatientId = ConsoleInputHelper.ReadString("Enter new Patient Identification");
                var newPatient = PatientService.GetPatientById(newPatientId);
                if (newPatient == null)
                {
                    Console.WriteLine("Patient not found.");
                    return;
                }
                MedicalAppoinmentService.UpdatePatient(appointmentId, newPatient);
                break;

            case "3":
                DateTime newServiceDate = ConsoleInputHelper.ReadDateTime("Enter new Service Date and Time (yyyy-MM-dd HH:mm)");

                if (newServiceDate <= DateTime.Now)
                {
                    Console.WriteLine("Service date must be in the future.");
                    return;
                }

                // Check availability of current doctor for the new date
                var appointment = MedicalAppoinmentService.GetAppointmentById(appointmentId);
                if (appointment == null)
                {
                    Console.WriteLine("Appointment not found.");
                    return;
                }

                bool available = MedicalAppoinmentService.IsDoctorAvailable(appointment.Doctor, newServiceDate);
                if (!available)
                {
                    Console.WriteLine("The doctor already has an appointment at that time. Please select another time.");
                    return;
                }

                MedicalAppoinmentService.UpdateServiceDate(appointmentId, newServiceDate);
                break;

            case "4":
                Console.Write("Enter new state (true for Active, false for Inactive): ");
                string stateInput = Console.ReadLine();
                if (bool.TryParse(stateInput, out bool newState))
                {
                    MedicalAppoinmentService.UpdateState(appointmentId, newState);
                }
                else
                {
                    Console.WriteLine("Invalid state value.");
                }
                break;

            case "0":
                Console.WriteLine("Update cancelled.");
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    private static void DeleteAppointment()
    {
        Console.WriteLine("\n--- DELETE APPOINTMENT ---");
        string appointmentId = ConsoleInputHelper.ReadString("Enter Appointment ID to delete");
        MedicalAppoinmentService.DeleteAppointment(appointmentId);
    }
}
