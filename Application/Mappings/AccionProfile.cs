using Application.Features.Accion.Commands.CreateAccion;
using Application.Features.Accion.Commands.UpdateAccion;
using AutoMapper;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    /// <summary>
    /// Accion Profile AutoMapper
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class AccionProfile : Profile
    {
        public AccionProfile()
        {
            CreateMap<CreateAccionCommand, Acciones>();
            CreateMap<UpdateAccionCommand, Acciones>();
        }
    }
}
