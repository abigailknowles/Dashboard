using PatientWarningApp.Api.PatientAccount.Entities;
using PatientWarningApp.Api.PatientAccount.Models;

namespace PatientWarningApp.Api.PatientAccount
{
    public static class PatientAccountMapper 
    {
        public static PatientAccountEntity ToEntity(this PatientAccountModel model) => (model == null) ? null : new PatientAccountEntity
        {
            PatientAccountId = model.PatientAccountId,
            PractitionerAccountId = model.PractitionerAccountId,
            Email = model.Email,
            Password = model.Password,
            Username = model.Username
        };

        public static PatientAccountModel ToModel(this PatientAccountEntity entity) => (entity == null) ? null : new PatientAccountModel
        {
            PatientAccountId = entity.PatientAccountId,
            PractitionerAccountId = entity.PractitionerAccountId,
            Email = entity.Email,
            Password = entity.Password,
            Username = entity.Username
        };
    }
}
