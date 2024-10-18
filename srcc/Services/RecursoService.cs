using SmartCitySecurity.Data.Repository;
using SmartCitySecurity.Models;
using System;
<<<<<<< HEAD

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
=======
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
>>>>>>> developp
        }

        public async Task<RecursosPoliciais> ObterRecursoPorId(int id)
        {
<<<<<<< HEAD
            var recurso = await _recursoRepository.GetById(id);
=======
            var recurso = await _repository.GetById(id);
>>>>>>> developp
            if (recurso == null)
            {
                throw new Exception($"Recurso com ID {id} não encontrado.");
            }
            return recurso;
        }

        public async Task CriarRecurso(RecursosPoliciais recurso)
        {
<<<<<<< HEAD
            if (recurso == null)
            {
                throw new ArgumentNullException(nameof(recurso), "O recurso não pode ser nulo.");
            }
            await _recursoRepository.Add(recurso);
=======
            if (recurso == null) throw new ArgumentNullException(nameof(recurso));
            await _repository.Add(recurso);
>>>>>>> developp
        }

        public async Task AtualizarRecurso(RecursosPoliciais recurso)
        {
<<<<<<< HEAD
            var recursoExistente = await _recursoRepository.GetById(recurso.RecursoId);
            if (recursoExistente == null)
            {
                throw new Exception($"Recurso com ID {recurso.RecursoId} não encontrado para atualização.");
            }
            await _recursoRepository.Update(recurso);
=======
            var existingRecurso = await _repository.GetById(recurso.RecursoId);
            if (existingRecurso == null) throw new Exception($"Recurso com ID {recurso.RecursoId} não encontrado.");
            await _repository.Update(recurso);
>>>>>>> developp
        }

        public async Task DeletarRecurso(int id)
        {
<<<<<<< HEAD
            var recurso = await _recursoRepository.GetById(id);
            if (recurso == null)
            {
                throw new Exception($"Recurso com ID {id} não encontrado para exclusão.");
            }
            await _recursoRepository.Delete(recurso);
=======
            var recurso = await _repository.GetById(id);
            if (recurso == null) throw new Exception($"Recurso com ID {id} não encontrado para exclusão.");
            await _repository.Delete(recurso);
>>>>>>> developp
        }

        public async Task AtualizarStatusDisponibilidade()
        {
<<<<<<< HEAD
            var tempoLimite = TimeSpan.FromHours(24);
            var recursos = await _recursoRepository.GetAll();

            foreach (var recurso in recursos)
            {
                if (DateTime.UtcNow - recurso.UltimaManutencao > tempoLimite)
                {
                    recurso.Disponibilidade = false;
                    await _recursoRepository.Update(recurso);
=======
            var recursos = await _repository.GetAll();
            foreach (var recurso in recursos)
            {
                // Lógica para atualizar a disponibilidade
                // Exemplo: 
                if (recurso.UltimaManutencao < DateTime.UtcNow.AddDays(-1))
                {
                    recurso.Disponibilidade = false;
                    await _repository.Update(recurso);
>>>>>>> developp
                }
            }
        }
    }
}
