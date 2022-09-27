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

            _mapView.GetClientesAutoMapper();

            stopwatch.Stop();

            return Ok(new { TempoDeExecucao = stopwatch.Elapsed.ToString() });
        }

        [HttpGet("RequestTesteAutomapper/{countVezes}")]
        public IActionResult RequestTesteAutomapper([FromRoute] int countVezes)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < countVezes; i++)
            {
                _mapView.GetClientesAutoMapper();
            }

            stopwatch.Stop();

            return Ok(new { TempoDeExecucao = stopwatch.Elapsed.ToString() });
        }
    }
}