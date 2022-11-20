using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Megalaba_COM
{
    [Guid("EAA4976A-45C3-4BC5-BC0B-E474F4C3C840")]
    public interface ComClass1Interface
    {
        bool IsReady();
        bool[] IsChoisesMade();
        void SendData(byte data);
        byte GetData();
    }

    [Guid("7BD20046-DF8C-44A6-8F6B-687FAA26FA72"),
        InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ComClass1Events
    {

    }

    [Guid("0D53A3E8-E51A-49C7-944E-E72A2064F939"),
        ClassInterface(ClassInterfaceType.None),
        ComSourceInterfaces(typeof(ComClass1Events))]
    public class ComClass1 : ComClass1Interface
    {
        public static MemoryMappedFile mmf;
        public static MemoryMappedFile mmf_ready;
        //public static StreamReader reader = new StreamReader(mmf.CreateViewStream(), System.Text.Encoding.ASCII);
        //public static StreamWriter writer = new StreamWriter(mmf.CreateViewStream(), System.Text.Encoding.ASCII);
        public static string data = "";
        public static bool mode;//true - connect to game, false - create
        public static byte LastOpponentChoise = 0x10;
        public ComClass1()
        {
            try
            {
                mmf = MemoryMappedFile.OpenExisting("Megalaba");
                mmf_ready = MemoryMappedFile.OpenExisting("Megalaba_ready");
                mode = true;
                byte[] temp;
                using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, 0))
                {
                    BinaryReader reader = new BinaryReader(stream);
                    temp = reader.ReadBytes(2);
                    //Array.Reverse(temp);
                }
                using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, 0))
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    temp[1] = 0x20;
                    writer.Write(temp);
                    writer.Flush();
                }
                using (MemoryMappedViewStream stream = mmf_ready.CreateViewStream(0, 0))
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    writer.Write(0x11);
                    writer.Flush();
                }



            }
            catch (FileNotFoundException)
            {
                mmf = MemoryMappedFile.CreateNew("Megalaba", 2);
                mmf_ready = MemoryMappedFile.CreateNew("Megalaba_ready", 1);
                mode = false;

                using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, 0))
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    writer.Write(0x10);
                    writer.Flush();
                }
                using (MemoryMappedViewStream stream = mmf_ready.CreateViewStream(0, 0))
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    writer.Write(0x10);
                    writer.Flush();
                }//на самом деле не нужен
            }
        }
        public bool IsReady()
        {
            using (MemoryMappedViewStream stream = mmf_ready.CreateViewStream(0, 0))
            {
                BinaryReader reader = new BinaryReader(stream);
                byte[] temp = reader.ReadBytes(1);
                if (temp[0] == 0x11)
                    return true;
                else
                    return false;
            }
        }
        public bool[] IsChoisesMade()
        {
            bool[] bools = new bool[3] { false, false, false };//0 - игроки сделали выбор, 1 - ты победил, 2 - ничья
            byte[] temp;
            using (MemoryMappedViewStream stream = mmf_ready.CreateViewStream(0, 0))
            {
                BinaryReader reader = new BinaryReader(stream);
                temp = reader.ReadBytes(1);
            }
            if (temp[0] == 0x22 || temp[0] == 0x32 || temp[0] == 0x23)
            {
                bools[0] = true;
                byte[] vibory;
                if ((mode == false && temp[0] == 0x23) || (mode == true && temp[0] == 0x32))
                    using (MemoryMappedViewStream stream = mmf_ready.CreateViewStream(0, 0))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(0x11);
                        writer.Flush();
                    }
                if (temp[0] == 0x22)
                {
                    if (mode == false) using (MemoryMappedViewStream stream = mmf_ready.CreateViewStream(0, 0))
                        {
                            BinaryWriter writer = new BinaryWriter(stream);
                            writer.Write(0x32);
                            writer.Flush();
                        }
                    else using (MemoryMappedViewStream stream = mmf_ready.CreateViewStream(0, 0))
                        {
                            BinaryWriter writer = new BinaryWriter(stream);
                            writer.Write(0x23);
                            writer.Flush();
                        }
                }
                using (MemoryMappedViewStream stream1 = mmf.CreateViewStream(0, 0))
                {
                    BinaryReader reader1 = new BinaryReader(stream1);
                    vibory = reader1.ReadBytes(2);
                }//0x11 - rock, 0x12 - paper, 0x13 - scissors

                if (mode == false)
                {
                    LastOpponentChoise = vibory[1];
                }
                else
                {
                    LastOpponentChoise = vibory[0];
                }
                if ((vibory[0] == 0x11 && vibory[1] == 0x11)
                    || (vibory[0] == 0x12 && vibory[1] == 0x12)
                    || (vibory[0] == 0x13 && vibory[1] == 0x13))
                { bools[2] = true; return bools; }
                
                if (vibory[0] == 0x11 && vibory[1] == 0x12) 
                { 
                    if(mode==false) bools[1] = false;
                    else bools[1] = true; 
                    return bools; 
                }
                if (vibory[0] == 0x11 && vibory[1] == 0x13)
                {
                    if (mode == false) bools[1] = true;
                    else bools[1] = false;
                    return bools;
                }
                if (vibory[0] == 0x12 && vibory[1] == 0x11)
                {
                    if (mode == false) bools[1] = true;
                    else bools[1] = false;
                    return bools;
                }
                if (vibory[0] == 0x12 && vibory[1] == 0x13)
                {
                    if (mode == false) bools[1] = false;
                    else bools[1] = true;
                    return bools;
                }
                if (vibory[0] == 0x13 && vibory[1] == 0x11)
                {
                    if (mode == false) bools[1] = false;
                    else bools[1] = true;
                    return bools;
                }
                if (vibory[0] == 0x13 && vibory[1] == 0x12)
                {
                    if (mode == false) bools[1] = true;
                    else bools[1] = false;
                    return bools;
                }
                throw new Exception("Что-то пошло не так");
            }
            else
                return bools;
        }
        public void SendData(byte data)//0x11 - rock, 0x12 - paper, 0x13 - scissors
        {
            byte[] temp;
            byte[] temp_state;
            using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, 0))
            {
                BinaryReader reader = new BinaryReader(stream);
                temp = reader.ReadBytes(2);
                //Array.Reverse(temp);
            }
            using (MemoryMappedViewStream stream = mmf_ready.CreateViewStream(0, 0))
            {
                BinaryReader reader = new BinaryReader(stream);
                temp_state = reader.ReadBytes(1);
            }

            using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, 0))
            {
                BinaryWriter writer = new BinaryWriter(stream);
                //clear mmf

                if (mode == false)
                {
                    temp[0] = data;
                    writer.Write(temp);
                    writer.Flush();

                }
                else
                {
                    temp[1] = data;
                    writer.Write(temp);
                    writer.Flush();
                }
            }
            using (MemoryMappedViewStream stream = mmf_ready.CreateViewStream(0, 0))
            {
                BinaryWriter writer = new BinaryWriter(stream);
                if (mode == false)
                {
                    if (temp_state[0] == 0x12) writer.Write(0x22);
                    else writer.Write(0x21);
                }
                else
                {
                    if (temp_state[0] == 0x21) writer.Write(0x22);
                    else writer.Write(0x12);
                }
            }
        }
        public byte GetData()
        {/*
            byte[] state;
            using (MemoryMappedViewStream stream = mmf_ready.CreateViewStream(0, 0))
            {
                BinaryReader reader = new BinaryReader(stream);
                state = reader.ReadBytes(1);
            }
            if (state[0] == 0x32 || state[0] == 0x23)
            {
                byte[] temp;
                using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, 0))
                {
                    BinaryReader reader = new BinaryReader(stream);
                    temp = reader.ReadBytes(2);
                }
                if (mode == false)
                {
                    return temp[1];
                }
                else
                {
                    return temp[0];
                }
            }
            else return 0x10;
            */
            return LastOpponentChoise;
        }
    }
}
