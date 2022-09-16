using RH.Enums;
using RH.DTO;

namespace RH.Models;

public class Funcionario
{
  public string Id { get; set; }
  public string Nome { get; set; }
  public string Senha { get; set; }
  public decimal Salario { get; set; }
  public Permissoes Permissao { get; set; }

  public Funcionario()
  {

  }
  public Funcionario(FuncionarioDto funcionario)
  {
    Id = funcionario.Id;
    Nome = funcionario.Nome;
    Senha = funcionario.Senha;
    Salario = funcionario.Salario;
    Permissao = funcionario.Permissao;
  }

  public void Update(FuncionarioDto funcionario)
  {
    Nome = funcionario.Nome;
    Senha = funcionario.Senha;
    Permissao = funcionario.Permissao;
    Salario = funcionario.Salario;
  }
  public void Update(Funcionario funcionario)
  {
    Nome = funcionario.Nome;
    Senha = funcionario.Senha;
    Permissao = funcionario.Permissao;
    Salario = funcionario.Salario;
  }

}
