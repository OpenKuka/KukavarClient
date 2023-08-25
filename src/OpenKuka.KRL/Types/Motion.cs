
using OpenKuka.KRL.DataParser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OpenKuka.KRL.Types
{
    public interface IAxis
    {
        double? A1 { get; set; }
        double? A2 { get; set; }
        double? A3 { get; set; }
        double? A4 { get; set; }
        double? A5 { get; set; }
        double? A6 { get; set; }
    }
    public interface IEAxis
    {
        double? E1 { get; set; }
        double? E2 { get; set; }
        double? E3 { get; set; }
        double? E4 { get; set; }
        double? E5 { get; set; }
        double? E6 { get; set; }
    }
    public interface IFrame
    {
        double? X { get; set; }
        double? Y { get; set; }
        double? Z { get; set; }
        double? A { get; set; }
        double? B { get; set; }
        double? C { get; set; }
    }
    public interface IStatusTurn
    {
        int? S { get; set; }
        int? T { get; set; }
        STATUS? GetStatus();
        TURN? GetTurn();
    }

    public struct STATUS
    {
        private BitArray _bits;

        /// <summary>
        /// Bit 0: Position of the wrist root point(basic/overhead area)
        /// </summary>
        public bool B0 => _bits[0];

        /// <summary>
        /// Bit 1: Arm configuration
        /// </summary>
        public bool B1 => _bits[1];

        /// <summary>
        /// Bit 2: Wrist configuration
        /// </summary>
        public bool B2 => _bits[2];

        public STATUS(int status) : this()
        {
            _bits = new BitArray(new int[] { status });
        }

        public override string ToString()
        {
            return ToString();
        }
        public string ToString(bool bitsRep = true)
        {
            if (bitsRep)
            {
                var cmd = "";
                cmd += B2 ? "1" : "0";
                cmd += B1 ? "1" : "0";
                cmd += B0 ? "1" : "0";
                return cmd;
            }
            else
            {
                return "" + ToInt();
            }
        }
        public int ToInt()
        {
            int val = 0;
            val += B2 ? 4 : 0;
            val += B1 ? 2 : 0;
            val += B0 ? 1 : 0;
            return val;
        }
    }
    public struct TURN
    {
        private BitArray _bits;

        /// <summary>
        /// Bit 0: angle of A1 < 0 (true)  
        /// </summary>
        public bool B0 => _bits[0];

        /// <summary>
        /// Bit 1: angle of A2 < 0 (true)  
        /// </summary>
        public bool B1 => _bits[1];

        /// <summary>
        /// Bit 2: angle of A3 < 0 (true)  
        /// </summary>
        public bool B2 => _bits[2];

        /// <summary>
        /// Bit 3: angle of A4 < 0 (true)  
        /// </summary>
        public bool B3 => _bits[3];

        /// <summary>
        /// Bit 4: angle of A5 < 0 (true)  
        /// </summary>
        public bool B4 => _bits[4];

        /// <summary>
        /// Bit 5: angle of A6 < 0 (true)  
        /// </summary>
        public bool B5 => _bits[5];

        public TURN(int turn) : this()
        {
            _bits = new BitArray(new int[] { turn });
        }

        public override string ToString()
        {
            return ToString();
        }
        public string ToString(bool bitsRep = true)
        {
            if (bitsRep)
            {
                var cmd = "";
                cmd += B5 ? "1" : "0";
                cmd += B4 ? "1" : "0";
                cmd += B3 ? "1" : "0";
                cmd += B2 ? "1" : "0";
                cmd += B1 ? "1" : "0";
                cmd += B0 ? "1" : "0";
                return cmd;
            }
            else
            {
                return "" + ToInt();
            }
        }
        public int ToInt()
        {
            int val = 0;
            val += B5 ? 32 : 0;
            val += B4 ? 16 : 0;
            val += B3 ? 8 : 0;
            val += B2 ? 4 : 0;
            val += B1 ? 2 : 0;
            val += B0 ? 1 : 0;
            return val;
        }
    }

    public struct AXIS : IAxis
    {
        public double? A1 { get; set; }
        public double? A2 { get; set; }
        public double? A3 { get; set; }
        public double? A4 { get; set; }
        public double? A5 { get; set; }
        public double? A6 { get; set; }

        public AXIS(Data data) : this()
        {
            var tree = data as StrucData;

            if (tree == null)
                throw new ArgumentException("The data provided is not a STRUC", "data");

            if (tree.StrucType != "AXIS")
                throw new ArgumentException("The data provided is not of type AXIS");

            if (tree.Value.ContainsKey("A1")) A1 = ((RealData)tree.Value["A1"]).Value;
            if (tree.Value.ContainsKey("A2")) A2 = ((RealData)tree.Value["A2"]).Value;
            if (tree.Value.ContainsKey("A3")) A3 = ((RealData)tree.Value["A3"]).Value;
            if (tree.Value.ContainsKey("A4")) A4 = ((RealData)tree.Value["A4"]).Value;
            if (tree.Value.ContainsKey("A5")) A5 = ((RealData)tree.Value["A5"]).Value;
            if (tree.Value.ContainsKey("A6")) A6 = ((RealData)tree.Value["A6"]).Value;
        }

        public override string ToString()
        {
            return ToString();
        }
        public string ToString(bool showType = true, string format = "G6")
        {
            var items = new List<string>();

            if (A1.HasValue) items.Add(string.Format("A1 {0:" + format + "}", A1));
            if (A2.HasValue) items.Add(string.Format("A2 {0:" + format + "}", A2));
            if (A3.HasValue) items.Add(string.Format("A3 {0:" + format + "}", A3));
            if (A4.HasValue) items.Add(string.Format("A4 {0:" + format + "}", A4));
            if (A5.HasValue) items.Add(string.Format("A5 {0:" + format + "}", A5));
            if (A6.HasValue) items.Add(string.Format("A6 {0:" + format + "}", A6));

            var cmd = showType ? "{AXIS: " : "{";
            cmd += string.Join(", ", items) + "}";
            return cmd;
        }
    }
    public struct E6AXIS : IAxis, IEAxis
    {
        public double? A1 { get; set; }
        public double? A2 { get; set; }
        public double? A3 { get; set; }
        public double? A4 { get; set; }
        public double? A5 { get; set; }
        public double? A6 { get; set; }

        public double? E1 { get; set; }
        public double? E2 { get; set; }
        public double? E3 { get; set; }
        public double? E4 { get; set; }
        public double? E5 { get; set; }
        public double? E6 { get; set; }

        public E6AXIS(IEnumerable<double> axis)
        {
            A1 = axis.ElementAt(0);
            A2 = axis.ElementAt(1);
            A3 = axis.ElementAt(2);
            A4 = axis.ElementAt(3);
            A5 = axis.ElementAt(4);
            A6 = axis.ElementAt(5);

            E1 = null;
            E2 = null;
            E3 = null;
            E4 = null;
            E5 = null;
            E6 = null;
        }
        public E6AXIS(IEnumerable<double> axis, IEnumerable<double> eAxis):this(axis)
        {
            E1 = eAxis.ElementAt(0);
            E2 = eAxis.ElementAt(1);
            E3 = eAxis.ElementAt(2);
            E4 = eAxis.ElementAt(3);
            E5 = eAxis.ElementAt(4);
            E6 = eAxis.ElementAt(5);
        }

        public E6AXIS(Data data) : this()
        {
            var tree = data as StrucData;

            if (tree == null)
                throw new ArgumentException("The data provided is not a STRUC", "data");

            if (tree.StrucType != "E6AXIS")
                throw new ArgumentException("The data provided is not of type E6AXIS");

            if (tree.Value.ContainsKey("A1")) A1 = ((RealData)tree.Value["A1"]).Value;
            if (tree.Value.ContainsKey("A2")) A2 = ((RealData)tree.Value["A2"]).Value;
            if (tree.Value.ContainsKey("A3")) A3 = ((RealData)tree.Value["A3"]).Value;
            if (tree.Value.ContainsKey("A4")) A4 = ((RealData)tree.Value["A4"]).Value;
            if (tree.Value.ContainsKey("A5")) A5 = ((RealData)tree.Value["A5"]).Value;
            if (tree.Value.ContainsKey("A6")) A6 = ((RealData)tree.Value["A6"]).Value;

            if (tree.Value.ContainsKey("E1")) E1 = ((RealData)tree.Value["E1"]).Value;
            if (tree.Value.ContainsKey("E2")) E2 = ((RealData)tree.Value["E2"]).Value;
            if (tree.Value.ContainsKey("E3")) E3 = ((RealData)tree.Value["E3"]).Value;
            if (tree.Value.ContainsKey("E4")) E4 = ((RealData)tree.Value["E4"]).Value;
            if (tree.Value.ContainsKey("E5")) E5 = ((RealData)tree.Value["E5"]).Value;
            if (tree.Value.ContainsKey("E6")) E6 = ((RealData)tree.Value["E6"]).Value;
        }

        public override string ToString()
        {
            return ToString();
        }
        public string ToString(bool showType = true, string format = "G6")
        {
            var items = new List<string>();

            if (A1.HasValue) items.Add(string.Format("A1 {0:" + format + "}", A1));
            if (A2.HasValue) items.Add(string.Format("A2 {0:" + format + "}", A2));
            if (A3.HasValue) items.Add(string.Format("A3 {0:" + format + "}", A3));
            if (A4.HasValue) items.Add(string.Format("A4 {0:" + format + "}", A4));
            if (A5.HasValue) items.Add(string.Format("A5 {0:" + format + "}", A5));
            if (A6.HasValue) items.Add(string.Format("A6 {0:" + format + "}", A6));

            if (E1.HasValue) items.Add(string.Format("E1 {0:" + format + "}", E1));
            if (E2.HasValue) items.Add(string.Format("E2 {0:" + format + "}", E2));
            if (E3.HasValue) items.Add(string.Format("E3 {0:" + format + "}", E3));
            if (E4.HasValue) items.Add(string.Format("E4 {0:" + format + "}", E4));
            if (E5.HasValue) items.Add(string.Format("E5 {0:" + format + "}", E5));
            if (E6.HasValue) items.Add(string.Format("E6 {0:" + format + "}", E6));

            var cmd = showType ? "{E6AXIS: " : "{";
            cmd += string.Join(", ", items) + "}";
            return cmd;
        }
    }
    public struct FRAME : IFrame
    {
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
        public double? A { get; set; }
        public double? B { get; set; }
        public double? C { get; set; }

        public FRAME(IEnumerable<double> xyzabc)
        {
            X = xyzabc.ElementAt(0);
            Y = xyzabc.ElementAt(1);
            Z = xyzabc.ElementAt(2);
            A = xyzabc.ElementAt(3);
            B = xyzabc.ElementAt(4);
            C = xyzabc.ElementAt(5);
        }
        public FRAME(Data data) : this()
        {
            var tree = data as StrucData;

            if (tree == null)
                throw new ArgumentException("The data provided is not a STRUC", "data");

            if (tree.StrucType != "FRAME")
                throw new ArgumentException("The data provided is not of type FRAME");

            if (tree.Value.ContainsKey("X")) X = ((RealData)tree.Value["X"]).Value;
            if (tree.Value.ContainsKey("Y")) Y = ((RealData)tree.Value["Y"]).Value;
            if (tree.Value.ContainsKey("Z")) Z = ((RealData)tree.Value["Z"]).Value;
            if (tree.Value.ContainsKey("A")) A = ((RealData)tree.Value["A"]).Value;
            if (tree.Value.ContainsKey("B")) B = ((RealData)tree.Value["B"]).Value;
            if (tree.Value.ContainsKey("C")) C = ((RealData)tree.Value["C"]).Value;
        }

        public override string ToString()
        {
            return ToString();
        }
        public string ToString(bool showType = true, string format = "G6")
        {
            var items = new List<string>();

            if (X.HasValue) items.Add(string.Format("X {0:" + format + "}", X));
            if (Y.HasValue) items.Add(string.Format("Y {0:" + format + "}", Y));
            if (Z.HasValue) items.Add(string.Format("Z {0:" + format + "}", Z));
            if (A.HasValue) items.Add(string.Format("A {0:" + format + "}", A));
            if (B.HasValue) items.Add(string.Format("B {0:" + format + "}", B));
            if (C.HasValue) items.Add(string.Format("C {0:" + format + "}", C));

            var cmd = showType ? "{FRAME: " : "{";
            cmd += string.Join(", ", items) + "}";
            return cmd;
        }
    }
    public struct POS : IFrame, IStatusTurn
    {
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
        public double? A { get; set; }
        public double? B { get; set; }
        public double? C { get; set; }
        public int? S { get; set; }
        public int? T { get; set; }

        public STATUS? GetStatus()
        {
            if (S.HasValue) return new STATUS(S.Value);
           return null;
        }
        public TURN? GetTurn()
        {
            if (T.HasValue) return new TURN(T.Value);
            return null;
        }

        public POS(Data data) : this()
        {
            var tree = data as StrucData;

            if (tree == null)
                throw new ArgumentException("The data provided is not a STRUC", "data");

            if (tree.StrucType != "POS")
                throw new ArgumentException("The data provided is not of type POS");

            if (tree.Value.ContainsKey("X")) X = ((RealData)tree.Value["X"]).Value;
            if (tree.Value.ContainsKey("Y")) Y = ((RealData)tree.Value["Y"]).Value;
            if (tree.Value.ContainsKey("Z")) Z = ((RealData)tree.Value["Z"]).Value;
            if (tree.Value.ContainsKey("A")) A = ((RealData)tree.Value["A"]).Value;
            if (tree.Value.ContainsKey("B")) B = ((RealData)tree.Value["B"]).Value;
            if (tree.Value.ContainsKey("C")) C = ((RealData)tree.Value["C"]).Value;

            if (tree.Value.ContainsKey("S")) S = ((IntData)tree.Value["S"]).Value;
            if (tree.Value.ContainsKey("T")) T = ((IntData)tree.Value["T"]).Value;
        }

        public override string ToString()
        {
            return ToString();
        }
        public string ToString(bool showType = true, string format = "G6")
        {
            var items = new List<string>();

            if (X.HasValue) items.Add(string.Format("X {0:" + format + "}", X));
            if (Y.HasValue) items.Add(string.Format("Y {0:" + format + "}", Y));
            if (Z.HasValue) items.Add(string.Format("Z {0:" + format + "}", Z));
            if (A.HasValue) items.Add(string.Format("A {0:" + format + "}", A));
            if (B.HasValue) items.Add(string.Format("B {0:" + format + "}", B));
            if (C.HasValue) items.Add(string.Format("C {0:" + format + "}", C));

            if (S.HasValue) items.Add(string.Format("S {0}", S));
            if (T.HasValue) items.Add(string.Format("T {0}", T));

            var cmd = showType ? "{FRAME: " : "{";
            cmd += string.Join(", ", items) + "}";
            return cmd;
        }
    }
    public struct E6POS : IFrame, IStatusTurn, IEAxis
    {
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
        public double? A { get; set; }
        public double? B { get; set; }
        public double? C { get; set; }

        public int? S { get; set; }
        public int? T { get; set; }

        public double? E1 { get; set; }
        public double? E2 { get; set; }
        public double? E3 { get; set; }
        public double? E4 { get; set; }
        public double? E5 { get; set; }
        public double? E6 { get; set; }

        public STATUS? GetStatus()
        {
            if (S.HasValue) return new STATUS(S.Value);
            return null;
        }
        public TURN? GetTurn()
        {
            if (T.HasValue) return new TURN(T.Value);
            return null;
        }

        public E6POS(IEnumerable<double> xyzabc)
        {
            X = xyzabc.ElementAt(0);
            Y = xyzabc.ElementAt(1);
            Z = xyzabc.ElementAt(2);
            A = xyzabc.ElementAt(3);
            B = xyzabc.ElementAt(4);
            C = xyzabc.ElementAt(5);

            S = null;
            T = null;

            E1 = null;
            E2 = null;
            E3 = null;
            E4 = null;
            E5 = null;
            E6 = null;
        }
        public E6POS(IEnumerable<double> xyzabc, IEnumerable<double> eAxis):this(xyzabc)
        {
            E1 = eAxis.ElementAt(0);
            E2 = eAxis.ElementAt(1);
            E3 = eAxis.ElementAt(2);
            E4 = eAxis.ElementAt(3);
            E5 = eAxis.ElementAt(4);
            E6 = eAxis.ElementAt(5);
        }
        public E6POS(IEnumerable<double> xyzabc, IEnumerable<double> eAxis, int status, int turn) : this(xyzabc, eAxis)
        {
            S = status;
            T = turn;
        }

            public E6POS(Data data) : this()
        {
            var tree = data as StrucData;

            if (tree == null)
                throw new ArgumentException("The data provided is not a STRUC", "data");

            if (tree.StrucType != "E6POS")
                throw new ArgumentException("The data provided is not of type E6POS");

            if (tree.Value.ContainsKey("X")) X = ((RealData)tree.Value["X"]).Value;
            if (tree.Value.ContainsKey("Y")) Y = ((RealData)tree.Value["Y"]).Value;
            if (tree.Value.ContainsKey("Z")) Z = ((RealData)tree.Value["Z"]).Value;
            if (tree.Value.ContainsKey("A")) A = ((RealData)tree.Value["A"]).Value;
            if (tree.Value.ContainsKey("B")) B = ((RealData)tree.Value["B"]).Value;
            if (tree.Value.ContainsKey("C")) C = ((RealData)tree.Value["C"]).Value;

            if (tree.Value.ContainsKey("S")) S = ((IntData)tree.Value["S"]).Value;
            if (tree.Value.ContainsKey("T")) T = ((IntData)tree.Value["T"]).Value;

            if (tree.Value.ContainsKey("E1")) E1 = ((RealData)tree.Value["E1"]).Value;
            if (tree.Value.ContainsKey("E2")) E2 = ((RealData)tree.Value["E2"]).Value;
            if (tree.Value.ContainsKey("E3")) E3 = ((RealData)tree.Value["E3"]).Value;
            if (tree.Value.ContainsKey("E4")) E4 = ((RealData)tree.Value["E4"]).Value;
            if (tree.Value.ContainsKey("E5")) E5 = ((RealData)tree.Value["E5"]).Value;
            if (tree.Value.ContainsKey("E6")) E6 = ((RealData)tree.Value["E6"]).Value;
        }

        public override string ToString()
        {
            return ToString();
        }
        public string ToString(bool showType = true, string format = "G6")
        {
            var items = new List<string>();

            if (X.HasValue) items.Add(string.Format("X {0:" + format + "}", X));
            if (Y.HasValue) items.Add(string.Format("Y {0:" + format + "}", Y));
            if (Z.HasValue) items.Add(string.Format("Z {0:" + format + "}", Z));
            if (A.HasValue) items.Add(string.Format("A {0:" + format + "}", A));
            if (B.HasValue) items.Add(string.Format("B {0:" + format + "}", B));
            if (C.HasValue) items.Add(string.Format("C {0:" + format + "}", C));

            if (E1.HasValue) items.Add(string.Format("E1 {0:" + format + "}", E1));
            if (E2.HasValue) items.Add(string.Format("E2 {0:" + format + "}", E2));
            if (E3.HasValue) items.Add(string.Format("E3 {0:" + format + "}", E3));
            if (E4.HasValue) items.Add(string.Format("E4 {0:" + format + "}", E4));
            if (E5.HasValue) items.Add(string.Format("E5 {0:" + format + "}", E5));
            if (E6.HasValue) items.Add(string.Format("E6 {0:" + format + "}", E6));

            if (S.HasValue) items.Add(string.Format("S {0}", S));
            if (T.HasValue) items.Add(string.Format("T {0}", T));



            var cmd = showType ? "{E6POS: " : "{";
            cmd += string.Join(", ", items) + "}";
            return cmd;
        }
    }

    public struct CP
    {
        public double? LIN { get; set; }
        public double? ORI1 { get; set; }
        public double? ORI2 { get; set; }

        public CP(Data data) : this()
        {
            var tree = data as StrucData;

            if (tree == null)
                throw new ArgumentException("The data provided is not a STRUC", "data");

            if (tree.StrucType != "CP")
                throw new ArgumentException("The data provided is not of type CP");

            if (tree.Value.ContainsKey("CP")) LIN = ((RealData)tree.Value["CP"]).Value;
            if (tree.Value.ContainsKey("ORI1")) ORI1 = ((RealData)tree.Value["ORI1"]).Value;
            if (tree.Value.ContainsKey("ORI2")) ORI2 = ((RealData)tree.Value["ORI2"]).Value;
        }

        public override string ToString()
        {
            return ToString();
        }
        public string ToString(bool showType = true, string format = "G6")
        {
            var items = new List<string>();

            if (LIN.HasValue) items.Add(string.Format("CP {0:" + format + "}", LIN));
            if (ORI1.HasValue) items.Add(string.Format("ORI1 {0:" + format + "}", ORI1));
            if (ORI2.HasValue) items.Add(string.Format("ORI2 {0:" + format + "}", ORI2));

            var cmd = showType ? "{FRAME: " : "{";
            cmd += string.Join(", ", items) + "}";
            return cmd;
        }
    }

    public enum CIRC_TYPE
    {
        /// <summary>
        /// Space-related orientation control
        /// </summary>
        BASE,

        /// <summary>
        /// Path-related orientation control
        /// </summary>
        PATH
    }

    public enum DIRECTION
    {
        /// <summary>
        /// Forwards execution
        /// </summary>
        FORWARD,

        /// <summary>
        /// Backwards execution
        /// </summary>
        BACKWARD
    }

    public enum IPO_MODE
    {
        BASE,
        TCP
    }


    public enum ORI_TYPE
    {
        /// <summary>
        /// Variable orientation with possible reduction of velocity and acceleration.
        /// </summary>
        VAR,

        /// <summary>
        /// Constant orientation.
        /// </summary>
        CONSTANT,

        /// <summary>
        /// Variable orientation without reduction of velocity and acceleration.
        /// </summary>
        JOINT
    }

    public enum TARGET_STATUS
    {
        /// <summary>
        /// Use Status of start point.
        /// </summary>
        SOURCE,

        /// <summary>
        /// All eight Status combinations are calculated; the one with the shortest path between the start point and end point in axis space is selected.
        /// </summary>
        BEST
    }

    public enum TRANSSYS
    {
        WORLD,
        BASE,
        ROBROOT,
        TCP
    }


    public static class KRL
    {
        public static string PTP(AXIS axis, string suffix = "", bool showType = true, string format = "G6")
        {
            var cmd = "PTP " + axis.ToString(showType, format) + suffix;
            return cmd;
        }
        public static string PTP(E6AXIS e6axis, string suffix = "", bool showType = true, string format = "G6")
        {
            var cmd = "PTP " + e6axis.ToString(showType, format) + suffix;
            return cmd;
        }
        public static string PTP(FRAME frame, string suffix = "", bool showType = true, string format = "G6")
        {
            var cmd = "PTP " + frame.ToString(showType, format) + suffix;
            return cmd;
        }
        public static string PTP(POS pos, string suffix = "", bool showType = true, string format = "G6")
        {
            var cmd = "PTP " + pos.ToString(showType, format) + suffix;
            return cmd;
        }
        public static string PTP(E6POS e6pos, string suffix = "", bool showType = true, string format = "G6")
        {
            var cmd = "PTP " + e6pos.ToString(showType, format) + suffix;
            return cmd;
        }

        public static string LIN(FRAME frame, string suffix = "", bool showType = true, string format = "G6")
        {
            var cmd = "LIN " + frame.ToString(showType, format) + suffix;
            return cmd;
        }
        public static string LIN(POS pos, string suffix = "", bool showType = true, string format = "G6")
        {
            var cmd = "LIN " + pos.ToString(showType, format) + suffix;
            return cmd;
        }
        public static string LIN(E6POS e6pos, string suffix = "", bool showType = true, string format = "G6")
        {
            var cmd = "LIN " + e6pos.ToString(showType, format) + suffix;
            return cmd;
        }
    }
}