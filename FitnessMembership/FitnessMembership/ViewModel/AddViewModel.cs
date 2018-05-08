using GalaSoft.MvvmLight;
using System;
using System.Windows.Input;

namespace FitnessMembership.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        private string enteredFName;
        private string enteredLName;
        private string enteredEmail;

        public AddViewModel()
        {
            SaveCommand = new RelayCommand<IClosable>(SaveMethod);
            //
        }

        public ICommand SaveCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public void Save(IClosable window)
        {
            try
            {
                if (window != null)
                {
                    MessengerInstance.Default.Send();
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
    }
}
