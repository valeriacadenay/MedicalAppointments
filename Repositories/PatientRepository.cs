using CitasMedicas.Data;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;

namespace CitasMedicas.Repositories;

public class PatientRepository : ICreate<Patient>, IGet<Patient>, IUpdatePerson<Patient>, IDelete<Patient>
{
     public void Create(Patient patient)
    {
        Database.Patients.Add(patient);
    }

    public List<Patient> GetAll()
    {
        return Database.Patients;
    }


    public Patient? GetById(string id)
    {
        return Database.Patients.Find((patient => patient.Identification.ToString() == id));
    }


    public Patient? GetByName(string name)
    {
        return Database.Patients.Find((patient => patient.Name == name));
    }

    public void UpdatePersonName(string newName, Patient entity)
    {
        Database.Patients = Database.Patients.Select((patient) =>
        {
            if (patient.LastName == newName)
            {
                patient.LastName = newName;
                return patient;
            }

            return patient;
        }).ToList();
    }
    
    public void UpdatePersonLastName(string newLastName, Patient entity)
    {
        Database.Patients = Database.Patients.Select((patient) =>
        {
            if (patient.LastName == newLastName)
            {
                patient.LastName = newLastName;
                return patient;
            }

            return patient;
        }).ToList();
    }
    
    public void UpdatePersonIdentification(string newIdentification, Patient entity)
    {
        Database.Patients = Database.Patients.Select((patient) =>
        {
            if (patient.Identification == newIdentification)
            {
                patient.Identification = newIdentification;
                return patient;
            }

            return patient;
        }).ToList();
    }
    
    public void UpdatePersonEmail(string newEmail, Patient entity)
    {
        Database.Patients = Database.Patients.Select((patient) =>
        {
            if (patient.Email == newEmail)
            {
                patient.Email = newEmail;
                return patient;
            }

            return patient;
        }).ToList();
    }
    public void UpdatePersonPhone(string newPhone, Patient entity)
    {
        Database.Patients = Database.Patients.Select((patient) =>
        {
            if (patient.Phone == newPhone)
            {
                patient.Phone = newPhone;
                return patient;
            }

            return patient;
        }).ToList();
    }
    public void UpdatePersonBirthDate(DateOnly newBirthDate, Patient entity)
    {
        Database.Patients = Database.Patients.Select((patient) =>
        {
            if (patient.BirthDate == newBirthDate)
            {
                patient.BirthDate = newBirthDate;
                return patient;
            }

            return patient;
        }).ToList();
    }
    public void Delete(Guid id)
    {
        Database.Patients.Where((doctor => doctor.Id == id));
    }
}