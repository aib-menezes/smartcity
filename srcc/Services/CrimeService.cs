using SmartCitySecurity.Models;
using SmartCitySecurity.srcc.Repository.Implementations;

namespace SmartCitySecurity.srcc.Services
{
    public class CrimeService : ICrimeService
    {
        private readonly ICrimeRepository _crimeRepository;

        public CrimeService(ICrimeRepository crimeRepository)
        {
            _crimeRepository = crimeRepository;
        }

        public async Task<IEnumerable<ModeloCrime>> ListarCrimes()
        {
            return await _crimeRepository.GetAll();
        }

        public async Task<ModeloCrime> ObterCrimePorId(int id)
        {
            return await _crimeRepository.GetById(id);
        }

        public async Task CriarCrime(ModeloCrime crime)
        {
            await _crimeRepository.Add(crime);
        }

        public async Task AtualizarCrime(ModeloCrime crime)
        {
            await _crimeRepository.Update(crime);
        }

        public async Task DeletarCrime(int id)
        {
            var crime = await _crimeRepository.GetById(id);
            if (crime != null)
            {
                await _crimeRepository.Delete(crime);
            }
        }
    }
}
