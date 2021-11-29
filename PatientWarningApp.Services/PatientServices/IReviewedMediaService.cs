using PatientWarningApp.Services.Models;
using System.Collections.Generic;

namespace PatientWarningApp.Services.PatientServices
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