using Authentication.Domain.Core.Interfaces;
using Authentication.Domain.Funcionarios.Enums;

namespace Authentication.Domain.Funcionarios.Repository
{
    public interface IFuncionarioRepository: IRepository<Funcionario>
    {
        object ListFilter(string nomeCompleto, byte? idadeMinima,byte? idadeLimite, SexoEnum sexo, byte? habilidades);

    }
}
