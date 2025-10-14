namespace CitasMedicas.Interfaces;

public interface IGet <T>
{
    List<T> GetAll();
    T? GetById(string id);
    T? GetByName(string name);
}