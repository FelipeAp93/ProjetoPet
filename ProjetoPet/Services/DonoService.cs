using AutoMapper;
using ProjetoPet.DTOs;
using ProjetoPet.Models;
using ProjetoPet.Repositories;

namespace ProjetoPet.Services;

public class DonoService : IDonoService
{
    private readonly IDonoRepository _donoReposiroty;
    private readonly IMapper _mapper;

    public DonoService(IDonoRepository donoReposiroty, IMapper mapper)
    {
        _donoReposiroty = donoReposiroty;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DonoDTO>> BuscarDonos()
    {
        var donosEntity = await _donoReposiroty.BuscarDonos();
        return _mapper.Map<IEnumerable<DonoDTO>>(donosEntity);
    }
    public async Task<IEnumerable<DonoDTO>> BuscarDonoPet()
    {
        var donosEntity = await _donoReposiroty.BuscarDonoPet();
        return _mapper.Map<IEnumerable<DonoDTO>>(donosEntity);
    }
    public async Task<DonoDTO> BuscarDonoPorId(int id)
    {
        var donoEntity = await _donoReposiroty.BuscarDonoPorId(id);
        return _mapper.Map<DonoDTO>(donoEntity);
    }
    public async Task CriarDono(DonoDTO donoDto)
    {
        var donoEntity = _mapper.Map<DonoModel>(donoDto);
        await _donoReposiroty.CriarDono(donoEntity);
        donoDto.Id = donoEntity.Id;
    }

    public async Task CriarDono(DonoCriarDTO donoCriarDto)
    {
        var donoEntity = _mapper.Map<DonoModel>(donoCriarDto);
        await _donoReposiroty.CriarDono(donoEntity);
        donoCriarDto.Id = donoEntity.Id;
    }
    public async Task Atualizar(DonoDTO donoDto)
    {
        var donoEntity = _mapper.Map<DonoModel>(donoDto);
        await _donoReposiroty.Atualizar(donoEntity);
    }
    public async Task Deletar(int id)
    {
        var donoEntity = _donoReposiroty.BuscarDonoPorId(id).Result;
        await _donoReposiroty.Deletar(donoEntity.Id);
    }

   
}
