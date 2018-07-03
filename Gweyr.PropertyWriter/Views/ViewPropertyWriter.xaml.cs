using Gweyr.PropertyWriter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gweyr.PropertyWriter.Views
{
    /// <summary>
    /// Interaction logic for ViewPropertyWriter.xaml
    /// </summary>
    public partial class ViewPropertyWriter : UserControl
    {
        public ViewPropertyWriter(ViewPropertyWriterViewModel model)
        {
            InitializeComponent();

            this.DataContext = model; 
        }
    }
}
