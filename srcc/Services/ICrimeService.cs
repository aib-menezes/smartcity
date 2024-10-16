using SmartCitySecurity.Models;

namespace SmartCitySecurity.srcc.Services
{
    public interface ICrimeService
    {
        Task<IEnumerable<ModeloCrime>> ListarCrimes();
        Task<ModeloCrime> ObterCrimePorId(int id);
        Task CriarCrime(ModeloCrime crime);
        Task AtualizarCrime(ModeloCrime crime);
        Task DeletarCrime(int id);
    }
}
