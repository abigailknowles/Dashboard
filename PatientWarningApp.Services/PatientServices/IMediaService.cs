using PatientWarningApp.Services.Models;
using System.Collections.Generic;

namespace PatientWarningApp.Services.PatientServices
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