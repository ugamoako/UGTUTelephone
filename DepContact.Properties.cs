using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace UGTUTelephone
{
    public partial class DepContact
    {
	
    
        public string ActualPhoneNumber
        {
            get
            {
                return string.IsNullOrEmpty(Phone) ? CalcFromIP() : Phone;
            }
            set
            {
                Phone = value;
            }
        }

        private string CalcFromIP()
        {
            if (string.IsNullOrEmpty(IP_Phone)) return string.Empty;
            var firstDig = int.Parse(IP_Phone[0].ToString());
            var prefix = string.Empty;
            switch (firstDig)
            {
                case 2:
                case 3: prefix = "700"; break;
                case 4:
                case 5: prefix = "774"; break;
                case 6:
                case 7: prefix = "738"; break;
                default:
                    return string.Empty;
            }
            return prefix + IP_Phone;
        }
    }
}