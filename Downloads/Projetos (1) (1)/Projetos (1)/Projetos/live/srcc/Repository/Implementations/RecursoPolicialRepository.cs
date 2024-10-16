using SmartCitySecurity.Data.Contexts;
using SmartCitySecurity.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartCitySecurity.Data.Repository
{
    public class RecursoPolicialRepository : IRecursoPolicialRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RecursoPolicialRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public async Task Add(RecursosPoliciais recursoPolicial)
        {
            await _databaseContext.RecursosPoliciais.AddAsync(recursoPolicial);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var recurso = await _databaseContext.RecursosPoliciais.FindAsync(id);
            if (recurso != null)
            {
                _databaseContext.RecursosPoliciais.Remove(recurso);
                await _databaseContext.SaveChangesAsync();
            }
        }

        public Task Delete(RecursosPoliciais recurso)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RecursosPoliciais>> GetAll()
        {
            return await _databaseContext.RecursosPoliciais.ToListAsync();
        }

        public async Task<RecursosPoliciais> GetById(int id)
        {
            return await _databaseContext.RecursosPoliciais.FindAsync(id);
        }

        public async Task Update(RecursosPoliciais recursoPolicial)
        {
            _databaseContext.RecursosPoliciais.Update(recursoPolicial);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
