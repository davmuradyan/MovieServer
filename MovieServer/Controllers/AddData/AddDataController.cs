using Microsoft.AspNetCore.Mvc;
using MovieServer.Core.Services.csvServices;

namespace MovieServer.Controllers.AddData
{
    public class AddDataController : Controller
    {

        ICSVService csvService;
        public AddDataController(ICSVService csvService)
        {
            this.csvService = csvService;
        }

        //[HttpPost("AddGenomeScores")]
        //public IActionResult AddGenomeScores()
        //{
        //    DateTime start = DateTime.Now;
        //    csvService.AddGenomeScoreEntity();
        //    DateTime end = DateTime.Now;
        //    return Ok(start-end);
        //}

        [HttpPost("AddRatings")]
        public IActionResult AddRatings(int part) {
            csvService.AddRatingEntity(part);
            return Ok();
        }
    }
}
