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

namespace PatientWarningApp.Api.Shared
{
    public static class DataIoc
    {
        public static IServiceCollection AddDataDi(this IServiceCollection services) {
            services.AddScoped<IPractitionerAccountRepository, PractitionerAccountRepository>();
            services.AddScoped<IPractitionerRepository, PractitionerRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientAccountRepository, PatientAccountRepository>();
            services.AddScoped<IMediaRepository, MediaRepository>();
            services.AddScoped<IReviewedMediaRepository, ReviewedMediaRepository>();
            services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();

            return services;

        }
    }
}
