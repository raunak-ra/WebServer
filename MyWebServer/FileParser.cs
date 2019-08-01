using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class FileParser
    {
       
        static readonly string ServerPath = @"C:\Users\rsingh\source\repos\MyWebServer\MyWebServer\WebFile\";
        public byte[] ParseFile(string rawUrl)
        {
            byte[] lines;

            if (File.Exists(ServerPath + rawUrl))
            {
                lines = File.ReadAllBytes(ServerPath + rawUrl);
            }
            else
            {
                lines = File.ReadAllBytes(ServerPath + "notfound.jpg");
            }
         
            return lines;
           
        }
    }
}
