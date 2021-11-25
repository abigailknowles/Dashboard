using PatientWarningApp.Data.Entities;
using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.Mappers
{
    public static class PatientMapper
    {
        public static Patient ToEntity(this PatientModel model) => (model == null) ? null : new Patient
        {
            PatientId = model.PatientId,
            Title = model.Title,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Gender = model.Gender,
            DOB = model.DOB,
            MobileNumber = model.MobileNumber
        };

        public static PatientModel ToModel(this Patient entity) => (entity == null) ? null : new PatientModel
        {
            PatientId = entity.PatientId,
            Title = entity.Title,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Gender = entity.Gender,
            DOB = entity.DOB,
            MobileNumber = entity.MobileNumber
        };
    }
}
