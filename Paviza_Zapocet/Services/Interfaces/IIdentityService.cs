using Microsoft.EntityFrameworkCore;

namespace Paviza_Zapocet.Services.Interfaces
{
    public interface IIdentityService
    {

        bool TokenisValid(string token);

    }
}
