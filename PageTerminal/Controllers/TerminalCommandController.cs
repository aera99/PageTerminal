using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PageTerminal.Models;
using System.Linq;

namespace PageTerminal.Controllers
{
    public class TerminalCommandController : Controller
    {
        ConnectionToVendista connection = new ConnectionToVendista("part", "part");
        static int selectIdTerminal = 0;
        public ActionResult Index()
        {
            CommandType commands = connection.GetCommandsTypes();
            HistoryCommands historyCommands = connection.GetHistoryCommands(selectIdTerminal);

            CommandsAndHistory commandsAndHistory = new CommandsAndHistory(commands, historyCommands);
            return View(commandsAndHistory);
        }

        [HttpPost]
        public IActionResult GetAllParametres(int idTerminal , int selectCommand, int parametr1 , int parametr2 , int parametr3)
        {
            selectIdTerminal = idTerminal;
            Command cmd = new Command(selectCommand, parametr1, parametr2, parametr3);
            connection.SendCommand(idTerminal, cmd);
            return Redirect("~/");
        }
    }
}
