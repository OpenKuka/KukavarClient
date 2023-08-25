using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenKuka.KRL.Data.DOM
{
    [DataContract]
    public class CharValue : IADSValue
    {
        [DataMember(Name = "value", Order = 2)]
        public char Value { get; private set; }

        public ADSValueType ADSValueType => ADSValueType.CharValue;
        public string DataType => "CHAR";

        public bool IsScalar => true;
        public bool IsStruc => false;
        public bool IsArray => false;

        public CharValue(string value)
        {
            Value = char.Parse(value);
        }

        public string ToStringValue()
        {
            return "'" + Value.ToString() + "'";
        }
    }
}
