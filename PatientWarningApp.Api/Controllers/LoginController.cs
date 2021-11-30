using Microsoft.AspNetCore.Mvc;
using PatientWarningApp.Api.PractitionerAccount.Interfaces;
using PatientWarningApp.Api.PractitionerAccount.Models;

namespace PatientWarningApp.Api.Controllers
{
    //TODO: needs to be refactored to be a general use login controller
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IPractitionerAccountService _practitionerAccountService;

        public LoginController(IPractitionerAccountService practitionerAccountService)
        {
            _practitionerAccountService = practitionerAccountService;
        }

        [HttpPost]
        public ActionResult<PractitionerAccountModel> Login(PractitionerAccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_practitionerAccountService.ReadByUsernameAndPassword(account));
        }
    }
}
