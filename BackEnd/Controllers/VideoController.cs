using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        IVideoService videoService;

        public VideoController(IVideoService VideoService)
        {
            videoService = VideoService;
        }


        // GET: api/<VideoModel>
        [HttpGet]
        public ActionResult Get()
        {
            List<VideoModel> result = videoService.GetVideos().Result;
            return new JsonResult(result);
        }

        // GET api/<VideoModel>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            VideoModel result = videoService.GetVideoById(id).Result;
            return new JsonResult(result);
        }

        // POST api/<VideoModel>
        [HttpPost]
        public ActionResult Post([FromBody] VideoModel video)
        {
            var result = videoService.Add(video);
            return new JsonResult(result);
        }


        // PUT api/<VideoModel>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] VideoModel video)
        {
            var result = videoService.Update(video);
            return new JsonResult(result);
        }


        // DELETE api/<VideoModel>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = videoService.Delete(id);
            return new JsonResult(result);
        }
    }
}
