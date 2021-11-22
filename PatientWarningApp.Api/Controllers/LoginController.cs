using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;

namespace PaitentWarning.Web.Controllers
{
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
