using Microsoft.EntityFrameworkCore;
using SmartCitySecurity.Models;


namespace SmartCitySecurity.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Habitante> Habitantes { get; set; }
        public virtual DbSet<ModeloCrime> Crimes { get; set; }
        public virtual DbSet<ModeloEmergencia> Emergencias { get; set; }
        public virtual DbSet<ModeloSistemaVigilancia> SistemasVigilancia { get; set; }
        public virtual DbSet<RecursosPoliciais> RecursosPoliciais { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade Habitante
            modelBuilder.Entity<Habitante>(e =>
            {
                e.ToTable("HABITANTE");

                e.HasKey(e => e.HabitanteId);

                e.Property(e => e.HabitanteNome).IsRequired();
                e.Property(e => e.Genero).IsRequired();
                e.Property(e => e.EnderecoHabitante).IsRequired();
                e.Property(e => e.Nascimento).HasColumnType("date");
                e.Property(e => e.Cpf);
                e.Property(e => e.Telefone);
                e.Property(e => e.Observacoes).HasMaxLength(500);
                e.Property(e => e.HistoricoCriminal).IsRequired();

                e.HasIndex(e => e.HabitanteId);

                e.HasIndex(e => new { e.EnderecoHabitante, e.Cpf })
                 .HasDatabaseName("IDX_ENDERECO_CPF");
            });

            // Configuração da entidade ModeloCrime
            modelBuilder.Entity<ModeloCrime>(e =>
            {
                e.ToTable("CRIME");

                e.HasKey(e => e.CrimeId);

                e.Property(e => e.NomeCrime).IsRequired();
                e.Property(e => e.TipoCrime).IsRequired();
                e.Property(e => e.Data).HasColumnType("date");
                e.Property(e => e.Localizacao);
                e.Property(e => e.StatusCrime);
                e.Property(e => e.Gravidade);
                e.Property(e => e.ArmaUtilizada).IsRequired();
                e.Property(e => e.Descricao).HasMaxLength(500);

                e.HasIndex(e => e.CrimeId);

                e.HasIndex(e => new { e.NomeCrime, e.TipoCrime })
                 .HasDatabaseName("IDX_NOME_TIPO");
            });

            // Configuração da entidade ModeloEmergencia
            modelBuilder.Entity<ModeloEmergencia>(e =>
            {
                e.ToTable("EMERGENCIA");

                e.HasKey(e => e.EmergenciaId);

                e.Property(e => e.TipoEmergencia).IsRequired();
                e.Property(e => e.DataEmergencia).HasColumnType("date");
                e.Property(e => e.LocalEmergencia).IsRequired();
                e.Property(e => e.Descricao).HasMaxLength(500);
                e.Property(e => e.StatusEmergencia);
                e.Property(e => e.HabitanteId).IsRequired();
                e.Property(e => e.SistemaVigilanciaId).IsRequired();

                e.HasIndex(e => e.EmergenciaId);

                e.HasIndex(e => new { e.TipoEmergencia, e.DataEmergencia })
                 .HasDatabaseName("IDX_TIPO_DATA");

                e.HasOne(e => e.Habitante)
                  .WithMany()
                  .HasForeignKey(e => e.HabitanteId);

                e.HasOne(e => e.SistemaVigilancia)
                  .WithMany()
                  .HasForeignKey(e => e.SistemaVigilanciaId);
            });

            // Configuração da entidade ModeloSistemaVigilancia
            modelBuilder.Entity<ModeloSistemaVigilancia>(e =>
            {
                e.ToTable("SISTEMA_VIGILANCIA");
                e.HasKey(e => e.SistemaVigilanciaId);
                e.Property(e => e.SistemaNome).IsRequired();
                e.Property(e => e.SistemaLocalizacao).IsRequired();
                e.Property(e => e.Descricao).HasMaxLength(500);
                e.Property(e => e.Status);
                e.Property(e => e.ResolucaVideo);
                e.Property(e => e.DataVideo).HasColumnType("date");
                e.Property(e => e.UltimaManutencao).HasColumnType("date");
                e.Property(e => e.Instalacao).HasColumnType("date");
                e.Property(e => e.ResponsavelManutencao);
                e.Property(e => e.RegistroIncidentes);

                e.HasIndex(e => e.SistemaVigilanciaId);

                e.HasIndex(e => new { e.SistemaNome, e.SistemaLocalizacao })
                 .HasDatabaseName("IDX_NOME_LOCAL");
            });

            // Configuração da entidade RecursosPoliciais
            modelBuilder.Entity<RecursosPoliciais>(e =>
            {
                e.ToTable("RECURSOS_POLICIAIS");

                e.HasKey(e => e.RecursoId);

                e.Property(e => e.Recurso).IsRequired();
                e.Property(e => e.TipoRecurso).IsRequired();
                e.Property(e => e.Disponibilidade).IsRequired();
                e.Property(e => e.LocalizacaoRecurso);
                e.Property(e => e.NomeAgentes);
                e.Property(e => e.Delegacias).IsRequired();
                e.Property(e => e.Capacidade);
                e.Property(e => e.Aquisicao).HasColumnType("date");
                e.Property(e => e.UltimaManutencao).HasColumnType("date");
                e.Property(e => e.ReponsavelManutencao);

                e.HasIndex(e => e.RecursoId);

                e.HasIndex(e => new { e.Recurso, e.Disponibilidade })
                 .HasDatabaseName("IDX_RECURSO_DISPONIBILIDADE");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
