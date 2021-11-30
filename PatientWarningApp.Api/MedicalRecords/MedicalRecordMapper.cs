using PatientWarningApp.Api.MedicalRecords.Entities;
using PatientWarningApp.Api.MedicalRecords.Models;

namespace PatientWarningApp.Api.MedicalRecords
{
    public static class MedicalRecordMapper
    {
        public static MedicalRecordEntity ToEntity(this MedicalRecordModel model) => (model == null) ? null : new MedicalRecordEntity
        {
            Id = model.Id,
             StartDate= model.StartDate,
            SeizureTypes = model.SeizureTypes,
            SeizureFrequencies = model.SeizureFrequencies,
            SeizureTimes = model.SeizureTimes,
            SeizureTriggers = model.SeizureTriggers,
            SideEffects = model.SideEffects,
            Notes = model.Notes
        };

        public static MedicalRecordModel ToModel(this MedicalRecordEntity entity) => (entity == null) ? null : new MedicalRecordModel
        {
            Id = entity.Id,
            StartDate = entity.StartDate,
            SeizureTypes = entity.SeizureTypes,
            SeizureFrequencies = entity.SeizureFrequencies,
            SeizureTimes = entity.SeizureTimes,
            SeizureTriggers = entity.SeizureTriggers,
            SideEffects = entity.SideEffects,
            Notes = entity.Notes
        };
    }
}
