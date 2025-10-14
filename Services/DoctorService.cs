using CitasMedicas.Models;
using CitasMedicas.Repositories;

namespace CitasMedicas.Services;

public class DoctorService
{
    private static DoctorRepository _doctoRepository = new DoctorRepository();
    
    public static void CreateDoctor(string name, string lastName, string identification, string email, string phone, DateOnly birthDate, string specialty)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName) ||
            string.IsNullOrEmpty(identification) || string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(specialty))
        {
            Console.WriteLine("Invalid input. Please provide valid owner details.");
            return;
        }

        try
        {
            var doctor = new Doctor(name, lastName, identification, email, phone, birthDate, specialty);
            _doctoRepository.Create(doctor);
            Console.WriteLine("Doctor created successfully.");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error creating owner: {ex.Message}");
        }
    }
    
    public static List<Doctor> GetDoctors()
    {
        try
        {
            return _doctoRepository.GetAll();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error retrieving owners: {ex.Message}");
            return [];
        }   
    }
    public static Doctor? GetDoctorById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return null;
        }
        try
        {
            return _doctoRepository.GetById(id);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error retrieving owner: {ex.Message}");
            return null;
        }
    }
    
    public static void UpdateDoctorName(string id, string newName)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newName))
        {
            Console.WriteLine("Invalid input. Please provide a valid name and doctor.");
        }
        try
        {
            Doctor? updateDoctor = _doctoRepository.GetById(id);
            if (updateDoctor == null)
            {
                Console.WriteLine("Doctor not found.");
            }

            updateDoctor.Name = newName;
            _doctoRepository.UpdatePersonName(newName, updateDoctor);
            Console.WriteLine("Doctor name updated successfully.");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error updating doctor name: {ex.Message}");
        }
    }
    
    public static void UpdateDoctorLastName(string id, string newLastName)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newLastName))
        {
            Console.WriteLine("Invalid input. Please provide a valid last name and doctor.");
        }
        try
        {
            Doctor? updateDoctor = _doctoRepository.GetById(id);
            if (updateDoctor == null)
            {
                Console.WriteLine("Owner not found.");
            }

            updateDoctor.LastName = newLastName;
            _doctoRepository.UpdatePersonLastName(newLastName, updateDoctor);
            Console.WriteLine("Owner last name updated successfully.");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error updating doctor last name: {ex.Message}");
        }
    }
    public static void UpdateDoctorIdentification(string id, string newIdentification)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newIdentification))
        {
            Console.WriteLine("Invalid input. Please provide a valid identification and doctor.");
        }
        try
        {
            Doctor? updateDoctor = _doctoRepository.GetById(id);
            if (updateDoctor == null)
            {
                Console.WriteLine("Owner not found.");
            }

            updateDoctor.Identification = newIdentification;
            _doctoRepository.UpdatePersonIdentification(newIdentification, updateDoctor);
            Console.WriteLine("Owner identification updated successfully.");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error updating doctor identification: {ex.Message}");
        }
    }
    public static void UpdateDoctorEmail(string id, string newEmail)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newEmail))
        {
            Console.WriteLine("Invalid input. Please provide a valid email and doctor.");
        }
        try
        {
            Doctor? updateDoctor = _doctoRepository.GetById(id);
            if (updateDoctor == null)
            {
                Console.WriteLine("Owner not found.");
            }

            updateDoctor.Email = newEmail;
            _doctoRepository.UpdatePersonEmail(newEmail, updateDoctor);
            Console.WriteLine("Owner email updated successfully.");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error updating doctor email: {ex.Message}");
        }
    }

    public static void UpdateDoctorPhone(string id, string newPhone)
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newPhone))
        {
            Console.WriteLine($"Invalid Id or Phone");
        }

        try
        {
            Doctor? updateDoctor = _doctoRepository.GetById(id);
            if (updateDoctor == null)
            {
                Console.WriteLine("Owner not found.");
            }

            updateDoctor.Phone = newPhone;
            _doctoRepository.UpdatePersonPhone(newPhone, updateDoctor);
            Console.WriteLine("Owner Phone updated successfully.");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error updating doctor email: {ex.Message}");
        }
    }
    public static void UpdateDoctorBirthDate(string id, DateOnly newBirthDate)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        try
        {
            Doctor? updateDoctor = _doctoRepository.GetById(id);
            if (updateDoctor == null)
            {
                Console.WriteLine("Owner not found.");
                return;
            }

            updateDoctor.BirthDate = newBirthDate;
            _doctoRepository.UpdatePersonBirthDate(newBirthDate, updateDoctor);
            Console.WriteLine("Owner birth date updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating doctor birth date: {ex.Message}");
        }
    }
    public static void DeleteDoctor(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        try
        {
            _doctoRepository.Delete(Guid.Parse(id));
            Console.WriteLine("Doctor deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting doctor: {ex.Message}");
        }
    }
    
}