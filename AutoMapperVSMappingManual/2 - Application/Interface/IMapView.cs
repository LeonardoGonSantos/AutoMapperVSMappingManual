using AutoMapperVSMappingManual._2___Application.Entity.Clientes;

namespace AutoMapperVSMappingManual._2___Application.Interface
{
    public interface IMapView
    {
        ClientesViewModel GetClientesAutoMapper();
        ClientesViewModel GetClientesMappingManual();
    }
}
