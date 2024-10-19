using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoPet.Account;
using ProjetoPet.DTOs;
using ProjetoPet.Models;
using ProjetoPet.Services;

namespace ProjetoPet.Controllers;


[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
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

    [HttpPost("login")]
    public async Task<ActionResult<UserToken>> Selecionar (LoginModel loginModel)
    {
        var existe = await _authenticateService.UserExiste(loginModel.Email);
        if (!existe)
        {
            return BadRequest("Usuário não existe.");
        }

        var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);
        if (!result) 
        {
            return BadRequest("Teste.");
        }

        var usuario = await _authenticateService.GetUserByEmail(loginModel.Email);

        var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

        return new UserToken
        {
            Token = token
        }; 
    }
}
