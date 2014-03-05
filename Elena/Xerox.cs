using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Elena
{
    public sealed class Xerox
    {
        Xerox() { }

        public static Xerox Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            static Nested() { }

            internal static readonly Xerox instance = new Xerox();
        }

        public object Photocopy(object original)
        {
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            b.Serialize(ms, original);
            ms.Seek(0, SeekOrigin.Begin);
            object retobj = b.Deserialize(ms);
            ms.Close();
            return retobj;
        }
    }
}
