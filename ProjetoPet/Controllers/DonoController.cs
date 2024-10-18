using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPet.DTOs;
using ProjetoPet.Services;

namespace ProjetoPet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DonoController : ControllerBase
{
    private readonly IDonoService _donoService;

    public DonoController(IDonoService donoService)
    {
        _donoService = donoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DonoDTO>>> Buscar()
    {
        var donosDto = await _donoService.BuscarDonos();

        if (donosDto is null)
            return NotFound("Donos não encontrados");

        return Ok(donosDto);
    }

    [HttpGet("Donos&Pets")]
    public async Task<ActionResult<IEnumerable<DonoDTO>>> BuscarDonoPet()
    {
        var donosDto = await _donoService.BuscarDonoPet();

        if (donosDto is null)
            return NotFound("Donos e pets não encontrados");

        return Ok(donosDto);
    }

    [HttpGet("{id:int}", Name = "ObterDono")]
    public async Task<ActionResult<DonoDTO>> BuscarDonoPorId(int id)
    {
        var donoDto = await _donoService.BuscarDonoPorId(id);

        if (donoDto is null)
            return NotFound("Dono pelo id não encontrados");

        return Ok(donoDto);
    }
    [HttpPost]
    public async Task<ActionResult> Criar([FromBody] DonoCriarDTO donoCriarDto)
    {
        if (donoCriarDto is null)
            return BadRequest("Não foi possível criar um dono.");

        await _donoService.CriarDono(donoCriarDto);

        return new CreatedAtRouteResult("ObterDono", new { id = donoCriarDto.Id }, donoCriarDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Atualizar(int id, [FromBody] DonoDTO donoDto)
    {
        if (id != donoDto.Id)
            return BadRequest();

        if (donoDto is null)
            return NotFound();
        await _donoService.Atualizar(donoDto);
        return Ok(donoDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<DonoDTO>> Deletar(int id)
    {
        var donoDto = await _donoService.BuscarDonoPorId(id);
        if (donoDto is null)
        {
            return NotFound("Dono não encontradado");
        }

        await _donoService.Deletar(id);
        return Ok(donoDto);
    }
}
