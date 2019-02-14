using nucs.JsonSettings;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kukavar.DemoApp
{
    class AppSettings : JsonSettings
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

        public List<string> ReadHistory { get; set; }
        public Dictionary<string, List<String>> ReadTemplateList { get; set; }

        #endregion
        //Step 3: Override parent's constructors
        public AppSettings() { }
        public AppSettings(string fileName) : base(fileName) { }
    }
}
