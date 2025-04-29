using FilePropertyViewer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePropertyViewer.Services
{
    public class FileService
    {
        public List<FileModel> GetFiles(string directoryPath)
        {
            var fileList = new List<FileModel>();

            if (!Directory.Exists(directoryPath))
            {
                return fileList;
            }

            var files = Directory.GetFiles(directoryPath);
            foreach (var filePath in files)
            {
                var fileInfo = new FileInfo(filePath);
                fileList.Add(new FileModel(fileInfo));
            }

            return fileList;
        }
    }
}
