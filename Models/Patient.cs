namespace CitasMedicas.Models;

public class Patient : Person
{
    // Constructor to initialize the patient with the personal information
    public Patient (string name, string lastName, string identification, string email, string phone, DateOnly birthDate)
        : base(name, lastName, identification, email, phone, birthDate)
    {
    }
    
    // Method to display Patient information
    public override void ShowInformation()
    {
        Console.WriteLine(
            $"Name: {Name} {LastName}, Identification: {Identification}, Email: {Email}, Phone: {Phone} , Age {Age}");
    }
}