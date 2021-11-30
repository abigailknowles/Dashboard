using PatientWarningApp.Api.Practitioner.Entities;
using PatientWarningApp.Api.Practitioner.Models;

namespace PatientWarningApp.Api.Practitioner
{
    public static class PractitionerMapper
    {
        public static PractitionerEntity ToEntity(this PractitionerModel model) => (model == null) ? null : new PractitionerEntity
        {
            PractitionerId = model.PractitionerId,
            Title = model.Title,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Gender = model.Gender,
            DOB = model.DOB,
            MobileNumber = model.MobileNumber,
            Address= model.Address,
            Postcode = model.Postcode
        };

        public static PractitionerModel ToModel(this PractitionerEntity entity) => (entity == null) ? null : new PractitionerModel
        {
            PractitionerId = entity.PractitionerId,
            Title = entity.Title,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Gender = entity.Gender,
            DOB = entity.DOB,
            MobileNumber = entity.MobileNumber,
            Address = entity.Address,
            Postcode = entity.Postcode
        };
    }
}
