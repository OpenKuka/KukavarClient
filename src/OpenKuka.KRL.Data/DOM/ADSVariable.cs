using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenKuka.KRL.Data.DOM
{
    /// <summary>
    /// Abstract Data Syntax representing a KRL variable.
    /// </summary>
    public class ADSVariable
    {
        /// <summary>
        /// The name of the KRL variable.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value (or state) of the KRL variable.
        /// </summary>
        public IADSValue Value { get; set; }
    }
}
