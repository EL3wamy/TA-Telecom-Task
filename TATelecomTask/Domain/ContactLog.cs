using System;

namespace TATelecomTask.Domain
{
    public class ContactLog
    {
        public int Id { get; private set; }

        public DateTime CreationDate { get; private set; }

        public string Message { get; private set; }

        public virtual Contact Contact { get; private set; }

    }
}
