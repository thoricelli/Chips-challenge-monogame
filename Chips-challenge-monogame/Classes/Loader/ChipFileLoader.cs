using CHIPS_CHALLENGE.Classes.Entities;
using CHIPS_CHALLENGE.Classes.Items;
using CHIPS_CHALLENGE.Classes.Items.Enums;
using CHIPS_CHALLENGE.Classes.Loader.ChipFile;
using CHIPS_CHALLENGE.Classes.Loader.ChipFile.Fields;
using CHIPS_CHALLENGE.Classes.Loader.ChipFile.Fields.Enums;
using CHIPS_CHALLENGE.Classes.Sprites;
using CHIPS_CHALLENGE.Classes.Utilities;
using Microsoft.Xna.Framework;
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
        public ChipFileInformation LoadLevelFromFile(int level, bool populateLevel = true)
        {
            ChipFileInformation chipInfo = new ChipFileInformation();

            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fs = File.Open(filepath, FileMode.Open);

            //Base of the file.
            Base chipBase = FromFileStream<Base>(fs);
            chipInfo.NumberOfLevels = chipBase.NumberOfLevels;

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
            if (populateLevel)
            {
                byte[] layer1 = DecompressLayer(fs);
                byte[] layer2 = DecompressLayer(fs);

                List<byte[]> layers = new List<byte[]>() { layer1, layer2 };

                foreach (byte[] layer in layers)
                {
                    chipInfo.layers.Add(ToLayer(layer));
                }
            } else
            {
                LayerStruct layer = FromFileStream<LayerStruct>(fs);
                fs.Seek(layer.Bytes, SeekOrigin.Current);
                LayerStruct layer2 = FromFileStream<LayerStruct>(fs);
                fs.Seek(layer2.Bytes, SeekOrigin.Current);
            }

            PopulateFields(chipInfo, fs, populateLevel);

            fs.Close();

            return chipInfo;
        }

        public List<ChipFileInformation> GetAllLevels()
        {
            FileStream fs = File.Open(filepath, FileMode.Open);
            Base chipBase = FromFileStream<Base>(fs);
            fs.Close();

            int level = 1;

            List<ChipFileInformation> fileInfo = new List<ChipFileInformation>();

            do
            {
                fileInfo.Add(LoadLevelFromFile(level, false));
                level++;
            } while (chipBase.NumberOfLevels >= level);

            return fileInfo;
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
                case Objects.HERO_NORTH:
                case Objects.HERO_WEST:
                case Objects.HERO_SOUTH:
                case Objects.HERO_EAST:
                    ChipGame.SetSpawnLocation(index);
                    code = (byte)Objects.EMPTY;
                    break;
            }
            return code;
        }

        private void PopulateFields(ChipFileInformation chipInfo, FileStream fs, bool populateLevel)
        {
            //Now we need to parse the fields.
            byte[] sizeByte = new byte[2];
            fs.ReadAsync(sizeByte);

            int endAddress = (int)fs.Position + BitConverter.ToUInt16(sizeByte, 0);

            do
            {
                ReadField(chipInfo, fs, populateLevel);
            } while (fs.Position < endAddress);
        }

        private void ReadField(ChipFileInformation chipInfo, FileStream fs, bool populateLevel)
        {
            /* Read the first number as an INT, field number.
               Probably the best way to solve this is, not have fields but variables
               inside of the fileinfo class.
               Maybe just give the gameinfo as an argument, and let this function fill it up.
               annoying!
            */
            Field field = FromFileStream<Field>(fs);
            switch ((FieldEnum)(field.Type-1))
            {
                case FieldEnum.MAP_TITLE:
                    chipInfo.MapTitle = ReadString(field.Bytes, fs);
                    break;
                case FieldEnum.TRAP_CONTROLS:
                    int endTrap = (int)(fs.Position + field.Bytes);
                    do
                    {
                        ChipFile.Trap trap = FromFileStream<ChipFile.Trap>(fs);
                        chipInfo.Traps.Add(trap);
                    } while (fs.Position < endTrap);
                    break;
                case FieldEnum.CLONING_CONTROLS:
                    int endClone = (int)(fs.Position + field.Bytes);
                    do
                    {
                        CloneMachine cloneMachine = FromFileStream<CloneMachine>(fs);
                        chipInfo.CloneMachines.Add(cloneMachine);
                    } while (fs.Position < endClone);
                    break;
                case FieldEnum.MAP_PASSWORD:
                    byte[] mapPassword = new byte[field.Bytes-1];
                    fs.ReadAsync(mapPassword);
                    fs.Seek(0x1, SeekOrigin.Current);
                    chipInfo.Password = DecryptPassword(mapPassword);
                    break;
                case FieldEnum.MAP_HINT:
                    chipInfo.HintText = ReadString(field.Bytes, fs);
                    break;
                case FieldEnum.MOVEMENT:
                    int endMovement = (int)(fs.Position + field.Bytes);
                    do
                    {
                        Monster monster = FromFileStream<Monster>(fs);
                        Vector2 position = new Vector2(monster.X*32, monster.Y*32);

                        if (populateLevel)
                        {
                            Objects code = chipInfo.layers[0].objects[GeneralUtilities.ConvertFromVectorToIndex(position)].code;
                            //TEMP
                            chipInfo.layers[0].objects[GeneralUtilities.ConvertFromVectorToIndex(position)] = ItemFactory.CreateObjectFromCode(Objects.EMPTY);
                            ChipGame.AddEnemy(EnemyFactory.CreateObjectFromCode(code, position));
                        }
                    } while (fs.Position < endMovement);
                    break;
                default:
                    fs.Seek(field.Bytes, SeekOrigin.Current);
                    break;
            }
        }
        private string ReadString(int size, FileStream fs)
        {
            byte[] title = new byte[size];
            fs.ReadAsync(title);
            return Encoding.Default.GetString(title);
        }
        private string DecryptPassword(byte[] password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                password[i] ^= 0x99;
            }
            return Encoding.Default.GetString(password);
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
