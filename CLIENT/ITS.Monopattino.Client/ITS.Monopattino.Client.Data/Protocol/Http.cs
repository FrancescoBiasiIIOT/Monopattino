using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ITS.Monopattino.Client.Data.Protocol
{  
        public class Http : IProtocol
        {
            private string endpoint;
            private HttpWebRequest httpWebRequest;

            public Http(string endpoint)
            {
                this.endpoint = endpoint;
            }

            public void Send(string data)
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(endpoint);
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                Console.Out.WriteLine(httpResponse.StatusCode);

                httpResponse.Close();
            }
        }
    
}
