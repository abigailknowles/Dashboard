using Microsoft.Extensions.DependencyInjection;
using PatientWarningApp.Api.Media;
using PatientWarningApp.Api.Media.Interfaces;
using PatientWarningApp.Api.MedicalRecords;
using PatientWarningApp.Api.MedicalRecords.Interfaces;
using PatientWarningApp.Api.Patient;
using PatientWarningApp.Api.Patient.Interfaces;
using PatientWarningApp.Api.PatientAccount;
using PatientWarningApp.Api.PatientAccount.Interfaces;
using PatientWarningApp.Api.Practitioner;
using PatientWarningApp.Api.Practitioner.Interfaces;
using PatientWarningApp.Api.PractitionerAccount;
using PatientWarningApp.Api.PractitionerAccount.Interfaces;
using PatientWarningApp.Api.ReviewedMedia;
using PatientWarningApp.Api.ReviewedMedia.Interfaces;

namespace PatientWarningApp.Api.Shared
{
    public static class ServicesIoc
    {
        public static IServiceCollection AddServicesDi(this IServiceCollection services) {
            services.AddScoped<IPractitionerAccountService, PractitionerAccountService>();
            services.AddScoped<IPatientAccountService, PatientAccountService>();
            services.AddScoped<IPractitionerService, PractitionerService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<IReviewedMediaService, ReviewedMediaService>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();

            return services;

        }
    }
}
