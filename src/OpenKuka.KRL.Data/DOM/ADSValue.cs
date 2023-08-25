using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenKuka.KRL.Data.DOM
{

    /// <summary>
    /// Primitive KRL types.
    /// </summary>
    public enum DataType
    {
        BOOL,
        INT,
        REAL,
        CHAR,
        ENUM,
        STRUC,
    }

    /// <summary>
    /// Available concrete types implementing IADSValue.
    /// This is required for the serialization of the DOM tree.
    /// </summary>
    public enum ADSValueType : int
    {
        BoolValue       = 0,
        IntValue        = 1,
        RealValue       = 2,
        CharValue       = 3,
        EnumValue       = 4,
        StringValue     = 5,
        BitArrayValue   = 6,
        StrucValue      = 7,
        ArrayValue      = 7,
    }

    /// <summary>
    /// Abstract Data Syntax value contract.
    /// </summary>
    public interface IADSValue
    {
        /// <summary>
        /// Type of the concrete type implementing the ADSValueType.
        /// </summary>
        [DataMember(Name = "type", Order = 1)]
        ADSValueType ADSValueType { get; }

        /// <summary>
        /// The underlying KRL data type of the value.
        /// For an ArrayValue, it is the type of the elements.
        /// For any other ADSValue, it is the type of the value itself.
        /// </summary>
        string DataType { get; }

        bool IsScalar { get; }
        bool IsStruc { get; }
        bool IsArray { get; }

        string ToStringValue();
    }
}
