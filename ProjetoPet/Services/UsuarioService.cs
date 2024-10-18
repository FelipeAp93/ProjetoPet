using AutoMapper;
using ProjetoPet.DTOs;
using ProjetoPet.Models;
using ProjetoPet.Repositories;

namespace ProjetoPet.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioDTO>> BuscarTodos()
    {
        var usuarios = await _repository.BuscarTodos();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
    }

    public async Task<UsuarioDTO> BuscarPorId(int id)
    {
        var usuario = await _repository.BuscarPorId(id);
        return _mapper.Map<UsuarioDTO>(usuario); 

    }

    public async Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        var usuarioIncluido = await _repository.Incluir(usuario);
        return _mapper.Map<UsuarioDTO>(usuarioIncluido);

    }

    public async Task<UsuarioDTO> Atualizar(UsuarioDTO usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        var usuarioAtt = await _repository.Atualizar(usuario);
        return _mapper.Map<UsuarioDTO>(usuarioAtt);
    }

    public async Task<UsuarioDTO> Deletar(int id)
    {
        var usuario = await _repository.Deletar(id);
        return _mapper.Map<UsuarioDTO>(usuario);
    }

   
}
