using PatientWarningApp.Data.Entities;
using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.Mappers
{
    public class PractitionerAccountMapper : IPractitionerAccountMapper
    {
        public PractitionerAccount ToEntity(PractitionerAccountModel model) => (model == null) ? new PractitionerAccount
        {
            Email = model.Email,
            Password = model.Password,
            Username = model.Username
        } : null;

        public PractitionerAccountModel ToModel(PractitionerAccount entity) => (entity == null) ? new PractitionerAccountModel
        {
            Email = entity.Email,
            Password = entity.Password,
            Username = entity.Username
        } : null;
    }

    public interface IPractitionerAccountMapper
    {
        PractitionerAccount ToEntity(PractitionerAccountModel model);
        PractitionerAccountModel ToModel(PractitionerAccount entity);
    }
}
