namespace SmartCitySecurity.Models
{
    public class ModeloSistemaVigilancia
    {

        public int SistemaVigilanciaId { get; set; }

        public string SistemaNome { get; set; }

        public string SistemaLocalizacao { get; set; }

        public string Descricao { get; set; }

        public string Status { get; set; }   

        public string ResolucaVideo { get; set; }

        public DateTime DataVideo { get; set; }

        public DateTime UltimaManutencao { get; set; }

        public DateTime Instalacao { get; set; }

        public string ResponsavelManutencao { get; set; }

        public string RegistroIncidentes { get; set; }


        public ModeloSistemaVigilancia()
        {
            
        }

        public ModeloSistemaVigilancia(int sistemaVigilanciaId, string sistemaNome, string sistemaLocalizacao, string descricao, string status, string resolucaVideo, DateTime dataVideo, DateTime ultimaManutencao, DateTime instalacao, string responsavelManutencao, string registroIncidentes)
        {
            SistemaVigilanciaId = sistemaVigilanciaId;
            SistemaNome = sistemaNome;
            SistemaLocalizacao = sistemaLocalizacao;
            Descricao = descricao;
            Status = status;
            ResolucaVideo = resolucaVideo;
            DataVideo = dataVideo;
            UltimaManutencao = ultimaManutencao;
            Instalacao = instalacao;
            ResponsavelManutencao = responsavelManutencao;
            RegistroIncidentes = registroIncidentes;
        }
    }
}
