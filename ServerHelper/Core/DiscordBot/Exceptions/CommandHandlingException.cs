using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHelper.Core.DiscordBot
{
    public  class CommandsHandlingException : Exception
    {
        public Dictionary<PendingCommand, Exception> UnfulfilledCommands { get; set; }

        public CommandsHandlingException()
        {
            UnfulfilledCommands = new Dictionary<PendingCommand, Exception>();
        }
        public CommandsHandlingException AddUnfulfilledCommand(PendingCommand command, Exception exception)
        {
            UnfulfilledCommands.Add(command, exception);
            return this;
        }
    }
}
