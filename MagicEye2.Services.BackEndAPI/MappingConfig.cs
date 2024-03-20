using AutoMapper;
using MagicEye2.Services.BackEndAPI.Models;
using MagicEye2.Services.BackEndAPI.Models.Dto;
using MagicEye2.Services.BackEndAPI.Models.Insumos;

namespace MagicEye2.Services.BackEndAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        { 
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CoberturaDto, Cobertura>();
                config.CreateMap<Cobertura, CoberturaDto>();

                config.CreateMap<EntregaDto, Entrega>();
                config.CreateMap<Entrega, EntregaDto>();

                config.CreateMap<Hcu053Dto, Hcu053>();
                config.CreateMap<Hcu053, Hcu053Dto>();

                config.CreateMap<ResultadoDto, Resultado>();
                config.CreateMap<Resultado, ResultadoDto>();

                config.CreateMap<ValidacionDto, Validacion>();
                config.CreateMap<Validacion, ValidacionDto>();

                config.CreateMap<ExpedienteDto, Expediente>();
                config.CreateMap<Expediente, ExpedienteDto>();
            });
            return mappingConfig;
            }
    }
}
