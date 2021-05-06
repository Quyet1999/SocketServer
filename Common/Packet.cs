using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Packet
    {
        public static byte[] Serialize(object msgStr, int _maxBuffer)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, msgStr);
            byte[] buff = new byte[_maxBuffer];
            return stream.ToArray();
        }

        public static object Deserialize(byte[] buff)
        {
            MemoryStream stream = new MemoryStream(buff);
            BinaryFormatter bf = new BinaryFormatter();
            return (MsgStruct)bf.Deserialize(stream);
        }
    }
}
