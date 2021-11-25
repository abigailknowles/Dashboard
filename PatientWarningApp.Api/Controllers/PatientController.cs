using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;
using System.Collections.Generic;

namespace PaitentWarning.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _service;

        public PatientController(ILogger<PatientController> logger, IPatientService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientModel>> Get(int patientId)
        {
            
            return Ok(_service.Read(patientId));
        }

        [HttpPost]
        public ActionResult<PatientModel> CreatePatient(PatientModel patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ;
            return Ok(_service.Create(patient));
        }

        [HttpPut]
        public ActionResult<PatientModel> UpdatePatient(PatientModel patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

        ;
            return Ok(_service.Update(patient));
        }

        [HttpDelete]
        public ActionResult<PatientModel> DeletePatient(PatientModel patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

    ;
            return Ok(_service.Delete(patient));
        }
    }
}
