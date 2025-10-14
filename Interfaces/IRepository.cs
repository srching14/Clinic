
namespace HospitalDoctorsPatients.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        T? GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}