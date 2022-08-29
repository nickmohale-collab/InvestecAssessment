using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections;

namespace Investec_Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://swapi.dev/api/people");
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(responseString);

                string filmNames = string.Empty;
                string[] filmArray;

                Console.WriteLine("Buddies");
                Console.WriteLine("=====================");
                foreach (JObject result in obj["results"])
                {
                    foreach (JProperty property in result.Properties())
                    {
                        if (property.Name.Contains("films"))
                        {
                            filmNames = property.Value.ToString();

                            filmArray = filmNames.TrimStart('[').TrimEnd(']').Split(',');

                            if (filmArray.Length < 2)
                            {
                                Console.WriteLine(string.Format(" {0}" , result.First.First));
                            }                        

                        }
                    }
                }
            }
        }

     

       
    }
}
