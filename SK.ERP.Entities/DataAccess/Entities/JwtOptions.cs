using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Entities.DataAccess.Entities
{
    public class JwtOptions
    {
        public string AsymmetricKeyPublic { get; set; }
        public string AsymmetricKeyPrivate { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
