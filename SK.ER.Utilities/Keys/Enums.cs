using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ER.Utilities.Keys
{
    public static class Constants
    {
        public const string FORMAT_DATE = "{0:dd/MM/yyyy}";
        public const string FORMAT_DATE_HOUR = "{0:dd/MM/yyyy H:mm}";
        public const string FORMAT_HOUR = "{0:H:mm:ss}";

        public const string Claim_userName = "UserName";
        public const string Claim_userPerfil = "UserPerfil";
    }
    public static class Enums
    {
        public enum eCode : int
        {
            OK = 0,
            ERROR = 1,
            VAL = 2,
            NOAUTH = 3,
            NOTFOUND = 4
        }
        public enum eTypeTemplate : int
        {

        }
    }
}
