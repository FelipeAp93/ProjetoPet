using AutoMapper;
using ProjetoPet.DTOs;
using ProjetoPet.Models;
using ProjetoPet.Repositories;

namespace ProjetoPet.Services;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;
    private readonly IMapper _mapper;
    private readonly IDonoRepository _donoRepository;

    public PetService(IPetRepository petRepository, IMapper mapper, IDonoRepository donoRepository)
    {
        _petRepository = petRepository;
        _mapper = mapper;
        _donoRepository = donoRepository;
    }
    public async Task<IEnumerable<PetDTO>> BuscarPets()
    {
        var petsEntity = await _petRepository.BuscarPets();
        return _mapper.Map<IEnumerable<PetDTO>>(petsEntity);
    }
    public async Task<IEnumerable<PetDTO>> BuscarPetDono()
    {
        var petsEntity = await _petRepository.BuscarPetDono();
        return _mapper.Map<IEnumerable<PetDTO>>(petsEntity);
    }
    public async Task<PetDTO> BuscarPetPorId(int id)
    {
        var petEntity = await _petRepository.BuscarPetPorId(id);
        return _mapper.Map<PetDTO>(petEntity);
    }

    public async Task CriarPet(PetDTO petDto)
    {
        var petEntity = _mapper.Map<PetModel>(petDto);

        // Verifique se o DonoId existe e associe o dono ao pet
        var dono = await _donoRepository.BuscarDonoPorId(petDto.DonoId);
        if (dono is null)
        {
            throw new Exception("Dono não encontrado");
        }

        petEntity.Dono = dono;  // Associa o pet ao dono
        await _petRepository.CriarPet(petEntity);

        petDto.Id = petEntity.Id;  // Retorna o ID gerado para o pet
    }
    public async Task Atualizar(PetDTO petDto)
    {
        var petEntity = _mapper.Map<PetModel>(petDto);
        await _petRepository.Atualizar(petEntity);
    }
    public async Task Deletar(int id)
    {
        var petEntity = await _petRepository.BuscarPetPorId(id);
        await _petRepository.Deletar(petEntity.Id);
    }
}
