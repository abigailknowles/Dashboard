using Microsoft.Extensions.DependencyInjection;
using PatientWarningApp.Data.Repositories;

namespace PatientWarningApp.Data
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

            return services;

        }
    }
}
