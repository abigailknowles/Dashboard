using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientWarningApp.Services.Models;
using PatientWarningApp.Services.PatientServices;
using System.Collections.Generic;

namespace PaitentWarning.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly PractitionerAccountService _service;

        public AccountController(ILogger<AccountController> logger, PractitionerAccountService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PractitionerAccountModel>> Get(PractitionerAccountModel account)
        {
            
            return Ok(_service.Read(account));
        }

        [HttpPost]
        public ActionResult<PractitionerAccountModel> CreateAccount(PractitionerAccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ;
            return Ok(_service.Create(account));
        }

        [HttpPut]
        public ActionResult<PractitionerAccountModel> UpdateAccount(PractitionerAccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

        ;
            return Ok(_service.Update(account));
        }

        [HttpDelete]
        public ActionResult<PractitionerAccountModel> DeleteAccount(PractitionerAccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

    ;
            return Ok(_service.Delete(account));
        }
    }
}
