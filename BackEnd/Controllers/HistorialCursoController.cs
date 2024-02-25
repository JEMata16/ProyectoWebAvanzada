using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialCursoController : ControllerBase
    {
        IHistorialCursoService historialCursoService;

        public HistorialCursoController(IHistorialCursoService HistorialCursoService)
        {
            historialCursoService = HistorialCursoService;
        }


          // GET: api/<HistorialCursoController>
        [HttpGet]
        public ActionResult Get()
        {
            List<HistorialCursoModel> result = historialCursoService.GetHistorialCursos().Result;
            return new JsonResult(result);
        }


        // GET api/<HistorialCursoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            HistorialCursoModel result = historialCursoService.GetHistorialCursoById(id).Result;
            return new JsonResult(result);
        }
        // POST api/<HistorialCursoController>
        [HttpPost]
        public ActionResult Post([FromBody] HistorialCursoModel historialCurso)
        {
            var result = historialCursoService.Add(historialCurso);
            return new JsonResult(result);
        }

        // PUT api/<HistorialCursoController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] HistorialCursoModel historialCurso)
        {
            var result = historialCursoService.Update(historialCurso);
            return new JsonResult(result);
        }
        // DELETE api/<HistorialCursoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = historialCursoService.Delete(id);
            return new JsonResult(result);
        }
    }
}
