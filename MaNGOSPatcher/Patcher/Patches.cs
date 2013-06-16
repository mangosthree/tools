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
}
	
