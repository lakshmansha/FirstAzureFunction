using FirstAzureFunction.Models;

namespace FirstAzureFunction.Services
{
    public interface IUserService
    {
        string Greetings(UserE user);

        string TimeTrigger();
    }
}