using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemaController : ControllerBase
    {

        ITemaService temaService;

        public TemaController(ITemaService TemaService)
        {
            temaService = TemaService;
        }

    
        // GET: api/<TemaController>
        [HttpGet]
        public ActionResult Get()
        {
            List<TemaModel> result = temaService.GetTemas().Result;
            return new JsonResult(result);
        }

        // GET api/<TemaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            TemaModel result = temaService.GetTemaById(id).Result;
            return new JsonResult(result);
        }

        // POST api/<TemaController>
        [HttpPost]
        public ActionResult Post([FromBody] TemaModel tema)
        {
            var result = temaService.Add(tema);
            return new JsonResult(result);
        }
        // PUT api/<TemaController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] TemaModel tema)
        {
            var result = temaService.Update(tema);
            return new JsonResult(result);
        }


        // DELETE api/<TemaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = temaService.Delete(id);
            return new JsonResult(result);
        }
    }
}
