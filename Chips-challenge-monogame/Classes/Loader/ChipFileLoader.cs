using CHIPS_CHALLENGE.Classes.Loader.ChipFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Loader
{
    public static class ChipFileLoader
    {
       public static Base LoadLevelFromFile(string filepath, int level)
       {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fs = File.Open(filepath, FileMode.Open);

            Base chipBase = FromFileStream<Base>(fs);

            return chipBase;
       }

        private static T FromFileStream<T>(FileStream fs, int offset = 0)
        {
            int sizeOfT = Marshal.SizeOf(typeof(T));
            byte[] data = new byte[sizeOfT];
            fs.Read(data, offset, sizeOfT);

            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                ms.Seek(0, 0);
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                return (T)bf.Deserialize(ms);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }
    }
}
