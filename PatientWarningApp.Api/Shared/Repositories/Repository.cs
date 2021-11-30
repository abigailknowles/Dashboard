using System.Linq;

namespace PatientWarningApp.Api.Shared.Repositories
{
    public interface Repository<T>
    {
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
        T Read(int id);
        IQueryable<T> ReadAll();
    }
}
