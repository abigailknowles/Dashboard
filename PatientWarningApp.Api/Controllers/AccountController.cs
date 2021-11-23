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
        private readonly IPractitionerAccountService _service;

        public AccountController(ILogger<AccountController> logger, IPractitionerAccountService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PractitionerAccountModel>> Get(int accountId)
        {
            
            return Ok(_service.Read(accountId));
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
