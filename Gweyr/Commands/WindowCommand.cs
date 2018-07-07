using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Gweyr.Commands
{
    public class WindowCommand : CommandBase<WindowCommand>
    {
        public override void Execute(object parameter)
        {
            ApplicationCommands.WindowStateCommand.Execute(parameter);
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
