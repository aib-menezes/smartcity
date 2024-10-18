using SmartCitySecurity.Data.Repository;
using SmartCitySecurity.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCitySecurity.Services
{
    public class RecursoService
    {
        private readonly IRecursoPolicialRepository _repository;

        public RecursoService(IRecursoPolicialRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RecursosPoliciais>> ListarRecursos()
        {
            return await _repository.GetAll();
        }

        public async Task<RecursosPoliciais> ObterRecursoPorId(int id)
        {
            var recurso = await _repository.GetById(id);
            if (recurso == null)
            {
                throw new Exception($"Recurso com ID {id} não encontrado.");
            }
            return recurso;
        }

        public async Task CriarRecurso(RecursosPoliciais recurso)
        {
            if (recurso == null) throw new ArgumentNullException(nameof(recurso));
            await _repository.Add(recurso);
        }

        public async Task AtualizarRecurso(RecursosPoliciais recurso)
        {
            var existingRecurso = await _repository.GetById(recurso.RecursoId);
            if (existingRecurso == null) throw new Exception($"Recurso com ID {recurso.RecursoId} não encontrado.");
            await _repository.Update(recurso);
        }

        public async Task DeletarRecurso(int id)
        {
            var recurso = await _repository.GetById(id);
            if (recurso == null) throw new Exception($"Recurso com ID {id} não encontrado para exclusão.");
            await _repository.Delete(recurso);
        }

        public async Task AtualizarStatusDisponibilidade()
        {
            var recursos = await _repository.GetAll();
            foreach (var recurso in recursos)
            {
                // Lógica para atualizar a disponibilidade
                // Exemplo: 
                if (recurso.UltimaManutencao < DateTime.UtcNow.AddDays(-1))
                {
                    recurso.Disponibilidade = false;
                    await _repository.Update(recurso);
                }
            }
        }
    }
}
