using PatientWarningApp.Data.Entities;
using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.Mappers
{
    public static class ReviewedMediaMapper
    {
        public static ReviewedMedia ToEntity(this ReviewedMediaModel model) => (model == null) ? null : new ReviewedMedia
        {
            Id = model.Id,
            SeizureTriggerTimes = model.SeizureTriggerTimes,
            EpilepsyRating = model.EpilepsyRating,
            Notes = model.Notes
        };

        public static ReviewedMediaModel ToModel(this ReviewedMedia entity) => (entity == null) ? null : new ReviewedMediaModel
        {
            Id = entity.Id,
            SeizureTriggerTimes = entity.SeizureTriggerTimes,
            EpilepsyRating = entity.EpilepsyRating,
            Notes = entity.Notes
        };
    }
}
