namespace CitasMedicas.Models;

public class Doctor : Person
{
    public string Specialty { get; set; }
    // Constructor to initialize the doctor with the personal information
    public Doctor (string name, string lastName, string identification, string email, string phone, DateOnly birthDate, string specialty)
        : base(name, lastName, identification, email, phone, birthDate)
    {
        this.Specialty = specialty;
    }
    
    // Method to display Doctor information
    public override void ShowInformation()
    {
        Console.WriteLine(
            $"Name: {Name} {LastName}, Identification: {Identification}, Speciality {Specialty} , Email: {Email}, Phone: {Phone} , Age {Age}");
    }
}