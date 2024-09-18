using SmartCitySecurity.Models;

namespace SmartCitySecurity.Services
{
    public interface IRecursoService
    {
        Task<IEnumerable<RecursosPoliciais>> ListarRecursos();
        Task<RecursosPoliciais> ObterRecursoPorId(int id);
        Task CriarRecurso(RecursosPoliciais recurso);
        Task AtualizarRecurso(RecursosPoliciais recurso);
        Task DeletarRecurso(int id);
        Task AtualizarStatusDisponibilidade();
    }
}
