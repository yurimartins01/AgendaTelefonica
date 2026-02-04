using Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Agenda.Application.DTOs
{
    public class ContatoDto
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<TelefoneDto> Telefones { get; set; } = new();



    }
}
