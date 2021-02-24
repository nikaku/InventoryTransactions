using System;

namespace Marketplace.Core.Command
{
    public abstract class Command : Message.Message
    {
        public DateTime TimeStamp { get; protected set; }
        protected Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
