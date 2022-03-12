using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;
using FirstAzureFunction.Services;

[assembly: WebJobsStartup(typeof(FirstAzureFunction.Startup))]
namespace FirstAzureFunction
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.TryAddTransient<IUserService, UserService>();            
        }
    }
}
