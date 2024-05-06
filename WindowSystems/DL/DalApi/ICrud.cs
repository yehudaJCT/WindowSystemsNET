namespace WindowSystems.DL.DalApi;

public interface ICrud<T>
{
    public int Create(T entity);
    public Task<T> Read(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public IEnumerable<T> ReadAll(Func<T, bool>? func = null);
    public T ReadObject(Func<T, bool>? func);

}
