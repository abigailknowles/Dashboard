using PatientWarningApp.Api.ReviewedMedia.Entities;
using PatientWarningApp.Api.ReviewedMedia.Models;

namespace PatientWarningApp.Api.ReviewedMedia
{
    public static class ReviewedMediaMapper
    {
        public static ReviewedMediaEntity ToEntity(this ReviewedMediaModel model) => (model == null) ? null : new ReviewedMediaEntity
        {
            Id = model.Id,
            SeizureTriggerTimes = model.SeizureTriggerTimes,
            EpilepsyRating = model.EpilepsyRating,
            Notes = model.Notes
        };

        public static ReviewedMediaModel ToModel(this ReviewedMediaEntity entity) => (entity == null) ? null : new ReviewedMediaModel
        {
            Id = entity.Id,
            SeizureTriggerTimes = entity.SeizureTriggerTimes,
            EpilepsyRating = entity.EpilepsyRating,
            Notes = entity.Notes
        };
    }
}
