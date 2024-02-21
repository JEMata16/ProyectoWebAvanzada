using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService UsuarioService)
        {
            usuarioService = UsuarioService;
        }


        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult Get()
        {
            List<UsuarioModel> result = usuarioService.GetUsuarios().Result;
            return new JsonResult(result);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            UsuarioModel result = usuarioService.GetUsuarioById(id).Result;
            return new JsonResult(result);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post([FromBody] UsuarioModel usuario)
        {
            var result = usuarioService.Add(usuario);
            return new JsonResult(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public ActionResult Put([FromBody] UsuarioModel usuario)
        {
            var result = usuarioService.Update(usuario);
            return new JsonResult(result);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = usuarioService.Delete(id);
            return new JsonResult(result);
        }
    }
}
