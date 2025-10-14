namespace CitasMedicas.Interfaces;

public interface IUpdatePerson
{
    public void UpdatePersonName(string name);
    public void UpdatePersonLastName(string lastName);
    public void UpdatePersonIdentification(string identification);
    public void UpdatePersonEmail(string email);
    public void UpdatePersonPhone(string phone);
    public void UpdatePersonBirthDate(DateOnly birthDate);
}