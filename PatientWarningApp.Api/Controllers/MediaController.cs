using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;
using System.Collections.Generic;

namespace PaitentWarning.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {

        private readonly ILogger<MediaController> _logger;
        private readonly IMediaService _service;

        public MediaController(ILogger<MediaController> logger, IMediaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MediaModel>> Get(int id)
        {
            
            return Ok(_service.Read(id));
        }

        [HttpPost]
        public ActionResult<MediaModel> CreateMedia(MediaModel media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ;
            return Ok(_service.Create(media));
        }

        [HttpPut]
        public ActionResult<MediaModel> UpdateMedia(MediaModel media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

        ;
            return Ok(_service.Update(media));
        }

        [HttpDelete]
        public ActionResult<MediaModel> DeleteMedia(MediaModel media)
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
