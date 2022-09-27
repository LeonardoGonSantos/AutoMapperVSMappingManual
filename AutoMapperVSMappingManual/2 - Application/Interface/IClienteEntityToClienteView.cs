using static AutoMapperVSMappingManual._2___Application.Entity.Clientes.Clientes;
using static AutoMapperVSMappingManual._2___Application.Entity.Clientes.ClientesViewModel;

namespace AutoMapperVSMappingManual._2___Application.Interface
{
    public interface IClienteEntityToClienteView
    {
        ClienteView Create(ClienteEntity clienteEntity);
        Task<ClienteView> CreateAsync(ClienteEntity clienteEntity);
    }
}
