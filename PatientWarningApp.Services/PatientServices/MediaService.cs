﻿using PatientWarningApp.Data.Repositories;
using PatientWarningApp.Services.Mappers;
using PatientWarningApp.Services.Models;
using System;
using System.Collections.Generic;

namespace PatientWarningApp.Services.PatientServices
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public MediaModel Create(MediaModel model)
        {
            var result = _mediaRepository.Create(model.ToEntity());
            return result.ToModel();
        }

        public MediaModel Delete(MediaModel model)
        {
            var result = _mediaRepository.Delete(model.ToEntity());
            return result.ToModel();
        }

        public MediaModel Read(int id)
        {
            var result = _mediaRepository.Read(id);
            return result.ToModel();
        }

        public List<MediaModel> ReadAll()
        {
            throw new NotImplementedException();
        }

        public MediaModel Update(MediaModel model)
        {
            var result = _mediaRepository.Update(model.ToEntity());
            return result.ToModel();
        }
    }
}
