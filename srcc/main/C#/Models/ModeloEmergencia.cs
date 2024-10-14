namespace SmartCitySecurity.Models
{
    public class ModeloEmergencia
    {
        public int EmergenciaId { get; set; }

        public string TipoEmergencia { get; set; }    

        public DateTime DataEmergencia { get; set; }

        public string LocalEmergencia { get; set; }    

        public string Descricao { get; set; }

        public string StatusEmergencia { get; set; }

        // Propriedades de chave estrangeira
        public int HabitanteId { get; set; }
        public Habitante Habitante { get; set; }
        public int SistemaVigilanciaId { get; set; }
        public ModeloSistemaVigilancia SistemaVigilancia { get; set; }

        public ModeloEmergencia()
        {
            
        }

        public ModeloEmergencia(int emergenciaId, string tipoEmergencia, DateTime dataEmergencia, string localEmergencia, string descricao, string statusEmergencia, int habitanteId, Habitante habitante, int sistemaVigilanciaId, ModeloSistemaVigilancia sistemaVigilancia)
        {
            EmergenciaId = emergenciaId;
            TipoEmergencia = tipoEmergencia;
            DataEmergencia = dataEmergencia;
            LocalEmergencia = localEmergencia;
            Descricao = descricao;
            StatusEmergencia = statusEmergencia;
            HabitanteId = habitanteId;
            Habitante = habitante;
            SistemaVigilanciaId = sistemaVigilanciaId;
            SistemaVigilancia = sistemaVigilancia;
        }

    }
}
