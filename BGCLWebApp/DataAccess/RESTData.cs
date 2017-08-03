using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace BGLWebApp.DataAccess
{
    public class RESTData
    {
        public string GetRestData(string _endPointURL)
        {
            //Call the rest API
            string response = string.Empty;
            var client = new WebClient();
         
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36(KHTML, like Gecko) Chrome / 58.0.3029.110 Safari / 537.36");
            try
            {
                 response = client.DownloadString(_endPointURL);
            }

            catch(Exception ex)
            {
                
                return null;
            }

            return response;

        }
    }
}