using SmartCitySecurity.Data.Repository;
using SmartCitySecurity.Models;

namespace SmartCitySecurity.Services
{
    public class RecursoService : IRecursoService
    {
        private readonly IRecursoPolicialRepository _recursoRepository;

        public RecursoService(IRecursoPolicialRepository recursoRepository)
        {
            _recursoRepository = recursoRepository;
        }

        public async Task<IEnumerable<RecursosPoliciais>> ListarRecursos() => await _recursoRepository.GetAll();

        public async Task<RecursosPoliciais> ObterRecursoPorId(int id) => await _recursoRepository.GetById(id);

        public async Task CriarRecurso(RecursosPoliciais recurso) => await _recursoRepository.Add(recurso);

        public async Task AtualizarRecurso(RecursosPoliciais recurso) => await _recursoRepository.Update(recurso);

        public async Task DeletarRecurso(int id)
        {
            var recurso = await _recursoRepository.GetById(id);
            if (recurso != null)
            {
                await _recursoRepository.Delete(recurso);
            }
        }

        public async Task AtualizarStatusDisponibilidade()
        {
            var tempoLimite = TimeSpan.FromHours(24);
            var recursos = await _recursoRepository.GetAll();

            foreach (var recurso in recursos)
            {
                if (DateTime.UtcNow - recurso.UltimaManutencao > tempoLimite)
                {
                    recurso.Disponibilidade = false;
                    await _recursoRepository.Update(recurso);
                }
            }
        }
    }
}
