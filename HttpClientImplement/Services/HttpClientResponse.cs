namespace HttpClientImplement.Services
{   public class HttpClientResponse<T> 
    {
        public bool IsSucsess { get; set; }

        public HttpResponseMessage responseMessage { get; set; }
      
        public T? Content { get; set; }
    }


}
