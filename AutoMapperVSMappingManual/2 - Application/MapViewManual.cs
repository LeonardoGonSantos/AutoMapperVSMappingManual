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
        private ParallelOptions _parallelOptions = new()
        {
            MaxDegreeOfParallelism = 15
        };

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

        public async Task<ClientesViewModel> GetClientesMappingManualAsync()
        {
            ClientesViewModel clientes = new ClientesViewModel();
            clientes.ClientesView = new List<ClienteView>();

            await Parallel.ForEachAsync(_clientesEntity.ClientesEntity, _parallelOptions, async (source, token) =>
            {
                clientes.ClientesView.Add(await _clienteEntityToClienteView.CreateAsync(source));
            });

            return clientes;
        }
    }
}
