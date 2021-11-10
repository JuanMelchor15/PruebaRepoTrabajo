using SK.ERP.Entities.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Business.DataAccess.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(MessageEmail messageEmail);
    }
}
