using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPet.DTOs;
using ProjetoPet.Services;

namespace ProjetoPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetDTO>>> BuscarPets()
        {
            var petsDto = await _petService.BuscarPets();
            if (petsDto is null)
            {
                return NotFound("Pets não encontrados");
            }
            return Ok(petsDto);
        }

        [HttpGet("Pets&Donos")]
        public async Task<ActionResult<IEnumerable<PetDTO>>> BuscarPetsDonos()
        {
            var petsDto = await _petService.BuscarPetDono();

            if (petsDto is null)
                return NotFound("Pets e donos não encontrados");

            return Ok(petsDto);
        }

        [HttpGet("{id:int}", Name = "ObterPet")]
        public async Task<ActionResult<PetDTO>> BuscarPetPorId(int id)
        {
            var petDto = await _petService.BuscarPetPorId(id);

            if (petDto is null)
                return NotFound("Pet não pelo id encontrados");

            return Ok(petDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Criar([FromBody] PetDTO petDto)
        {
            if (petDto is null)
                return BadRequest("Não foi possível criar um pet");

            await _petService.CriarPet(petDto);

            return new CreatedAtRouteResult("ObterPet", new { id = petDto.Id }, petDto);
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<ActionResult> Atualizar(int id, [FromBody] PetDTO petDto)
        {
            if (id != petDto.Id)
                return BadRequest();

            if (petDto is null)
                return NotFound();
            await _petService.Atualizar(petDto);
            return Ok(petDto);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult<PetDTO>> Deletar(int id)
        {
            var petDto = await _petService.BuscarPetPorId(id);
            if (petDto is null)
            {
                return NotFound("Dono não encontradado");
            }

            await _petService.Deletar(id);
            return Ok(petDto);
        }
    }
}
