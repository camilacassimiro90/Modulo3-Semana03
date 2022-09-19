using RH.DTO;
using RH.Enums;
using RH.Models;

namespace RH.Repositories
{
  public class FuncionarioRepository
  {
    public static List<Funcionario> funcionarioLista = new List<Funcionario>
  {
    new Funcionario {

     Id = "1",
     Nome = "Camila",
     Senha = "123",
     Salario = 50000m,
     Permissao = Permissoes.Adm

    }
  };

    public static IList<Funcionario> ObterTodos()
    {
      return funcionarioLista;
    }

    public static Funcionario ObterPorId(string id)
    {
      var funcionario = funcionarioLista.Find(f => f.Id == id);
      return funcionario;
    }

    public static Funcionario ObterPorUsuarioESenha(FuncionarioLoginDto funcionario)
    {
      return funcionarioLista.FirstOrDefault(f => f.Nome == funcionario.Nome && f.Senha == funcionario.Senha);
    }

    public static Funcionario Adicionar(Funcionario funcionario)
    {
      funcionario.Id = Guid.NewGuid().ToString();
      funcionarioLista.Add(funcionario);

      return funcionario;

    }

    public void Editar(Funcionario funcionario)
    {
      var funcionarioEd = funcionarioLista.Find(f => f.Id == funcionario.Id);
      funcionarioEd.Update(funcionario);
    }

    public void Excluir(Funcionario funcionario)
    {
      funcionarioLista.RemoveAll(f => f.Id == funcionario.Id);
    }






  }
}



