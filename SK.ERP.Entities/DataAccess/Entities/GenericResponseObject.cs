using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static SK.ER.Utilities.Keys.Enums;

namespace SK.ERP.Entities.DataAccess.Entities
{
    public class GenericResponseObject
    {
        public eCode Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
