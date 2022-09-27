using AutoMapper;
using AutoMapperVSMappingManual._2___Application.Entity.Clientes;
using AutoMapperVSMappingManual._2___Application.Interface;
using Microsoft.Extensions.Options;
using static AutoMapperVSMappingManual._2___Application.Entity.Clientes.Clientes;
using static AutoMapperVSMappingManual._2___Application.Entity.Clientes.ClientesViewModel;

namespace AutoMapperVSMappingManual._2___Application
{
    public class MapViewManual : IMapViewManual
    {
        private Clientes _clientesEntity;
        private IClienteEntityToClienteView _clienteEntityToClienteView;

        public MapViewManual(IOptions<Clientes> clientesEntity, IClienteEntityToClienteView clienteEntityToClienteView)
        {
            _clientesEntity = clientesEntity.Value;
            _clienteEntityToClienteView = clienteEntityToClienteView;
        }

        public ClientesViewModel GetClientesMappingManual()
        {
            ClientesViewModel clientes = new ClientesViewModel();
            clientes.ClientesView = new List<ClienteView>();

            foreach (var entity in _clientesEntity.ClientesEntity)
            {
                var result = _clienteEntityToClienteView.Create(entity);
                clientes.ClientesView.Add(result);
            }
            
            return clientes;
        }
    }
}
