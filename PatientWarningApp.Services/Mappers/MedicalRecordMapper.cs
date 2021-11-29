using PatientWarningApp.Data.Entities;
using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.Mappers
{
    public static class MedicalRecordMapper
    {
        public static MedicalRecord ToEntity(this MedicalRecordModel model) => (model == null) ? null : new MedicalRecord
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

        public static MedicalRecordModel ToModel(this MedicalRecord entity) => (entity == null) ? null : new MedicalRecordModel
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
