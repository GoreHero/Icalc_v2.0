using Icalc_v2._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Icalc_v2._0.ViewModels
{
    internal class MainWindowViewModels : INotifyPropertyChanged //уведомление о том что произошли изменения
    {
        string inputText = ""; //ввод
        string printText = ""; //вывод


        public event PropertyChangedEventHandler PropertyChanged; //событие

        public string InputText
        {
            protected set
            {
                bool previousCanExecuteDeleteChar = this.CanExecuteDeleteCharacter(null);

                if (this.SetProperty<string>(ref inputText, value))
                {
                    this.printText = FormatText(inputText);

                    if (previousCanExecuteDeleteChar != this.CanExecuteDeleteCharacter(null))
                        this.DeleteCharacterCommand.RaiseCanExecuteChanged();
                }
            }
            get { return inputText; }
        }

        public string PrintText
        {
            protected set { this.SetProperty<string>(ref printText, value); }
            get { return printText; }
        }

        // Реализация ICommand
        public IDelegateCommand AddCharacterCommand { protected set; get; }
        public IDelegateCommand DeleteCharacterCommand { protected set; get; }

        // Методы Execute() и CanExecute() 
        void ExecuteAddCharacter(object param)
        {
            this.inputText += param as string;
        }

        void ExecuteDeleteCharacter(object param)
        {
            this.inputText = this.inputText.Substring(0, this.inputText.Length - 1);
        }

        bool CanExecuteDeleteCharacter(object param)
        {
            return this.inputText.Length > 0;
        }

        // Закрытый метод, вызываемый из InputString
        private string FormatText(string str)
        {
            
            string formatted = str;

            if (str.Length < 8)
            {
                formatted = String.Format("{0}-{1}", str.Substring(0, 3),
                                                     str.Substring(3));
            }
            else
            {
                formatted = String.Format("({0}) {1}-{2}", str.Substring(0, 3),
                                                           str.Substring(3, 3),
                                                           str.Substring(6));
            }
            return formatted;
        }

        protected bool SetProperty<T>(ref T storage, T value,
                                      [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }




        //void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        //}


        double n1 = 1;

        private string number1;
        public string Number1
        {
            get => number1;
            set
            {
                number1 = value;
            }
        }
        private string number2;
        public string Number2
        {
            get => number2;
            set
            {
                number2 = value;
            }
        }



        //CMD_PLUS<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<PLUS
        public ICommand PlusCommand { get; }
        private void OnPlusCommandExecute(object p)
        {
            inputText = Ariph.Plus(Number1, number2);
        }
        private bool CanPlusCommandExecute(object p)
        {
            return true;
        }

        //CMD_ADD<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<ADD
        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object p)
        {
            inputText = AddNumbers.AddNum(PrintText,inputText);
        }
        private bool CanAddCommandExecute(object p)
        {
            return true;
        }
        //CMD_EXIT<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<EXIT
        public ICommand ExitCommand { get; }
        private void OnExitCommandExecute(object p)
        {
            Application.Current.Shutdown();
        }
        private bool CanExitCommandExecute(object p)
        {
            return true;
        }


        public MainWindowViewModels()
        {
            PlusCommand = new RelayCommand(OnPlusCommandExecute, CanPlusCommandExecute);
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecute);
            ExitCommand = new RelayCommand(OnExitCommandExecute, CanExitCommandExecute);

            this.AddCharacterCommand = new DelegateCommand(ExecuteAddCharacter);
            this.DeleteCharacterCommand = new DelegateCommand(ExecuteDeleteCharacter, CanExecuteDeleteCharacter);


        }


    }
}
