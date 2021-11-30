using System.Collections.Generic;
using PatientWarningApp.Api.Media.Models;
using PatientWarningApp.Api.ReviewedMedia.Models;

namespace PatientWarningApp.Api.ReviewedMedia.Interfaces
{
    public interface IReviewedMediaService
    {
        ReviewedMediaModel Create(ReviewedMediaModel model);
        ReviewedMediaModel Delete(ReviewedMediaModel model);
        ReviewedMediaModel Read(int id);
        ReviewedMediaModel Update(ReviewedMediaModel model);
        List<ReviewedMediaModel> ReadAll();
    }
}