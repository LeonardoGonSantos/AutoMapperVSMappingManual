using AutoMapperVSMappingManual._2___Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoMapperVSMappingManual.Controllers
{
    [ApiController]
    [Route("AutoMappingTesteController/")]
    public class AutoMappingTesteController : ControllerBase
    {
        private readonly IMapViewAutoMapper _mapView;

        public AutoMappingTesteController(IMapViewAutoMapper mapView)
        {
            _mapView = mapView;
        }


        [HttpGet("RequestTesteAutomapper")]
        public IActionResult RequestTesteAutomapper()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var result = _mapView.GetClientesAutoMapper();

            return Ok(new { TempoDeExecucao = stopwatch.Elapsed, result = result });
        }
    }
}