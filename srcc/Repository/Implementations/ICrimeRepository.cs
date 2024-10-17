using SmartCitySecurity.Models;

namespace SmartCitySecurity.srcc.Repository.Implementations
{
    public interface ICrimeRepository
    {
        Task<IEnumerable<ModeloCrime>> GetAll();
        Task<ModeloCrime> GetById(int id);
        Task Add(ModeloCrime crime);
        Task Update(ModeloCrime crime);
        Task Delete(ModeloCrime crime);
    }
}
