using Microsoft.AspNetCore.Mvc;
using ProjetoPet.Account;
using ProjetoPet.DTOs;
using ProjetoPet.Models;
using ProjetoPet.Services;

namespace ProjetoPet.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly IAuthenticate _authenticateService;
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IAuthenticate authenticateService, IUsuarioService usuarioService)
    {
        _authenticateService = authenticateService;
        _usuarioService = usuarioService;
    }

    [HttpPost("registro")]
    public async Task<ActionResult<UserToken>> Incluir(UsuarioDTO usuarioDTO)
    {
        if (usuarioDTO == null)
        {
            return BadRequest("Dados inválidos");
        }

        var emailExiste = await _authenticateService.UserExiste(usuarioDTO.Email);

        if (emailExiste)
        {
            return BadRequest("Este email já possui um cadastro.");
        }



        var usuario = await _usuarioService.Incluir(usuarioDTO);
        if (usuario == null)
        {
            return BadRequest("Ocorreu um erro ao cadastrar.");
        }

        var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);
        return new UserToken
        {
            Token = token
        };
    }
}
