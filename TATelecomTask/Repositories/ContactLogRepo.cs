using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TATelecomTask.Contexts;
using TATelecomTask.Domain;

namespace TATelecomTask.Repositories
{
    public class ContactLogRepo : IContactLogRepo
    {
        private readonly TaskDBContext _context;

        private const int TakeNumber = 10;
        private const int ZeroValue = 0;

        public ContactLogRepo(TaskDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddContanctLogAsync(string message)
        {

            var toBeSendedMessages = await _context.Contacts
                .Where(contact => !contact.ContactLogs.Any(contactLog => contactLog.Contact == contact))
                .Include(c => c.ContactLogs)
                .Take(TakeNumber)
                .ToListAsync();

            if (toBeSendedMessages.Count == ZeroValue)
            {
                return false;
            }

            toBeSendedMessages.ForEach(contact => contact.ContactLogs.Add(ContactLog.New(message)));

            await _context.SaveChangesAsync();

            return true;
        }
    }
}