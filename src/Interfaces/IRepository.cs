namespace src.Interfaces;

public interface IRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Get(Func<T, bool> predicate);
    void Create(T item);
    void Remove(T item);
    void Update(T item);
}