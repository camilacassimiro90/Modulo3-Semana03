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

    [HttpPost]
    public IActionResult Adicionar([FromBody] FuncionarioDto funcionario)
    {
      var novoFuncionario = new Funcionario
      {
        Nome = funcionario.Nome,
        Senha = funcionario.Senha,
        Salario = funcionario.Salario
      };

      FuncionarioRepository.Adicionar(novoFuncionario);
      return StatusCode(StatusCodes.Status201Created);
    }

    [HttpDelete]
    public void Excluir(Funcionario funcionario)
    {
      FuncionarioRepository.Excluir(funcionario);
    }


  }
}