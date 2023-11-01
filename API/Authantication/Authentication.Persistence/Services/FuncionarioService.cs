using Authentication.Domain.Funcionarios;
using Authentication.Domain.Funcionarios.Enums;
using Authentication.Domain.Funcionarios.FuncionarioXHabilidades;
using Authentication.Domain.Funcionarios.FuncionarioXHabilidades.Repository;
using Authentication.Domain.Funcionarios.Habilidades.Repository;
using Authentication.Domain.Funcionarios.Repository;
using Authentication.Domain.Funcionarios.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Authentication.Persistence.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        readonly IFuncionarioRepository _funcionarioRepository;
        readonly IFuncionarioXHabilidadeRepository _funcionarioXHabilidadeRepository;
        readonly IHabilidadeRepository _habilidadeRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository,
        IFuncionarioXHabilidadeRepository funcionarioXHabilidadeRepository,
        IHabilidadeRepository habilidadeRepository)
        {
            _funcionarioXHabilidadeRepository = funcionarioXHabilidadeRepository;
            _funcionarioRepository = funcionarioRepository;
            _habilidadeRepository = habilidadeRepository;
        }


        public void Atualizar(Funcionario funcionario)
        {
            if (funcionario.IsValid())
            {
                var funciTemp = _funcionarioRepository.FirstOrDefault(e => e.Id == funcionario.Id && e.Removed == false);

                if (funciTemp == null)
                    throw new Exception("Não foi posssível identificar o usuario a ser alterado.");



                funciTemp.NomeCompleto = funcionario.NomeCompleto;
                funciTemp.DataNascimento = funcionario.DataNascimento;
                funciTemp.Email = funcionario.Email;
                funciTemp.FuncionarioXHabilidades = funciTemp.FuncionarioXHabilidades;


                _funcionarioRepository.Update(funciTemp);
            }
            else
            {
                throw new Exception("Não foi posssível identificar o usuario a ser alterado.");
            }

            try
            {
                _funcionarioRepository.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Não foi posssível fazer atualização.");
            }
        }

        public void Cadastrar(Funcionario funcionario)
        {
            if (funcionario.IsValid())
            {
                _funcionarioRepository.Add(funcionario);
            }
            try
            {
                _funcionarioRepository.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Não foi posssível fazer inclusão.");
            }
        }

        public IEnumerable<object> ListarPorFiltro(string nomeCompleto, byte? idadeMinima, byte? idadeLimite, byte? sexo, byte[] habilidades)
        {

            var listaFuncionario = new List<FuncionarioXHabilidade>();
            var dataInicio = new DateTime(DateTime.Today.Year - Convert.ToInt32(idadeMinima), DateTime.Today.Month, DateTime.Today.Day);
            var dataLimite = new DateTime(DateTime.Today.Year - Convert.ToInt32(idadeLimite), DateTime.Today.Month, DateTime.Today.Day);

            if (habilidades != null && habilidades.Length > 0)
                foreach (var hab in habilidades)
                {
                    var habExistente = _funcionarioXHabilidadeRepository.GetById(Convert.ToInt32(hab));
                    if (habExistente != null)
                    {
                        listaFuncionario.Add(habExistente);
                    }
                }


            listaFuncionario.Where(fxh =>
                fxh.IdFuncionarioNavigation.NomeCompleto.Contains(nomeCompleto) &&
                (fxh.IdFuncionarioNavigation.DataNascimento >= dataInicio && fxh.IdFuncionarioNavigation.DataNascimento <= dataLimite) &&
                fxh.IdFuncionarioNavigation.Sexo.Equals(sexo));

            return listaFuncionario.ToList();
        }
    }
}
