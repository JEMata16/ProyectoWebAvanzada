using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudInfoController : ControllerBase
    {

        ISolicitudInfoService solicitudInfoService;

        public SolicitudInfoController(ISolicitudInfoService SolicitudInfoService)
        {
            solicitudInfoService = SolicitudInfoService;
        }


        // GET: api/<SolicitudInfoController>
        [HttpGet]
        public ActionResult Get()
        {
            List<SolicitudInfoModel> result = solicitudInfoService.GetSolicitudInfos().Result;
            return new JsonResult(result);
        }

        // GET api/<SolicitudInfoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            SolicitudInfoModel result = solicitudInfoService.GetSolicitudInfoById(id).Result;
            return new JsonResult(result);
        }
        // POST api/<SolicitudInfoController>
        [HttpPost]
        public ActionResult Post([FromBody] SolicitudInfoModel solicitudInfo)
        {
            var result = solicitudInfoService.Add(solicitudInfo);
            return new JsonResult(result);
        }
        // PUT api/<SolicitudInfoController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] SolicitudInfoModel solicitudInfo)
        {
            var result = solicitudInfoService.Update(solicitudInfo);
            return new JsonResult(result);
        }

        // DELETE api/<SolicitudInfoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = solicitudInfoService.Delete(id);
            return new JsonResult(result);
        }
    }
}
