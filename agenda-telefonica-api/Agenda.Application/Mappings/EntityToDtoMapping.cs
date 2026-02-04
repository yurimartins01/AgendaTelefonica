using Agenda.Application.DTOs;
using Agenda.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Mappings
{
    public class EntityToDtoMapping : Profile
    {
        public EntityToDtoMapping()
        {
            CreateMap<Contato, ContatoDto>().ReverseMap();
            CreateMap<Contato, CriarContatoDto>().ReverseMap();
            CreateMap<Telefone, CriarTelefoneDto>().ReverseMap();
            CreateMap<Telefone, TelefoneDto>().ReverseMap();

        }
    }
}
