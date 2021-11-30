using System;
using System.Collections.Generic;
using PatientWarningApp.Api.ReviewedMedia.Interfaces;
using PatientWarningApp.Api.ReviewedMedia.Models;

namespace PatientWarningApp.Api.ReviewedMedia
{
    public class ReviewedMediaService : IReviewedMediaService
    {
        private readonly IReviewedMediaRepository _reviewedMediaRepository;

        public ReviewedMediaService(IReviewedMediaRepository reviewedMediaRepository)
        {
            _reviewedMediaRepository = reviewedMediaRepository;
        }

        public ReviewedMediaModel Create(ReviewedMediaModel model)
        {
            var result = _reviewedMediaRepository.Create(model.ToEntity());
            return result.ToModel();
        }

        public ReviewedMediaModel Delete(ReviewedMediaModel model)
        {
            var result = _reviewedMediaRepository.Delete(model.ToEntity());
            return result.ToModel();
        }

        public ReviewedMediaModel Read(int id)
        {
            var result = _reviewedMediaRepository.Read(id);
            return result.ToModel();
        }

        public List<ReviewedMediaModel> ReadAll()
        {
            throw new NotImplementedException();
        }

        public ReviewedMediaModel Update(ReviewedMediaModel model)
        {
            var result = _reviewedMediaRepository.Update(model.ToEntity());
            return result.ToModel();
        }
    }
}
