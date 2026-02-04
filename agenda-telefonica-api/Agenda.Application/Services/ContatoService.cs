using Agenda.Application.DTOs;
using Agenda.Application.Interfaces;
using Agenda.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ContatoService> _logger;

        public ContatoService(IContatoRepository repository, IMapper mapper, ILogger<ContatoService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<List<ContatoDto>> BuscarTodos()
        {
            var contatos = await _repository.BuscarTodos();
            return _mapper.Map<List<ContatoDto>>(contatos);
        }

        public async Task<ContatoDto> BuscarPorId(int id)
        {
            var contato = await _repository.BuscarContatoPorId(id);
            return _mapper.Map<ContatoDto>(contato);
        }

        public async Task<ContatoDto> AdicionarContato(CriarContatoDto contatoDto)
        {
            var contato = _mapper.Map<Contato>(contatoDto);
            var novoContato = await _repository.AdicionarContato(contato);
            return _mapper.Map<ContatoDto>(novoContato);
        }

        public async Task<ContatoDto> AtulizarContato(int id, CriarContatoDto contatoDto)
        {
            var contato = _mapper.Map<Contato>(contatoDto);
            var contatoAtualizado = await _repository.AtualizarContato(id, contato);
            return _mapper.Map<ContatoDto>(contatoAtualizado);
        }

        public async Task<ContatoDto> DeletarContato(int id)
        {
            var contato = await _repository.DeletarContato(id);

            _logger.LogInformation("Contato excluido --> {@contato}", contato);
            return _mapper.Map<ContatoDto>(contato);
        }
    }
}