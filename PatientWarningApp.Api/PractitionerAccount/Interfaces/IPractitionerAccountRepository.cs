using PatientWarningApp.Api.PractitionerAccount.Entities;
using PatientWarningApp.Api.Shared.Repositories;

namespace PatientWarningApp.Api.PractitionerAccount.Interfaces
{
    public interface IPractitionerAccountRepository : Repository<PractitionerAccountEntity>
    {
        Entities.PractitionerAccountEntity ReadByUsernameAndPassword(PractitionerAccountEntity entity);
    }
}