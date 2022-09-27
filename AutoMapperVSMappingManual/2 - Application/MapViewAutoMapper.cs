using AutoMapper;
using AutoMapperVSMappingManual._2___Application.Entity.Clientes;
using AutoMapperVSMappingManual._2___Application.Interface;
using Microsoft.Extensions.Options;
using static AutoMapperVSMappingManual._2___Application.Entity.Clientes.Clientes;
using static AutoMapperVSMappingManual._2___Application.Entity.Clientes.ClientesViewModel;

namespace AutoMapperVSMappingManual._2___Application
{
    public class MapViewAutoMapper : IMapViewAutoMapper
    {
        private Clientes _clientesEntity;
        private IMapper _mapper;

        public MapViewAutoMapper(IOptions<Clientes> clientesEntity, IMapper mapper)
        {
            _clientesEntity = clientesEntity.Value;
            _mapper = mapper;
        }

        public ClientesViewModel GetClientesAutoMapper()
        {
            return _mapper.Map<ClientesViewModel>(_clientesEntity);
        }
    }
}
