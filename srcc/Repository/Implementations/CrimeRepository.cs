using Microsoft.EntityFrameworkCore;
using SmartCitySecurity.Data.Contexts;
using SmartCitySecurity.Models;

namespace SmartCitySecurity.srcc.Repository.Implementations
{
    public class CrimeRepository : ICrimeRepository
    {
        private readonly DatabaseContext _context;

        public CrimeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ModeloCrime>> GetAll()
        {
            return await _context.Crimes.ToListAsync();
        }

        public async Task<ModeloCrime> GetById(int id)
        {
            return await _context.Crimes.FindAsync(id);
        }

        public async Task Add(ModeloCrime crime)
        {
            await _context.Crimes.AddAsync(crime);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ModeloCrime crime)
        {
            _context.Crimes.Update(crime);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ModeloCrime crime)
        {
            _context.Crimes.Remove(crime);
            await _context.SaveChangesAsync();
        }
    }
}
