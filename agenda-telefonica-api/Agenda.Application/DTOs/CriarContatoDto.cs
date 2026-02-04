using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.DTOs
{
    public class CriarContatoDto
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<CriarTelefoneDto> Telefones { get; set; } = new();
    }
}
