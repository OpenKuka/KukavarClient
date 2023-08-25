using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenKuka.KRL.Data.DOM
{
    [DataContract]
    public class StrucValue : IADSValue
    {
        [DataMember(Name = "value", Order = 3)]
        public Dictionary<string, IADSValue> Items { get; set; }

        public ADSValueType ADSValueType => ADSValueType.StrucValue;

        [DataMember(Name = "strucType", Order = 2)]
        public string DataType { get; set; }
        public int Count => Items.Count;

        public bool IsScalar => false;
        public bool IsStruc => true;
        public bool IsArray => false;

        public StrucValue(string dataType, Dictionary<string, IADSValue> items)
        {
            DataType = dataType;
            Items = items;
        }
        internal StrucValue(string dataType)
        {
            DataType = dataType;
            Items = new Dictionary<string, IADSValue>();
        }

        public IADSValue this[string fieldName]
        {
            get { return Items[fieldName]; }
        }
        internal void Add(string fieldName, IADSValue fieldValue)
        {
            Items.Add(fieldName, fieldValue);
        }

        public string ToStringValue()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('{');
            if (DataType != string.Empty)
            {
                stringBuilder.Append(DataType);
                stringBuilder.Append(": ");
            }
            bool flag = true;
            foreach (var item in Items)
            {
                if (flag)
                {
                    flag = false;
                }
                else
                {
                    stringBuilder.Append(", ");
                }
                stringBuilder.Append(item.Value.ToString());
            }
            stringBuilder.Append('}');
            return stringBuilder.ToString();
        }
    }
}
