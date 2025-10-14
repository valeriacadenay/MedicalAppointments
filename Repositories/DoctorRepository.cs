using CitasMedicas.Data;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;

namespace CitasMedicas.Repositories;

public class DoctorRepository : ICreate<Doctor>, IGet<Doctor>, IUpdatePerson<Doctor>, IDelete<Doctor>, IDoctor
{
    public void Create(Doctor doctor)
    {
        Database.Doctors.Add(doctor);
    }

    public List<Doctor> GetAll()
    {
        return Database.Doctors;
    }


    public Doctor? GetById(string id)
    {
        return Database.Doctors.Find((doctor => doctor.Identification.ToString() == id));
    }


    public Doctor? GetByName(string name)
    {
        return Database.Doctors.Find((doctor => doctor.Name == name));
    }

    public void UpdatePersonName(string newName, Doctor entity)
    {
        Database.Doctors = Database.Doctors.Select((doctor) =>
        {
            if (doctor.Name == newName)
            {
                doctor.Name = newName;
                return doctor;
            }

            return doctor;
        }).ToList();
    }
    
    public void UpdatePersonLastName(string newLastName, Doctor entity)
    {
        Database.Doctors = Database.Doctors.Select((doctor) =>
        {
            if (doctor.LastName == newLastName)
            {
                doctor.LastName = newLastName;
                return doctor;
            }

            return doctor;
        }).ToList();
    }
    
    public void UpdatePersonIdentification(string newIdentification, Doctor entity)
    {
        Database.Doctors = Database.Doctors.Select((doctor) =>
        {
            if (doctor.Identification == newIdentification)
            {
                doctor.Identification = newIdentification;
                return doctor;
            }

            return doctor;
        }).ToList();
    }
    
    public void UpdatePersonEmail(string newEmail, Doctor entity)
    {
        Database.Doctors = Database.Doctors.Select((doctor) =>
        {
            if (doctor.Email == newEmail)
            {
                doctor.Email = newEmail;
                return doctor;
            }

            return doctor;
        }).ToList();
    }
    public void UpdatePersonPhone(string newPhone, Doctor entity)
    {
        Database.Doctors = Database.Doctors.Select((doctor) =>
        {
            if (doctor.Phone == newPhone)
            {
                doctor.Phone = newPhone;
                return doctor;
            }

            return doctor;
        }).ToList();
    }
    public void UpdatePersonBirthDate(DateOnly newBirthDate, Doctor entity)
    {
        Database.Doctors = Database.Doctors.Select((doctor) =>
        {
            if (doctor.BirthDate == newBirthDate)
            {
                doctor.BirthDate = newBirthDate;
                return doctor;
            }

            return doctor;
        }).ToList();
    }
    public void Delete(Guid id)
    {
        Database.Doctors.Where((doctor => doctor.Id == id));
    }
    
    
    public List<Doctor> GetDoctorsBySpecialty(string specialty)
    {
        if (string.IsNullOrEmpty(specialty))
            return new List<Doctor>();

        return Database.Doctors
            .Where(d => d.Specialty != null && d.Specialty.ToLower() == specialty.ToLower())
            .ToList();
    }
    
}