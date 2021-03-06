using bART.Services;
using bART.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace bART.IoC
{
    public static class AddCustomServicesExtension
    {
        public static void AddCustomServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAccountService, AccountService>();
            serviceCollection.AddTransient<IContactService, ContactService>();
            serviceCollection.AddTransient<IIncidentService, IncidentService>();
        }
    }
}
