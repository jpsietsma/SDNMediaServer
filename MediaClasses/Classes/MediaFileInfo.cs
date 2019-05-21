using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MediaClasses.Classes
{
    public class MediaFileInfo
    {
        public string FullName { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }
        public long Length { get; set; }
        public string Directory { get; set; }
        public string DirectoryName { get; set; }
        public DateTime CreationTime { get; set; }


        public MediaFileInfo(string filepath)
        {
            FileInfo info = new FileInfo(filepath);
            FullName = info.FullName;
            Extension = info.Extension;
            Name = info.Name;
            Length = info.Length;
            Directory = info.Directory.Parent.Name;
            DirectoryName = info.DirectoryName;
            CreationTime = info.CreationTime;
        }

        public MediaFileInfo(FileInfo info)
        {
            FullName = info.FullName;
            Extension = info.Extension;
            Name = info.Name;
            Length = info.Length;
            Directory = info.Directory.Parent.Name;
            DirectoryName = info.DirectoryName;
            CreationTime = info.CreationTime;
        }
    }
}
