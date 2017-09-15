using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MobileCenter.APIClient;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace MobileCenter.Commands.Test
{
    public class AppiumPreparer
    {
        private readonly string artifactsDir;
        
        public AppiumPreparer(string artifactsDir)
        {
            if (artifactsDir==null)
            {
                throw new Exception("Argument artifactsDir is required");
            }
            
            this.artifactsDir = artifactsDir;
            
        }

        public string Prepare()
        {
            string manifestPath = artifactsDir+"./Appium.json";

            return manifestPath;

        }
    }
}
