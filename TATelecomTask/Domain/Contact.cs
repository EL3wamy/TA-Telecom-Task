using System.Collections.Generic;

namespace TATelecomTask.Domain
{
    public class Contact
    {
        public int Id { get; private set; }

        public string MobileNumber { get; private set; }

        public virtual List<ContactLog> ContactLogs { get; private set; }

        public static Contact New(string phoneNumber, int id)
        {
            return new Contact
            {
                Id = id,
                MobileNumber = phoneNumber
            };
        }
    }
}
