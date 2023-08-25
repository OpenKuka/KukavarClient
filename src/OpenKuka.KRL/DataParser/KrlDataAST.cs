using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace OpenKuka.KRL.DataParser
{
    public enum DataType
    {
        BOOL,
        INT,
        REAL,
        CHAR,
        STRING,
        ENUM,
        STRUC
    }

    public abstract class Data
    {
        private static Regex _array = new Regex(@"\[([\d]+)\]", RegexOptions.IgnoreCase);

        public abstract DataType Type { get; }
        public string Name { get; set; }

        public bool IsScalar { get => Type != DataType.STRUC; }
        public bool IsComposite { get => Type == DataType.STRUC; }
        public bool IsArrayElement(out short index)
        {
            index = 0;
            Match match = _array.Match(Name);
            if (match.Success)
            {
                index = short.Parse(match.Groups[1].Value);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Data(string name)
        {
            Name = name;
        }
        public abstract void Print(string indent);
        public abstract string ToKrlString();
        public virtual string KrlType => Type.ToString();
    }


    public class BoolData : Data
    {
        public override DataType Type => DataType.BOOL;
        public bool Value { get; private set; }
        public override string ToKrlString() => Value ? "TRUE" : "FALSE";
        public BoolData(string name, string value) : base(name)
        {
            Value = bool.Parse(value);
        }
        public override void Print(string indent) => Console.WriteLine(indent + "+- " + Name + "<" + Type + ">" + " = " + Value);
        
    }
    public class EnumData : Data
    {
        public override DataType Type => DataType.ENUM;
        public string Value { get; private set; }
        public override string ToKrlString() => Value.ToString();
        public EnumData(string name, string value) : base(name)
        {
            Value = value;
        }
        public override void Print(string indent) => Console.WriteLine(indent + "+- " + Name + "<" + Type + ">" + " = " + Value);
    }
    public class IntData : Data
    {
        public override DataType Type => DataType.INT;
        public short Value { get; private set; }
        public override string ToKrlString() => Value.ToString();
        public IntData(string name, string value) : base(name)
        {
            Value = short.Parse(value, CultureInfo.InvariantCulture);
        }
        public override void Print(string indent) => Console.WriteLine(indent + "+- " + Name + "<" + Type + ">" + " = " + Value);
    }
    public class RealData : Data
    {
        public override DataType Type => DataType.REAL;
        public double Value { get; private set; }
        public override string ToKrlString() => Value.ToString();
        public RealData(string name, string value) : base(name)
        {
            Value = double.Parse(value, CultureInfo.InvariantCulture);
        }
        public override void Print(string indent) => Console.WriteLine(indent + "+- " + Name + "<" + Type + ">" + " = " + Value);
    }
    public class CharData : Data
    {
        public override DataType Type => DataType.CHAR;
        public char Value { get; private set; }
        public override string ToKrlString() => Value.ToString();
        public CharData(string name, string value) : base(name)
        {
           Value = char.Parse(value.Substring(1, value.Length - 2));
        }
        public override void Print(string indent) => Console.WriteLine(indent + "+- " + Name + "<" + Type + ">" + " = '" + Value + "'");
    }
    public class StringData : Data
    {
        public override DataType Type => DataType.STRING;
        public string Value { get; private set; }
        public override string ToKrlString() => Value;
        public StringData(string name, string value) : base(name)
        {
            Value = value.Substring(1, value.Length - 2);
        }
        public override void Print(string indent) => Console.WriteLine(indent + "+- " + Name + "<" + Type + ">" + " = \"" + Value + "\"");
    }
    public class StrucData : Data
    {
        public override DataType Type => DataType.STRUC;
        public string StrucType { get; private set; }
        public override string ToKrlString()
        {
            var krl = "{" + Type + ": ";
            foreach (var node in Value)
            {
                node.Value.ToKrlString();
            }
            krl += "}";
            return krl;
        }
        public override string KrlType => StrucType;
        public Dictionary<string, Data> Value { get; private set; }
        public StrucData(string name, string strucType, IEnumerable<Data> dataList) : base(name)
        {
            Value = new Dictionary<string, Data>(StringComparer.InvariantCultureIgnoreCase); // case insensitive dic as KRL is case insensitive
            foreach (var data in dataList) Value.Add(data.Name, data);
            StrucType = strucType.Substring(0, strucType.Length - 1);
        }
        public override void Print(string indent)
        {
            Console.WriteLine(indent + "+- " + Name + "<STRUC: " + StrucType + ">");
            indent += "|  ";
            foreach (var node in Value) node.Value.Print(indent);
        }

    }
}
