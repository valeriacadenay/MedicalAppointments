using CitasMedicas.Models;

namespace CitasMedicas.Data;

public static class Database
{
    public static List<Doctor> Doctors = [];
    public static List<Patient> Patients = [];
    public static List<MedicalAppointments> Appointments = [];
    public static List<string> Specialties = [
        "Cardiology",
        "Dermatology",
        "Neurology",
        "Pediatrics",
        "Psychiatry",
        "Radiology",
        "Surgery"
    ];
    
    //Method to initilize the database with some doctors and patients
    static Database()
    {
        
        // Add Doctors
        var doctor1 = new Doctor(
            name: "Alice",
            lastName: "Smith",
            identification: "DOC123",
            email: "alice.smith@hospital.com",
            phone: "555-1234",
            birthDate: new DateOnly(1980, 5, 20),
            specialty: "Cardiology"
        );

        var doctor2 = new Doctor(
            name: "Bob",
            lastName: "Johnson",
            identification: "DOC456",
            email: "bob.johnson@clinic.com",
            phone: "555-5678",
            birthDate: new DateOnly(1975, 11, 15),
            specialty: "Dermatology"
        );

        Doctors.Add(doctor1);
        Doctors.Add(doctor2);

        // Add Patients
        var patient1 = new Patient(
            name: "Charlie",
            lastName: "Brown",
            identification: "PAT789",
            email: "charlie.brown@example.com",
            phone: "555-0001",
            birthDate: new DateOnly(1995, 2, 10)
        );

        var patient2 = new Patient(
            name: "Diana",
            lastName: "Miller",
            identification: "PAT012",
            email: "diana.miller@example.com",
            phone: "555-0002",
            birthDate: new DateOnly(2000, 8, 25)
        );

        Patients.Add(patient1);
        Patients.Add(patient2);

        // Add an Appointment
        var appointment1 = new MedicalAppointments(
            doctor: doctor1,
            patient: patient1,
            serviceDate: DateTime.Now.AddDays(3) // appointment 3 days from now
        );

        Appointments.Add(appointment1);
        
    }

}