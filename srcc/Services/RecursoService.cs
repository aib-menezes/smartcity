using SmartCitySecurity.Data.Repository;
using SmartCitySecurity.Models;
using System;

namespace SmartCitySecurity.Services
{
    public class RecursoService : IRecursoService
    {
        private readonly IRecursoPolicialRepository _recursoRepository;

        public RecursoService(IRecursoPolicialRepository recursoRepository)
        {
            _recursoRepository = recursoRepository;
        }

        public async Task<IEnumerable<RecursosPoliciais>> ListarRecursos()
        {
            return await _recursoRepository.GetAll();
        }

        public async Task<RecursosPoliciais> ObterRecursoPorId(int id)
        {
            var recurso = await _recursoRepository.GetById(id);
            if (recurso == null)
            {
                throw new Exception($"Recurso com ID {id} não encontrado.");
            }
            return recurso;
        }

        public async Task CriarRecurso(RecursosPoliciais recurso)
        {
            if (recurso == null)
            {
                throw new ArgumentNullException(nameof(recurso), "O recurso não pode ser nulo.");
            }
            await _recursoRepository.Add(recurso);
        }

        public async Task AtualizarRecurso(RecursosPoliciais recurso)
        {
            var recursoExistente = await _recursoRepository.GetById(recurso.RecursoId);
            if (recursoExistente == null)
            {
                throw new Exception($"Recurso com ID {recurso.RecursoId} não encontrado para atualização.");
            }
            await _recursoRepository.Update(recurso);
        }

        public async Task DeletarRecurso(int id)
        {
            var recurso = await _recursoRepository.GetById(id);
            if (recurso == null)
            {
                throw new Exception($"Recurso com ID {id} não encontrado para exclusão.");
            }
            await _recursoRepository.Delete(recurso);
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
