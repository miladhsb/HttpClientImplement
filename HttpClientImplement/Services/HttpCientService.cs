using System.Net.Http.Headers;

namespace HttpClientImplement.Services
{
    public class HttpCientService:IHttpCientService
    {
         private readonly HttpClient _client;
        public HttpCientService(HttpClient Client)
        {
            _client = Client;
         
           // _client.BaseAddress=new Uri("");
          //  _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer","123456");
        }

        public async Task<HttpClientResponse<string>> GetStringAsync(string Url)
        {
            var result = await _client.GetAsync(Url);

            if (!result.IsSuccessStatusCode)
            {

                return new HttpClientResponse<string>()
                {
                    IsSucsess = false,
                    responseMessage = result,
                };


            }
            return new HttpClientResponse<string>()
            {

                IsSucsess = true,
                responseMessage = result,
                Content = await result.Content.ReadAsStringAsync()
            };


        }

        public async Task<HttpClientResponse<T>> GetAsync<T>(string Url)
        {
          var result=  await _client.GetAsync(Url);

            if (!result.IsSuccessStatusCode)
            {

                return new HttpClientResponse<T>()
                {
                    IsSucsess = false,
                    responseMessage = result, 
                };


            }
            return new HttpClientResponse<T>()
            {

                IsSucsess = true,
                responseMessage = result,
                Content=await result.Content.ReadFromJsonAsync<T>()
            };


        }

        public async Task<HttpClientResponse<Out>> PostAsync<In,Out>(string Url,In Input)
        {
            var content = JsonContent.Create(Input);
            if (content==null)
            {
                throw new NullReferenceException("مقدار ورودی خالی است");
            }

            var result = await _client.PostAsync(Url, content);

          
            if (!result.IsSuccessStatusCode)
            {

                return new HttpClientResponse<Out>()
                {
                    IsSucsess = false,
                    responseMessage = result,
                };


            }
            return new HttpClientResponse<Out>()
            {
                IsSucsess = true,
                responseMessage = result,
                Content = await result.Content.ReadFromJsonAsync<Out>()
            };
        }



    }
}
