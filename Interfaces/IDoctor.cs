using CitasMedicas.Models;
namespace CitasMedicas.Interfaces;

public interface IDoctor
{
    List<Doctor> GetDoctorsBySpecialty(string specialty);
}
