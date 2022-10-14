using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace HttpClientImplement.Services
{
    public class HttpClientInterceptor: DelegatingHandler
    {
        public HttpClientInterceptor()
        {


        }
        //protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        //{
          
        //    request.Headers.Authorization = new AuthenticationHeaderValue("bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c");
        //    return base.Send(request, cancellationToken);
        //}

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
    

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer","eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c");
            return base.SendAsync(request, cancellationToken);
        }

    }
}
