using System;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Globalization;

namespace MSTranslator
{
    class TranslatorAPI
    {
        public static string route = "/translate?api-version=3.0&to=zh-Hant&to=zh-Hans&to=es&to=fr&to=ru"; //"/translate?api-version=3.0&from=en&to=zh-Hant&to=zh-Hans&to=es&=fr";
        private static readonly string key = Properties.Settings.Default.AccessKey;    //Your access key
        private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com";
        //https://learn.microsoft.com/zh-tw/azure/cognitive-services/translator/language-support

        // location, also known as region.
        // required if you're using a multi-service or regional (not global) resource. It can be found in the Azure portal on the Keys and Endpoint page.
        private static readonly string location = "global";

        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        public class TranslationClass
        {
            public DetectedLanguage detectedLanguage { get; set; }
            public List<Translation> translations { get; set; }
        }

        public class DetectedLanguage
        {
            public string language { get; set; }
            public double score { get; set; }
        }

        public class Translation
        {
            public string text { get; set; }
            public string to { get; set; }
        }

        public static async Task<string> Translate(string inputText)
        {
            //string textToTranslate = "I would really like to drive your car around the block a few times!";
            object[] body = new object[] { new { Text = inputText } };
            string requestBody = JsonConvert.SerializeObject(body);

            using (HttpClient client = new HttpClient())
            using (HttpRequestMessage request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                // location required if you're using a multi-service or regional (not global) resource.
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Read response as a string.

                string result = await response.Content.ReadAsStringAsync();
                List<TranslationClass> translationClass = JsonConvert.DeserializeObject<List<TranslationClass>>(result);
                string tempText = "";
                CultureInfo myCIintl;
                myCIintl = new CultureInfo(translationClass[0].detectedLanguage.language, false);
                //confidence
                tempText = $"來源語言:{myCIintl.DisplayName}\n偵測準確度:{Convert.ToInt32(translationClass[0].detectedLanguage.score * 100)}%\n\n\n";

                foreach (Translation translation in translationClass[0].translations)
                {
                    myCIintl = new CultureInfo(translation.to, false);
                    tempText += myCIintl.DisplayName + ":\n" + translation.text + "\n\n";
                }
                return tempText;
            }
        }
    }
}
