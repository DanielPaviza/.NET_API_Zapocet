using Paviza_Zapocet.Data;

namespace Paviza_Zapocet.Services
{

    public class MasterService
    {
        internal ApplicationDbContext _context;
        public MasterService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
