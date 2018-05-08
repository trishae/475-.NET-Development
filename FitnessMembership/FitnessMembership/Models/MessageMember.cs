namespace FitnessMembership.Models
{
    public class MessageMember : Member
    {
        public MessageMember(string fName, string lName, string mail, string message) : base(fName, lName, mail)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
