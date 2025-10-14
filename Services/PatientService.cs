using CitasMedicas.Models;
using CitasMedicas.Repositories;

namespace CitasMedicas.Services;

public class PatientService
{
    private static PatientRepository _patientRepository = new PatientRepository();

    public static void CreatePatient(string name,
        string lastName,
        string identification,
        string email,
        string phone,
        DateOnly birthDate)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName) ||
            string.IsNullOrEmpty(identification) || string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(phone) || birthDate > DateOnly.FromDateTime(DateTime.Now))
        {
            Console.WriteLine("Invalid input. Please provide valid patient details.");
            return;
        }
        try
        {
            Patient newPatient = new Patient(name, lastName, identification,email, phone, birthDate);
            _patientRepository.Create(newPatient);
            Console.WriteLine("Patient created successfully.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating patient: {ex.Message}");
        }
    }

    public static List<Patient> GetAllPatients()
    {
        try
        {
            return _patientRepository.GetAll();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving patients: {ex.Message}");
            return [];
        }
    }

    public static Patient? GetPatientById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return null;
        }

        try
        {
            return _patientRepository.GetById(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving patient by Id: {ex.Message}");
            return null;
        }
    }

    public static Patient? GetPatientByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Invalid Name");
            return null;
        }

        try
        {
            return _patientRepository.GetByName(name);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving patient by Name: {ex.Message}");
            return null;
        }
    }

    public static void UpdatePatientName(string id, string newName)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newName))
        {
            Console.WriteLine("Invalid Id or Name");
            return;
        }

        try
        {
            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            patient.Name = newName;
            _patientRepository.UpdatePersonName(newName, patient);
            Console.WriteLine("Patient name updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating patient name: {ex.Message}");
        }
    }

    public static void UpdatePatientLastName(string id, string newLastName)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newLastName))
        {
            Console.WriteLine("Invalid Id or Last Name");
            return;
        }

        try
        {
            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            patient.LastName = newLastName;
            _patientRepository.UpdatePersonName(newLastName, patient);
            Console.WriteLine("Patient name updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating patient name: {ex.Message}");
        }
    }
    // identification,email, phone
    
    public static void UpdatePatientIdentification(string id, string newIdentification)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newIdentification))
        {
            Console.WriteLine("Invalid Id or Identification");
            return;
        }

        try
        {
            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            patient.Identification = newIdentification;
            _patientRepository.UpdatePersonIdentification(newIdentification, patient);
            Console.WriteLine("Patient identification updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating patient identification: {ex.Message}");
        }
    }
    public static void UpdatePatientEmail(string id, string newEmail)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newEmail))
        {
            Console.WriteLine("Invalid Id or Email");
            return;
        }

        try
        {
            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            patient.Email = newEmail;
            _patientRepository.UpdatePersonEmail(newEmail, patient);
            Console.WriteLine("Patient email updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating patient email: {ex.Message}");
        }
    }

    public static void UpdatePatientPhone(string id, string newPhone)
    {
        if(string.IsNullOrEmpty(id)||string.IsNullOrEmpty(newPhone))
        {
            Console.WriteLine("Invalid Id or Phone");
            return;
        }
        try
        {
            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            patient.Phone = newPhone;
            _patientRepository.UpdatePersonPhone(newPhone, patient);
            Console.WriteLine("Patient phone updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating patient phone: {ex.Message}");
        }
    }
    

    public static void UpdatePatientBirthDate(string id, DateOnly newBirthDate)
    {
        if (string.IsNullOrEmpty(id) || newBirthDate > DateOnly.FromDateTime(DateTime.Now))
        {
            Console.WriteLine("Invalid Id or BirthDate");
            return;
        }

        try
        {
            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            patient.BirthDate = newBirthDate;
            _patientRepository.UpdatePersonBirthDate(newBirthDate, patient);
            Console.WriteLine("Patient birth date updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating patient birth date: {ex.Message}");
        }
    }
    
    
    public static void DeletePatient(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        try
        {
            _patientRepository.Delete(Guid.Parse(id));
            Console.WriteLine("Patient deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting patient: {ex.Message}");
        }
    }
}
