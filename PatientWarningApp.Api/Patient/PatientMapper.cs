using PatientWarningApp.Api.Patient.Entities;
using PatientWarningApp.Api.Patient.Models;

namespace PatientWarningApp.Api.Patient
{
    public static class PatientMapper
    {
        public static PatientEntity ToEntity(this PatientModel model) => (model == null) ? null : new PatientEntity
        {
            PatientId = model.PatientId,
            Title = model.Title,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Gender = model.Gender,
            DOB = model.DOB,
            Age = model.Age,
            MobileNumber = model.MobileNumber,
            Address = model.Address,
            Postcode = model.Postcode
        };

        public static PatientModel ToModel(this PatientEntity entity) => (entity == null) ? null : new PatientModel
        {
            PatientId = entity.PatientId,
            Title = entity.Title,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Gender = entity.Gender,
            DOB = entity.DOB,
            Age = entity.Age,
            MobileNumber = entity.MobileNumber,
            Address = entity.Address,
            Postcode = entity.Postcode
        };
    }
}
