using AutoMapper;
using MagicEye2.Services.BackEndAPI.Models.Dto;
using MagicEye2.Services.BackEndAPI.Models;
using System.Reflection.PortableExecutable;

namespace MagicEye2.Services.BackEndAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Expediente, ExpedienteDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            
            // //Mapeo de la tabla intermedia
            CreateMap<ExpedienteCliente, ExpedienteClienteDto>().ReverseMap();

            //
            CreateMap<Paciente, PacienteDto>().ReverseMap();
            CreateMap<MaestroTBeneficiario, MaestroTBeneficiarioDto>().ReverseMap();

        }
        // Si necesitas crear la configuración manualmente, puedes mantener este método estático
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingConfig());
            });

            return mappingConfig;
        }
    }
}
