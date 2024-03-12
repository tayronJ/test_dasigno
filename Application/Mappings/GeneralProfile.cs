using Application.DTOs;
using Application.Features.Colaboradors.Command.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateColaboradorCommand, Colaborador>();
            CreateMap<Colaborador, ColaboradorDTO>();
        }
    }
}
