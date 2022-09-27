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
        private readonly IMapViewAutoMapper _mapViewAutoMapper;
        private readonly IMapViewManual _mapViewManual;

        public PerformanceTesteController(IMapView mapView, IMapViewAutoMapper mapViewAutoMapper, IMapViewManual mapViewManual)
        {
            _mapView = mapView;
            _mapViewAutoMapper = mapViewAutoMapper;
            _mapViewManual = mapViewManual;
        }

        [HttpGet("ComparacaoDeTempoClassSeparadas")]
        public IActionResult ComparacaoDeTempoClassSeparadas()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            var resultAuto = _mapViewAutoMapper.GetClientesAutoMapper();

            stopwatch.Stop();

            var tempoAuto = stopwatch.Elapsed;



            stopwatch.Restart();

            var resultManual = _mapViewManual.GetClientesMappingManual();

            stopwatch.Stop();

            var tempoManual = stopwatch.Elapsed;




            return Ok(new { TempoDeExecucaoAuto = tempoAuto.ToString(), TempoDeExecucaoManual = tempoManual });
        }

        [HttpGet("ComparacaoDeTempo")]
        public IActionResult ComparacaoDeTempo()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            var resultAuto = _mapView.GetClientesAutoMapper();

            var tempoAuto = stopwatch.Elapsed;

            stopwatch.Stop();


            stopwatch.Restart();

            var resultManual = _mapView.GetClientesMappingManual();

            var tempoManual = stopwatch.Elapsed;

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