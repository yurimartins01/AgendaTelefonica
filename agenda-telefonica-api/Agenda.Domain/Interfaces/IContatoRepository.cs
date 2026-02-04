using Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Interfaces
{
    public interface IContatoRepository
    {
        Task<List<Contato>> BuscarTodos();
        Task<Contato> BuscarContatoPorId(int id);
        Task<Contato> AdicionarContato(Contato contato);
        Task<Contato> AtualizarContato(int id, Contato contato);
        Task<Contato> DeletarContato(int id);
    }
}
