using FitnessMembership.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessMembership.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        private string enteredFName;
        private string enteredLName;
        private string enteredEmail;

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public AddViewModel()
        {
            SaveCommand = new RelayCommand<IClosable>(SaveAction);
            CancelCommand = new RelayCommand<IClosable>(CancelAction);
        }

        public void SaveAction(IClosable window)
        {
            try
            {
                if (window != null)
                {
                    Messenger.Default.Send(new MessageMember(enteredFName, enteredLName, enteredEmail, "Add"));
                    window.Close();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Fields must be under 25 characters.", "Entry Error");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Fields cannot be empty.", "Entry Error");
            }
            catch (FormatException)
            {
                MessageBox.Show("Must be a valid e-mail address.", "Entry Error");
            }
        }

        public void CancelAction(IClosable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        public string EnteredFName
        {
            get
            {
                return enteredFName;
            }
            set
            {
                enteredFName = value;
                RaisePropertyChanged("EnteredFName");
            }
        }

        public string EnteredLName
        {
            get
            {
                return enteredLName;
            }
            set
            {
                enteredLName = value;
                RaisePropertyChanged("EnteredLName");
            }
        }

        public string EnteredEmail
        {
            get
            {
                return enteredEmail;
            }
            set
            {
                enteredEmail = value;
                RaisePropertyChanged("EnteredEmail");
            }
        }
    }
}
