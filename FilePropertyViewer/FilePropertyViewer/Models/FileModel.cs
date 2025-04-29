using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace FilePropertyViewer.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public long Size { get; set; }
        public string SizeFormatted => FormatSize(Size);
        public DateTime CreationTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public string FileType { get; set; }
        public string Hash { get; set; }

        public FileModel(FileInfo fileInfo)
        {
            Name = fileInfo.Name;
            FullPath = fileInfo.FullName;
            Size = fileInfo.Length;
            CreationTime = fileInfo.CreationTime;
            LastWriteTime = fileInfo.LastWriteTime;
            FileType = fileInfo.Extension;
            Hash = CalculateFileHash(fileInfo.FullName);
        }

        private string CalculateFileHash(string filePath)
        {
            try
            {
                using (var sha256 = SHA256.Create())
                using (var stream = File.OpenRead(filePath))
                {
                    var hashBytes = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                }
            }
            catch (Exception)
            {
                return "Error calculating hash";
            }
        }

        private string FormatSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            if (bytes == 0)
                return "0 Bytes";
            int i = (int)(Math.Floor(Math.Log(bytes) / Math.Log(1024)));
            return Math.Round(bytes / Math.Pow(1024, i), 2) + " " + sizes[i];
        }
    }
}
