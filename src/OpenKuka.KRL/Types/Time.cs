using OpenKuka.KRL.DataParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenKuka.KRL.Types
{
    public struct DATE
    {
        public int? CSEC { get; set; }
        public int? SEC { get; set; }
        public int? MIN { get; set; }
        public int? HOUR { get; set; }
        public int? DAY { get; set; }
        public int? MONTH { get; set; }
        public int? YEAR { get; set; }

        public DATE(DateTime date)
        {
            CSEC = date.Millisecond;
            SEC = date.Second;
            MIN = date.Minute;
            HOUR = date.Hour;
            DAY = date.Day;
            MONTH = date.Month;
            YEAR = date.Year;
        }
        public DATE(Data data) : this()
        {
            var tree = data as StrucData;

            if (tree == null)
                throw new ArgumentException("The data provided is not a DATE", "data");

            if (tree.StrucType != "DATE")
                throw new ArgumentException("The data provided is not of type DATE");

            if (tree.Value.ContainsKey("CSEC")) CSEC = ((IntData)tree.Value["CSEC"]).Value;
            if (tree.Value.ContainsKey("SEC")) SEC = ((IntData)tree.Value["SEC"]).Value;
            if (tree.Value.ContainsKey("MIN")) MIN = ((IntData)tree.Value["MIN"]).Value;
            if (tree.Value.ContainsKey("HOUR")) HOUR = ((IntData)tree.Value["HOUR"]).Value;
            if (tree.Value.ContainsKey("DAY")) DAY = ((IntData)tree.Value["DAY"]).Value;
            if (tree.Value.ContainsKey("MONTH")) MONTH = ((IntData)tree.Value["MONTH"]).Value;
            if (tree.Value.ContainsKey("YEAR")) YEAR = ((IntData)tree.Value["YEAR"]).Value;
        }

        public DateTime ToDateTime() => new DateTime(YEAR ?? 0, MONTH ?? 0, DAY ?? 0, HOUR ?? 0, MIN ?? 0, SEC ?? 0, CSEC ?? 0, DateTimeKind.Unspecified);
        public override string ToString()
        {
            return ToString();
        }
        public string ToString(bool showType = true)
        {
            var items = new List<string>();

            if (CSEC.HasValue) items.Add(string.Format("CSEC {0}", CSEC));
            if (SEC.HasValue) items.Add(string.Format("SEC {0}", SEC));
            if (MIN.HasValue) items.Add(string.Format("MIN {0}", MIN));
            if (HOUR.HasValue) items.Add(string.Format("HOUR {0}", HOUR));
            if (DAY.HasValue) items.Add(string.Format("DAY {0}", DAY));
            if (MONTH.HasValue) items.Add(string.Format("MONTH {0}", MONTH));
            if (YEAR.HasValue) items.Add(string.Format("YEAR {0}", YEAR));

            var cmd = showType ? "{DATE: " : "{";
            cmd += string.Join(", ", items) + "}";
            return cmd;
        }
    }
}
