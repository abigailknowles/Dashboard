using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientWarningApp.Api.PatientAccount.Interfaces;
using PatientWarningApp.Api.PatientAccount.Models;

namespace PatientWarningApp.Api.PatientAccount
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAccountController : ControllerBase
    {

        private readonly ILogger<PatientAccountController> _logger;
        private readonly IPatientAccountService _service;

        public PatientAccountController(ILogger<PatientAccountController> logger, IPatientAccountService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientAccountModel>> Get(int accountId)
        {
            
            return Ok(_service.Read(accountId));
        }

        [HttpPost]
        public ActionResult<PatientAccountModel> CreateAccount(PatientAccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_service.Create(account));
        }

        [HttpPut]
        public ActionResult<PatientAccountModel> UpdateAccount(PatientAccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_service.Update(account));
        }

        [HttpDelete]
        public ActionResult<PatientAccountModel> DeleteAccount(PatientAccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_service.Delete(account));
        }
    }
}
