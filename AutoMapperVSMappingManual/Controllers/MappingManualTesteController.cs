using AutoMapperVSMappingManual._2___Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoMapperVSMappingManual.Controllers
{
    [ApiController]
    [Route("MappingManualTesteController/")]
    public class MappingManualTesteController : ControllerBase
    {
        private readonly IMapViewManual _mapView;

        public MappingManualTesteController(IMapViewManual mapView)
        {
            _mapView = mapView;
        }

        [HttpGet("RequestTesteMapingManual")]
        public IActionResult RequestTesteMapingManual()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var result = _mapView.GetClientesMappingManual();

            return Ok(new { TempoDeExecucao = stopwatch.Elapsed.ToString(), result = result });
        }
    }
}