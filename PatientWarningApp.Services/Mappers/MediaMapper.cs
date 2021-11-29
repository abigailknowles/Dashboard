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
            ReleaseDate = model.ReleaseDate,
            Director = model.Director
        };

        public static MediaModel ToModel(this Media entity) => (entity == null) ? null : new MediaModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Genre = entity.Genre,
            ReleaseDate = entity.ReleaseDate,
            Director = entity.Director
        };
    }
}
