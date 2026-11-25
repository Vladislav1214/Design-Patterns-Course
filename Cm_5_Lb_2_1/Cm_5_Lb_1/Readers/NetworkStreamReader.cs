using Cm_5_Lb_1.Interfase;
using System;
using System.IO;
using System.Net.Http;

namespace Cm_5_Lb_1.Readers
{
    public class NetworkStreamReader : IDataReader
    {
        private static readonly HttpClient _client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        public bool Exists(string source)
        {
            return Uri.TryCreate(source, UriKind.Absolute, out var uri)
                   && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }

        public Stream Open(string source)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, source);

            var response = _client.Send(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStream();
        }
    }
}
