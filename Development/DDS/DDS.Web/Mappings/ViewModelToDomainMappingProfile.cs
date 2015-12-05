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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<PerfilViewModel, Perfil>();
            Mapper.CreateMap<RecetaViewModel, Receta>();
            Mapper.CreateMap<GrupoViewModel, Grupo>();
            Mapper.CreateMap<PasoViewModel, Paso>();
            Mapper.CreateMap<PlanificacionViewModel, Planificacion>();
        }
    }
}