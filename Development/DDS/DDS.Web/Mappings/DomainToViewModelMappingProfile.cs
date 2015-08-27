using AutoMapper;
using DDS.Model;
using DDS.Model.Models;
using DDS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDS.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Perfil, PerfilViewModel>();
            Mapper.CreateMap<Grupo, GrupoViewModel>();
        }
    }
}