using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ITS.Monopattino.Client.Data.Protocol
{  
        public class HttpRepository : IProtocol
        {
            private readonly string ConnectionString;
            private readonly IConfiguration configuration;
            private HttpWebRequest httpWebRequest;

            public HttpRepository(IConfiguration configuration)
            {
                this.configuration = configuration;
                ConnectionString = this.configuration.GetConnectionString("EndPoint");
            }

            public void Send(string data)
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(ConnectionString);
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
