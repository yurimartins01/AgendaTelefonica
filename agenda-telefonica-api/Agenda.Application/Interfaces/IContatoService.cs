using Agenda.Application.DTOs;
using Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Interfaces
{
    public interface IContatoService
    {
        Task<List<ContatoDto>> BuscarTodos();
        Task<ContatoDto> BuscarPorId(int id);
        Task<ContatoDto> AdicionarContato(CriarContatoDto contatoDto);
        Task<ContatoDto> AtulizarContato(int id, CriarContatoDto contatoDto);
        Task<ContatoDto> DeletarContato(int id); 
        
    }
}
