using FitnessMembership.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using System.Windows.Input;

namespace FitnessMembership.ViewModel
{
    /// <summary>
    /// The VM for modifying or removing users.
    /// </summary>
    public class ChangeViewModel : ViewModelBase
    {
        private string enteredFName;
        private string enteredLName;
        private string enteredEmail;
        private Member selectedMember;
        
        public ICommand UpdateCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public ChangeViewModel()
        {
            UpdateCommand = new RelayCommand<IClosable>(UpdateAction);
            DeleteCommand = new RelayCommand<IClosable>(DeleteAction);
            Messenger.Default.Register<Member>(this, GetSelected);
        }
        

        /// <summary>
        /// Sends a valid member to the main VM to replace at the selected index with,
        /// then closes the change window.
        /// </summary>
        /// <param name="window">The window to close.</param>
        public void UpdateAction(IClosable window)
        {
            try
            {
                Messenger.Default.Send(new MessageMember(enteredFName, enteredLName, enteredEmail, "Update"));
                window.Close();
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
        /// <summary>
        /// Sends out a message to initiate closing the change window.
        /// </summary>
        /// <param name="window">The window to close.</param>
        public void DeleteAction(IClosable window)
        {
            if (window != null)
            {
                Messenger.Default.Send(new NotificationMessage("Delete"));
                window.Close();
            }
        }
        /// <summary>
        /// Receives a member from the main VM to auto-fill the change box with the
        /// currently selected member.
        /// </summary>
        /// <param name="m">The member data to fill in.</param>
        public void GetSelected(Member m)
        {
            selectedMember = m;
        }

        /// <summary>
        /// The currently entered first name in the change window.
        /// </summary>
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