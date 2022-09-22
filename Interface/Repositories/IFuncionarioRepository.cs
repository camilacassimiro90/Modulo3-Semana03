using RH.DTO;
using RH.Models;

namespace RH.Interfaces.Repositorios
{
  public interface IFuncionarioRepositorio
  {
    IList<Funcionario> ObterTodos();
    Funcionario ObterPorId(int id);
    Funcionario ObterPorUsuarioESenha(string nome, string senha);
    void CadastrarFuncionario(Funcionario funcionario);
    void Editar(Funcionario funcionario);
    void Excluir(Funcionario funcionario);
    bool ExisteFuncionario(Funcionario funcionario);

  }
}