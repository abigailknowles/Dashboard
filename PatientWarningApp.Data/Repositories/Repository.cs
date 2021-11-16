namespace PatientWarningApp.Data.Repositories
{
    public interface Repository<T>
    {
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
        T Read(T entity);
    }
}