using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {

        IRatingService ratingService;


        public RatingController(IRatingService RatingService)
        {
            ratingService =     RatingService;
        }



           // GET: api/<RatingController>
        [HttpGet]
        public ActionResult Get()
        {
            List<RatingModel> result = ratingService.GetRatings().Result;
            return new JsonResult(result);
        }
        // GET api/<RatingController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            RatingModel result = ratingService.GetRatingById(id).Result;
            return new JsonResult(result);
        }

        // POST api/<RatingController>
        [HttpPost]
        public ActionResult Post([FromBody] RatingModel rating)
        {
            var result = ratingService.Add(rating);
            return new JsonResult(result);
        }
        // PUT api/<RatingController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] RatingModel rating)
        {
            var result = ratingService.Update(rating);
            return new JsonResult(result);
        }

        // DELETE api/<RatingController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = ratingService.Delete(id);
            return new JsonResult(result);
        }
    }
}
