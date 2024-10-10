namespace SmartCitySecurity.Models
{
    public class ModeloCrime
    {
        public int CrimeId { get; set; } 

        public string NomeCrime { get; set; }
        public string TipoCrime { get; set; }
        public DateTime Data { get; set; }
        public string Localizacao { get; set; }
        public string StatusCrime { get; set; }
        public string Gravidade { get; set; }
        public  string ArmaUtilizada { get; set; }    
        public string Descricao { get; set; }

        public ModeloCrime()
        {
            
        }

        public ModeloCrime(int crimeId, string nomeCrime, string tipoCrime, DateTime data, string localizacao, string statusCrime, string gravidade, string armaUtilizada, string descricao)
        {
            CrimeId = crimeId;
            NomeCrime = nomeCrime;
            TipoCrime = tipoCrime;
            Data = data;
            Localizacao = localizacao;
            StatusCrime = statusCrime;
            Gravidade = gravidade;
            ArmaUtilizada = armaUtilizada;
            Descricao = descricao;
        }
    }
}
