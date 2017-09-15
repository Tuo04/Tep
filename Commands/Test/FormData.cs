using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MobileCenter.Commands.Test
{
    class FormData
    {
        string relativePath;
        Stream file;
        string fileType;
        public FormData(TestRunFile file)
        {
            this.RelativePath = file.TargetRelativePath;
            this.File = new FileStream(file.SourcePath, FileMode.Open);
            this.FileType = file.TestRunfileType.ToString();

        }

        public string RelativePath { get => relativePath; set => relativePath = value; }
        public Stream File { get => file; set => file = value; }
        public string FileType { get => fileType; set => fileType = value; }
    }
}
