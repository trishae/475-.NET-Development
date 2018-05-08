using GalaSoft.MvvmLight;
using System;

namespace FitnessMembership.Models
{
    public class Member : ObservableObject
    {
        private int TEXT_LIMIT = 25;

        private string firstName;
        private string lastName;
        private string email;

        public Member()
        {
        }

        public Member(string fName, string lName, string mail)
        {
            this.firstName = fName;
            this.lastName = lName;
            this.email = mail;
        }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value.Length > TEXT_LIMIT)
                {
                    throw new ArgumentException("Too long");
                }

                if (value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                firstName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value.Length > TEXT_LIMIT)
                {
                    throw new ArgumentException("Too long");
                }

                if (value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                lastName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value.Length > TEXT_LIMIT)
                {
                    throw new ArgumentException("Too long");
                }

                if (value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                if (value.IndexOf("@") == -1 || value.IndexOf(".") == -1)
                {
                    throw new FormatException();
                }

                email = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetDisplayText()
        {
            return firstName + " " + lastName + " - " + email;
        }
    }
}
