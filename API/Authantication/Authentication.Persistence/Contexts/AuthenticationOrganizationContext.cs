using Authentication.Domain.Funcionarios;
using Authentication.Domain.Funcionarios.FuncionarioXHabilidades;
using Authentication.Domain.Funcionarios.Habilidades;
using Authentication.Persistence.Extensions;
using Authentication.Persistence.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Persistence.Contexts
{
    public partial class AuthenticationOrganizationContext: DbContext
    {
        public virtual DbSet<Habilidade> Habilidade { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }

        public AuthenticationOrganizationContext()
        {
        }

        public AuthenticationOrganizationContext(DbContextOptions<AuthenticationOrganizationContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            //optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new DefaultMap<FuncionarioXHabilidade>());
            modelBuilder.AddConfiguration(new DefaultMap<Habilidade>());
            modelBuilder.AddConfiguration(new DefaultMap<Funcionario>());

            modelBuilder.AddConfiguration(new HabilidadeMap());
            modelBuilder.AddConfiguration(new FuncionarioMap());
            modelBuilder.AddConfiguration(new FuncionarioXHabilidadeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
