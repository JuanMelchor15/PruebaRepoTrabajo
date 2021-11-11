using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Entities.DataAccess.Authentication
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
        public string URLRedirectToLogin { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
