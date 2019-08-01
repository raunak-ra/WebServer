using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    class WebServer
    {
        static void Main(string[] args)
        {
            string[] prefixes = { "http://localhost:8000/"};
             Listener(prefixes);
        }


        public static void Listener(string[] prefixes)
        {
         
            HttpListener listener = new HttpListener();
            
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();
            Console.WriteLine("Listening...");
           
            while (true)
            {
                HttpListenerContext context = listener.GetContext();      
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
              
                FileParser fileParser = new FileParser();
                string rawUrl = request.RawUrl;
                byte[] buffer = fileParser.ParseFile(rawUrl);

                FileIdentifier fIleIdentifier = new FileIdentifier();
               string fileType =  fIleIdentifier.IdentifyFileType(rawUrl);

                response.AddHeader("Content-Type", fileType);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
                
            }

           
        }
    }
}
