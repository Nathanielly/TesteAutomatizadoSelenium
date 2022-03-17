using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public static class TestHelper
    {
        //( => ) expressão lambda
        public static string PastaDoExecutavel => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //camminho do executável do chrome.

    }
}
