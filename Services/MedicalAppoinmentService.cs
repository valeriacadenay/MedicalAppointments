using CitasMedicas.Data;
using CitasMedicas.Models;
using CitasMedicas.Repositories;

namespace CitasMedicas.Services;

public class MedicalAppoinmentService
{
    private static MedicalAppointmentRepository _appointmentRepository = new MedicalAppointmentRepository();

    public static void CreateAppointment(Doctor doctor, Patient patient, DateTime serviceDate)
    {
        if (doctor == null || patient == null || serviceDate <= DateTime.Now)
        {
            Console.WriteLine("Invalid input. Please provide valid doctor, patient and future service date.");
            return;
        }

        try
        {
            var newAppointment = new MedicalAppointments(doctor, patient, serviceDate);
            _appointmentRepository.Create(newAppointment);
            Console.WriteLine("Medical appointment created successfully.");
            // Send confirmation email
            string subject = "Confirmación de cita médica";
            string body = $"Hola {patient.Name},\n\nTu cita con el Dr. {doctor.Name} está confirmada para el {serviceDate}.\n\nGracias.";
        
            bool emailSent = EmailSender.SendEmail(patient.Email, subject, body);
            // Save the submission history to the repository
            Database.Emails.Add(new EmailLog
            {
                ToEmail = patient.Email,
                Subject = subject,
                SentDate = DateTime.Now,
                SentSuccessfully = emailSent
            });

            if (emailSent)
                Console.WriteLine("Correo de confirmación enviado correctamente.");
            else
                Console.WriteLine("No se pudo enviar el correo de confirmación.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating medical appointment: {ex.Message}");
        }
    }

    public static List<MedicalAppointments> GetAllAppointments()
    {
        try
        {
            return _appointmentRepository.GetAll();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving appointments: {ex.Message}");
            return new List<MedicalAppointments>();
        }
    }

    public static MedicalAppointments? GetAppointmentById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Invalid Id");
            return null;
        }

        try
        {
            return _appointmentRepository.GetById(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving appointment by Id: {ex.Message}");
            return null;
        }
    }

    public static MedicalAppointments? GetAppointmentByPatientName(string patientName)
    {
        if (string.IsNullOrEmpty(patientName))
        {
            Console.WriteLine("Invalid Patient Name");
            return null;
        }

        try
        {
            return _appointmentRepository.GetByName(patientName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving appointment by patient name: {ex.Message}");
            return null;
        }
    }

    public static void UpdateDoctor(string appointmentId, Doctor newDoctor)
    {
        if (string.IsNullOrEmpty(appointmentId) || newDoctor == null)
        {
            Console.WriteLine("Invalid appointment ID or doctor");
            return;
        }

        try
        {
            var appointment = _appointmentRepository.GetById(appointmentId);
            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }

            appointment.Doctor = newDoctor;
            _appointmentRepository.UpdateDoctor(newDoctor);
            Console.WriteLine("Appointment doctor updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating appointment doctor: {ex.Message}");
        }
    }

    public static void UpdatePatient(string appointmentId, Patient newPatient)
    {
        if (string.IsNullOrEmpty(appointmentId) || newPatient == null)
        {
            Console.WriteLine("Invalid appointment ID or patient");
            return;
        }

        try
        {
            var appointment = _appointmentRepository.GetById(appointmentId);
            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }

            appointment.Patient = newPatient;
            _appointmentRepository.UpdatePatient(newPatient);
            Console.WriteLine("Appointment patient updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating appointment patient: {ex.Message}");
        }
    }

    public static void UpdateServiceDate(string appointmentId, DateTime newServiceDate)
    {
        if (string.IsNullOrEmpty(appointmentId) || newServiceDate <= DateTime.Now)
        {
            Console.WriteLine("Invalid appointment ID or service date");
            return;
        }

        try
        {
            var appointment = _appointmentRepository.GetById(appointmentId);
            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }

            appointment.ServiceDate = newServiceDate;
            _appointmentRepository.UpdateDate(newServiceDate);
            Console.WriteLine("Appointment service date updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating appointment date: {ex.Message}");
        }
    }

    public static void UpdateState(string appointmentId, bool newState)
    {
        if (string.IsNullOrEmpty(appointmentId))
        {
            Console.WriteLine("Invalid appointment ID");
            return;
        }

        try
        {
            var appointment = _appointmentRepository.GetById(appointmentId);
            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }

            appointment.State = newState;
            _appointmentRepository.UpdateState(newState);
            Console.WriteLine("Appointment state updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating appointment state: {ex.Message}");
        }
    }

    public static void DeleteAppointment(string appointmentId)
    {
        if (string.IsNullOrEmpty(appointmentId))
        {
            Console.WriteLine("Invalid appointment ID");
            return;
        }

        try
        {
            _appointmentRepository.Delete(Guid.Parse(appointmentId));
            Console.WriteLine("Appointment deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting appointment: {ex.Message}");
        }
    }
    public static bool IsDoctorAvailable(Doctor doctor, DateTime dateTime)
    {
        var allAppointments = _appointmentRepository.GetAll();

        return !allAppointments.Any(appt =>
            appt.Doctor.Identification == doctor.Identification &&
            appt.ServiceDate == dateTime &&
            appt.State); 
    }
    

}
