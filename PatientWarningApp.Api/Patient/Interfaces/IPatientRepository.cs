using PatientWarningApp.Api.Patient.Entities;
using PatientWarningApp.Api.Shared.Repositories;

namespace PatientWarningApp.Api.Patient.Interfaces
{
    public interface IPatientRepository : Repository<PatientEntity>
    {
    }
}