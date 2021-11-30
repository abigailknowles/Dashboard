using PatientWarningApp.Api.Media.Entities;
using PatientWarningApp.Api.Media.Models;

namespace PatientWarningApp.Api.Media
{
    public static class MediaMapper
    {
        public static MediaEntity ToEntity(this MediaModel model) => (model == null) ? null : new MediaEntity
        {
            MediaId = model.MediaId,
            Title = model.Title,
            Genre  = model.Genre,
            ReleaseDate = model.ReleaseDate,
            Director = model.Director
        };

        public static MediaModel ToModel(this MediaEntity entity) => (entity == null) ? null : new MediaModel
        {
            MediaId = entity.MediaId,
            Title = entity.Title,
            Genre = entity.Genre,
            ReleaseDate = entity.ReleaseDate,
            Director = entity.Director
        };
    }
}
