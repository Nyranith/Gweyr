using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Gweyr.Common; 

namespace Gweyr.PropertyWriter.ViewModels
{
    public class ViewPropertyWriterViewModel : BindableBase
    {

        public DelegateCommand<string> TextChangedCommand { get; private set; }

        public DelegateCommand OnPressCommand { get; private set; }

        private string _propertyType; 

        public string PropertyType
        {
            get
            {
                return _propertyType;
            }
            set
            {
                SetProperty(ref _propertyType, value); 
            }
        }

        private string _name; 

        public string Name
        {
            get
            {
                return _name; 
            } 
            set
            {
                SetProperty(ref _name, value); 
            }
        }

        private string _textBox;

        public string TextBox
        {
            get
            {
                return _textBox; 
            }
            set
            {
                SetProperty(ref _textBox, value); 
            }
        }

        public ViewPropertyWriterViewModel()
        {
            OnPressCommand = new DelegateCommand(CreatePropery); 
        }


        public void CreatePropery()
        {
            var name = Name.FirstToUpper();
            var privateName = '_' + Name.ToLower();
            
            var sb = new StringBuilder();
            sb.Append("private " + PropertyType + " " + privateName + ";");
            sb.Append(Environment.NewLine);
            sb.Append("public " + PropertyType + " " + name);
            sb.Append('{');
            sb.AppendLine();
            sb.Append("get{ ");
            sb.AppendLine();
            sb.Append("return " + privateName + ";");
            sb.AppendLine();
            sb.Append(" }");
            sb.AppendLine();
            sb.Append("set{ ");
            sb.AppendLine();
            sb.Append("if(" + privateName + " != value){");
            sb.AppendLine();
            sb.Append(privateName + "= value;");
            sb.AppendLine();
            sb.Append("OnPropertyChanged(" + '"' + name + '"' + ");");
            sb.AppendLine();
            sb.Append('}');
            sb.AppendLine();
            sb.Append('}');
            sb.AppendLine();
            sb.Append('}');
            sb.AppendLine();

            
            TextBox = sb.ToString();
            Clipboard.SetText(sb.ToString());
        }

    }
}
