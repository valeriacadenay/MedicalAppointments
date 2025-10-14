namespace CitasMedicas.Models;

public class MedicalAppointments
{
    public Guid IdAppointment { get; set; }
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
    public DateTime ServiceDate { get; set; }
    public bool State { get; set; }
    
    // Constructor to initialize the appointment with a doctor, patient, and service date
    public MedicalAppointments(Doctor doctor, Patient patient, DateTime serviceDate)
    {
        IdAppointment = Guid.NewGuid();
        Doctor = doctor;
        Patient = patient;
        ServiceDate = serviceDate;
        State = false;
    }
    
    // Method to display appointment information
    public void ShowInformation()
    {
        Console.WriteLine($"Appointment ID: {IdAppointment}");
        Console.WriteLine($"Medical Appointment Created Succesfully with the Dr. {Doctor.Name} {Doctor.LastName}");
        Console.WriteLine($"Patient: {Patient.Name}");
        Console.WriteLine($"Date: {ServiceDate}");
    }
}