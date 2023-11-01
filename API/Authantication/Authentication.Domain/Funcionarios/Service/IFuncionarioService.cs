using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Funcionarios.Service
{
    public interface IFuncionarioService
    {
        IEnumerable<object> ListarPorFiltro(string nomeCompleto, byte? idadeMinima, byte? idadeLimite, byte? sexo, byte[] habilidades);
        void Cadastrar(Funcionario funcionario);
        void Atualizar(Funcionario funcionario);
    }
}
