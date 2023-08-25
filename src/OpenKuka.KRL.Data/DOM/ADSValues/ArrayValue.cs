using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenKuka.KRL.Data.DOM
{
    [DataContract]
    public class ArrayValue : IADSValue
    {
        [DataMember(Name = "value", Order = 3)]
        public IADSValue[] Items { get; private set; }

        public ADSValueType ADSValueType => ADSValueType.BitArrayValue;

        [DataMember(Name = "strucType", Order = 2)]
        public string DataType { get; set; }

        public bool IsScalar => false;
        public bool IsStruc => false;
        public bool IsArray => true;
        public int Count => Items.Length;

        public ArrayValue(string dataType, IADSValue[] items)
        {
            DataType = dataType;
            Items = items;
        }

        public string ToStringValue()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                if (i > 0) stringBuilder.Append(", ");
                stringBuilder.Append(Items[i].ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
