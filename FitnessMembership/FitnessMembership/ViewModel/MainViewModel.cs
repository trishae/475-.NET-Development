using FitnessMembership.Models;
using FitnessMembership.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FitnessMembership.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Member> memberList;

        private Member selectedMember;

        private MemberDB database;

        public ICommand ExitCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand ChangeCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            memberList = new ObservableCollection<Member>();
            database = new MemberDB(memberList);
            //members = database.GetMemberships();
            AddCommand = new RelayCommand(AddAction);
            ExitCommand = new RelayCommand<IClosable>(ExitAction);
            ChangeCommand = new RelayCommand(ChangeAction);
            Messenger.Default.Register<MessageMember>(this, ReceiveMember);
            Messenger.Default.Register<NotificationMessage>(this, ReceiveMessage);
        }

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

        /// <summary>
        /// 
        /// </summary>
        public void AddAction()
        {
            AddWindow add = new AddWindow();
            add.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="window"></param>
        public void ExitAction(IClosable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ChangeAction()
        {
            if (SelectedMember != null)
            {
                ChangeWindow change = new ChangeWindow();
                change.Show();
                Messenger.Default.Send(new ChangeViewModel());
            }
        }

        /// <summary>
        /// Gets a new member for the list.
        /// </summary>
        /// <param name="m">The member to add. The message denotes how it is added.
        /// "Update" replaces at the specified index, "Add" adds it to the list.</param>
        public void ReceiveMember(MessageMember m)
        {
            if (m.Message == "Update")
            {
                var i = MemberList.IndexOf(selectedMember);
                MemberList[i] = new Member(m.FirstName, m.LastName, m.Email);
                database.SaveMemberships(MemberList);
            }
            else if (m.Message == "Add")
            {
                MemberList.Add(new Member(m.FirstName, m.LastName, m.Email));
                database.SaveMemberships(MemberList);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void ReceiveMessage(NotificationMessage msg)
        {
            if (msg.Notification == "Delete")
            {
                MemberList.Remove(selectedMember);
                database.SaveMemberships();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Member> MemberList
        {
            get { return database.GetMemberships(); }
        }
    }
}