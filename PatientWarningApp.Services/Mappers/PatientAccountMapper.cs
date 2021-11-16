using PatientWarningApp.Data.Entities;
using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.Mappers
{
    public class PatientAccountMapper : IPatientAccountMapper
    {
        public PatientAccount ToEntity(PatientAccountModel model)
        {
            return new PatientAccount
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username
            };
        }

        public PatientAccountModel ToModel(PatientAccount entity)
        {
            return new PatientAccountModel
            {
                Email = entity.Email,
                Password = entity.Password,
                Username = entity.Username
            };
        }
    }

    public interface IPatientAccountMapper
    {
        PatientAccount ToEntity(PatientAccountModel model);
        PatientAccountModel ToModel(PatientAccount entity);
    }
}
