using PatientWarningApp.Api.Practitioner.Entities;
using PatientWarningApp.Api.Shared.Repositories;

namespace PatientWarningApp.Api.Practitioner.Interfaces
{
    public interface IPractitionerRepository : Repository<PractitionerEntity>
    {
    }
}