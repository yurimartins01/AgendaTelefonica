using Agenda.Application.Interfaces;
using Agenda.Domain.Entities;
using Agenda.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infra.Data.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ApplicationDbContext _context;

        public ContatoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contato>> BuscarTodos()
        {
            return await _context.Contatos.Include(c => c.Telefones).OrderBy(c => c.Nome).ToListAsync();
        }

        public async Task<Contato?> BuscarContatoPorId(int id)
        {

            var contato = await _context.Contatos.Include(c => c.Telefones).FirstOrDefaultAsync(c => c.Id == id);
            return contato;
        }

        public async Task<Contato> AdicionarContato(Contato contato)
        {
            await _context.Contatos.AddAsync(contato);
            await _context.SaveChangesAsync();

            return contato;
        }

        public async Task<Contato> AtualizarContato(int id, Contato contato)
        {
            var contatoExistente = await BuscarContatoPorId(id);
            
            if(contatoExistente == null)
            {
                throw new KeyNotFoundException("Contato não encontrado.");
            }
            
            contatoExistente.Nome = contato.Nome;
            contatoExistente.Idade = contato.Idade;

            var novosTelefones = contato.Telefones.Select(t => t.Numero).ToList();
            var telefonesExistentes = contatoExistente.Telefones;
            var telefonesParaRemover = telefonesExistentes.Where(t => !novosTelefones.Contains(t.Numero)).ToList();
            var telefonesParaAdicionar = novosTelefones.Where(numero => !telefonesExistentes.Any(t => t.Numero == numero)).ToList();

            _context.Telefones.RemoveRange(telefonesParaRemover);

            foreach(var numero in telefonesParaAdicionar)
            {
                contatoExistente.Telefones.Add(new Telefone
                {
                    Numero = numero,
                    IdContato = id
                 
                });
            }

            await _context.SaveChangesAsync();
            return contatoExistente;
        }

        public async Task<Contato> DeletarContato(int id)
        {
            var contato = await BuscarContatoPorId(id);
            if(contato == null)
            {
                throw new KeyNotFoundException("Contato não encontrado");
            }
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();

            return contato;

        }
    }
}
