using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UGTUTelephone
{
    public class EmailResult
    {
        public bool IsCalculated { get; private set; }

        public string Email { get; private set; }

        public EmailResult (bool isCalculated, string email)
        {
            IsCalculated = isCalculated;
            Email = email;
        }
    }

    public partial class DeptEmplo
    {
        //public string EstimatedEmail
        //{


        //    get { return string.IsNullOrEmpty(Email)? myEmail(Employee):Email; }
        //    set { Email = value; }
        //}
        

        public EmailResult EstimatedEmail
        {
            get
            {
                return new EmailResult(Email == null, Email ?? myEmail(Employee)); 
            }
        }

        //public override string ToString()
        //{
        //    if (Email == null) return myEmail(Employee);
        //    return Email;
        //}


        private string myEmail(string name)
        {
            if (name == null) return "";
            string[] mail = name.Split(' ');
            string email = mail[1].Substring(0, 1).ToLower() + mail[0].ToLower();
            string myem = "";
            string[] arr1 = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            string[] arr = { "a", "b", "v", "g", "d", "e", "io", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h", "ts", "ch", "sh", "csh", "", "i", "", "e", "yu", "ya" };
            foreach (var c in email)
            {
                for (int i = 0; i < arr1.Length; ++i)
                {
                    if (c.ToString() == arr1[i])
                    {
                        myem += arr[i];
                        break;
                    }
                }

            }

            return myem + "@ugtu.net";
        }
    }
}