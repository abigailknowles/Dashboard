using System.Collections.Generic;
using PatientWarningApp.Api.Media.Models;

namespace PatientWarningApp.Api.Media.Interfaces
{
    public interface IMediaService
    {
        MediaModel Create(MediaModel model);
        MediaModel Delete(MediaModel model);
        MediaModel Read(int id);
        MediaModel Update(MediaModel model);
        List<MediaModel> ReadAll();
    }
}