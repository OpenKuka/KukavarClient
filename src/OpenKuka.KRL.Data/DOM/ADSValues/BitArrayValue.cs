using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenKuka.KRL.Data.DOM
{
    [DataContract]
    public class BitArrayValue : IADSValue
    {
        [DataMember(Name = "value", Order = 2)]
        public BitArray Value { get; private set; }

        public ADSValueType ADSValueType => ADSValueType.BitArrayValue;
        public string DataType => "BOOL";

        public bool IsScalar => false;
        public bool IsStruc => false;
        public bool IsArray => true;

        public BitArrayValue(string value)
        {
            Value = new BitArray(value.Length - 3);
            for (int i = 0; i < Value.Count; i++)
            {
                Value[i] = (value[i + 2] == '1');
            }
        }

        public string ToStringValue()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("'B");
            for (int i = 0; i < Value.Count; i++)
            {
                stringBuilder.Append(Value[i] ? '1' : '0');
            }
            stringBuilder.Append("'");
            return stringBuilder.ToString();
        }
    }

}
