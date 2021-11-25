using PatientWarningApp.Data.Entities;
using PatientWarningApp.Services.Models;

namespace PatientWarningApp.Services.Mappers
{
    public static class MediaMapper
    {
        public static Media ToEntity(this MediaModel model) => (model == null) ? null : new Media
        {
            Id = model.Id,
            Title = model.Title,
            Genre  = model.Genre,
            EpilepsyRating = model.EpilepsyRating,
            Notes = model.Notes
        };

        public static MediaModel ToModel(this Media entity) => (entity == null) ? null : new MediaModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Genre = entity.Genre,
            EpilepsyRating = entity.EpilepsyRating,
            Notes = entity.Notes
        };
    }
}
