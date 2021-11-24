using PatientWarningApp.Data.Entities;
using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.Mappers
{
    public static class PatientAccountMapper 
    {
        public static PatientAccount ToEntity(this PatientAccountModel model) => (model == null) ? null : new PatientAccount
        {
            PatientAccountId = model.PatientAccountId,
            PractitionerAccountId = model.PractitionerAccountId,
            Email = model.Email,
            Password = model.Password,
            Username = model.Username
        };

        public static PatientAccountModel ToModel(this PatientAccount entity) => (entity == null) ? null : new PatientAccountModel
        {
            PatientAccountId = entity.PatientAccountId,
            PractitionerAccountId = entity.PractitionerAccountId,
            Email = entity.Email,
            Password = entity.Password,
            Username = entity.Username
        };
    }
}
