using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        IEventoService eventoService;

        public EventoController (IEventoService EventoService)
        {
            eventoService = EventoService;
        }


            // GET: api/<EventoController>
        [HttpGet]
        public ActionResult Get()
        {
            List<EventoModel> result = eventoService.GetEventos().Result;
            return new JsonResult(result);
        }

        // GET api/<EventoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            EventoModel result = eventoService.GetEventoById(id).Result;
            return new JsonResult(result);
        }

        // POST api/<EventoController>
        [HttpPost]
        public ActionResult Post([FromBody] EventoModel evento)
        {
            var result = eventoService.Add(evento);
            return new JsonResult(result);
        }
        // PUT api/<EventoController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] EventoModel evento)
        {
            var result = eventoService.Update(evento);
            return new JsonResult(result);
        }

        // DELETE api/<EventoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = eventoService.Delete(id);
            return new JsonResult(result);
        }
    }
}
