using Gweyr.Commands;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gweyr.ViewModels.Content
{
    public class MenuViewModel : BindableBase
    {
        public DelegateCommand<Type> ChangeWindowCommand { get; set; }

        public MenuViewModel()
        {
            ChangeWindowCommand = new DelegateCommand<Type>(ChangeWindowCommandHandler);
        }

        private void ChangeWindowCommandHandler(Type obj)
        {
            ApplicationCommands.NavigateCommand.Execute(obj);
        }

    }
}
