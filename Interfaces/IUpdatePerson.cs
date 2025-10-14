namespace CitasMedicas.Interfaces;

//Interface to update person, doctor and patient details
public interface IUpdatePerson <T>
{
    public void UpdatePersonName(string newName, T entity);
    public void UpdatePersonLastName(string newLastName, T entity);
    public void UpdatePersonIdentification(string newIdentification, T entity);
    public void UpdatePersonEmail(string newEmail, T entity);
    public void UpdatePersonPhone(string newPhone, T entity);
    public void UpdatePersonBirthDate(DateOnly newBirthDate, T entity);
}