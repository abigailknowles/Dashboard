using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientWarningApp.Api.PractitionerAccount.Interfaces;
using PatientWarningApp.Api.PractitionerAccount.Models;

namespace PatientWarningApp.Api.PractitionerAccount
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionerAccountController : ControllerBase
    {

        private readonly ILogger<PractitionerAccountController> _logger;
        private readonly IPractitionerAccountService _service;

        public PractitionerAccountController(ILogger<PractitionerAccountController> logger, IPractitionerAccountService service)
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

            return Ok(_service.Create(account));
        }

        [HttpPut]
        public ActionResult<PractitionerAccountModel> UpdateAccount(PractitionerAccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_service.Update(account));
        }

        [HttpDelete]
        public ActionResult<PractitionerAccountModel> DeleteAccount(PractitionerAccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_service.Delete(account));
        }
    }
}
