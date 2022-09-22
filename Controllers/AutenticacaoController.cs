using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RH.Services;
using RH.DTO;
using RH.Repositories;
using RH.Interface.Services;


namespace RH.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class Autenticacoescontroller : ControllerBase
  {
    private readonly IFuncionarioServico _funcionarioServico;

    public Autenticacoescontroller(IFuncionarioServico funcionarioServico)
    {
      _funcionarioServico = funcionarioServico;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login(
         [FromBody] FuncionarioLoginDto dto
     )
    {
      var funcionario = _funcionarioServico.ObterPorUsuarioESenha(dto);
      if (funcionario == null)
        return StatusCode(StatusCodes.Status401Unauthorized);

      var token = TokenService.GenerateToken(funcionario);
      var refreshToken = TokenService.GenerateRefreshToken();
      TokenService.SaveRefreshToken(funcionario.Nome, refreshToken);

      return Ok(new
      {
        token,
        refreshToken
      });
    }

    [HttpPost]
    [Route("refresh-token")]
    [AllowAnonymous]
    public IActionResult Refresh(
        [FromQuery] string token,
        [FromQuery] string refreshToken
    )
    {
      var principal = TokenService.GetPrincipalFromExpiredToken(token);
      var username = principal.Identity.Name;
      var savedRefreshToken = TokenService.GetRefreshToken(username);

      if (savedRefreshToken != refreshToken)
        throw new SecurityTokenException("Invalid Token");

      var newToken = TokenService.GenerateToken(principal.Claims);
      var newRefreshToken = TokenService.GenerateRefreshToken();
      TokenService.DeleteRefreshToken(username, refreshToken);
      TokenService.SaveRefreshToken(username, newRefreshToken);

      return Ok(new
      {
        newToken,
        newRefreshToken
      });

    }
  }
}
