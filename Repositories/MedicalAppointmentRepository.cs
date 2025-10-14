using CitasMedicas.Data;
using CitasMedicas.Interfaces;
using CitasMedicas.Models;

namespace CitasMedicas.Repositories;

public class MedicalAppointmentRepository : ICreate<MedicalAppointments>, IGet<MedicalAppointments>, IUpdateMedicalAppointment, IDelete<MedicalAppointments>
{
    public void Create(MedicalAppointments appointment)
    {
        Database.Appointments.Add(appointment);
    }

    public List<MedicalAppointments> GetAll()
    {
        return Database.Appointments;
    }


    public MedicalAppointments? GetById(string id)
    {
        return Database.Appointments.Find((appointment => appointment.IdAppointment.ToString() == id));
    }


    public MedicalAppointments? GetByName(string name)
    {
        return Database.Appointments.Find((patient => patient.Patient.Name == name));
    }
    
    public void UpdateDoctor(Doctor doctor)
    {
        Database.Appointments = Database.Appointments.Select((appointment) =>
        {
            if (appointment.Doctor.Identification == doctor.Identification)
            {
                appointment.Doctor = doctor;
                return appointment;
            }

            return appointment;
        }).ToList();
    }
    public void UpdatePatient(Patient patient)
    {
        Database.Appointments = Database.Appointments.Select((appointment) =>
        {
            if (appointment.Patient.Identification == patient.Identification)
            {
                appointment.Patient = patient;
                return appointment;
            }

            return appointment;
        }).ToList();
    }
    public void UpdateDate(DateTime serviceDate)
    {
        Database.Appointments = Database.Appointments.Select((appointment) =>
        {
            if (appointment.ServiceDate == serviceDate)
            {
                appointment.ServiceDate = serviceDate;
                return appointment;
            }

            return appointment;
        }).ToList();
    }
    public void UpdateState(bool state)
    {
        Database.Appointments = Database.Appointments.Select((appointment) =>
        {
            if (appointment.State == state)
            {
                appointment.State = state;
                return appointment;
            }

            return appointment;
        }).ToList();
    }
    public void Delete(Guid id)
    {
        Database.Appointments.Where((appoinment => appoinment.IdAppointment == id));
    }
}