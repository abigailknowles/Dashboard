using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientWarningApp.Api.MedicalRecords.Interfaces;
using PatientWarningApp.Api.MedicalRecords.Models;

namespace PatientWarningApp.Api.MedicalRecords
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {

        private readonly ILogger<MedicalRecordController> _logger;
        private readonly IMedicalRecordService _service;

        public MedicalRecordController(ILogger<MedicalRecordController> logger, IMedicalRecordService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MedicalRecordModel>> Get(int id)
        {
            
            return Ok(_service.Read(id));
        }

        [HttpPost]
        public ActionResult<MedicalRecordModel> CreateMedicalRecord(MedicalRecordModel medicalRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_service.Create(medicalRecord));
        }

        [HttpPut]
        public ActionResult<MedicalRecordModel> UpdateMedicalRecord(MedicalRecordModel medicalRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_service.Update(medicalRecord));
        }

        [HttpDelete]
        public ActionResult<MedicalRecordModel> DeleteMedicalRecord(MedicalRecordModel medicalRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_service.Delete(medicalRecord));
        }
    }
}
