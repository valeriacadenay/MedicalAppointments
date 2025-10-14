using CitasMedicas.Models;

namespace CitasMedicas.Interfaces;
//Interface to update medical appointment details

public interface IUpdateMedicalAppointment
{
    public void UpdateDoctor(Doctor doctor);
    public void UpdatePatient(Patient patient);
    public void UpdateDate(DateTime serviceDate);
    public void UpdateState(bool state);
}