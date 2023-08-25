using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenKuka.KRL.Data.DOM
{
    [DataContract]
    public class BoolValue : IADSValue
    {
        [DataMember(Name = "value", Order = 2)]
        public bool Value { get; private set; }

        public ADSValueType ADSValueType => ADSValueType.BoolValue;
        public string DataType => "BOOL";

        public bool IsScalar => true;
        public bool IsStruc => false;
        public bool IsArray => false;

        public BoolValue(string value)
        {
            Value = bool.Parse(value);
        }

        public string ToStringValue()
        {
            return Value ? "TRUE" : "FALSE";
        }
    }
}
