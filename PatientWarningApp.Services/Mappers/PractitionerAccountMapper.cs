using PatientWarningApp.Data.Entities;
using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.Mappers
{
    public class PractitionerAccountMapper : IPractitionerAccountMapper
    {
        public PractitionerAccount ToEntity(PractitionerAccountModel model) => (model == null) ? null : new PractitionerAccount
        {
            Id = model.Id,
            Email = model.Email,
            Password = model.Password,
            Username = model.Username
        };

        public PractitionerAccountModel ToModel(PractitionerAccount entity) => (entity == null) ? null : new PractitionerAccountModel
        {
            Id = entity.Id,
            Email = entity.Email,
            Password = entity.Password,
            Username = entity.Username
        };
    }

    public interface IPractitionerAccountMapper
    {
        PractitionerAccount ToEntity(PractitionerAccountModel model);
        PractitionerAccountModel ToModel(PractitionerAccount entity);
    }
}
