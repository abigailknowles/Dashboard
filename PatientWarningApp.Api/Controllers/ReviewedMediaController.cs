using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;
using System.Collections.Generic;

namespace PaitentWarning.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewedMediaController : ControllerBase
    {

        private readonly ILogger<ReviewedMediaController> _logger;
        private readonly IReviewedMediaService _service;

        public ReviewedMediaController(ILogger<ReviewedMediaController> logger, IReviewedMediaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReviewedMediaModel>> Get(int id)
        {
            
            return Ok(_service.Read(id));
        }

        [HttpPost]
        public ActionResult<ReviewedMediaModel> CreateReviewedMedia(ReviewedMediaModel reviewedMedia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ;
            return Ok(_service.Create(reviewedMedia));
        }

        [HttpPut]
        public ActionResult<ReviewedMediaModel> UpdateReviewedMedia(ReviewedMediaModel media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

        ;
            return Ok(_service.Update(media));
        }

        [HttpDelete]
        public ActionResult<ReviewedMediaModel> DeleteReviewedMedia(ReviewedMediaModel media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

    ;
            return Ok(_service.Delete(media));
        }
    }
}
