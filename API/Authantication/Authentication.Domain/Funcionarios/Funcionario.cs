using Authentication.Domain.Core.Models;
using Authentication.Domain.Funcionarios.Enums;
using Authentication.Domain.Funcionarios.FuncionarioXHabilidades;
using Authentication.Domain.Funcionarios.Habilidades;
using System;
using System.Collections.Generic;

namespace Authentication.Domain.Funcionarios
{
    public class Funcionario : Entity<Funcionario>
    {
        public Funcionario()
        {
            FuncionarioXHabilidades = new HashSet<FuncionarioXHabilidade>();
        }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public SexoEnum Sexo { get; set; }
        public ICollection<FuncionarioXHabilidade> FuncionarioXHabilidades { get; set; }
        public override bool IsValid()
        {
            return true;
        }
    }
}
