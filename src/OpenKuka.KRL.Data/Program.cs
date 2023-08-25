using Newtonsoft.Json;
using OpenKuka.KRL.Data.DOM;
using OpenKuka.KRL.Data.Parser;
using OpenKuka.KRL.Data.Serializer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace OpenKuka.KRL.Data
{

    class Program
    {
        static void Main(string[] args)
        {
            var s1 = @"ID {X 123.09, Y -009812.128e2, Z 0.0, STR ""erioun[];slk''/%,"", ZOB[] 'ehehe', ZIZ TRUE, zoz FaLse, ENU #zlek, BitSt 'B0101010', sdds NaN, mycher 'C' }";
            var s2 = @"{X 123.09, Y -009812.128e2}";
            var s3 = @"ZOB {BOB: X 123.09, Y -009812.128e2, B TRUE, Z{E6POS: A 1, B 2, C 3}}";
            var s4 = @"X 123.09, -009812.128e2, Z{E6POS: A 1, B 2, C 3}";
            var s = s3;

            var ast = DataParser.Parse(s);

            foreach (var item in ast)
            {
                Debug.Write(item.ToString());
            }

            //JsonSerializer serializer = new JsonSerializer();
            //serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());


            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new OrderedContractResolver(),
                //TypeNameHandling = TypeNameHandling.Auto
            };

            settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            //var root = new
            //{
            //    data = ast
            //};

            string output = JsonConvert.SerializeObject(ast[0], Formatting.Indented, settings);
            Debug.WriteLine(output);

            //var obj = JsonConvert.DeserializeObject<DataObject>(output);

            //List<DataObject> list = JsonConvert.DeserializeObject<List<Holder>>(json);
            //string json = JsonConvert.SerializeObject(ast, Formatting.Indented, settings);

            //var list = JsonConvert.DeserializeObject<List<ValueObject>>(json);
            //Debug.WriteLine(list[0].ToString());


            Console.ReadKey();
        }
    }
}
