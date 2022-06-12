using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsteriodeWEB.Exceptions;
using AsteriodeWEB.Filters;
using AsteriodeWEB.Models;
using AsteriodeWEB.WebRest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AsteriodeWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(ExceptionAsteroideFilters))]
    public class AsteroidsController : ControllerBase
    {
        private readonly ILogger<AsteroidsController> _logger;

        private const String STR_KEY = "zb0vnoe8bLPOS3HffDPKD1djhaiLrny6LMSOQ5kh";

        public AsteroidsController(ILogger<AsteroidsController>  logger)
        {
            this._logger = logger;
        }
       
        [HttpGet]
        public IActionResult GetAsteroids()
        {
            return lanzarException("El numero de dias es obligatorio");
        }
        // GET /5
        [HttpGet("{days:int}")]
        public List<Asteroide> GetAsteroids(int days)
        {
            NasaWeb rest;
            List<Asteroide> respuesta = null;
            
            if (days == 0)
            {
                 lanzarException("El número de días es obligatorio");
            }
            else
            {
                if (days < 1 || days > 7)
                   lanzarException("El número de días debe tener un valor entre 1 y 7 ambos incluidos");
                else
                {
                    //SimpleDateFormat format = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
                   
                    DateTime star_date = DateTime.Now;
                    DateTime end_date = star_date.AddDays(days);
                    String url = String.Format("https://api.nasa.gov/neo/rest/v1/feed?start_date={0}&end_date={1}&api_key={2}", star_date.Date.ToString("yyyy-MM-dd"), end_date.Date.ToString("yyyy-MM-dd"), STR_KEY);
                    rest = new NasaWeb();
                    respuesta= rest.GetRest(url);
                }

            }
            return respuesta;
        }

        public IActionResult lanzarException(string msg)
        {
            throw new AsteroideException(msg);
        }
    }
}
