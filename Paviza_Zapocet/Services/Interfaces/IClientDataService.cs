using Microsoft.EntityFrameworkCore;
using Paviza_Zapocet.Data.Model;

namespace Paviza_Zapocet.Services.Interfaces
{
    public interface IClientDataService
    {
        ClientDataResponseDto AddClientData(List<ClientDataDto> clientDataDto);

        List<ClientDataExport> GetClientData();

    }
}
