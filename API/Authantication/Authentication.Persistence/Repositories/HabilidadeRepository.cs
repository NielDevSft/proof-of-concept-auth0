using Authentication.Domain.Funcionarios.Habilidades;
using Authentication.Domain.Funcionarios.Habilidades.Repository;
using Authentication.Persistence.Contexts;

namespace Authentication.Persistence.Repositories
{
    public class HabilidadeRepository : Repository<Habilidade>, IHabilidadeRepository
    {
        public HabilidadeRepository(AuthenticationOrganizationContext context) : base(context)
        {
        }
    }
}
