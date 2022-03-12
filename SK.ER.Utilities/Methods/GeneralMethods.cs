using System;
using System.Collections.Generic;
using System.Text;
using TimeZoneConverter;

namespace SK.ER.Utilities.Methods
{
    public class GeneralMethods
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static DateTime FechaActualLimaQuito()
        {
            TimeZoneInfo info = TZConvert.GetTimeZoneInfo("America/Lima");
            DateTime dt_peru = TimeZoneInfo.ConvertTime(DateTime.Now, info);
            return dt_peru;
        }
        public static TimeSpan DiasRestantes(DateTime Fecha1, DateTime Fecha2)
        {

            TimeSpan Diff_dates = Fecha2.Subtract(Fecha1);
            return Diff_dates;
        }
    }
}
