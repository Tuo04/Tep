using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileCenter.APIClient;
using MobileCenter.APIClient.Models;

namespace MobileCenter.Commands.Test
{
    public class TestCloudUploader
    {
        private readonly MobileCenterClient client;
        private readonly string userName;
        private readonly string appName;
        private readonly string manifestPath;
        private readonly string devices;

        public string appPath;
        public string testSeries;
        public Dictionary<string, string> testParameters;

        public TestCloudUploader(MobileCenterClient client, string userName, string appName, string manifestPath, string devices)
        {
            this.client = client;
            this.manifestPath = manifestPath;
            this.devices = devices;
            this.userName = userName;
            this.appName = appName;
        }

        public void UploadAndStart() {
            string testRunId = this.CreateTestRun(this.client);
            this.StartTestRun(testRunId);
        }

        public void ValidateAndParseManifest() { }
        public void ValidateAndCreateAppFile() { }

        public string CreateTestRun(MobileCenterClient client)
        {
            var newTestRun = client.Test.CreateTestRun(this.userName, this.appName);
            var newTestRunId = (newTestRun.Location.Split('/').Last<string>());

            return newTestRunId;
        }

        public void StartTestRun(string testRunId)
        {
            TestCloudStartTestRunOptions startOption = new TestCloudStartTestRunOptions
            {
                DeviceSelection = this.devices,
                TestFramework = "Appium"
            };

            client.Test.StartTestRun(testRunId, startOption, this.userName, this.appName);

        }

    }
}
