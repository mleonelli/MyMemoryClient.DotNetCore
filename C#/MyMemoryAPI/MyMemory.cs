using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyMemoryAPI
{
    public class MyMemory
    {
        private static string myMemoryBaseUrl = "http://api.mymemory.translated.net";
        private bool IsAuthenticated = false;
        
        private string key;
        private string email;
        private string ip = null;

        public MyMemory(){

        }

        public MyMemory(string key, string email)
        {
            this.key = key;
            this.email = email;
        }

        public MyMemory(string key, string email, string ip)
        {
            this.key = key;
            this.email = email;
            this.ip = ip;
        }

        public MyMemoryGetResponse Get(string sentence, RegionInfo sourceLanguage, RegionInfo destinationLanguage)
        {
            string uri = "/get" +
                "?" +
                "q=" + Uri.EscapeDataString(sentence) + "&" +
                "langpair=" + sourceLanguage.Name + "|" + destinationLanguage.Name;

            if (this.key != null)
            {
                uri +=
                    "&" + "key=" + this.key +
                    "&" + "de=" + this.email;
                if (this.ip != null)
                    uri += "&" + "ip=" + this.ip;
            }

            return Get(uri, OutputFormat.Json);
        }

        public MyMemoryGetResponse Get(string sentence, RegionInfo sourceLanguage, RegionInfo destinationLanguage, OutputFormat outFormat = OutputFormat.Json, bool machineTranslation = true, bool OnlyPrivateMT = false)
        {
            string outFormatString = OuputFormat(outFormat);
            string uri = "/get" +
                "?" +
                "q=" + Uri.EscapeDataString(sentence) + "&" +
                "langpair=" + sourceLanguage.Name + "|" + destinationLanguage.Name + "&" +
                "mt=" + Convert.ToInt32(machineTranslation) + "&" +
                "of=" + outFormatString;

            if (this.key != null)
            {
                uri +=
                    "&" + "key=" + this.key +
                    "&" + "de=" + this.email;
                if (this.ip != null)
                    uri += "&" + "ip=" + this.ip;
                uri += "&" + "onlyprivate=" + Convert.ToInt32(OnlyPrivateMT);
            }

            return Get(uri, outFormat);
        }

        private static string OuputFormat(OutputFormat outFormat)
        {
            if (outFormat == null)
                return "json";

            switch (outFormat)
            {
                case OutputFormat.Json:
                    return "json";
                case OutputFormat.Tmx:
                    return "tmx";
                case OutputFormat.Array:
                    return "array";
                default:
                    return "json";
            }
        }

        private MyMemoryGetResponse Get(string uri, OutputFormat outFormat)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(myMemoryBaseUrl);

            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                MyMemoryGetResponse ajsonObject = JsonConvert.DeserializeObject<MyMemoryGetResponse>(response.Content.ReadAsStringAsync().Result);
                return ajsonObject;
            }
            else
            {
                throw new Exception("Response Exception");
            }
            
        }

        public MyMemorySetResponse Set(string segment, string translation, RegionInfo sourceLanguage, RegionInfo destinationLanguage)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(myMemoryBaseUrl);


            string uri = "/set" +
                "?" +
                "seg=" + segment + "&" +
                "tra=" + translation + "&" +
                "langpair=" + sourceLanguage.Name + "|" + destinationLanguage.Name;

            if (this.key != null)
            {
                uri +=
                    "&" + "key=" + this.key +
                    "&" + "de=" + this.email;
            }

            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                MyMemorySetResponse ajsonObject = JsonConvert.DeserializeObject<MyMemorySetResponse>(response.Content.ReadAsStringAsync().Result);
                return ajsonObject;
            }
            else
            {
                throw new Exception("Response Exception");
            }
        }

        public MyMemoryGetResponse Keygen(string username, string password)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(myMemoryBaseUrl);

            string uri = "/keygen" +
                "?" +
                "user=" + Uri.EscapeDataString(username) + "&" +
                "pass=" + Uri.EscapeDataString(password);

            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                MyMemoryGetResponse ajsonObject = JsonConvert.DeserializeObject<MyMemoryGetResponse>(response.Content.ReadAsStringAsync().Result);
                return ajsonObject;
            }
            else
            {
                throw new Exception("Response Exception");
            }
        }
    }
}
