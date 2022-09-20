using RH.Enums;
using RH.Models;

namespace RH.DTO
{
  public class FuncionarioDto
  {
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }
    public Permissoes Permissao { get; set; }
    public decimal Salario { get; set; }

    public FuncionarioDto()
    {

    }
    public FuncionarioDto(Funcionario funcionario)
    {
      Nome = funcionario.Nome;
      Senha = funcionario.Senha;
      Permissao = funcionario.Permissao;
      Salario = funcionario.Salario;
    }
  }
}