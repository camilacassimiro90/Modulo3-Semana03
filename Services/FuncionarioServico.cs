using RH.Interface.Services;
using RH.DTO;
using RH.Interfaces.Repositorios;
using RH.Models;

namespace RH.Services
{
  public class FuncionarioServico : IFuncionarioServico
  {

    private readonly IFuncionarioRepositorio _funcionarioRepositorio;

    public FuncionarioServico(IFuncionarioRepositorio funcionarioRepositorio)
    {
      _funcionarioRepositorio = funcionarioRepositorio;
    }

    public void CadastrarFuncionario(FuncionarioDto funcionario)
    {
      if (_funcionarioRepositorio.ExisteFuncionario(new Funcionario(funcionario)))
      {
        throw new Exception("Funcionario já Cadastrado!");

        _funcionarioRepositorio.CadastrarFuncionario(new Funcionario(funcionario));
      }
    }

    public void Editar(FuncionarioDto funcionario)
    {
      _funcionarioRepositorio.Editar(new Funcionario(funcionario));
    }

    public FuncionarioDto ObterPorId(int id)
    {
      return new FuncionarioDto(_funcionarioRepositorio.ObterPorId(id));
    }

    public Funcionario ObterPorUsuarioESenha(FuncionarioLoginDto funcionario)
    {
      return _funcionarioRepositorio.ObterPorUsuarioESenha(funcionario.Nome, funcionario.Senha);
    }

    public IList<FuncionarioDto> ObterTodos()
    {
      return _funcionarioRepositorio.ObterTodos().Select(f => new FuncionarioDto(f)).ToList();
    }

    public void Excluir(FuncionarioDto funcionario)
    {
      _funcionarioRepositorio.Excluir(new Funcionario(funcionario));
    }


  }
}