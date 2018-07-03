using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Gweyr.PropertyWriter.ViewModels
{
    public class ViewPropertyWriterViewModel : BindableBase
    {

        public DelegateCommand<string> TextChangedCommand { get; private set; }

        public ViewPropertyWriterViewModel()
        {
            TextChangedCommand = new DelegateCommand<string>(TextChanged);
        }

        public void TextChanged(string value)
        {
            Console.WriteLine(value); 
        }

    }
}
