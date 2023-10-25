using System;

namespace LumpStich
{
    public class Bsp_Header
    {
        public string identity;
        public int versionA;
        public int file_offset;
        public int file_length;
        public int versionB;
        public Byte[] compressed_length;
        public int revision;
    }
}