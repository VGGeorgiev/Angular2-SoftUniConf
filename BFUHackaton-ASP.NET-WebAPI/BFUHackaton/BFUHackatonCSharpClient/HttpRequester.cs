namespace BFUHackatonCSharpClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    class HttpRequester
    {
        private const string MediaType = "application/json";
        private string baseUrl;
        private HttpClient client;


        public HttpRequester(string baseUrl)
        {
            this.baseUrl = baseUrl;
            this.client = new HttpClient();
        }

        public async Task<T> Make<T>(HttpMethod method, string serviceUrl, string bearer, object data = null, string mediaType = MediaType)
        {
            var request = this.GetRequestMessage(serviceUrl, method, bearer, data, mediaType);
            var response = await this.client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }

        private HttpRequestMessage GetRequestMessage(string uri, HttpMethod method, string bearer, object data, string mediaType)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(this.baseUrl + uri),
                Method = method,
                Headers =
                {
                    Accept = { new MediaTypeWithQualityHeaderValue(mediaType) },
                    Authorization = new AuthenticationHeaderValue("Bearer", bearer)
                },
            };

            if (data != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(data))
                {
                    Headers = {ContentType = new MediaTypeHeaderValue(mediaType)}
                };
            }

            return request;
        }
    }
}
