using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenKuka.KRL.Data.DOM
{
    [DataContract]
    public class EnumValue : IADSValue
    {
        [DataMember(Name = "value", Order = 2)]
        public string Value { get; private set; }

        public ADSValueType ADSValueType => ADSValueType.EnumValue;
        public string DataType => "ENUM";

        public bool IsScalar => true;
        public bool IsStruc => false;
        public bool IsArray => false;

        public EnumValue(string value)
        {
            Value = value.Substring(1);
        }

        public string ToStringValue()
        {
            return "#" + Value.ToString();
        }
    }
}
