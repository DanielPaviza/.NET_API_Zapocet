using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paviza_Zapocet.Data;
using Paviza_Zapocet.Services.Interfaces;
using System.Net;

namespace Paviza_Zapocet.Services
{

    public class IdentityService : MasterService, IIdentityService
    {
        public IdentityService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool TokenisValid(string token)
        {

            var result = _context.CompanyKeys
                .Where(x => x.CompanyHash.Equals(token))
                .Any();

            return result;

        }
    }
}
