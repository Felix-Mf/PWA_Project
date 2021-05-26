using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWA_Project.Shared
{
    public class SaveFile
    {
        public List<FileData> Files { get; set; }
    }

    public class FileData
    {
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public long Size { get; set; }
    }
}
