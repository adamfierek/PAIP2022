using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;

namespace CalculatorWPF.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string numberString = "";
        private List<string> components = new();
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
            var operatorList = new List<string>() { "+", "-", "*", "/" };
            var componentsOnp = new List<string>();
            var stack = new Stack<string>();

            foreach (var c in components)
            {
                if (!operatorList.Contains(c))
                {
                    componentsOnp.Add(c);
                    continue;
                }
                else if (c == "(")
                {
                    stack.Push(c);
                    continue;
                }
                else if (c == ")")
                {
                    while (stack.Count > 0)
                    {
                        var op = stack.Pop();
                        if (op == "(") break;
                        componentsOnp.Add(op);
                    }
                }
                else
                {
                    var stack_pr = -1;
                    var c_pr = c is "+" or "-" or "(" ? 0 : 1;

                    if (stack.Count != 0)
                    {
                        var s = stack.Peek();
                        stack_pr = s is "+" or "-" or "(" ? 0 : 1;
                    }

                    if (c_pr <= stack_pr)
                    {
                        while (stack.Count > 0)
                        {
                            var s = stack.Peek();
                            stack_pr = s is "+" or "-" or "(" ? 0 : 1;
                            if (stack_pr >= c_pr)
                            {
                                if (s is not "(" and not ")")
                                {
                                    componentsOnp.Add(stack.Pop());
                                }
                                else break;
                            }
                            else break;
                        }
                    }
                    stack.Push(c);
                }
            }

            while (stack.Count > 0)
            {
                componentsOnp.Add(stack.Pop());
            }

            stack.Clear();

            foreach (var c in componentsOnp)
            {
                if (!operatorList.Contains(c))
                {
                    stack.Push(c);
                    continue;
                }

                var a = Convert.ToDouble(stack.Pop(), CultureInfo.InvariantCulture);
                var b = Convert.ToDouble(stack.Pop(), CultureInfo.InvariantCulture);

                var result = c switch
                {
                    "+" => b + a,
                    "-" => b - a,
                    "*" => b * a,
                    "/" => b / a,
                    _ => 0
                };

                stack.Push(result.ToString());
            }

            return stack.Pop();
        }

        private void _TypeOperation(string obj)
        {
            if (ResultValue != "")
            {
                components.Clear();
                ResultValue = "";
                RaisePropertyChanged(nameof(ResultValue));
            }

            if (numberString == "" && components.Count == 0 && obj == "-")
            {
                _TypeNumber(obj);
                return;
            }

            if (numberString != "")
            {
                components.Add(numberString);
                numberString = "";
                components.Add(obj);
                RaisePropertyChanged(nameof(EquationValue));
            }
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
                numberString = numberString[0..^1];
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
            if (ResultValue != "")
            {
                components.Clear();
                ResultValue = "";
                RaisePropertyChanged(nameof(ResultValue));
            }
            numberString += obj;
            RaisePropertyChanged(nameof(EquationValue));
        }

        private void _Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
