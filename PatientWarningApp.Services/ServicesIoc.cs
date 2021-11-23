using Microsoft.Extensions.DependencyInjection;
using PatientWarningApp.Services.Mappers;
using PatientWarningApp.Services.PatientServices;

namespace PatientWarningApp.Data
{
    public static class ServicesIoc
    {
        public static IServiceCollection AddServicesDi(this IServiceCollection services) {
            services.AddScoped<IPractitionerAccountService, PractitionerAccountService>();
            services.AddScoped<IPatientAccountService, PatientAccountService>();
            services.AddScoped<IPractitionerAccountMapper, PractitionerAccountMapper>();
            services.AddScoped<IPatientAccountMapper, PatientAccountMapper>();
            services.AddScoped<IPatientAccountMapper, PatientAccountMapper>();

            return services;

        }
    }
}
