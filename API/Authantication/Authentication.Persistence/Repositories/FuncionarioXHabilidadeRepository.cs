using Authentication.Domain.Funcionarios.FuncionarioXHabilidades;
using Authentication.Domain.Funcionarios.FuncionarioXHabilidades.Repository;
using Authentication.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Persistence.Repositories
{
    public class FuncionarioXHabilidadeRepository : Repository<FuncionarioXHabilidade>, IFuncionarioXHabilidadeRepository
    {
        public FuncionarioXHabilidadeRepository(AuthenticationOrganizationContext context) : base(context)
        {

        }
    }
}
