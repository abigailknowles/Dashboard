using Microsoft.AspNetCore.Mvc;
using PatientWarningApp.Api.PractitionerAccount.Interfaces;
using PatientWarningApp.Api.PractitionerAccount.Models;

namespace PatientWarningApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionerAuthController : ControllerBase
    {
        private readonly IPractitionerAccountService _practitionerAccountService;

        public PractitionerAuthController(IPractitionerAccountService practitionerAccountService)
        {
            _practitionerAccountService = practitionerAccountService;
        }

        [HttpPost("PractitionerLogin")]
        public ActionResult<PractitionerAccountModel> Login(PractitionerAccountModel account)
        {
            // check request is valid
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_practitionerAccountService.ReadByUsernameAndPassword(account));
        }
    }
}
