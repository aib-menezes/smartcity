using SmartCitySecurity.Models;

namespace SmartCitySecurity.Data.Repository
{
    public interface IRecursoPolicialRepository
    {
        Task<IEnumerable<RecursosPoliciais>> GetAll();
        Task<RecursosPoliciais> GetById(int id);
        Task Add(RecursosPoliciais recursosPoliciais);
        Task Update(RecursosPoliciais recursosPoliciais);
        Task Delete(int id);
        Task Delete(RecursosPoliciais recurso);
    }
}
