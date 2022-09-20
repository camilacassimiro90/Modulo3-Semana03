using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RH.DTO;
using RH.Models;
using RH.Repositories;

namespace RH.Controller
{

  [Route("[controller]")]
  public class FuncionarioController : ControllerBase
  {

    [HttpGet]
    public IActionResult ObterTodos()
    {
      var funcionarios = FuncionarioRepository.ObterTodos();
      return Ok(funcionarios);
    }

    [HttpPost]
    public IActionResult Adicionar([FromBody] FuncionarioDto funcionario)
    {
      var novoFuncionario = new Funcionario
      {
        Nome = funcionario.Nome,
        Senha = funcionario.Senha,
        Salario = funcionario.Salario,
        Permissao = funcionario.Permissao
      };

      FuncionarioRepository.Adicionar(novoFuncionario);
      return StatusCode(StatusCodes.Status201Created);
    }

    [Authorize(Roles = "Adm, Gerente")]
    [HttpDelete("excluir-funcionario/{id}")]
    public IActionResult ExcluirFuncionario([FromRoute] string id)
    {
      var funcionario = FuncionarioRepository.ObterPorId(id);
      if (funcionario.Permissao == Enums.Permissoes.Adm || funcionario.Permissao == Enums.Permissoes.Gerente)
        return StatusCode(StatusCodes.Status401Unauthorized);

      FuncionarioRepository.Excluir(funcionario);
      return NoContent();
    }


    //  EXCLUIR GERENTE
    [Authorize(Roles = "Adm")]
    [HttpDelete("excluir-gerente/{id}")]
    public IActionResult ExcluirGerente([FromRoute] string id)
    {
      var funcionario = FuncionarioRepository.ObterPorId(id);
      FuncionarioRepository.Excluir(funcionario);
      return NoContent();
    }

    [Authorize(Roles = "Gerente")]
    [HttpPut("alterar-salario/{id}")]
    public IActionResult AlterarSalario(
       [FromRoute] string id,
       [FromBody] SalarioDto salario
   )
    {
      var funcionarioSalario = FuncionarioRepository.ObterPorId(id);
      funcionarioSalario.Salario = salario.Salario;
      FuncionarioRepository.Editar(funcionarioSalario);
      return Ok();
    }





  }
}