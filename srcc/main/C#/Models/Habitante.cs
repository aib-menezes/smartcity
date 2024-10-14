namespace SmartCitySecurity.Models
{
    public class Habitante
    {
        public int HabitanteId { get; set; }    
        public string HabitanteNome { get; set; }
        public string Genero { get; set; }
        public string EnderecoHabitante { get; set; }
        public DateTime Nascimento { get; set; }
        public int Cpf {  get; set; }
        public int Telefone { get; set; }
        public string Observacoes { get; set; }
        public string HistoricoCriminal { get;  set; }


        public Habitante()
        {
            
        }

        public Habitante(int habitanteId, string habitanteNome, string genero, string enderecoHabitante, DateTime nascimento, int cpf, int telefone, string observacoes, string historicoCriminal)
        {
            HabitanteId = habitanteId;
            HabitanteNome = habitanteNome;
            Genero = genero;
            EnderecoHabitante = enderecoHabitante;
            Nascimento = nascimento;
            Cpf = cpf;
            Telefone = telefone;
            Observacoes = observacoes;
            HistoricoCriminal = historicoCriminal;
        }
    }
}
