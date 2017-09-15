using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace MobileCenter.Commands.Test
{
    
    public class TestRunFile
    {
        readonly string sourcePath;
        readonly string targetRelativePath;
        string sha256;
        readonly TestRunFileType testRunfileType;

        public TestRunFile(string sourcePath, string targetRelativePath, string sha256, TestRunFileType fileType)
        {
            this.sourcePath = sourcePath;
            this.targetRelativePath = targetRelativePath.Replace(@"\\", @"/");
            this.Sha256 = sha256;
            this.testRunfileType = fileType;

        }

        public string SourcePath => sourcePath;

        public string TargetRelativePath => targetRelativePath;

        public TestRunFileType TestRunfileType => testRunfileType;

        public string Sha256 { get => sha256; set => sha256 = value; }

        public TestRunFile Create(string sourcePath, string targetRelativePath, TestRunFileType fileType)
        {
            FileStream fileInfo = new FileStream(sourcePath, FileMode.Open)
            {
                Position = 0
            };

            SHA256 hash = SHA256.Create();
            byte[] hashValue=hash.ComputeHash(fileInfo);
            Sha256= BitConverter.ToString(hashValue).Replace("-","");
            fileInfo.Close();
            
            var result= new TestRunFile(sourcePath, targetRelativePath, Sha256, fileType);
            return result;
        
        }         

    }
    public enum TestRunFileType
    {
        appfile,
        testfile
    }
}
