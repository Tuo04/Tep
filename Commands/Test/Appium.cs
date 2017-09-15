using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCenter.Commands.Test
{
    class Appium
    {
        public string PrepareManifest(string artifactsDir)
        {
            var preparer = new AppiumPreparer(artifactsDir);

            return preparer.Prepare();
        }
    }
}
