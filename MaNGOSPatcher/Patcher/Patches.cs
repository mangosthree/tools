using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaNGOSatcher
{
    internal class PatchBytes
    {
        public int Offset;
        public byte[] Unpatched;
        public byte[] Patched;
        public PatchBytes(int offset, byte[] unpatched, byte[] patched)
        {
            Offset = offset;
            Unpatched = unpatched;
            Patched = patched;
        }
    }

    internal abstract class PatchInfo
    {
        public int ExeLength;
        public List<PatchBytes> Patches = new List<PatchBytes>();
        protected abstract void Init();
        public PatchInfo()
        {
            Init();
        }
    }

    // WoW 4.3.4 15595
    class Patch434Win : PatchInfo
    {
        protected override void Init()
        {
            ExeLength = 10474064;

            Patches.Add(new PatchBytes(0x737A,
                                   new byte[] { 0xE8, 0xB1, 0xED, 0xFF, 0xFF },
                                   new byte[] { 0xB8, 0x01, 0x00, 0x00, 0x00 }));

            Patches.Add(new PatchBytes(0x889CA,
                                       new byte[] { 0x8B, 0x55, 0x0C, 0x83, 0xFA, 0x02, 0x75 },
                                       new byte[] { 0xBA, 0x00, 0x00, 0x00, 0x00, 0x90, 0xEB }));

            Patches.Add(new PatchBytes(0x883AE,
                                       new byte[] { 0x74 },
                                       new byte[] { 0xEB }));
        }
    }

    class Patch434Win64 : PatchInfo
    {
        protected override void Init()
        {
            ExeLength = 13592144;

            // Patch #2a: Send function - NOP the je that skips type=0 path
            Patches.Add(new PatchBytes(0xAAB6F,
                                       new byte[] { 0x74, 0x08 },
                                       new byte[] { 0x90, 0x90 }));

            // Patch #2b: Send function - xor edx, edx to force type=0
            Patches.Add(new PatchBytes(0xAAB71,
                                       new byte[] { 0x41, 0x8B, 0xD5 },
                                       new byte[] { 0x31, 0xD2, 0x90 }));

            // Patch #3: NetClient - force connection[0] lookup
            Patches.Add(new PatchBytes(0xA9AD3,
                                       new byte[] { 0x74, 0x10 },
                                       new byte[] { 0xEB, 0x10 }));
        }
    }
}
	
