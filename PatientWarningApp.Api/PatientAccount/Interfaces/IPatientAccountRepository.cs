using PatientWarningApp.Api.PatientAccount.Entities;
using PatientWarningApp.Api.Shared.Repositories;

namespace PatientWarningApp.Api.PatientAccount.Interfaces
{
    public interface IPatientAccountRepository : Repository<PatientAccountEntity>
    {
    }
}