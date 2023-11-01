using Authentication.Domain.Core.Models;
using Authentication.Domain.Funcionarios.FuncionarioXHabilidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Funcionarios.Habilidades
{
    public class Habilidade : Entity<Habilidade>
    {
        public Habilidade()
        {
            FuncionarioXHabilidades = new HashSet<FuncionarioXHabilidade>();
        }
        public string Nome { get; set; }
        public ICollection<FuncionarioXHabilidade> FuncionarioXHabilidades { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
