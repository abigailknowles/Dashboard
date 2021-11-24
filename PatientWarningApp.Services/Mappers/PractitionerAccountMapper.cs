using PatientWarningApp.Data.Entities;
using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.Mappers
{
    public static class PractitionerAccountMapper
    {
        public static PractitionerAccount ToEntity(this PractitionerAccountModel model) => (model == null) ? null : new PractitionerAccount
        {
            PractitionerAccountId = model.PractitionerAccountId,
            Email = model.Email,
            Password = model.Password,
            Username = model.Username
        };

        public static PractitionerAccountModel ToModel(this PractitionerAccount entity) => (entity == null) ? null : new PractitionerAccountModel
        {
            PractitionerAccountId = entity.PractitionerAccountId,
            Email = entity.Email,
            Password = entity.Password,
            Username = entity.Username
        };
    }
}
