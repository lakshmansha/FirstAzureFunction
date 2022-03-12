using System;
using FirstAzureFunction.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FirstAzureFunction
{
    public class FirstTimeTrigger
    {
        private readonly ILogger _log;
        private readonly IUserService _userService;

        public FirstTimeTrigger(ILoggerFactory log, IUserService userService)
        {
            _log = log.CreateLogger<FirstTimeTrigger>();
            _userService = userService;
        }

        [FunctionName("FirstTimeTrigger")]
        public void Run([TimerTrigger("0/10 * * * * *")]TimerInfo myTimer)
        {
            _log.LogInformation(_userService.TimeTrigger());
        }
    }
}
