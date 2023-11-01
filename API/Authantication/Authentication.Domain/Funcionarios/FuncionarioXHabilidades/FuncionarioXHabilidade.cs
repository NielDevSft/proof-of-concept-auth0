using Authentication.Domain.Core.Models;
using Authentication.Domain.Funcionarios.Habilidades;

namespace Authentication.Domain.Funcionarios.FuncionarioXHabilidades
{
    public class FuncionarioXHabilidade : Entity<FuncionarioXHabilidade>
    {
        public int IdFuncionario { get; set; }
        public int IdHabilidade { get; set; }

        public Funcionario IdFuncionarioNavigation { get; set; }
        public Habilidade IdHabilidadeNavigation { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
