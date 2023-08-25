using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenKuka.KRL.Data.DOM
{
    [DataContract]
    public class StringValue : IADSValue
    {
        [DataMember(Name = "value", Order = 2)]
        public string Value { get; private set; }

        public ADSValueType ADSValueType => ADSValueType.StringValue;
        public string DataType => "BOOL";

        public bool IsScalar => false;
        public bool IsStruc => false;
        public bool IsArray => true;

        public StringValue(string value)
        {
            Value = value.Substring(1, value.Length - 2);
        }

        public string ToStringValue()
        {
            return '"' + Value + '"';
        }
    }
}
