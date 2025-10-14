namespace CitasMedicas.Models;

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Identification { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateOnly BirthDate { get; set; }

    public int Age
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - BirthDate.Year;
            if (BirthDate > today.AddYears(-age)) age--;
            return age;
        }
    }
    // Constructor to initialize the personal information of the person
    public Person(string name, string lastName, string identification, string email, string phone, DateOnly birthDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        LastName = lastName;
        Identification = identification;
        Email = email;
        Phone = phone;
        BirthDate = birthDate;
    }
    
    // Method to display Person information
    public virtual void ShowInformation()
    {
        Console.WriteLine(
            $"Name: {Name} {LastName}, Identification: {Identification}, Email: {Email}, Phone: {Phone} , Age {Age}");
    }
}