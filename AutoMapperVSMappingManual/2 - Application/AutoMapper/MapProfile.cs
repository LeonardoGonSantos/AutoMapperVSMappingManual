using AutoMapper;
using AutoMapperVSMappingManual._2___Application.Entity.Clientes;

namespace AutoMapperVSMappingManual._2___Application.AutoMapper
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<Clientes, ClientesViewModel>();
		}
	}
}
