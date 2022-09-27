using AutoMapperVSMappingManual._2___Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoMapperVSMappingManual.Controllers
{
    [ApiController]
    [Route("")]
    public class PerformanceTesteController : ControllerBase
    {
        private readonly IMapView _mapView;

        public PerformanceTesteController( IMapView mapView)
        {
            _mapView = mapView;
        }

        [HttpGet("ComparacaoDeTempo")]
        public IActionResult ComparacaoDeTempo()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            var resultManual = _mapView.GetClientesMappingManual();

            var tempoManual = stopwatch.Elapsed;

            stopwatch.Stop();

            stopwatch.Restart();

            var resultAuto = _mapView.GetClientesAutoMapper();

            var tempoAuto = stopwatch.Elapsed;

            stopwatch.Stop();

            return Ok(new { TempoDeExecucaoAuto = tempoAuto.ToString(), TempoDeExecucaoManual = tempoManual });
        }

        [HttpGet("RequestTesteAutomapper")]
        public IActionResult RequestTesteAutomapper()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var result = _mapView.GetClientesAutoMapper();

            return Ok(new { TempoDeExecucao = stopwatch.Elapsed, result = result });
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