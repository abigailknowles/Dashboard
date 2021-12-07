using PatientWarningApp.Api.PractitionerAccount.Entities;
using PatientWarningApp.Api.PractitionerAccount.Models;

namespace PatientWarningApp.Api.PractitionerAccount
{
    public static class PractitionerAccountMapper
    {
        public static PractitionerAccountEntity ToEntity(this PractitionerAccountModel model) => (model == null) ? null : new PractitionerAccountEntity
        {
            PractitionerAccountId = model.PractitionerAccountId,
            PractitionerId = model.PractitionerId,
            Email = model.Email,
            Password = model.Password,
            Username = model.Username
        };

        public static PractitionerAccountModel ToModel(this PractitionerAccountEntity entity) => (entity == null) ? null : new PractitionerAccountModel
        {
            PractitionerAccountId = entity.PractitionerAccountId,
            PractitionerId = entity.PractitionerId,
            Email = entity.Email,
            Password = entity.Password,
            Username = entity.Username
        };
    }
}
