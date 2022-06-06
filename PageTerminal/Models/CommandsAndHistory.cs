using System.Linq;
namespace PageTerminal.Models
{
    public class CommandsAndHistory
    {
        public CommandType commands { get; set; }
        public HistoryCommands historyCommands { get; set; }
        
        public CommandsAndHistory(CommandType commands , HistoryCommands historyCommands)
        {
            this.commands = commands;
            this.historyCommands = historyCommands;
        }

        public string GetNameCommand(int idCommand)
        {
            foreach (var item in commands.items)
            {
                if (item.id == idCommand)
                {
                    return item.name;
                }
            }
            return null;
        }
    }
}
