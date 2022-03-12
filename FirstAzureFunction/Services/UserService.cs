using FirstAzureFunction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAzureFunction.Services
{
    public class UserService : IUserService
    {
        public string Greetings(UserE user)
        {
            return $"Hello, {user.name}. This HTTP triggered function executed successfully.";
        }

        public string TimeTrigger()
        {
            return $"C# Timer trigger function executed at: {DateTime.Now}";
        }
    }
}
