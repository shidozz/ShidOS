using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shiboxos.Utils
{
    public class Time
    {
        public static string getDate(string formats)
        {
            string day = DateTime.Now.Day < 10 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
            string date = formats.ToLower().Replace("dd", day).Replace("mm", month).Replace("yy", DateTime.Now.Year.ToString());
            return date;

        }
        public static string getTime(string formats)
        {
            string Hours = DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString();
            string Minutes = DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString();
            string Seconds = DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString();
            string time = formats.ToLower().Replace("hh", Hours).Replace("mm", Minutes).Replace("ss", Seconds);
            return time;

        }

    }
}
