using Microsoft.Extensions.DependencyInjection;
using PatientWarningApp.Data.Repositories;

namespace PatientWarningApp.Data
{
    public static class DataIoc
    {
        public static IServiceCollection AddDataDi(this IServiceCollection services) {
            services.AddScoped<IPractitionerAccountRepository, PractitionerAccountRepository>();
            services.AddScoped<IPatientAccountRepository, PatientAccountRepository>();

            return services;

        }
    }
}
