using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        ICursoService cursoService;

        public CursoController(ICursoService CursoService)
        {
            cursoService =  CursoService;
        }



        // GET: api/<CursoController>
        [HttpGet]
        public ActionResult Get()
        {
            List<CursoModel> result = cursoService.getCursos().Result;
            return new JsonResult(result);
        }
        // GET api/<CursoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            CursoModel result = cursoService.GetCursoById(id).Result;
            return new JsonResult(result);
        }
        // POST api/<CursoController>
        [HttpPost]
        public ActionResult Post([FromBody] CursoModel curso)
        {
            var result = cursoService.Add(curso);
            return new JsonResult(result);
        }

        // PUT api/<CursoController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] CursoModel curso)
        {
            var result = cursoService.Update(curso);
            return new JsonResult(result);
        }

        // DELETE api/<CursoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = cursoService.Delete(id);
            return new JsonResult(result);
        }
    }
}
