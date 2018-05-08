using FitnessMembership.Models;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FitnessMembership.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Member> members;

        private Member selectedMember;

        private MemberDB database;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //members =
            //database = 
            //members = database.GetMemberships();
            //AddCommand = 
            //ExitCommand = 
            //ChangeCommand =
            //Messenger.Default.Register<MessageMember>(this, ReceiveMember);
            //Messenger.Default.Register<NotificationMessage>(this.ReceiveMessage);
        }

        public ICommand AddCommand { get; private set; }

        public Member SelectedMember
        {
            get
            {
                return selectedMember;
            }
            set
            {
                selectedMember = value;
                RaisePropertyChanged("SelectedMember");
            }
        }

        public void Add()
        {
            AddWindow add new AddWindow();
            add.Show();
        }

        public void Exit(IClosable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        public void Change()
        {
            if (SelectedMember != null)
            {
                ChangeWindow change = new ChangeWindow();
                change.Show();
                MessengerInstance.Default.Send();
            }
        }
    }
}