using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain;
using Authentication.Domain.Funcionarios;
using Authentication.Domain.Funcionarios.Enums;
using Authentication.Domain.Funcionarios.Repository;
using Authentication.Persistence.Contexts;

namespace Authentication.Persistence.Repositories
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(AuthenticationOrganizationContext context) : base(context)
        {
        }

        public object ListFilter(string nomeCompleto, byte? idadeMinima, byte? idadeLimite, SexoEnum sexo, byte? habilidade)
        {
            var retorno = GetDataTable("[Almoxarifado].[SP_S_Funcionario]", new System.Collections.Generic.Dictionary<string, object>()
            {
                {"@NomeCompleto", nomeCompleto },
                {"@IdadeMinima", idadeMinima },
                {"@idadeLimite", idadeLimite },
                {"@Sexo", sexo.CompareTo(sexo)},
                {"@Habilidade", habilidade},
            });
            return ConvertTableToObject(retorno);
        }
    }
}
