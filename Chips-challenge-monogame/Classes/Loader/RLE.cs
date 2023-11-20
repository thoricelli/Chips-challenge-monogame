using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHIPS_CHALLENGE.Classes.Loader
{
    public static class RLE
    {
        public static byte[] RLEDecompress(this byte[] objects)
        {
            byte[] result = new byte[1024]; //32*32 is the full map size, hm, hardcoded not a good idea?
            int index = 0;
            /*
             #FF means RLE.
             #FF, #copies, #byte-code
             */
            for (int i = 0; i < objects.Length; i++)
            {
                byte obj = objects[i];

                //We check if we meet an #FF
                if (obj == 0xFF)
                {
                    byte copies = objects[i + 1];
                    byte object_code = objects[i + 2];

                    for (int j = index; j < index + copies; j++) //TOO LAZY TO USE ANYTHING ELSE :)
                    {
                        result[j] = object_code;
                    }

                    index += copies;
                    i += 2; //Skip 2 bytes.
                }
                else
                {
                    result[index] = obj;
                    index++;
                }
            }
            return result;
        }
    }
}
