using nucs.JsonSettings;
using OpenKuka.KRL.Types;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kukavar.DemoApp
{
    internal class AppSettings : JsonSettings
    {
        //Step 2: override a default FileName or keep it empty. Just make sure to specify it when calling Load!
        //This is used for default saving and loading so you won't have to specify the filename/path every time.
        //Putting just a filename without folder will put it inside the executing file's directory.

        public override string FileName { get; set; } = "config.json"; //for loading and saving.

        #region Settings

        public string ServerIP { get; set; }
        public int ServerPort { get; set; }
        public int MaxIdleTime { get; set; }
        public int ReconnectionTimeout { get; set; }
        public bool AutoReconnect { get; set; }

        // READ
        public List<string> ReadHistory { get; set; }
        public Dictionary<string, List<String>> ReadTemplateList { get; set; }

        // WRITE
        public List<WriteVariable> WriteHistory { get; set; }

        // RECORD
        public List<Record> Records { get; set; }

        #endregion
        //Step 3: Override parent's constructors
        public AppSettings() { }
        public AppSettings(string fileName) : base(fileName) { }
    }

    internal class Record
    {
        public int Id { get; set; }
        public DATE Date { get; set; }
        public E6POS POS_ACT { get; set; }
        public E6AXIS AXIS_ACT { get; set; }
        public FRAME BASE { get; set; }

        public FRAME TOOL { get; set; }

        public object[] ToArray()
        {
            var array = new object[40];
            var i  = -1;
            array[++i] = Id;
            array[++i] = Date.ToDateTime();
            array[++i] = POS_ACT.X;
            array[++i] = POS_ACT.Y;
            array[++i] = POS_ACT.Z;
            array[++i] = POS_ACT.A;
            array[++i] = POS_ACT.B;
            array[++i] = POS_ACT.C;
            array[++i] = POS_ACT.E1;
            array[++i] = POS_ACT.E2;
            array[++i] = POS_ACT.E3;
            array[++i] = POS_ACT.E4;
            array[++i] = POS_ACT.E5;
            array[++i] = POS_ACT.E6;
            array[++i] = POS_ACT.S;
            array[++i] = POS_ACT.T;
            array[++i] = AXIS_ACT.A1;
            array[++i] = AXIS_ACT.A2;
            array[++i] = AXIS_ACT.A3;
            array[++i] = AXIS_ACT.A4;
            array[++i] = AXIS_ACT.A5;
            array[++i] = AXIS_ACT.A6;
            array[++i] = AXIS_ACT.E1;
            array[++i] = AXIS_ACT.E2;
            array[++i] = AXIS_ACT.E3;
            array[++i] = AXIS_ACT.E4;
            array[++i] = AXIS_ACT.E5;
            array[++i] = AXIS_ACT.E6;
            array[++i] = BASE.X;
            array[++i] = BASE.Y;
            array[++i] = BASE.Z;
            array[++i] = BASE.A;
            array[++i] = BASE.B;
            array[++i] = BASE.C;
            array[++i] = TOOL.X;
            array[++i] = TOOL.Y;
            array[++i] = TOOL.Z;
            array[++i] = TOOL.A;
            array[++i] = TOOL.B;
            array[++i] = TOOL.C;
            return array;
        }

        public static Record FromDatarow(DataRow dr)
        {
            var rec = new Record();
            var i = -1;

            rec.Id = (int)dr[++i];

            var date = new DATE((DateTime)dr[++i]);
            rec.Date = date;

            var frame = new double[6];
            var axis = new double[6];

            frame[0] = (double)dr[++i];
            frame[1] = (double)dr[++i];
            frame[2] = (double)dr[++i];
            frame[3] = (double)dr[++i];
            frame[4] = (double)dr[++i];
            frame[5] = (double)dr[++i];

            axis[0] = (double)dr[++i];
            axis[1] = (double)dr[++i];
            axis[2] = (double)dr[++i];
            axis[3] = (double)dr[++i];
            axis[4] = (double)dr[++i];
            axis[5] = (double)dr[++i];

            var s = (int)dr[++i];
            var t = (int)dr[++i];

            rec.POS_ACT = new E6POS(frame, axis, s, t);

            frame[0] = (double)dr[++i];
            frame[1] = (double)dr[++i];
            frame[2] = (double)dr[++i];
            frame[3] = (double)dr[++i];
            frame[4] = (double)dr[++i];
            frame[5] = (double)dr[++i];

            axis[0] = (double)dr[++i];
            axis[1] = (double)dr[++i];
            axis[2] = (double)dr[++i];
            axis[3] = (double)dr[++i];
            axis[4] = (double)dr[++i];
            axis[5] = (double)dr[++i];

            rec.AXIS_ACT = new E6AXIS(frame, axis);

            frame[0] = (double)dr[++i];
            frame[1] = (double)dr[++i];
            frame[2] = (double)dr[++i];
            frame[3] = (double)dr[++i];
            frame[4] = (double)dr[++i];
            frame[5] = (double)dr[++i];

            rec.BASE = new FRAME(frame);

            frame[0] = (double)dr[++i];
            frame[1] = (double)dr[++i];
            frame[2] = (double)dr[++i];
            frame[3] = (double)dr[++i];
            frame[4] = (double)dr[++i];
            frame[5] = (double)dr[++i];

            rec.TOOL = new FRAME(frame);

            return rec;
        }
    }
    internal class WriteVariable
    {
        public string VarName { get; set; }
        public string VarValue { get; set; }
    }
}
