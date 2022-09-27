using AutoMapperVSMappingManual._2___Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoMapperVSMappingManual.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerformanceTesteController : ControllerBase
    {

        private readonly ILogger<PerformanceTesteController> _logger;
        private readonly IMapView _mapView;

        public PerformanceTesteController(ILogger<PerformanceTesteController> logger, IMapView mapView)
        {
            _logger = logger;
            _mapView = mapView;
        }

        [HttpGet(Name = "RequestTesteAutomapper")]
        public IActionResult RequestTesteAutomapper()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var result = _mapView.GetClientesAutoMapper();

            return Ok((stopwatch.ElapsedMilliseconds, result));
        }

        [HttpGet(Name = "RequestTesteMapingManual")]
        public IActionResult RequestTesteMapingManual()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var result = _mapView.GetClientesMappingManual();

            return Ok((stopwatch.ElapsedMilliseconds, result));
        }
    }
}