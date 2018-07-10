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
using System.CodeDom;
using Microsoft.CSharp;
using System.IO;

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
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit(); 

            if(Name != null && PropertyType != null)
            {
                CodeMemberField propertyField = new CodeMemberField(new CodeTypeReference(PropertyType), '_' + Name.FirstToLower())
                {
                    Attributes = MemberAttributes.Private
                }; 

                CodeMemberProperty propertyValue = new CodeMemberProperty()
                {
                    Type = new CodeTypeReference(PropertyType),
                    Name = Name.FirstToUpper(),
                    Attributes = MemberAttributes.Public | MemberAttributes.Final,
                };
                propertyValue.GetStatements.Add(new CodeMethodReturnStatement(
                        new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), propertyField.Name)));

                var setAssignment = new CodeAssignStatement(
                        new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), propertyField.Name),
                        new CodePropertySetValueReferenceExpression());

                var methodeOnPropertyChanged = new CodeMethodInvokeExpression()
                {
                    Method = new CodeMethodReferenceExpression()
                    {
                        MethodName = "OnPropertyChanged"
                    }
                };

                methodeOnPropertyChanged.Parameters.Add(new CodeSnippetExpression(string.Format("\"{0}\"", propertyValue.Name)));

                CodeConditionStatement codeConditionStatement = new CodeConditionStatement(new CodeBinaryOperatorExpression(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), propertyField.Name), CodeBinaryOperatorType.IdentityInequality, new CodePropertySetValueReferenceExpression()), setAssignment);
                codeConditionStatement.TrueStatements.Add(methodeOnPropertyChanged); 


                propertyValue.SetStatements.Add(codeConditionStatement);

                TextWriter writer = new StringWriter();

                CSharpCodeProvider provider = new CSharpCodeProvider();
                provider.GenerateCodeFromMember(propertyField, writer, null);
                provider.GenerateCodeFromMember(propertyValue, writer, null);

                TextBox = writer.ToString();
                Clipboard.SetText(writer.ToString()); 
            }
        }

    }
}
