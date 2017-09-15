using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCenter.Commands.Test
{
    class TestManifest
    {
        string version;
        TestRunFile[] testFiles;
        TestRunFile applicationFile;
        string testFramework;

        public void TestMainfest(string version, TestRunFile applicationFile, TestRunFile[] files, string testFrameworkData)
        {
            this.version = version;
            this.applicationFile = applicationFile;
            this.testFiles = files;
            this.testFramework = testFrameworkData;
        }
    }
}
