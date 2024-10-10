namespace SmartCitySecurity.Models
{
    public class RecursosPoliciais
    {

        public int RecursoId { get; set; }

        public string Recurso { get; set; }

        public string TipoRecurso { get; set; }

        public bool Disponibilidade { get; set; }

        public string LocalizacaoRecurso { get; set; }

        public string NomeAgentes { get; set; }

        public string Delegacias { get; private set; }

        public int Capacidade { get; set; }

        public DateTime Aquisicao { get; set; }

        public DateTime UltimaManutencao { get; set; }

        public string ReponsavelManutencao { get; set; }

        // Propriedades de chave estrangeira
        public int EmergenciaID { get; set; }
        public ModeloEmergencia Emergencia { get; set; }


        public RecursosPoliciais()
        {

        }

        public RecursosPoliciais(int recursoId, string recurso, string tipoRecurso, bool disponibilidade, string localizacaoRecurso, string nomeAgentes, string delegacias, int capacidade, DateTime aquisicao, DateTime ultimaManutencao, string reponsavelManutencao, int emergenciaID, ModeloEmergencia emergencia)
        {
            RecursoId = recursoId;
            Recurso = recurso;
            TipoRecurso = tipoRecurso;
            Disponibilidade = disponibilidade;
            LocalizacaoRecurso = localizacaoRecurso;
            NomeAgentes = nomeAgentes;
            Delegacias = delegacias;
            Capacidade = capacidade;
            Aquisicao = aquisicao;
            UltimaManutencao = ultimaManutencao;
            ReponsavelManutencao = reponsavelManutencao;
            EmergenciaID = emergenciaID;
            Emergencia = emergencia;
        }
    }
}
