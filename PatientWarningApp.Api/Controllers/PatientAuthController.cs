using Microsoft.AspNetCore.Mvc;
using PatientWarningApp.Api.PatientAccount.Interfaces;
using PatientWarningApp.Api.PatientAccount.Models;

namespace PatientWarningApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAuthController : ControllerBase
    {
        private readonly IPatientAccountService _patientAccountService;

        public PatientAuthController(IPatientAccountService patientAccountService)
        {
            _patientAccountService = patientAccountService;
        }

        [HttpPost("PatientLogin")]
        public ActionResult<PatientAccountModel> Login(PatientAccountModel account)
        {
            // check request is valid
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_patientAccountService.ReadByUsernameAndPassword(account));
        }
    }
}
