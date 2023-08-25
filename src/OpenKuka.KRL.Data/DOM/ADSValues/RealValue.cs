using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenKuka.KRL.Data.DOM
{
    [DataContract]
    public class RealValue : IADSValue
    {
        [DataMember(Name = "value", Order = 2)]
        public double Value { get; private set; }

        public ADSValueType ADSValueType => ADSValueType.RealValue;
        public string DataType => "REAL";

        public bool IsScalar => true;
        public bool IsStruc => false;
        public bool IsArray => false;

        public RealValue(string value)
        {
            Value = double.Parse(value, CultureInfo.InvariantCulture);
        }

        public string ToStringValue()
        {
            return Value.ToString("G", NumberFormatInfo.InvariantInfo);
        }
    }
}
