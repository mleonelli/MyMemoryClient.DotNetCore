using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyMemoryAPI
{
    public class MyMemory
    {
        private static string myMemoryBaseUrl = "http://api.mymemory.translated.net";

        public static void Get()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(myMemoryBaseUrl);

            string uri = "/get" +
                "?" +
                "q=" + "Hello World!" + "&" +
                "langpair=" + "en|it";

            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                MyMemoryGetResponse ajsonObject = JsonConvert.DeserializeObject<MyMemoryGetResponse>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {

            }
        }

        public static void Set()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(myMemoryBaseUrl);


            string uri = "/set" +
                "?" +
                "seg=" + "Hello World!" + "&" +
                "tra=" + "Ciao Mondo!" + "&" +
                "langpair=" + "en|it";


            //form.Add(new StringContent(tra), "key");
            //form.Add(new StringContent(langpair), "de");
            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                MyMemoryGetResponse ajsonObject = JsonConvert.DeserializeObject<MyMemoryGetResponse>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {

            }
        }

        public static void Keygen(string username, string password)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(myMemoryBaseUrl);

            string uri = "/keygen";

            MultipartFormDataContent form = new MultipartFormDataContent();

            form.Add(new StringContent(username), "user");
            form.Add(new StringContent(password), "pass");

            HttpResponseMessage response = client.PostAsync(uri, form).Result;

            if (response.IsSuccessStatusCode)
            {
                MyMemoryGetResponse ajsonObject = JsonConvert.DeserializeObject<MyMemoryGetResponse>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {

            }
        }
    }
}
