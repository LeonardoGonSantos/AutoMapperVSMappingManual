using AutoMapperVSMappingManual._2___Application.Entity.Clientes;

namespace AutoMapperVSMappingManual._2___Application.Interface
{
    public interface IMapViewManual
    {
        ClientesViewModel GetClientesMappingManual();
        Task<ClientesViewModel> GetClientesMappingManualAsync();
    }
}
