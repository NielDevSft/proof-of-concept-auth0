using System.ComponentModel;

namespace Authentication.Domain.Funcionarios.Enums
{
    public enum SexoEnum: byte
    {
        [Description("Feminino")]
        Feminino = 0,
        [Description("Masculino")]
        Masculino = 1,
        [Description("Outros")]
        Outros = 255
    }
}
