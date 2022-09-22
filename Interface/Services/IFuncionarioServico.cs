using RH.DTO;
using RH.Models;

namespace RH.Interface.Services
{
  public interface IFuncionarioServico
  {

    IList<FuncionarioDto> ObterTodos();
    FuncionarioDto ObterPorId(int id);
    Funcionario ObterPorUsuarioESenha(FuncionarioLoginDto funcionario);
    void CadastrarFuncionario(FuncionarioDto funcionario);
    void Editar(FuncionarioDto funcionario);
    void Excluir(FuncionarioDto funcionario);
  }
}