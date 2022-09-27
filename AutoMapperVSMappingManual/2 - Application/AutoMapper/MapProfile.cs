using AutoMapper;
using AutoMapperVSMappingManual._2___Application.Entity.Clientes;
using static AutoMapperVSMappingManual._2___Application.Entity.Clientes.Clientes;
using static AutoMapperVSMappingManual._2___Application.Entity.Clientes.ClientesViewModel;

namespace AutoMapperVSMappingManual._2___Application.AutoMapper
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<Clientes, ClientesViewModel>()
				.ForMember(source => source.ClientesView, config => config.MapFrom(destination => destination.ClientesEntity));

            CreateMap<ClienteEntity, ClienteView>();
            //.ForMember(source => source.SiatuacaoCiviil, config => config.MapFrom(destination => destination.SiatuacaoCiviil))
            //.ForMember(source => source.Email, config => config.MapFrom(destination => destination.Email))
            //.ForMember(source => source.Idade, config => config.MapFrom(destination => destination.Idade))
            //.ForMember(source => source.Telefone, config => config.MapFrom(destination => destination.Telefone))
            //.ForMember(source => source.Endereco, config => config.MapFrom(destination => destination.Endereco))
            //.ForMember(source => source.Nome, config => config.MapFrom(destination => destination.Nome))
            //.ForMember(source => source.ContatosDeEmergencia, config => config.MapFrom(destination => destination.ContatosDeEmergencia));

            CreateMap<TelefoneEntity, TelefoneView>();
            //.ForMember(source => source.Numero, config => config.MapFrom(destination => destination.Numero))
            //            .ForMember(source => source.DDD, config => config.MapFrom(destination => destination.DDD));

            CreateMap<EnderecoEntity, EnderecoView>();
            //.ForMember(source => source.Rua, config => config.MapFrom(destination => destination.Rua))
            //            .ForMember(source => source.NUmero, config => config.MapFrom(destination => destination.NUmero))
            //            .ForMember(source => source.Cep, config => config.MapFrom(destination => destination.Cep))
            //            .ForMember(source => source.Rua, config => config.MapFrom(destination => destination.Rua))
            //            .ForMember(source => source.Bairro, config => config.MapFrom(destination => destination.Bairro))
            //            .ForMember(source => source.Pais, config => config.MapFrom(destination => destination.Pais))
            //            .ForMember(source => source.Complemento, config => config.MapFrom(destination => destination.Complemento));

            CreateMap<ContatosdeemergenciaEntity, ContatosdeemergenciaView>();
				//.ForMember(source => source.Telefone, config => config.MapFrom(destination => destination.Telefone))
    //            .ForMember(source => source.Nome, config => config.MapFrom(destination => destination.Nome))
    //            .ForMember(source => source.DDD, config => config.MapFrom(destination => destination.DDD));
        }
    }
}
