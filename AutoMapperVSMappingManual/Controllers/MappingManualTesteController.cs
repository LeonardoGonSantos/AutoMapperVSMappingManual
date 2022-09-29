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

            _mapView.GetClientesMappingManual();

            stopwatch.Stop();

            return Ok(new { TempoDeExecucao = stopwatch.Elapsed.ToString() });
        }

        [HttpGet("RequestTesteMapingManualAsync")]
        public async Task<IActionResult> RequestTesteMapingManualAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            await _mapView.GetClientesMappingManualAsync();

            stopwatch.Stop();

            return Ok(new { TempoDeExecucao = stopwatch.Elapsed.ToString() });
        }

        [HttpGet("RequestTesteMapingManual/{countVezes}")]
        public IActionResult RequestTesteMapingManualComContador([FromRoute] int countVezes)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < countVezes; i++)
            {
                _mapView.GetClientesMappingManual();
            }

            stopwatch.Stop();

            return Ok(new { TempoDeExecucao = stopwatch.Elapsed.ToString() });
        }

        [HttpGet("RequestTesteMapingManualAsync/{countVezes}")]
        public async Task<IActionResult> RequestTesteMapingManualAsyncComContador([FromRoute] int countVezes)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();


            var tasks = new List<Task>();

            for (int i = 0; i < countVezes; i++)
            {
                tasks.Add(_mapView.GetClientesMappingManualAsync());
            }

            await Task.WhenAll(tasks);

            stopwatch.Stop();

            return Ok(new { TempoDeExecucao = stopwatch.Elapsed.ToString() });
        }
    }
}