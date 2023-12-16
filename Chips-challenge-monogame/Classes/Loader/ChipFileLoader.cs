using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Loader.ChipFile;
using CHIPS_CHALLENGE.Classes.Loader.ChipFile.Fields;
using CHIPS_CHALLENGE.Classes.Loader.ChipFile.Fields.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Myra.Attributes;
using SharpDX.MediaFoundation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CHIPS_CHALLENGE.Classes.Loader
{
    public class ChipFileLoader
    {
        private string filepath;

        public ChipFileLoader(string filepath)
        {
            this.filepath = filepath;
        }

        //REFER TO https://www.seasip.info/ccfile.html
        public ChipFileInformation LoadLevelFromFile(int level)
        {
            ChipFileInformation chipInfo = new ChipFileInformation();

            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fs = File.Open(filepath, FileMode.Open);

            //Base of the file.
            Base chipBase = FromFileStream<Base>(fs);

            //We can get the bytes for the level from here, and seek the filestream.
            Level loadedLevel;

            do
            {
                loadedLevel = FromFileStream<Level>(fs);
                if (loadedLevel.LevelNumber != level)
                    fs.Seek(loadedLevel.Bytes - 0x6, SeekOrigin.Current);
            } while (loadedLevel.LevelNumber != level);

            chipInfo.LevelNumber = loadedLevel.LevelNumber;
            chipInfo.Time = loadedLevel.Time;
            chipInfo.ChipsToPickUp = loadedLevel.ChipsToPickUp;

            //OK, we found our level!

            fs.Seek(0x2, SeekOrigin.Current); //Field 1, we skip this.
            
            //Implement level loading logic.
            //Hardcoded layers for now.
            byte[] layer1 = DecompressLayer(fs);
            byte[] layer2 = DecompressLayer(fs);

            List<byte[]> layers = new List<byte[]>() { layer1, layer2 };

            foreach (byte[] layer in layers)
            {
                chipInfo.layers.Add(ToLayer(layer));
            }

            //Now we need to parse the fields.
            byte[] sizeByte = new byte[2];
            fs.Read(sizeByte, sizeByte.Length, 0);

            int endAddress = (int)fs.Position + BitConverter.ToUInt16(sizeByte, 0);

            fs.Seek(0x2, SeekOrigin.Current); //Size till end, WE DO NEED THIS...

            /*do
            {
                int fieldNo = 0;
                Field field = ReadField(fs, ref fieldNo);
                chipInfo.fields[fieldNo] = field;
            } while (fs.Position > endAddress);*/

            fs.Close();

            return chipInfo;
        }

        private Layer ToLayer(byte[] layer)
        {
            Layer layerObj = new Layer(32, 32); //TODO: REPLACE!
            for (int i = 0; i < layer.Length; i++)
            {
                //TODO, switch for type. For now chipobj wont be abstract.
                layer[i] = SetupForCode(layer[i], i);
                layerObj.objects[i] = ItemFactory.CreateObjectFromCode((Objects)layer[i]);
            }
            return layerObj;
        }

        //Depending on the code found, the game might want to do a setup first.
        private byte SetupForCode(byte code, int index)
        {
            Objects codeObject = (Objects)code;
            //Do any mutations or setup here, I should probably refactor this and move this to another class.
            switch (codeObject)
            {
                case Objects.HERO_SOUTH:
                    ChipGame.SetSpawnLocation(index);
                    break;
            }
            return code;
        }

        private Field ReadField(FileStream fs, ref int fieldNo)
        {
            /* Read the first number as an INT, field number.
               Probably the best way to solve this is, not have fields but variables
               inside of the fileinfo class.
               Maybe just give the gameinfo as an argument, and let this function fill it up.
               annoying!
            */
            fieldNo = fs.ReadByte();
            switch ((FieldEnum)fieldNo)
            {
                case FieldEnum.LEVEL_TIME:
                    return FromFileStream<Field1>(fs);
                case FieldEnum.CHIP_COUNT:
                    return FromFileStream<Field2>(fs);
                case FieldEnum.MAP_TITLE:
                    return FromFileStream<Field3>(fs);
                case FieldEnum.TRAP_CONTROLS:
                    return FromFileStream<Field4>(fs);
                case FieldEnum.CLONING_CONTROLS:
                    return FromFileStream<Field5>(fs);
                case FieldEnum.MAP_PASSWORD:
                    return FromFileStream<Field6>(fs);
                case FieldEnum.MAP_HINT:
                    return FromFileStream<Field7>(fs);
                case FieldEnum.MAP_PASSWORD_NO_ENCODE:
                    return FromFileStream<Field8>(fs);
                case FieldEnum.MOVEMENT:
                    return FromFileStream<Field10>(fs);
                default:
                    return FromFileStream<Field>(fs);
            }
        }

        private byte[] DecompressLayer(FileStream fs)
        {
            LayerStruct layer = FromFileStream<LayerStruct>(fs);
            byte[] objects = new byte[layer.Bytes];

            fs.Read(objects);
            return RLE.RLEDecompress(objects);
        }

        //Thank god for stackoverflow.
        private T FromFileStream<T>(FileStream fs, int offset = 0)
        {
            int sizeOfT = Marshal.SizeOf(typeof(T));
            byte[] data = new byte[sizeOfT];
            fs.Read(data, offset, sizeOfT);

            if (data == null)
                return default(T);

            IntPtr ptr = IntPtr.Zero;
            try
            {
                int size = Marshal.SizeOf(typeof(T));
                ptr = Marshal.AllocHGlobal(size);
                Marshal.Copy(data, 0, ptr, size);
                object obj = Marshal.PtrToStructure(ptr, typeof(T));
                return (T)obj;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
