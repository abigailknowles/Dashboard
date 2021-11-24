using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;
using System.Collections.Generic;

namespace PaitentWarning.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionerController : ControllerBase
    {

        private readonly ILogger<PractitionerController> _logger;
        private readonly IPractitionerService _service;

        public PractitionerController(ILogger<PractitionerController> logger, IPractitionerService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PractitionerModel>> Get(int practitionerId)
        {
            
            return Ok(_service.Read(practitionerId));
        }

        [HttpPost]
        public ActionResult<PractitionerModel> CreatePractitioner(PractitionerModel practitioner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ;
            return Ok(_service.Create(practitioner));
        }

        [HttpPut]
        public ActionResult<PractitionerModel> UpdatePractitioner(PractitionerModel practitioner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

        ;
            return Ok(_service.Update(practitioner));
        }

        [HttpDelete]
        public ActionResult<PractitionerModel> DeletePractitioner(PractitionerModel practitioner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

    ;
            return Ok(_service.Delete(practitioner));
        }
    }
}
