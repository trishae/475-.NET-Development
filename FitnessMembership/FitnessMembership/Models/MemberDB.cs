using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace FitnessMembership.Models
{
    public class MemberDB : ObservableObject
    {
        private ObservableCollection<Member> members;

        private const string filepath = "../members.txt";

        public MemberDB()
        {
        }

        public MemberDB(ObservableCollection<Member> m)
        {
            members = m;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Member> GetMemberships()
        {
            try
            {
                StreamReader input = new StreamReader(new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read));

                input.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid e-mail address format.");
            }
            return members;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveMemberships(ObservableCollection<Member> newMembers)
        {
            try
            {
                using (StreamWriter output = new StreamWriter(new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    foreach(Member m in newMembers)
                    {
                        output.Write(m.GetDisplayText());
                        output.WriteLine();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveMemberships()
        {
            try
            {
                using (StreamWriter output = new StreamWriter(new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    foreach (Member m in members)
                    {
                        output.Write(m.GetDisplayText());
                        output.WriteLine();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("");
            }
        }
    }
}
