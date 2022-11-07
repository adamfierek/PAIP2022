using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalculatorWPF.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string numberString = "";
        private List<string> components = new List<string>();
        public string EquationValue => string.Join(null, components) + numberString;
        public string ResultValue { get; set; } = "";
        public Command Exit { get; }
        public Command<string> TypeNumber { get; }
        public Command TypeCancel { get; }
        public Command<string> TypeOperation { get; }
        public Command TypeEquals { get; }

        public MainWindowViewModel()
        {
            Exit = new Command(_Exit);
            TypeNumber = new Command<string>(_TypeNumber);
            TypeCancel = new Command(_TypeCancel);
            TypeOperation = new Command<string>(_TypeOperation);
            TypeEquals = new Command(_TypeEquals);
        }

        private void _TypeEquals()
        {
            if (numberString != "")
            {
                components.Add(numberString);
                numberString = "";
            }
            ResultValue = GetResult();
            RaisePropertyChanged(nameof(ResultValue));
        }

        private string GetResult()
        {
            //TODO: implement ONP equation solver
            return "xDD";
        }

        private void _TypeOperation(string obj)
        {
            if (numberString != "")
            {
                components.Add(numberString);
                numberString = "";
            }

            components.Add(obj);
            RaisePropertyChanged(nameof(EquationValue));
        }

        private void _TypeCancel()
        {
            if (ResultValue != "")
            {
                components.Clear();
                ResultValue = "";
            }
            else if (numberString != "")
            {
                numberString = numberString.Substring(0, numberString.Length - 1);
            }
            else if (components.Count > 0)
            {
                components.RemoveAt(components.Count - 1);
            }

            RaisePropertyChanged(nameof(EquationValue));
            RaisePropertyChanged(nameof(ResultValue));
        }

        private void _TypeNumber(string obj)
        {
            numberString += obj;
            RaisePropertyChanged(nameof(EquationValue));
        }

        private void _Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
