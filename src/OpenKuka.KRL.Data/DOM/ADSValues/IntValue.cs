using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenKuka.KRL.Data.DOM
{

    [DataContract]
    public class IntValue : IADSValue
    {
        [DataMember(Name = "value", Order = 2)]
        public int Value { get; private set; }

        public ADSValueType ADSValueType => ADSValueType.IntValue;
        public string DataType => "INT";

        public bool IsScalar => true;
        public bool IsStruc => false;
        public bool IsArray => false;

        public IntValue(string value)
        {
            Value = int.Parse(value);
        }

        public string ToStringValue()
        {
            return Value.ToString(NumberFormatInfo.InvariantInfo);
        }
    }

}
